Imports Microsoft.Reporting.WinForms

Public Class PreviewResep
    Public sql As String

    Private Sub PreviewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        setData()
        copyResep()
    End Sub

    Public dokter As String = ""
    Public pelanggan As String = ""
    Public umur As String = ""
    Public resep As String = ""
    Public idjual As String = ""
    Public tglbeli As String = ""
    Public tgldokter As String
    Public iter As String = ""
    Public data As DataTable


    Sub setData()


        If Not IsNothing(data) Then
            Dim clonedDT As DataTable = data.Clone()
            clonedDT.Columns(2).DataType = GetType(String)
            clonedDT.Columns(4).DataType = GetType(String)
            clonedDT.Columns(5).DataType = GetType(String)
            For Each row As DataRow In data.Rows

                clonedDT.ImportRow(row)
            Next
            For Each row As DataRow In clonedDT.Rows
                Dim iter = toInteger(row.Item(5))
                If iter = 0 Then
                    If row.Item(2) = row.Item(4) Then
                        row.Item(2) = "det orig"
                    Else
                        row.Item(2) = "det " & IntegerToRoman(toInteger(row.Item(2).ToString))
                    End If
                ElseIf iter = 1 Then
                    If row.Item(2) = row.Item(4) Then
                        row.Item(2) = "iter 1x"
                    Else
                        row.Item(2) = "det orig + " & IntegerToRoman(toInteger(row.Item(2).ToString))
                    End If
                Else
                    If row.Item(2) = row.Item(4) Then
                        row.Item(2) = "iter " & row.Item(5) & "x"
                    Else
                        row.Item(2) = "iter " & row.Item(5) & "x" & " + " &
                                      IntegerToRoman(toInteger(row.Item(2).ToString))
                    End If
                End If


                row.Item(4) = IntegerToRoman(toInteger(row.Item(4).ToString))
            Next
            data = clonedDT
        End If
    End Sub


    Sub copyResep()
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.LaporanCopyResep.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, apoteker, APA, SIA, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        sql = "SELECT * from view_detailjual where idjual = " & idjual
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(data, DataTable)))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("namatoko",
                                                                    getValue(sqlidentitas, "namatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("alamattoko",
                                                                    getValue(sqlidentitas, "alamatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("notoko", getValue(sqlidentitas, "notoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("apa", getValue(sqlidentitas, "apoteker").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("sia", getValue(sqlidentitas, "SIA").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("sipa", getValue(sqlidentitas, "APA").ToString))
        ' ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("username", Form1.username))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("resep", resep))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("pelanggan", pelanggan))

        ReportViewer1.LocalReport.SetParameters(New ReportParameter("umur", umur))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("dokter", dokter))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("tglbeli", tglbeli))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("tgldokter", tgldokter))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("iter", iter))

        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()
    End Sub

    Sub laporanBarangTanpaHarga()
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.LaporanAset.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        sql = "SELECT idproduk, produk, merk, kategori,  stok1, stok2, stok3 from view_produk as T1"
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(sql), DataTable)))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("namaToko",
                                                                    getValue(sqlidentitas, "namatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("alamatToko",
                                                                    getValue(sqlidentitas, "alamatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("nomerToko",
                                                                    getValue(sqlidentitas, "notoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("username", Form1.username))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()
    End Sub

    Sub laporanBarangLengkap()
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.LaporanAsetNew.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ' Dim sql As String = "SELECT idproduk, produk,  IIF(tipedata = 1,  view_harga.stok1 , IIF(tipedata = 2, view_harga.stok2, view_harga.stok3 )) as stok1, hargajual, hargabeli, satuan from view_harga  where produk like '%" & eCari.Text & "%'"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(sql), DataTable)))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("namaToko",
                                                                    getValue(sqlidentitas, "namatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("alamatToko",
                                                                    getValue(sqlidentitas, "alamatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("nomerToko",
                                                                    getValue(sqlidentitas, "notoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("username", Form1.username))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        laporanBarangLengkap()
    End Sub

    Private Sub ReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles ReportViewer1.KeyDown, eCari.KeyDown, Button4.KeyDown, Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            laporanBarangLengkap()

        End If
    End Sub
End Class