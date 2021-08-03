Imports System.Threading

Public Class FormDatagridKategori
    Public status = False

    Private Sub FormDatagridMerk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getListMerk()
    End Sub


    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, ListKategori.KeyDown, btnKeluar.KeyDown, BtnHps.KeyDown
        If e.KeyCode = Keys.Delete Then
            deleteMerk()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
    End Sub

    Sub getListMerk()
        ListKategori.DataSource = getData("select idkategori,kategori,ketkategori from tblkategori where idkategori > 1")
        ListKategori.Columns(0).Visible = False
        ListKategori.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ListKategori.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ListKategori.Columns(1).HeaderText = "Kategori"
        ListKategori.Columns(2).HeaderText = "Keterangan"
        styliseDG(ListKategori)
        Try
            ListKategori.CurrentCell = ListKategori.Rows(ListKategori.Rows.Count - 2).Cells(1)
        Catch ex As Exception

        End Try
    End Sub

    Sub closeTab()
        Dim thread As New Thread(
            Sub()

                FormEditBarang.getJenis()
            End Sub
            )
        thread.Start()
        Me.Close()
    End Sub


    Sub deleteMerk()

        If ListKategori.SelectedCells.Count = 1 And Not IsNothing(ListKategori.CurrentRow.Cells(0).Value.ToString()) _
            Then

            If (String.IsNullOrWhiteSpace(ListKategori.CurrentRow.Cells(0).Value.ToString())) Then
                dialogError("Pilih Item terlebih dahulu")
                Return
            End If
            If _
                getCount(
                    "select idkategori from tblproduk where idkategori=" &
                    ListKategori.CurrentRow.Cells(0).Value.ToString) > 0 Then
                dialogError("Kategori dipakai")
                Return
            End If

            If dialog("Apakah anda yakin untuk menghapus " & ListKategori.CurrentRow.Cells(1).Value.ToString & " ?") _
                Then
                exc("DELETE FROM tblkategori WHERE idkategori=" & ListKategori.CurrentRow.Cells(0).Value.ToString)
                getListMerk()


            End If
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Private Sub ListMerk_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles ListKategori.CellContentClick
    End Sub

    Dim check As Boolean = True
    Dim ubah = 0
    Dim baris = 0

    Private Sub ListMerk_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles ListKategori.CellValueChanged
        Try
            If check And Not IsNothing(ListKategori.CurrentRow) Then
                ubah = e.ColumnIndex
                baris = e.RowIndex
                If String.IsNullOrWhiteSpace(ListKategori.CurrentRow.Cells(1).Value.ToString) Then
                    dialogError("Isi kategori dengan benar")
                    check = False
                Else
                    Dim nilai As String = ListKategori.CurrentRow.Cells(1).Value.ToString

                    If String.IsNullOrWhiteSpace(ListKategori.CurrentRow.Cells(0).Value.ToString) Then
                        Dim isi() As String = {nilai, nilai}
                        If getCount("select kategori from tblkategori where kategori='" & nilai & "'") > 0 Then
                            ubah = 3
                            dialogError("kategori sudah pernah dimasukkan")
                            check = False
                            getListMerk()
                            check = True


                            Return
                        End If
                        If operationQuery("insert into tblkategori (kategori,ketkategori) values ( ?,?  );", isi) Then


                        End If
                    Else
                        Dim a As String = ListKategori.CurrentRow.Cells(2).Value.ToString
                        Dim isi() As String = {nilai, a}
                        If _
                            operationQuery(
                                "update tblkategori set kategori= ?, ketkategori= ? where idkategori = " &
                                ListKategori.CurrentRow.Cells(0).Value.ToString, isi) Then


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

    Private Sub ListMerk_SelectionChanged(sender As Object, e As EventArgs) Handles ListKategori.SelectionChanged
        Try

            If ubah = 1 Then
                ListKategori.CurrentCell = ListKategori.Rows(baris).Cells(2)
                ubah = 0

            ElseIf ubah = 2 Then
                ListKategori.CurrentCell = ListKategori.Rows(baris + 1).Cells(1)
                ubah = 0
            ElseIf ubah = 3 Then
                ListKategori.Rows.Insert(ListKategori.Rows.Count - 1)
                ListKategori.CurrentCell = ListKategori.Rows(ListKategori.Rows.Count - 2).Cells(1)
                ubah = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormDatagridKategori_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If status Then
            Form1.refreshKategori()
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