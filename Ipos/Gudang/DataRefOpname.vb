Public Class DataRefOpname
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListSat)
        getDataProduk()
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

    Sub getDataProduk()
        ListSat.ClearSelection()
        Me.ListSat.DataSource =
            getData(
                "SELECT idproduk, produk,  CASE WHEN tipedata = 1 THEN view_harga.stok1  WHEN tipedata = 2 THEN view_harga.stok2 ELSE view_harga.stok3 END as stok1,  satuan, barcode from view_harga where (produk LIKE '%" &
                eCari.Text & "%' OR idproduk LIKE '%" & eCari.Text & "%') and idkategori > 1 and cabang=" & Form1.idcabang)
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Produk"
            ListSat.Columns(1).HeaderText = "Nama Produk"
            ListSat.Columns(2).HeaderText = "Stok"
            ListSat.Columns(3).HeaderText = "Satuan"
            ListSat.Columns(4).Visible = False


        Catch ex As Exception

        End Try
        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataProduk()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, eCari.KeyDown, ListSat.KeyDown, AddBtn.KeyDown

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListSat.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListSat.Focus()
            If ListSat.Rows.Count > 0 Then
                ListSat.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            tambahProduk()
        ElseIf e.KeyCode = Keys.F2 Then

        ElseIf e.KeyCode = Keys.Delete Then

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Me.Close()
        Return
        Dim listItemForms As DataRefOpname = Application.OpenForms("DataRefOpname")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Sub hapusProduk()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idbarang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value.ToString
            If True Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then

                    exc("DELETE FROM tblproduk WHERE idproduk = " & idbarang & "")
                    getDataProduk()
                End If
            Else
                dialogError("Produk sedang dipakai")
            End If


        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub editProduk()
        If ListSat.SelectedRows.Count = 1 Then
            Form1.openEditProduk(ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString)
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Sub tambahProduk()
        If ListSat.SelectedRows.Count = 1 Then
            DialogOpname.iddetailjual = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(4).Value.ToString
            DialogOpname.ShowDialog()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        tambahProduk()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        closeTab()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getDataProduk()
    End Sub

    Private Sub DataRefOpname_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Datagridopname.getDataPelanggan()
    End Sub
End Class