Public Class FormPembelian
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TBjam.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
        TBjam.Enabled = False
    End Sub


    Sub awal()
        CBMetode.Items.Clear()
        CBMetode.Items.Add("Tunai")

        getSupplier()
        TBuser.Text = Form1.username
        TBdept.Text = Form1.role
        DataGridView1.Columns(3).ValueType = GetType(Double)
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        TBnotransaksi.Text = ""
        DataGridView1.Columns(6).ReadOnly = True
        DataGridView1.Columns(8).ReadOnly = True

        Dim cbc As DataGridViewComboBoxColumn = DataGridView1.Columns(4)
        cbc.DataPropertyName = "barcode"

        DataGridView1.Columns(6).DefaultCellStyle.Format = "C2"
        DataGridView1.Rows.Clear()
        getTotal()
        styliseDG(DataGridView1)

        Me.ActiveControl = TBnotransaksi
    End Sub


    Sub getSupplier()
        CBsupplier.DataSource = getData("select supplier,idsupplier from tblsupplier where idcabang=" & Form1.idcabang)
        CBsupplier.DisplayMember = "supplier"
        CBsupplier.ValueMember = "idsupplier"
        Try
            CBsupplier.SelectedValue = 2
            If CBsupplier.SelectedValue = 2 Then
                CBMetode.SelectedIndex = 0
                If CBMetode.Items.Count = 2 Then
                    CBMetode.Items.RemoveAt(1)
                End If
                CBsupplier.BackColor = Color.Green
                CBsupplier.ForeColor = Color.White
            Else
                CBMetode.SelectedIndex = 0
                If CBMetode.Items.Count = 1 Then
                    CBMetode.Items.Add("Hutang")
                End If

                CBsupplier.BackColor = SystemColors.Control
                CBsupplier.ForeColor = SystemColors.ControlText
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Function dontDuplicate(barcode As String, Optional jumlah As Double = 1) As Boolean
        Dim dup = True

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim defsat As String = ""
            If Not IsNothing(row.Cells(7).Value) Then
                defsat = row.Cells(7).Value.ToString
            End If

            If defsat.Equals(barcode) Then
                dup = False
                TextBox1.Text = ""
                Me.ActiveControl = DataGridView1
                DataGridView1.CurrentCell = row.Cells(3)
                baris = row.Index
                status = True
                cari = False
                ubah = 3
                row.Cells(3).Value = toDouble(row.Cells(3).Value) + jumlah
                row.Cells(6).Value = toDouble(row.Cells(3).Value.ToString)*toDouble(row.Cells(5).Value.ToString)

                updateBaris()
                getTotal()
                Exit For
            End If
        Next
        If dup Then
            Debug.WriteLine("Tidak ada")
        Else
            Debug.WriteLine("ada")
        End If

        Return dup
    End Function

    Sub clearRow(row As Integer)
        DataGridView1.Rows(row).Cells(1).Value = ""
        DataGridView1.Rows(row).Cells(2).Value = ""
        DataGridView1.Rows(row).Cells(3).Value = "1,0"
        DataGridView1.Columns(5).ValueType = GetType(Double)
        DataGridView1.Rows(row).Cells(5).Value = ""
        cari = False
        updateBaris()
        Me.ActiveControl = DataGridView1
    End Sub


    Dim status As Boolean = True

    Dim ubah As Int32 = 0
    Dim baris = 0
    Dim kolum = 0
    Dim cari As Boolean = False

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellValueChanged
        If cari Then
            Return
        End If

        If Not IsNothing(DataGridView1.CurrentRow) Then
            Dim dgvRow As DataGridViewRow = DataGridView1.CurrentRow


            Dim query As String = ""

            baris = e.RowIndex
            If (e.ColumnIndex = 1) Then

                query = "SELECT produk FROM view_produk WHERE idproduk='" + dgvRow.Cells(1).Value.ToString +
                        "' and statusbarang=1"

                status = False

                If getCount(query) = 1 Then
                    cari = True
                    dgvRow.Cells(0).Value = baris + 1
                    dgvRow.Cells(2).Value = getValue(query, "produk")
                    dgvRow.Cells(3).Value = "1,00"
                    dgvRow.Cells(1).ReadOnly = True
                    dgvRow.Cells(2).ReadOnly = True
                    Dim defaultsatuan =
                            getValue(
                                "select barcode from view_harga where idproduk='" + dgvRow.Cells(1).Value.ToString + "'",
                                "barcode")
                    Dim dgvcc As DataGridViewComboBoxCell


                    Try
                        dgvcc = DataGridView1.Rows(e.RowIndex).Cells(4)
                        dgvcc.DataSource =
                            getData(
                                "select satuan from view_harga where idproduk='" + dgvRow.Cells(1).Value.ToString + "'")
                        dgvcc.DisplayMember = "satuan"
                        dgvcc.ValueMember = "barcode"
                        dgvcc.Value = defaultsatuan
                        Dim subquery As String = "SELECT hargabeli FROM tblharga where barcode=" &
                                                 DataGridView1.Rows(e.RowIndex).Cells(4).Value
                        dgvRow.Cells(5).Value = getValue(subquery, "hargabeli")
                        dgvRow.Cells(6).Value = Double.Parse(dgvRow.Cells(3).Value.ToString)*
                                                Double.Parse(dgvRow.Cells(5).Value.ToString)

                        updateBaris()
                    Catch ex As Exception

                    End Try
                    cari = False
                    ubah = 3
                    dgvRow.Cells(0).ReadOnly = True

                Else


                    CariProduk.eCari.Text = dgvRow.Cells(1).Value.ToString

                    CariProduk.getDataProduk()
                    CariProduk.row = e.RowIndex
                    CariProduk.tipe = 0
                    cari = True
                    Try
                        CariProduk.ShowDialog()
                        CariProduk.Dispose()
                    Catch ex As Exception

                    End Try

                End If


                If Not status Then

                    status = True
                End If
            ElseIf e.ColumnIndex = 0 Then

                ubah = 1
            ElseIf (e.ColumnIndex = 2) Then

                query = "SELECT idproduk FROM view_produk WHERE produk='" + dgvRow.Cells(2).Value.ToString +
                        "' and statusbarang=1"

                status = False
                If getCount(query) = 1 Then
                    cari = True
                    dgvRow.Cells(0).Value = baris + 1
                    dgvRow.Cells(1).Value = getValue(query, "idproduk")
                    dgvRow.Cells(3).Value = "1,00"
                    dgvRow.Cells(1).ReadOnly = True
                    dgvRow.Cells(2).ReadOnly = True
                    Dim defaultsatuan =
                            getValue(
                                "select barcode from view_harga where idproduk='" + dgvRow.Cells(1).Value.ToString + "'",
                                "barcode")
                    Dim dgvcc As DataGridViewComboBoxCell


                    Try
                        dgvcc = DataGridView1.Rows(e.RowIndex).Cells(4)
                        dgvcc.DataSource =
                            getData(
                                "select satuan,barcode from view_harga where idproduk='" +
                                dgvRow.Cells(1).Value.ToString + "'")
                        dgvcc.DisplayMember = "satuan"
                        dgvcc.ValueMember = "barcode"
                        dgvcc.Value = defaultsatuan
                        Dim subquery As String = "SELECT hargabeli FROM tblharga where barcode=" &
                                                 DataGridView1.Rows(e.RowIndex).Cells(4).Value
                        dgvRow.Cells(5).Value = getValue(subquery, "hargabeli")
                        dgvRow.Cells(6).Value = Double.Parse(dgvRow.Cells(3).Value.ToString)*
                                                Double.Parse(dgvRow.Cells(5).Value.ToString)
                        updateBaris()
                    Catch ex As Exception

                    End Try

                    cari = False
                    ubah = 3
                    dgvRow.Cells(0).ReadOnly = True

                Else


                    CariProduk.eCari.Text = dgvRow.Cells(2).Value.ToString

                    CariProduk.getDataProduk()
                    CariProduk.row = e.RowIndex
                    CariProduk.tipe = 0
                    cari = True
                    Try
                        CariProduk.ShowDialog()
                        CariProduk.Dispose()
                    Catch ex As Exception

                    End Try

                End If


                If Not status Then

                    status = True
                End If
            End If


            If IsNothing(dgvRow.Cells(1).Value) And Not e.ColumnIndex = 1 Then
                dgvRow.Cells(0).Value = ""
                dgvRow.Cells(1).Value = ""
                dgvRow.Cells(2).Value = ""
                dgvRow.Cells(3).Value = ""
                dgvRow.Cells(4).Value = ""
                dgvRow.Cells(5).Value = ""
                ubah = 4
            ElseIf String.IsNullOrWhiteSpace(dgvRow.Cells(1).Value.ToString) Then
                dgvRow.Cells(0).Value = ""
                dgvRow.Cells(1).Value = ""
                dgvRow.Cells(2).Value = ""
                dgvRow.Cells(3).Value = ""
                dgvRow.Cells(4).Value = ""
                dgvRow.Cells(5).Value = ""
                ubah = 4
            ElseIf status And Not IsNothing(dgvRow.Cells(0).Value) Then

                query = "SELECT * FROM view_barang WHERE idbarang='" + dgvRow.Cells(0).Value.ToString + "'"
                If e.ColumnIndex = 5 Then
                    If _
                        String.IsNullOrWhiteSpace(dgvRow.Cells(5).Value.ToString) Or
                        Not Double.TryParse(dgvRow.Cells(5).Value.ToString, 0) Then
                        status = False
                        Dim subquery As String = "SELECT hargabeli FROM tblharga where barcode=" &
                                                 DataGridView1.Rows(e.RowIndex).Cells(4).Value
                        dgvRow.Cells(5).Value = getValue(subquery, "hargabeli")
                        status = True
                    Else

                        status = False

                        dgvRow.Cells(6).Value = Double.Parse(dgvRow.Cells(3).Value.ToString)*
                                                Double.Parse(dgvRow.Cells(5).Value.ToString)
                        status = True
                    End If
                    ubah = 6
                ElseIf e.ColumnIndex = 3 Then
                    ubah = 5
                    If _
                        String.IsNullOrWhiteSpace(dgvRow.Cells(3).Value.ToString) Or
                        Not Double.TryParse(dgvRow.Cells(3).Value.ToString, 0) Then
                        status = False
                        dgvRow.Cells(3).Value = "1,00"
                        status = True
                    Else

                        status = False
                        Try
                            If Double.Parse(dgvRow.Cells(3).Value.ToString) = 0 Then
                                dgvRow.Cells(3).Value = "1,00"
                            End If
                            dgvRow.Cells(6).Value = Double.Parse(dgvRow.Cells(3).Value.ToString)*
                                                    Double.Parse(dgvRow.Cells(5).Value.ToString)
                        Catch ex As Exception

                        End Try

                        status = True
                    End If

                    ubah = 5
                ElseIf e.ColumnIndex = 4 Then
                    Try
                        Dim dgvcc As DataGridViewComboBoxCell
                        status = False
                        dgvcc = DataGridView1.Rows(e.RowIndex).Cells(4)
                        Dim subquery As String = "SELECT hargabeli FROM tblharga where barcode=" &
                                                 DataGridView1.Rows(e.RowIndex).Cells(4).Value
                        dgvRow.Cells(5).Value = getValue(subquery, "hargabeli")
                        dgvRow.Cells(6).Value = Double.Parse(dgvRow.Cells(3).Value.ToString)*
                                                Double.Parse(dgvRow.Cells(5).Value.ToString)
                        getTotal()
                    Catch ex As Exception

                    End Try

                    status = True
                    ubah = 5
                End If
            End If


        End If
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) _
        Handles DataGridView1.CurrentCellDirtyStateChanged

        If Not IsNothing(DataGridView1.CurrentCell) Then
            If DataGridView1.CurrentCell.ColumnIndex = 4 Then
                DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End If
    End Sub


    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        If ubah = 3 Then
            ubah = 0
            DataGridView1.BeginEdit(True)
            DataGridView1.CurrentCell = DataGridView1.Rows(baris).Cells(3)
        ElseIf ubah = 1 Then
            ubah = 0
            DataGridView1.CurrentCell = DataGridView1.Rows(baris + 1).Cells(1)

        ElseIf ubah = 4 Then
            ubah = 0

            DataGridView1.CurrentCell = DataGridView1.Rows(baris).Cells(1)
        ElseIf ubah = 5 Then
            ubah = 0

            DataGridView1.CurrentCell = DataGridView1.Rows(baris).Cells(5)
        ElseIf ubah = 6 Then
            DataGridView1.ClearSelection()
            Me.ActiveControl = TextBox1
            ubah = 0

        End If

        getTotal()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DataGridView1.SelectedCells.Count = 0 Then
                    dialogError("Plih item terlebih dahulu")
                Else
                    If _
                        dialog(
                            "Apakah anda yakin untuk menghapus " &
                            DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value.ToString & " ?") Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.CurrentCell.RowIndex)
                        updateBaris()
                    End If
                End If
            ElseIf e.KeyCode = Keys.Enter And DataGridView1.CurrentCell.ColumnIndex = 0 Then
                DataGridView1.CurrentCell = DataGridView1.Rows(baris).Cells(1)
            ElseIf e.KeyCode = Keys.Enter And DataGridView1.CurrentCell.ColumnIndex = 1 Then
                DataGridView1.CurrentCell = DataGridView1.Rows(baris).Cells(3)
            ElseIf e.KeyCode = Keys.Enter And DataGridView1.CurrentCell.ColumnIndex = 3 Then
                e.SuppressKeyPress = True
                DataGridView1.CurrentCell = DataGridView1.Rows(baris).Cells(5)
            ElseIf e.KeyCode = Keys.Enter And DataGridView1.CurrentCell.ColumnIndex = 5 Then
                e.SuppressKeyPress = True
                DataGridView1.ClearSelection()
                Me.ActiveControl = TextBox1
            ElseIf e.Control AndAlso e.KeyCode = Keys.Up Then
                DataGridView1.ClearSelection()
                Me.ActiveControl = TextBox1
            End If
        Catch ex As Exception

        End Try
    End Sub


    Sub getTotal()
        Dim total As Double = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not IsNothing(row.Cells(5).Value) Then
                If Double.TryParse(row.Cells(5).Value.ToString, 0) Then
                    total += Double.Parse(row.Cells(5).Value.ToString)*Double.Parse(row.Cells(3).Value.ToString)
                End If

            End If

        Next
        Label4.Text = numberFor(total.ToString)
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) _
        Handles DataGridView1.DataError

        If e.ColumnIndex = 4 Then
            e.Cancel = True

        ElseIf e.ColumnIndex = 3 Or e.ColumnIndex = 5 Then
            e.Cancel = True
            dialogError("Masukkan digit dengan benar")

        End If
    End Sub

    Private Sub ListLevel_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) _
        Handles DataGridView1.EditingControlShowing
        If DataGridView1.CurrentCell.ColumnIndex = 3 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress1
        ElseIf DataGridView1.CurrentCell.ColumnIndex = 5 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress2
        Else
            Try
                AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub TextBox_keyPress1(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ",") Then e.Handled = True
        End If
    End Sub

    Private Sub TextBox_keyPress2(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar)))) Then e.Handled = True
        End If
    End Sub

    Private Sub TextBox_keyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = False
    End Sub

    Sub closeTab()
        Me.Close()

        Dim listItemForms As FormPembelian = Application.OpenForms("FormPembelian")

        If Not IsNothing(listItemForms) Then
            listItemForms.Close()
            'Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Function cekKeranjang() As Boolean
        Dim total As Double = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not IsNothing(row.Cells(5).Value) Then
                If Double.TryParse(row.Cells(5).Value.ToString, 0) Then
                    total += Double.Parse(row.Cells(5).Value.ToString)*Double.Parse(row.Cells(3).Value.ToString)
                End If

            End If

        Next


        If total = 0 Then
            dialogError("Keranjang masih kosong")
            Return False
        ElseIf String.IsNullOrWhiteSpace(TBnotransaksi.Text) Then
            dialogError("Isi nomor transaksi terlebih dahulu")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        If cekKeranjang() Then

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CariSupplier.getDataPelanggan()
        CariSupplier.ShowDialog()
    End Sub

    Private Sub TBnotransak1si_KeyDown(sender As Object, e As KeyEventArgs) Handles TBnotransaksi.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = TextBox1
        End If
    End Sub

    Private Sub TBnotransaksi_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBuser.KeyDown, TBnotransaksi.KeyDown, TBjam.KeyDown, TBdept.KeyDown, MyBase.KeyDown, dtTanggal.KeyDown,
                DataGridView1.KeyDown, CBsupplier.KeyDown, CBMetode.KeyDown, Button9.KeyDown, Button7.KeyDown,
                Button10.KeyDown, Button1.KeyDown, TextBox1.KeyDown
        If e.KeyCode = Keys.F5 Then
            If DataGridView1.Focused Then

            Else
                DataGridView1.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            DataGridView1.ClearSelection()
            Me.ActiveControl = TextBox1
            SendKeys.Send("{ENTER}")
        ElseIf e.KeyCode = Keys.F6 Then
            TBnotransaksi.Focus()
        ElseIf e.KeyCode = Keys.F11 Then
            bayar()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
    End Sub

    Private Sub CBsupplier_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles CBsupplier.SelectedIndexChanged
        Try
            If CBsupplier.SelectedValue = 2 Then
                CBMetode.SelectedIndex = 0
                If CBMetode.Items.Count = 2 Then
                    CBMetode.Items.RemoveAt(1)
                End If
                CBsupplier.BackColor = Color.Green
                CBsupplier.ForeColor = Color.White
            Else
                CBMetode.SelectedIndex = 0
                If CBMetode.Items.Count = 1 Then
                    CBMetode.Items.Add("Hutang")
                End If

                CBsupplier.BackColor = SystemColors.Control
                CBsupplier.ForeColor = SystemColors.ControlText
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub updateBaris()
        cari = True

        Dim nomer = 1
        For Each row As DataGridViewRow In DataGridView1.Rows
            Try
                If IsNothing(row.Cells(1).Value) Then
                    DataGridView1.Rows.RemoveAt(row.Index)

                ElseIf String.IsNullOrWhiteSpace(row.Cells(1).Value.ToString) Then
                    DataGridView1.Rows.RemoveAt(row.Index)
                End If
            Catch ex As Exception

            End Try
        Next
        cari = False
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            If DataGridView1.SelectedCells.Count = 0 Then
                dialogError("Plih item terlebih dahulu")
            Else
                If Not IsNothing(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value) Then
                    If _
                        dialog(
                            "Apakah anda yakin untuk menghapus " &
                            DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value.ToString & " ?") Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.CurrentCell.RowIndex)
                        updateBaris()
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        bayar()
    End Sub

    Sub bayar()
        If Not limit("tblbeli") Then
            Return
        End If
        If cekKeranjang() Then
            Dim t As Double = 0
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not IsNothing(row.Cells(5).Value) Then
                    If Double.TryParse(row.Cells(5).Value.ToString, 0) Then
                        t += Double.Parse(row.Cells(5).Value.ToString)*Double.Parse(row.Cells(3).Value.ToString)
                    End If

                End If

            Next

            If CBMetode.SelectedIndex = 1 Then
                DialogBayarBeli.total = t
                DialogBayarBeli.datagridview = DataGridView1
                DialogBayarBeli.tgl = dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":")
                DialogBayarBeli.faktur = TBnotransaksi.Text
                DialogBayarBeli.supplier = CBsupplier.SelectedValue.ToString
                DialogBayarBeli.ShowDialog()
                DialogBayarBeli.Dispose()
            Else
                If dialog("Apakah anda yakin untuk menyimpan transaksi ini ?") Then
                    simpanBayar(t)
                End If
            End If


        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        closeTab()
    End Sub

    Sub simpanBayarHutang(total As Double, bayar As Double)
    End Sub


    Sub simpanBayar(total As Double)
        Dim bayar As Double = 0

        Dim hutang As Boolean = False
        If CBMetode.SelectedIndex = 1 Then
            hutang = True
        End If
        Dim kembali As Double = 0
        If CBMetode.SelectedIndex = 0 Then
            bayar = total
            kembali = 0
            DialogBayarBeli.hutang = False
        Else
            DialogBayarBeli.hutang = True
            bayar = 0
            kembali = total*- 1
        End If
        Dim isidata As String() = New String() _
                {TBnotransaksi.Text, dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), total.ToString,
                 bayar.ToString, kembali.ToString, CBsupplier.SelectedValue}
        Dim sql As String =
                "INSERT INTO tblbeli (fakturbeli, tglbeli, totalbeli, bayarbeli, kembalibeli, idsupplier) VALUES (?,?,?,?,?,?)"


        If exc(operationQueryString(sql, isidata)) Then
            If hutang Then
                Dim piutang As Double = total
                exc(
                    "update tblsupplier set piutang = piutang + " & piutang & " where idsupplier=" &
                    CBsupplier.SelectedValue)
                hutang = False
            End If
            Dim idbeli As String = getValue("SELECT idbeli from tblbeli order by idbeli desc", "idbeli")
            isidetail(idbeli)

            dialogInfo("Berhasil")
            Form1.refreshProduk()
            restartControl()
            ''Form1.openPembelian(True)

            '   Me.Close()
            '  closeTab()


        End If
    End Sub

    Sub restartControl()
        Me.Controls.Clear()
        InitializeComponent()
        awal()
    End Sub

    Sub isidetail(idbeli As String)
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not IsNothing(row.Cells(1).Value) Then
                Dim sql = "Select konversi1, konversi2, stok1, stok2, stok3 from tblproduk where idproduk='" &
                          row.Cells(1).Value.ToString & "'"
                If getCount(sql) > 0 Then

                    Dim idbarang = row.Cells(1).Value.ToString
                    Dim hargabeli As String = row.Cells(5).Value.ToString
                    Dim jumlah = row.Cells(3).Value.ToString
                    Dim subquery = "select satuan,tipedata from view_harga where barcode=" & row.Cells(7).Value.ToString
                    Dim satuan = getValue(subquery, "satuan")
                    Dim nilai As Double = 0
                    exc("update tblharga set hargabeli=" & hargabeli & " where barcode=" & row.Cells(7).Value.ToString)
                    Dim konversi1 As Double = Double.Parse(getValue(sql, "konversi1"))
                    Dim konversi2 As Double = konversi1*Double.Parse(getValue(sql, "konversi2"))
                    Dim tipedata = getValue(subquery, "tipedata")
                    If tipedata = "1" Then
                        nilai = Double.Parse(jumlah)

                    ElseIf tipedata = "2" Then
                        nilai = Double.Parse(jumlah)*konversi1
                    Else
                        nilai = Double.Parse(jumlah)*konversi2
                    End If
                    Dim expired As String = "-"
                    Dim batch = "-"
                    Dim querydetail =
                            "INSERT INTO tbldetailbeli (idbeli, barcode, hargabeli, jumlahbeli, satuanbeli, nilaibeli, expired, kodeproduksi) values (?,?,?,?,?,?,?,?)"
                    Dim datadetail As String() = New String() _
                            {idbeli, idbarang, hargabeli, jumlah.ToString.Replace(",", "."), satuan,
                             nilai.ToString.Replace(",", "."), expired, batch}
                    Debug.Write(operationQueryString(querydetail, datadetail))
                    If operationQuery(querydetail, datadetail) Then
                        'kartu stok
                        Dim datastok As String() = New String() _
                                {idbarang, jumlah.Replace(",", "."), satuan, nilai.ToString.Replace(",", "."),
                                 dtTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), "PEMBELIAN", idbeli}
                        Dim querystok =
                                "INSERT INTO tblstok (idproduk, tambahan, satuanstok, nilaidasar, tglstok, keterangan,idbeli) values (?,?,?,?,?,?,?)"
                        operationQuery(querystok, datastok)
                        'Pembagian Stok
                        Dim stok1 As Double = Double.Parse(getValue(sql, "stok1")),
                            stok2 As Double = Double.Parse(getValue(sql, "stok2")),
                            stok3 As Double = Double.Parse(getValue(sql, "stok3"))


                        If nilai Mod 1 = 0 Then
                            If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                stok3 += nilai\konversi2
                                nilai = nilai Mod konversi2
                            End If
                            If konversi1 <= nilai And konversi1 > 1 Then
                                stok2 += nilai\konversi1

                                nilai = nilai Mod konversi1
                            End If
                        Else
                            If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                                stok3 += Math.Floor(nilai/konversi2)
                                nilai -= Math.Floor(nilai/konversi2)*konversi2
                            End If
                            If konversi1 <= nilai And konversi1 > 1 Then
                                stok2 += Math.Floor(nilai/konversi1)

                                nilai -= Math.Floor(nilai/konversi1)*konversi1
                            End If
                        End If
                        stok1 += nilai
                        Dim databarang As String() = New String() _
                                {stok1.ToString.Replace(",", "."), stok2.ToString.Replace(",", "."),
                                 stok3.ToString.Replace(",", "."), idbarang}
                        Dim barangsql = "UPDATE tblproduk set stok1=?, stok2=?, stok3=? where idproduk=?"
                        operationQuery(barangsql, databarang)
                    End If

                End If
            End If
        Next
    End Sub


    Sub cariBarang(idbarang As String, row As Integer, Optional satuan As String = "")
        Dim QUERY = "SELECT produk FROM view_produk WHERE idproduk='" + idbarang + "' and statusbarang=1"
        Dim defaultsatuan
        If String.IsNullOrEmpty(satuan) Then
            defaultsatuan = getValue("select barcode from view_harga where idproduk='" + idbarang + "'", "barcode")
        Else
            defaultsatuan = Integer.Parse(satuan)
        End If
        If Not dontDuplicate(defaultsatuan) Then
            SendKeys.Send("{TAB}")

            Return
        End If

        Dim dgvrow As DataGridViewRow = DataGridView1.Rows(0).Clone
        dgvrow.Cells(0).Value = "a"
        dgvrow.Cells(1).Value = idbarang
        dgvrow.Cells(2).Value = getValue(QUERY, "produk")
        dgvrow.Cells(3).Value = "1,00"
        dgvrow.Cells(1).ReadOnly = True
        dgvrow.Cells(2).ReadOnly = True
        dgvrow.Cells(7).Value = defaultsatuan
        dgvrow.Cells(9).Value = "-"
        Dim dgvcc As DataGridViewComboBoxCell


        Try
            dgvcc = dgvrow.Cells(4)
            dgvcc.DataSource = getData("select satuan,barcode from view_harga where barcode=" & defaultsatuan)
            dgvcc.DisplayMember = "satuan"
            dgvcc.ValueMember = "barcode"

            dgvcc.Value = getData("select satuan,barcode from view_harga where barcode=" & defaultsatuan).Rows(0).Item(0)


            Dim subquery As String = "SELECT hargabeli FROM tblharga where barcode=" & defaultsatuan
            dgvrow.Cells(5).Value = getValue(subquery, "hargabeli")
            dgvrow.Cells(6).Value = Double.Parse(dgvrow.Cells(3).Value.ToString)*
                                    Double.Parse(dgvrow.Cells(5).Value.ToString)

        Catch ex As Exception

        End Try

        DataGridView1.Rows.Insert(row, dgvrow)
        '' initialize DateTimePicker


        dgvrow.Cells(0).ReadOnly = True
        updateBaris()
        getTotal()

        Me.ActiveControl = TextBox1

        baris = row
        status = True


        cari = False

        DataGridView1.CurrentCell = DataGridView1.Rows(row).Cells(2)


        SendKeys.Send("{TAB}")
        SendKeys.Send("{TAB}")
    End Sub

    Sub dtp_Text(sender As Object, e As KeyEventArgs)
    End Sub

    Private Sub TextBox1_KeyDown_1(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim row = DataGridView1.Rows.Count - 1

            Dim QUERY = "SELECT idproduk,produk FROM view_harga WHERE idproduk='" + TextBox1.Text +
                        "' and statusbarang=1 AND cabang=" & Form1.idcabang

            status = False
            Dim dgvrow As DataGridViewRow = DataGridView1.Rows(0).Clone
            If getCount(QUERY) = 1 Then

                Dim defaultsatuan = getValue("select barcode from view_harga where idproduk='" + TextBox1.Text + "'",
                                             "barcode")

                If Not dontDuplicate(defaultsatuan) Then
                    Return
                End If
                cari = True

                dgvrow.Cells(0).Value = row
                dgvrow.Cells(1).Value = getValue(QUERY, "idproduk")
                dgvrow.Cells(2).Value = getValue(QUERY, "produk")
                dgvrow.Cells(3).Value = "1,00"
                dgvrow.Cells(1).ReadOnly = True
                dgvrow.Cells(2).ReadOnly = True
                dgvrow.Cells(7).Value = defaultsatuan
                dgvrow.Cells(9).Value = "-"
                Dim dgvcc As DataGridViewComboBoxCell


                Try
                    dgvcc = dgvrow.Cells(4)
                    dgvcc.Items.Clear()
                    dgvcc.DataSource = getData("select satuan,barcode from view_harga where barcode=" & defaultsatuan)
                    dgvcc.DisplayMember = "satuan"
                    dgvcc.ValueMember = "barcode"
                    dgvcc.Value = defaultsatuan
                    Dim subquery As String = "SELECT hargabeli FROM tblharga where barcode=" & dgvrow.Cells(4).Value
                    'Stok Tersedia
                    'dgvRow.Cells(4).Value = Double.Parse(getValue(cektemp, "nilai")) / Double.Parse(getValue(subquery, "hargajual"))

                    dgvrow.Cells(5).Value = getValue(subquery, "hargabeli")
                    dgvrow.Cells(6).Value = Double.Parse(dgvrow.Cells(3).Value.ToString)*
                                            Double.Parse(dgvrow.Cells(5).Value.ToString)


                Catch ex As Exception

                End Try

                DataGridView1.Rows.Insert(row, dgvrow)
                cari = False

                dgvrow.Cells(0).ReadOnly = True

                getTotal()
                TextBox1.Text = ""
                Me.ActiveControl = DataGridView1
                '' initialize DateTimePicker


                DataGridView1.CurrentCell = DataGridView1.Rows(row).Cells(3)

                baris = row
                status = True
                updateBaris()

                Me.ActiveControl = DataGridView1
            Else


                CariProduk.eCari.Text = TextBox1.Text
                TextBox1.Text = ""
                CariProduk.getDataProduk()
                CariProduk.row = row
                CariProduk.tipe = 2

                Try
                    CariProduk.ShowDialog()
                    CariProduk.Dispose()
                Catch ex As Exception

                End Try
            End If
        ElseIf e.KeyCode = Keys.Down Then
            Me.ActiveControl = DataGridView1

        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellContentClick
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
    End Sub
End Class