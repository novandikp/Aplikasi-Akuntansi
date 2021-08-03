Public Class DatagridHutang
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListSat)
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
        Me.ListSat.DataSource =
            getData(
                "SELECT idhutangtemp, pelanggan,  jatuhtempo, jumlahbayar, sisasaldp, idpelanggan from view_hutang_temp where  sisasaldp > 0 and (pelanggan LIKE '%" &
                eCari.Text & "%' OR alamatpelanggan LIKE '%" & eCari.Text & "%') and idcabang =" & Form1.idcabang &
                " and jatuhtempo between '" & DTAwal.Value.ToString("yyyy/MM/dd") & "' and '" &
                DTAkhir.Value.ToString("yyyy/MM/dd") & "'  order by jatuhtempo desc")
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).Visible = False
            ListSat.Columns(1).HeaderText = "Nama Pelanggan"
            ListSat.Columns(2).HeaderText = "Jatuh Tempo"
            ListSat.Columns(3).HeaderText = "Jumlah Pembayaran"

            ListSat.Columns(4).HeaderText = "Sisa Hutang"

            ListSat.Columns(5).Visible = False
        Catch ex As Exception

        End Try
        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataPelanggan()
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
            tambahPelanggan()

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Me.Close()
        Return
        Dim listItemForms As DatagridHutang = Application.OpenForms("DatagridHutang")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Sub hapusPelanggan()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idbarang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value.ToString
            If True Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then

                    exc("DELETE FROM tblpelanggan WHERE idpelanggan = " & idbarang & "")
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
            Form1.openEditPelanggan(ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString)
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Sub tambahPelanggan()
        If ListSat.SelectedRows.Count = 1 Then
            If ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(4).Value.ToString = "0" Then
                dialogError("Tidak ada hutang")
                Return
            End If
            DialogHutang.idpelanggan = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(5).Value.ToString
            DialogHutang.idhutangtemp = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString

            DialogHutang.ShowDialog()
            DialogHutang.Dispose()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
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