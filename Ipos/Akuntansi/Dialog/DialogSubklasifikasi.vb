Public Class DialogSubklasifikasi

    Public idsubklasifikasi As String
    Public subklasifikasi As String

    Private Sub DialogSubklasifikasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getKlasifikasi()
        fillData()
        Me.ActiveControl = eCari
    End Sub

    Sub getKlasifikasi()
        Dim sql As String = "SELECT idklasifikasi,klasifikasi from tblklasifikasi order by idklasifikasi"
        Dim dt As DataTable = getData(sql)
        Dim dr As DataRow = dt.NewRow
        dr.Item(0) = 0
        dr.Item(1) = "Semua"
        dt.Rows.InsertAt(dr, 0)
        cbSub.DataSource = dt
        cbSub.DisplayMember = "klasifikasi"
        cbSub.ValueMember = "idklasifikasi"
    End Sub




    Sub fillData()
        Dim cari As String = eCari.Text
        Dim sqldata As String = "SELECT tblklasifikasi.klasifikasi ,tblsubklasifikasi.idsubklasifikasi, tblsubklasifikasi.subklasifikasi from tblsubklasifikasi inner join tblklasifikasi on tblklasifikasi.idklasifikasi = tblsubklasifikasi.idklasifikasi where (tblsubklasifikasi.subklasifikasi ILIKE '%" & cari & "%' or tblsubklasifikasi.idsubklasifikasi ILIKE '%" & cari & "%')"
        If cbSub.SelectedIndex > 0 Then
            sqldata &= " AND tblklasifikasi.idklasifikasi=" & cbSub.SelectedValue
        End If
        ListSat.DataSource = getData(sqldata)
        ListSat.Columns(0).Visible = False
        ListSat.Columns(1).HeaderText = "Kode Subklasifikasi"
        ListSat.Columns(2).HeaderText = "Subklasifikasi"
        styliseDG(ListSat)
        makeFillDG(ListSat)
    End Sub

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        fillData()
    End Sub



    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            idsubklasifikasi = ListSat.Rows(e.RowIndex).Cells(1).Value
            subklasifikasi = ListSat.Rows(e.RowIndex).Cells(2).Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub ListSat_KeyDown(sender As Object, e As KeyEventArgs) Handles ListSat.KeyDown, Me.KeyDown
        If Not IsNothing(ListSat.CurrentRow) And e.KeyCode = Keys.Enter Then
            idsubklasifikasi = ListSat.Rows(ListSat.CurrentRow.Index).Cells(1).Value
            subklasifikasi = ListSat.Rows(ListSat.CurrentRow.Index).Cells(2).Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub eCari_Click(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
    End Sub
End Class