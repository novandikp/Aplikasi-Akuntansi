Public Class LaporanUmurPiutang

    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()
        styliseDG(ListSat)
        Dim sql As String = "SELECT tgljurnal,

koderefrensi,
sum(tbljurnal.debit-tbljurnal.kredit) +COALESCE(T.bayar,0) AS piutang,
0 as piutang1 ,
0 as piutang2,
0 as piutang3,
0,
tblkontak.pelanggan from tblhistoripiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoripiutang.idjurnal 
inner join tblkontak on tblkontak.idpelanggan = tbljurnal.kontak
left join
(SELECT sum(tbljurnal.debit-tbljurnal.kredit) as bayar,kodejual from tblhistoribayarpiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoribayarpiutang.idjurnal group by tblhistoribayarpiutang.kodejual) T  on T.kodejual = tbljurnal.koderefrensi
 where  koderefrensi ilike '%" & eCari.Text & "%' group by koderefrensi, T.bayar,tgljurnal,tblkontak.pelanggan;"
        Debug.WriteLine(sql)
        Dim datalaporan As DataTable = getData(sql)
        For Each row As DataRow In datalaporan.Rows
            Dim hariData As Date = CDate(row.Item(0))
            Dim nilai As Double = toDouble(row.Item(2))
            Dim hariini As Date = dtAwal.Value
            Dim harike30 As Date = hariini.AddDays(-30)
            Dim harike60 As Date = hariini.AddDays(-60)
            Dim harike90 As Date = hariini.AddDays(-90)
            row.Item(6) = nilai
            If hariData <= hariini And hariData >= harike30 Then
                row.Item(2) = nilai
                row.Item(4) = 0
                row.Item(5) = 0
                row.Item(3) = 0
            ElseIf hariData < harike30 And hariData >= harike60 Then
                row.Item(3) = nilai
                row.Item(2) = 0
                row.Item(4) = 0
                row.Item(5) = 0
            ElseIf hariData < harike60 And hariData >= harike90 Then
                row.Item(4) = nilai
                row.Item(2) = 0
                row.Item(3) = 0
                row.Item(5) = 0
            Else
                row.Item(4) = 0
                row.Item(3) = 0
                row.Item(2) = 0
                row.Item(5) = nilai
            End If
        Next
        dv = datalaporan.AsDataView

        ListSat.DataSource = datalaporan
        makeFillDG(ListSat)


        ListSat.Columns(0).HeaderText = "Tanggal"
        ListSat.Columns(1).HeaderText = "Kode Refrensi"
        ListSat.Columns(2).HeaderText = "< 30 Hari"
        ListSat.Columns(3).HeaderText = "30-60 Hari"
        ListSat.Columns(4).HeaderText = "60-90 Hari"
        ListSat.Columns(5).HeaderText = "> 90 Hari"
        ListSat.Columns(7).HeaderText = "Pelanggan"

        ListSat.Columns(6).Visible = False
        ListSat.Columns(5).DefaultCellStyle.Format = "c0"
        ListSat.Columns(4).DefaultCellStyle.Format = "c0"
        ListSat.Columns(2).DefaultCellStyle.Format = "c0"
        ListSat.Columns(3).DefaultCellStyle.Format = "c0"
        ListSat.Columns(7).DisplayIndex = 2


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

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        getDataLaporan()
    End Sub


    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewUmurPiutang.dataview = dv

        PreviewUmurPiutang.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub
End Class