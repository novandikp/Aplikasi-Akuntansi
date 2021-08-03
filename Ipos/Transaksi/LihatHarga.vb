Imports System.Text

Public Class LihatHarga
    Public selectedList As New ArrayList
    Public selectedBarcode As New ArrayList

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
                "SELECT idproduk, produk, satuan, merk, kategori,  hargabeli, hargajual,barcode from view_harga as T1 where (produk LIKE '%" &
                eCari.Text & "%' OR idproduk LIKE '%" & eCari.Text & "%')  AND cabang=" & Form1.idcabang)
        makeFillDG(ListSat)
        Try
            ListSat.Columns(1).HeaderText = "Kode Produk"
            ListSat.Columns(2).HeaderText = "Nama Produk"
            ListSat.Columns(3).HeaderText = "Satuan"
            ListSat.Columns(4).HeaderText = "Merk"
            ListSat.Columns(5).HeaderText = "Jenis"
            ListSat.Columns(6).HeaderText = "Harga Beli"
            If Not Modul.hargabeli Then
                ListSat.Columns(6).Visible = False
            End If
            ListSat.Columns(7).HeaderText = "Harga Jual"
            ListSat.Columns(6).DefaultCellStyle.Format = "C2"
            ListSat.Columns(7).DefaultCellStyle.Format = "C2"
            ListSat.Columns(8).Visible = False
            ListSat.Columns(1).ReadOnly = True
            ListSat.Columns(2).ReadOnly = True
            ListSat.Columns(3).ReadOnly = True
            ListSat.Columns(4).ReadOnly = True
            ListSat.Columns(5).ReadOnly = True
            ListSat.Columns(6).ReadOnly = True
            ListSat.Columns(7).ReadOnly = True
            ListSat.Columns(8).ReadOnly = True

            refreshSelected()
        Catch ex As Exception

        End Try
        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataProduk()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, eCari.KeyDown, ListSat.KeyDown, Button4.KeyDown, btnEdt.KeyDown

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
            editProduk()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusProduk()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Me.Close()
        Return
        Dim listItemForms As DatagridBarang = Application.OpenForms("DatagridBarang")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Dim open As Boolean = True

    Sub hapusProduk()
        If open Then
            open = False
            Dim preview As CetakBarcode = New CetakBarcode()

            preview.struk()
            preview.ShowDialog()
            preview.Dispose()
            open = True
        End If
    End Sub


    Sub editProduk()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idbarang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(8).Value.ToString
            UbahHarga.row = idbarang
            UbahHarga.awal()
            UbahHarga.ShowDialog()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Sub tambahProduk()
        If open Then
            open = False
            Dim preview As CetakBarcode = New CetakBarcode()

            preview.awal()
            preview.ShowDialog()
            open = True
        End If
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs)
        tambahProduk()
    End Sub

    Private Sub HpsBtn_Click(sender As Object, e As EventArgs)
        hapusProduk()
    End Sub

    Private Sub EdtBTN_Click(sender As Object, e As EventArgs)
        editProduk()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        closeTab()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        getDataProduk()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub

    Private Sub btnEdt_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
        editProduk()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs)
        hapusProduk()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs)
        closeTab()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        tambahProduk()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click


        If (selectedBarcode.Count > 0) Then
            If open Then
                open = False
                Dim idproduk As New StringBuilder()
                Dim i As Integer = 0
                For Each id As String In selectedBarcode
                    If i = 0 Then
                        idproduk.Append("(")
                    End If
                    idproduk.Append("'" & id & "'")
                    If i = selectedBarcode.Count - 1 Then
                        idproduk.Append(")")
                    Else
                        idproduk.Append(",")
                        i += 1
                    End If

                Next

                Dim sqlbarcode As String =
                        "select barcode, idproduk, hargajual, hargabeli, idsatuan, tipedata, konversi, produk, idkategori, idmerk, ppnproduk, rak, gambar, statusbarang, stokis, 1 as stok, konversi1, konversi2, cabang, kategori, merk, satuan from view_harga WHERE barcode in " &
                        idproduk.ToString & " and cabang=" & Form1.idcabang
                Debug.Write(sqlbarcode)
                Dim preview As CetakBarcode = New CetakBarcode()
                preview.sqlbarcode = sqlbarcode
                preview.struk()
                preview.ShowDialog()
                preview.Dispose()
                open = True
            End If
        Else
            dialogError("Pilih barang terlebih dahulu")
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If (selectedBarcode.Count > 0) Then
            If open Then
                open = False
                Dim idproduk As New StringBuilder()
                Dim i As Integer = 0
                For Each id As String In selectedBarcode
                    If i = 0 Then
                        idproduk.Append("(")
                    End If
                    idproduk.Append("'" & id & "'")
                    If i = selectedBarcode.Count - 1 Then
                        idproduk.Append(")")
                    Else
                        idproduk.Append(",")
                        i += 1
                    End If

                Next

                Dim sqlbarcode As String =
                        "select *,(select count(idproduk) from tblharga where tblharga.idproduk = t.idproduk) as duplikasi from view_harga as t where barcode in " &
                        idproduk.ToString & " and cabang =" & Form1.idcabang & " order by rak, idproduk"


                Dim preview As CetakBarcode = New CetakBarcode()
                preview.sqlrak = sqlbarcode
                preview.awal()
                preview.ShowDialog()
                preview.Dispose()
                open = True
            End If
        Else
            dialogError("Pilih barang terlebih dahulu")
        End If
    End Sub

    Sub refreshSelected()
        For Each row As DataGridViewRow In ListSat.Rows
            Dim idbarang = row.Cells(8).Value.ToString
            Dim cell As DataGridViewCheckBoxCell = row.Cells(0)

            If selectedBarcode.IndexOf(idbarang) >= 0 Then
                cell.Value = True
            Else
                cell.Value = False
            End If
        Next
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim selectedAll As Boolean = False
        selectedList.Clear()
        selectedBarcode.Clear()

        For Each row As DataGridViewRow In ListSat.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells(0)
            If IsNothing(cell.Value) Then
                cell.Value = False

            End If

            If Not cell.Value.ToString = "True" Then
                selectedAll = True
                Exit For
            End If
        Next

        For Each row As DataGridViewRow In ListSat.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells(0)
            If selectedAll Then
                selectedList.Add(row.Cells(1).Value.ToString)
                selectedBarcode.Add(row.Cells(8).Value.ToString)
                cell.Value = True
            Else
                cell.Value = False
            End If
        Next
    End Sub

    Private Sub ListSat_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles ListSat.CellValueChanged


        If e.RowIndex > - 1 And e.ColumnIndex = 0 Then
            Dim row = ListSat.Rows(e.RowIndex)
            Dim idbarang = row.Cells(1).Value.ToString
            Dim barcode = row.Cells(8).Value.ToString
            Dim cell As DataGridViewCheckBoxCell = row.Cells(0)

            If Not cell.Value.ToString = "True" Then

                If selectedList.IndexOf(idbarang) >= 0 Then
                    selectedList.RemoveAt(selectedList.IndexOf(idbarang))
                End If
                If selectedBarcode.IndexOf(barcode) >= 0 Then
                    selectedBarcode.RemoveAt(selectedBarcode.IndexOf(barcode))
                End If

            Else
                If selectedList.IndexOf(idbarang) < 0 Then
                    selectedList.Add(idbarang)
                End If

                If selectedBarcode.IndexOf(barcode) < 0 Then
                    selectedBarcode.Add(barcode)
                End If

            End If
        End If
    End Sub

    Private Sub ListSat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles ListSat.CellContentClick
        ListSat.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick

        ListSat.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub ListSat_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) _
        Handles ListSat.CurrentCellDirtyStateChanged
        ListSat.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If (selectedBarcode.Count > 0) Then
            If open Then
                open = False
                Dim idproduk As New StringBuilder()
                Dim i As Integer = 0
                For Each id As String In selectedBarcode
                    If i = 0 Then
                        idproduk.Append("(")
                    End If
                    idproduk.Append("'" & id & "'")
                    If i = selectedBarcode.Count - 1 Then
                        idproduk.Append(")")
                    Else
                        idproduk.Append(",")
                        i += 1
                    End If

                Next

                Dim sqlbarcode As String =
                        "select idproduk, produk, hargajual, rak,  CASE WHEN tipedata=1 THEN stok3 * konversi1 * konversi2 + stok2 * konversi1 + stok1 WHEN tipedata=2 THEN stok2 + stok3 * konversi2 ELSE stok3 END as stok, satuan from view_harga WHERE barcode in " &
                        idproduk.ToString & " and cabang=" & Form1.idcabang
                Debug.Write(sqlbarcode)
                Dim preview As CetakDetail = New CetakDetail()
                preview.sql = sqlbarcode
                preview.a4 = True
                preview.ShowDialog()
                preview.Dispose()
                open = True
            End If
        Else
            dialogError("Pilih barang terlebih dahulu")
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (selectedBarcode.Count > 0) Then
            If open Then
                open = False
                Dim idproduk As New StringBuilder()
                Dim i As Integer = 0
                For Each id As String In selectedBarcode
                    If i = 0 Then
                        idproduk.Append("(")
                    End If
                    idproduk.Append("'" & id & "'")
                    If i = selectedBarcode.Count - 1 Then
                        idproduk.Append(")")
                    Else
                        idproduk.Append(",")
                        i += 1
                    End If

                Next

                Dim sqlbarcode As String =
                        "select idproduk, produk, hargajual, rak,  CASE WHEN tipedata=1 THEN stok3 * konversi1 * konversi2 + stok2 * konversi1 + stok1 WHEN tipedata=2 THEN stok2 + stok3 * konversi2 ELSE stok3 END as stok, satuan from view_harga WHERE barcode in " &
                        idproduk.ToString & " and cabang=" & Form1.idcabang
                Debug.Write(sqlbarcode)
                Dim preview As CetakDetail = New CetakDetail()
                preview.sql = sqlbarcode

                preview.ShowDialog()
                preview.Dispose()
                open = True
            End If
        Else
            dialogError("Pilih barang terlebih dahulu")
        End If
    End Sub
End Class