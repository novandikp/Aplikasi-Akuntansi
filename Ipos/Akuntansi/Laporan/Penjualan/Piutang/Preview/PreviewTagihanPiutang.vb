Imports Microsoft.Reporting.WinForms
Public Class PreviewTagihanPiutang
    Private Sub PreviewTagihanPiutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillData()
    End Sub

    Sub fillData()
        Dim sql = "SELECT tgljurnal,
koderefrensi,
sum(tbljurnal.debit-tbljurnal.kredit) +COALESCE(T.bayar,0) AS piutang,
0 as piutang1,
tblkontak.pelanggan from tblhistoripiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoripiutang.idjurnal 
inner join tblkontak on tblkontak.idpelanggan = tbljurnal.kontak
left join
(SELECT sum(tbljurnal.debit-tbljurnal.kredit) as bayar,kodejual from tblhistoribayarpiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoribayarpiutang.idjurnal group by tblhistoribayarpiutang.kodejual) T  on T.kodejual = tbljurnal.koderefrensi
 where  koderefrensi ilike '%%' group by koderefrensi, T.bayar,tgljurnal,tblkontak.pelanggan;"

        Dim dt As DataTable = getData(sql)
        Dim dv As DataView = dt.AsDataView
        dv.RowFilter = "piutang > 0"
        ReportViewer1.Reset()

        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.TagihanPiutang.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        Dim awal = ""
        Dim akhir = ""

        ReportViewer1.LocalReport.EnableExternalImages = True
        'Dim sql As String = "SELECT fakturjual, produk, tgljual, satuanjual, laba as hargajual, jumlahjual from view_detailjual  where tgljual between ('" & awal & " 00:00:00') and ('" & akhir & " 23:59:59') and flag=1 and (pelanggan like '%" & eCari.Text & "%' or fakturjual like '%" & eCari.Text & "%')"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(dv, DataView)))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

        'ReportViewer1.LocalReport.SetParameters(New ReportParameter("namaToko",
        '                                                            getValue(sqlidentitas, "namatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New ReportParameter("alamatToko",
        '                                                            getValue(sqlidentitas, "alamatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New ReportParameter("nomerToko",
        '                                                            getValue(sqlidentitas, "notoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New ReportParameter("username", Form1.username))
        'ReportViewer1.LocalReport.SetParameters(New ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.RefreshReport()
    End Sub
End Class