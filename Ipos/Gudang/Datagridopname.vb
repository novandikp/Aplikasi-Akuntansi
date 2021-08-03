Public Class Datagridopname
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListSat)
        'DTAwal.Value = New DateTime(Now.Year, Now.Month, 1)
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
                "SELECT idproduk, produk, tglstok, awal, tambahan, awal + tambahan as akhir, satuanstok, keterangan  from view_stokopname where tglstok between ('" &
                awal & " 00:00:00') and ('" & akhir & " 23:59:59') and (produk LIKE '%" & eCari.Text & "%') and cabang=" &
                Form1.idcabang)
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).Visible = False

            ListSat.Columns(1).HeaderText = "Produk"
            ListSat.Columns(2).HeaderText = "Tanggal"
            ListSat.Columns(3).HeaderText = "Awal"
            ListSat.Columns(4).HeaderText = "Selisih"

            ListSat.Columns(5).HeaderText = "Akhir"
            ListSat.Columns(6).HeaderText = "Satuan"
            ListSat.Columns(7).HeaderText = "Keterangan"

        Catch ex As Exception

        End Try
        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataPelanggan()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, eCari.KeyDown, ListSat.KeyDown, AddBtn.KeyDown, DTAkhir.KeyDown, DTAwal.KeyDown

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListSat.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListSat.Focus()
            If ListSat.Rows.Count > 0 Then
                ListSat.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            tambahPelanggan()
        ElseIf e.KeyCode = Keys.F2 Then

        ElseIf e.KeyCode = Keys.Delete Then

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Me.Close()
        Return
        Dim listItemForms As Datagridopname = Application.OpenForms("Datagridopname")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
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
        Form1.openRefOpname()
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        tambahPelanggan()
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
End Class