Public Class DatagridPiutang
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(listSupplier)
        getDataPelanggan()
        eCari.Focus()
    End Sub

    Private Sub ecaria(sender As Object, e As KeyEventArgs) Handles eCari.KeyDown
        If e.KeyCode = Keys.Down Then
            Me.ActiveControl = listSupplier
            Try
                listSupplier.Rows(0).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub getDataPelanggan()
        listSupplier.ClearSelection()
        Me.listSupplier.DataSource =
            getData(
                "SELECT idpiutangtemp, supplier,  jatuhtempo, jumlahbayar, sisasaldp, idsupplier from view_piutang_temp where not idsupplier=2 and sisasaldp > 0 and (supplier LIKE '%" &
                eCari.Text & "%' OR alamatsupplier LIKE '%" & eCari.Text & "%') and idcabang =" & Form1.idcabang &
                " and jatuhtempo between '" & DTAwal.Value.ToString("yyyy/MM/dd") & "' and '" &
                DTAkhir.Value.ToString("yyyy/MM/dd") & "'  order by jatuhtempo desc")
        makeFillDG(listSupplier)
        Try
            listSupplier.Columns(0).Visible = False
            listSupplier.Columns(1).HeaderText = "Nama Supplier"
            listSupplier.Columns(2).HeaderText = "Jatuh Tempo"
            listSupplier.Columns(3).HeaderText = "Jumlah Pembayaran"
            listSupplier.Columns(4).HeaderText = "Sisa Hutang"
            listSupplier.Columns(5).Visible = False

        Catch ex As Exception

        End Try
        listSupplier.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataPelanggan()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, eCari.KeyDown, listSupplier.KeyDown, btnTmbh.KeyDown

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            listSupplier.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            listSupplier.Focus()

            If listSupplier.Rows.Count > 0 Then
                listSupplier.Rows(0).Selected = True
            End If

        ElseIf e.KeyCode = Keys.F1 Then
            tambahPelanggan()
        ElseIf e.KeyCode = Keys.F2 Then
            editPelanggan()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusPelanggan()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Me.Close()
        Return
        Dim listItemForms As DatagridPiutang = Application.OpenForms("DatagridPiutang")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Sub hapusPelanggan()
        If listSupplier.SelectedRows.Count = 1 Then
            Dim idbarang As String = listSupplier.Rows(listSupplier.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = listSupplier.Rows(listSupplier.SelectedRows(0).Index).Cells(1).Value.ToString
            If True Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then

                    exc("DELETE FROM tblsupplier WHERE idsupplier = " & idbarang & "")
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
        If listSupplier.SelectedRows.Count = 1 Then
            Form1.openEditSupplier(listSupplier.Rows(listSupplier.SelectedRows(0).Index).Cells(0).Value.ToString)
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        listSupplier.ClearSelection()
    End Sub

    Sub tambahPelanggan()
        If listSupplier.SelectedRows.Count = 1 Then
            If listSupplier.Rows(listSupplier.SelectedRows(0).Index).Cells(4).Value.ToString = "0" Then
                dialogError("Tidak ada piutang")
                Return
            End If
            DialogPiutang.idsupplier = listSupplier.Rows(listSupplier.SelectedRows(0).Index).Cells(5).Value.ToString
            DialogPiutang.idhutangtemp = listSupplier.Rows(listSupplier.SelectedRows(0).Index).Cells(0).Value.ToString
            DialogPiutang.ShowDialog()
            DialogPiutang.Dispose()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        listSupplier.ClearSelection()
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahPelanggan()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs)
        hapusPelanggan()
    End Sub

    Private Sub Btnedt_Click(sender As Object, e As EventArgs)
        editPelanggan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        closeTab()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        getDataPelanggan()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        getDataPelanggan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getDataPelanggan()
    End Sub

    Private Sub DTAwal_ValueChanged(sender As Object, e As EventArgs) Handles DTAwal.ValueChanged
        getDataPelanggan()
    End Sub

    Private Sub DTAkhir_ValueChanged(sender As Object, e As EventArgs) Handles DTAkhir.ValueChanged
        getDataPelanggan()
    End Sub
End Class