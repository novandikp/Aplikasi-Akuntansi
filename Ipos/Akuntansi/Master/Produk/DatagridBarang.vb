

Public Class DatagridBarang
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
        dataFocus()
    End Sub

    'Focus pada data
    Sub dataFocus()
        gbData.Enabled = True
        panelAksi.Enabled = True
    End Sub

    Sub awal()
        styliseDG(ListSat)

        setGudang()
        getDataProduk()
        eCari.Focus()
        addhandlertoAllComponent()
    End Sub


    Sub setGudang()
        Dim dt As DataTable = getData("SELECT idgudang,gudang from tblgudang order by idgudang")
        Dim dr As DataRow = dt.NewRow
        dr.Item(0) = ".?.?????"
        dr.Item(1) = "Semua"
        dt.Rows.InsertAt(dr, 0)
        cbSub.DataSource = dt
        cbSub.DisplayMember = "gudang"
        cbSub.ValueMember = "idgudang"
        cbSub.SelectedIndex = 0
    End Sub

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

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListSat.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListSat.Focus()
            If ListSat.Rows.Count > 0 Then
                ListSat.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            tambahData()
        ElseIf e.KeyCode = Keys.F2 Then
            editData()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusData()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
    End Sub


    Sub tambahData()
        ListSat.ClearSelection()

        Dim dialogresult As DialogResult = FormBarang.ShowDialog()
        If dialogresult = DialogResult.OK Then
            getDataProduk()
        End If
        FormBarang.Dispose()
    End Sub

    Sub editData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idproduk As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value
            FormBarang.idproduk = idproduk
            Dim dialogresult As DialogResult = FormBarang.ShowDialog()
            If dialogresult = DialogResult.OK Then
                getDataProduk()
            End If
            FormBarang.Dispose()
        Else
            dialogError("Pilih Produk terlebih dahulu")
        End If
    End Sub

    Sub hapusData()

        If ListSat.SelectedRows.Count = 1 Then
            If dialog("Apakah anda yakin untuk menghapus Data ini ?") Then
                Dim idproduk As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value
                If exc("delete from tblharga where idbarang='" & idproduk & "'") Then
                    exc("delete from tblproduk where idproduk='" & idproduk & "'")
                End If
                dialogSukses("Data berhasil dihapus")
                getDataProduk()
            End If

        Else
            dialogError("Pilih Produk terlebih dahulu")
        End If
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Sub getDataProduk()
        ListSat.ClearSelection()
        Dim cari As String = eCari.Text

        Dim sql As String
        If cbSub.SelectedIndex > 0 Then
            sql = "SELECT tblproduk.idproduk, produk, kategori, gudangvarian1.stok, satuan1.satuan , gudangvarian2.stok, satuan2.satuan, gudangvarian3.stok,satuan3.satuan from tblproduk 
left join tblharga as varian1 on varian1.idbarang = tblproduk.idproduk and varian1.""level""=1 left join tblsatuan as satuan1 on satuan1.kodesatuan = varian1.idsatuan left join (select idharga, sum(stok) as stok from tblstokgudang where idgudang ='" & cbSub.SelectedValue & "' GROUP by idharga) as gudangvarian1 on gudangvarian1.idharga = varian1.idharga
left join tblharga as varian2 on varian2.idbarang = tblproduk.idproduk and varian2.""level""=2 left join tblsatuan as satuan2 on satuan2.kodesatuan = varian2.idsatuan left join (select idharga, sum(stok) as stok from tblstokgudang where idgudang ='" & cbSub.SelectedValue & "' GROUP by idharga) as gudangvarian2 on  gudangvarian2.idharga = varian2.idharga
left join tblharga as varian3 on varian3.idbarang = tblproduk.idproduk and varian3.""level""=3 left join tblsatuan as satuan3 on satuan3.kodesatuan = varian3.idsatuan left join (select idharga, sum(stok) as stok from tblstokgudang where idgudang ='" & cbSub.SelectedValue & "' GROUP by idharga) as gudangvarian3 on  gudangvarian3.idharga = varian3.idharga
inner join tblkategori on tblproduk.idkategori = tblkategori.idkategori where tblproduk.idproduk ilike '%" & cari & "%' or produk ilike '%" & cari & "%'"
        Else

            sql = "SELECT tblproduk.idproduk, produk, kategori, gudangvarian1.stok, satuan1.satuan , gudangvarian2.stok, satuan2.satuan, gudangvarian3.stok,satuan3.satuan from tblproduk 
left join tblharga as varian1 on varian1.idbarang = tblproduk.idproduk and varian1.""level""=1 left join tblsatuan as satuan1 on satuan1.kodesatuan = varian1.idsatuan left join (select idharga, sum(stok) as stok from tblstokgudang GROUP by idharga) as gudangvarian1 on gudangvarian1.idharga = varian1.idharga
left join tblharga as varian2 on varian2.idbarang = tblproduk.idproduk and varian2.""level""=2 left join tblsatuan as satuan2 on satuan2.kodesatuan = varian2.idsatuan left join (select idharga, sum(stok) as stok from tblstokgudang GROUP by idharga) as gudangvarian2 on  gudangvarian2.idharga = varian2.idharga
left join tblharga as varian3 on varian3.idbarang = tblproduk.idproduk and varian3.""level""=3 left join tblsatuan as satuan3 on satuan3.kodesatuan = varian3.idsatuan left join (select idharga, sum(stok) as stok from tblstokgudang GROUP by idharga) as gudangvarian3 on  gudangvarian3.idharga = varian3.idharga
inner join tblkategori on tblproduk.idkategori = tblkategori.idkategori where tblproduk.idproduk ilike '%" & cari & "%' or produk ilike '%" & cari & "%'"
        End If

        Dim tableProduk As DataTable = getData(sql)

        For Each row As DataRow In tableProduk.Rows
            Dim satuan1 As String = row.Item(4).ToString
            Dim satuan2 As String = row.Item(6).ToString
            Dim satuan3 As String = row.Item(8).ToString
            If Not String.IsNullOrEmpty(satuan1) Then
                row.Item(3) = toDouble(row.Item(3).ToString)
            End If
            If Not String.IsNullOrEmpty(satuan2) Then
                row.Item(5) = toDouble(row.Item(5).ToString)
            End If
            If Not String.IsNullOrEmpty(satuan3) Then
                row.Item(7) = toDouble(row.Item(7).ToString)
            End If

        Next

        Me.ListSat.DataSource = tableProduk


        Try
            ListSat.Columns(0).HeaderText = "Kode Produk"
            ListSat.Columns(1).HeaderText = "Produk"
            ListSat.Columns(2).HeaderText = "Kategori"
            ListSat.Columns(3).HeaderText = "Stok 1"
            ListSat.Columns(4).HeaderText = "Satuan 1"
            ListSat.Columns(5).HeaderText = "Stok 2"
            ListSat.Columns(6).HeaderText = "Satuan 2"
            ListSat.Columns(7).HeaderText = "Stok 3"
            ListSat.Columns(8).HeaderText = "Satuan 3"

        Catch ex As Exception
        End Try
        styliseDG(ListSat)

        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        closeTab()
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

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataProduk()
    End Sub

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataProduk()
    End Sub
End Class