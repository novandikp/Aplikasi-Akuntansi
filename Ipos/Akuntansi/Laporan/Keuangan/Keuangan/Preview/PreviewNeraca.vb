Imports Microsoft.Reporting.WinForms
Public Class PreviewNeraca
    Public sql As String = ""
    Public dataview As DataView
    Public saldoawal As Double = 0

    Private Sub PreviewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyBase.WindowState = FormWindowState.Maximized
        laporanBarangLengkap()
    End Sub


    Sub laporanBarangLengkap()
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.Neraca.rdlc"
        '  ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(dataview, DataView)))
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

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs)
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        laporanBarangLengkap()
    End Sub

    Private Sub ReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles ReportViewer1.KeyDown, Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            laporanBarangLengkap()

        End If
    End Sub
End Class