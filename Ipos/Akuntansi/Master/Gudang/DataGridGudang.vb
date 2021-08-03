Public Class Datagridgudang
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
        setDepartemen()
        styliseDG(ListSat)
        getSubKlasifikasi()
        getDataProduk()
        eCari.Focus()
        addhandlertoAllComponent()
    End Sub

    Private Sub setDepartemen()
        Dim dt As DataTable = getData("SELECT iddepartemen,departemen from tbldepartemen order by iddepartemen")
        cbDepartemen.DataSource = dt
        cbDepartemen.DisplayMember = "departemen"
        cbDepartemen.ValueMember = "iddepartemen"
        cbDepartemen.SelectedIndex = 0

    End Sub

    Private Sub getSubKlasifikasi()
        Dim dt As DataTable = getData("SELECT iddepartemen,departemen from tbldepartemen order by iddepartemen")
        Dim dr As DataRow = dt.NewRow
        dr.Item(0) = ".?.?????"
        dr.Item(1) = "Semua"
        dt.Rows.InsertAt(dr, 0)
        cbSub.DataSource = dt
        cbSub.DisplayMember = "departemen"
        cbSub.ValueMember = "iddepartemen"
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
        Dim sql As String = "SELECT idgudang,gudang, departemen,tblgudang.iddepartemen,CAST(tblgudang.flaggudang as varchar) from tblgudang inner join tbldepartemen on tbldepartemen.iddepartemen = tblgudang.iddepartemen
        where gudang ilike '%" & eCari.Text & "%' or idgudang ilike '%" & eCari.Text & "%'"

        If cbSub.SelectedIndex > 0 And cbSub.Items.Count > 1 Then
            sql &= " and tblgudang.iddepartemen ='" & cbSub.SelectedValue & "'"
        End If
        Me.ListSat.DataSource =
            getData(sql)

        Try
            ListSat.Columns(0).HeaderText = "Kode Gudang"
            ListSat.Columns(1).HeaderText = "Gudang"
            ListSat.Columns(2).HeaderText = "Departemen"
            ListSat.Columns(3).Visible = False
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
                If exc("delete from tblgudang where idgudang = '" & idselected & "'") Then
                    dialogSukses("Data Berhasil dihapus")
                    getDataProduk()
                    dataFocus()

                Else
                    dialogError("Data gagal dihapus karena telah digunakan")
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

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataProduk()
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        batal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dialogdepartemen As New DialogDepartemen
        Dim ds As DialogResult = dialogdepartemen.ShowDialog()
        If ds = DialogResult.OK Then
            cbDepartemen.SelectedValue = dialogdepartemen.iddepartemen

        End If
        dialogdepartemen.Dispose()
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
        Dim sqlupdate As String = "UPDATE public.tblgudang	SET idgudang=?, gudang=?, iddepartemen=?, flaggudang=? where idgudang='" & idselected & "'"
        Dim isiData As String() = {TBKode.Text, TBNama.Text, cbDepartemen.SelectedValue, getStatus(cbStatus)}
        If operationQuery(sqlupdate, isiData) Then
            dialogSukses("Data berhasil diubah")
            getDataProduk()
            dataFocus()
        Else
            dialogError("Kode Gudang telah dipakai")
        End If
    End Sub

    Sub insert()
        Dim sqlinsert As String = "INSERT INTO public.tblgudang( idgudang, gudang, iddepartemen, flaggudang) VALUES (?, ?, ?, ?);"
        Dim isiData As String() = {TBKode.Text, TBNama.Text, cbDepartemen.SelectedValue, getStatus(cbStatus)}
        If operationQuery(sqlinsert, isiData) Then
            dialogSukses("Data berhasil disimpan")
            getDataProduk()
            dataFocus()
        Else
            dialogError("Kode Gudang telah dipakai")
        End If
    End Sub

    Sub setDataSelected()
        Dim sqlselected As String = "SELECT idgudang, gudang, iddepartemen, flaggudang	FROM public.tblgudang where idgudang='" & idselected & "'"

        TBKode.Text = getValue(sqlselected, "idgudang")
        TBNama.Text = getValue(sqlselected, "gudang")
        cbDepartemen.SelectedValue = getValue(sqlselected, "iddepartemen")
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
End Class