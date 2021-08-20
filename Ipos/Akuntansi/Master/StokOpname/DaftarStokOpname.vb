Public Class DaftarStokOpname
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
            tambahStokOpname()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusData()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub

    Sub tambahStokOpname()
        FormStokOpname.ShowDialog()
        FormStokOpname.Dispose()
        fillData()
    End Sub

    Sub cetakJurnal()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value
            Modul.openJurnalDialog(idselected)
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub


    Sub hapusData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value
            If True Then
                If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                    Dim sqlhapus = "DELETE FROM tblstokopname where kodestokopname = '" & idselected & "';"

                    exc("update tblstokgudang set stok = stok + (buku-fisik) from ( SELECT kodestokopname, idharga,buku,fisik,kodegudang from tblstokopname ) sub where tblstokgudang.idharga = sub.idharga and tblstokgudang.idgudang= sub.kodegudang and kodestokopname='" & idselected & "'")
                    If exc(sqlhapus) Then
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
        tambahStokOpname()
    End Sub

    Private Sub DaftarStokOpname_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillData()
    End Sub

    Sub fillData()
        Dim cari As String = eCari.Text
        Dim tglAwal As String = dtAwal.Value.ToString("yyyy-MM-dd")
        Dim tglAkhir As String = dtAkhir.Value.ToString("yyyy-MM-dd")


        Dim sql As String = "SELECT kodestokopname, gudang, tglstokopname, produk, buku, fisik, satuan from tblstokopname 
        inner join tblgudang on tblgudang.idgudang = tblstokopname.kodegudang
        inner join tblharga on tblharga.idharga = tblstokopname.idharga 
        inner  join tblproduk  on tblproduk.idproduk = tblharga.idbarang
        inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan
        where  (produk ilike  '%" & cari & "%') and tglstokopname between '" & tglAwal & "' and '" & tglAkhir & "'"

        ListSat.DataSource = getData(sql)
        ListSat.Columns(0).HeaderText = "Kode"
        ListSat.Columns(1).HeaderText = "Gudang"
        ListSat.Columns(2).HeaderText = "Tanggal"
        ListSat.Columns(3).HeaderText = "Barang"
        ListSat.Columns(4).HeaderText = "Buku"
        ListSat.Columns(5).HeaderText = "Fisik"
        ListSat.Columns(6).HeaderText = "Satuan"

        makeFillDG(ListSat)

    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged, dtAkhir.ValueChanged
        fillData()
    End Sub

    Private Sub eCari_Click(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cetakJurnal()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusData()
    End Sub
End Class