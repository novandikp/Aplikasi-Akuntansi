Public Class LaporanStokOpname
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        Dim cari As String = eCari.Text
        If cbSub.SelectedIndex = 0 Then
            sql = "SELECT  tglstokopname,tblstokopname.kodestokopname, gudang,deskripsiopname, idproduk,produk,fisik,selisih,buku, satuan, hpp
from tbldetailstokopname inner join tblstokopname on tblstokopname.kodestokopname = tbldetailstokopname.kodestokopname
inner join tblgudang on tblstokopname.kodegudang = tblgudang.idgudang
inner join tblproduk on tblproduk.idproduk = tbldetailstokopname.kodebarang
inner join tblakun on tblakun.kodeakun = tblstokopname.kodeakun
inner join tblsatuan on tblsatuan.kodesatuan = tbldetailstokopname.idsatuan
where (tblproduk.idproduk like '%" & cari & "%' OR tblproduk.produk like '%" & cari & "%') and  tglstokopname BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'
"
        Else
            sql = "SELECT  tglstokopname,tblstokopname.kodestokopname, gudang,deskripsiopname, idproduk,produk,fisik,selisih,buku, satuan, hpp
from tbldetailstokopname inner join tblstokopname on tblstokopname.kodestokopname = tbldetailstokopname.kodestokopname
inner join tblgudang on tblstokopname.kodegudang = tblgudang.idgudang
inner join tblproduk on tblproduk.idproduk = tbldetailstokopname.kodebarang
inner join tblakun on tblakun.kodeakun = tblstokopname.kodeakun
inner join tblsatuan on tblsatuan.kodesatuan = tbldetailstokopname.idsatuan
where (tblproduk.idproduk like '%" & cari & "%' OR tblproduk.produk like '%" & cari & "%') and  tglstokopname BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "' and kodegudang = '" & cbSub.SelectedValue & "'
"
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