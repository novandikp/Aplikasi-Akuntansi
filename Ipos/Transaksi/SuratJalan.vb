Imports Microsoft.Reporting.WinForms

Public Class SuratJalan
    Public idjual = ""

    Private Sub PreviewStruk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.Suratjalan.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ReportViewer1.LocalReport.EnableExternalImages = True
        Dim sql As String = "SELECT * from view_detailjual where idjual = " & idjual
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(sql), DataTable)))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

        ReportViewer1.LocalReport.SetParameters(New ReportParameter("namaToko",
                                                                    getValue(sqlidentitas, "namatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("alamatToko",
                                                                    getValue(sqlidentitas, "alamatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("kota", getValue(sqlidentitas, "kota").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("nomorToko",
                                                                    getValue(sqlidentitas, "notoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("username", Form1.username))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))


        ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
    End Sub
End Class