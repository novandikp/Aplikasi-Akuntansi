Imports System.ComponentModel
Imports Npgsql

Public Class FormFakturBeli
    Public edited As Boolean = False
    Dim cari As Boolean = False
    Dim status As Boolean = True
    Dim ubah As Int32 = 0
    Private Sub eventDatagridBerubah(sender As Object, e As DataGridViewCellEventArgs) Handles dgKeranjang.CellValueChanged
        If cari Then
            Return
        End If

        If Not IsNothing(dgKeranjang.CurrentRow) Then
            Dim dgvRow As DataGridViewRow = dgKeranjang.CurrentRow
            baris = e.RowIndex
            If status And Not IsNothing(dgvRow.Cells(1).Value) Then
                Dim subtotal As Double = toDouble(dgvRow.Cells(5).Value.ToString) * toDouble(dgvRow.Cells(3).Value.ToString) * (100 - toDouble(dgvRow.Cells(12).Value.ToString)) / 100
                Dim subpajak As Double = subtotal * (toDouble(dgvRow.Cells(8).Value.ToString)) / 100
                If e.ColumnIndex = 5 Or e.ColumnIndex = 12 Then
                    status = False
                    dgvRow.Cells(6).Value = subpajak
                    dgvRow.Cells(7).Value = subtotal + subpajak
                    status = True
                    ubah = 6
                ElseIf e.ColumnIndex = 3 Then
                    status = False
                    ubah = 7
                    If toDouble(dgvRow.Cells(3).Value.ToString) = 0 Then
                        dgvRow.Cells(3).Value = "1,00"
                    End If
                    dgvRow.Cells(6).Value = subpajak
                    dgvRow.Cells(7).Value = subtotal + subpajak
                    status = True
                    updateBaris()
                    ubah = 7

                End If
            End If
        End If
    End Sub

    Private Sub btnCariPenawaran_Click(sender As Object, e As EventArgs) Handles btnCariPenawaran.Click
        cariPenawaranJual()
    End Sub

    Private Sub FormPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub cariBtn(sender As Object, e As EventArgs) Handles btnCariPelanggan.Click
        cariPelanggan()
    End Sub


    Private Sub eventCariProduk(sender As Object, e As KeyEventArgs) Handles tbKodeProduk.KeyDown
        If e.KeyCode = Keys.Enter Then
            inputProduk()
        ElseIf e.KeyCode = Keys.Down Then
            Me.ActiveControl = dgKeranjang
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgKeranjang.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 10 And Not IsNothing(sender.Rows(e.RowIndex).Cells(10).Value) Then
                hapusItemKeranjang(e.RowIndex)
            End If
        End If
    End Sub
    Private Sub afterEdit(sender As Object, e As EventArgs) Handles dgKeranjang.SelectionChanged
        If cari Then
            Return
        End If
        Try
            If ubah = 3 Then
                ubah = 0
                dgKeranjang.BeginEdit(True)
                dgKeranjang.CurrentCell = dgKeranjang.Rows(baris).Cells(3)
            ElseIf ubah = 1 Then
                ubah = 0
                dgKeranjang.CurrentCell = dgKeranjang.Rows(baris + 1).Cells(1)

            ElseIf ubah = 4 Then
                ubah = 0

                dgKeranjang.CurrentCell = dgKeranjang.Rows(baris).Cells(1)
            ElseIf ubah = 5 Then
                ubah = 0

                dgKeranjang.CurrentCell = dgKeranjang.Rows(baris).Cells(5)
            ElseIf ubah = 6 Then
                ubah = 0

                dgKeranjang.CurrentCell = dgKeranjang.Rows(baris).Cells(6)

            ElseIf ubah = 7 Then
                dgKeranjang.ClearSelection()
                Me.ActiveControl = tbKodeProduk
                ubah = 0
            End If

        Catch ex As Exception

        End Try

        getTotal()
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) _
        Handles dgKeranjang.CurrentCellDirtyStateChanged

        If Not IsNothing(dgKeranjang.CurrentCell) Then
            If dgKeranjang.CurrentCell.ColumnIndex = 4 Then
                dgKeranjang.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End If
    End Sub

    Private Sub eventKeyboardDatagrid(sender As Object, e As KeyEventArgs) Handles dgKeranjang.KeyDown

        Dim rowNumber As Integer = 0
        If Not IsNothing(dgKeranjang.CurrentCell) Then
            rowNumber = dgKeranjang.CurrentCell.ColumnIndex
        End If
        Try
            If e.KeyCode = Keys.Delete Then
                hapusItemKeranjang()
            ElseIf e.KeyCode = Keys.Enter And rowNumber = 3 Then
                e.SuppressKeyPress = True
                dgKeranjang.ClearSelection()
                Me.ActiveControl = tbKodeProduk
            ElseIf e.KeyCode = Keys.Enter And rowNumber = 5 Then
                e.SuppressKeyPress = True
                dgKeranjang.ClearSelection()
                Me.ActiveControl = tbKodeProduk
            ElseIf e.Control And e.KeyCode = Keys.Up Then
                dgKeranjang.ClearSelection()
                Me.ActiveControl = tbKodeProduk
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub errorHandlerDGV(sender As Object, e As DataGridViewDataErrorEventArgs) _
        Handles dgKeranjang.DataError
        If e.ColumnIndex = 4 Then
            e.Cancel = True
        ElseIf e.ColumnIndex = 3 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 12 Then
            e.Cancel = True
            dialogError("Masukkan digit dengan benar")
        End If
    End Sub

    Private Sub validatingInputDGV(sender As Object, e As DataGridViewEditingControlShowingEventArgs) _
        Handles dgKeranjang.EditingControlShowing
        If dgKeranjang.CurrentCell.ColumnIndex = 3 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf numberWithComma
        ElseIf dgKeranjang.CurrentCell.ColumnIndex = 5 Or dgKeranjang.CurrentCell.ColumnIndex = 6 Or dgKeranjang.CurrentCell.ColumnIndex = 12 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf numberOnly
        Else
            Try
                AddHandler CType(e.Control, TextBox).KeyPress, AddressOf disableValidated
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub numberWithComma(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ",") Then e.Handled = True
        End If
    End Sub

    Private Sub numberOnly(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar)))) Then e.Handled = True
        End If
    End Sub

    Private Sub disableValidated(sender As Object, e As KeyPressEventArgs)
        e.Handled = False
    End Sub


    Private Sub handlerAllComponent(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If dgKeranjang.Focused Then
            Else
                dgKeranjang.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            cariProduk()
        ElseIf e.KeyCode = Keys.F6 Then
            dtTanggal.Focus()
        ElseIf e.KeyCode = Keys.F12 Then
            bayar()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
    End Sub


    '======================= END EVENT

    Sub cariPenawaranJual()
        If Not edited Then
            Dim dialog As New DialogPesananJual
            If dialog.ShowDialog = DialogResult.OK Then
                tbPenawaranJual.Text = dialog.kodepesananjual
                getDataFromPenawaran()
            End If
            dialog.Dispose()
        End If
    End Sub

    Sub addhandlertoAllComponent()
        For Each komponen As Control In Me.Controls
            AddHandler komponen.KeyDown, AddressOf handlerAllComponent
            If komponen.Controls.Count > 0 Then
                For Each komponen2 As Control In komponen.Controls
                    AddHandler komponen2.KeyDown, AddressOf handlerAllComponent
                    If komponen2.Controls.Count > 0 Then
                        For Each komponen3 As Control In komponen2.Controls
                            AddHandler komponen3.KeyDown, AddressOf handlerAllComponent
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Sub awal()
        styliseDG(dgKeranjang)
        addhandlertoAllComponent()
        saved = False
        setGudang()
        setDepartemen()
        setProjek()
        getPelanggan()
        setTableColumn()
        TBuser.Text = Form1.username
        TBdept.Text = Form1.role
        If edited Then
            continueOrder()
            btnCariPenawaran.Enabled = False
        Else
            btnCariPenawaran.Enabled = True
            TBnotransaksi.Text = generateRefrence("PJ")

        End If
        getTotal()
        Me.ActiveControl = tbKodeProduk
    End Sub


    Sub inputProduk()
        Dim row = dgKeranjang.Rows.Count - 1
        Dim queryCari = "select idharga, idbarang,tblproduk.statusproduk, produk,hargabeli, hargabeli,satuan, tblpajak.persenpajak, nilaidasar  from tblharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan inner join tblpajak on tblpajak.kodepajak = tblproduk.pajakbeli where idproduk='" + tbKodeProduk.Text + "' and statusproduk=1"
        Dim dataproduk As DataTable = getData(queryCari)
        status = False
        Dim dgvrow As DataGridViewRow = dgKeranjang.Rows(0).Clone
        If countTable(dataproduk) = 1 Then
            Dim defaultsatuan = dataproduk.Rows(0).Item("idharga")
            If Not dontDuplicate(defaultsatuan) Then
                Return
            End If
            cari = True
            dgvrow.Cells(1).Value = dataproduk.Rows(0).Item("idbarang")
            dgvrow.Cells(2).Value = dataproduk.Rows(0).Item("produk")
            dgvrow.Cells(3).Value = "1,00"
            dgvrow.Cells(1).ReadOnly = True
            dgvrow.Cells(2).ReadOnly = True
            dgvrow.Cells(6).Value = "0"
            dgvrow.Cells(9).Value = defaultsatuan
            dgvrow.Cells(4).Value = dataproduk.Rows(0).Item("satuan")
            dgvrow.Cells(5).Value = dataproduk.Rows(0).Item("hargabeli")
            dgvrow.Cells(8).Value = dataproduk.Rows(0).Item("persenpajak")

            Dim pajak As Double = dataproduk.Rows(0).Item("hargabeli") * (dataproduk.Rows(0).Item("persenpajak") / 100)
            dgvrow.Cells(6).Value = pajak
            dgvrow.Cells(6).ReadOnly = True
            dgvrow.Cells(7).Value = dataproduk.Rows(0).Item("hargabeli") + pajak
            Dim colButtonDelete As DataGridViewButtonCell
            dgvrow.Cells(11).Value = dataproduk.Rows(0).Item("nilaidasar")
            dgvrow.Cells(12).Value = 0
            colButtonDelete = dgvrow.Cells(10)
            colButtonDelete.Value = "Hapus"
            dgvrow.Cells(10).ReadOnly = True
            dgKeranjang.Rows.Insert(row, dgvrow)
            cari = False
            dgvrow.Cells(0).ReadOnly = True
            tbKodeProduk.Text = ""
            Me.ActiveControl = dgKeranjang
            dgKeranjang.CurrentCell = dgKeranjang.Rows(row).Cells(3)
            baris = row
            status = True
            updateBaris()
            Me.ActiveControl = dgKeranjang
        Else
            cariProduk()
        End If
    End Sub

    Sub hapusItemKeranjang(Optional index As Integer = -1)
        If dgKeranjang.SelectedCells.Count = 0 Then
            dialogError("Plih item terlebih dahulu")
        Else
            If (index < 0) Then
                index = dgKeranjang.CurrentCell.RowIndex
            End If
            If dialog("Apakah anda yakin untuk menghapus " & dgKeranjang.Rows(index).Cells(2).Value.ToString & " ?") Then
                Dim idbarang = dgKeranjang.Rows(index).Cells(1).Value.ToString
                dgKeranjang.Rows.RemoveAt(index)
                updateBaris()
                dgKeranjang.ClearSelection()
                Me.ActiveControl = tbKodeProduk
            End If

        End If
    End Sub

    'Isi Comboboxpelanggan
    Sub getPelanggan()
        CBsupplier.DataSource = getData("select idpelanggan, pelanggan from tblkontak WHERE posisi LIKE '%Pelanggan%'")
        CBsupplier.DisplayMember = "pelanggan"
        CBsupplier.ValueMember = "idpelanggan"
        CBsupplier.SelectedIndex = 0
    End Sub

    'Isi Gudang
    Sub setGudang()
        Dim sqlgudang As String = "select idgudang, gudang from tblgudang order by gudang"
        cbGudang.DataSource = getData(sqlgudang)
        cbGudang.ValueMember = "idgudang"
        cbGudang.DisplayMember = "gudang"
        cbGudang.SelectedIndex = 0
    End Sub

    'isi Departemen
    Sub setDepartemen()
        Dim sqldepartemen As String = "select iddepartemen, departemen from tbldepartemen order by departemen"
        ComboBox1.DataSource = getData(sqldepartemen)
        ComboBox1.ValueMember = "iddepartemen"
        ComboBox1.DisplayMember = "departemen"
        ComboBox1.SelectedIndex = 0
    End Sub
    Function dontDuplicate(barcode As String, Optional jumlah As Double = 1) As Boolean
        Dim dup = True
        For Each row As DataGridViewRow In dgKeranjang.Rows
            Dim defsat As String = ""
            If Not IsNothing(row.Cells(9).Value) Then
                defsat = row.Cells(9).Value.ToString
            End If
            If defsat.Equals(barcode) Then
                dup = False
                tbKodeProduk.Text = ""
                Me.ActiveControl = dgKeranjang
                dgKeranjang.CurrentCell = row.Cells(3)
                baris = row.Index
                status = True
                cari = False
                ubah = 3


                row.Cells(3).Value = toDouble(row.Cells(3).Value) + jumlah
                Dim subtotal As Double = toDouble(row.Cells(5).Value.ToString) * toDouble(row.Cells(3).Value.ToString) * (100 - toDouble(row.Cells(12).Value.ToString)) / 100
                Dim subpajak As Double = subtotal * (toDouble(row.Cells(8).Value.ToString)) / 100
                row.Cells(6).Value = subpajak
                row.Cells(7).Value = subtotal + subpajak
                updateBaris()
                Exit For
            End If
        Next


        Return dup
    End Function

    'Cari Produk
    Sub cariProduk()
        Dim dialog As New DialogProduk
        If Not IsNothing(cbGudang.SelectedValue) Then
            dialog.idgudang = cbGudang.SelectedValue
        End If
        dialog.visibleHargaBeli = False
        dialog.visibleHPP = False
        dialog.eCari.Text = tbKodeProduk.Text
        Dim dialogResult As DialogResult = dialog.ShowDialog
        If dialogResult = DialogResult.OK Then
            Dim queryCari = "select idharga, idbarang,tblproduk.statusproduk,nilaidasar, produk,hargabeli, hargabeli,satuan, tblpajak.persenpajak  from tblharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan inner join tblpajak on tblpajak.kodepajak = tblproduk.pajakbeli where idharga=" + dialog.idharga
            Dim row = dgKeranjang.Rows.Count - 1
            Dim dataproduk As DataTable = getData(queryCari)
            status = False
            Dim dgvrow As DataGridViewRow = dgKeranjang.Rows(0).Clone
            Dim defaultsatuan = dataproduk.Rows(0).Item("idharga")
            If Not dontDuplicate(defaultsatuan) Then
                Return
            End If
            cari = True
            dgvrow.Cells(1).Value = dataproduk.Rows(0).Item("idbarang")
            dgvrow.Cells(2).Value = dataproduk.Rows(0).Item("produk")
            dgvrow.Cells(3).Value = "1,00"
            dgvrow.Cells(1).ReadOnly = True
            dgvrow.Cells(2).ReadOnly = True
            dgvrow.Cells(6).Value = "0"
            dgvrow.Cells(9).Value = defaultsatuan
            dgvrow.Cells(4).Value = dataproduk.Rows(0).Item("satuan")
            dgvrow.Cells(5).Value = dataproduk.Rows(0).Item("hargabeli")

            dgvrow.Cells(8).Value = dataproduk.Rows(0).Item("persenpajak")
            dgvrow.Cells(11).Value = dataproduk.Rows(0).Item("nilaidasar")
            dgvrow.Cells(12).Value = 0
            Dim pajak As Double = dataproduk.Rows(0).Item("hargabeli") * (dataproduk.Rows(0).Item("persenpajak") / 100)
            dgvrow.Cells(6).Value = pajak
            dgvrow.Cells(6).ReadOnly = True
            dgvrow.Cells(7).Value = dataproduk.Rows(0).Item("hargabeli") + pajak
            Dim colButtonDelete As DataGridViewButtonCell
            colButtonDelete = dgvrow.Cells(10)
            colButtonDelete.Value = "Hapus"
            dgvrow.Cells(10).ReadOnly = True
            dgKeranjang.Rows.Insert(row, dgvrow)
            cari = False
            dgvrow.Cells(0).ReadOnly = True
            tbKodeProduk.Text = ""
            Me.ActiveControl = dgKeranjang
            dgKeranjang.CurrentCell = dgKeranjang.Rows(row).Cells(3)
            baris = row
            status = True
            updateBaris()
            Me.ActiveControl = dgKeranjang
            tbKodeProduk.Text = ""
        End If
    End Sub
    'SetColumn datagridview
    Sub setTableColumn()
        dgKeranjang.Columns(12).DisplayIndex = 5
        dgKeranjang.Columns(3).ValueType = GetType(Double)
        dgKeranjang.Columns(5).ValueType = GetType(Double)
        dgKeranjang.Columns(6).ValueType = GetType(Double)
        dgKeranjang.Columns(8).ValueType = GetType(Double)
        dgKeranjang.Columns(12).ValueType = GetType(Double)
        dgKeranjang.Columns(0).ReadOnly = True
        dgKeranjang.Columns(1).ReadOnly = True
        dgKeranjang.Columns(2).ReadOnly = True
        dgKeranjang.Columns(7).ReadOnly = True
        dgKeranjang.Columns(7).DefaultCellStyle.Format = "C2"
        dgKeranjang.Rows.Clear()
    End Sub
    'cari pelanggan
    Sub cariPelanggan()
        Dim dialogPelanggan As New DialogKontak
        dialogPelanggan.posisi = "Pelanggan"
        If dialogPelanggan.ShowDialog = DialogResult.OK Then
            CBsupplier.SelectedValue = dialogPelanggan.idpelanggan
        End If
        dialogPelanggan.Dispose()
    End Sub
    'set projek
    Sub setProjek()
        cbProjek.DataSource = getData("SELECT idprojek, projek from tblprojek")
        cbProjek.DisplayMember = "projek"
        cbProjek.ValueMember = "idprojek"
        cbProjek.SelectedIndex = -1
    End Sub

    Sub clearRow(row As Integer)
        dgKeranjang.Rows(row).Cells(0).Value = ""
        dgKeranjang.Rows(row).Cells(1).Value = ""
        dgKeranjang.Rows(row).Cells(1).ReadOnly = False
        dgKeranjang.Rows(row).Cells(2).Value = ""
        dgKeranjang.Rows(row).Cells(3).Value = "1,0"
        dgKeranjang.Rows(row).Cells(5).Value = ""
        dgKeranjang.Rows(row).Cells(6).Value = ""
        dgKeranjang.Rows(row).Cells(7).Value = ""
        Dim dgvcc As DataGridViewComboBoxCell
        dgvcc = dgKeranjang.Rows(row).Cells(4)
        dgKeranjang.Rows.RemoveAt(row)
        dgvcc.DataSource = Nothing
        updateBaris()
        cari = False
        If dgKeranjang.Focused Then
        Else
            Me.ActiveControl = dgKeranjang
            dgKeranjang.Focus()
        End If
    End Sub

    Sub updateBaris()
        cari = True
        For Each row As DataGridViewRow In dgKeranjang.Rows
            Try
                If IsNothing(row.Cells(1).Value) Then
                    dgKeranjang.Rows.RemoveAt(row.Index)
                ElseIf String.IsNullOrWhiteSpace(row.Cells(1).Value.ToString) Then
                    dgKeranjang.Rows.RemoveAt(row.Index)
                Else
                End If
            Catch ex As Exception
            End Try
        Next
        getTotal()
        cari = False
    End Sub

    Sub getTotal()
        Dim total As Double = 0
        For Each row As DataGridViewRow In dgKeranjang.Rows
            If Not IsNothing(row.Cells(5).Value) Then
                If Double.TryParse(row.Cells(5).Value.ToString, 0) Then
                    total += (toDouble(row.Cells(5).Value.ToString) * toDouble(row.Cells(3).Value.ToString) *
                             (100 - toDouble(row.Cells(12).Value.ToString)) / 100) *
                             (100 + toDouble(row.Cells(8).Value.ToString)) / 100
                End If

            End If

        Next
        lblGrandTotal.Text = numberFor(total.ToString)
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Public saved As Boolean = False
    Public idor = "0"
    Dim baris = 0
    Dim kolum = 0


    Sub getDataFromPenawaran()
        Dim sqlorder As String = "select kodepesananbeli, tglpesananbeli, kodedepartemen, kodeprojek, total, diskonrupiah, diskonpersen, totalpajak, biayalain, kasbiayalain, kasdiskon, nomerdokumen, tgldokumen, pelanggan, kodegudang from tblpesananbeli where kodepesananbeli='" & tbPenawaranJual.Text & "'"
        Dim sqldetail As String = "select tbldetailpesananbeli.idharga,diskondetailpersen,nilaidasar,idproduk,produk, idbarang,jumlahbeli, tbldetailpesananbeli.hargabeli,satuan,jumlahpajak from  tbldetailpesananbeli  inner join tblharga on tblharga.idharga = tbldetailpesananbeli.idharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan where kodepesananbeli='" & tbPenawaranJual.Text & "'"

        If String.IsNullOrEmpty(tbPenawaranJual.Text) Then
            Return
        End If
        saved = True
        dgKeranjang.Rows.Clear()
        CBsupplier.SelectedValue = getValue(sqlorder, "pelanggan")
        cbGudang.SelectedValue = getValue(sqlorder, "kodegudang")
        cbProjek.SelectedValue = getValue(sqlorder, "kodeprojek")

        Dim tableExist As DataTable = getData(sqldetail)
        Dim no = 0
        For Each row As DataRow In tableExist.Rows
            dgKeranjang.Rows.Add()
        Next
        cari = True
        For Each row As DataRow In tableExist.Rows

            dgKeranjang.Rows(no).Cells(1).Value = row.Item("idproduk").ToString
            dgKeranjang.Rows(no).Cells(11).Value = row.Item("nilaidasar").ToString
            dgKeranjang.Rows(no).Cells(2).Value = row.Item("produk").ToString
            dgKeranjang.Rows(no).Cells(3).Value = row.Item("jumlahbeli").ToString
            dgKeranjang.Rows(no).Cells(4).Value = row.Item("satuan").ToString
            dgKeranjang.Rows(no).Cells(5).Value = row.Item("hargabeli").ToString
            dgKeranjang.Rows(no).Cells(6).Value = row.Item("jumlahpajak").ToString
            dgKeranjang.Rows(no).Cells(12).Value = row.Item("diskondetailpersen").ToString
            Dim subtotal As Double = toDouble(dgKeranjang.Rows(no).Cells(5).Value.ToString) * toDouble(dgKeranjang.Rows(no).Cells(3).Value.ToString) * (100 - toDouble(dgKeranjang.Rows(no).Cells(12).Value.ToString)) / 100
            dgKeranjang.Rows(no).Cells(7).Value = subtotal + toDouble(row.Item("jumlahpajak"))
            If toDouble(dgKeranjang.Rows(no).Cells(6).Value.ToString) = 0 Then
                dgKeranjang.Rows(no).Cells(8).Value = 0
            Else
                dgKeranjang.Rows(no).Cells(8).Value = subtotal / toDouble(dgKeranjang.Rows(no).Cells(6).Value.ToString)
            End If

            dgKeranjang.Rows(no).Cells(9).Value = row.Item("idharga").ToString
            dgKeranjang.Rows(no).Cells(10).Value = "Hapus"
            dgKeranjang.Rows(no).Cells(1).ReadOnly = True
            dgKeranjang.Rows(no).Cells(2).ReadOnly = True
            dgKeranjang.Rows(no).Cells(4).ReadOnly = True
            dgKeranjang.Rows(no).Cells(10).ReadOnly = True
            If True Then
                cari = True

            Else
                clearRow(no)
            End If

            no += 1

        Next
        cari = False

        dgKeranjang.Columns(3).ValueType = GetType(Double)
        dgKeranjang.Columns(0).ReadOnly = True
        dgKeranjang.Columns(2).ReadOnly = True
        dgKeranjang.Columns(7).ReadOnly = True
        dgKeranjang.Columns(7).DefaultCellStyle.Format = "C2"
        getTotal()
        idor = ""
        updateBaris()
        dgKeranjang.ClearSelection()
        Me.ActiveControl = tbKodeProduk
    End Sub

    Sub continueOrder()
        Dim sqlorder As String = "select kodebeli,kodepesananbeli, tglbeli, kodedepartemen, kodeprojek, total, diskonrupiah, diskonpersen, totalpajak, biayalain, kasbiayalain, kasdiskon, nomerdokumen, tgldokumen, pelanggan, kodegudang from tblbeli where kodebeli='" & TBnotransaksi.Text & "'"
        Dim sqldetail As String = "select tbldetailbeli.idharga,diskondetailpersen,idproduk,nilaidasar,produk, idbarang,jumlahbeli, tbldetailbeli.hargabeli,satuan,jumlahpajak from  tbldetailbeli  inner join tblharga on tblharga.idharga = tbldetailbeli.idharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan where kodebeli='" & TBnotransaksi.Text & "'"
        saved = True
        dgKeranjang.Rows.Clear()
        CBsupplier.SelectedValue = getValue(sqlorder, "pelanggan")
        cbGudang.SelectedValue = getValue(sqlorder, "kodegudang")
        cbProjek.SelectedValue = getValue(sqlorder, "kodeprojek")
        tbPenawaranJual.Text = getValue(sqlorder, "kodepesananbeli")
        Dim tableExist As DataTable = getData(sqldetail)
        Dim no = 0
        For Each row As DataRow In tableExist.Rows
            dgKeranjang.Rows.Add()
        Next

        For Each row As DataRow In tableExist.Rows
            cari = True
            dgKeranjang.Rows(no).Cells(1).Value = row.Item("idproduk").ToString
            dgKeranjang.Rows(no).Cells(11).Value = row.Item("nilaidasar").ToString
            dgKeranjang.Rows(no).Cells(2).Value = row.Item("produk").ToString
            dgKeranjang.Rows(no).Cells(3).Value = row.Item("jumlahbeli").ToString
            dgKeranjang.Rows(no).Cells(4).Value = row.Item("satuan").ToString
            dgKeranjang.Rows(no).Cells(5).Value = row.Item("hargabeli").ToString
            dgKeranjang.Rows(no).Cells(6).Value = row.Item("jumlahpajak").ToString
            dgKeranjang.Rows(no).Cells(12).Value = row.Item("diskondetailpersen").ToString
            Dim subtotal As Double = toDouble(dgKeranjang.Rows(no).Cells(5).Value.ToString) * toDouble(dgKeranjang.Rows(no).Cells(3).Value.ToString) * (100 - toDouble(dgKeranjang.Rows(no).Cells(12).Value.ToString)) / 100
            dgKeranjang.Rows(no).Cells(7).Value = subtotal + toDouble(row.Item("jumlahpajak"))
            If toDouble(dgKeranjang.Rows(no).Cells(6).Value.ToString) = 0 Then
                dgKeranjang.Rows(no).Cells(8).Value = 0
            Else
                dgKeranjang.Rows(no).Cells(8).Value = subtotal / toDouble(dgKeranjang.Rows(no).Cells(6).Value.ToString)
            End If

            dgKeranjang.Rows(no).Cells(9).Value = row.Item("idharga").ToString
            dgKeranjang.Rows(no).Cells(10).Value = "Hapus"
            dgKeranjang.Rows(no).Cells(1).ReadOnly = True
            dgKeranjang.Rows(no).Cells(2).ReadOnly = True
            dgKeranjang.Rows(no).Cells(4).ReadOnly = True
            dgKeranjang.Rows(no).Cells(10).ReadOnly = True
            If True Then
                cari = True
            Else
                clearRow(no)
            End If
            cari = False
            no += 1
        Next
        dgKeranjang.Columns(3).ValueType = GetType(Double)
        dgKeranjang.Columns(0).ReadOnly = True
        dgKeranjang.Columns(2).ReadOnly = True
        dgKeranjang.Columns(7).ReadOnly = True
        dgKeranjang.Columns(7).DefaultCellStyle.Format = "C2"
        getTotal()
        idor = ""

        updateBaris()
        dgKeranjang.ClearSelection()
        Me.ActiveControl = tbKodeProduk
    End Sub



    Function cekKeranjang(Optional stokis As Boolean = False) As Boolean
        Dim total As Double = 0
        Dim idbarang As String = "("
        For Each row As DataGridViewRow In dgKeranjang.Rows
            If Not IsNothing(row.Cells(5).Value) And Not IsNothing(row.Cells(1).Value) And Not IsNothing(row.Cells(9).Value) Then
                idbarang &= "'" & CStr(row.Cells(1).Value) & "',"
                If Double.TryParse(row.Cells(5).Value.ToString, 0) Then
                    total += toDouble(row.Cells(5).Value.ToString) * toDouble(row.Cells(3).Value.ToString) *
                             (100 - toDouble(row.Cells(6).Value.ToString)) / 100
                End If
            End If
        Next
        idbarang = idbarang.Substring(0, idbarang.Length - 1) & ")"

        If total = 0 Or dgKeranjang.Rows.Count = 0 Then
            dialogError("Keranjang masih kosong")
            Return False
        Else
            Dim Condition As Boolean = True
            Dim sql = "SELECT sum(tblharga.nilaidasar* COALESCE(stok,0)) as stok,tblharga.idbarang,COALESCE(T.nilaidasar,0) as nilaidasar2,COALESCE(B.nilaidasar ,0) as nilaidasar3, 
Y.idharga as id1,T.idharga as id2,B.idharga as id3
from tblharga left join tblstokgudang on tblstokgudang.idharga = tblharga.idharga  and (idgudang='" & cbGudang.SelectedValue & "' OR idgudang is NULL)  
left join tblharga Y on Y.idbarang  = tblharga.idbarang and Y.level =1
left join tblharga T on T.idbarang  = tblharga.idbarang and T.level =2
left join tblharga B on B.idbarang  = tblharga.idbarang and B.level =3
where tblharga.idbarang in " & idbarang & "
GROUP by  tblharga.idbarang,T.nilaidasar, B.nilaidasar,T.idharga,B.idharga ,Y.idharga "
            Debug.WriteLine(sql)
            Dim dt As DataTable = getData(sql)

            For Each rowStok As DataRow In dt.Rows
                For Each rowKeranjang As DataGridViewRow In dgKeranjang.Rows
                    If rowKeranjang.Cells(1).Value = rowStok.Item("idbarang") Then
                        rowStok.Item("stok") = rowStok.Item("stok") - rowKeranjang.Cells(3).Value * rowKeranjang.Cells(11).Value
                    End If
                Next

                If edited And rowStok.Item("stok") < 0 Then
                    Dim sqlCheckOldDetail = "SELECT COALESCE(sum(jumlahbeli*nilaidasar),0) as total FROM tbldetailbeli inner join tblharga on tblharga.idharga = tbldetailbeli.idharga WHERE tbldetailbeli.kodebeli = '" & TBnotransaksi.Text & "' and idbarang ='" & rowStok.Item("idbarang") & "'"
                    If rowStok.Item("stok") + toDouble(getValue(sqlCheckOldDetail, "total")) < 0 Then
                        dialogError("Stok dari " & rowStok.Item("idbarang") & " tidak mencukupi")
                        Condition = False
                        Exit For
                    End If

                ElseIf rowStok.Item("stok") < 0 Then
                    dialogError("Stok dari " & rowStok.Item("idbarang") & " tidak mencukupi")
                    Condition = False
                    Exit For
                End If
            Next
            'Kurangi Stok
            If stokis And Condition Then
                'Hapus Stok yang telah ada
                For Each rowStok As DataRow In dt.Rows
                    If IsDBNull(rowStok.Item("id2")) Then
                        'Cuman satu
                        exc("INSERT INTO public.tblstokgudang(idgudang, stok, idharga) VALUES ( '" & cbGudang.SelectedValue & "', " & rowStok.Item("stok").ToString().Replace(",", ".") & " ," & rowStok.Item("id1") & ") ON CONFLICT  (idgudang,idharga) DO UPDATE  set stok =  EXCLUDED.stok")
                    ElseIf IsDBNull(rowStok.Item("id3")) Then
                        'Cuman dua
                        Dim stok2 As Double = rowStok.Item("stok") \ rowStok.Item("nilaidasar2")
                        Dim stok1 As Double = rowStok.Item("stok") - (stok2 * rowStok.Item("nilaidasar2"))
                        exc("INSERT INTO public.tblstokgudang(idgudang, stok, idharga) VALUES ( '" & cbGudang.SelectedValue & "', " & stok2.ToString().Replace(",", ".") & " ," & rowStok.Item("id2") & ") ON CONFLICT  (idgudang,idharga) DO UPDATE  set stok =  EXCLUDED.stok")
                        exc("INSERT INTO public.tblstokgudang(idgudang, stok, idharga) VALUES ( '" & cbGudang.SelectedValue & "', " & stok1.ToString().Replace(",", ".") & " ," & rowStok.Item("id1") & ") ON CONFLICT  (idgudang,idharga) DO UPDATE  set stok =  EXCLUDED.stok")
                    Else
                        'Ada semua
                        'Cuman dua
                        Dim stok3 As Double = rowStok.Item("stok") \ rowStok.Item("nilaidasar3")
                        Dim stok2 As Double = (rowStok.Item("stok") - (stok3 * rowStok.Item("nilaidasar3"))) \ rowStok.Item("nilaidasar2")
                        Dim stok1 As Double = rowStok.Item("stok") - (stok2 * rowStok.Item("nilaidasar2")) - (stok3 * rowStok.Item("nilaidasar3"))
                        exc("INSERT INTO public.tblstokgudang(idgudang, stok, idharga) VALUES ( '" & cbGudang.SelectedValue & "', " & stok3.ToString().Replace(",", ".") & " ," & rowStok.Item("id3") & ") ON CONFLICT  (idgudang,idharga) DO UPDATE  set stok =  EXCLUDED.stok")
                        exc("INSERT INTO public.tblstokgudang(idgudang, stok, idharga) VALUES ( '" & cbGudang.SelectedValue & "', " & stok2.ToString().Replace(",", ".") & " ," & rowStok.Item("id2") & ") ON CONFLICT  (idgudang,idharga) DO UPDATE  set stok =  EXCLUDED.stok")
                        exc("INSERT INTO public.tblstokgudang(idgudang, stok, idharga) VALUES ( '" & cbGudang.SelectedValue & "', " & stok1.ToString().Replace(",", ".") & " ," & rowStok.Item("id1") & ") ON CONFLICT  (idgudang,idharga) DO UPDATE  set stok =  EXCLUDED.stok")
                    End If
                Next
            End If
            Return Condition
        End If
    End Function


    Private Sub Button9_Click(sender As Object, e As EventArgs)
        closeTab()
    End Sub
    Sub simpanBayar(bayar As DialogTransaksiBayar)

        Dim kodeprojek As String
        If cbProjek.SelectedIndex < 0 Then
            kodeprojek = "NULL"
        Else
            kodeprojek = cbProjek.SelectedValue
        End If


        Dim kodepesanan As String
        If String.IsNullOrEmpty(tbPenawaranJual.Text) Then
            kodepesanan = "NULL"
        Else
            kodepesanan = tbPenawaranJual.Text
        End If

        Dim t As Double = 0
        For Each row As DataGridViewRow In dgKeranjang.Rows
            If Not IsNothing(row.Cells(5).Value) Then
                If Double.TryParse(row.Cells(5).Value.ToString, 0) Then
                    t += toDouble(row.Cells(5).Value.ToString) * toDouble(row.Cells(3).Value.ToString)
                End If
            End If
        Next
        If cekKeranjang(True) Then
            Dim pembayaran As Double = bayar.bayar
            Dim grandTotal As Double = bayar.grandtotalResult
            Dim kembali As Double = pembayaran - grandTotal
            If Not edited Then
                Dim isidata As String() = {bayar.kasPenerimaaan, pembayaran.ToString, kembali.ToString, TBnotransaksi.Text, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), ComboBox1.SelectedValue, kodeprojek, bayar.total.ToString, bayar.diskonRupiah.ToString, bayar.diskonPersen.ToString, bayar.totalpajak.ToString, bayar.biayaLain.ToString, bayar.kasBiayaLain.ToString, bayar.kasDiskon.ToString, bayar.nomerDokumen, bayar.tglDokumen, CBsupplier.SelectedValue, cbGudang.SelectedValue, "0", kodepesanan}
                Dim sql As String = "INSERT INTO public.tblbeli(kaspenerimaan, bayar, kembali,kodebeli, tglbeli, kodedepartemen, kodeprojek, total, diskonrupiah, diskonpersen, totalpajak, biayalain, kasbiayalain, kasdiskon, nomerdokumen, tgldokumen, pelanggan, kodegudang, statusbeli,kodepesananbeli) 	VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?);"
                If operationQuery(sql, isidata) Then

                    isidetail(TBnotransaksi.Text, bayar)
                    dialogSukses("Berhasil")
                    restartControl()

                End If
            Else
                Dim isidata As String() = {bayar.kasPenerimaaan, pembayaran.ToString, kembali.ToString, TBnotransaksi.Text, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), ComboBox1.SelectedValue, kodeprojek, bayar.total.ToString, bayar.diskonRupiah.ToString, bayar.diskonPersen.ToString, bayar.totalpajak.ToString, bayar.biayaLain.ToString, bayar.kasBiayaLain.ToString, bayar.kasDiskon.ToString, bayar.nomerDokumen, bayar.tglDokumen, CBsupplier.SelectedValue, cbGudang.SelectedValue, kodepesanan, TBnotransaksi.Text, TBnotransaksi.Text, TBnotransaksi.Text, TBnotransaksi.Text}
                Dim sql As String = "UPDATE public.tblbeli SET kaspenerimaan=?, bayar=?, kembali=?  ,  kodebeli=?, tglbeli=?, kodedepartemen=?, kodeprojek=?, total=?, diskonrupiah=?, diskonpersen=?, totalpajak=?, biayalain=?, kasbiayalain=?, kasdiskon=?, nomerdokumen=?, tgldokumen=?, pelanggan=?, kodegudang=?,kodepesananbeli=? where kodebeli=?;DELETE FROM tbldetailbeli where kodebeli=?;DELETE FROM tblhistoristok where refrensi=?;DELETE FROM tbljurnal WHERE koderefrensi=?;"
                exc("update tblstokgudang set stok = stok + sub.jumlahbeli from ( SELECT tbldetailbeli.idharga, tbldetailbeli.jumlahbeli,tblbeli.kodegudang, tbldetailbeli.kodebeli from tbldetailbeli  inner join tblbeli on tbldetailbeli.kodebeli = tblbeli.kodebeli ) sub where tblstokgudang.idharga = sub.idharga and tblstokgudang.idgudang= sub.kodegudang and kodebeli='" & TBnotransaksi.Text & "'")
                If operationQuery(sql, isidata) Then


                    isidetail(TBnotransaksi.Text, bayar)
                    dialogSukses("Berhasil")
                    edited = False
                    restartControl()
                    btnCariPenawaran.Enabled = True
                End If
            End If

        End If

    End Sub

    Sub restartControl()
        Me.Controls.Clear()
        InitializeComponent()
        awal()
    End Sub

    Sub isidetail(refrensi As String, bayar As DialogTransaksiBayar)
        Dim Totalhpp As Double = 0
        Dim totalPenbelian As Double = 0
        For Each row As DataGridViewRow In dgKeranjang.Rows
            If Not IsNothing(row.Cells(1).Value) Then
                'Ambil hpp
                Dim sqlhpp As String = "SELECT hpp from tblharga where idharga=" & row.Cells(9).Value
                Dim hpp As Double = getValue(sqlhpp, "hpp")
                Totalhpp = Totalhpp + (hpp * row.Cells(3).Value())
                totalPenbelian = totalPenbelian + (row.Cells(5).Value * row.Cells(3).Value * (100 - row.Cells(12).Value) / 100)

                Dim sqldetail As String = "INSERT INTO public.tbldetailbeli(kodebeli, jumlahbeli, hargabeli, jumlahpajak, catatandetail, idharga,diskondetailpersen)	VALUES ( ?, ?, ?, ?, ?, ?,?);"
                Dim data As String() = {refrensi, row.Cells(3).Value.ToString.Replace(",", "."), row.Cells(5).Value.ToString, row.Cells(6).Value.ToString, "-", row.Cells(9).Value.ToString, row.Cells(12).Value.ToString}
                If operationQuery(sqldetail, data) Then
                    Dim sqlHistoriStok As String = "INSERT INTO public.tblhistoristok(masuk, keluar, harga, tglhistori, idharga, refrensi, hpp) VALUES ( ?, ?, ?, ?, ?, ?, ?);"
                    Dim dataHistori As String() = {"0", row.Cells(3).Value.ToString.Replace(",", "."), row.Cells(5).Value.ToString, dtTanggal.Value.ToString("yyyy-MM-dd"), row.Cells(9).Value, TBnotransaksi.Text, hpp.ToString}

                    operationQuery(sqlHistoriStok, dataHistori)
                End If
            End If
        Next
        Dim kodeprojek As String
        If cbProjek.SelectedIndex < 0 Then
            kodeprojek = "NULL"
        Else
            kodeprojek = cbProjek.SelectedValue
        End If

        Dim sqlJurnal As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);"
        Dim kembali As Double = bayar.bayar - bayar.grandtotalResult

        'Default Akun
        Dim akunPersediaan As String = "110004"
        Dim akunHPP As String = "510001"
        Dim akunPiutangUsaha As String = "130001"
        Dim akunPenbelianProduk As String = "410001"
        Dim akunUtangPajak As String = "230001"


        'Penbelian Produk
        Dim dataPenbelianProduk As String() = {akunPenbelianProduk, kodeprojek, ComboBox1.SelectedValue, CBsupplier.SelectedValue, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", totalPenbelian.ToString, "PJ", TBnotransaksi.Text, "Faktur Penbelian, " & CBsupplier.Text}
        operationQuery(sqlJurnal, dataPenbelianProduk)


        'Piutang Usaha
        If kembali < 0 Then

            Dim dataPiutangUsaha As String() = {akunPiutangUsaha, kodeprojek, ComboBox1.SelectedValue, CBsupplier.SelectedValue, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), (kembali * -1).ToString, "0", "PJ", TBnotransaksi.Text, "Faktur Penbelian, " & CBsupplier.Text}
            operationQuery(sqlJurnal, dataPiutangUsaha)
            exc("INSERT into tblhistoripiutang (idjurnal) select idjurnal from tbljurnal where koderefrensi='" & TBnotransaksi.Text & "' AND kodeakun='" & akunPiutangUsaha & "'")
        End If

        'Uang Muka 
        If bayar.bayar > 0 And kembali < 0 Then
            Dim dataPembayaran As String() = {bayar.kasPenerimaaan, kodeprojek, ComboBox1.SelectedValue, CBsupplier.SelectedValue, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), bayar.bayar.ToString, "0", "PJ", TBnotransaksi.Text, "Faktur Penbelian, " & CBsupplier.Text}
            operationQuery(sqlJurnal, dataPembayaran)
        ElseIf bayar.bayar > 0 And kembali >= 0 Then
            'Pembayaran
            Dim total As Double = bayar.grandtotalResult
            Dim dataPembayaran As String() = {bayar.kasPenerimaaan, kodeprojek, ComboBox1.SelectedValue, CBsupplier.SelectedValue, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), total.ToString, "0", "PJ", TBnotransaksi.Text, "Faktur Penbelian, " & CBsupplier.Text}
            operationQuery(sqlJurnal, dataPembayaran)
        End If


        'Biaya lain
        If bayar.biayaLain > 0 Then
            Dim dataBiayaLain As String() = {bayar.kasBiayaLain, kodeprojek, ComboBox1.SelectedValue, CBsupplier.SelectedValue, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", bayar.biayaLain.ToString, "PJ", TBnotransaksi.Text, "Faktur Penbelian, " & CBsupplier.Text}
            operationQuery(sqlJurnal, dataBiayaLain)
        End If

        'Potongan Harga
        If bayar.diskonRupiah > 0 Then
            Dim dataDiskonDebit As String() = {bayar.kasDiskon, kodeprojek, ComboBox1.SelectedValue, CBsupplier.SelectedValue, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), bayar.diskonRupiah.ToString, "0", "PJ", TBnotransaksi.Text, "Faktur Penbelian, " & CBsupplier.Text}
            operationQuery(sqlJurnal, dataDiskonDebit)
        End If

        'Insert Pajaknya
        Dim diskonSisa As Double = 100 - bayar.diskonPersen
        Dim sqlpajak As String = "INSERT INTO public.tbljurnal(kodeakun, kodeprojek, kodedepartemen, kontak, tgljurnal, debit, kredit, tipe, koderefrensi, deskripsijurnal) select COALESCE(tblpajak.akunpajakbeli,'" & akunUtangPajak & "')," & kodeprojek & ",'" & ComboBox1.SelectedValue & "', " & CBsupplier.SelectedValue & ",'" & dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "',0, sum(jumlahpajak) * " & diskonSisa.ToString & "/100,'PJ','" & TBnotransaksi.Text & "','" & "Faktur Penbelian, " & CBsupplier.Text & "'  from tbldetailbeli inner join tblharga on tblharga.idharga = tbldetailbeli.idharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblpajak on tblpajak.kodepajak = tblproduk.pajakbeli where kodebeli='" & TBnotransaksi.Text & "' GROUP BY tblpajak.akunpajakbeli"
        exc(sqlpajak)



        'HPP dan Persediaan

        Dim dataDebit As String() = {akunHPP, kodeprojek, ComboBox1.SelectedValue, CBsupplier.SelectedValue, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), Totalhpp, "0", "PJ", TBnotransaksi.Text, "Faktur Penbelian, " & CBsupplier.Text}
        Dim dataKredit As String() = {akunPersediaan, kodeprojek, ComboBox1.SelectedValue, CBsupplier.SelectedValue, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "0", Totalhpp, "PJ", TBnotransaksi.Text, "Faktur Penbelian, " & CBsupplier.Text}

        operationQuery(sqlJurnal, dataDebit)
        operationQuery(sqlJurnal, dataKredit)


        exc("delete from tbljurnal where debit = 0 and kredit=0 and koderefrensi='" & TBnotransaksi.Text & "'")
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        bayar()
    End Sub

    Sub bayar()
        If dgKeranjang.Rows.Count > 1 Then
            If cekKeranjang() Then
                tampilkanDialogPembayaran()
            End If
        Else
            dialogError("Keranjang masih kosong")
        End If
    End Sub

    Sub tampilkanDialogPembayaran()
        Dim t As Double = 0
        Dim totalPajak As Double = 0
        For Each row As DataGridViewRow In dgKeranjang.Rows
            If Not IsNothing(row.Cells(5).Value) Then
                If Double.TryParse(row.Cells(5).Value.ToString, 0) Then
                    t += toDouble(row.Cells(5).Value.ToString) * toDouble(row.Cells(3).Value.ToString) * (100 - toDouble(row.Cells(12).Value.ToString)) / 100
                    totalPajak += toDouble(row.Cells(6).Value.ToString)
                End If
            End If
        Next
        Dim dialog As New DialogTransaksiBayar
        dialog.total = t
        dialog.totalpajak = totalPajak
        If edited Then
            dialog.tableRefrensi = "tblbeli"
            dialog.keyRefrensi = "kodebeli"
            dialog.refrensi = TBnotransaksi.Text
        ElseIf Not String.IsNullOrEmpty(tbPenawaranJual.Text) Then
            dialog.tableRefrensi = "tblpesananbeli"
            dialog.keyRefrensi = "kodepesananbeli"
            dialog.refrensi = tbPenawaranJual.Text
        End If

        If dialog.ShowDialog = DialogResult.OK Then

            simpanBayar(dialog)
        End If

        dialog.Dispose()
    End Sub

    Private Sub FormPenbelian_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not IsNothing(dgKeranjang.Rows(0).Cells(9).Value) Then
            e.Cancel = True
            If dialog("Apakah anda yakin ingin keluar dari transaksi  ?") Then
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        closeTab()
    End Sub

End Class