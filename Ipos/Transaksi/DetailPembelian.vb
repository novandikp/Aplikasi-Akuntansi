

Public Class DetailPembelian
    Public idjual As String = ""
    Public row As Integer = 0
    Public tipe As Integer = 0

    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListSat)
        getDataProduk()
        eCari.Focus()
        Me.ActiveControl = eCari
    End Sub


    Sub getDataProduk()
        ListSat.ClearSelection()
        Me.ListSat.DataSource =
            getData(
                "SELECT barcode, produk, tglbeli, jumlahbeli, satuanbeli, hargabeli from view_detailbeli where idbeli=" &
                idjual & " AND (produk LIKE '%" & eCari.Text & "%' OR idproduk LIKE '%" & eCari.Text & "%')")
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Produk"
            ListSat.Columns(1).HeaderText = "Nama Produk"
            ListSat.Columns(2).HeaderText = "Tanggal"
            ListSat.Columns(3).HeaderText = "Jumlah"
            ListSat.Columns(4).HeaderText = "Satuan Beli"
            ListSat.Columns(5).HeaderText = "Harga Beli"


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
End Class