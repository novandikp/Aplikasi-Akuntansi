Public Class LaporanPembayaranPiutangUsaha



    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()
        sql = "SELECT tglbayarpiutang as tanggal,
kodebayarpiutang as kode,
tblbayarpiutang.kodejual as koderefrensi, 
tblakun.akun,
tblkontak.pelanggan as kontak, 
tblbayarpiutang.bayarpiutang as nominal,  
tblbayarpiutang.biayalain from tblbayarpiutang
inner join tbljual on tbljual.kodejual = tblbayarpiutang.kodejual
INNER join tblkontak on tbljual.pelanggan = tblkontak.idpelanggan
inner join tblakun on tblakun.kodeakun = tblbayarpiutang.akun
WHERE tblkontak.pelanggan ilike '%" & eCari.Text & "%' AND tglbayarpiutang BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'"
        Debug.WriteLine(sql)
        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        styliseDG(ListSat)
        makeFillDG(ListSat)
        ListSat.Columns(0).HeaderText = "Tanggal"
        ListSat.Columns(1).HeaderText = "Kode Bayar"
        ListSat.Columns(2).HeaderText = "Kode Refrensi"
        ListSat.Columns(3).HeaderText = "Akun Penerimaan"
        ListSat.Columns(4).HeaderText = "Pelanggan"
        ListSat.Columns(5).HeaderText = "Pembayaran"
        ListSat.Columns(6).HeaderText = "Biaya Lain"
    End Sub

    Public saldoawal As String = "0"



    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        PreviewPembayaranPiutang.dataview = dv

        PreviewPembayaranPiutang.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub
End Class