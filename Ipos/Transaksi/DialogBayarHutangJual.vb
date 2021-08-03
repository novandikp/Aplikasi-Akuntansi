Imports System.ComponentModel
Imports Microsoft.Reporting.WinForms

Public Class DialogBayarHutangJual
    Public datagridview As DataGridView
    Public supplier As String
    Public user As String
    Public total As Double
    Public tanggal As String
    Public fakturbeli As String
    Public hutang As Boolean
    Public saved As Boolean
    Public idorder As String
    Public cetak As String = ""
    Public dokter As String
    Public resep As String
    Public catatan As String = "-"
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles tbTotal.TextChanged
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
        tbTotal.Text = numberFormat(total.ToString)
        tbAwal.Text = numberFormat(total.ToString)
        tbTotal.ReadOnly = True
        cetak = ""
        Button6.Enabled = True
        Button5.Enabled = True
        Panel1.Enabled = True
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        tbBayar.Text = 0


        tbBayar.Focus()
        Me.ActiveControl = tbBayar
        TBDiskon.Text = getValue("select diskon from view_pelanggan where idpelanggan =" & supplier, "diskon")
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

        If diskonNominal.Checked Then
            Dim diskon As Double = 0
            If Double.TryParse(unnumberFormat(TBPotongan.Text), 0) Then
                diskon = toDouble(unnumberFormat(TBPotongan.Text))
            End If


            tbKembali.Text = numberFormat((bayar - (total - diskon).ToString))
        Else
            Dim diskon As Double = 0
            If Double.TryParse(TBDiskon.Text, 0) Then
                diskon = toDouble(TBDiskon.Text)
            End If


            tbKembali.Text = numberFormat((bayar - (total*(100 - diskon)/100)).ToString)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Sub isidetail(idbeli As String)
        For Each row As DataGridViewRow In datagridview.Rows
            If Not IsNothing(row.Cells(1).Value) Then
                Dim sql =
                        "select konversi1, konversi2,stok1, stok2, stok3, idkategori from tblproduk where idproduk='" &
                        row.Cells(1).Value.ToString & "'"
                If getCount(sql) > 0 Then
                    Dim idbarang = row.Cells(1).Value.ToString
                    Dim hargabeli = row.Cells(5).Value.ToString
                    Dim diskondet = row.Cells(6).Value.ToString
                    Dim jumlah = row.Cells(3).Value.ToString
                    Dim subquery = "select satuan,tipedata,hargabeli from view_harga where barcode=" &
                                   row.Cells(9).Value.ToString
                    Dim satuan = getValue(subquery, "satuan")
                    Dim nilai As Double = 0
                    Dim konversi1 As Double = toDouble(getValue(sql, "konversi1"))
                    Dim konversi2 As Double = konversi1*toDouble(getValue(sql, "konversi2"))
                    Dim tipedata = getValue(subquery, "tipedata")
                    Dim idkategori = getValue(sql, "idkategori")
                    If tipedata = "1" Then
                        nilai = toDouble(jumlah)

                    ElseIf tipedata = "2" Then
                        nilai = toDouble(jumlah)*konversi1
                    Else
                        nilai = toDouble(jumlah)*konversi2
                    End If
                    Dim laba = ((toDouble(hargabeli)*(100 - toDouble(diskondet))/100)) -
                               toDouble(getValue(subquery, "hargabeli"))
                    If idkategori = "1" Then
                        If dokter = "1" Then
                            laba = toDouble(hargabeli)
                        Else
                            laba = ((toDouble(hargabeli) * (100 - toDouble(diskondet)) / 100)) *
                                   (100 - toDouble(getValue(subquery, "hargabeli"))) / 100
                        End If

                    End If

                    Dim expired = row.Cells(10).Value.ToString
                    Dim batch = row.Cells(11).Value.ToString
                    Dim querydetail =
                            "INSERT INTO tbldetailjual (idjual, barcode, hargajual, jumlahjual, satuanjual, nilaijual, diskon, laba,expired,batch) values (?,?,?,?,?,?,?,?,?,?)"

                    Dim datadetail As String() = New String() _
                            {idbeli, idbarang, hargabeli, jumlah.Replace(",", "."), satuan,
                             nilai.ToString.Replace(",", "."), diskondet, laba.ToString, expired, batch}

                    If operationQuery(querydetail, datadetail) Then
                        'kartu stok
                        If idkategori = "1" Then
                            laba = ((toDouble(hargabeli)*(100 - toDouble(diskondet))/100))*
                                   (toDouble(getValue(subquery, "hargabeli")))/100
                            exc(
                                "UPDATE tbldokter set sid = sid + " & laba & " where iddokter ='" & dokter &
                                "' AND iddokter > 1")
                        Else
                            Dim datastok As String() = New String() _
                                    {idbarang, "-" & jumlah.Replace(",", "."), satuan, nilai.ToString.Replace(",", "."),
                                     tanggal, "PENJUALAN", idbeli}
                            Dim querystok =
                                    "INSERT INTO tblstok (idproduk, tambahan, satuanstok, nilaidasar, tglstok, keterangan,idjual) values (?,?,?,?,?,?,?)"
                            operationQuery(querystok, datastok)


                            'Pembagian Stok
                            Dim stok1 As Double = toDouble(getValue(sql, "stok1")),
                                stok2 As Double = toDouble(getValue(sql, "stok2")),
                                stok3 As Double = toDouble(getValue(sql, "stok3"))
                            nilai = (stok1 + (stok2*konversi1) + (stok3*konversi2)) - nilai
                            If nilai Mod 1 = 0 Then
                                If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                    stok3 = nilai\konversi2
                                    nilai = nilai Mod konversi2
                                Else
                                    stok3 = 0
                                End If


                                If konversi1 <= nilai And konversi1 > 1 Then
                                    stok2 = nilai\konversi1

                                    nilai = nilai Mod konversi1
                                Else
                                    stok2 = 0
                                End If
                            Else
                                If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                    stok3 = Math.Floor(nilai/konversi2)
                                    nilai -= Math.Floor(nilai/konversi2)*konversi2
                                Else
                                    stok3 = 0
                                End If


                                If konversi1 <= nilai And konversi1 > 1 Then
                                    stok2 = Math.Floor(nilai/konversi1)

                                    nilai -= Math.Floor(nilai/konversi1)*konversi1
                                Else
                                    stok2 = 0
                                End If
                            End If


                            stok1 = nilai


                            Dim databarang As String() = New String() _
                                    {stok1.ToString.Replace(",", "."), stok2.ToString.Replace(",", "."),
                                     stok3.ToString.Replace(",", "."), idbarang}
                            Dim barangsql = "UPDATE tblproduk set stok1=?, stok2=?, stok3=? where idproduk=?"
                            operationQuery(barangsql, databarang)
                        End If

                    End If

                End If
            End If
        Next
    End Sub


    Sub isidetail2(idbeli As String)
        For Each row As DataGridViewRow In datagridview.Rows
            If Not IsNothing(row.Cells(1).Value) Then
                Dim sql = "select konversi1, konversi2,stok1, stok2, stok3 from tblproduk where idproduk='" &
                          row.Cells(1).Value.ToString & "'"
                If getCount(sql) > 0 Then
                    Dim idbarang = row.Cells(1).Value.ToString
                    Dim hargabeli = row.Cells(5).Value.ToString
                    Dim diskondet = row.Cells(6).Value.ToString
                    Dim jumlah = row.Cells(3).Value.ToString
                    Dim subquery = "select satuan,tipedata,hargabeli from view_harga where barcode=" &
                                   row.Cells(9).Value.ToString
                    Dim satuan = getValue(subquery, "satuan")
                    Dim nilai As Double = 0
                    Dim konversi1 As Double = toDouble(getValue(sql, "konversi1"))
                    Dim konversi2 As Double = konversi1*toDouble(getValue(sql, "konversi2"))
                    Dim tipedata = getValue(subquery, "tipedata")
                    If tipedata = "1" Then
                        nilai = toDouble(jumlah)

                    ElseIf tipedata = "2" Then
                        nilai = toDouble(jumlah)*konversi1
                    Else
                        nilai = toDouble(jumlah)*konversi2
                    End If
                    Dim laba = ((toDouble(hargabeli)*(100 - toDouble(diskondet))/100)) -
                               toDouble(getValue(subquery, "hargabeli"))
                    Dim expired = "-"
                    Dim batch = "-"
                    Dim querydetail =
                            "INSERT INTO tbldetailjual (idjual, barcode, hargajual, jumlahjual, satuanjual, nilaijual, diskon,laba, expired,batch) values (?,?,?,?,?,?,?,?,?,?)"

                    Dim datadetail As String() = New String() _
                            {idbeli, idbarang, hargabeli, jumlah.Replace(",", "."), satuan,
                             nilai.ToString.Replace(",", "."), diskondet, laba.ToString, expired, batch}

                    If operationQuery(querydetail, datadetail) Then
                        'kartu stok
                        Dim datastok As String() = New String() _
                                {idbarang, "-" & jumlah.Replace(",", "."), satuan, nilai.ToString.Replace(",", "."),
                                 tanggal, "PENJUALAN", idbeli}
                        Dim querystok =
                                "INSERT INTO tblstok (idproduk, tambahan, satuanstok, nilaidasar, tglstok, keterangan,idjual) values (?,?,?,?,?,?,?)"
                        operationQuery(querystok, datastok)


                        'Pembagian Stok
                        Dim stok1 As Double = toDouble(getValue(sql, "stok1")),
                            stok2 As Double = toDouble(getValue(sql, "stok2")),
                            stok3 As Double = toDouble(getValue(sql, "stok3"))
                        nilai = (stok1 + (stok2*konversi1) + (stok3*konversi2)) - nilai
                        If nilai Mod 1 = 0 Then
                            If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                stok3 = nilai\konversi2
                                nilai = nilai Mod konversi2
                            Else
                                stok3 = 0
                            End If


                            If konversi1 <= nilai And konversi1 > 1 Then
                                stok2 = nilai\konversi1

                                nilai = nilai Mod konversi1
                            Else
                                stok2 = 0
                            End If
                        Else
                            If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                stok3 = Math.Floor(nilai/konversi2)
                                nilai -= Math.Floor(nilai/konversi2)*konversi2
                            Else
                                stok3 = 0
                            End If


                            If konversi1 <= nilai And konversi1 > 1 Then
                                stok2 = Math.Floor(nilai/konversi1)

                                nilai -= Math.Floor(nilai/konversi1)*konversi1
                            Else
                                stok2 = 0
                            End If
                        End If


                        stok1 = nilai


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

    Function updateTemp(idbarang As String) As Boolean
        Dim jumlah As Double = 0
        If IsNothing(idbarang) Then
            Return True
        End If
        Dim nilai As Double = 0
        If _
            Double.TryParse(
                getValue(
                    "SELECT stok1 + (stok2 * konversi1) + (stok3 * konversi1* konversi2) as totalstok from tblproduk where idproduk='" &
                    idbarang & "'", "totalstok"), 0) Then
            nilai =
                toDouble(
                    getValue(
                        "SELECT stok1 + (stok2 * konversi1) + (stok3 * konversi1* konversi2) as totalstok from tblproduk where idproduk='" &
                        idbarang & "'", "totalstok"))
        Else
            Return True
        End If
        For Each row As DataGridViewRow In datagridview.Rows
            If row.Cells(1).Value = idbarang Then
                Dim cekbarang = "SELECT * FROM view_harga where barcode=" & row.Cells(4).Value


                Dim jenis = getValue(cekbarang, "tipedata")


                If jenis = "2" Then
                    jumlah += row.Cells(3).Value*toDouble(getValue(cekbarang, "konversi1"))
                ElseIf jenis = "3" Then
                    jumlah += row.Cells(3).Value*toDouble(getValue(cekbarang, "konversi1"))*
                              toDouble(getValue(cekbarang, "konversi2"))
                Else
                    jumlah += row.Cells(3).Value
                End If
            End If
        Next

        nilai = nilai - jumlah
        If nilai < 0 Then
            Return False
        Else
            exc("update temp_stok set nilai='" & nilai & "' where idproduk='" & idbarang & "'")
            Return True
        End If
    End Function

    Sub simpanBayar()

        Dim idbarang As String = "("
        For Each row As DataGridViewRow In datagridview.Rows
            If _
                Not IsNothing(row.Cells(5).Value) And Not IsNothing(row.Cells(1).Value) And
                Not IsNothing(row.Cells(4).Value) Then
                idbarang &= CStr(row.Cells(4).Value) & ","


            End If
        Next
        idbarang = idbarang.Substring(0, idbarang.Length - 1) & ")"
        Dim sqlcek As String =
                "SELECT barcode, tipedata, stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2 as stok, konversi1, konversi2, produk from view_harga where barcode in " +
                idbarang

        Dim dt As DataTable = getData(sqlcek)
        Dim condition As Boolean = True
        idbarang = idbarang.Substring(0, idbarang.Length - 1) & ")"
        For Each rows As DataRow In dt.Rows
            For Each row As DataGridViewRow In datagridview.Rows
                If row.Cells(4).Value = rows.Item("barcode") Then
                    If rows.Item("tipedata") = 1 Then
                        rows.Item("stok") = toDouble(rows.Item("stok").ToString()) -
                                            toDouble(row.Cells(3).Value.ToString)
                    ElseIf rows.Item("tipedata") = 2 Then
                        rows.Item("stok") = toDouble(rows.Item("stok").ToString()) -
                                            toDouble(row.Cells(3).Value.ToString)*
                                            toDouble(rows.Item("konversi1").ToString())
                    Else
                        rows.Item("stok") = toDouble(rows.Item("stok").ToString()) -
                                            toDouble(row.Cells(3).Value.ToString)*
                                            toDouble(rows.Item("konversi1").ToString())*
                                            toDouble(rows.Item("konversi2").ToString())
                    End If
                    Exit For
                End If
            Next

            If toDouble(rows.Item("stok")) < 0 Then
                condition = False
                dialogError("Stok " & rows.Item("produk") & " tidak mencukupi")
                Exit For
            End If
        Next
        If Not condition Then
            Return
        End If
        Dim bayar As Double = 0
        If Double.TryParse(unnumberFormat(tbBayar.Text), 0) Then
            bayar = toDouble(unnumberFormat(tbBayar.Text))
        End If

        'Dim diskon As Double = 0
        'If Double.TryParse(TBDiskon.Text, 0) Then
        ' diskon = Modul.toDouble(TBDiskon.Text)
        'End If
        Dim diskon As Double = 0
        Dim kembali As Double = 0
        If diskonNominal.Checked Then
            If Double.TryParse(unnumberFormat(TBPotongan.Text), 0) Then
                diskon = toDouble(unnumberFormat(TBPotongan.Text))
            End If
            kembali = bayar - (total - diskon)
        Else

            If Double.TryParse(TBDiskon.Text, 0) Then
                diskon = toDouble(TBDiskon.Text)
            End If
            kembali = bayar - (total*(100 - diskon)/100)
        End If

        If Not limit("tbljual") Then
            Return
        End If

        If diskon > 99 And Not diskonNominal.Checked Then
            dialogError("Isi diskon dengan benar")
        ElseIf diskon >= total And diskonNominal.Checked Then
            dialogError("Isi potongan dengan benar")
        ElseIf String.IsNullOrWhiteSpace(tbBayar.Text) Then
            dialogError("Isi bayar terlebih dahulu")
        ElseIf hutang And kembali < 0 Then
            Dim metode = "Hutang"
            Dim akun = "-"
            Dim noakun = "-"
            If String.IsNullOrWhiteSpace(Keterangan.Text.ToString) Then
                Keterangan.Text = "-"

            End If
            akun = Keterangan.Text
            Dim isidata As String() = New String() _
                    {fakturbeli, tanggal, total.ToString, bayar.ToString, kembali.ToString, supplier, metode, akun,
                     noakun, unnumberFormat(TBPotongan.Text), user, dokter, resep, catatan}
            Dim sql As String =
                    "INSERT INTO tbljual (fakturjual, tgljual, total, bayar, kembali, idpelanggan, metode, kartu, nokartu, granddiskon, username,iddokter,resep,lokasi) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            If operationQuery(sql, isidata) Then
                If saved Then
                    exc("DELETE FROM tbldetailjual WHERE idjual = " & idorder)
                    exc("DELETE FROM tbljual WHERE idjual = " & idorder)
                End If
                Dim piutang = kembali*- 1
                If hutang Then

                    exc("update tblpelanggan set hutang = hutang + " & piutang & " where idpelanggan=" & supplier)
                End If


                Dim idbeli As String = getValue("SELECT idjual from tbljual order by idjual desc limit 1", "idjual")
                exc(
                    "INSERT INTO tblhutangtemporal (jatuhtempo,jumlahbayar,sisasaldp, idjual, keterangan) values ('" &
                    DateTimePicker1.Value.ToString("yyyy-MM-dd") & "','" & bayar.ToString & "','" & piutang.ToString &
                    "', '" & idbeli & "', '" & Keterangan.Text & "')")

                If bayar > 0 Then
                    Dim idhutang As String =
                            getValue("SELECT idhutangtemp from tblhutangtemporal order by idhutangtemp desc limit 1",
                                     "idhutangtemp")
                    exc(
                        "INSERT INTO tblhutang (idhutangtemp, bayarhutang, tglhutang,kethutang, saldo) VALUES ('" &
                        idhutang & "','" & bayar.ToString & "','" & tanggal & "','" & Keterangan.Text & "','" &
                        piutang.ToString & "')")
                End If
                isidetail(idbeli)
                dialogInfo("Berhasil")
                cetak = idbeli
                Button6.Enabled = False
                Button5.Enabled = False
                Panel1.Enabled = False
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True
                Me.ActiveControl = Button7
                Form1.refreshProduk()
                Form1.refreshHutang()

                If dialog("Apakah anda ingin mencetak struk ?") Then
                    '' Form1.openPenjualan(True)
                    FormPenawaranJual.restartControl()
                    StrukA.Reset()
                    StrukA.LocalReport.ReportEmbeddedResource = "Ipos.Invoice.rdlc"
                    Dim sqlidentitasa As String =
                            "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota, bank, rekening, anbank from tblidentitas where idtoko=1"

                    Dim sqla As String = "SELECT * from view_detailjual where idjual = " & idbeli
                    StrukA.LocalReport.DataSources.Clear()
                    StrukA.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(sqla), DataTable)))
                    StrukA.SetDisplayMode(DisplayMode.PrintLayout)

                    StrukA.LocalReport.SetParameters(New ReportParameter("namaToko",
                                                                         getValue(sqlidentitasa, "namatoko").ToString))
                    StrukA.LocalReport.SetParameters(New ReportParameter("alamatToko",
                                                                         getValue(sqlidentitasa, "alamatoko").ToString))
                    StrukA.LocalReport.SetParameters(New ReportParameter("nomorToko",
                                                                         getValue(sqlidentitasa, "notoko").ToString))
                    StrukA.LocalReport.SetParameters(New ReportParameter("kota",
                                                                         getValue(sqlidentitasa, "kota").ToString))
                    StrukA.LocalReport.SetParameters(New ReportParameter("username", Form1.username))
                    StrukA.LocalReport.SetParameters(New ReportParameter("caption1",
                                                                         getValue(sqlidentitasa, "caption1").ToString))
                    StrukA.LocalReport.SetParameters(New ReportParameter("caption2",
                                                                         getValue(sqlidentitasa, "caption2").ToString))
                    StrukA.LocalReport.SetParameters(New ReportParameter("caption3",
                                                                         getValue(sqlidentitasa, "caption3").ToString))
                    Dim sqlhutang As String =
                            "SELECT jatuhtempo as jatuhtempo from tblhutangtemporal where idjual = " &
                            idbeli
                    StrukA.LocalReport.SetParameters(New ReportParameter("jatuhtempo",
                                                                         getValue(sqlhutang, "jatuhtempo").ToString))
                    StrukA.LocalReport.SetParameters(New ReportParameter("bank",
                                                                         getValue(sqlidentitasa, "bank").ToString))
                    StrukA.LocalReport.SetParameters(New ReportParameter("rekening",
                                                                         getValue(sqlidentitasa, "rekening").ToString))
                    StrukA.LocalReport.SetParameters(New ReportParameter("anbank",
                                                                         getValue(sqlidentitasa, "anbank").ToString))
                    StrukA.RefreshReport()

                    m_bPrint = True

                Else
                    ''Form1.openPenjualan(True)
                    FormPenawaranJual.restartControl()
                    'Me.Close()
                End If

            End If
        ElseIf hutang Then
            dialogError("Pembayaran kelebihan")

        Else
            dialogError("Pembayaran kurang")


        End If
    End Sub

    Sub simpanBayarJalan()
        For Each rows As DataGridViewRow In datagridview.Rows
            If Not updateTemp(rows.Cells(1).Value) Then
                dialogError("Stok " & rows.Cells(2).Value & " tidak cukup")
                Return
            End If
        Next

        Dim bayar As Double = 0
        If Double.TryParse(unnumberFormat(tbBayar.Text), 0) Then
            bayar = toDouble(unnumberFormat(tbBayar.Text))
        End If

        Dim diskon As Double = 0
        If Double.TryParse(TBDiskon.Text, 0) Then
            diskon = toDouble(TBDiskon.Text)
        End If

        Dim kembali = bayar - (total*(100 - diskon)/100)
        If diskon > 99 Then
            dialogError("Isi diskon degan benar")

        ElseIf String.IsNullOrWhiteSpace(tbBayar.Text) Then
            dialogError("Isi bayar terlebih dahulu")
        ElseIf (Not hutang And kembali >= 0) Or (hutang And kembali < 0) Then
            Dim metode = "Hutang"
            Dim akun = "-"
            Dim noakun = "-"


            Dim isidata As String() = New String() _
                    {fakturbeli, tanggal, total.ToString, unnumberFormat(tbBayar.Text), kembali.ToString, supplier,
                     metode, akun, noakun, unnumberFormat(TBPotongan.Text), user, dokter, resep}
            Dim sql As String =
                    "INSERT INTO tbljual (fakturjual, tgljual, total, bayar, kembali, idpelanggan, metode, kartu, nokartu, granddiskon, username,iddokter,resep) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)"


            If operationQuery(sql, isidata) Then
                If saved Then
                    exc("DELETE FROM tbldetailjual WHERE idjual = " & idorder)
                    exc("DELETE FROM tbljual WHERE idjual = " & idorder)
                End If
                If hutang Then
                    Dim piutang = kembali*- 1
                    exc("update tblpelanggan set hutang = hutang + " & piutang & " where idpelanggan=" & supplier)
                End If
                Dim idbeli As String = getValue("select * from tbljual order by idjual desc", "idjual")
                isidetail(idbeli)
                dialogInfo("Berhasil")
                If dialog("Apakah anda ingin mencetak surat Jalan ?") Then
                    '' Form1.openPenjualan(True)
                    FormPenawaranJual.restartControl()
                    SuratJalan.idjual = idbeli
                    SuratJalan.Show()
                    Me.Close()
                Else
                    ''   Form1.openPenjualan(True)
                    FormPenawaranJual.restartControl()
                    Me.Close()
                End If

            End If
        ElseIf hutang Then
            dialogError("Pembayaran kelebihan")

        Else
            dialogError("Pembayaran kurang")


        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        simpanBayar()
    End Sub

    Private Sub Button5_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles tbTotal.KeyDown, tbKembali.KeyDown, tbBayar.KeyDown, Button6.KeyDown, Button5.KeyDown, Button4.KeyDown,
                Button3.KeyDown, Button2.KeyDown, Button1.KeyDown, TBDiskon.KeyDown, Button7.KeyDown, Button8.KeyDown,
                Button9.KeyDown
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

    Private Sub TBDiskon_TextChanged(sender As Object, e As EventArgs) Handles TBDiskon.TextChanged
        If Not diskonNominal.Checked Then
            Dim diskon As Double = 0
            If Double.TryParse(TBDiskon.Text, 0) Then
                diskon = toDouble(TBDiskon.Text)
            End If
            TBPotongan.Text = numberFormat((total*(diskon)/100).ToString)
            tbTotal.Text = numberFormat((total*(100 - diskon)/100).ToString)
            Dim bayar As Double = 0
            If Double.TryParse(unnumberFormat(tbBayar.Text), 0) Then
                bayar = toDouble(unnumberFormat(tbBayar.Text))
            End If

            tbKembali.Text = numberFormat((bayar - (total*(100 - diskon)/100)).ToString)
        End If
    End Sub

    Private Sub TBDiskon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBDiskon.KeyPress, tbBayar.KeyPress
        onlyNumber(e)
    End Sub


    Private Sub TBDiskon_Validating(sender As Object, e As CancelEventArgs) Handles TBDiskon.Validating
        If String.IsNullOrWhiteSpace(TBDiskon.Text) Then
            TBDiskon.Text = "0"
        End If
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Sub cetakStruk()

        PreviewStrukA5.idjual = cetak
        PreviewStrukA5.ShowDialog()
        PreviewStruk70.Dispose()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        SuratJalan.idjual = cetak
        SuratJalan.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        cetakStruk()
    End Sub

    Private Sub tbKembali_TextChanged(sender As Object, e As EventArgs) Handles tbKembali.TextChanged
    End Sub

    Private Sub diskonNominal_CheckedChanged(sender As Object, e As EventArgs) Handles diskonNominal.CheckedChanged
        If diskonNominal.Checked Then

            TBDiskon.Enabled = False
            TBPotongan.Enabled = True
            TBPotongan.Text = "0"
        Else
            TBDiskon.Enabled = True
            TBPotongan.Enabled = False
            TBDiskon.Text = "0"
        End If
    End Sub

    Dim check2 = True

    Private Sub TBPotongan_TextChanged(sender As Object, e As EventArgs) Handles TBPotongan.TextChanged
        If diskonNominal.Checked Then
            If check2 Then
                check2 = False
                TBPotongan.Text = numberFormat(unnumberFormat(TBPotongan.Text))
                TBPotongan.SelectionStart = TBPotongan.Text.Count
                TBPotongan.SelectionLength = 0
                check2 = True
            End If
            Dim diskon As Double = 0
            If Double.TryParse(TBDiskon.Text, 0) Then
                diskon = toDouble(TBDiskon.Text)
            End If
            tbTotal.Text = numberFormat((total - toDouble(unnumberFormat(TBPotongan.Text))))
            TBDiskon.Text = (toDouble(unnumberFormat(TBPotongan.Text))/total*100)

            Dim bayar As Double = 0
            If Double.TryParse(unnumberFormat(tbBayar.Text), 0) Then
                bayar = toDouble(unnumberFormat(tbBayar.Text))
            End If

            tbKembali.Text = numberFormat((bayar - (total - toDouble(unnumberFormat(TBPotongan.Text))).ToString))
        End If
    End Sub

    Private Sub TBPotongan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBPotongan.KeyPress
        onlyNumber(e)
    End Sub
End Class