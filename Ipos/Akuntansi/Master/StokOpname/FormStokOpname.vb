Public Class FormStokOpname
    Dim onEditCurrency As Boolean = False
    Dim kodeproduk As String = ""
    Dim onLoaded As Boolean = False
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
            Me.ActiveControl = eCari

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub

    Private Sub DGStokOpname_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setGudang()
        focusData()
        addhandlertoAllComponent()
        onLoaded = True
    End Sub

    Sub editCurrency(tb As TextBox)
        If Not onEditCurrency Then
            onEditCurrency = True
            tb.Text = numberFormat(tb.Text)
            tb.SelectionStart = tb.Text.Count
            tb.SelectionLength = 0
            onEditCurrency = False
        End If
    End Sub



    Sub setGudang()
        cbGudang.DataSource = getData("SELECT idgudang, gudang from tblgudang")
        cbGudang.DisplayMember = "gudang"
        cbGudang.ValueMember = "idgudang"
        cbGudang.SelectedIndex = 0
    End Sub


    Sub initForm()

        'isi Akun biaya lain
        cbAkun.DataSource = getData("select kodeakun,akun from tblakun")
        cbAkun.DisplayMember = "akun"
        cbAkun.ValueMember = "kodeakun"
        cbAkun.SelectedIndex = 0



        'isi Departemen
        cbDepartemen.DataSource = getData("select iddepartemen, departemen from tbldepartemen")
        cbDepartemen.DisplayMember = "departemen"
        cbDepartemen.ValueMember = "iddepartemen"
        cbDepartemen.SelectedIndex = 0


        'isi akun penerimaan

        jumlahBuku.Text = "0"
        hpp.Text = "0"
        jumlahFisik.Text = "0"
    End Sub


    Sub fillData()

        Dim sqlStok As String = "SELECT  tblproduk.idproduk,tblproduk.produk, COALESCE(tblstokgudang.stok,0) as stok, tblsatuan.satuan, tblharga.idharga, hpp from tblharga 
            inner join tblproduk on tblproduk.idproduk = tblharga.idbarang
            inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan
            left join tblstokgudang on tblstokgudang.idharga = tblharga.idharga and tblstokgudang.idgudang ='" & cbGudang.SelectedValue & "'
            where produk ilike '%" & eCari.Text & "%' and idproduk ilike '%" & eCari.Text & "%'"
        Dim dt As DataTable = getData(sqlStok)

        Dim dataview As DataView = dt.AsDataView

        ListSat.DataSource = dataview

        Try
            ListSat.Columns(0).HeaderText = "Kode Produk"
            ListSat.Columns(1).HeaderText = "Produk"
            ListSat.Columns(2).HeaderText = "Stok"
            ListSat.Columns(3).HeaderText = "Satuan"
            ListSat.Columns(4).Visible = False
            ListSat.Columns(5).HeaderText = "HPP"
            ListSat.Columns(5).DefaultCellStyle.Format = "n0"
        Catch ex As Exception
        End Try
        styliseDG(ListSat)
        makeFillDG(ListSat)
    End Sub


    Sub focusData()
        kodeproduk = ""
        gbData.Enabled = True
        gbForm.Enabled = False
        fillData()
        initForm()

    End Sub

    Sub focusForm()
        gbData.Enabled = False
        gbForm.Enabled = True
        initForm()
    End Sub


    Private Sub tbBayar_TextChanged(sender As Object, e As EventArgs) Handles hpp.TextChanged
        editCurrency(sender)
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs)
        fillData()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        focusData()
    End Sub



    Private Sub btnKeluar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dialog As New DialogAkun
        If dialog.ShowDialog = DialogResult.OK Then
            cbAkun.SelectedValue = dialog.idakun
        End If
        dialog.Dispose()
    End Sub


    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = ListSat.Rows(e.RowIndex)
            kodeproduk = row.Cells(4).Value
            focusForm()
            jumlahBuku.Text = (row.Cells(2).Value)
            hpp.Text = numberFormat(row.Cells(5).Value)

        End If
    End Sub



    Sub simpanData()

        Dim jumlahBayar As String = unnumberFormat(jumlahFisik.Text)
        Dim tglbayar As String = dtTanggal.Value.ToString("yyyy-MM-dd")

        Dim akunPenerimaan As String = cbAkun.SelectedValue

        If Not Double.TryParse(jumlahFisik.Text, 0) Then
            dialogError("Masukkan jumlah dengan benar")
            Return

        End If



        Dim selisih As Double = toDouble(jumlahBuku.Text.Replace(",", ".")) - toDouble(jumlahFisik.Text.Replace(",", "."))

        Dim subHPP As Double = selisih * toDouble(unnumberFormat(hpp.Text))

        Dim akunPersediaan As String = "110004"
        Dim sqlinsert As String = "INSERT INTO public.tblstokopname(
	kodestokopname, kodegudang, tglstokopname, kodeakun, idharga, kodedepartemen, buku, fisik)
	VALUES (?, ?, ?, ?, ?, ?, ?, ?);"

        Dim kode As String = generateRefrence("ST")
        Dim dataInsert As String() = {kode, cbGudang.SelectedValue, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), akunPenerimaan, kodeproduk, cbDepartemen.SelectedValue, jumlahFisik.Text.ToString.Replace(",", "."), jumlahBuku.Text.ToString.Replace(",", ".")}
        If operationQuery(sqlinsert, dataInsert) Then
            If selisih < 0 Then
                subHPP = subHPP * -1
                Dim sqlJurnal As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);"
                Dim dataDebit As String() = {cbAkun.SelectedValue, "NULL", cbDepartemen.SelectedValue, "NULL", dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), subHPP.ToString.Replace(",", "."), "0", "ST", kode, "Stok Opname, " & cbDepartemen.Text}
                Dim dataKredit As String() = {akunPersediaan, "NULL", cbDepartemen.SelectedValue, "NULL", dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", subHPP.ToString.Replace(",", "."), "ST", kode, "Stok Opname, " & cbDepartemen.Text}

                operationQuery(sqlJurnal, dataDebit)
                operationQuery(sqlJurnal, dataKredit)

                Dim sqlHistoriStok As String = "INSERT INTO public.tblhistoristok(masuk, keluar, harga, tglhistori, idharga, refrensi, hpp) VALUES ( ?, ?, ?, ?, ?, ?, ?);"
                Dim dataHistori As String() = {"0", selisih.ToString.Replace(",", "."), unnumberFormat(hpp.Text), dtTanggal.Value.ToString("yyyy-MM-dd"), kodeproduk, kode, hpp.ToString.Replace(",", ".")}

                operationQuery(sqlHistoriStok, dataHistori)
            Else
                Dim sqlJurnal As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);"
                Dim dataDebit As String() = {akunPersediaan, "NULL", cbDepartemen.SelectedValue, "NULL", dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), subHPP.ToString.Replace(",", "."), "0", "ST", kode, "Stok Opname, " & cbDepartemen.Text}
                Dim dataKredit As String() = {cbAkun.SelectedValue, "NULL", cbDepartemen.SelectedValue, "NULL", dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", subHPP.ToString.Replace(",", "."), "ST", kode, "Stok Opname, " & cbDepartemen.Text}

                operationQuery(sqlJurnal, dataDebit)
                operationQuery(sqlJurnal, dataKredit)

                Dim sqlHistoriStok As String = "INSERT INTO public.tblhistoristok(masuk, keluar, harga, tglhistori, idharga, refrensi, hpp) VALUES ( ?, ?, ?, ?, ?, ?, ?);"
                Dim dataHistori As String() = {selisih.ToString.Replace(",", "."), "0", unnumberFormat(hpp.Text), dtTanggal.Value.ToString("yyyy-MM-dd"), kodeproduk, kode, hpp.ToString.Replace(",", ".")}

                operationQuery(sqlHistoriStok, dataHistori)
            End If

            exc("INSERT INTO public.tblstokgudang(idgudang, stok, idharga) VALUES ( '" & cbGudang.SelectedValue & "', " & jumlahFisik.Text.ToString().Replace(",", ".") & " ," & kodeproduk & ") ON CONFLICT  (idgudang,idharga) DO UPDATE  set stok =  EXCLUDED.stok")
            dialogSukses("Berhasil")
            focusData()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        If dialog("Apakah anda yakin untuk menyimpan stok opname ini ?") Then
            simpanData()
        End If
    End Sub

    Private Sub hppKeyPress(sender As Object, e As KeyPressEventArgs) Handles  hpp.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub jumlahKeyPRess(sender As Object, e As KeyPressEventArgs) Handles jumlahFisik.KeyPress
        onlyNumberWithComma(e)
    End Sub

    Private Sub cbGudang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGudang.SelectedIndexChanged
        If onLoaded Then
            fillData()
        End If

    End Sub
End Class