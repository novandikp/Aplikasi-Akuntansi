Public Class DaftarKreditDebit
    Public debit As Boolean = False
    Public edited As Boolean = False
    Public kodeTransaksi As String = ""
    Dim onEditCurrency As Boolean = False
    Sub editCurrency(tb As TextBox)
        If Not onEditCurrency Then
            onEditCurrency = True
            tb.Text = numberFormat(tb.Text)
            tb.SelectionStart = tb.Text.Count
            tb.SelectionLength = 0
            onEditCurrency = False
        End If
    End Sub

    Private Sub DaftarKreditDebit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        focusData()
        addhandlertoAllComponent()
        If debit Then
            Me.Text = "Form Penerimaan"
        Else
            Me.Text = "Form Pengeluaran"
        End If
    End Sub

    Sub addhandlertoAllComponent()
        For Each komponen As Control In Me.Controls
            AddHandler komponen.KeyDown, AddressOf handlerAllComponent
            If komponen.Controls.Count > 0 Then
                For Each komponen2 As Control In komponen.Controls
                    AddHandler komponen2.KeyDown, AddressOf handlerAllComponent
                    If komponen2.Controls.Count > 0 Then
                        For Each komponen3 As Control In komponen2.Controls
                            AddHandler komponen3.KeyDown, AddressOf handlerAllComponent
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub handlerAllComponent(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            tambahData()
        ElseIf e.KeyCode = Keys.F2 Then
            editData()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusData()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub

    Sub focusData()
        gbData.Enabled = True
        gbForm.Enabled = False
        panelAksi.Enabled = True
        initForm()
        edited = False
        fillData()
    End Sub

    Sub focusForm()
        gbData.Enabled = False
        gbForm.Enabled = True
        panelAksi.Enabled = False

    End Sub


    Sub cariKontak()
        Dim dialogKontak As New DialogKontak
        If dialogKontak.ShowDialog = DialogResult.OK Then
            cbKontak.SelectedValue = dialogKontak.idpelanggan
        End If
        dialogKontak.Dispose()
    End Sub


    Sub cariAkunAsal()
        Dim dialogAkun As New DialogAkun
        If dialogAkun.ShowDialog = DialogResult.OK Then
            cbAkunAsal.SelectedValue = dialogAkun.idakun
        End If
        dialogAkun.Dispose()
    End Sub

    Sub cariAkunTujuan()
        Dim dialogAkun As New DialogAkun
        If dialogAkun.ShowDialog = DialogResult.OK Then
            cbAkunTujuan.SelectedValue = dialogAkun.idakun
        End If
        dialogAkun.Dispose()
    End Sub

    Sub initForm()
        edited = False
        setKontak()
        setDepartemen()
        setProjek()
        setAsalAkun()
        setTujuanAkun()
        Dim tipe As String = ""
        tbBayar.Text = "0"
        If debit Then
            tipe = "CD"
        Else
            tipe = "CK"
        End If
        Dim lastid As String
        If getCount("select kodetransaksi from tbltransaksi where tipetransaksi='" & tipe & "' order by kodetransaksi desc LIMIT 1") > 0 Then
            lastid = getValue("select kodetransaksi from tbltransaksi where tipetransaksi='" & tipe & "' order by kodetransaksi desc LIMIT 1", "kodetransaksi")
            lastid = Strings.Right(lastid, lastid.Length - 2)
        Else
            lastid = "0"
        End If
        Dim jumlahData As Integer = toInteger(lastid) + 1
        Dim refrensi As String = tipe + "0000000"
        kodeTransaksi = Strings.Left(refrensi, refrensi.Length - jumlahData.ToString.Length) & jumlahData.ToString
    End Sub

    Sub setKontak(Optional idpelanggan As String = Nothing)
        Dim sql = "SELECT idpelanggan,pelanggan from tblkontak"
        cbKontak.DataSource = getData(sql)
        cbKontak.DisplayMember = "pelanggan"
        cbKontak.ValueMember = "idpelanggan"
        If IsNothing(idpelanggan) Then
            cbKontak.SelectedIndex = 0
        Else
            cbKontak.SelectedValue = idpelanggan
        End If
    End Sub


    Sub setDepartemen(Optional iddepartemen As String = Nothing)
        Dim sql = "SELECT iddepartemen,departemen from tbldepartemen"
        cbDepartemen.DataSource = getData(sql)
        cbDepartemen.DisplayMember = "departemen"
        cbDepartemen.ValueMember = "iddepartemen"
        If IsNothing(iddepartemen) Then
            cbDepartemen.SelectedIndex = 0
        Else
            cbDepartemen.SelectedValue = iddepartemen
        End If
    End Sub

    Sub setProjek(Optional idprojek As String = Nothing)
        Dim sql = "SELECT idprojek,projek from tblprojek"
        cbProjek.DataSource = getData(sql)
        cbProjek.DisplayMember = "projek"
        cbProjek.ValueMember = "idprojek"
        If IsNothing(idprojek) Then
            cbProjek.SelectedIndex = -1
        Else
            cbProjek.SelectedValue = idprojek
        End If
    End Sub

    Sub setAsalAkun(Optional kodeakun As String = Nothing)
        Dim sql = "SELECT kodeakun,akun from tblakun"
        cbAkunAsal.DataSource = getData(sql)
        cbAkunAsal.DisplayMember = "akun"
        cbAkunAsal.ValueMember = "kodeakun"
        If IsNothing(kodeakun) Then
            cbAkunAsal.SelectedIndex = 0
        Else
            cbAkunAsal.SelectedValue = kodeakun
        End If
    End Sub

    Sub setTujuanAkun(Optional kodeakun As String = Nothing)
        Dim sql = "SELECT kodeakun,akun from tblakun"
        cbAkunTujuan.DataSource = getData(sql)
        cbAkunTujuan.DisplayMember = "akun"
        cbAkunTujuan.ValueMember = "kodeakun"
        If IsNothing(kodeakun) Then
            cbAkunTujuan.SelectedIndex = 0
        Else
            cbAkunTujuan.SelectedValue = kodeakun
        End If
    End Sub


    Sub fillData()
        Dim sql As String = "SELECT kodetransaksi, T.akun as asalakun, B.akun as tujuanakun,  tgltransaksi, jumlah,pelanggan from tbltransaksi
        inner join tblakun T on T.kodeakun = tbltransaksi.akunasal 
        inner join tblakun B on B.kodeakun = tbltransaksi.akuntujuan 
        inner join tblkontak on tblkontak.idpelanggan = tbltransaksi.kontak 
        where (kodetransaksi ilike '%" & eCari.Text & "%' OR pelanggan ilike '%" & eCari.Text & "%') 
        and tgltransaksi between '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'"
        If debit Then
            ListSat.DataSource = getData(sql & " AND tipetransaksi='CD'")
        Else
            ListSat.DataSource = getData(sql & " AND tipetransaksi='CK'")
        End If

        styliseDG(ListSat)
        ListSat.Columns(0).HeaderText = "Kode Transaksi"
        ListSat.Columns(1).HeaderText = "Akun Asal"
        ListSat.Columns(2).HeaderText = "Akun Tujuan"
        ListSat.Columns(3).HeaderText = "Tanggal Transaksi"
        ListSat.Columns(4).HeaderText = "Jumlah"
        ListSat.Columns(5).HeaderText = "Kontak"
        ListSat.Columns(4).DefaultCellStyle.Format = "c0"
    End Sub

    Private Sub btn_ClickCariAsalAkun(sender As Object, e As EventArgs) Handles Button4.Click
        cariAkunAsal()
    End Sub

    Private Sub btn_ClickCariTujuanAkun(sender As Object, e As EventArgs) Handles Button2.Click
        cariAkunTujuan()
    End Sub

    Private Sub btn_clickCariKontak(sender As Object, e As EventArgs) Handles Button3.Click
        cariKontak()
    End Sub


    Sub tambahData()
        initForm()
        focusForm()

    End Sub

    Sub editData()
        If edited Then
            focusForm()
        Else
            dialogError("Harap Pilih Item terlebih dahulu")
        End If

    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        focusData()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusData()
    End Sub

    Sub hapusData()
        If edited Then
            Dim idselectedRows As String = kodeTransaksi
            If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                If exc("delete from tbltransaksi where kodetransaksi = '" & idselectedRows & "'") Then
                    focusData()
                Else
                    dialogError("Data Sedang dipakai tidak bisa dihapus")
                End If
            End If
        Else
            dialogError("Harap Pilih Item terlebih dahulu")
        End If
    End Sub

    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = ListSat.Rows(e.RowIndex)
            Dim idtransaksi As String = row.Cells(0).Value.ToString
            Dim sqlSelectedData As String = "SELECT akunasal, kontak, deskripsitransaksi, tipetransaksi,
            kodetransaksi, tgltransaksi, akuntujuan, kodedepartemen, kodeprojek, jumlah from tbltransaksi where kodetransaksi='" & idtransaksi & "'"
            dtpBayar.Value = getValue(sqlSelectedData, "tgltransaksi")
            cbProjek.SelectedValue = getValue(sqlSelectedData, "kodeprojek")
            setProjek(getValue(sqlSelectedData, "kodeprojek"))
            setDepartemen(getValue(sqlSelectedData, "kodedepartemen"))
            setAsalAkun(getValue(sqlSelectedData, "akunasal"))
            setTujuanAkun(getValue(sqlSelectedData, "akuntujuan"))
            setKontak(getValue(sqlSelectedData, "kontak"))
            tbBayar.Text = getValue(sqlSelectedData, "jumlah")
            kodeTransaksi = idtransaksi
            edited = True
        End If
    End Sub


    Function validation() As Boolean
        If toDouble(tbBayar.Text) <= 0 Then
            dialogError("Jumlah harus melebihi 0")
            Return False
        End If
        If cbAkunAsal.SelectedValue = cbAkunTujuan.SelectedValue Then
            dialogError("Akun asal dan akun tujuan tidak boleh sama")
            Return False
        End If
        Return True
    End Function

    Sub isiJurnal()
        Dim kodeprojek As String = "NULL"
        If cbProjek.SelectedIndex >= 0 Then
            kodeprojek = cbProjek.SelectedValue
        End If


        Dim sqlJurnal As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);"
        Dim jumlah As Double = toDouble(unnumberFormat(tbBayar.Text))
        If debit Then
            Dim keterangan As String = "Penerimaan dari " & cbAkunAsal.Text
            Dim dataKredit As String() = {cbAkunAsal.SelectedValue, kodeprojek, cbDepartemen.SelectedValue, cbKontak.SelectedValue, dtpBayar.Value.ToString("yyyy-MM-dd"), "0", jumlah.ToString, "DP", kodeTransaksi, keterangan}
            Dim dataDebit As String() = {cbAkunTujuan.SelectedValue, kodeprojek, cbDepartemen.SelectedValue, cbKontak.SelectedValue, dtpBayar.Value.ToString("yyyy-MM-dd"), jumlah.ToString, "0", "DP", kodeTransaksi, keterangan}
            operationQuery(sqlJurnal, dataDebit)
            operationQuery(sqlJurnal, dataKredit)
        Else
            Dim keterangan As String = "Pengeluaran dari " & cbAkunAsal.Text
            Dim dataKredit As String() = {cbAkunTujuan.SelectedValue, kodeprojek, cbDepartemen.SelectedValue, cbKontak.SelectedValue, dtpBayar.Value.ToString("yyyy-MM-dd"), "0", jumlah.ToString, "DP", kodeTransaksi, keterangan}
            Dim dataDebit As String() = {cbAkunAsal.SelectedValue, kodeprojek, cbDepartemen.SelectedValue, cbKontak.SelectedValue, dtpBayar.Value.ToString("yyyy-MM-dd"), jumlah.ToString, "0", "DP", kodeTransaksi, keterangan}
            operationQuery(sqlJurnal, dataDebit)
            operationQuery(sqlJurnal, dataKredit)

        End If
        dialogSukses("Berhasil")
        focusData()
    End Sub


    Sub simpanData()
        If validation() Then
            Dim idprojek As String = "NULL"
            If cbProjek.SelectedIndex >= 0 Then
                idprojek = cbProjek.SelectedValue
            End If

            Dim tipeTransaksi As String = ""
            If debit Then
                tipeTransaksi = "CD"
            Else
                tipeTransaksi = "CK"
            End If
            If Not dialog("Apakah anda yakin untuk menyimpan data ini ?") Then
                Return
            End If
            Dim dataTransaksi As String() = {cbAkunAsal.SelectedValue, cbKontak.SelectedValue, "-",
            tipeTransaksi, dtpBayar.Value.ToString("yyyy-MM-dd"),
            cbAkunTujuan.SelectedValue, cbDepartemen.SelectedValue, idprojek, unnumberFormat(tbBayar.Text), kodeTransaksi}
            If edited Then
                If operationQuery("UPDATE public.tbltransaksi SET akunasal=?, kontak=?, deskripsitransaksi=?, tipetransaksi=?, tgltransaksi=?, akuntujuan=?, kodedepartemen=?, kodeprojek=?, jumlah=? 	WHERE kodetransaksi=?", dataTransaksi) Then
                    exc("delete from tbljurnal where koderefrensi='" & kodeTransaksi & "'")
                    isiJurnal()
                End If
            Else
                If operationQuery("INSERT INTO public.tbltransaksi( akunasal, kontak, deskripsitransaksi, tipetransaksi, tgltransaksi, akuntujuan, kodedepartemen, kodeprojek, jumlah,kodetransaksi)	VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?);", dataTransaksi) Then
                    isiJurnal()
                End If
            End If
        End If
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged, dtAwal.ValueChanged
        fillData()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanData()
    End Sub

    Private Sub btnEdt_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
        editData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If edited Then
            Modul.openJurnalDialog(kodeTransaksi)
        Else
            dialogError("Harap pilih item terlebih dahulu")
        End If
    End Sub

    Private Sub tbBayar_TextChanged(sender As Object, e As EventArgs) Handles tbBayar.TextChanged
        editCurrency(sender)
    End Sub
End Class