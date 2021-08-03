Public Class DatagridPelanggan
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
                "SELECT idpelanggan, pelanggan, alamatpelanggan, nopelanggan, CASE WHEN statuspelanggan = 1 THEN 'Aktif' ELSE 'Nonaktif' END as status, level, hutang from view_pelanggan where not idpelanggan = 1 and (pelanggan LIKE '%" &
                eCari.Text & "%' OR alamatpelanggan LIKE '%" & eCari.Text & "%')")
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).Visible = False
            ListSat.Columns(1).HeaderText = "Nama Pelanggan"
            ListSat.Columns(2).HeaderText = "Alamat"
            ListSat.Columns(3).HeaderText = "No Telp"
            ListSat.Columns(4).HeaderText = "Status"
            ListSat.Columns(5).HeaderText = "Level"
            ListSat.Columns(6).HeaderText = "Hutang"


        Catch ex As Exception

        End Try
        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataPelanggan()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, eCari.KeyDown, ListSat.KeyDown

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
            editPelanggan()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusPelanggan()
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
            If getCount("select idpelanggan from tbljual where idpelanggan=" & idbarang) = 0 Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then

                    exc("DELETE FROM tblpelanggan WHERE idpelanggan = " & idbarang & "")
                    getDataPelanggan()
                End If
            Else
                dialogError("Pelanggan sedang dalam transaksi")
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

        Form1.openTambahPelanggan()
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs)
        tambahPelanggan()
    End Sub

    Private Sub HpsBtn_Click(sender As Object, e As EventArgs)
        hapusPelanggan()
    End Sub

    Private Sub EdtBTN_Click(sender As Object, e As EventArgs)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        getDataPelanggan()
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahPelanggan()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        getDataPelanggan()
    End Sub

    Private Sub btnEdt_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
        editPelanggan()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusPelanggan()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        closeTab()
    End Sub

    Private Sub btnKeluar_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Button2.KeyDown, btnTmbh.KeyDown, btnKeluar.KeyDown, BtnHps.KeyDown, btnEdt.KeyDown
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
            editPelanggan()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusPelanggan()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub
End Class