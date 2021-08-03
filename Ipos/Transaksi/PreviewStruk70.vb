Imports Microsoft.Reporting.WinForms

Public Class PreviewStruk70
    Public idjual = ""

    Private Sub PreviewStruk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReportViewer1.Reset()

        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        Dim sql As String = "SELECT * from view_detailjual where idjual = " & idjual
        Dim table As DataTable = getData(sql)
        If table.Rows.Count > 0 Then
            If table.Rows(0).Item("metode") = "Hutang" Then
                ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.Struk70Hutang.rdlc"
            Else
                ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.Struk70.rdlc"
            End If
        Else
            Me.Close()
        End If


        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(sql), DataTable)))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

        ReportViewer1.LocalReport.SetParameters(New ReportParameter("namaToko",
                                                                    getValue(sqlidentitas, "namatoko").ToString))
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

        ReportViewer1.RefreshReport()
    End Sub
End Class