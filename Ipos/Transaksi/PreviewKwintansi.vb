Imports Microsoft.Reporting.WinForms

Public Class PreviewKwintansi
    Public idjual = ""

    Private Sub PreviewStruk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReportViewer1.Reset()
        Dim sql As String =
                 "SELECT fakturjual as idpelanggan,  pelanggan, tglhutang,  to_char(tglhutang,'YYYYmmDD') || LEFT(CAST(idhutang as TEXT),4)  as nopelanggan, jumlahbayar+sisasaldp as hutang, bayarhutang   as  alamatpelanggan from view_hutang  where idhutang = " & idjual
        Dim table As DataTable = getData(sql)
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.Kwintansi.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, bendahara, logo, kota from tblidentitas where idtoko=1"

        Dim t As New Terbilang()
        t.Text = getValue(sql, "alamatpelanggan")

        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(sql), DataTable)))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

        ReportViewer1.LocalReport.SetParameters(New ReportParameter("namaToko",
                                                                    getValue(sqlidentitas, "namatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("terbilang", t.Text))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("alamatToko",
                                                                    getValue(sqlidentitas, "alamatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("nomorToko",
                                                                    getValue(sqlidentitas, "notoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("kota", getValue(sqlidentitas, "kota").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("username", Form1.username))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("caption1",
                                                                    getValue(sqlidentitas, "caption1").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("caption2",
                                                                    getValue(sqlidentitas, "caption2").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("caption3",
                                                                    getValue(sqlidentitas, "caption3").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("bendahara",
                                                                    getValue(sqlidentitas, "bendahara").ToString))

        ReportViewer1.RefreshReport()
    End Sub
End Class