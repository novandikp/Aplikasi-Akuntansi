Imports Microsoft.Reporting.WinForms

Public Class DialogJurnal
    Public koderefrensi As String = ""
    Private Sub DialogJurnal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initReport()
    End Sub


    Sub initReport()
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.Jurnal.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        Dim sql = " SELECT tbljurnal.kodeakun,akun, tgljurnal,deskripsijurnal as deskripsi ,tbljurnal.koderefrensi,departemen, COALESCE(projek,'N/A') as projek,debit,kredit FROM tbljurnal 
         inner join tblakun on tblakun.kodeakun = tbljurnal.kodeakun 
         inner join tbldepartemen on tbldepartemen.iddepartemen = tbljurnal.kodedepartemen 
         left join tblprojek on tblprojek.idprojek = tbljurnal.kodeprojek 
         where koderefrensi ='" & koderefrensi & "'"
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(Sql), DataTable)))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()
    End Sub

End Class