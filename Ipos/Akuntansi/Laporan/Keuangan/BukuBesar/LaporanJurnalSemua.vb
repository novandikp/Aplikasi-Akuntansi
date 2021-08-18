Public Class LaporanJurnalSemua

    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String
    Sub getDataLaporan()
        sql = "SELECT tipe as dari, tbljurnal.kodeakun as idakun, tblakun.akun, tgljurnal, deskripsijurnal as deskripsi, koderefrensi, kodedepartemen, debit, kredit, COALESCE(kodeprojek,'N\A') AS kodeprojek from tbljurnal	    
    inner JOIN tblakun
    on tbljurnal.kodeakun = tblakun.kodeakun
        WHERE deskripsijurnal ILIKE '%" & eCari.Text & "%'
        and  tbljurnal.tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'
        ORDER by tgljurnal,idjurnal"


        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv

        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Tipe"
            ListSat.Columns(1).HeaderText = "Kode Akun"
            ListSat.Columns(2).HeaderText = "Akun"
            ListSat.Columns(3).HeaderText = "Tanggal"
            ListSat.Columns(4).HeaderText = "Deskripsi"
            ListSat.Columns(5).HeaderText = "Kode Refrensi"
            ListSat.Columns(6).HeaderText = "Kode Departemen"
            ListSat.Columns(7).HeaderText = "Debit"
            ListSat.Columns(8).HeaderText = "Kredit"
            ListSat.Columns(9).HeaderText = "Kode Projek"


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

        PreviewJurnalSemua.dataview = dv

        PreviewJurnalSemua.Show()
    End Sub
End Class