Public Class DialogDepartemen

    Public iddepartemen As String
    Public departemen As String

    Private Sub DialogSubklasifikasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fillData()
        Me.ActiveControl = eCari
    End Sub




    Sub fillData()
        Dim cari As String = eCari.Text
        Dim sqldata As String = "SELECT tbldepartemen.iddepartemen, tbldepartemen.departemen from tbldepartemen where (tbldepartemen.departemen ILIKE '%" & cari & "%' or tbldepartemen.iddepartemen ILIKE '%" & cari & "%')"

        ListSat.DataSource = getData(sqldata)

        ListSat.Columns(0).HeaderText = "Kode Departemen"
        ListSat.Columns(1).HeaderText = "Departemen"
        styliseDG(ListSat)
        makeFillDG(ListSat)
    End Sub

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs)
        fillData()
    End Sub



    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            iddepartemen = ListSat.Rows(e.RowIndex).Cells(0).Value
            departemen = ListSat.Rows(e.RowIndex).Cells(1).Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub ListSat_KeyDown(sender As Object, e As KeyEventArgs) Handles ListSat.KeyDown, Me.KeyDown
        If Not IsNothing(ListSat.CurrentRow) And e.KeyCode = Keys.Enter Then
            iddepartemen = ListSat.Rows(ListSat.CurrentRow.Index).Cells(0).Value
            departemen = ListSat.Rows(ListSat.CurrentRow.Index).Cells(1).Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub eCari_Click(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
    End Sub
End Class