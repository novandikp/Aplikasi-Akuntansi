Public Class DaftarPembelian
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListSat)
        'DTAwal.Value = New DateTime(Now.Year, Now.Month, 1)
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
        Dim awal = DTAwal.Value.ToString("yyyy/MM/dd")
        Dim akhir = DTAkhir.Value.ToString("yyyy/MM/dd")
        Me.ListSat.DataSource =
            getData(
                "SELECT idbeli, fakturbeli, tglbeli, supplier, totalbeli from view_beli where tglbeli  between ('" &
                awal & " 00:00:00') and ('" & akhir & " 23:59:59')  and idcabang = " & Form1.idcabang &
                " and (supplier LIKE '%" & eCari.Text & "%' OR fakturbeli LIKE '%" & eCari.Text & "%')")
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).Visible = False

            ListSat.Columns(1).HeaderText = "Faktur"
            ListSat.Columns(2).HeaderText = "Tanggal"
            ListSat.Columns(3).HeaderText = "Supplier"
            ListSat.Columns(4).HeaderText = "Total"
            ListSat.Columns(4).DefaultCellStyle.Format = "C2"


        Catch ex As Exception

        End Try
        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataPelanggan()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, eCari.KeyDown, ListSat.KeyDown, DTAkhir.KeyDown, DTAwal.KeyDown, Button2.KeyDown

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
        ElseIf e.KeyCode = Keys.F10 Then
            detail()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusPelanggan()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Dim listItemForms As DaftarPembelian = Application.OpenForms("DaftarPembelian")
        'listItemForms.Close()
        Me.Close()
        Return
        'Dim listItemForms As DaftarPembelian = Application.OpenForms("DaftarPembelian")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Function checkStok(idbarang As String) As Boolean

        Dim dgv As New DataTable


        dgv =
            getData(
                "SELECT barcode,Sum(tbldetailbeli.nilaibeli) AS nilai FROM tbldetailbeli where idbeli=" & idbarang &
                " GROUP BY tbldetailbeli.barcode;")
        For Each drow As DataRow In dgv.Rows

            Dim stoksaatini =
                    Double.Parse(
                        getValue(
                            "SELECT stok1 + stok2 * konversi1 + stok3 * konversi1*konversi2 as stok from tblproduk where idproduk ='" &
                            drow("barcode") & "';", "stok"))
            If stoksaatini < Double.Parse(drow("nilai")) Then
                Return False
            End If


        Next
        Return True
    End Function

    Sub hapusPelanggan()
        If ListSat.SelectedRows.Count = 1 Then

            Dim idbarang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value.ToString

            If Not checkStok(idbarang) Then
                dialogError("Stok tidak cukup")
                Return
            End If
            If getCount("select idbeli from view_returbeli where idbeli=" & idbarang) > 0 Then
                dialogError("Sudah terdapat retur")
                Return
            End If
            If True Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then
                    Dim dgv As New DataTable
                    dgv = getData("select * from view_detailbeli WHERE idbeli = " & idbarang)
                    For Each drow As DataRow In dgv.Rows
                        Dim produk = drow.Item("barcode")
                        Dim nilai As Double = Double.Parse(drow.Item("nilaibeli"))
                        Dim datastok As String() = New String() _
                                {drow.Item("barcode"), "-" & drow.Item("jumlahbeli"), drow.Item("satuanbeli"),
                                 nilai.ToString.Replace(",", "."),
                                 Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"),
                                 "SALAH PEMBELIAN " & idbarang, "0"}
                        Dim querystok =
                                "INSERT INTO tblstok (idproduk, tambahan, satuanstok, nilaidasar, tglstok, keterangan,idbeli) values (?,?,?,?,?,?,?)"
                        operationQuery(querystok, datastok)

                        'Pembagian Stok
                        Dim konversi1 As Double = Double.Parse(drow.Item("konversi1"))
                        Dim konversi2 As Double = konversi1*Double.Parse(drow.Item("konversi2"))
                        Dim stok1 As Double = Double.Parse(drow.Item("stok1")),
                            stok2 As Double = Double.Parse(drow.Item("stok2")),
                            stok3 As Double = Double.Parse(drow.Item("stok3"))
                        nilai = (stok1 + (stok2*konversi1) + (stok3*konversi2)) - nilai
                        If nilai Mod 1 = 0 Then
                            If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                stok3 = nilai\konversi2
                                nilai = nilai Mod konversi2
                            Else
                                stok3 = 0
                            End If


                            If konversi1 <= nilai And konversi1 > 1 Then
                                stok2 = nilai\konversi1

                                nilai = nilai Mod konversi1
                            Else
                                stok2 = 0
                            End If
                        Else
                            If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                stok3 = Math.Floor(nilai/konversi2)
                                nilai -= Math.Floor(nilai/konversi2)*konversi2
                            Else
                                stok3 = 0
                            End If


                            If konversi1 <= nilai And konversi1 > 1 Then
                                stok2 = Math.Floor(nilai/konversi1)

                                nilai -= Math.Floor(nilai/konversi1)*konversi1
                            Else
                                stok2 = 0
                            End If
                        End If


                        stok1 = nilai


                        Dim databarang As String() = New String() _
                                {stok1.ToString.Replace(",", "."), stok2.ToString.Replace(",", "."),
                                 stok3.ToString.Replace(",", "."), produk}
                        Dim barangsql = "UPDATE tblproduk set stok1=?, stok2=?, stok3=? where idproduk=?"
                        operationQuery(barangsql, databarang)


                    Next
                    exc("DELETE FROM tbldetailbeli WHERE idbeli = " & idbarang & "")
                    exc("DELETE FROM tblbeli WHERE idbeli = " & idbarang & "")

                    getDataPelanggan()
                    Form1.refreshProduk()
                End If
            Else
                dialogError("Pelanggan sedang dipakai")
            End If


        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub editPelanggan()
    End Sub

    Sub tambahPelanggan()
        Dim addItemForms As FormPembelian = Application.OpenForms("FormPembelian")
        If Not IsNothing(addItemForms) Then
            If dialog("Apakah anda yakin untuk menimpa form order yang telah dibuka") Then
                Form1.openPembelian(True)
            Else
                Form1.openPembelian(False)
            End If

        Else
            Form1.openPembelian(True)

        End If
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

    Private Sub DTAwal_ValueChanged(sender As Object, e As EventArgs) Handles DTAwal.ValueChanged

        getDataPelanggan()
    End Sub

    Private Sub DTAkhir_ValueChanged(sender As Object, e As EventArgs) Handles DTAkhir.ValueChanged
        getDataPelanggan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getDataPelanggan()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusPelanggan()
    End Sub

    Sub detail()
        If ListSat.SelectedRows.Count = 1 Then

            DetailPembelian.idjual = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            DetailPembelian.getDataProduk()
            DetailPembelian.ShowDialog()

        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        detail()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        closeTab()
    End Sub
End Class