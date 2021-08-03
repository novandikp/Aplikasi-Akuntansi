

Public Class FormDatagridLevel
    Private Sub FormDatagridlevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getListlevel()
    End Sub

    Dim edit As Boolean = False
    Dim baris As Integer = 0

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown, Listlevel.KeyDown, btnKeluar.KeyDown, BtnHps.KeyDown
        If e.KeyCode = Keys.Delete Then
            deletelevel()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
    End Sub

    Sub getListlevel()
        Listlevel.DataSource = getData("select  idlevel, ""level"", diskon from tbllevel")
        Listlevel.Columns(0).Visible = False
        Listlevel.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Listlevel.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Listlevel.Columns(1).HeaderText = "Level"
        Listlevel.Columns(2).HeaderText = "Diskon"
        styliseDG(Listlevel)
    End Sub


    Sub closeTab()
        Me.Close()
    End Sub


    Sub deletelevel()
        If Listlevel.SelectedCells.Count = 1 And Not IsNothing(Listlevel.CurrentRow.Cells(0).Value) Then
            If String.IsNullOrWhiteSpace(Listlevel.CurrentRow.Cells(0).Value.ToString) Then
                dialogError("Pilih item terlebih dahulu")
                Return
            End If

            If _
                getCount(
                    "select idlevel from tblpelanggan where idlevel=" & Listlevel.CurrentRow.Cells(0).Value.ToString) >
                0 Then
                dialogError("Kategori dipakai")
                Return
            End If
            If dialog("Apakah anda yakin untuk menghapus " & Listlevel.CurrentRow.Cells(1).Value.ToString & " ?") Then
                exc("DELETE FROM tbllevel WHERE idlevel=" & Listlevel.CurrentRow.Cells(0).Value.ToString)
                getListlevel()
            End If
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Dim check As Boolean = True

    Private Sub ListLevel_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles Listlevel.CellValueChanged
        Try

            If check And Not IsNothing(Listlevel.CurrentRow) Then

                If _
                    Not String.IsNullOrWhiteSpace(Listlevel.CurrentRow.Cells(1).Value.ToString) And
                    String.IsNullOrWhiteSpace(Listlevel.CurrentRow.Cells(2).Value.ToString) Then
                    edit = True
                    baris = e.RowIndex

                ElseIf _
                    String.IsNullOrWhiteSpace(Listlevel.Rows(e.RowIndex).Cells(2).Value.ToString) Or
                    String.IsNullOrWhiteSpace(Listlevel.Rows(e.RowIndex).Cells(1).Value.ToString) Then
                    dialogError("Isi dengan benar")
                    check = False
                    getListlevel()
                Else


                    Dim nilai As String = Listlevel.Rows(e.RowIndex).Cells(1).Value.ToString
                    Dim diskon As String = Replace(Listlevel.Rows(e.RowIndex).Cells(2).Value.ToString, ",", ".")
                    If String.IsNullOrWhiteSpace(Listlevel.Rows(e.RowIndex).Cells(0).Value.ToString) Then
                        Dim isi() As String = {nilai}
                        If operationQuery("insert into tbllevel (level,diskon) values ( ? , " & diskon & ");", isi) Then
                            dialogInfo("Berhasil disimpan")

                        End If
                    Else
                        Dim isi() As String = {nilai}
                        If _
                            operationQuery(
                                "update tbllevel set level= ?, diskon = " & diskon & " where idlevel = " &
                                Listlevel.CurrentRow.Cells(0).Value.ToString, isi) Then
                            dialogInfo("Berhasil disimpan")

                        End If
                    End If
                    getListlevel()
                End If

            Else
                check = True
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        deletelevel()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        closeTab()
    End Sub


    Private Sub ListLevel_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) _
        Handles Listlevel.EditingControlShowing
        If Listlevel.CurrentCell.ColumnIndex = 2 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress1
        Else
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        End If
    End Sub

    Private Sub TextBox_keyPress1(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ",") Then e.Handled = True
        End If
    End Sub

    Private Sub TextBox_keyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = False
    End Sub

    Private Sub Listlevel_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Listlevel.DataError
        e.Cancel = True
        dialogError("Masukkan dengan benar")
    End Sub

    Private Sub Listlevel_SelectionChanged(sender As Object, e As EventArgs) Handles Listlevel.SelectionChanged
        If edit Then
            edit = False
            Listlevel.Rows(baris).Cells(2).Value = "0,00"
            Listlevel.CurrentCell = Listlevel.Rows(baris).Cells(2)
            check = True
        End If
    End Sub

    Private Sub Listlevel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles Listlevel.CellContentClick
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        deletelevel()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        closeTab()
    End Sub
End Class