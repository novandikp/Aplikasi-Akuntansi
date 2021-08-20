Public Class LaporanMutasiPiutang


    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()
        Dim akunPiutangUsaha As String = "130001"
        If cbSub.SelectedIndex = 0 Then
            sql = "SELECT tblkontak.pelanggan,SUM(debit) as piutang, sum(kredit) as piutang1, sum(debit-kredit) as piutang2
            from tbljurnal
            inner join tblkontak on 
            tbljurnal.kontak = tblkontak.idpelanggan
            WHERE tblkontak.pelanggan ILIKE '%" & eCari.Text & "%'   
            and kodeakun ='" & akunPiutangUsaha & "'
            GROUP by tblkontak.idpelanggan"
        Else
            sql = "SELECT tblkontak.pelanggan,SUM(debit) as piutang, sum(kredit) as piutang1, sum(debit-kredit) as piutang2
            from tbljurnal
            inner join tblkontak on 
            tbljurnal.kontak = tblkontak.idpelanggan
            WHERE kodedepartemen = '" & cbSub.SelectedValue.ToString() & "' AND  tblkontak.pelanggan ILIKE '%" & eCari.Text & "%' 
            and kodeakun ='" & akunPiutangUsaha & "'
            GROUP by tblkontak.idpelanggan"
        End If

        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        ListSat.Columns(0).HeaderText = "Pelanggan"
        ListSat.Columns(1).HeaderText = "Jumlah Piutang"
        ListSat.Columns(2).HeaderText = "Jumlah Bayar"
        ListSat.Columns(3).HeaderText = "Saldo"
        styliseDG(ListSat)
        makeFillDG(ListSat)
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


    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewMutasiPiutang.dataview = dv
        PreviewMutasiPiutang.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub
End Class