Public Class DaftarKelebihanBayar

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

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub


    Sub fillData()
        Dim cari As String = eCari.Text
        Dim tglAwal As String = dtAwal.Value.ToString("yyyy-MM-dd")
        Dim tglAkhir As String = dtAkhir.Value.ToString("yyyy-MM-dd")


        Dim sql As String = "select tglkelebihanjual,kodekelebihanbayarjual,tblkontak.pelanggan, tblkelebihanbayarjual.kodejual,tblkelebihanbayarjual.jumlah as nilai from tblkelebihanbayarjual inner join tbljual on tbljual.kodejual = tblkelebihanbayarjual.kodejual inner join tblkontak on tblkontak.idpelanggan = tbljual.pelanggan "
        Dim filter As String = "WHERE (kodekelebihanbayarjual ilike '%" & cari & "%' or tblkontak.pelanggan ilike '%" & cari & "%') AND tglkelebihanjual BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' order by tglkelebihanjual,kodekelebihanbayarjual"
        ListSat.DataSource = getData(sql & filter)
        ListSat.Columns(0).HeaderText = "Tanggal"
        ListSat.Columns(1).HeaderText = "Kode Refrensi"
        ListSat.Columns(2).HeaderText = "Pelanggan"

        ListSat.Columns(3).HeaderText = "Kode Jual"
        ListSat.Columns(4).HeaderText = "Nilai"
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
        Dim ds As DialogResult = FormKelebihanByr.ShowDialog()
        If ds = DialogResult.OK Then

        End If
        fillData()
        FormKelebihanByr.Dispose()
    End Sub


    Sub hapusData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value
            If True Then
                If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                    Dim sqlhapus = "DELETE FROM tblkelebihanbayarjual where kodekelebihanbayarjual = '" & idselected & "';"
                    If exc(sqlhapus) Then
                        exc("DELETE FROM tbljurnal WHERE koderefrensi='" & idselected & "';")
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


    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusData()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class