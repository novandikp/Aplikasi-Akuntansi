Imports System.ComponentModel

Public Class CariProduk

    Public row As Integer = 0
    Public tipe As Integer = 0

    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListSat)
        getDataProduk()
        eCari.Focus()
        If tipe = 2 Then
            Dim p As Point = ListSat.Location
            p.Y = p.Y - 25
            ListSat.Location = p
            ListSat.Height = ListSat.Height + 25
            ComboBox1.Visible = False
        Else
            ComboBox1.Visible = True
            ComboBox1.Items.Add("Semua")
            ComboBox1.Items.Add("Sparepart")
            ComboBox1.Items.Add("Jasa")
            ComboBox1.SelectedIndex = 0
        End If
        Me.ActiveControl = eCari

    End Sub

    Sub getDataProduk()
        ListSat.ClearSelection()
        Dim sql As String = "SELECT idproduk, produk, satuan, hargajual, hargabeli, CASE WHEN tipedata=1 THEN stok3 * konversi1 * konversi2 + stok2 * konversi1 + stok1 WHEN tipedata=2 THEN stok2 + stok3 * konversi2 ELSE stok3 END as stok, barcode from view_harga where (produk LIKE '%" & eCari.Text & "%' OR idproduk LIKE '%" & eCari.Text & "%') AND cabang=" & Form1.idcabang
        If tipe = 1 Then
            If ComboBox1.SelectedIndex = 1 Then
                sql = sql & " and idkategori > 1"
            ElseIf ComboBox1.SelectedIndex = 2 Then
                sql = sql & " and idkategori = 1"
            End If
        ElseIf tipe = 2 Then
            sql = sql & " and idkategori > 1"
        End If
        Me.ListSat.DataSource = getData(sql)
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Produk"
            ListSat.Columns(1).HeaderText = "Nama Produk"
            ListSat.Columns(2).HeaderText = "Satuan"
            ListSat.Columns(3).HeaderText = "Harga Jual"
            ListSat.Columns(4).HeaderText = "Harga Beli"
             If Not Modul.hargabeli Then
                ListSat.Columns(4).Visible = False
            End If
            ListSat.Columns(5).HeaderText = "Stok"
            ListSat.Columns(6).Visible = False

            If tipe = 1 Then
                ListSat.Columns(4).Visible = False
            End If
        Catch ex As Exception

        End Try
        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataProduk()
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

    Private Sub dg(sender As Object, e As KeyEventArgs) Handles ListSat.KeyDown
        If e.Control And e.KeyCode = Keys.Up Then
            Me.ActiveControl = eCari
            Try
                ListSat.ClearSelection()
            Catch ex As Exception

            End Try
        End If
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

        ElseIf e.KeyCode = Keys.Enter Then

            If ListSat.SelectedRows.Count = 1 Then
                closeTab()

                If tipe = 0 Then
                    Form1.setBarangBeli(ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(0).Value.ToString, row,
                                        ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(6).Value.ToString)

                ElseIf tipe = 1 Then
                    Form1.setBarangJual(ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(0).Value.ToString,
                                        row,
                                        ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(6).Value.ToString)
                Else
                    Form1.setBarangBeli(ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(0).Value.ToString, row,
                                        ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(6).Value.ToString)
                End If
            End If

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()

        End If





    End Sub

    Dim status As Boolean = True
    Sub closeTab()
        status = False
        Me.Close()
    End Sub

    Sub hapusProduk()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idbarang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value.ToString
            If True Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?", "Konfirmasi", MessageBoxButtons.YesNo)
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
        Form1.openTambahProduk()
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub

    Private Sub CariProduk_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If status Then
            If tipe = 0 Then
                Form1.setClearBarangBeli(row)
            ElseIf tipe = 1 Then
                '   Form1.setClearBarangJual(row)
            End If


        Else
            status = True
        End If
    End Sub

    Private Sub listSupplier_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellContentClick

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getDataProduk()
    End Sub

    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        closeTab()

        If tipe = 0 Then
            Form1.setBarangBeli(ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(0).Value.ToString, row,
                                        ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(6).Value.ToString)

        ElseIf tipe = 1 Then
            Form1.setBarangJual(ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(0).Value.ToString,
                                row,
                                ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(6).Value.ToString)
        Else
            Form1.setBarangBeli(ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(0).Value.ToString, row,
                                        ListSat.Rows(ListSat.CurrentCell.RowIndex).Cells(6).Value.ToString)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        getDataProduk()
    End Sub
End Class