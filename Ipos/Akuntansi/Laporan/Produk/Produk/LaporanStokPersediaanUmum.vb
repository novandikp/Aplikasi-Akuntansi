Public Class LaporanStokPersediaanUmum

    Dim dataLaporan As New DataTable
        Dim dv As DataView
        Dim sql As String

        Public ringkasan As Boolean = False
        Sub getDataLaporan()

            Dim cari As String = eCari.Text
        sql = "(select 0 as idhistoristok,tblproduk.produk, tblsatuan.satuan, max(tglhistori) as tglhistori, 0 as masuk,0 as keluar, 0 as hpp, sum(masuk -keluar) as sisa,
round(sum((masuk -keluar)* hpp)/sum(masuk -keluar)) as sisahpp from tblhistoristok inner join tblproduk on tblhistoristok.idproduk = tblproduk.idproduk inner join tblsatuan on tblsatuan.kodesatuan = tblhistoristok.idsatuan
where tglhistori < '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' GROUP by tblproduk.idproduk, tblsatuan.kodesatuan)
UNION  
(select idhistoristok,tblproduk.produk, tblsatuan.satuan,tglhistori , masuk, keluar ,hpp, sum(masuk-keluar) over (PARTITION by tblhistoristok.idproduk, tblhistoristok.idsatuan order by tglhistori,idhistoristok) + COALESCE( T.awal,0)
as sisa, round((sum((masuk-keluar) * hpp)  over (PARTITION by tblhistoristok.idproduk, tblhistoristok.idsatuan order by tglhistori,idhistoristok) + COALESCE(T.awalhpp,0))/ (sum(masuk-keluar) over (PARTITION by tblhistoristok.idproduk, tblhistoristok.idsatuan order by tglhistori,idhistoristok) + COALESCE( T.awal,0))) as sisahpp from tblhistoristok 
inner join tblproduk on tblhistoristok.idproduk = tblproduk.idproduk 
inner join tblsatuan on tblsatuan.kodesatuan = tblhistoristok.idsatuan 
left join (SELECT sum(masuk-keluar)as awal,sum((masuk-keluar)* hpp) as awalhpp,idproduk,idsatuan from tblhistoristok where tglhistori < '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' GROUP by idproduk,idsatuan) T 
on T.idsatuan = tblsatuan.kodesatuan and T.idproduk = tblproduk.idproduk
where tglhistori BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' and '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "') order by produk, satuan,tglhistori, idhistoristok;"



        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        dv.RowFilter = "produk like '%" & cari & "%'"
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

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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