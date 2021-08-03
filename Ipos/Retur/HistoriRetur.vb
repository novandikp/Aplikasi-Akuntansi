Public Class HistoriRetur
    Public idjual = ""

    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListSat)
        'DTAwal.Value = New DateTime(Now.Year, Now.Month, 1)
        getDataPelanggan()
        eCari.Focus()
        Me.ActiveControl = eCari
    End Sub

    Private Sub ecaria(sender As Object, e As KeyEventArgs) Handles eCari.KeyDown
        If e.KeyCode = Keys.Down Then
            Me.ActiveControl = ListSat
            Try
                ListSat.Rows(0).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub

    Function checkStok(idbarang As String) As Boolean
        Dim sql =
                "SELECT jumlahreturjual * nilaijual/jumlahjual as retur, barcode from view_returjual where idreturjual=" &
                idbarang
        Dim stoksaatini =
                Double.Parse(
                    getValue(
                        "SELECT stok1 + stok2 * konversi1 + stok3 * konversi1*konversi2 as stok from tblproduk where idproduk ='" &
                        getValue(sql, "barcode") & "';", "stok"))
        If stoksaatini < Double.Parse(getValue(sql, "retur")) Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub getDataPelanggan()
        ListSat.ClearSelection()
        Dim awal = DTAwal.Value.ToString("yyyy/MM/dd")
        Dim akhir = DTAkhir.Value.ToString("yyyy/MM/dd")
        Me.ListSat.DataSource =
            getData(
                "SELECT idreturjual ,produk, fakturjual, tglreturjual, jumlahreturjual from view_returjual where tglreturjual between ('" &
                awal & " 00:00:00') and ('" & akhir & " 23:59:59')  and (produk LIKE '%" & eCari.Text &
                "%' OR fakturjual LIKE '%" & eCari.Text & "%') and idjual=" & idjual)
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).Visible = False

            ListSat.Columns(1).HeaderText = "Produk"
            ListSat.Columns(2).HeaderText = "Faktur"
            ListSat.Columns(3).HeaderText = "Tanggal Retur"
            ListSat.Columns(4).HeaderText = "Jumlah Retur"


        Catch ex As Exception

        End Try
        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataPelanggan()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, eCari.KeyDown, ListSat.KeyDown, HpsBtn.KeyDown, DTAkhir.KeyDown, DTAwal.KeyDown,
                Button2.KeyDown, HpsBtn.KeyDown, Button1.KeyDown

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListSat.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListSat.Focus()
            If ListSat.Rows.Count > 0 Then
                ListSat.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            tambahPelanggan()

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Sub hapusPelanggan()
        If ListSat.SelectedRows.Count = 1 Then

            Dim idbarang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value.ToString
            Dim edit As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(5).Value.ToString
            If edit = "Sudah Bayar" Then
                dialogError("Order yang dibayar tidak dapat dihapus")
                Return
            End If
            If True Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then
                    exc("DELETE FROM tbldetailjual WHERE idjual = " & idbarang & "")
                    exc("DELETE FROM tbljual WHERE idjual = " & idbarang & "")

                    getDataPelanggan()
                End If
            Else
                dialogError("Pelanggan sedang dipakai")
            End If


        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub editPelanggan()

        If ListSat.SelectedRows.Count = 1 Then
            Dim edit As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(5).Value.ToString
            If edit = "Sudah Bayar" Then
                dialogError("Order yang dibayar tidak dapat diedit")
                Return
            End If
            Form1.openEditPenjualan(ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString)
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Sub tambahPelanggan()
        If ListSat.SelectedRows.Count = 1 Then
            If dialog("Apakah anda yakin untuk menghapus data") Then
                Dim id = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
                Dim faktur = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(2).Value.ToString
                Dim sql = "select * from view_returjual where idreturjual=" & id
                If checkStok(id) Then
                    Dim produk = getValue(sql, "barcode")
                    exc(
                        "update tbldetailjual set returjual = returjual - '" & getValue(sql, "jumlahreturjual") &
                        "' where iddetailjual=" & getValue(sql, "iddetailjual"))
                    Dim nilai As Double =
                            Double.Parse(
                                getValue(
                                    "SELECT jumlahreturjual * nilaijual/jumlahjual as retur, barcode from view_returjual where idreturjual=" &
                                    id, "retur"))
                    Dim datastok As String() = New String() _
                            {produk, "-" & getValue(sql, "jumlahreturjual").ToString.Replace(",", "."),
                             getValue(sql, "satuanjual"), nilai.ToString.Replace(",", "."), Date.Now.ToString(),
                             "SALAH RETUR " & faktur, "0"}
                    Dim querystok =
                            "INSERT INTO tblstok (idproduk, tambahan, satuanstok, nilaidasar, tglstok, keterangan,idbeli) values (?,?,?,?,?,?,?)"
                    operationQuery(querystok, datastok)
                    Dim stok1 As Double = Double.Parse(getValue(sql, "stok1")),
                        stok2 As Double = Double.Parse(getValue(sql, "stok2")),
                        stok3 As Double = Double.Parse(getValue(sql, "stok3"))
                    Dim konversi1 As Double = Double.Parse(getValue(sql, "konversi1"))
                    Dim konversi2 As Double = konversi1*Double.Parse(getValue(sql, "konversi2"))

                    nilai = (stok1 + (stok2*konversi1) + (stok3*konversi2)) - nilai
                    If nilai Mod 1 = 0 Then
                        If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                            stok3 = nilai\konversi2
                            nilai = nilai Mod konversi2
                        Else
                            stok3 = 0
                        End If


                        If konversi1 <= nilai And konversi1 > 1 Then
                            stok2 = nilai\konversi1

                            nilai = nilai Mod konversi1
                        Else
                            stok2 = 0
                        End If
                    Else
                        If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                            stok3 = Math.Floor(nilai/konversi2)
                            nilai -= Math.Floor(nilai/konversi2)*konversi2
                        Else
                            stok3 = 0
                        End If


                        If konversi1 <= nilai And konversi1 > 1 Then
                            stok2 = Math.Floor(nilai/konversi1)

                            nilai -= Math.Floor(nilai/konversi1)*konversi1
                        Else
                            stok2 = 0
                        End If
                    End If


                    stok1 = nilai


                    Dim databarang As String() = New String() _
                            {stok1.ToString.Replace(",", "."), stok2.ToString.Replace(",", "."),
                             stok3.ToString.Replace(",", "."), produk}
                    Dim barangsql = "UPDATE tblproduk set stok1=?, stok2=?, stok3=? where idproduk=?"
                    exc("delete from tblreturjual where idreturjual =" & id)
                    operationQuery(barangsql, databarang)
                    Form1.refreshProduk()
                Else
                    dialogError("Stok tidak cukup")
                End If

            End If
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
        getDataPelanggan()
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles HpsBtn.Click
        tambahPelanggan()
    End Sub

    Private Sub HpsBtn_Click(sender As Object, e As EventArgs)
        hapusPelanggan()
    End Sub

    Private Sub EdtBTN_Click(sender As Object, e As EventArgs)
        editPelanggan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        closeTab()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        getDataPelanggan()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        getDataPelanggan()
    End Sub

    Private Sub DTAwal_ValueChanged(sender As Object, e As EventArgs) Handles DTAwal.ValueChanged

        getDataPelanggan()
    End Sub

    Private Sub DTAkhir_ValueChanged(sender As Object, e As EventArgs) Handles DTAkhir.ValueChanged
        getDataPelanggan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getDataPelanggan()
    End Sub

    Private Sub HistoriRetur_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DatagridRetur.getDataPelanggan()
    End Sub
End Class