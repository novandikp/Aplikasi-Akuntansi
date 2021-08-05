Public Class FormKelebihanByr
    Dim onEditCurrency As Boolean = False
    Dim kodejual As String = ""

    Private Sub FormBayarPiutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        focusData()
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

        jumlahPiutang.Text = "0"

        tbBayar.Text = "0"
    End Sub


    Sub fillData()
        Dim sqlHistoriPiutang As String = "SELECT tgljurnal,koderefrensi,(sum(tbljurnal.debit-tbljurnal.kredit) +COALESCE(T.bayar,0)) * -1 AS piutang from tblhistoripiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoripiutang.idjurnal 
left join (SELECT sum(tbljurnal.debit-tbljurnal.kredit) as bayar,kodejual from tblhistoribayarpiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoribayarpiutang.idjurnal group by tblhistoribayarpiutang.kodejual) T  on T.kodejual = tbljurnal.koderefrensi where tbljurnal.tipe = 'PJ' and koderefrensi ILIKE '%" & eCari.Text & "%' and tgljurnal between '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' and '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "' group by koderefrensi, T.bayar,tgljurnal"
        Dim dt As DataTable = getData(sqlHistoriPiutang)
        Dim dataview As DataView = dt.AsDataView
        dataview.RowFilter = "piutang > 0"
        ListSat.DataSource = dataview

        ListSat.Columns(0).HeaderText = "Tanggal Jurnal"
        ListSat.Columns(1).HeaderText = "Kode Refrensi"
        ListSat.Columns(2).HeaderText = "Kelebihan Bayar"
        ListSat.Columns(2).DefaultCellStyle.Format = "n0"
        styliseDG(ListSat)
        makeFillDG(ListSat)
    End Sub


    Sub focusData()
        kodejual = ""
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


    Private Sub tbBayar_TextChanged(sender As Object, e As EventArgs) Handles tbBayar.TextChanged
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



    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
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
            kodejual = row.Cells(1).Value
            focusForm()
            jumlahPiutang.Text = numberFormat(row.Cells(2).Value)

        End If
    End Sub



    Sub simpanData()
        Dim jumlahBayar As String = unnumberFormat(tbBayar.Text)
        Dim tglbayar As String = dtpBayar.Value.ToString("yyyy-MM-dd")

        Dim akunPenerimaan As String = cbAkun.SelectedValue


        Dim akunPiutangUsaha As String = "130001"
        Dim sqlinsert As String = "INSERT INTO public.tblkelebihanbayarjual(
	kodekelebihanbayarjual, akun, jumlah, kodejual, tglkelebihanjual)
	VALUES (?, ?, ?, ?, ?);"

        Dim kode As String = generateRefrence("LP")
        Dim dataInsert As String() = {kode, akunPenerimaan, jumlahBayar, kodejual, tglbayar}
        If operationQuery(sqlinsert, dataInsert) Then
            Dim sqlJurnal As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) select ?,kodeprojek,kodedepartemen,pelanggan,?,?,?,?,?,? from tbljual where kodejual ='" & kodejual & "' limit 1"
            Dim dataDebit As String() = {akunPiutangUsaha, tglbayar, jumlahBayar, "0", "LP", kode, "Penegembalian Kelebihan dari Faktur " & kodejual}
            Dim dataKredit As String() = {akunPenerimaan, tglbayar, "0", (jumlahBayar).ToString, "LP", kode, "Penegembalian Kelebihan dari Faktur " & kodejual}
            operationQuery(sqlJurnal, dataDebit)
            operationQuery(sqlJurnal, dataKredit)
            exc("INSERT into tblhistoribayarpiutang (idjurnal,kodejual) select idjurnal,'" & kodejual & "' from tbljurnal where koderefrensi='" & kode & "' AND kodeakun='" & akunPiutangUsaha & "'")
            dialogSukses("Berhasil")
            focusData()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim jumlahBayar As Double = unnumberFormat(tbBayar.Text)
        Dim jmlPiutang As Double = unnumberFormat(jumlahPiutang.Text)

        If jumlahBayar > jmlPiutang Then
            dialogError("Melebihi Kelebihan")
        End If
        If dialog("Apakah anda yakin untuk menyimpan kelebihan penjualan ini ?") Then
            simpanData()
        End If
    End Sub

    Private Sub tbBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBayar.KeyPress
        onlyNumber(e)
    End Sub
End Class