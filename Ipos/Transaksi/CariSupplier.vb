﻿Public Class CariSupplier
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(listSupplier)
        getDataPelanggan()
        eCari.Focus()
        Me.ActiveControl = eCari
    End Sub

    Private Sub dg(sender As Object, e As KeyEventArgs) Handles listSupplier.KeyDown
        If e.Control And e.KeyCode = Keys.Up Then
            Me.ActiveControl = eCari
            Try
                listSupplier.ClearSelection()
            Catch ex As Exception

            End Try
        End If
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
                "SELECT  idsupplier, supplier, alamatsupplier, nosupplier, piutang from tblsupplier where (supplier LIKE '%" &
                eCari.Text & "%' OR alamatsupplier LIKE '%" & eCari.Text & "%') AND idcabang=" & Form1.idcabang)
        makeFillDG(listSupplier)
        Try
            listSupplier.Columns(0).Visible = False
            listSupplier.Columns(1).HeaderText = "Nama Supplier"
            listSupplier.Columns(2).HeaderText = "Alamat"
            listSupplier.Columns(3).HeaderText = "No Telp"


        Catch ex As Exception

        End Try
        For Each row As DataGridViewRow In listSupplier.Rows
            If row.Cells(0).Value = 2 Then
                row.Cells(1).Style.BackColor = Color.Green
                row.Cells(2).Style.BackColor = Color.Green
                row.Cells(3).Style.BackColor = Color.Green

                row.Cells(1).Style.ForeColor = Color.White
                row.Cells(2).Style.ForeColor = Color.White
                row.Cells(3).Style.ForeColor = Color.White
                Exit For
            End If

        Next
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
        ElseIf e.KeyCode = Keys.Enter Then

            If listSupplier.SelectedRows.Count = 1 Then
                Me.Close()
                Form1.setSupplierBeli(listSupplier.Rows(listSupplier.CurrentCell.RowIndex).Cells(0).Value.ToString)
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            tambahPelanggan()

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Me.Close()
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
        TambahSupplier.ShowDialog()
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahPelanggan()
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

    Private Sub listSupplier_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles listSupplier.CellContentClick
        Me.Close()
        Form1.setSupplierBeli(listSupplier.Rows(e.RowIndex).Cells(0).Value.ToString)
    End Sub

    Private Sub listSupplier_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles listSupplier.CellContentDoubleClick
        Me.Close()
        Form1.setSupplierBeli(listSupplier.Rows(e.RowIndex).Cells(0).Value.ToString)
    End Sub

    Private Sub listSupplier_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) _
        Handles listSupplier.CellMouseClick
        Me.Close()
        Form1.setSupplierBeli(listSupplier.Rows(e.RowIndex).Cells(0).Value.ToString)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getDataPelanggan()
    End Sub
End Class