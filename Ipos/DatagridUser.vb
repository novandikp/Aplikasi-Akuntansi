Public Class DatagridUser
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListUser)
        ComboBox1.SelectedIndex = 0
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


    Dim whereRole As String = ""

    Sub getDataUser()
        ListUser.ClearSelection()
        If ComboBox1.SelectedIndex = 0 Then
            whereRole = ""
        ElseIf ComboBox1.SelectedIndex = 1 Then
            whereRole = " AND role = 'Admin'"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            whereRole = " AND role = 'Kasir'"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            whereRole = " AND role = 'Gudang'"
        End If
        Me.ListUser.DataSource =
            getData(
                "SELECT  username, ""password"", ""role"" from tbluser where idcabang='" & Form1.idcabang &
                "' AND  username LIKE '%" & eCari.Text & "%' " & whereRole)
        makeFillDG(ListUser)
        Try
            ListUser.Columns(1).Visible = False
            ListUser.Columns(0).HeaderText = "Username"

            ListUser.Columns(2).HeaderText = "Role"


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
            Dim barang As String = ListUser.Rows(ListUser.SelectedRows(0).Index).Cells(0).Value.ToString

            If getCount("select username from tbljual where username='" & idbarang & "'") = 0 Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then

                    exc("DELETE FROM tbluser WHERE username = '" & idbarang & "'")
                    getDataUser()
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
            Form1.openEditUser(ListUser.Rows(ListUser.SelectedRows(0).Index).Cells(0).Value.ToString)
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListUser.ClearSelection()
    End Sub

    Sub tambahUser()
        Form1.openTambahUser()
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            whereRole = ""
        ElseIf ComboBox1.SelectedIndex = 1 Then
            whereRole = " AND role = 'Admin'"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            whereRole = " AND role = 'Kasir'"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            whereRole = " AND role = 'Gudang'"
        End If
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