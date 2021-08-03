Public Class LaporanPelangganHutang
    Public sql As String = ""

    Private Sub PreviewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' MyBase.WindowState = FormWindowState.Maximized
        getCabang()
        ComboBox1.SelectedIndex = 0
        laporanBarangLengkap()
    End Sub

    Dim statusCabang As Boolean = False

    Sub getCabang()
        Dim dt As DataTable = getData("select idcabang,cabang from tblcabang")
        Dim dr As DataRow = dt.NewRow
        dr(0) = "0"
        dr(1) = "SEMUA"

        dt.Rows.InsertAt(dr, 0)
        ComboBox3.DataSource = dt
        ComboBox3.ValueMember = "idcabang"
        ComboBox3.DisplayMember = "cabang"
        ComboBox3.SelectedIndex = 0
        statusCabang = True
    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        laporanBarangLengkap()
    End Sub


    Sub laporanBarangLengkap()

        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        Dim awal = DTawal.Value.ToString("yyyy/MM/dd")
        Dim akhir = DtAkhir.Value.ToString("yyyy/MM/dd")
        sql =
            "SELECT pelanggan as supplier,  jatuhtempo as tglpiutang, jumlahbayar as bayarpiutang, sisasaldp as nosupplier, keterangan as alamatsupplier, idpelanggan as idsupplier, fakturjual as idpiutang from view_hutang_temp where  jatuhtempo between ('" &
            awal & "') and ('" & akhir & "')  and (supplier like '%" & eCari.Text & "%' or alamatpelanggan like '%" &
            eCari.Text & "%')"
        If statusCabang Then
            If Not ComboBox3.SelectedIndex = 0 Then
                sql &= " AND idcabang=" & ComboBox3.SelectedValue
            End If
        End If
        If ComboBox1.SelectedIndex = 1 Then
            sql &= " and jumlahbayar = 0"
        End If
        If ComboBox1.SelectedIndex = 2 Then
            sql &= " and jumlahbayar > 0"
        End If

        Try
            DataGridView1.Columns(0).HeaderText = "Pelanggan"
            DataGridView1.Columns(1).HeaderText = "Jatuh Tempo"
            DataGridView1.Columns(2).HeaderText = "Jumlah Pembayaran"
            DataGridView1.Columns(3).HeaderText = "Sisa Hutang"
            DataGridView1.Columns(4).HeaderText = "Keterangan"
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False


        Catch ex As Exception

        End Try
        DataGridView1.DataSource = getData(sql)
        makeFillDG(DataGridView1)
        styliseDG(DataGridView1)
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

    Private Sub ReportViewer1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            laporanBarangLengkap()

        End If
    End Sub

    Dim open As Boolean = True

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If open Then
            open = False
            Dim preview As PreviewPelangganHutang = New PreviewPelangganHutang()
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

    Private Sub eCari_KeyDown(sender As Object, e As KeyEventArgs)
    End Sub

    Private Sub eCari_KeyDown_1(sender As Object, e As KeyEventArgs) _
        Handles MyBase.KeyDown, eCari.KeyDown, DataGridView1.KeyDown, Button4.KeyDown, Button1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            If open Then
                open = False
                Dim preview As PreviewSupplierPiutang = New PreviewSupplierPiutang()
                preview.sql = sql
                preview.laporanBarangLengkap()
                preview.ShowDialog()
                open = True
            End If

        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellContentClick
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
    End Sub

    Private Sub DTawal_ValueChanged(sender As Object, e As EventArgs) Handles DTawal.ValueChanged
        laporanBarangLengkap()
    End Sub

    Private Sub DtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles DtAkhir.ValueChanged
        laporanBarangLengkap()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        laporanBarangLengkap()
    End Sub
End Class