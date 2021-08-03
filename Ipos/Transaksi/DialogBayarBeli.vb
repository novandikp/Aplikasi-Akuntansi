Imports Microsoft.Reporting.WinForms

Public Class DialogBayarBeli
    Public datagridview As DataGridView

    Public user As String
    Public total As Double
    Public tanggal As String
    Public fakturbeli As String
    Public hutang As Boolean
    Public saved As Boolean
    Public idorder As String
    Public cetak As String = ""


    Private Sub Label1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbBayar.Text = "10000"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbBayar.Text = "20000"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tbBayar.Text = "50000"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbBayar.Text = "100000"
    End Sub


    Sub awal()

        tbAwal.Text = numberFormat(total.ToString)

        cetak = ""
        Button6.Enabled = True

        Panel1.Enabled = True

        tbBayar.Text = 0

        tbBayar.Focus()
        Me.ActiveControl = tbBayar
    End Sub


    Private Sub DialogBayarBeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub


    Dim check As Boolean = True

    Private Sub tbBayar_TextChanged(sender As Object, e As EventArgs) Handles tbBayar.TextChanged
        If check Then
            check = False
            tbBayar.Text = numberFormat(unnumberFormat(tbBayar.Text))
            tbBayar.SelectionStart = tbBayar.Text.Count
            tbBayar.SelectionLength = 0
            check = True
        End If

        Dim bayar As Double = 0
        If Double.TryParse(unnumberFormat(tbBayar.Text), 0) Then
            bayar = toDouble(unnumberFormat(tbBayar.Text))
        End If

        Dim diskon As Double = 0


        tbKembali.Text = numberFormat((bayar - (total*(100 - diskon)/100)).ToString)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Public faktur, tgl, supplier As String

    Sub simpanBayarHutang(total As Double, bayar As Double)


        Dim hutang As Boolean = False

        hutang = True

        Dim kembali As Double = 0


        kembali = bayar - total
        Dim isidata As String() = New String() {faktur, tgl, total.ToString, bayar.ToString, kembali.ToString, supplier}
        Dim sql As String =
                "INSERT INTO tblbeli (fakturbeli, tglbeli, totalbeli, bayarbeli, kembalibeli, idsupplier) VALUES (?,?,?,?,?,?)"


        If exc(operationQueryString(sql, isidata)) Then
            Dim piutang = kembali*- 1
            If hutang Then

                exc("update tblsupplier set piutang = piutang + " & piutang & " where idsupplier=" & supplier)
                hutang = False
            End If
            If String.IsNullOrWhiteSpace(Keterangan.Text.ToString) Then
                Keterangan.Text = "-"
            End If
            Dim idbeli As String = getValue("SELECT idbeli from tblbeli order by idbeli desc", "idbeli")
            exc(
                "INSERT INTO tblpituangtemporal (jatuhtempo,jumlahbayar,sisasaldp, idbeli,keterangan) values ('" &
                DateTimePicker1.Value.ToString("yyyy-MM-dd") & "','" & bayar.ToString & "','" & piutang.ToString &
                "', '" & idbeli & "','" & Keterangan.Text & "')")
            If bayar > 0 Then
                Dim idhutang As String =
                        getValue("SELECT idpiutangtemp from tblpituangtemporal order by idpiutangtemp desc limit 1",
                                 "idpiutangtemp")
                exc(
                    "INSERT INTO tblpiutang (idpiutangtemp, bayarpiutang, tglpiutang,ketpiutang, saldo) VALUES ('" &
                    idhutang & "','" & bayar.ToString & "','" & tgl & "','" & Keterangan.Text & "', '" &
                    piutang.ToString & "')")
            End If
            isidetail(idbeli)
        End If
    End Sub

    Sub isidetail(idbeli As String)
        For Each row As DataGridViewRow In datagridview.Rows
            If Not IsNothing(row.Cells(1).Value) Then
                Dim sql = "Select konversi1, konversi2, stok1, stok2, stok3 from tblproduk where idproduk='" &
                          row.Cells(1).Value.ToString & "'"
                If getCount(sql) > 0 Then
                    Dim idbarang = row.Cells(1).Value.ToString
                    Dim hargabeli As String = row.Cells(5).Value.ToString
                    Dim jumlah = row.Cells(3).Value.ToString
                    Dim subquery = "select satuan,tipedata from view_harga where barcode=" & row.Cells(7).Value.ToString
                    Dim satuan = getValue(subquery, "satuan")
                    Dim nilai As Double = 0
                    exc("update tblharga set hargabeli=" & hargabeli & " where barcode=" & row.Cells(7).Value.ToString)
                    Dim konversi1 As Double = Double.Parse(getValue(sql, "konversi1"))
                    Dim konversi2 As Double = konversi1*Double.Parse(getValue(sql, "konversi2"))
                    Dim tipedata = getValue(subquery, "tipedata")
                    If tipedata = "1" Then
                        nilai = Double.Parse(jumlah)

                    ElseIf tipedata = "2" Then
                        nilai = Double.Parse(jumlah)*konversi1
                    Else
                        nilai = Double.Parse(jumlah)*konversi2
                    End If
                    Dim expired As String = row.Cells(8).Value.ToString()
                    Dim batch = row.Cells(9).Value.ToString
                    Dim querydetail =
                            "INSERT INTO tbldetailbeli (idbeli, barcode, hargabeli, jumlahbeli, satuanbeli, nilaibeli, expired, kodeproduksi) values (?,?,?,?,?,?,?,?)"
                    Dim datadetail As String() = New String() _
                            {idbeli, idbarang, hargabeli, jumlah.ToString.Replace(",", "."), satuan,
                             nilai.ToString.Replace(",", "."), expired, batch}
                    '' Dim querydetail = "INSERT INTO tbldetailbeli (idbeli, barcode, hargabeli, jumlahbeli, satuanbeli, nilaibeli) values (?,?,?,?,?,?)"
                    '' Dim datadetail As String() = New String() {idbeli, idbarang, hargabeli, jumlah.ToString.Replace(",", "."), satuan, nilai.ToString.Replace(",", ".")}
                    Debug.Write(operationQueryString(querydetail, datadetail))
                    If operationQuery(querydetail, datadetail) Then
                        'kartu stok
                        Dim datastok As String() = New String() _
                                {idbarang, jumlah.Replace(",", "."), satuan, nilai.ToString.Replace(",", "."), tgl,
                                 "PEMBELIAN", idbeli}
                        Dim querystok =
                                "INSERT INTO tblstok (idproduk, tambahan, satuanstok, nilaidasar, tglstok, keterangan,idbeli) values (?,?,?,?,?,?,?)"
                        operationQuery(querystok, datastok)
                        'Pembagian Stok
                        Dim stok1 As Double = Double.Parse(getValue(sql, "stok1")),
                            stok2 As Double = Double.Parse(getValue(sql, "stok2")),
                            stok3 As Double = Double.Parse(getValue(sql, "stok3"))


                        If nilai Mod 1 = 0 Then
                            If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                stok3 += nilai\konversi2
                                nilai = nilai Mod konversi2
                            End If
                            If konversi1 <= nilai And konversi1 > 1 Then
                                stok2 += nilai\konversi1

                                nilai = nilai Mod konversi1
                            End If
                        Else
                            If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                stok3 += Math.Floor(nilai/konversi2)
                                nilai -= Math.Floor(nilai/konversi2)*konversi2
                            End If
                            If konversi1 <= nilai And konversi1 > 1 Then
                                stok2 += Math.Floor(nilai/konversi1)

                                nilai -= Math.Floor(nilai/konversi1)*konversi1
                            End If
                        End If
                        stok1 += nilai
                        Dim databarang As String() = New String() _
                                {stok1.ToString.Replace(",", "."), stok2.ToString.Replace(",", "."),
                                 stok3.ToString.Replace(",", "."), idbarang}
                        Dim barangsql = "UPDATE tblproduk set stok1=?, stok2=?, stok3=? where idproduk=?"
                        operationQuery(barangsql, databarang)
                    End If

                End If
            End If
        Next
    End Sub

    Sub simpanBayar()
    End Sub

    Sub simpanBayarJalan()
    End Sub

    Private Sub Button5_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles tbKembali.KeyDown, tbBayar.KeyDown, Button6.KeyDown, Button4.KeyDown, Button3.KeyDown, Button2.KeyDown,
                Button1.KeyDown
        If e.KeyCode = Keys.F11 Then
            If String.IsNullOrWhiteSpace(cetak) Then
                simpanBayar()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            If Not String.IsNullOrWhiteSpace(cetak) Then
                SuratJalan.idjual = cetak
                SuratJalan.Show()
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.P Then
            If Not String.IsNullOrWhiteSpace(cetak) Then
                cetakStruk()
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub

    Sub isiBank()
    End Sub

    Sub isiEmoney()
    End Sub

    Private Sub cbMetode_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub


    Dim m_bPrint = False

    Private Sub ctlReportViewerTill_RenderingComplete(sender As Object, e As RenderingCompleteEventArgs) _
        Handles Struk5.RenderingComplete
        If m_bPrint = True Then
            m_bPrint = False
            Struk5.PrintDialog()

        Else
            Trace.WriteLine("ReportViewer RendingComplete Error")
        End If
    End Sub


    Private Sub ctlReportViewerTilal_RenderingComplete(sender As Object, e As RenderingCompleteEventArgs) _
        Handles Struk7.RenderingComplete
        If m_bPrint = True Then
            m_bPrint = False
            Struk7.PrintDialog()

        Else
            Trace.WriteLine("ReportViewer RendingComplete Error")
        End If
    End Sub

    Private Sub ctlReportViewerTilsal_RenderingComplete(sender As Object, e As RenderingCompleteEventArgs) _
        Handles StrukA.RenderingComplete
        If m_bPrint = True Then
            m_bPrint = False
            StrukA.PrintDialog()

        Else
            Trace.WriteLine("ReportViewer RendingComplete Error")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        simpanBayarJalan()
    End Sub

    Private Sub tbBayar_LostFocus(sender As Object, e As EventArgs) Handles tbBayar.LostFocus
        tbBayar.Text = numberFormat(tbBayar.Text.ToString)
    End Sub


    Sub cetakStruk()

        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        Dim struk = getValue(sqlidentitas, "printstruk")
        If struk = "58 mm" Then
            PreviewStruk.idjual = cetak
            PreviewStruk.ShowDialog()
            PreviewStruk.Dispose()
        ElseIf struk = "70 mm" Then
            PreviewStruk70.idjual = cetak
            PreviewStruk70.ShowDialog()
            PreviewStruk70.Dispose()
        Else
            PreviewStrukA5.idjual = cetak
            PreviewStrukA5.ShowDialog()
            PreviewStruk70.Dispose()
        End If
    End Sub

    Private Sub tbKembali_TextChanged(sender As Object, e As EventArgs) Handles tbKembali.TextChanged
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If total < toDouble(unnumberFormat(tbBayar.Text)) Then
            dialogError("Pembayaran Kelebihan")
            Return
        End If
        simpanBayarHutang(total, toDouble(unnumberFormat(tbBayar.Text)))
        dialogInfo("Berhasil")
        Form1.refreshProduk()
        FormPembelian.restartControl()
        '' FormPembelian.simpanBayarHutang(total, Modul.toDouble(unnumberFormat(tbBayar.Text)))

        Me.Close()
    End Sub
End Class