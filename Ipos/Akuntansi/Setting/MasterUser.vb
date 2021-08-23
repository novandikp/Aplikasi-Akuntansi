Public Class MasterUser
    Private Sub MasterUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Dim idselected As String = ""


    Sub awal()
        focusData()
        isiCBRole()
    End Sub

    Sub focusForm()
        gbData.Enabled = False
        gbForm.Enabled = True
        panelAksi.Enabled = False
    End Sub

    Sub focusData()
        clearForm(gbForm)
        gbData.Enabled = True
        gbForm.Enabled = False
        panelAksi.Enabled = True
        fillData()

    End Sub

    Sub isiCBRole()
        cbPosisi.DataSource = getData("select hakakses from tblakses")
        cbPosisi.DisplayMember = "hakakses"
        cbPosisi.ValueMember = "hakakses"
        cbPosisi.SelectedIndex = 0

    End Sub


    Sub filldata()
        Dim sql = $"select * from tbluser where username ilike '%{eCari.Text}%' or hakakses ilike '%{eCari.Text}%'"
        ListSat.DataSource = getData(sql)
        ListSat.Columns(0).HeaderText = "Username"
        ListSat.Columns(1).Visible = False
        ListSat.Columns(2).HeaderText = "Posisi"
        styliseDG(ListSat)
        makeFillDG(ListSat)
    End Sub


    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanData()
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
            hapusdata()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Escape Then
            If gbForm.Enabled Then
                focusData()
                idselected = ""
            End If

        End If
    End Sub



    Private Sub eCari_Click(sender As Object, e As EventArgs) Handles eCari.TextChanged
        filldata()
    End Sub


    Sub simpanData()
        If adaKosong(gbForm) Then
            dialogError("Harap isi dengan benar")
        Else
            If String.IsNullOrEmpty(idselected) Then
                insert()
            Else
                update()
            End If
        End If
    End Sub


    Sub insert()
        Dim sql = "INSERT INTO tbluser VALUES (?,?,?)"
        Dim data As String() = {tbUsername.Text, EncryptText(tbPass.Text), cbPosisi.SelectedValue}
        If operationQuery(sql, data) Then
            dialogSukses("Berhasil disimpan")
            focusData()
            clearForm(gbForm)
            idselected = ""
        Else
            dialogError("Username telah dipakai")
        End If
    End Sub


    Sub update()
        Dim sql = "UPDATE tbluser SET username=?,password=?,hakakses=? where username=?"
        Dim data As String() = {tbUsername.Text, EncryptText(tbPass.Text), cbPosisi.SelectedValue, idselected}
        If operationQuery(sql, data) Then
            dialogSukses("Berhasil disimpan")
            focusData()
            clearForm(gbForm)
            idselected = ""
        Else
            dialogError("Username telah dipakai")
        End If
    End Sub



    Sub hapus()
        Dim sql = $"DELETE FROM tbluser WHERE username='{idselected}'"
        If exc(sql) Then
            dialogSukses("Data Berhasil dihapus")
            focusData()
            clearForm(gbForm)
            idselected = ""
        Else
            dialogError("Data gagal dihapus karena telah dipakai")
        End If
    End Sub


    Sub tambahData()
        focusForm()
        clearForm(gbForm)
    End Sub


    Sub editData()
        If String.IsNullOrEmpty(idselected) Then
            dialogError("Harap pilih user yang ingin diedit")
        Else
            focusForm()
        End If
    End Sub


    Sub hapusdata()
        If String.IsNullOrEmpty(idselected) Then
            dialogError("Harap pilih user yang ingin dihapus")
        Else
            If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                hapus()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        focusData()
        idselected = ""
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahData()
    End Sub

    Private Sub btnEdt_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
        editData()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusdata()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub ListSat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then

            tbUsername.Text = ListSat.Rows(e.RowIndex).Cells(0).Value
            idselected = tbUsername.Text
            tbPass.Text = DecryptText(ListSat.Rows(e.RowIndex).Cells(1).Value)
            cbPosisi.SelectedValue = ListSat.Rows(e.RowIndex).Cells(2).Value
        End If
    End Sub
End Class