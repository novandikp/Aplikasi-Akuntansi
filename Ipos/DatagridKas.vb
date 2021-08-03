Public Class DatagridKas
    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        styliseDG(ListKas)
        getDataKas()
        eCari.Focus()
    End Sub

    Sub getDataKas()
        ListKas.ClearSelection()
        Me.ListKas.DataSource =
            getData("SELECT * FROM tblkas  where kas LIKE '%" & eCari.Text & "%' OR kodekas LIKE '%" & eCari.Text & "%'")
        makeFillDG(ListKas)
        Try

            ListKas.Columns(0).HeaderText = "Kode Kas"
            ListKas.Columns(1).HeaderText = "Nama Kas"
            ListKas.Columns(2).HeaderText = "Saldo"


        Catch ex As Exception

        End Try
        ListKas.ClearSelection()
        eCari.Focus()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataKas()
    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, eCari.KeyDown, ListKas.KeyDown, AddBtn.KeyDown, EdtBtn.KeyDown, HpsBtn.KeyDown

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListKas.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListKas.Focus()
            If ListKas.Rows.Count > 0 Then
                ListKas.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            tambahKas()
        ElseIf e.KeyCode = Keys.F2 Then
            editKas()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusKas()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Sub closeTab()
        Dim listItemForms As DatagridKas = Application.OpenForms("DatagridKas")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Sub hapusKas()
        If ListKas.SelectedRows.Count = 1 Then
            Dim idbarang As String = ListKas.Rows(ListKas.SelectedRows(0).Index).Cells(0).Value.ToString
            Dim barang As String = ListKas.Rows(ListKas.SelectedRows(0).Index).Cells(1).Value.ToString
            If True Then
                Dim ds As DialogResult = MessageBox.Show("Apakah anda yakin untuk menghapus " & barang & "?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo)
                If ds = DialogResult.Yes Then

                    exc("DELETE FROM tblkas WHERE kodekas = " & idbarang & "")
                    getDataKas()
                End If
            Else
                dialogError("Kas sedang dipakai")
            End If


        Else
            MsgBox("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub editKas()
        If ListKas.SelectedRows.Count = 1 Then
            Form1.openEditKas(ListKas.Rows(ListKas.SelectedRows(0).Index).Cells(0).Value.ToString)
        Else
            MsgBox("Pilih item terlebih dahulu")
        End If
        ListKas.ClearSelection()
    End Sub

    Sub tambahKas()
        Form1.openTambahKas()
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        tambahKas()
    End Sub

    Private Sub HpsBtn_Click(sender As Object, e As EventArgs) Handles HpsBtn.Click
        hapusKas()
    End Sub

    Private Sub EdtBTN_Click(sender As Object, e As EventArgs) Handles EdtBtn.Click
        editKas()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        closeTab()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        getDataKas()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        getDataKas()
    End Sub
End Class