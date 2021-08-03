Public Class DaftarPenjualan
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        styliseDG(ListSat)
        ' DTAwal.Value = New DateTime(Now.Year, Now.Month, 1)
        getDataPelanggan()
        eCari.Focus()
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

    Sub getDataPelanggan()
        ListSat.ClearSelection()
        Dim awal = DTAwal.Value.ToString("yyyy/MM/dd")
        Dim akhir = DTAkhir.Value.ToString("yyyy/MM/dd")
        Me.ListSat.DataSource =
            getData(
                "SELECT idjual, fakturjual, tgljual, pelanggan, total, CASE WHEN flag = 1 THEN 'Sudah Bayar'ELSE 'Belum Bayar' END as status from view_jual where tgljual between ('" &
                awal & " 00:00:00') and ('" & akhir & " 23:59:59')  and idcabang = " & Form1.idcabang &
                " and (pelanggan LIKE '%" & eCari.Text & "%' OR fakturjual LIKE '%" & eCari.Text & "%')")
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).Visible = False

            ListSat.Columns(1).HeaderText = "Faktur"
            ListSat.Columns(2).HeaderText = "Tanggal"
            ListSat.Columns(3).HeaderText = "Pelanggan"
            ListSat.Columns(4).HeaderText = "Total"
            ListSat.Columns(4).DefaultCellStyle.Format = "C2"
            ListSat.Columns(5).HeaderText = "Status"


        Catch ex As Exception

        End Try
        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataPelanggan()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, eCari.KeyDown, ListSat.KeyDown, EdtBtn.KeyDown, HpsBtn.KeyDown, DTAkhir.KeyDown,
                DTAwal.KeyDown, Button7.KeyDown, Button1.KeyDown, Button2.KeyDown

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListSat.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListSat.Focus()
            If ListSat.Rows.Count > 0 Then
                ListSat.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            'tambahPelanggan()
        ElseIf e.KeyCode = Keys.F2 Then
            editPelanggan()
        ElseIf e.KeyCode = Keys.F7 Then
            printDialog()
        ElseIf e.KeyCode = Keys.F8 Then
            printDialogJalan()
        ElseIf e.KeyCode = Keys.F10 Then
            detail()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusPelanggan()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Dim listItemForms As DaftarPenjualan = Application.OpenForms("DaftarPenjualan")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Sub hapusPelanggan()
        If Not HpsBtn.Enabled Then
            Return
        End If
        If ListSat.SelectedRows.Count = 1 Then

            Dim idbarang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value.ToString
            Dim edit As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(5).Value.ToString
            If getCount("select idjual from view_returjual where idjual=" & idbarang) > 0 Then
                dialogError("Sudah terdapat retur")
                Return
            End If
            If True Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then
                    If edit = "Sudah Bayar" Then
                        Dim dgv As New DataTable
                        dgv = getData("select * from view_detailjual WHERE idjual = " & idbarang)
                        For Each drow As DataRow In dgv.Rows
                            Dim produk = drow.Item("barcode")
                            Dim nilai As Double = Double.Parse(drow.Item("nilaijual"))
                            Dim datastok As String() = New String() _
                                    {drow.Item("barcode"), drow.Item("jumlahjual").ToString.Replace(",", "."),
                                     drow.Item("satuanjual"), nilai.ToString.Replace(",", "."),
                                     Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"),
                                     "SALAH PENJUALAN " & idbarang, "0"}
                            Dim querystok =
                                    "INSERT INTO tblstok (idproduk, tambahan, satuanstok, nilaidasar, tglstok, keterangan,idbeli) values (?,?,?,?,?,?,?)"
                            operationQuery(querystok, datastok)
                            Dim stok1 As Double = Double.Parse(drow.Item("stok1")),
                                stok2 As Double = Double.Parse(drow.Item("stok2")),
                                stok3 As Double = Double.Parse(drow.Item("stok3"))
                            Dim konversi1 As Double = Double.Parse(drow.Item("konversi1"))
                            Dim konversi2 As Double = konversi1*Double.Parse(drow.Item("konversi2"))

                            If nilai Mod 1 = 0 Then
                                If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                    stok3 += nilai\konversi2
                                    nilai = nilai Mod konversi2
                                End If


                                If konversi1 <= nilai And konversi1 > 1 Then
                                    stok2 += nilai\konversi1

                                    nilai = nilai Mod konversi1
                                End If
                            Else
                                If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                    stok3 += Math.Floor(nilai/konversi2)
                                    nilai -= Math.Floor(nilai/konversi2)*konversi2
                                End If


                                If konversi1 <= nilai And konversi1 > 1 Then
                                    stok2 += Math.Floor(nilai/konversi1)

                                    nilai -= Math.Floor(nilai/konversi1)*konversi1
                                End If
                            End If


                            stok1 += nilai

                            Dim databarang As String() = New String() _
                                    {stok1.ToString.Replace(",", "."), stok2.ToString.Replace(",", "."),
                                     stok3.ToString.Replace(",", "."), produk}
                            Dim barangsql = "UPDATE tblproduk set stok1=?, stok2=?, stok3=? where idproduk=?"
                            operationQuery(barangsql, databarang)


                        Next
                    End If
                    exc("DELETE FROM tbldetailjual WHERE idjual = " & idbarang & "")
                    exc("DELETE FROM tbljual WHERE idjual = " & idbarang & "")

                    getDataPelanggan()
                    Form1.refreshProduk()
                End If
            Else
                dialogError("Pelanggan sedang dipakai")
            End If


        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub editPelanggan()
        If Not EdtBtn.Enabled Then
            Return
        End If
        If ListSat.SelectedRows.Count = 1 Then
            Dim edit As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(5).Value.ToString
            If edit = "Sudah Bayar" Then
                dialogError("Order yang dibayar tidak dapat diedit")
                Return
            End If
            FormPenawaranJual.continueOrder()
            FormPenawaranJual.ShowDialog()

            FormPenawaranJual.Dispose()
            'Form1.openEditPenjualan(ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString)
            ListSat.ClearSelection()
        Else
            'MsgBox("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub printDialog()
        If Not Button7.Enabled Then
            Return
        End If
        If ListSat.SelectedRows.Count = 1 Then
            Dim edit As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(5).Value.ToString
            If Not edit = "Sudah Bayar" Then
                dialogError("Order belum dibayar tidak dapat dicetak")
                Return
            End If
            Dim idbarang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim sqlmetode = "select metode from tbljual where idjual = " & idbarang
            Dim sqlidentitas As String = "select printstruk from tblidentitas where idtoko=1"
            If getValue(sqlmetode, "metode") = "Hutang" Then
                PreviewStrukA5.idjual = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
                PreviewStrukA5.ShowDialog()
            Else
                Dim struk = getValue(sqlidentitas, "printstruk")
                If struk = "58 mm" Then
                    PreviewStruk.idjual = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
                    PreviewStruk.ShowDialog()
                ElseIf struk = "70 mm" Then
                    PreviewStruk70.idjual = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
                    PreviewStruk70.ShowDialog()
                Else
                    PreviewStrukA5.idjual = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
                    PreviewStrukA5.ShowDialog()
                End If
            End If

        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Sub printDialogJalan()
        If Not Button1.Enabled Then
            Return
        End If
        If ListSat.SelectedRows.Count = 1 Then
            Dim edit As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(5).Value.ToString
            If Not edit = "Sudah Bayar" Then
                dialogError("Order belum dibayar tidak dapat dicetak")
                Return
            End If
            SuratJalan.idjual = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            SuratJalan.ShowDialog()

        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Sub tambahPelanggan()
        Dim addItemForms As FormPenawaranJual = Application.OpenForms("FormPenjualan")
        If Not IsNothing(addItemForms) Then
            If dialog("Apakah anda yakin untuk menimpa form order yang telah dibuka") Then
                Form1.openPenjualan(True)
            Else
                Form1.openPenjualan(False)
            End If

        Else
            Form1.openPenjualan(True)

        End If
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs)
        tambahPelanggan()
    End Sub

    Private Sub HpsBtn_Click(sender As Object, e As EventArgs) Handles HpsBtn.Click
        hapusPelanggan()
    End Sub

    Private Sub EdtBTN_Click(sender As Object, e As EventArgs) Handles EdtBtn.Click
        editPelanggan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        printDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        printDialogJalan()
    End Sub

    Private Sub ListSat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles ListSat.CellContentClick
    End Sub

    Private Sub ListSat_SelectionChanged(sender As Object, e As EventArgs) Handles ListSat.SelectionChanged
        Try
            Dim edit As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(5).Value.ToString
            If edit = "Sudah Bayar" Then
                HpsBtn.Enabled = False
                Button7.Enabled = True
                Button1.Enabled = True
                Button4.Enabled = True
                EdtBtn.Enabled = False
            Else
                HpsBtn.Enabled = True
                Button7.Enabled = False
                Button1.Enabled = False
                Button4.Enabled = False
                EdtBtn.Enabled = True

            End If
            Button2.Enabled = True
        Catch ex As Exception
            HpsBtn.Enabled = False
            Button7.Enabled = False
            Button1.Enabled = False
            EdtBtn.Enabled = False
            Button2.Enabled = False
        End Try
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        getDataPelanggan()
    End Sub


    Sub detail()
        If ListSat.SelectedRows.Count = 1 Then

            DetailPenjualan.idjual = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            DetailPenjualan.getDataProduk()
            DetailPenjualan.ShowDialog()

        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        detail()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        If ListSat.SelectedRows.Count = 1 Then

            CopyResep.idjual = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            CopyResep.getDataProduk()
            CopyResep.ShowDialog()

        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub
End Class