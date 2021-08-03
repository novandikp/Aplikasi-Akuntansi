Public Class FormEditBarang
    Private Sub FormBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub
    Public jasa As Boolean = False
    Public idbarang As String = ""

    Sub setBarang()
        Dim sql As String =
                "SELECT idproduk,produk, ppnproduk, rak, stokmin, idkategori, idmerk, flex, statusbarang FROM tblproduk where idproduk='" &
                idbarang & "'"
        TBNama.Text = getValue(sql, "produk")
        TBKode.Text = getValue(sql, "idproduk")
        TBPajak.Text = getValue(sql, "ppnproduk")
        TBRak.Text = getValue(sql, "rak")
        stokMin.Text = getValue(sql, "stokmin")
        Dim idkategori As String = getValue(sql, "idkategori")
        setJasa(idkategori)
        If Not idkategori = "1" Then
            jasa = True
            cbJenis.SelectedValue = idkategori
            cbMerk.SelectedValue = getValue(sql, "idmerk")
        End If



        If getValue(sql, "flex") = "1" Then
            Flex1.Checked = True
        Else
            Flex1.Checked = False
        End If
        If getValue(sql, "statusbarang") = "0" Then
            solded.Checked = False
            notsolded.Checked = True
        Else
            solded.Checked = True
            notsolded.Checked = False
        End If
    End Sub


    Sub awal()

        getMerk()
        getJenis()
        getDataSatuan()
        solded.Checked = True

        setBarang()
        styliseDG(dgvSatuanBarang)
        TabControl1.SelectedIndex = 0

        Me.ActiveControl = TBKode
    End Sub

    Sub getMerk()
        cbMerk.DataSource = getData("SELECT idmerk,merk FROM tblmerk where idmerk > 1")
        cbMerk.ValueMember = "idmerk"
        cbMerk.DisplayMember = "merk"
    End Sub

    Sub getJenis()
        cbJenis.DataSource = getData("SELECT idkategori, kategori FROM tblkategori where idkategori > 1")
        cbJenis.ValueMember = "idkategori"
        cbJenis.DisplayMember = "kategori"
    End Sub


    Private Sub solded_CheckedChanged(sender As Object, e As EventArgs) Handles solded.CheckedChanged
        If solded.Checked Then
            notsolded.Checked = False
        End If
    End Sub

    Private Sub notsolded_CheckedChanged(sender As Object, e As EventArgs) Handles notsolded.CheckedChanged
        If notsolded.Checked Then
            solded.Checked = False
        End If
    End Sub


    Sub getDataSatuan()
        dgvSatuanBarang.DataSource =
            getData(
                "Select barcode, idsatuan, satuan, CASE WHEN tipedata = 1 THEN 'Nilai Dasar' WHEN tipedata = 2 THEN 'Konversi 1' ELSE 'Konversi 2' END, konversi, hargabeli, hargajual from view_harga where view_harga.idproduk='" &
                idbarang & "'")
        dgvSatuanBarang.Columns(0).Visible = False
        dgvSatuanBarang.Columns(1).Visible = False
        dgvSatuanBarang.Columns(2).HeaderText = "Satuan"
        dgvSatuanBarang.Columns(3).HeaderText = "Jenis"
        dgvSatuanBarang.Columns(4).HeaderText = "Konversi"
        dgvSatuanBarang.Columns(5).HeaderText = "Harga Beli"
        dgvSatuanBarang.Columns(6).HeaderText = "Harga Jual"
        dgvSatuanBarang.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvSatuanBarang.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvSatuanBarang.Columns(5).DefaultCellStyle.Format = "C2"
        dgvSatuanBarang.Columns(6).DefaultCellStyle.Format = "C2"

        If dgvSatuanBarang.Rows.Count = 3 Then
            btnTmbh.Enabled = False
        Else
            btnTmbh.Enabled = True
        End If
    End Sub


    Sub tambahDataSatuan()
        If dgvSatuanBarang.Rows.Count = 3 Then

            dialogError("Sudah terdapat transaksi")
        ElseIf _
            Not _
            Integer.Parse(getValue("SELECT (stok1+stok2+stok3) as stok FROM tblproduk where idproduk='" & idbarang & "'",
                                   "stok")) = 0 Then
            dialogError("Sudah terdapat transaksi")
        Else
            FormEditSatuanBarang.row = Nothing
            FormEditSatuanBarang.idbarang = idbarang
            FormEditSatuanBarang.ShowDialog()
        End If
    End Sub

    Sub editDataSatuan()
        If dgvSatuanBarang.SelectedRows.Count = 0 Then
            dialogError("Pilih Item terlebih dahulu")
        Else
            FormEditSatuanBarang.row = dgvSatuanBarang.Rows(dgvSatuanBarang.CurrentRow.Index).Cells(0).Value.ToString
            FormEditSatuanBarang.idbarang = idbarang
            FormEditSatuanBarang.ShowDialog()
        End If
    End Sub

    Sub hpsDataSatuan()
        If _
            Not _
            Integer.Parse(getValue("SELECT (stok1+stok2+stok3) as stok FROM tblproduk where idproduk='" & idbarang & "'",
                                   "stok")) = 0 Then
            dialogError("Sudah terdapat transaksi")
        Else
            If dgvSatuanBarang.SelectedRows.Count = 0 Then
                dialogError("Pilih Item terlebih dahulu")
            ElseIf Not dgvSatuanBarang.CurrentRow.Index = dgvSatuanBarang.Rows.Count - 1 Then
                dialogError("Harus hapus dari bawah")
            ElseIf dgvSatuanBarang.CurrentRow.Index = 0 Then
                dialogError("Satuan dasar tidak bisa dihapus")
            Else

                If dialog("Apakah anda yakin untuk menghapus satuan ini ?, Data tidak bisa dikembalikan") Then
                    exc(
                        "delete from tblharga where barcode=" &
                        dgvSatuanBarang.Rows(dgvSatuanBarang.CurrentRow.Index).Cells(0).Value.ToString)

                    If dgvSatuanBarang.CurrentRow.Index = 2 Then
                        exc("update tblproduk set konversi2 = 0 where idproduk='" & idbarang & "'")
                    ElseIf dgvSatuanBarang.CurrentRow.Index = 1 Then
                        exc("update tblproduk set konversi1 = 0 where idproduk='" & idbarang & "'")
                    End If
                End If

                getDataSatuan()
            End If
        End If
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahDataSatuan()
    End Sub

    Private Sub btnEdt_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
        editDataSatuan()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hpsDataSatuan()
    End Sub


    Sub closeTab()
        Me.Close()
        Return
        Dim listItemForms As FormEditBarang = Application.OpenForms("FormEditBarang")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Sub setJasa(idkat As String)
        If idkat = "1" Then
            AddBtn.Visible = False
            cbJenis.Visible = False
            Label4.Visible = False
            Button1.Visible = False
            Label6.Visible = False
            TBRak.Visible = False
            cbMerk.Visible = False
            Label5.Visible = False
            Button2.Visible = False
            stokMin.Enabled = False
            stokMin.Text = "0"
            ToolStripStatusLabel1.Visible = False
            TabPage2.Enabled = False
            Button3.Visible = True
            edtHargaJasa.Visible = True
            Label12.Visible = True
            lblBagiHasil.Visible = True
            edtBagiHasil.Visible = True
            persenBagiHasil.Visible = True
            Dim sql As String = "SELECT hargajual, hargabeli FROM tblharga where idproduk='" & idbarang & "'"
            edtHargaJasa.Text = getValue(sql, "hargajual")
            edtBagiHasil.Text = getValue(sql, "hargabeli")
        Else
            stokMin.Enabled = True
            persenBagiHasil.Visible = False
            ToolStripStatusLabel3.Visible = True
            TabPage2.Enabled = True
            AddBtn.Visible = True
            cbJenis.Visible = True
            Label4.Visible = True
            Button1.Visible = True
            Label6.Visible = True
            TBRak.Visible = True
            cbMerk.Visible = True
            Label5.Visible = True
            Button2.Visible = True

            Button3.Visible = False
            edtHargaJasa.Visible = False
            Label12.Visible = False
            lblBagiHasil.Visible = False
            edtBagiHasil.Visible = False
        End If
    End Sub

    Sub simpanDataBarang()
        Dim kodebarang = TBKode.Text
        Dim sqla As String =
                "SELECT idproduk, produk, idkategori, idmerk, ppnproduk, rak, gambar, statusbarang, stokis, stok1, stok2, stok3, konversi1, konversi2, flex, stokmin FROM tblproduk where idproduk='" &
                idbarang & "'"
        Dim barang = getValue(sqla, "produk")
        Dim nama = TBNama.Text
        Dim pajak = TBPajak.Text
        Dim rak = TBRak.Text
        Dim merk = cbMerk.SelectedValue
        Dim jenis = cbJenis.SelectedValue

        Dim flex = "0"
        If Flex1.Checked = True Then
            flex = "1"
        End If

        Dim status = "0"

        If solded.Checked Then
            status = "1"
        End If

        Dim konversi1 As String = "1"
        Dim konversi2 As String = "1"


        If dgvSatuanBarang.Rows.Count > 1 Then
            konversi1 = dgvSatuanBarang.Rows(1).Cells(4).Value.ToString
        End If

        If dgvSatuanBarang.Rows.Count > 2 Then
            konversi2 = dgvSatuanBarang.Rows(2).Cells(4).Value.ToString
        End If


        If String.IsNullOrWhiteSpace(stokMin.Text) Then
            stokMin.Text = "0"
        End If

        If _
            String.IsNullOrWhiteSpace(kodebarang) Or String.IsNullOrWhiteSpace(nama) Or String.IsNullOrWhiteSpace(pajak) Or
            String.IsNullOrWhiteSpace(rak) Or dgvSatuanBarang.Rows.Count = 0 Then
            dialogError("Isi form dengan benar")

        ElseIf _
            getCount("select idproduk from tblproduk where idproduk='" + kodebarang + "'") > 0 And
            Not kodebarang = idbarang Then
            dialogError("Kode Barang sudah digunakan")
        ElseIf getCount("select produk from tblproduk where produk='" + nama + "'") > 0 And Not nama = barang Then
            dialogError("Nama Barang sudah digunakan")
        ElseIf Integer.Parse(pajak) > 100 Then
            dialogError("Isi pajak dengan benar 0-100")
        Else
            Dim sql As String =
                    "update tblproduk set idproduk=?, produk=?, idkategori=?, idmerk=?, ppnproduk=?, rak=?, gambar=?, statusbarang=?, flex=?, stokmin=? where idproduk= ?"
            If _
                operationQuery(sql,
                               {kodebarang, nama, jenis, merk, pajak, rak, "", status, flex, stokMin.Text, idbarang}) _
                Then
                exc("update tblharga set idproduk ='" & kodebarang & "' where idproduk = '" & idbarang & "'")
                exc("update tblstok set idproduk='" & kodebarang & "' where idproduk='" & idbarang & "'")
                exc("update tblstokopname set idproduk='" & kodebarang & "' where idproduk='" & idbarang & "'")
                exc("update tbldetailjual set barcode='" & kodebarang & "' where barcode='" & idbarang & "'")
                exc("update tbldetailbeli set barcode='" & kodebarang & "' where barcode='" & idbarang & "'")
                closeTab()
                Form1.refreshProduk()
                DatagridBarang.getDataProduk()
                ' Form1.openListProduk()
            End If


        End If
    End Sub


    Sub simpanDataJasa()
        If Not (toDouble(edtBagiHasil.Text) < 100 And toDouble(edtBagiHasil.Text) > 0 And Not String.IsNullOrEmpty(edtBagiHasil.Text)) Then
            dialogError("Isi bagi hasil 0-100")
            Return
        End If
        Dim kodebarang = TBKode.Text
        Dim sqla As String =
                "SELECT idproduk, produk, idkategori, idmerk, ppnproduk, rak, gambar, statusbarang, stokis, stok1, stok2, stok3, konversi1, konversi2, flex, stokmin FROM tblproduk where idproduk='" &
                idbarang & "'"
        Dim barang = getValue(sqla, "produk")
        Dim nama = TBNama.Text
        Dim pajak = TBPajak.Text
        Dim rak = "-"
        Dim merk = "1"
        Dim jenis = "1"

        Dim flex = "0"
        If Flex1.Checked = True Then
            flex = "1"
        End If

        Dim status = "0"

        If solded.Checked Then
            status = "1"
        End If

        Dim konversi1 As String = "1"
        Dim konversi2 As String = "1"


        If String.IsNullOrWhiteSpace(stokMin.Text) Then
            stokMin.Text = "0"
        End If

        If _
            String.IsNullOrWhiteSpace(kodebarang) Or String.IsNullOrWhiteSpace(nama) Or String.IsNullOrWhiteSpace(pajak) Or
            String.IsNullOrWhiteSpace(rak) Or dgvSatuanBarang.Rows.Count = 0 Then
            dialogError("Isi form dengan benar")

        ElseIf _
            getCount("select idproduk from tblproduk where idproduk='" + kodebarang + "'") > 0 And
            Not kodebarang = idbarang Then
            dialogError("Kode Barang sudah digunakan")
        ElseIf getCount("select produk from tblproduk where produk='" + nama + "'") > 0 And Not nama = barang Then
            dialogError("Nama Barang sudah digunakan")
        ElseIf Integer.Parse(pajak) > 100 Then
            dialogError("Isi pajak dengan benar 0-100")
        Else
            Dim sql As String =
                    "update tblproduk set idproduk=?, produk=?, idkategori=?, idmerk=?, ppnproduk=?, rak=?, gambar=?, statusbarang=?, flex=?, stokmin=? where idproduk= ?"
            If _
                operationQuery(sql,
                               {kodebarang, nama, jenis, merk, pajak, rak, "", status, flex, stokMin.Text, idbarang}) _
                Then
                exc(
                    "update tblharga set idproduk ='" & kodebarang & "', hargajual ='" & edtHargaJasa.[Text] &
                    "',hargabeli ='" & edtBagiHasil.Text & "' where idproduk = '" & idbarang & "'")
                exc("update tblstok set idproduk='" & kodebarang & "' where idproduk='" & idbarang & "'")
                exc("update tblstokopname set idproduk='" & kodebarang & "' where idproduk='" & idbarang & "'")
                exc("update tbldetailjual set barcode='" & kodebarang & "' where barcode='" & idbarang & "'")
                exc("update tbldetailbeli set barcode='" & kodebarang & "' where barcode='" & idbarang & "'")
                closeTab()
                Form1.refreshProduk()
                DatagridBarang.getDataProduk()
                ' Form1.openListProduk()
            End If


        End If
    End Sub

    Private Sub BtnHps_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles dgvSatuanBarang.KeyDown, btnTmbh.KeyDown, BtnHps.KeyDown, btnEdt.KeyDown, TabPage2.KeyDown,
                stokMin.KeyDown, Button14.KeyDown
        If e.KeyCode = Keys.F11 And jasa Then
            simpanDataBarang()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
        If e.KeyCode = Keys.F1 And jasa Then
            tambahDataSatuan()
        ElseIf e.KeyCode = Keys.F2 And jasa Then
            editDataSatuan()
        ElseIf e.KeyCode = Keys.Delete And jasa Then
            hpsDataSatuan()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBPajak.KeyDown, TBRak.KeyDown, TBNama.KeyDown, TBKode.KeyDown, solded.KeyDown, notsolded.KeyDown,
                MyBase.KeyDown, cbMerk.KeyDown, cbJenis.KeyDown, Button13.KeyDown, Button11.KeyDown, TabPage1.KeyDown
        If e.KeyCode = Keys.F11 And jasa Then
            simpanDataBarang()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
    End Sub


    Private Sub TBPajak_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBPajak.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        simpanDataBarang()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        closeTab()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        FormDatagridKategori.status = True
        FormDatagridKategori.ShowDialog()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        FormDatagridMerk.status = True
        FormDatagridMerk.ShowDialog()
    End Sub

    Private Sub stokMin_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles stokMin.KeyPress, edtBagiHasil.KeyPress, edtHargaJasa.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        closeTab()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        simpanDataJasa()
    End Sub
End Class