﻿Public Class DetailPiutangUsaha

    Public idkontak As String = "3"
    Dim kodejual As String = ""
    Private Sub DaftarPiutangUsaha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addhandlertoAllComponent()
        focusData()
    End Sub

    Sub focusData()
        gbData.Enabled = True
        fillData()

        gbForm.Enabled = False
        initForm()
    End Sub

    Sub focusForm()
        gbData.Enabled = False

        gbForm.Enabled = True
        initForm()
    End Sub



    Sub initForm()
        'Departemen
        cbDepartemen.DataSource = getData("SELECT iddepartemen,departemen from tbldepartemen")
        cbDepartemen.DisplayMember = "departemen"
        cbDepartemen.ValueMember = "iddepartemen"
        cbDepartemen.SelectedIndex = 0

        'Akun
        cbAkun.DataSource = getData("SELECT kodeakun ,akun FROM tblakun")
        cbAkun.DisplayMember = "akun"
        cbAkun.ValueMember = "kodeakun"
        cbAkun.SelectedIndex = 0

        'Projek 
        cbProjek.DataSource = getData("select idprojek , projek from tblprojek")
        cbProjek.DisplayMember = "idprojek"
        cbProjek.ValueMember = "projek"
        cbProjek.SelectedIndex = -1


        tbKode.Text = generateRefrence("DP")
        jumlahPiutang.Text = "0"

    End Sub

    Sub fillData()
        styliseDG(ListSat)
        Dim sql As String = "SELECT tgljurnal,koderefrensi,sum(tbljurnal.debit-tbljurnal.kredit) +COALESCE(T.bayar,0) AS piutang,0 as piutang1 ,0 as piutang2,0 as piutang3,0 from tblhistoripiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoripiutang.idjurnal 
left join
(SELECT sum(tbljurnal.debit-tbljurnal.kredit) as bayar,kodejual from tblhistoribayarpiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoribayarpiutang.idjurnal group by tblhistoribayarpiutang.kodejual) T  on T.kodejual = tbljurnal.koderefrensi
 where kontak=" & idkontak & " and koderefrensi ilike '%" & eCari.Text & "%' group by koderefrensi, T.bayar,tgljurnal;"

        Dim datalaporan As DataTable = getData(sql)
        For Each row As DataRow In datalaporan.Rows
            Dim hariData As Date = CDate(row.Item(0))
            Dim nilai As Double = toDouble(row.Item(2))
            Dim hariini As Date = Now
            Dim harike30 As Date = Now.AddDays(-30)
            Dim harike60 As Date = Now.AddDays(-60)
            Dim harike90 As Date = Now.AddDays(-90)
            row.Item(6) = nilai
            If hariData <= hariini And hariData >= harike30 Then
                row.Item(2) = nilai
                row.Item(4) = 0
                row.Item(5) = 0
                row.Item(3) = 0
            ElseIf hariData < harike30 And hariData >= harike60 Then
                row.Item(3) = nilai
                row.Item(2) = 0
                row.Item(4) = 0
                row.Item(5) = 0
            ElseIf hariData < harike60 And hariData >= harike90 Then
                row.Item(4) = nilai
                row.Item(2) = 0
                row.Item(3) = 0
                row.Item(5) = 0
            Else
                row.Item(4) = 0
                row.Item(3) = 0
                row.Item(2) = 0
                row.Item(5) = nilai
            End If
        Next
        Dim dataView As DataView = datalaporan.AsDataView

        ListSat.DataSource = datalaporan
        makeFillDG(ListSat)


        ListSat.Columns(0).HeaderText = "Tanggal"
        ListSat.Columns(1).HeaderText = "Kode Refrensi"
        ListSat.Columns(2).HeaderText = "< 30 Hari"
        ListSat.Columns(3).HeaderText = "30-60 Hari"
        ListSat.Columns(4).HeaderText = "60-90 Hari"
        ListSat.Columns(5).HeaderText = "> 90 Hari"
        ListSat.Columns(6).Visible = False
        ListSat.Columns(5).DefaultCellStyle.Format = "c0"
        ListSat.Columns(4).DefaultCellStyle.Format = "c0"
        ListSat.Columns(2).DefaultCellStyle.Format = "c0"
        ListSat.Columns(3).DefaultCellStyle.Format = "c0"
        kodejual = ""
        detailRefrensi()
    End Sub


    Sub detailRefrensi()
        Dim sql As String = "SELECT tgljurnal,koderefrensi, tbljurnal.debit-tbljurnal.kredit as bayar,0,0,0 from tblhistoripiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoripiutang.idjurnal where koderefrensi='" & kodejual & "'
union all
SELECT tgljurnal,koderefrensi, tbljurnal.debit-tbljurnal.kredit as bayar,0,0,0 from tblhistoribayarpiutang inner join tbljurnal on tbljurnal.idjurnal = tblhistoribayarpiutang.idjurnal where kodejual='" & kodejual & "'"
        styliseDG(ListDetail)
        Dim datalaporan As DataTable = getData(sql)
        For Each row As DataRow In datalaporan.Rows
            Dim hariData As Date = CDate(row.Item(0))
            Dim nilai As Double = toDouble(row.Item(2))
            Dim hariini As Date = Now
            Dim harike30 As Date = Now.AddDays(-30)
            Dim harike60 As Date = Now.AddDays(-60)
            Dim harike90 As Date = Now.AddDays(-90)
            If hariData <= hariini And hariData >= harike30 Then
                row.Item(2) = nilai
                row.Item(4) = 0
                row.Item(5) = 0
                row.Item(3) = 0
            ElseIf hariData < harike30 And hariData >= harike60 Then
                row.Item(3) = nilai
                row.Item(2) = 0
                row.Item(4) = 0
                row.Item(5) = 0
            ElseIf hariData < harike60 And hariData >= harike90 Then
                row.Item(4) = nilai
                row.Item(2) = 0
                row.Item(3) = 0
                row.Item(5) = 0
            Else
                row.Item(4) = 0
                row.Item(3) = 0
                row.Item(2) = 0
                row.Item(5) = nilai
            End If
        Next

        ListDetail.DataSource = datalaporan
        makeFillDG(ListDetail)


        ListDetail.Columns(0).HeaderText = "Tanggal"
        ListDetail.Columns(1).HeaderText = "Kode Refrensi"
        ListDetail.Columns(2).HeaderText = "< 30 Hari"
        ListDetail.Columns(3).HeaderText = "30-60 Hari"
        ListDetail.Columns(4).HeaderText = "60-90 Hari"
        ListDetail.Columns(5).HeaderText = "> 90 Hari"

        ListDetail.Columns(5).DefaultCellStyle.Format = "c0"
        ListDetail.Columns(4).DefaultCellStyle.Format = "c0"
        ListDetail.Columns(2).DefaultCellStyle.Format = "c0"
        ListDetail.Columns(3).DefaultCellStyle.Format = "c0"

    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs)
        closeTab()
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
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
            Me.ActiveControl = eCari
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
    End Sub

    Private Sub ListDetail_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            kodejual = ListSat.Rows(e.RowIndex).Cells(1).Value
            detailRefrensi()
            If Not toDouble(ListSat.Rows(e.RowIndex).Cells(6).Value.ToString) = 0 Then
                focusForm()
                jumlahPiutang.Text = numberFormat(ListSat.Rows(e.RowIndex).Cells(6).Value.ToString)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        focusData()
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dialog As New DialogAkun
        If dialog.ShowDialog = DialogResult.ok Then
            cbAkun.SelectedValue = dialog.idakun
        End If
        dialog.Dispose()
    End Sub

    Private Sub ListSat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellContentClick

    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanData()
    End Sub




    Sub simpanData()
        If dialog("Apakah anda yakin untuk melakukan penghapusan piutang ?") Then
            Dim kodeprojek As String = "NULL"
            If cbProjek.SelectedIndex >= 0 Then
                kodeprojek = cbProjek.SelectedValue
            End If
            Dim sqlHapusPiutang As String = "INSERT INTO public.tblhapuspiutang(kodehapuspiutang,
	 tglhapuspiutang, jumlahpiutang, kodedepartemen, kodeprojek, kodeakun)
	VALUES ( ?,?, ?, ?, ?, ?);"

            Dim dataHapusPiutang As String() = {tbKode.Text, dtpPenghapusan.Value.ToString("yyyy-MM-dd"), unnumberFormat(jumlahPiutang.Text), cbDepartemen.SelectedValue, kodeprojek, cbAkun.SelectedValue}


            If operationQuery(sqlHapusPiutang, dataHapusPiutang) Then
                'Input ke dalam jurnal
                'Jika piutang negatif atau positif
                Dim akunPiutangUsaha As String = "130001"
                Dim keterangan As String = "Penghapusan Piutang dari " & kodejual
                Dim sqlJurnal As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);"
                Dim jumlah As Double = toDouble(unnumberFormat(jumlahPiutang.Text))
                If jumlah < 0 Then
                    jumlah = jumlah * -1
                    Dim dataKredit As String() = {cbAkun.SelectedValue, kodeprojek, cbDepartemen.SelectedValue, idkontak, dtpPenghapusan.Value.ToString("yyyy-MM-dd"), "0", jumlah.ToString, "DP", tbKode.Text, keterangan}
                    Dim dataDebit As String() = {akunPiutangUsaha, kodeprojek, cbDepartemen.SelectedValue, idkontak, dtpPenghapusan.Value.ToString("yyyy-MM-dd"), jumlah.ToString, "0", "DP", tbKode.Text, keterangan}
                    operationQuery(sqlJurnal, dataDebit)
                    operationQuery(sqlJurnal, dataKredit)
                Else
                    Dim dataKredit As String() = {akunPiutangUsaha, kodeprojek, cbDepartemen.SelectedValue, idkontak, dtpPenghapusan.Value.ToString("yyyy-MM-dd"), "0", jumlah.ToString, "DP", tbKode.Text, keterangan}
                    Dim dataDebit As String() = {cbAkun.SelectedValue, kodeprojek, cbDepartemen.SelectedValue, idkontak, dtpPenghapusan.Value.ToString("yyyy-MM-dd"), jumlah.ToString, "0", "DP", tbKode.Text, keterangan}
                    operationQuery(sqlJurnal, dataDebit)
                    operationQuery(sqlJurnal, dataKredit)
                End If
                exc("INSERT into tblhistoribayarpiutang (idjurnal,kodejual) select idjurnal,'" & kodejual & "' from tbljurnal where koderefrensi='" & tbKode.Text & "' AND kodeakun='" & akunPiutangUsaha & "'")
                dialogSukses("Berhasil")
                focusData()
            End If
        End If
    End Sub
End Class