Public Class LaporanPelanggan
    Public sql As String = ""

    Private Sub PreviewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' MyBase.WindowState = FormWindowState.Maximized
        laporanBarangLengkap()
    End Sub

    Private Sub eCari_KeyDown_1(sender As Object, e As KeyEventArgs) _
        Handles MyBase.KeyDown, eCari.KeyDown, DataGridView1.KeyDown, Button4.KeyDown, Button1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            If open Then
                open = False
                Dim preview As PreviewPelanggan = New PreviewPelanggan()
                preview.sql = sql
                preview.laporanBarangLengkap()
                preview.ShowDialog()
                open = True
            End If

        End If
    End Sub


    Sub laporanBarangLengkap()

        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        sql = "SELECT pelanggan, alamatpelanggan, nopelanggan from view_pelanggan  where (pelanggan like '%" &
              eCari.Text & "%' or alamatpelanggan like '%" & eCari.Text & "%') and not idpelanggan=1"
        DataGridView1.DataSource = getData(sql)
        Try
            DataGridView1.Columns(0).HeaderText = "Pelanggan"
            DataGridView1.Columns(1).HeaderText = "Alamat"
            DataGridView1.Columns(2).HeaderText = "Telepon"


        Catch ex As Exception

        End Try
        styliseDG(DataGridView1)
        makeFillDG(DataGridView1)
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs)
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        laporanBarangLengkap()
    End Sub

    Private Sub ReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles eCari.KeyDown, Button4.KeyDown, Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            laporanBarangLengkap()

        End If
    End Sub

    Dim open As Boolean = True

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If open Then
            open = False
            Dim preview As PreviewPelanggan = New PreviewPelanggan()
            preview.sql = sql
            preview.laporanBarangLengkap()
            preview.ShowDialog()
            preview.Dispose()
            open = True
        End If
    End Sub

    Private Sub eCari_TextChanged_1(sender As Object, e As EventArgs) Handles eCari.TextChanged
        laporanBarangLengkap()
    End Sub
End Class