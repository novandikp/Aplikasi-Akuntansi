

Public Class CopyResep
    Public idjual As String = ""
    Public row As Integer = 0
    Public tipe As Integer = 0
    Public statusCol As Boolean = True

    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListSat)
        '  getDataProduk()
        isiDefaultData()
    End Sub

    Sub getDataProduk()
        ListSat.ClearSelection()
        Me.ListSat.DataSource =
            getData(
                "SELECT  produk, tgljual, jumlahjual,  hargajual, jumlahjual as stok1, 0 as stok2, stok3, '' as alamatpelanggan from view_detailjual where idjual=" &
                idjual)
        'makeFillDG(ListSat)
        Try

            ListSat.Columns(0).HeaderText = "Nama Produk"
            ListSat.Columns(1).HeaderText = "Tanggal"
            ListSat.Columns(2).HeaderText = "Jumlah"
            ListSat.Columns(3).HeaderText = "Harga Jual"
            ListSat.Columns(4).HeaderText = "Jumlah Item pada Resep"
            ListSat.Columns(5).HeaderText = "Jumlah Pembelian Iter Lengkap"
            ListSat.Columns(7).HeaderText = "Deskripsi Obat"
            ListSat.Columns(0).ReadOnly = True
            ListSat.Columns(1).ReadOnly = True
            ListSat.Columns(2).ReadOnly = True
            ListSat.Columns(3).ReadOnly = True
            ListSat.Columns(6).Visible = False

        Catch ex As Exception

        End Try
        makeFillDG(ListSat)
        ListSat.ClearSelection()
        getDataOrder()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub


    Sub getDataOrder()
        Dim sql As String = "SELECT resep,pelanggan, dokter, tgljual from view_jual where idjual=" & idjual
        TBDokter.Text = getValue(sql, "dokter")
        TBResep.Text = getValue(sql, "resep")
        TBPelanggan.Text = getValue(sql, "pelanggan")
        dtpDokter.Value = getValue(sql, "tgljual")
        TBIter.Text = "0/"
    End Sub

    Private Sub ecaria(sender As Object, e As KeyEventArgs)
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

            Try
                ListSat.ClearSelection()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, ListSat.KeyDown

        If e.KeyCode = Keys.F6 Then
            ListSat.Focus()
            If ListSat.Rows.Count > 0 Then
                ListSat.Rows(0).Selected = True
            End If

        ElseIf e.KeyCode = Keys.Enter Then


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
        Form1.openTambahProduk()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
    End Sub


    Sub isiDefaultData()
        Return
        For Each row As DataGridViewRow In ListSat.Rows
            row.Cells(2).Value = "0"
        Next
    End Sub


    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TBIter.TextChanged
        If Not Double.TryParse(TBIter.Text, 0) Then
            TBIter.Text = "0"
        End If
    End Sub


    Function cekObat() As Boolean
        Dim status = True
        Dim baris As Integer = 1
        For Each row As DataGridViewRow In ListSat.Rows
            If Not Double.TryParse(row.Cells(4).Value, 0) Or Not Double.TryParse(row.Cells(4).Value, 0) Then
                dialogError("Isi dengan benar pada baris ke " & baris)
                status = False
                Exit For

            ElseIf toDouble(row.Cells(4).Value) < toDouble(row.Cells(2).Value) Then

                dialogError("Jumlah pada resep harus lebih besar sama dengan jumlah pembelian")
                status = False
                Exit For
            ElseIf String.IsNullOrWhiteSpace(row.Cells(7).Value) Then
                dialogError("Isi keterangan pada baris ke " & baris)
                status = False
                Exit For
            End If


            row.Cells(6).Value = toDouble(row.Cells(4).Value) - toDouble(row.Cells(2).Value)
            baris = baris + 1
        Next

        Return status
    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        If Not Double.TryParse(TBUmur.Text, 0) Or
           String.IsNullOrWhiteSpace(TBPelanggan.Text) Or
           String.IsNullOrWhiteSpace(TBResep.Text) Or
           String.IsNullOrWhiteSpace(TBDokter.Text) Or
           String.IsNullOrWhiteSpace(TBUmur.Text) Then
            dialogError("Isi resep dengan benar")
            Return
        End If

        If Not cekObat() Then
            Return
        End If
        PreviewResep.idjual = idjual
        PreviewResep.resep = TBResep.Text
        PreviewResep.dokter = TBDokter.Text
        PreviewResep.pelanggan = TBPelanggan.Text
        PreviewResep.umur = TBUmur.Text
        PreviewResep.tglbeli = dtpBeli.Value.ToString("yyyy-MM-dd")
        PreviewResep.tgldokter = dtpDokter.Value.ToString("yyyy-MM-dd")
        PreviewResep.iter = TBIter.Text
        PreviewResep.data = New DataTable
        PreviewResep.data = (DirectCast(ListSat.DataSource, DataTable))
        PreviewResep.ShowDialog()
        PreviewResep.Dispose()
    End Sub
End Class