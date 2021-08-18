Public Class DatagridAset
    Dim idselected As String = ""
    Dim onEditCurrency As Boolean = False
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
        dataFocus()
    End Sub

    Sub editCurrency(tb As TextBox)
        If Not onEditCurrency Then
            onEditCurrency = True
            tb.Text = numberFormat(tb.Text)
            tb.SelectionStart = tb.Text.Count
            tb.SelectionLength = 0
            onEditCurrency = False
        End If
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
        isiDataKategori()
        styliseDG(ListSat)

        fillData()
        eCari.Focus()
        addhandlertoAllComponent()
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


    Sub isiDataKategori()
        cbKategori.DataSource = getData("select idkategoriaset, kategoriaset from tblkategoriaset")
        cbKategori.DisplayMember = "kategoriaset"
        cbKategori.ValueMember = "idkategoriaset"
        cbKategori.SelectedIndex = 0
    End Sub

    Sub fillData()
        ListSat.ClearSelection()
        Dim sql As String = "SELECT kodeaset, tblaset.idkategoriaset, kategoriaset, aset, tanggaldapat, nilaibeli, nilairesidu
	    FROM public.tblaset inner join  tblkategoriaset on tblkategoriaset.idkategoriaset = tblaset.idkategoriaset where (kategoriaset ilike '%" & eCari.Text & "%' or aset ilike '%" & eCari.Text & "%' )"

        Me.ListSat.DataSource = getData(sql)

        Try

            ListSat.Columns(0).HeaderText = "Kode Aset"
            ListSat.Columns(1).Visible = False
            ListSat.Columns(2).HeaderText = "Kategori Aset"
            ListSat.Columns(3).HeaderText = "Aset"
            ListSat.Columns(4).HeaderText = "Tanggal Perolehan"
            ListSat.Columns(5).HeaderText = "Nilai Perolehan"
            ListSat.Columns(6).HeaderText = "Nilai Residu"

        Catch ex As Exception
        End Try
        styliseDG(ListSat)

    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
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
                If exc("delete from tblaset where kodeaset='" & idselected & "'") Then
                    dialogSukses("Data berhasil dihapus")
                    fillData()
                    dataFocus()
                Else
                    dialogError("Data gagal dihapus dikarenakan data sedang digunakan")
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


    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        batal()
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
        Dim sqlupdate As String = "UPDATE public.tblaset
	SET kodeaset=?, idkategoriaset=?, aset=?, tanggaldapat=?, nilaibeli=?, nilairesidu=? where kodeaset='" & idselected & "'"
        Dim isiData As String() = {tbKode.Text, cbKategori.SelectedValue, tbNama.Text, dtpOleh.Value.ToString("yyyy-MM-dd"), unnumberFormat(nilaiOleh.Text), unnumberFormat(nilaiResidu.Text)}
        If operationQuery(sqlupdate, isiData) Then
            dialogSukses("Data berhasil diubah")
            fillData()
            dataFocus()
        Else
            dialogError("Terdapat kesalahan saat input")
        End If
    End Sub

    Sub insert()
        Dim sqlinsert As String = "INSERT INTO public.tblaset(
	kodeaset, idkategoriaset, aset, tanggaldapat, nilaibeli, nilairesidu)
	VALUES (?, ?, ?, ?, ?, ?);"
        Dim isiData As String() = {tbKode.Text, cbKategori.SelectedValue, tbNama.Text, dtpOleh.Value.ToString("yyyy-MM-dd"), unnumberFormat(nilaiOleh.Text), unnumberFormat(nilaiResidu.Text)}
        If operationQuery(sqlinsert, isiData) Then
            dialogSukses("Data berhasil disimpan")
            fillData()
            dataFocus()
        Else
            dialogError("Terdapat kesalahan saat input")
        End If
    End Sub

    Sub setDataSelected()
        Dim sqlselected As String = "SELECT kodeaset, tblaset.idkategoriaset, aset, tanggaldapat, nilaibeli, nilairesidu
	FROM public.tblaset where kodeaset='" & idselected & "'"

        tbKode.Text = getValue(sqlselected, "kodeaset")
        tbNama.Text = getValue(sqlselected, "aset")
        cbKategori.SelectedValue = getValue(sqlselected, "idkategoriaset")
        dtpOleh.Value = getValue(sqlselected, "tanggaldapat")
        nilaiOleh.Text = numberFormat(getValue(sqlselected, "nilaibeli"))
        nilaiResidu.Text = numberFormat(getValue(sqlselected, "nilairesidu"))

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

    Private Sub TBNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nilaiOleh.KeyPress, nilaiResidu.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub gbForm_Enter(sender As Object, e As EventArgs) Handles gbForm.Enter

    End Sub

    Private Sub nilaiOleh_TextChanged(sender As Object, e As EventArgs) Handles nilaiResidu.TextChanged, nilaiOleh.TextChanged
        editCurrency(sender)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not String.IsNullOrEmpty(idselected) Then
            Datagridpenurunan.idaset = idselected
            Datagridpenurunan.ShowDialog()
            Datagridpenurunan.Dispose()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub
End Class