Public Class LaporanJurnalPemasukan

    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String
    Sub getDataLaporan()
        sql = "SELECT tbltransaksi.kodetransaksi, asalakun.akun as akunasal, tblkontak.pelanggan, tgltransaksi,
 tujuanakun.akun as akuntujuan, jumlah as besartransaksi, departemen, COALESCE(projek,'N\A') as projek, tipetransaksi 
 from  tbltransaksi
inner join tblkontak
on tblkontak.idpelanggan = tbltransaksi.kontak
inner join tblakun asalakun
on asalakun.kodeakun = tbltransaksi.akunasal
inner join tblakun tujuanakun
on tujuanakun.kodeakun = tbltransaksi.akuntujuan
inner join tbldepartemen on
tbltransaksi.kodedepartemen = tbldepartemen.iddepartemen
left join tblprojek on
tblprojek.idprojek = tbltransaksi.kodeprojek
        WHERE tblkontak.pelanggan ILIKE '%" & eCari.Text & "%'
        and tipetransaksi='CD'  and  tgltransaksi BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'
        ORDER by tgltransaksi,kodetransaksi"
        Debug.WriteLine(sql)
        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv

        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Transaksi"
            ListSat.Columns(1).HeaderText = "Akun Asal"
            ListSat.Columns(2).HeaderText = "Kontak"
            ListSat.Columns(3).HeaderText = "Tanggal"
            ListSat.Columns(4).HeaderText = "Akun Tujuan"
            ListSat.Columns(5).HeaderText = "Nominal"
            ListSat.Columns(6).HeaderText = "Departemen"
            ListSat.Columns(7).HeaderText = "Projek"
            ListSat.Columns(8).Visible = False
        Catch ex As Exception

        End Try


    End Sub

    Public saldoawal As String = "0"
    Sub getSaldoAwal()





    End Sub

    Sub getAllTotal()


    End Sub

    Private Sub getSubKlasifikasi()

    End Sub

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getDataLaporan()
    End Sub





    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs)
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
        PreviewJurnalPengeluaran.dataview = dv
        PreviewJurnalPengeluaran.Show()
    End Sub
End Class