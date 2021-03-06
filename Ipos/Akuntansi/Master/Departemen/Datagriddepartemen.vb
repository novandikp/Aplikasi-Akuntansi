Public Class Datagriddepartemen
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
        setKontak()
        getDataProduk()
        eCari.Focus()
        addhandlertoAllComponent()
    End Sub

    Private Sub setKontak()
        Dim dt As DataTable = getData("SELECT idpelanggan,pelanggan from tblkontak where posisi ilike '%Pegawai%' order by pelanggan")
        cbKontak.DataSource = dt
        cbKontak.DisplayMember = "pelanggan"
        cbKontak.ValueMember = "idpelanggan"
        cbKontak.SelectedIndex = 0

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
        Dim sql As String = "SELECT iddepartemen, departemen, penanggunjawab, pelanggan, CAST(flagdepartemen as VARCHAR) from tbldepartemen inner join tblkontak on tbldepartemen.penanggunjawab = tblkontak.idpelanggan
        where departemen ilike '%" & eCari.Text & "%' or iddepartemen ilike '%" & eCari.Text & "%'"

        Me.ListSat.DataSource =
            getData(sql)

        Try
            ListSat.Columns(0).HeaderText = "Kode Departemen"
            ListSat.Columns(1).HeaderText = "Departemen"
            ListSat.Columns(3).HeaderText = "Penanggung Jawab"
            ListSat.Columns(2).Visible = False
            ListSat.Columns(4).HeaderText = "Status"
            For Each row As DataGridViewRow In ListSat.Rows
                row.Cells(4).Style.ForeColor = Color.White
                row.Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                If row.Cells(4).Value.ToString = "1" Then
                    row.Cells(4).Style.BackColor = Color.FromArgb(76, 175, 80)
                    row.Cells(4).Value = "Aktif"
                Else
                    row.Cells(4).Style.BackColor = Color.FromArgb(255, 87, 34)
                    row.Cells(4).Value = "Tidak Aktif"
                End If
            Next
        Catch ex As Exception
        End Try
        styliseDG(ListSat)
        makeFillDG(ListSat)
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
                If exc("delete from tbldepartemen where iddepartemen ='" & idselected & "'") Then
                    dialogSukses("Data berhasil dihapus")
                    getDataProduk()
                    dataFocus()
                Else
                    dialogError("Data gagal dihapus karena data sedang digunakan")
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        batal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dialogkontak As New DialogKontak
        dialogkontak.posisi = "Pegawai"
        Dim ds As DialogResult = dialogkontak.ShowDialog()
        If ds = DialogResult.OK Then
            cbKontak.SelectedValue = dialogkontak.idpelanggan

        End If
        dialogkontak.Dispose()
    End Sub

    Sub simpanData()
        If adaKosong(gbForm) Then
            dialogError("Masih ada form yang masih kosong")
        Else
            If String.IsNullOrEmpty(idselected) Then
                insert()
            Else
                update()
            End If
        End If

    End Sub

    Sub update()
        Dim sqlupdate As String = "UPDATE public.tbldepartemen 	SET iddepartemen=?, departemen=?, penanggunjawab=?, flagdepartemen=? where iddepartemen='" & idselected & "'"
        Dim isiData As String() = {TBKode.Text, TBNama.Text, cbKontak.SelectedValue, getStatus(cbStatus)}
        If operationQuery(sqlupdate, isiData) Then
            dialogSukses("Data berhasil diubah")
            getDataProduk()
            dataFocus()
        Else
            dialogError("Kode Departemen telah dipakai")
        End If
    End Sub

    Sub insert()
        Dim sqlinsert As String = "INSERT INTO public.tbldepartemen(	iddepartemen, departemen, penanggunjawab, flagdepartemen)	VALUES (?, ?, ?, ?);"
        Dim isiData As String() = {TBKode.Text, TBNama.Text, cbKontak.SelectedValue, getStatus(cbStatus)}
        If operationQuery(sqlinsert, isiData) Then
            dialogSukses("Data berhasil disimpan")
            getDataProduk()
            dataFocus()
        Else
            dialogError("Kode Departemen telah dipakai")
        End If
    End Sub

    Sub setDataSelected()
        Dim sqlselected As String = "SELECT iddepartemen, departemen, penanggunjawab, flagdepartemen 	FROM public.tbldepartemen where iddepartemen='" & idselected & "'"

        TBKode.Text = getValue(sqlselected, "iddepartemen")
        TBNama.Text = getValue(sqlselected, "departemen")
        cbKontak.SelectedValue = getValue(sqlselected, "penanggunjawab")
        setStatus(cbStatus, getValue(sqlselected, "flagdepartemen").ToString())

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
End Class