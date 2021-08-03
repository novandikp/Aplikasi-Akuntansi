Imports Microsoft.Reporting.WinForms

Public Class PreviewStrukA5
    Public idjual = ""

    Private Sub PreviewStruk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReportViewer1.Reset()
        Dim sql As String = "SELECT * from view_detailjual where idjual = " & idjual
        Dim table As DataTable = getData(sql)
        If table.Rows.Count > 0 Then
            If table.Rows(0).Item("metode") = "Hutang" Then
                ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.Invoice.rdlc"
            Else
                ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.StrukA5.rdlc"
            End If
        Else
            Me.Close()
        End If

        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota, bank, rekening, anbank from tblidentitas where idtoko=1"


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
        If table.Rows.Count > 0 Then
            If table.Rows(0).Item("metode") = "Hutang" Then
                Dim sqlhutang As String =
                        "SELECT jatuhtempo as jatuhtempo from tblhutangtemporal where idjual = " &
                        idjual
                ReportViewer1.LocalReport.SetParameters(New ReportParameter("jatuhtempo",
                                                                            getValue(sqlhutang, "jatuhtempo").ToString))
                ReportViewer1.LocalReport.SetParameters(New ReportParameter("bank",
                                                                            getValue(sqlidentitas, "bank").ToString))
                ReportViewer1.LocalReport.SetParameters(New ReportParameter("rekening",
                                                                            getValue(sqlidentitas, "rekening").ToString))
                ReportViewer1.LocalReport.SetParameters(New ReportParameter("anbank",
                                                                            getValue(sqlidentitas, "anbank").ToString))
            End If

        End If
        ReportViewer1.RefreshReport()
    End Sub
End Class