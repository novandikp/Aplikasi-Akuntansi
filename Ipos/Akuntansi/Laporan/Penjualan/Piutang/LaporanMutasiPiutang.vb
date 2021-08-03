Public Class LaporanMutasiPiutang


    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        If cbSub.SelectedIndex = 0 Then
            sql = "SELECT tblkontak.pelanggan,COALESCE(
(SELECT SUM(debit-kredit) from tbljurnal  T where T.kontak = tblkontak.idpelanggan and tgljurnal < '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' GROUP BY kontak),0) as saldoawal
, SUM(debit) as debit, sum(kredit) as kredit
from tbljurnal
inner join tblkontak on 
tbljurnal.kontak = tblkontak.idpelanggan
WHERE tblkontak.pelanggan ILIKE '%" & eCari.Text & "%' AND tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'  
GROUP by tblkontak.idpelanggan"
        Else
            sql = "SELECT tblkontak.pelanggan,COALESCE(
(SELECT SUM(debit-kredit) from tbljurnal  T where T.kontak = tblkontak.idpelanggan and tgljurnal < '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' GROUP BY kontak),0) as saldoawal
, SUM(debit) as debit, sum(kredit) as kredit
from tbljurnal
inner join tblkontak on 
tbljurnal.kontak = tblkontak.idpelanggan
WHERE kodedepartemen = '" & cbSub.SelectedValue.ToString() & "' AND  tblkontak.pelanggan ILIKE '%" & eCari.Text & "%' AND
tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'
GROUP by tblkontak.idpelanggan"
        End If

        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        styliseDG(ListSat)
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
        PreviewPesananJual.dataview = dv
        PreviewPesananJual.ringkasan = Me.ringkasan
        PreviewPesananJual.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub
End Class