Public Class LaporanBukuBesar

    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String
    Sub getDataLaporan()
        sql = "
SELECT tblakun.akun , tblakun.kodeakun, tipe, tgljurnal, deskripsijurnal, koderefrensi, kodedepartemen , debit, kredit,
(sum(debit-kredit) over (PARTITION by tbljurnal.kodeakun  order by  tgljurnal, idjurnal)) as saldo, COALESCE(saldoawal,0) as saldoawal,
tblkontak.pelanggan 
from tblakun
left JOIN tbljurnal
on tblakun.kodeakun = tbljurnal.kodeakun and tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'
LEFT JOIN
(SELECT sum(debit-kredit) as saldoawal, kodeakun from tbljurnal where tgljurnal < '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' group by kodeakun) T
on tblakun.kodeakun = T.kodeakun
left join tblkontak on 
tbljurnal.kontak = tblkontak.idpelanggan
WHERE akun ILIKE '%" & eCari.Text & "%'
order by tbljurnal.kodeakun, tgljurnal, idjurnal"

        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        dv.RowFilter = "debit >= 0 and kredit >=0"
        ListSat.DataSource = dv

        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Akun"
            ListSat.Columns(1).HeaderText = "Kode Akun"
            ListSat.Columns(2).HeaderText = "Tipe"
            ListSat.Columns(3).HeaderText = "Tanggal"
            ListSat.Columns(4).HeaderText = "Deskripsi"
            ListSat.Columns(5).HeaderText = "Kode Refrensi"
            ListSat.Columns(6).HeaderText = "Kode Departemen"
            ListSat.Columns(7).HeaderText = "Debit"
            ListSat.Columns(8).HeaderText = "Kredit"
            ListSat.Columns(9).HeaderText = "Saldo"
            ListSat.Columns(10).HeaderText = "Saldo Awal"
            ListSat.Columns(11).HeaderText = "Kontak"
            ListSat.Columns(11).DisplayIndex = 2



        Catch ex As Exception

        End Try


    End Sub

    Public saldoawal As String = "0"

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
        PreviewBukuBesarSederhana.dataview = dataLaporan
        PreviewBukuBesarSederhana.Show()
    End Sub
End Class