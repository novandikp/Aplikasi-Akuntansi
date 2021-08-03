Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.IO
Imports BarcodeLib
Imports Microsoft.Reporting.WinForms

Public Class CetakBarcode
    Private Sub CetakBarcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.ReportViewer1.RefreshReport()
    End Sub

    Public _
        sqlrak As String =
            "select *,(select count(idproduk) from tblharga where tblharga.idproduk = t.idproduk) as duplikasi from view_harga as t where cabang =" &
            Form1.idcabang & " order by rak, idproduk"

    Sub awal()
        Dim datatable As New DataTable
        datatable.Columns.Add("idproduk")
        datatable.Columns.Add("produk")
        datatable.Columns.Add("rak")

        datatable.Columns.Add("hargabeli")
        datatable.Columns.Add("hargajual")
        datatable.Columns.Add("image")
        datatable.Columns.Add("row")


        Dim origin As DataTable = getData(sqlrak)
        Using ms As MemoryStream = New MemoryStream
            Dim bar As Double = 1
            Dim no As Double = 0
            Dim urutan As Double = 1
            For Each row As DataRow In origin.Rows

                Dim dr As DataRow = datatable.NewRow
                dr("idproduk") = row.Item("idproduk")
                dr("produk") = row.Item("produk")
                dr("rak") = row.Item("rak")
                dr(3) = row.Item("satuan")

                dr(4) = row.Item("hargajual").ToString()
                dr(5) = ""
                If bar = 1 Then
                    no = no + 1


                ElseIf Not origin(bar - 2).Item("idproduk") = row.Item("idproduk") Then

                    If origin(bar - 2).Item("duplikasi") = "1" Then
                        Dim dr2 As DataRow = datatable.NewRow
                        dr2("idproduk") = origin(bar - 2).Item("idproduk")
                        dr2("produk") = ""
                        dr2("rak") = origin(bar - 2).Item("rak")
                        dr2(3) = ""
                        dr2(4) = ""
                        dr2(5) = ms.ToArray
                        dr2(6) = no
                        datatable.Rows.Add(dr2)

                        Dim dr3 As DataRow = datatable.NewRow
                        dr3("idproduk") = origin(bar - 2).Item("idproduk")
                        dr3("produk") = ""
                        dr3("rak") = origin(bar - 2).Item("rak")
                        dr3(3) = ""
                        dr3(4) = ""
                        dr3(5) = ms.ToArray
                        dr3(6) = no
                        datatable.Rows.Add(dr3)
                    ElseIf origin(bar - 2).Item("duplikasi") = "2" Then
                        Dim dr2 As DataRow = datatable.NewRow
                        dr2("idproduk") = origin(bar - 2).Item("idproduk")
                        dr2("produk") = ""
                        dr2("rak") = origin(bar - 2).Item("rak")
                        dr2(3) = ""
                        dr2(4) = ""
                        dr2(5) = ms.ToArray
                        dr2(6) = no
                        datatable.Rows.Add(dr2)
                    End If


                    no = no + 1
                Else

                End If


                dr(6) = no

                bar = bar + 1
                datatable.Rows.Add(dr)
            Next

            If origin(origin.Rows.Count() - 1).Item("duplikasi") = "1" Then
                Dim dr2 As DataRow = datatable.NewRow
                dr2("idproduk") = origin(origin.Rows.Count() - 1).Item("idproduk")
                dr2("produk") = ""
                dr2("rak") = origin(origin.Rows.Count() - 1).Item("rak")
                dr2(3) = ""
                dr2(4) = ""
                dr2(5) = ms.ToArray
                dr2(6) = no
                datatable.Rows.Add(dr2)

                Dim dr3 As DataRow = datatable.NewRow
                dr3("idproduk") = origin(origin.Rows.Count() - 1).Item("idproduk")
                dr3("produk") = ""
                dr3("rak") = origin(origin.Rows.Count() - 1).Item("rak")
                dr3(3) = ""
                dr3(4) = ""
                dr3(5) = ms.ToArray
                dr3(6) = no
                datatable.Rows.Add(dr3)
            ElseIf origin(origin.Rows.Count() - 1).Item("duplikasi") = "2" Then
                Dim dr2 As DataRow = datatable.NewRow
                dr2("idproduk") = origin(origin.Rows.Count() - 1).Item("idproduk")
                dr2("produk") = ""
                dr2("rak") = origin(origin.Rows.Count() - 1).Item("rak")
                dr2(3) = ""
                dr2(4) = ""
                dr2(5) = ms.ToArray
                dr2(6) = no
                datatable.Rows.Add(dr2)
            End If

        End Using

        ' PictureBox1.Image = datatable.Rows(0).Item(5)
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.RakAplikasi.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()

        'Sql = "SELECT idproduk, produk, merk, kategori,  stok1, stok2, stok3 from view_produk as T1"
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(datatable, DataTable)))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("namaToko", getValue(sqlidentitas, "namatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("alamatToko", getValue(sqlidentitas, "alamatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("nomerToko", getValue(sqlidentitas, "notoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("username", Form1.username))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()
    End Sub


    Public _
        sqlbarcode As String =
            "select barcode, idproduk, hargajual, hargabeli, idsatuan, tipedata, konversi, produk, idkategori, idmerk, ppnproduk, rak, gambar, statusbarang, stokis, stok1, stok2, stok3, konversi1, konversi2, cabang, kategori, merk, satuan from view_harga WHERE cabang=" &
            Form1.idcabang

    Sub struk()
        Dim datatable As New DataTable
        datatable.Columns.Add("idproduk")
        datatable.Columns.Add("produk")
        datatable.Columns.Add("rak")

        datatable.Columns.Add("hargabeli")
        datatable.Columns.Add("hargajual", GetType(Double))
        datatable.Columns.Add("image", GetType(Byte()))
        datatable.Columns.Add("row")


        Dim origin As DataTable = getData(sqlbarcode)

        Dim bar As Double = 1
        For Each row As DataRow In origin.Rows
            Using ms As MemoryStream = New MemoryStream
                Dim barcode As BarcodeLib.Barcode = New BarcodeLib.Barcode()
                barcode.Encode(TYPE.CODE39Extended, row.Item("idproduk"))
                Dim width = Math.Max(5, barcode.EncodedValue.Length)

                Dim img As Image = barcode.Encode(TYPE.CODE39Extended, row.Item("idproduk"), Color.Black, Color.White,
                                                  width, 30)
                img.Save(ms, ImageFormat.Png)

                For jumlah As Integer = 1 To CInt(row.Item("stok"))
                    Dim dr As DataRow = datatable.NewRow
                    dr("idproduk") = row.Item("idproduk")
                    dr("produk") = row.Item("produk")
                    dr("rak") = row.Item("rak")
                    dr(3) = row.Item("satuan")
                    dr(4) = row.Item("hargajual")
                    dr(5) = ms.ToArray
                    dr(6) = bar
                    bar = bar + 1
                    datatable.Rows.Add(dr)
                Next
            End Using
        Next


        ' PictureBox1.Image = datatable.Rows(0).Item(5)
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.BarcodeAplikasiA4.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        'Sql = "SELECT idproduk, produk, merk, kategori,  stok1, stok2, stok3 from view_produk as T1"
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(datatable, DataTable)))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("namaToko", getValue(sqlidentitas, "namatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("alamatToko", getValue(sqlidentitas, "alamatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("nomerToko", getValue(sqlidentitas, "notoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("username", Form1.username))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        '        ReportViewer1.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Custom", 12, 2.35 * (bar - 1) \ 3)
        ReportViewer1.RefreshReport()
    End Sub


    Public dgvdata As DataGridView

    Sub bcdbaru()
        Dim datatable As New DataTable
        datatable.Columns.Add("idproduk")
        datatable.Columns.Add("produk")
        datatable.Columns.Add("rak")

        datatable.Columns.Add("hargabeli")
        datatable.Columns.Add("hargajual", GetType(Double))
        datatable.Columns.Add("image", GetType(Byte()))
        datatable.Columns.Add("row")


        Dim origin As DataGridView = dgvdata

        Dim bar As Double = 1
        For Each row As DataGridViewRow In origin.Rows

            Using ms As MemoryStream = New MemoryStream
                Dim barcode As BarcodeLib.Barcode = New BarcodeLib.Barcode()
                barcode.Encode(TYPE.CODE39Extended, row.Cells("idproduk").Value)
                Dim width = Math.Max(100, barcode.EncodedValue.Length)
                Dim img As Image = barcode.Encode(TYPE.CODE39Extended, row.Cells("idproduk").Value, Color.Black, Color.White,
                                                  width, 30)
                img.Save(MS, ImageFormat.Png)

                For jumlah As Integer = 1 To CInt(row.Cells("stok").Value)
                    Dim dr As DataRow = datatable.NewRow
                    dr("idproduk") = row.Cells("idproduk").Value
                    dr("produk") = row.Cells("produk").Value
                    dr("rak") = row.Cells("rak").Value
                    dr(3) = row.Cells("satuan").Value
                    dr(4) = row.Cells("hargajual").Value
                    dr(5) = MS.ToArray
                    dr(6) = bar
                    bar = bar + 1
                    datatable.Rows.Add(dr)
                Next
            End Using
        Next

        ' PictureBox1.Image = datatable.Rows(0).Item(5)
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.BarcodeAplikasi.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        'Sql = "SELECT idproduk, produk, merk, kategori,  stok1, stok2, stok3 from view_produk as T1"
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(datatable, DataTable)))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("namaToko", getValue(sqlidentitas, "namatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("alamatToko", getValue(sqlidentitas, "alamatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("nomerToko", getValue(sqlidentitas, "notoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("username", Form1.username))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()
    End Sub
    Sub bcdA4()
        Dim datatable As New DataTable
        datatable.Columns.Add("idproduk")
        datatable.Columns.Add("produk")
        datatable.Columns.Add("rak")

        datatable.Columns.Add("hargabeli")
        datatable.Columns.Add("hargajual", GetType(Double))
        datatable.Columns.Add("image", GetType(Byte()))
        datatable.Columns.Add("row")


        Dim origin As DataGridView = dgvdata

        Dim bar As Double = 1
        For Each row As DataGridViewRow In origin.Rows

            Using ms As MemoryStream = New MemoryStream
                Dim barcode As BarcodeLib.Barcode = New BarcodeLib.Barcode()
                barcode.Encode(TYPE.CODE39Extended, row.Cells("idproduk").Value)
                Dim width = Math.Max(100, barcode.EncodedValue.Length)
                Dim img As Image = barcode.Encode(TYPE.CODE39Extended, row.Cells("idproduk").Value, Color.Black, Color.White,
                                                  width, 30)
                img.Save(ms, ImageFormat.Png)

                For jumlah As Integer = 1 To CInt(row.Cells("stok").Value)
                    Dim dr As DataRow = datatable.NewRow
                    dr("idproduk") = row.Cells("idproduk").Value
                    dr("produk") = row.Cells("produk").Value
                    dr("rak") = row.Cells("rak").Value
                    dr(3) = row.Cells("satuan").Value
                    dr(4) = row.Cells("hargajual").Value
                    dr(5) = ms.ToArray
                    dr(6) = bar
                    bar = bar + 1
                    datatable.Rows.Add(dr)
                Next
            End Using
        Next

        ' PictureBox1.Image = datatable.Rows(0).Item(5)
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.BarcodeAplikasiA4.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        'Sql = "SELECT idproduk, produk, merk, kategori,  stok1, stok2, stok3 from view_produk as T1"
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(datatable, DataTable)))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("namaToko", getValue(sqlidentitas, "namatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("alamatToko", getValue(sqlidentitas, "alamatoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("nomerToko", getValue(sqlidentitas, "notoko").ToString))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("username", Form1.username))
        'ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()
    End Sub
End Class