Public Class Datagridcabang
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListUser)

        getDataUser()
        eCari.Focus()
    End Sub

    Private Sub ecaria(sender As Object, e As KeyEventArgs) Handles eCari.KeyDown
        If e.KeyCode = Keys.Down Then
            Me.ActiveControl = ListUser
            Try
                ListUser.Rows(0).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub


    Dim ReadOnly whereRole As String = ""

    Sub getDataUser()
        ListUser.ClearSelection()

        Me.ListUser.DataSource =
            getData(
                "SELECT  idcabang, cabang, ketcabang from tblcabang where cabang LIKE '%" & eCari.Text & "%' " &
                whereRole)
        makeFillDG(ListUser)
        Try
            ListUser.Columns(0).Visible = False
            ListUser.Columns(1).HeaderText = "Cabang"

            ListUser.Columns(2).HeaderText = "Keterangan"


        Catch ex As Exception

        End Try
        ListUser.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataUser()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, eCari.KeyDown, ListUser.KeyDown, AddBtn.KeyDown, EdtBtn.KeyDown, HpsBtn.KeyDown,
                Button2.KeyDown

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListUser.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListUser.Focus()

            If ListUser.Rows.Count > 0 Then
                ListUser.Rows(0).Selected = True
            End If

        ElseIf e.KeyCode = Keys.F1 Then
            tambahUser()
        ElseIf e.KeyCode = Keys.F2 Then
            editUser()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusUser()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Sub hapusUser()
        If ListUser.SelectedRows.Count = 1 Then
            Dim idbarang As String = ListUser.Rows(ListUser.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = ListUser.Rows(ListUser.SelectedRows(0).Index).Cells(1).Value.ToString
            If True Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then

                    Dim ceksql As String = "select cabang from tblproduk where cabang = " & idbarang
                    Dim ceksql1 As String = "select idcabang from tblsupplier where idcabang = " & idbarang
                    If getCount(ceksql) = 0 And getCount(ceksql1) = 0 Then
                        exc("DELETE FROM tblcabang WHERE idcabang = '" & idbarang & "'")
                        getDataUser()
                    Else
                        dialogError("Cabang masih memiliki data")
                    End If

                End If
            Else
                dialogError("User sedang dipakai")
            End If


        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub editUser()
        If ListUser.SelectedRows.Count = 1 Then

            FormUbahCabang.idcabang = ListUser.Rows(ListUser.SelectedRows(0).Index).Cells(0).Value.ToString
            FormUbahCabang.ShowDialog()
            FormUbahCabang.Dispose()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListUser.ClearSelection()
    End Sub

    Sub tambahUser()
        FormCabang.ShowDialog()
        FormCabang.Dispose()
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        tambahUser()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles HpsBtn.Click
        hapusUser()
    End Sub

    Private Sub Btnedt_Click(sender As Object, e As EventArgs) Handles EdtBtn.Click
        editUser()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        closeTab()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        getDataUser()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        getDataUser()
    End Sub


    Private Sub Button4_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListUser.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListUser.Focus()

            If ListUser.Rows.Count > 0 Then
                ListUser.Rows(0).Selected = True
            End If

        ElseIf e.KeyCode = Keys.F1 Then
            tambahUser()
        ElseIf e.KeyCode = Keys.F2 Then
            editUser()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusUser()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getDataUser()
    End Sub
End Class