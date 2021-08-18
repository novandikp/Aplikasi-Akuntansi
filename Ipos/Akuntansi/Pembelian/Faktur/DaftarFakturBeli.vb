Public Class DaftarFakturBeli

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


        Dim sql As String = "SELECT tglbeli,kodebeli, tblkontak.pelanggan, total,diskonrupiah,biayalain,totalpajak,cast(statusbeli as varchar) from tblbeli inner join tblkontak on tblkontak.idpelanggan = tblbeli.pelanggan "
        Dim filter As String = "WHERE (kodebeli ilike '%" & cari & "%' or tblkontak.pelanggan ilike '%" & cari & "%') AND tglbeli BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' order by tglbeli,kodebeli"
        ListSat.DataSource = getData(sql & filter)
        ListSat.Columns(0).HeaderText = "Tanggal"
        ListSat.Columns(1).HeaderText = "Faktur Pembelian"
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
        Dim ds As DialogResult = FormFakturbeli.ShowDialog()
        If ds = DialogResult.OK Then

        End If
        fillData()
        FormFakturbeli.Dispose()
    End Sub

    Sub cetakJurnal()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value
            Modul.openJurnalDialog(idselected)
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub


    Sub editData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value
            Dim sqlbeli As String = "select kodepengirimanbeli from tblbeli where kodebeli ='" & idselected & "'"

            Dim pesanan As New FormFakturbeli

            If String.IsNullOrEmpty(getValue(sqlbeli, "kodepengirimanbeli")) Then
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
            Dim sqlparent As String = "SELECT kodebeli from tblreturbeli where kodebeli='" & idselected & "'"
            Dim sqlparent2 As String = "SELECT kodebeli from tblbayarhutang where kodebeli='" & idselected & "'"
            If getCount(sqlparent) = 0 And getCount(sqlparent2) = 0 Then
                If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                    Dim sqlhapus = "DELETE FROM tblbeli where kodebeli = '" & idselected & "';"
                    Dim sqlhapusdetail = "DELETE FROM tbldetailbeli where kodebeli = '" & idselected & "';"
                    exc("update tblstokgudang set stok = stok - sub.jumlahbeli from ( SELECT tbldetailbeli.idharga, tbldetailbeli.jumlahbeli,tblbeli.kodegudang, tbldetailbeli.kodebeli from tbldetailbeli  inner join tblbeli on tbldetailbeli.kodebeli = tblbeli.kodebeli ) sub where tblstokgudang.idharga = sub.idharga and tblstokgudang.idgudang= sub.kodegudang and kodebeli='" & idselected & "'")
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
        Dim kodebeli As String = generateRefrence("FB")
        Dim pembayaran As Double = bayar.bayar
        Dim grandTotal As Double = bayar.grandtotalResult
        Dim kembali As Double = pembayaran - grandTotal

        Dim isidata As String() = {bayar.kasPenerimaaan, pembayaran.ToString, kembali.ToString, kodebeli, Now().ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), bayar.total.ToString, bayar.diskonRupiah.ToString, bayar.diskonPersen.ToString, bayar.totalpajak.ToString, bayar.biayaLain.ToString, bayar.kasBiayaLain.ToString, bayar.kasDiskon.ToString, bayar.nomerDokumen, bayar.tglDokumen, "0", bayar.refrensi}
        Dim sql As String = "INSERT INTO public.tblbeli (kaspenerimaan, bayar, kembali,kodebeli, tglbeli, kodedepartemen, kodeprojek, total, diskonrupiah, diskonpersen, totalpajak, biayalain,  kasbiayalain, kasdiskon, nomerdokumen, tgldokumen, pelanggan, kodegudang, statusbeli,kodepengirimanbeli)  select ?, ? ,? ,? , ?, kodedepartemen, kodeprojek, ?, ?,?,?,?, ?,?,?,?,pelanggan,kodegudang, ?,? from tblpengirimanbeli where kodepengirimanbeli ='" & bayar.refrensi & "'  limit 1;"
        operationQuery(sql, isidata)
        Dim sqlDetail As String = "insert into tbldetailbeli (idharga, jumlahbeli, hargabeli, jumlahpajak, catatandetail, diskondetailpersen,kodebeli) SELECT  idharga, jumlahbeli, hargabeli, jumlahpajak, catatandetail, diskondetailpersen,'" & kodebeli & "' from tbldetailpengirimanbeli where kodepengirimanbeli ='" & bayar.refrensi & "'"
        exc(sqlDetail)
        Dim sqlhpp As String = "SELECT sum(jumlahbeli * tbldetailbeli.hargabeli * (100 - diskondetailpersen)/100) as total from tbldetailbeli inner join tblharga on tblharga.idharga = tbldetailbeli.idharga where kodebeli ='" & kodebeli & "'"

        Dim akunPersediaan As String = "149001"

        Dim akunhutangUsaha As String = "210001"

        Dim akunUtangPajak As String = "152001"

        ''Input Jurnal
        Dim sqlbeli As String = "select kodedepartemen, kodeprojek,pelanggan from tblbeli where kodebeli='" & kodebeli & "'"
        Dim iddepartemen = getValue(sqlbeli, "kodedepartemen")
        Dim idpelanggan = getValue(sqlbeli, "pelanggan")
        Dim idprojek = getValue(sqlbeli, "kodeprojek")

        If String.IsNullOrEmpty(idprojek) Then
            idprojek = "NULL"
        Else
            idprojek = idprojek.ToString
        End If

        Dim sqlJurnal As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);"



        'hutang Usaha
        If kembali < 0 Then
            Dim datahutangUsaha As String() = {akunhutangUsaha, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), (kembali * -1).ToString, "0", "FB", kodebeli, "Faktur Pembelian, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, datahutangUsaha)
            exc("INSERT into tblhistorihutang (idjurnal) select idjurnal from tbljurnal where koderefrensi='" & kodebeli & "' AND kodeakun='" & akunhutangUsaha & "'")
        End If

        'Uang Muka 
        If bayar.bayar > 0 And kembali < 0 Then
            Dim dataPembayaran As String() = {bayar.kasPenerimaaan, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), bayar.bayar.ToString, "0", "FB", kodebeli, "Faktur Pembelian, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, dataPembayaran)
        ElseIf bayar.bayar > 0 And kembali >= 0 Then
            'Pembayaran
            Dim total As Double = bayar.grandtotalResult
            Dim dataPembayaran As String() = {bayar.kasPenerimaaan, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), total.ToString, "0", "FB", kodebeli, "Faktur Pembelian, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, dataPembayaran)
        End If

        'Biaya lain
        If bayar.biayaLain > 0 Then
            Dim dataBiayaLain As String() = {bayar.kasBiayaLain, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", bayar.biayaLain.ToString, "FB", kodebeli, "Faktur Pembelian, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, dataBiayaLain)
        End If

        'Potongan Harga
        If bayar.diskonRupiah > 0 Then
            Dim dataDiskonDebit As String() = {bayar.kasBiayaLain, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), bayar.diskonRupiah.ToString, "0", "FB", kodebeli, "Faktur Pembelian, Dari Pengiriman" & bayar.refrensi}
            operationQuery(sqlJurnal, dataDiskonDebit)
        End If

        'Insert Pajaknya
        Dim diskonSisa As Double = 100 - bayar.diskonPersen
        Dim sqlpajak As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) select COALESCE(tblpajak.akunpajakbeli,'" & akunUtangPajak & "')," & idprojek & ",'" & iddepartemen & "', " & idpelanggan & ",'" & Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "',0, sum(jumlahpajak) * " & diskonSisa.ToString & "/100,'FB','" & kodebeli & "','Faktur Pembelian, Dari Pengiriman" & bayar.refrensi & "'  from tbldetailbeli inner join tblharga on tblharga.idharga = tbldetailbeli.idharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblpajak on tblpajak.kodepajak = tblproduk.pajakbeli where kodebeli='" & kodebeli & "' GROUP BY tblpajak.akunpajakbeli"
        exc(sqlpajak)

        'HPP dan Persediaan

        Dim dataKredit As String() = {akunPersediaan, idprojek, iddepartemen, idpelanggan, Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", getValue(sqlhpp, "total"), "FB", kodebeli, "Faktur Pembelian, Dari Pengiriman" & bayar.refrensi}


        operationQuery(sqlJurnal, dataKredit)
        exc("delete from tbljurnal where debit = 0 and kredit=0 and koderefrensi='" & kodebeli & "'")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialogPengiriman As New DialogPengirimanbeli
        If dialogPengiriman.ShowDialog = DialogResult.OK Then
            Dim dialogPembayaran As New DialogTransaksiBayar
            Dim sqlPengirimanbeli As String = "SELECT sum(jumlahpajak) as totalpajak, sum(jumlahbeli * hargabeli * (100 - diskondetailpersen)/100) as total from tbldetailpengirimanbeli where kodepengirimanbeli='" & dialogPengiriman.kodepengirimanbeli & "'"

            dialogPembayaran.total = toDouble(getValue(sqlPengirimanbeli, "total"))
            dialogPembayaran.totalpajak = toDouble(getValue(sqlPengirimanbeli, "totalpajak"))
            dialogPembayaran.tableRefrensi = "tblpengirimanbeli"
            dialogPembayaran.keyRefrensi = "kodepengirimanbeli"
            dialogPembayaran.refrensi = dialogPengiriman.kodepengirimanbeli
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