Public Class FormBarang
    Dim idselected As String = ""
    Public idproduk As String = ""
    Private Sub FormBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub


    Sub setPajak()
        Dim datapajak As DataTable = getData("select kodepajak , pajak from tblpajak")
        cbPajakBeli.DataSource = datapajak
        cbPajakBeli.ValueMember = "kodepajak"
        cbPajakBeli.DisplayMember = "pajak"
        cbPajakJual.DataSource = datapajak.Copy()
        cbPajakJual.ValueMember = "kodepajak"
        cbPajakJual.DisplayMember = "pajak"
        cbPajakBeli.SelectedIndex = 0
        cbPajakJual.SelectedIndex = 0
    End Sub

    Sub awal()
        addHadlerKeydown()
        getJenis()

        solded.Checked = True
        TabControl1.SelectedIndex = 0
        styliseDG(DataGridView1)
        clearForm(gbFormBarang)
        stokMin.Text = "0"
        getSatuan()
        setPajak()
        If String.IsNullOrEmpty(idproduk) Then
            exclocal("delete from temp_satuan where not idtempsatuan='0'")
            getDataSatuanLocal()
        Else
            setSelectedBarang()
            getDataSatuanOnline()
        End If
        Me.ActiveControl = TBKode
        TBKode.Focus()
        dataFocus()

    End Sub

    Sub dataFocus()
        satuanBefore.Text = ""
        clearForm(gbFormSatuan)
        idselected = ""
        DataGridView1.Enabled = True
        panelAction.Enabled = True
        gbFormSatuan.Enabled = False
    End Sub

    Sub formFocus()
        DataGridView1.Enabled = False
        panelAction.Enabled = False
        gbFormSatuan.Enabled = True

    End Sub


    Sub setSelectedBarang()
        Dim sqlbarang = "SELECT idproduk, produk, idkategori, stokmin, pajakjual, pajakbeli, statusproduk from tblproduk where idproduk = '" & idproduk & "'"
        TBKode.Text = getValue(sqlbarang, "idproduk")
        TBNama.Text = getValue(sqlbarang, "produk")
        cbJenis.SelectedValue = getValue(sqlbarang, "idkategori")
        cbPajakBeli.SelectedValue = getValue(sqlbarang, "pajakbeli")
        cbPajakJual.SelectedValue = getValue(sqlbarang, "pajakjual")
        If getValue(sqlbarang, "statusproduk").ToString() = "1" Then
            solded.Checked = True
        Else
            notsolded.Checked = True
        End If
    End Sub

    Sub getJenis()
        cbJenis.DataSource = getData("SELECT idkategori, kategori FROM tblkategori order by kategori")
        cbJenis.ValueMember = "idkategori"
        cbJenis.DisplayMember = "kategori"
        cbJenis.DropDownStyle = ComboBoxStyle.DropDown
        cbJenis.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbJenis.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Sub getSatuan()
        cbSatuan.DataSource = getData("SELECT kodesatuan, satuan FROM tblsatuan order by satuan")
        cbSatuan.ValueMember = "kodesatuan"
        cbSatuan.DisplayMember = "satuan"
        cbSatuan.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub CBJENIS_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbJenis.Validating
        If cbJenis.SelectedValue Is Nothing AndAlso cbJenis.Text <> String.Empty Then
            cbJenis.SelectedIndex = 0
        End If
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



    Sub getDataSatuanLocal()
        DataGridView1.DataSource = getLocalData("Select idtempsatuan, idsatuan, satuan, jenis, konversi, hargabeli, hargajual from temp_satuan")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).HeaderText = "Satuan"
        DataGridView1.Columns(3).HeaderText = "Jenis"
        DataGridView1.Columns(4).HeaderText = "Konversi"
        DataGridView1.Columns(5).HeaderText = "Harga Beli"
        DataGridView1.Columns(6).HeaderText = "Harga Jual"
        DataGridView1.Columns(5).DefaultCellStyle.Format = "C2"
        DataGridView1.Columns(6).DefaultCellStyle.Format = "C2"
        DataGridView1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If DataGridView1.Rows.Count = 3 Then
            buttonTambah.Enabled = False
        Else
            buttonTambah.Enabled = True
        End If
    End Sub

    Sub getDataSatuanOnline()
        Dim dt As DataTable = getData("SELECT idharga, idsatuan,satuan,cast(""level"" as VARCHAR),konversi, hargabeli,hargajual from tblharga inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan where idbarang ='" & idproduk & "' order by level")
        For Each row As DataRow In dt.Rows
            If row.Item(3).ToString() = "1" Then
                row.Item(3) = "Nilai Dasar"
            ElseIf row.Item(3).ToString() = "2" Then
                row.Item(3) = "Konversi 1"
            Else
                row.Item(3) = "Konversi 2"
            End If
        Next
        DataGridView1.DataSource = dt
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).HeaderText = "Satuan"
        DataGridView1.Columns(3).HeaderText = "Jenis"
        DataGridView1.Columns(4).HeaderText = "Konversi"
        DataGridView1.Columns(5).HeaderText = "Harga Beli"
        DataGridView1.Columns(6).HeaderText = "Harga Jual"
        DataGridView1.Columns(5).DefaultCellStyle.Format = "C2"
        DataGridView1.Columns(6).DefaultCellStyle.Format = "C2"
        DataGridView1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If DataGridView1.Rows.Count = 3 Then
            buttonTambah.Enabled = False
        Else
            buttonTambah.Enabled = True
        End If
    End Sub


    Sub tambahDataSatuan()
        If DataGridView1.Rows.Count = 3 Then
            buttonTambah.Enabled = False
        Else
            idselected = ""
            clearForm(gbFormSatuan)
            buttonTambah.Enabled = True
            getSatuan()
            formFocus()
            If String.IsNullOrEmpty(idproduk) Then
                Dim idtemp = (getLocalCount("select idtempsatuan from temp_satuan") + 1).ToString
                If idtemp = "1" Then
                    TBJenis.Text = "Dasar"
                    tbKonversi.Text = "1"
                    satuanBefore.Visible = False
                    tbKonversi.Enabled = False
                ElseIf idtemp = "2" Then
                    TBJenis.Text = "Konversi 1"
                    tbKonversi.Text = "1"
                    satuanBefore.Text = getLocalValue("select satuan from temp_satuan order by idtempsatuan desc", "satuan")
                    satuanBefore.Visible = True
                    tbKonversi.Enabled = True
                Else
                    TBJenis.Text = "Konversi 2"
                    satuanBefore.Text = getLocalValue("select satuan from temp_satuan order by idtempsatuan desc", "satuan")
                    tbKonversi.Text = "1"
                    tbKonversi.Enabled = True
                End If
            Else
                Dim idtemp = (getCount("SELECT idharga from tblharga WHERE idbarang = '" & idproduk & "'") + 1).ToString

                If idtemp = "1" Then
                    TBJenis.Text = "Dasar"
                    tbKonversi.Text = "1"
                    satuanBefore.Visible = False
                    tbKonversi.Enabled = False
                ElseIf idtemp = "2" Then
                    TBJenis.Text = "Konversi 1"
                    tbKonversi.Text = "1"
                    satuanBefore.Text = getValue("SELECT satuan from tblharga inner join tblsatuan on tblharga.idsatuan = tblsatuan.kodesatuan where idbarang = '" & idproduk & "' order by level DESC", "satuan")
                    satuanBefore.Visible = True
                    tbKonversi.Enabled = True
                Else
                    TBJenis.Text = "Konversi 2"
                    satuanBefore.Text = getValue("SELECT satuan from tblharga inner join tblsatuan on tblharga.idsatuan = tblsatuan.kodesatuan where idbarang = '" & idproduk & "' order by level DESC", "satuan")
                    tbKonversi.Text = "1"
                    tbKonversi.Enabled = True
                End If
            End If

        End If

    End Sub

    Sub editDataSatuan()
        If String.IsNullOrEmpty(idselected) Then
            dialogError("Pilih Item terlebih dahulu")
        Else
            If TBJenis.Text = "Nilai Dasar" Then
                tbKonversi.Enabled = False
            Else
                tbKonversi.Enabled = True
            End If
            formFocus()
        End If

    End Sub

    Sub hpsDataSatuan()
        If String.IsNullOrEmpty(idselected) Then
            dialogError("Pilih Item terlebih dahulu")
        ElseIf Not DataGridView1.CurrentRow.Index = DataGridView1.Rows.Count - 1 Then
            dialogError("Harus hapus dari bawah")
        Else
            If String.IsNullOrEmpty(idproduk) Then
                exclocal("delete from temp_satuan where idtempsatuan='" & idselected & "'")
            Else
                exc("delete from tblharga where idharga =" & idselected)
            End If

            dataFocus()
            getDataSatuanLocal()

        End If

    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Sub tambahDetailSatuanLocal()
        Dim idtempsatuan = (getLocalCount("select satuan from temp_satuan") + 1).ToString
        Dim namasatuan = cbSatuan.Text
        Dim jenis = TBJenis.Text
        Dim konversi = tbKonversi.Text
        Dim hargabeli = TBBeli.Text.Replace(",", ".").Replace(".", "")
        Dim hargajual = TBJual.Text.Replace(",", ".").Replace(".", "")
        Dim isidata As String() = New String() {idtempsatuan, cbSatuan.SelectedValue.ToString, namasatuan, jenis, konversi, hargabeli, hargajual}
        Dim sql As String = "INSERT INTO temp_satuan VALUES (?,?,?,?,?,?,?)"
        If exclocal(QueryModule.operationQueryString(sql, isidata)) Then
            getDataSatuanLocal()
            dataFocus()

        End If
    End Sub

    Sub editDetailSatuanLocal()
        Dim namasatuan = cbSatuan.Text
        Dim jenis = TBJenis.Text
        Dim konversi = tbKonversi.Text
        Dim hargabeli = TBBeli.Text.Replace(",", ".").Replace(".", "")
        Dim hargajual = TBJual.Text.Replace(",", ".").Replace(".", "")
        Dim isidata As String() = New String() {cbSatuan.SelectedValue.ToString, namasatuan, jenis, konversi, hargabeli, hargajual, idselected}
        Dim sql As String = "UPDATE temp_satuan set idsatuan= ?, satuan=?, jenis= ?, konversi = ?, hargabeli = ?, hargajual= ? where idtempsatuan= ?"
        If exclocal(QueryModule.operationQueryString(sql, isidata)) Then
            getDataSatuanLocal()
            dataFocus()

        End If
    End Sub

    Sub tambahDetailSatuanOnline()
        Dim jenis = TBJenis.Text
        Dim nilaidasar As Double
        Dim level As String
        If TBJenis.Text = "Konversi 1" Then
            level = "2"
            nilaidasar = toDouble(tbKonversi.Text)
        ElseIf TBJenis.Text = "Konversi 2" Then
            level = "3"
            nilaidasar = toDouble(getValue("select konversi from tblharga where idbarang='" & idproduk & "' and level = 2", "konversi")) * toDouble(tbKonversi.Text)
        Else
            level = "1"
            nilaidasar = 1
        End If
        Dim konversi = tbKonversi.Text
        Dim hargabeli = TBBeli.Text.Replace(",", ".").Replace(".", "")
        Dim hargajual = TBJual.Text.Replace(",", ".").Replace(".", "")
        Dim isidata As String() = New String() {hargajual, hargabeli, idproduk, hargabeli, cbSatuan.SelectedValue, level, konversi, nilaidasar.ToString}
        Dim sql As String = "INSERT INTO public.tblharga(hargajual, hpp, idbarang, hargabeli, idsatuan, level, konversi, nilaidasar) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?);"
        If exc(QueryModule.operationQueryString(sql, isidata)) Then
            getDataSatuanOnline()
            dataFocus()
        End If
    End Sub

    Sub editDetailSatuanOnline()

        Dim jenis = TBJenis.Text
        Dim nilaidasar As Double
        If TBJenis.Text = "Konversi 1" Then
            nilaidasar = toDouble(tbKonversi.Text)
            Dim nilai3 As Double = toDouble(getValue("select konversi from tblharga where idbarang='" & idproduk & "' and level = 3", "konversi")) * toDouble(tbKonversi.Text)
            exc("update tblharga set nilaidasar = " & nilai3.ToString & " where idbarang ='" & idproduk & "' and level =3")

        ElseIf TBJenis.Text = "Konversi 2" Then
            nilaidasar = toDouble(getValue("select konversi from tblharga where idbarang='" & idproduk & "' and level = 2", "konversi")) * toDouble(tbKonversi.Text)
        Else
            nilaidasar = 1
        End If
        Dim konversi = tbKonversi.Text
        Dim hargabeli = TBBeli.Text.Replace(",", ".").Replace(".", "")
        Dim hargajual = TBJual.Text.Replace(",", ".").Replace(".", "")
        Dim isidata As String() = New String() {cbSatuan.SelectedValue.ToString, hargajual, hargabeli, konversi, nilaidasar.ToString, idselected}
        Dim sql As String = "UPDATE public.tblharga
	SET idsatuan=?, hargajual=?, hargabeli=?, konversi=?, nilaidasar=? where idharga=?"
        If exc(QueryModule.operationQueryString(sql, isidata)) Then
            getDataSatuanOnline()
            dataFocus()
        End If
    End Sub



    Sub simpanDetailSatuan()
        Dim idsatuan = cbSatuan.SelectedValue.ToString
        Dim sqlcheck As String
        If String.IsNullOrEmpty(idproduk) Then

            If String.IsNullOrEmpty(idselected) Then
                sqlcheck = "SELECT satuan FROM temp_satuan WHERE idsatuan='" & idsatuan & "'"
            Else
                sqlcheck = "SELECT satuan FROM temp_satuan WHERE idsatuan='" & idsatuan & "' AND idtempsatuan != '" & idselected & "'"
            End If
            If getLocalCount(sqlcheck) > 0 Then
                dialogError("Satuan telah dipakai")
                Return
            End If

        Else
            If String.IsNullOrEmpty(idselected) Then
                sqlcheck = "SELECT idsatuan from tblharga where idsatuan=" & idsatuan & " AND idbarang='" & idproduk & "'"
            Else
                sqlcheck = "SELECT idsatuan from tblharga where idsatuan=" & idsatuan & " AND idbarang='" & idproduk & "' " & " AND idharga !=" & idselected
            End If
            Debug.WriteLine(sqlcheck)
            If getCount(sqlcheck) > 0 Then
                dialogError("Satuan telah dipakai")
                Return
            End If
        End If



        If adaKosong(gbFormSatuan) Then
            dialogError("Terdapat form masih kosong")

        ElseIf Not Double.TryParse(tbKonversi.Text, 0) Then
            dialogError("Masukkan jumlah konversi dengan benar")
        Else
            If String.IsNullOrEmpty(idproduk) Then
                If String.IsNullOrEmpty(idselected) Then
                    tambahDetailSatuanLocal()
                Else
                    editDetailSatuanLocal()
                End If
            Else
                If String.IsNullOrEmpty(idselected) Then
                    tambahDetailSatuanOnline()
                Else
                    editDetailSatuanOnline()
                End If
            End If

        End If
    End Sub

    Sub simpanDataSatuan()
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim kodebarang = TBKode.Text
            Dim idsatuan = row.Cells(1).Value.ToString
            Dim hargajual = row.Cells(6).Value.ToString
            Dim hargabeli = row.Cells(5).Value.ToString
            Dim konversi = row.Cells(4).Value.ToString
            Dim tipedata = row.Index + 1
            Dim jenis = row.Cells(3).Value.ToString
            Dim nilaidasar As Double
            Dim level As String
            If jenis = "Konversi 1" Then
                nilaidasar = toDouble(konversi)
                level = "2"
            ElseIf jenis = "Konversi 2" Then
                nilaidasar = toDouble(konversi) * toDouble(DataGridView1.Rows(1).Cells(4).Value)
                level = "3"
            Else
                level = "1"
                nilaidasar = 1
            End If
            Dim isidata As String() = New String() {hargajual, hargabeli, TBKode.Text, hargabeli, cbSatuan.SelectedValue, level, konversi, nilaidasar.ToString}
            Dim sql As String = "INSERT INTO public.tblharga(hargajual, hpp, idbarang, hargabeli, idsatuan, level, konversi, nilaidasar) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?);"
            operationQuery(sql, isidata)
        Next
    End Sub

    Sub simpanDataBarang()

        If DataGridView1.Rows.Count = 0 Or adaKosong(gbFormBarang) Then
            dialogError("Ada form kosong")
            Return
        End If

        If String.IsNullOrEmpty(idproduk) Then
            simpanBarang()
        Else
            updateBarang()
        End If
    End Sub

    Sub updateBarang()
        Dim sqlupdate As String = "UPDATE public.tblproduk
	SET idproduk=?, produk=?, idkategori=?, stokmin=?, pajakjual=?, pajakbeli=?, statusproduk=? where idproduk=?"
        Dim stokMinimal As String = toDouble(stokMin.Text).ToString
        Dim statusbarang As String = "0"
        If solded.Checked Then
            statusbarang = "1"
        End If
        Dim data As String() = {TBKode.Text, TBNama.Text, cbJenis.SelectedValue, stokMinimal, cbPajakJual.SelectedValue, cbPajakBeli.SelectedValue, statusbarang, idproduk}
        If operationQuery(sqlupdate, data) Then

            Me.DialogResult = DialogResult.OK
            closeTab()
        Else
            dialogError("Kode produk telah dipakai")
        End If
    End Sub

    Sub simpanBarang()

        Dim sqlinsert As String = "INSERT INTO public.tblproduk(
	idproduk, produk, idkategori, stokmin, pajakjual, pajakbeli, statusproduk)
	VALUES (?, ?, ?, ?, ?, ?, ?);"
        Dim stokMinimal As String = toDouble(stokMin.Text).ToString
        Dim statusbarang As String = "0"
        If solded.Checked Then
            statusbarang = "1"
        End If
        Dim data As String() = {TBKode.Text, TBNama.Text, cbJenis.SelectedValue, stokMinimal, cbPajakJual.SelectedValue, cbPajakBeli.SelectedValue, statusbarang}
        If operationQuery(sqlinsert, data) Then
            simpanDataSatuan()
            Me.DialogResult = DialogResult.OK
            closeTab()
        Else
            dialogError("Kode produk telah dipakai")
        End If
    End Sub

    Sub addHadlerKeydown()
        For Each control As Control In Me.Controls
            AddHandler control.KeyDown, AddressOf keyDownEvent
            If control.Controls.Count > 0 Then
                For Each control2 As Control In Me.Controls
                    AddHandler control2.KeyDown, AddressOf keyDownEvent
                Next
            End If
        Next
    End Sub


    Private Sub keyDownEvent(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F11 Then
            simpanDataBarang()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
        If e.KeyCode = Keys.F1 Then
            tambahDataSatuan()
        ElseIf e.KeyCode = Keys.F2 Then
            editDataSatuan()
        ElseIf e.KeyCode = Keys.Delete Then
            hpsDataSatuan()
        End If
    End Sub






    Private Sub FormBarang_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If String.IsNullOrEmpty(idproduk) And Not Me.DialogResult = DialogResult.OK Then
            If Not String.IsNullOrWhiteSpace(TBKode.Text) Or Not String.IsNullOrWhiteSpace(TBNama.Text) Then
                If Not dialog("Apakah anda yakin ingin keluar dari form input data barang") Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub stokMin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles stokMin.KeyPress
        onlyNumber(e)
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            getSatuan()
            idselected = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            cbSatuan.SelectedValue = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TBJenis.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            tbKonversi.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            TBBeli.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            TBJual.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
            If e.RowIndex > 0 Then
                tbKonversi.Enabled = False
                satuanBefore.Text = DataGridView1.Rows(e.RowIndex - 1).Cells(2).Value
            Else
                tbKonversi.Enabled = True
                satuanBefore.Text = ""
            End If
        End If
    End Sub

    Private Sub buttonTambah_Click(sender As Object, e As EventArgs) Handles buttonTambah.Click
        tambahDataSatuan()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        editDataSatuan()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        hpsDataSatuan()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanDetailSatuan()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        dataFocus()
    End Sub

    Private Sub btnSelesai_Click(sender As Object, e As EventArgs) Handles btnSelesai.Click
        simpanDataBarang()
    End Sub


    Private Sub tbKonversi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbKonversi.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub TBBeli_HandleCreated(sender As Object, e As EventArgs) Handles TBBeli.HandleCreated
        TBBeli.Text = numberFormat(TBBeli.Text.ToString)
    End Sub
    Dim checkBeli As Boolean = True
    Private Sub TBBeli_TextChanged(sender As Object, e As EventArgs) Handles TBBeli.TextChanged
        If checkBeli Then
            checkBeli = False
            TBBeli.Text = numberFormat(unnumberFormat(TBBeli.Text))
            TBBeli.SelectionStart = TBBeli.Text.Count
            TBBeli.SelectionLength = 0
            checkBeli = True
        End If
    End Sub

    Private Sub TBJual_HandleCreated(sender As Object, e As EventArgs) Handles TBJual.HandleCreated
        TBJual.Text = numberFormat(TBJual.Text.ToString)
    End Sub
    Dim checkJual As Boolean = True
    Private Sub TBJual_TextChanged(sender As Object, e As EventArgs) Handles TBJual.TextChanged
        If checkJual Then
            checkJual = False
            TBJual.Text = numberFormat(unnumberFormat(TBJual.Text))
            TBJual.SelectionStart = TBJual.Text.Count
            TBJual.SelectionLength = 0
            checkJual = True
        End If
    End Sub

End Class

