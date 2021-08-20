Public Class LaporanStokOpname
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        Dim cari As String = eCari.Text
        If cbSub.SelectedIndex = 0 Then
            sql = "SELECT kodestokopname, produk,buku, fisik, satuan, gudang, tglstokopname, akun, departemen  from tblstokopname
inner join tblakun on tblakun.kodeakun = tblstokopname.kodeakun
inner join tblharga on tblharga.idharga = tblstokopname.idharga
inner join tblproduk on tblproduk.idproduk = tblharga.idbarang
inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan
inner join tblgudang on tblgudang.idgudang = tblstokopname.kodegudang
inner join tbldepartemen on tbldepartemen.iddepartemen = tblstokopname.kodedepartemen
where (tblproduk.idproduk like '%" & cari & "%' OR tblproduk.produk like '%" & cari & "%') and  tglstokopname BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'
"
        Else
            sql = "SELECT kodestokopname, produk,buku, fisik, satuan, gudang, tglstokopname, akun, departemen  from tblstokopname
inner join tblakun on tblakun.kodeakun = tblstokopname.kodeakun
inner join tblharga on tblharga.idharga = tblstokopname.idharga
inner join tblproduk on tblproduk.idproduk = tblharga.idbarang
inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan
inner join tblgudang on tblgudang.idgudang = tblstokopname.kodegudang
inner join tbldepartemen on tbldepartemen.iddepartemen = tblstokopname.kodedepartemen
where (tblproduk.idproduk like '%" & cari & "%' OR tblproduk.produk like '%" & cari & "%') and  tglstokopname BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "' and tblstokopname.kodegudang = '" & cbSub.SelectedValue & "'
"
        End If




        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        Debug.WriteLine("SQL CARI :" & sql)
        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode"
            ListSat.Columns(1).HeaderText = "Produk"
            ListSat.Columns(2).HeaderText = "Buku"
            ListSat.Columns(3).HeaderText = "Fisik"
            ListSat.Columns(4).HeaderText = "Satuan"
            ListSat.Columns(5).HeaderText = "Gudang"
            ListSat.Columns(6).HeaderText = "Tanggal"
            ListSat.Columns(7).HeaderText = "Akun"
            ListSat.Columns(8).HeaderText = "Departemen"

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
        PreviewStokopname.dataview = dv
        PreviewStokopname.Show()

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