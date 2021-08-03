Public Class Datagridkontak
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
            panelPeran.Visible = True
            cbPegawai.Checked = False
            cbPelanggan.Checked = False
            cbSupplier.Checked = False
        End If

        gbData.Enabled = False
        gbForm.Enabled = True
        panelAksi.Enabled = False
    End Sub


    Sub awal()
        styliseDG(ListSat)
        cbSub.SelectedIndex = 0
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

    Sub fillData()
        ListSat.ClearSelection()
        Dim sql As String = "SELECT idpelanggan, pelanggan, alamat, notelp, posisi from tblkontak where (pelanggan ilike '%" & eCari.Text & "%' or alamat ilike '%" & eCari.Text & "%')"
        If cbSub.SelectedIndex > 0 Then
            sql &= " AND posisi ilike '%" & cbSub.Text & "%'"
        End If
        Me.ListSat.DataSource = getData(sql)

        Try
            ListSat.Columns(0).HeaderText = "Kode"
            ListSat.Columns(0).Visible = False
            ListSat.Columns(1).HeaderText = "Nama"
            ListSat.Columns(2).HeaderText = "Alamat"
            ListSat.Columns(3).HeaderText = "No Telp"
            ListSat.Columns(4).HeaderText = "Peran"
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
                If exc("DELETE FROM tblkontak WHERE idpelanggan=" & idselected) Then
                    dialogSukses("Data Berhasil dihapus")
                    fillData()
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

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        fillData()
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        batal()
    End Sub


    Function getPeran() As String
        Dim sb As New System.Text.StringBuilder
        If cbPelanggan.Checked Then
            sb.Append("Pelanggan,")
        End If
        If cbPegawai.Checked Then
            sb.Append("Pegawai,")
        End If
        If cbSupplier.Checked Then
            sb.Append("Supplier,")
        End If
        sb.Remove(sb.Length - 1, 1)
        Return sb.ToString()
    End Function


    Function hasSelected() As Boolean
        Dim kondisi As Boolean = False
        If cbPelanggan.Checked Then
            kondisi = True
        ElseIf cbPegawai.Checked Then
            kondisi = True
        ElseIf cbSupplier.Checked Then
            kondisi = True
        End If
        Return kondisi
    End Function

    Sub simpanData()
        If adaKosong(gbForm) Then
            dialogError("Masih ada form yang masih kosong")
        Else
            If String.IsNullOrEmpty(idselected) Then
                If hasSelected() Then
                    insert()
                Else
                    dialogError("Pilih salah satu peran untuk kontak ini !")
                End If

            Else
                update()
            End If
        End If

    End Sub

    Sub update()
        Dim sqlupdate As String = "UPDATE public.tblkontak	SET  pelanggan=?, alamat=?, notelp=? where idpelanggan=" & idselected
        Dim isiData As String() = {TBpelanggan.Text, tbAlamat.Text.ToString, tbTelp.Text}
        If operationQuery(sqlupdate, isiData) Then
            dialogSukses("Data berhasil diubah")
            fillData()
            dataFocus()
        Else
            dialogError("Terdapat kesalahan saat input")
        End If
    End Sub

    Sub insert()
        Dim sqlinsert As String = "INSERT INTO public.tblkontak(pelanggan, alamat, notelp, posisi)VALUES ( ?, ?, ?, ?);"
        Dim isiData As String() = {TBpelanggan.Text, tbAlamat.Text.ToString, tbTelp.Text, getPeran()}
        If operationQuery(sqlinsert, isiData) Then
            dialogSukses("Data berhasil disimpan")
            fillData()
            dataFocus()
        Else
            dialogError("Terdapat kesalahan saat input")
        End If
    End Sub

    Sub setDataSelected()
        Dim sqlselected As String = "SELECT idpelanggan, pelanggan, alamat, notelp from tblkontak where idpelanggan='" & idselected & "'"
        panelPeran.Visible = False
        TBpelanggan.Text = getValue(sqlselected, "pelanggan")
        tbAlamat.Text = getValue(sqlselected, "alamat")
        tbTelp.Text = getValue(sqlselected, "notelp")
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

    Private Sub tbTelp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbTelp.KeyPress
        onlyNumber(e)
    End Sub
End Class