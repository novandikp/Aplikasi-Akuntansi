Public Class FormBayarHutang
    Dim onEditCurrency As Boolean = False
    Dim kodebeli As String = ""


    Public klasifikasiBiayaLain As String = "6900"
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

    Private Sub FormBayarhutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        focusData()
        addhandlertoAllComponent()
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


    Sub initForm()

        'isi Akun biaya lain
        cbAkun.DataSource = getData("select kodeakun,akun from tblakun")
        cbAkun.DisplayMember = "akun"
        cbAkun.ValueMember = "kodeakun"
        cbAkun.SelectedIndex = 0
        'isi akun penerimaan
        cbBiayaLain.DataSource = getData("select kodeakun,akun from tblakun where idsubklasifikasi='" & klasifikasiBiayaLain & "'")
        cbBiayaLain.DisplayMember = "akun"
        cbBiayaLain.ValueMember = "kodeakun"
        cbBiayaLain.SelectedIndex = 0
        jumlahhutang.Text = "0"
        tbBiayaLain.Text = "0"
        tbBayar.Text = "0"
    End Sub


    Sub fillData()
        Dim sqlHistorihutang As String = "SELECT tgljurnal,koderefrensi,sum(tbljurnal.debit-tbljurnal.kredit) +COALESCE(T.bayar,0) AS hutang from tblhistorihutang inner join tbljurnal on tbljurnal.idjurnal = tblhistorihutang.idjurnal 
        left join (SELECT sum(tbljurnal.debit-tbljurnal.kredit) as bayar,kodebeli from tblhistoribayarhutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoribayarhutang.idjurnal group by tblhistoribayarhutang.kodebeli) T  on T.kodebeli = tbljurnal.koderefrensi where tbljurnal.tipe = 'FB' and koderefrensi ILIKE '%" & eCari.Text & "%' and tgljurnal between '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' and '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "' group by koderefrensi, T.bayar,tgljurnal"
        Dim dt As DataTable = getData(sqlHistorihutang)
        Dim dataview As DataView = dt.AsDataView
        dataview.RowFilter = "hutang > 0"
        ListSat.DataSource = dataview

        ListSat.Columns(0).HeaderText = "Tanggal Jurnal"
        ListSat.Columns(1).HeaderText = "Kode Refrensi"
        ListSat.Columns(2).HeaderText = "hutang"
        ListSat.Columns(2).DefaultCellStyle.Format = "n0"
        styliseDG(ListSat)
        makeFillDG(ListSat)
    End Sub


    Sub focusData()
        kodebeli = ""
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


    Private Sub tbBayar_TextChanged(sender As Object, e As EventArgs) Handles tbBayar.TextChanged, tbBiayaLain.TextChanged
        editCurrency(sender)
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged, dtAkhir.ValueChanged
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dialog As New DialogAkun
        dialog.isLocked = True
        dialog.selectedKlasifikasi = klasifikasiBiayaLain
        If dialog.ShowDialog = DialogResult.OK Then
            cbBiayaLain.SelectedValue = dialog.idakun
        End If
        dialog.Dispose()
    End Sub

    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = ListSat.Rows(e.RowIndex)
            kodebeli = row.Cells(1).Value
            focusForm()
            jumlahhutang.Text = numberFormat(row.Cells(2).Value)

        End If
    End Sub



    Sub simpanData()
        Dim jumlahBayar As String = unnumberFormat(tbBayar.Text)
        Dim tglbayar As String = dtpBayar.Value.ToString("yyyy-MM-dd")
        Dim akunBiayaLain As String = cbBiayaLain.SelectedValue
        Dim akunPenerimaan As String = cbAkun.SelectedValue
        Dim biayalain As Double = toDouble(unnumberFormat(tbBiayaLain.Text))

        Dim akunhutangUsaha As String = "210001"
        Dim sqlinsert As String = "INSERT INTO public.tblbayarhutang(
	kodebeli, tglbayarhutang, akun, bayarhutang, akunbiayalain, biayalain,kodebayarhutang)
	VALUES (?, ?, ?, ?, ?, ?,?);"

        Dim kode As String = generateRefrence("BB")
        Dim dataInsert As String() = {kodebeli, tglbayar, akunPenerimaan, jumlahBayar, akunBiayaLain, biayalain.ToString, kode}
        If operationQuery(sqlinsert, dataInsert) Then
            Dim sqlJurnal As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal)
select ?,kodeprojek,kodedepartemen,pelanggan,?,?,?,?,?,? from tblbeli where kodebeli ='" & kodebeli & "' limit 1"
            Dim dataDebit As String() = {akunPenerimaan, tglbayar, (toDouble(jumlahBayar) + biayalain).ToString, "0", "BP", kode, "Pembayaran hutang dari Faktur " & kodebeli}
            Dim dataKredit As String() = {akunhutangUsaha, tglbayar, "0", (jumlahBayar).ToString, "BP", kode, "Pembayaran hutang dari Faktur " & kodebeli}
            operationQuery(sqlJurnal, dataDebit)
            operationQuery(sqlJurnal, dataKredit)
            If biayalain > 0 Then
                Dim databiayaLain As String() = {akunBiayaLain, tglbayar, "0", (biayalain).ToString, "BP", kode, "Pembayaran hutang dari Faktur " & kodebeli}
                operationQuery(sqlJurnal, databiayaLain)
            End If
            exc("INSERT into tblhistoribayarhutang (idjurnal,kodebeli) select idjurnal,'" & kodebeli & "' from tbljurnal where koderefrensi='" & kode & "' AND kodeakun='" & akunhutangUsaha & "'")
            dialogSukses("Berhasil")
            focusData()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim jumlahBayar As Double = unnumberFormat(tbBayar.Text)
        Dim jmlhutang As Double = unnumberFormat(jumlahhutang.Text)

        If jumlahBayar > jmlhutang Then
            If Not dialog("Transaksi ini akan menghasilkan piutan negatif apakah anda yakin ?") Then
                Return
            End If
        End If
        If dialog("Apakah anda yakin untuk menyimpan pembayaran hutang ini ?") Then
            simpanData()
        End If
    End Sub

    Private Sub tbBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBiayaLain.KeyPress, tbBayar.KeyPress
        onlyNumber(e)
    End Sub
End Class