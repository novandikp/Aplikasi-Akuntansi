Public Class DatagridSupplier
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
                "SELECT idsupplier, supplier, alamatsupplier, nosupplier, piutang from tblsupplier where not idsupplier=2 and (supplier LIKE '%" &
                eCari.Text & "%' OR alamatsupplier LIKE '%" & eCari.Text & "%') AND idcabang=" & Form1.idcabang)
        makeFillDG(listSupplier)
        Try
            listSupplier.Columns(0).Visible = False
            listSupplier.Columns(1).HeaderText = "Nama Supplier"
            listSupplier.Columns(2).HeaderText = "Alamat"
            listSupplier.Columns(3).HeaderText = "No Telp"


        Catch ex As Exception

        End Try
        listSupplier.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataPelanggan()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs)
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Sub hapusPelanggan()
        If listSupplier.SelectedRows.Count = 1 Then
            Dim idbarang As String = listSupplier.Rows(listSupplier.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = listSupplier.Rows(listSupplier.SelectedRows(0).Index).Cells(1).Value.ToString
            If getCount("select idsupplier from tblbeli where idsupplier=" & idbarang) = 0 Then

                If dialog("Apakah anda yakin untuk menghapus " & barang & "?") Then

                    exc("DELETE FROM tblsupplier WHERE idsupplier = " & idbarang & "")
                    getDataPelanggan()
                End If
            Else
                dialogError("Supplier sedang dalam transaksi")
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

        Form1.openTambahSupplier()
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahPelanggan()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusPelanggan()
    End Sub

    Private Sub Btnedt_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
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

    Private Sub btnTmbh_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles MyBase.KeyDown, listSupplier.KeyDown, eCari.KeyDown, ComboBox1.KeyDown, btnTmbh.KeyDown,
                btnKeluar.KeyDown, BtnHps.KeyDown, btnEdt.KeyDown
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getDataPelanggan()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
    End Sub

    Private Function cekRow(row As DataRow, Optional tipe As Integer = 0) As Boolean
        Dim filled = True
        For i As Integer = 0 To row.ItemArray.Length - 1
            If String.IsNullOrWhiteSpace(row.Item(i).ToString) Then
                filled = False
                Exit For
            End If

        Next

        Return filled
    End Function

    Private Sub import_excel(data As DataTable)

        For Each row As DataRow In data.Rows

            If cekRow(row) Then
                If _
                    operationQuery("insert into tblsupplier (supplier, alamatsupplier, nosupplier ) values ( ?, ?, ?);",
                                   New String() {row.Item(0), row.Item(1), row.Item(2)}) Then

                End If
            Else

            End If

        Next
        dialogInfo("berhasil")
        getDataPelanggan()
    End Sub
End Class