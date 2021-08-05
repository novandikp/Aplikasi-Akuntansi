Public Class DatagridSub
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
        setKlasifikasi()
        fillData()
        eCari.Focus()
        addhandlertoAllComponent()
    End Sub


    Private Sub setKlasifikasi()
        cbKlasifikasi.DataSource = getData("SELECT klasifikasi, idklasifikasi from tblklasifikasi")
        cbKlasifikasi.DisplayMember = "klasifikasi"
        cbKlasifikasi.ValueMember = "idklasifikasi"
        cbKlasifikasi.SelectedIndex = 0
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

    Sub fillData()
        ListSat.ClearSelection()
        Dim sql As String = "select idsubklasifikasi, klasifikasi,subklasifikasi, tipearuskas, tiperasio from tblsubklasifikasi inner join tblklasifikasi on tblsubklasifikasi.idklasifikasi = tblklasifikasi.idklasifikasi where (subklasifikasi ilike '%" & eCari.Text & "%' or idsubklasifikasi ilike '%" & eCari.Text & "%')"

        Me.ListSat.DataSource = getData(sql)

        Try


            ListSat.Columns(0).HeaderText = "Kode Subklasifikasi"
            ListSat.Columns(1).HeaderText = "Klasifikasi"
            ListSat.Columns(2).HeaderText = "Subklasifikasi"
            ListSat.Columns(3).HeaderText = "Arus Kas"
            ListSat.Columns(4).HeaderText = "Rasio"
            ListSat.Columns(1).Visible = False
        Catch ex As Exception
        End Try
        styliseDG(ListSat)
        makeFillDG(ListSat)
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
                If exc("delete from tblsubklasifikasi where idsubklasifikasi='" & idselected & "'") Then
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
        Dim sqlupdate As String = "UPDATE public.tblsubklasifikasi
	SET subklasifikasi=?, tipearuskas=?, tiperasio=?, idsubklasifikasi=?, idklasifikasi=? where idsubklasifikasi='" & idselected & "'"
        Dim isiData As String() = {TBNama.Text, cbArusKas.Text, cbRasio.Text, TBKode.Text, cbKlasifikasi.SelectedValue}
        If operationQuery(sqlupdate, isiData) Then
            dialogSukses("Data berhasil diubah")
            fillData()
            dataFocus()
        Else
            dialogError("Kode Subklasifikasi telah dipakai")
        End If
    End Sub

    Sub insert()
        Dim sqlinsert As String = "INSERT INTO public.tblsubklasifikasi(
	subklasifikasi, tipearuskas, tiperasio, idsubklasifikasi, idklasifikasi)
	VALUES (?, ?, ?, ?, ?);"
        Dim isiData As String() = {TBNama.Text, cbArusKas.Text, cbRasio.Text, TBKode.Text, cbKlasifikasi.SelectedValue}
        If operationQuery(sqlinsert, isiData) Then
            dialogSukses("Data berhasil disimpan")
            fillData()
            dataFocus()
        Else
            dialogError("Kode Subklasifikasi telah dipakai")
        End If
    End Sub

    Sub setDataSelected()
        Dim sqlselected As String = "SELECT subklasifikasi, tipearuskas, tiperasio, idsubklasifikasi, idklasifikasi
	FROM public.tblsubklasifikasi where idsubklasifikasi='" & idselected & "'"

        TBKode.Text = getValue(sqlselected, "idsubklasifikasi")
        TBNama.Text = getValue(sqlselected, "subklasifikasi")
        cbRasio.Text = getValue(sqlselected, "tiperasio")
        cbArusKas.Text = getValue(sqlselected, "tipearuskas")
        cbKlasifikasi.SelectedValue = getValue(sqlselected, "idklasifikasi")

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