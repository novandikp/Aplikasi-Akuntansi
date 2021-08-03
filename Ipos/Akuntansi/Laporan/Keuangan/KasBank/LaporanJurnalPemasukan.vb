Public Class LaporanJurnalPemasukan

    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String
    Sub getDataLaporan()
        sql = "SELECT tbltransaksi.kodetransaksi, asalakun.akun as akunasal, kontak, tgltransaksi,  deskripsitransaksi, 
 tujuanakun.akun as akuntujuan, besartransaksi, departemen, COALESCE(projek,'N\A') as projek, tipetransaksi 
 from tbldetailtransaksi
inner join tbltransaksi
on tbltransaksi.kodetransaksi = tbldetailtransaksi.idtransaksi
inner join tblkontak
on tblkontak.idpelanggan = tbltransaksi.kontak
inner join tblakun asalakun
on asalakun.kodeakun = tbltransaksi.akunasal
inner join tblakun tujuanakun
on tujuanakun.kodeakun = tbltransaksi.akunasal
inner join tbldepartemen on
tbldetailtransaksi.kodedepartemen = tbldepartemen.iddepartemen
left join tblprojek on
tblprojek.idprojek = tbldetailtransaksi.kodeprojek
        WHERE deskripsitransaksi ILIKE '%" & eCari.Text & "%'
        and tipetransaksi='M'  and  tgltransaksi BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'
        ORDER by tgltransaksi,kodetransaksi"
        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv

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

        PreviewJurnalPemasukan.dataview = dv

        PreviewJurnalPemasukan.Show()
    End Sub
End Class