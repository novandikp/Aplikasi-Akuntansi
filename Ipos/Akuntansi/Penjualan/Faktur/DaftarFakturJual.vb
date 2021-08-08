Public Class DaftarFakturJual

    Sub addhandlertoAllComponent()
        For Each komponen As Control In Me.Controls
            AddHandler komponen.KeyDown, AddressOf eventKeydown
            If komponen.Controls.Count > 0 Then
                For Each komponen2 As Control In komponen.Controls
                    AddHandler komponen2.KeyDown, AddressOf eventKeydown
                    If komponen2.Controls.Count > 0 Then
                        For Each komponen3 As Control In komponen2.Controls
                            AddHandler komponen3.KeyDown, AddressOf eventKeydown
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub eventKeydown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F1 Then
            tambahData()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusData()
        ElseIf e.KeyCode = Keys.F2 Then
            editData()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub

    Sub AllTotal()

        For Each row As DataGridViewRow In ListSat.Rows
            Dim total = row.Cells(3).Value
            Dim diskon = row.Cells(4).Value
            Dim biayalain = row.Cells(5).Value
            Dim pajak = row.Cells(6).Value
            row.Cells(3).Value = total + biayalain + pajak
        Next
        ListSat.Columns(3).DefaultCellStyle.Format = "n0"
    End Sub

    Sub fillData()
        Dim cari As String = eCari.Text
        Dim tglAwal As String = dtAwal.Value.ToString("yyyy-MM-dd")
        Dim tglAkhir As String = dtAkhir.Value.ToString("yyyy-MM-dd")


        Dim sql As String = "SELECT tgljual,kodejual, tblkontak.pelanggan, total,diskonrupiah,biayalain,totalpajak,cast(statusjual as varchar) from tbljual inner join tblkontak on tblkontak.idpelanggan = tbljual.pelanggan "
        Dim filter As String = "WHERE (kodejual ilike '%" & cari & "%' or tblkontak.pelanggan ilike '%" & cari & "%') AND tgljual BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' order by tgljual,kodejual"
        ListSat.DataSource = getData(sql & filter)
        ListSat.Columns(0).HeaderText = "Tanggal"
        ListSat.Columns(1).HeaderText = "Faktur Penjualan"
        ListSat.Columns(2).HeaderText = "Pelanggan"

        ListSat.Columns(3).HeaderText = "Nilai"
        ListSat.Columns(4).Visible = False
        ListSat.Columns(5).Visible = False
        ListSat.Columns(6).Visible = False
        ListSat.Columns(7).HeaderText = "Status"


        AllTotal()
        setStatusDataGrid(ListSat, 7)
        makeFillDG(ListSat)

    End Sub

    Private Sub DatagridBukuBesar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillData()
        styliseDG(ListSat)
        addhandlertoAllComponent()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        fillData()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        fillData()
    End Sub


    Sub tambahData()
        Dim ds As DialogResult = FormFakturJual.ShowDialog()
        If ds = DialogResult.OK Then

        End If
        fillData()
        FormFakturJual.Dispose()
    End Sub

    Sub editData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value
            Dim sqlJual As String = "select kodepengirimanjual from tbljual where kodejual ='" & idselected & "'"

            Dim pesanan As New FormFakturJual

            If String.IsNullOrEmpty(getValue(sqlJual, "kodepengirimanjual")) Then
                pesanan.TBnotransaksi.Text = idselected
                pesanan.edited = True
                Dim ds As DialogResult = pesanan.ShowDialog()
                If ds = DialogResult.OK Then
                End If
                fillData()
            Else
                dialogError("Faktur Dari Pengiriman tidak bisa diedit")
            End If


            pesanan.Dispose()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub hapusData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value
            Dim sqlparent As String = "SELECT kodejual from tblreturjual where kodejual='" & idselected & "'"
            Dim sqlparent2 As String = "SELECT kodejual from tblbayarpiutang where kodejual='" & idselected & "'"
            If getCount(sqlparent) = 0 And getCount(sqlparent2) = 0 Then
                If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                    Dim sqlhapus = "DELETE FROM tbljual where kodejual = '" & idselected & "';"
                    Dim sqlhapusdetail = "DELETE FROM tbldetailjual where kodejual = '" & idselected & "';"
                    exc("update tblstokgudang set stok = stok + sub.jumlahjual from ( SELECT tbldetailjual.idharga, tbldetailjual.jumlahjual,tbljual.kodegudang, tbldetailjual.kodejual from tbldetailjual  inner join tbljual on tbldetailjual.kodejual = tbljual.kodejual ) sub where tblstokgudang.idharga = sub.idharga and tblstokgudang.idgudang= sub.kodegudang and kodejual='" & idselected & "'")
                    If exc(sqlhapusdetail & sqlhapus) Then
                        exc("DELETE FROM tblhistoristok where refrensi='" & idselected & "';DELETE FROM tbljurnal WHERE koderefrensi='" & idselected & "';")
                        fillData()
                    Else
                        dialogError("Data tidak bisa dihapus karena data telah digunakan")
                    End If
                End If
            Else
                dialogError("Transaksi telah dipakai")
            End If

        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub cetakJurnal()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value
            Modul.openJurnalDialog(idselected)
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub
    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahData()
    End Sub

    Private Sub btnEdt_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
        editData()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusData()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Sub simpanDariPengiriman(bayar As DialogTransaksiBayar)
        Dim kodejual As String = generateRefrence("PJ")
        Dim pembayaran As Double = bayar.bayar
        Dim grandTotal As Double = bayar.grandtotalResult
        Dim kembali As Double = pembayaran - grandTotal

        Dim isidata As String() = {bayar.kasPenerimaaan, pembayaran.ToString, kembali.ToString, kodejual, Now().ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), bayar.total.ToString, bayar.diskonRupiah.ToString, bayar.diskonPersen.ToString, bayar.totalpajak.ToString, bayar.biayaLain.ToString, bayar.kasBiayaLain.ToString, bayar.kasDiskon.ToString, bayar.nomerDokumen, bayar.tglDokumen, "0", bayar.refrensi}
        Dim sql As String = "INSERT INTO public.tbljual (kaspenerimaan, bayar, kembali,kodejual, tgljual, kodedepartemen, kodeprojek, total, diskonrupiah, diskonpersen, totalpajak, biayalain,  kasbiayalain, kasdiskon, nomerdokumen, tgldokumen, pelanggan, kodegudang, statusjual,kodepengirimanjual)  select ?, ? ,? ,? , ?, kodedepartemen, kodeprojek, ?, ?,?,?,?, ?,?,?,?,pelanggan,kodegudang, ?,? from tblpengirimanjual where kodepengirimanjual ='" & bayar.refrensi & "'  limit 1;"
        operationQuery(sql, isidata)
        Dim sqlDetail As String = "insert into tbldetailjual (idharga, jumlahjual, hargajual, jumlahpajak, catatandetail, diskondetailpersen,kodejual) SELECT  idharga, jumlahjual, hargajual, jumlahpajak, catatandetail, diskondetailpersen,'" & kodejual & "' from tbldetailpengirimanjual where kodepengirimanjual ='" & bayar.refrensi & "'"
        exc(sqlDetail)
        Dim sqlhpp As String = "SELECT sum(hpp* jumlahjual) as hpp, sum(jumlahjual * tbldetailjual.hargajual * (100 - diskondetailpersen)/100) as total from tbldetailjual inner join tblharga on tblharga.idharga = tbldetailjual.idharga where kodejual ='" & kodejual & "'"

        Dim akunPersediaan As String = "219001"
        Dim akunHPP As String = "510001"
        Dim akunPiutangUsaha As String = "130001"
        Dim akunPenjualanProduk As String = "410001"
        Dim akunUtangPajak As String = "230001"

        ''Input Jurnal
        Dim sqlJual As String = "select kodedepartemen, kodeprojek,pelanggan from tbljual where kodejual='" & kodejual & "'"
        Dim iddepartemen = getValue(sqlJual, "kodedepartemen")
        Dim idpelanggan = getValue(sqlJual, "pelanggan")
        Dim idprojek = getValue(sqlJual, "kodeprojek")

        If String.IsNullOrEmpty(idprojek) Then
            idprojek = "NULL"
        Else
            idprojek = idprojek.ToString
        End If

        Dim sqlJurnal As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);"

        'Penjualan Produk
        Dim dataPenjualanProduk As String() = {akunPenjualanProduk, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", getValue(sqlhpp, "total"), "PJ", kodejual, "Faktur Penjualan, Dari Pengiriman" & bayar.refrensi}
        operationQuery(sqlJurnal, dataPenjualanProduk)


        'Piutang Usaha
        If kembali < 0 Then
            Dim dataPiutangUsaha As String() = {akunPiutangUsaha, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), (kembali * -1).ToString, "0", "PJ", kodejual, "Faktur Penjualan, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, dataPiutangUsaha)
            exc("INSERT into tblhistoripiutang (idjurnal) select idjurnal from tbljurnal where koderefrensi='" & kodejual & "' AND kodeakun='" & akunPiutangUsaha & "'")
        End If

        'Uang Muka 
        If bayar.bayar > 0 And kembali < 0 Then
            Dim dataPembayaran As String() = {bayar.kasPenerimaaan, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), bayar.bayar.ToString, "0", "PJ", kodejual, "Faktur Penjualan, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, dataPembayaran)
        ElseIf bayar.bayar > 0 And kembali >= 0 Then
            'Pembayaran
            Dim total As Double = bayar.grandtotalResult
            Dim dataPembayaran As String() = {bayar.kasPenerimaaan, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), total.ToString, "0", "PJ", kodejual, "Faktur Penjualan, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, dataPembayaran)
        End If

        'Biaya lain
        If bayar.biayaLain > 0 Then
            Dim dataBiayaLain As String() = {bayar.kasBiayaLain, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", bayar.biayaLain.ToString, "PJ", kodejual, "Faktur Penjualan, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, dataBiayaLain)
        End If

        'Potongan Harga
        If bayar.diskonRupiah > 0 Then
            Dim dataDiskonDebit As String() = {bayar.kasBiayaLain, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), bayar.diskonRupiah.ToString, "0", "PJ", kodejual, "Faktur Penjualan, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, dataDiskonDebit)
        End If

        'Insert Pajaknya
        Dim diskonSisa As Double = 100 - bayar.diskonPersen
        Dim sqlpajak As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) select COALESCE(tblpajak.akunpajakjual,'" & akunUtangPajak & "')," & idprojek & ",'" & iddepartemen & "', " & idpelanggan & ",'" & Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "',0, sum(jumlahpajak) * " & diskonSisa.ToString & "/100,'PJ','" & kodejual & "','Faktur Penjualan, Dari Pengiriman" & bayar.refrensi & "'  from tbldetailjual inner join tblharga on tblharga.idharga = tbldetailjual.idharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblpajak on tblpajak.kodepajak = tblproduk.pajakjual where kodejual='" & kodejual & "' GROUP BY tblpajak.akunpajakjual"
        exc(sqlpajak)

        'HPP dan Persediaan
        Dim dataDebit As String() = {akunHPP, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), getValue(sqlhpp, "hpp"), "0", "PJ", kodejual, "Faktur Penjualan, Dari Pengiriman" & bayar.refrensi}
        Dim dataKredit As String() = {akunPersediaan, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", getValue(sqlhpp, "hpp"), "PJ", kodejual, "Faktur Penjualan, Dari Pengiriman" & bayar.refrensi}

        operationQuery(sqlJurnal, dataDebit)
        operationQuery(sqlJurnal, dataKredit)
        exc("delete from tbljurnal where debit = 0 and kredit=0 and koderefrensi='" & kodejual & "'")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialogPengiriman As New DialogPengirimanJual
        If dialogPengiriman.ShowDialog = DialogResult.OK Then
            Dim dialogPembayaran As New DialogTransaksiBayar
            Dim sqlPengirimanjual As String = "SELECT sum(jumlahpajak) as totalpajak, sum(jumlahjual * hargajual * (100 - diskondetailpersen)/100) as total from tbldetailpengirimanjual where kodepengirimanjual='" & dialogPengiriman.kodepengirimanjual & "'"

            dialogPembayaran.total = toDouble(getValue(sqlPengirimanjual, "total"))
            dialogPembayaran.totalpajak = toDouble(getValue(sqlPengirimanjual, "totalpajak"))
            dialogPembayaran.tableRefrensi = "tblpengirimanjual"
            dialogPembayaran.keyRefrensi = "kodepengirimanjual"
            dialogPembayaran.refrensi = dialogPengiriman.kodepengirimanjual
            If dialogPembayaran.ShowDialog = DialogResult.OK Then
                simpanDariPengiriman(dialogPembayaran)
                dialogSukses("Berhasil")
                fillData()
            End If
            dialogPembayaran.Dispose()
        End If
        dialogPengiriman.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cetakJurnal()
    End Sub
End Class