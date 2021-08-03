Public Class DatagridPajak
    Dim idselected As String = ""
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
        dataFocus()
    End Sub

    'Focus pada data
    Sub dataFocus()
        gbData.Enabled = True
        panelAksi.Enabled = True
        clearForm(gbForm)
        gbForm.Enabled = False
    End Sub

    'Focus pada form
    Sub formFocus(Optional clear As Boolean = False)
        If clear Then
            idselected = ""
            clearForm(gbForm)
        End If

        gbData.Enabled = False
        gbForm.Enabled = True
        panelAksi.Enabled = False
    End Sub


    Sub awal()
        styliseDG(ListSat)
        setAkunBeli()
        setAkunJual()
        getDataProduk()
        eCari.Focus()
        addhandlertoAllComponent()
    End Sub

    Private Sub setAkunBeli()
        Dim dt As DataTable = getData("SELECT kodeakun,akun from tblakun order by kodeakun")
        cbKontakBeli.DataSource = dt
        cbKontakBeli.DisplayMember = "akun"
        cbKontakBeli.ValueMember = "kodeakun"
        cbKontakBeli.SelectedIndex = 0

    End Sub

    Private Sub setAkunJual()
        Dim dt As DataTable = getData("SELECT kodeakun,akun from tblakun order by kodeakun")
        cbKontakJual.DataSource = dt
        cbKontakJual.DisplayMember = "akun"
        cbKontakJual.ValueMember = "kodeakun"
        cbKontakJual.SelectedIndex = 0

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

    Sub getDataProduk()
        ListSat.ClearSelection()
        Dim sql As String = "SELECT kodepajak, pajak, persenpajak,  akunpajakjual, pajakjual.akun as akunjual, akunpajakbeli, pajakbeli.akun as akunbeli,cast(flagpajak as varchar) from tblpajak inner join tblakun as pajakjual on pajakjual.kodeakun = tblpajak.akunpajakjual inner join tblakun as pajakbeli on pajakbeli.kodeakun = tblpajak.akunpajakbeli
        where pajak ilike '%" & eCari.Text & "%' or kodepajak ilike '%" & eCari.Text & "%'"

        Me.ListSat.DataSource =
            getData(sql)

        Try
            ListSat.Columns(0).HeaderText = "Kode Pajak"
            ListSat.Columns(1).HeaderText = "Pajak"
            ListSat.Columns(2).HeaderText = "Persen"
            ListSat.Columns(3).HeaderText = "Kode Akun Pajak Penjualan"
            ListSat.Columns(4).HeaderText = "Akun Pajak Penjualan"
            ListSat.Columns(5).HeaderText = "Kode Akun Pajak Pembelian"
            ListSat.Columns(6).HeaderText = "Akun Pajak Pembelian"
            ListSat.Columns(7).HeaderText = "Status"
            For Each row As DataGridViewRow In ListSat.Rows
                row.Cells(7).Style.ForeColor = Color.White
                row.Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                If row.Cells(7).Value.ToString = "1" Then
                    row.Cells(7).Style.BackColor = Color.FromArgb(76, 175, 80)
                    row.Cells(7).Value = "Aktif"
                Else
                    row.Cells(7).Style.BackColor = Color.FromArgb(255, 87, 34)
                    row.Cells(7).Value = "Tidak Aktif"
                End If
            Next
        Catch ex As Exception
        End Try
        styliseDG(ListSat)

        ListSat.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataProduk()
    End Sub


    Sub addhandlertoAllComponent()
        For Each komponen As Control In Me.Controls
            AddHandler komponen.KeyDown, AddressOf eventKeydown
            If komponen.Controls.Count > 0 Then
                For Each komponen2 As Control In komponen.Controls
                    AddHandler komponen2.KeyDown, AddressOf eventKeydown
                    If komponen2.Controls.Count > 0 Then
                        For Each komponen3 As Control In komponen2.Controls
                            AddHandler komponen3.KeyDown, AddressOf eventKeydown
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub eventKeydown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListSat.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListSat.Focus()
            If ListSat.Rows.Count > 0 Then
                ListSat.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            tambahData()
        ElseIf e.KeyCode = Keys.F2 Then
            editData()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusData()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        ElseIf e.KeyCode = Keys.Escape Then
            batal()
        End If
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Sub batal()
        dataFocus()
    End Sub

    Sub hapusData()
        If Not String.IsNullOrEmpty(idselected) Then
            If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                If exc("delete from tblpajak where kodepajak='" & idselected & "'") Then
                    dialogSukses("Data Berhasil dihapus")
                    getDataProduk()
                    dataFocus()
                Else
                    dialogError("Data gagal dihapus karena data telah digunakan")
                End If
            End If
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub editData()
        If Not String.IsNullOrEmpty(idselected) Then
            formFocus()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Sub tambahData()
        formFocus(True)
    End Sub

    Private Sub HpsBtn_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusData()
    End Sub

    Private Sub EdtBTN_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
        editData()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        closeTab()
    End Sub


    Private Sub btnKeluar_Click_1(sender As Object, e As EventArgs) Handles btnKeluar.Click
        closeTab()
    End Sub

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs)
        getDataProduk()
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahData()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dialogakun As New DialogAkun

        Dim ds As DialogResult = dialogakun.ShowDialog()
        If ds = DialogResult.OK Then
            cbKontakJual.SelectedValue = dialogakun.idakun

        End If
        dialogakun.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        batal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialogakun As New DialogAkun

        Dim ds As DialogResult = dialogakun.ShowDialog()
        If ds = DialogResult.OK Then
            cbKontakBeli.SelectedValue = dialogakun.idakun
        End If
        dialogakun.Dispose()
    End Sub



    Sub simpanData()
        If adaKosong(gbForm) Then
            dialogError("Masih ada form yang masih kosong")
        ElseIf Not Integer.TryParse(tbPersen.Text, 0) Then
            dialogError("Masukkan persentase dengan angka")
        ElseIf toDouble(tbPersen.Text) < -100 Or toDouble(tbPersen.Text) > 100 Then
            dialogError("Masukkan persentase dari -100 sampai 100")
        Else
            If String.IsNullOrEmpty(idselected) Then
                insert()
            Else
                update()
            End If
        End If

    End Sub

    Sub update()
        Dim sqlupdate As String = "UPDATE public.tblpajak
	SET kodepajak=?, pajak=?, persenpajak=?, flagpajak=?, akunpajakjual=?, akunpajakbeli=? where kodepajak='" & idselected & "'"
        Dim isiData As String() = {TBKode.Text, TBNama.Text, tbPersen.Text, getStatus(cbStatus), cbKontakJual.SelectedValue, cbKontakBeli.SelectedValue}
        If operationQuery(sqlupdate, isiData) Then
            dialogSukses("Data berhasil diubah")
            getDataProduk()
            dataFocus()
        Else
            dialogError("Kode Pajak telah dipakai")
        End If
    End Sub

    Sub insert()
        Dim sqlinsert As String = "INSERT INTO public.tblpajak(	kodepajak, pajak, persenpajak, flagpajak, akunpajakjual, akunpajakbeli) 	VALUES (?, ?, ?, ?, ?, ?);"
        Dim isiData As String() = {TBKode.Text, TBNama.Text, tbPersen.Text, getStatus(cbStatus), cbKontakJual.SelectedValue, cbKontakBeli.SelectedValue}
        If operationQuery(sqlinsert, isiData) Then
            dialogSukses("Data berhasil disimpan")
            getDataProduk()
            dataFocus()
        Else
            dialogError("Kode Pajak telah dipakai")
        End If
    End Sub

    Sub setDataSelected()
        Dim sqlselected As String = "SELECT kodepajak, pajak, persenpajak, flagpajak, akunpajakjual, akunpajakbeli
	FROM public.tblpajak where kodepajak='" & idselected & "'"

        TBKode.Text = getValue(sqlselected, "kodepajak")
        TBNama.Text = getValue(sqlselected, "pajak")
        tbPersen.Text = getValue(sqlselected, "persenpajak")
        cbKontakBeli.SelectedValue = getValue(sqlselected, "akunpajakbeli")
        cbKontakJual.SelectedValue = getValue(sqlselected, "akunpajakjual")
        setStatus(cbStatus, getValue(sqlselected, "flaggudang").ToString())

    End Sub



    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            idselected = ListSat.Rows(e.RowIndex).Cells(0).Value
            setDataSelected()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanData()
    End Sub

    Private Sub tbPersen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPersen.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) = 45 Then


            ElseIf Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True

            End If


        End If
    End Sub
End Class