Public Class DialogAkun

    Public idakun As String
    Public akun As String

    Public selectedKlasifikasi As String = ""
    Public isLocked As Boolean = False


    Private Sub DialogSubklasifikasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getKlasifikasi()
        fillData()
        Me.ActiveControl = eCari
    End Sub

    Sub getKlasifikasi()
        Dim sql As String = "SELECT idsubklasifikasi,subklasifikasi from tblsubklasifikasi order by idsubklasifikasi"
        Dim dt As DataTable = getData(sql)
        Dim dr As DataRow = dt.NewRow
        dr.Item(0) = "-,as-.."
        dr.Item(1) = "Semua"
        dt.Rows.InsertAt(dr, 0)
        cbSub.DataSource = dt
        cbSub.DisplayMember = "subklasifikasi"
        cbSub.ValueMember = "idsubklasifikasi"
        If Not String.IsNullOrEmpty(selectedKlasifikasi) Then
            cbSub.SelectedValue = selectedKlasifikasi
        End If
        cbSub.Enabled = Not isLocked

    End Sub




    Sub fillData()
        Dim cari As String = eCari.Text
        Dim sqldata As String = "SELECT idsubklasifikasi,kodeakun,akun from tblakun where (kodeakun ILIKE '%" & cari & "%' or akun ILIKE '%" & cari & "%')"
        If cbSub.SelectedIndex > 0 Then
            sqldata &= " AND idsubklasifikasi='" & cbSub.SelectedValue & "'"
        End If
        Debug.WriteLine(sqldata
                        )
        ListSat.DataSource = getData(sqldata)
        ListSat.Columns(0).Visible = False
        ListSat.Columns(1).HeaderText = "Kode Akun"
        ListSat.Columns(2).HeaderText = "Akun"
        styliseDG(ListSat)
        makeFillDG(ListSat)
    End Sub

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        fillData()
    End Sub



    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            idakun = ListSat.Rows(e.RowIndex).Cells(1).Value
            akun = ListSat.Rows(e.RowIndex).Cells(2).Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub ListSat_KeyDown(sender As Object, e As KeyEventArgs) Handles ListSat.KeyDown, Me.KeyDown
        If Not IsNothing(ListSat.CurrentRow) And e.KeyCode = Keys.Enter Then
            idakun = ListSat.Rows(ListSat.CurrentRow.Index).Cells(1).Value
            akun = ListSat.Rows(ListSat.CurrentRow.Index).Cells(2).Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub eCari_Click(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
    End Sub
End Class