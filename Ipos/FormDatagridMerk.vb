Public Class FormDatagridMerk
    Public status = False

    Private Sub FormDatagridMerk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getListMerk()
    End Sub


    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, ListMerk.KeyDown, btnKeluar.KeyDown, BtnHps.KeyDown

        If e.KeyCode = Keys.Delete Then
            deleteMerk()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
    End Sub

    Sub getListMerk()
        ListMerk.DataSource = getData("select idmerk, merk, ketmerk from tblmerk where idmerk > 1")
        ListMerk.Columns(0).Visible = False
        ListMerk.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ListMerk.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ListMerk.Columns(1).HeaderText = "Merk"
        ListMerk.Columns(2).HeaderText = "Keterangan"
        styliseDG(ListMerk)
        Try
            ListMerk.CurrentCell = ListMerk.Rows(ListMerk.Rows.Count - 2).Cells(1)
        Catch ex As Exception

        End Try
    End Sub

    Sub closeTab()

        FormEditBarang.getMerk()
        Me.Close()
    End Sub


    Sub deleteMerk()
        If ListMerk.SelectedCells.Count = 1 And Not IsNothing(ListMerk.CurrentRow.Cells(0).Value) Then
            If (String.IsNullOrWhiteSpace(ListMerk.CurrentRow.Cells(0).Value.ToString())) Then
                dialogError("Pilih Item terlebih dahulu")
                Return
            End If

            If getCount("select idmerk from tblproduk where idmerk=" & ListMerk.CurrentRow.Cells(0).Value.ToString) > 0 _
                Then
                dialogError("Merk dipakai")
                Return
            End If
            If dialog("Apakah anda yakin untuk menghapus " & ListMerk.CurrentRow.Cells(1).Value.ToString & " ?") Then
                exc("DELETE FROM tblmerk WHERE idmerk=" & ListMerk.CurrentRow.Cells(0).Value.ToString)
                getListMerk()


            End If
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Private Sub ListMerk_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles ListMerk.CellContentClick
    End Sub

    Dim check As Boolean = True
    Dim ubah = 0
    Dim baris = 0

    Private Sub ListMerk_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles ListMerk.CellValueChanged
        Try
            If check And Not IsNothing(Listmerk.CurrentRow) Then
                ubah = e.ColumnIndex
                baris = e.RowIndex
                If String.IsNullOrWhiteSpace(ListMerk.CurrentRow.Cells(1).Value.ToString) Then
                    dialogError("Isi kategori dengan benar")
                    check = False
                Else
                    Dim nilai As String = ListMerk.CurrentRow.Cells(1).Value.ToString

                    If String.IsNullOrWhiteSpace(ListMerk.CurrentRow.Cells(0).Value.ToString) Then
                        Dim isi() As String = {nilai, nilai}
                        If getCount("select merk from tblmerk where merk='" & nilai & "'") > 0 Then
                            ubah = 3
                            dialogError("Merk sudah pernah dimasukkan")
                            check = False
                            getListMerk()
                            check = True


                            Return
                        End If
                        If operationQuery("insert into tblmerk (merk,ketmerk) values ( ?,?  );", isi) Then


                        End If
                    Else
                        Dim a As String = ListMerk.CurrentRow.Cells(2).Value.ToString
                        Dim isi() As String = {nilai, a}
                        If _
                            operationQuery(
                                "update tblmerk set merk= ?, ketmerk= ? where idmerk = " &
                                ListMerk.CurrentRow.Cells(0).Value.ToString, isi) Then


                        End If
                    End If

                End If
                check = False

                getListMerk()

                ubah = e.ColumnIndex
                baris = e.RowIndex
                check = True
            Else
                check = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        deleteMerk()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        closeTab()
    End Sub

    Private Sub ListMerk_SelectionChanged(sender As Object, e As EventArgs) Handles ListMerk.SelectionChanged
        Try

            If ubah = 1 Then
                ListMerk.CurrentCell = ListMerk.Rows(baris).Cells(2)
                ubah = 0

            ElseIf ubah = 2 Then
                ListMerk.CurrentCell = ListMerk.Rows(baris + 1).Cells(1)
                ubah = 0
            ElseIf ubah = 3 Then
                ListMerk.Rows.Insert(ListMerk.Rows.Count - 1)
                ListMerk.CurrentCell = ListMerk.Rows(ListMerk.Rows.Count - 2).Cells(1)
                ubah = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormDatagridMerk_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If status Then
            Form1.refreshMerk()
            status = False
        End If
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        deleteMerk()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        closeTab()
    End Sub
End Class