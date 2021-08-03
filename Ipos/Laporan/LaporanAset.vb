Public Class LaporanAset
    Public sql As String = ""

    Private Sub PreviewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' MyBase.WindowState = FormWindowState.Maximized
        laporanBarangLengkap()
    End Sub

    Dim statusCabang As Boolean = False

    Sub getCabang()
        Dim dt As DataTable = getData("select idcabang,cabang from tblcabang")
        Dim dr As DataRow = dt.NewRow
        dr(0) = "0"
        dr(1) = "SEMUA"

        dt.Rows.InsertAt(dr, 0)
        ComboBox1.DataSource = dt
        ComboBox1.ValueMember = "idcabang"
        ComboBox1.DisplayMember = "cabang"
        ComboBox1.SelectedIndex = 0
        statusCabang = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        laporanBarangLengkap()
    End Sub

    Sub awal()


        Dim dt As DataTable = getData("select idkategori,kategori from tblkategori")
        Dim dr As DataRow = dt.NewRow
        dr(0) = "0"
        dr(1) = "SEMUA"

        dt.Rows.InsertAt(dr, 0)
        ComboBox2.DataSource = dt
        ComboBox2.ValueMember = "idkategori"
        ComboBox2.DisplayMember = "kategori"
        ComboBox2.SelectedIndex = 0
        getCabang()
        laporanBarangLengkap()
    End Sub

    Private Sub eCari_KeyDown_1(sender As Object, e As KeyEventArgs) _
        Handles MyBase.KeyDown, ComboBox2.KeyDown, eCari.KeyDown, DataGridView1.KeyDown, Button4.KeyDown,
                Button1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            If open Then
                open = False
                Dim preview As PreviewAset = New PreviewAset()
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
        Dim kat = ""
        If Not ComboBox2.SelectedIndex = 0 Then
            kat = "AND idkategori=" & ComboBox2.SelectedValue
        End If

        sql =
            "SELECT idproduk, produk, kategori, CASE WHEN tipedata = 1 THEN  view_harga.stok1 WHEN tipedata = 2 THEN view_harga.stok2 ELSE view_harga.stok3 END as stok1, hargabeli, satuan,  CASE WHEN tipedata = 1 THEN view_harga.stok1 WHEN tipedata = 2 THEN view_harga.stok2 ELSE view_harga.stok3 END * hargabeli as sub from view_harga  where produk like '%" &
            eCari.Text & "%' " & kat
        If statusCabang Then
            If Not ComboBox1.SelectedIndex = 0 Then
                sql &= " AND cabang=" & ComboBox1.SelectedValue
            End If
        End If
        DataGridView1.DataSource = getData(sql)
        Try
            DataGridView1.Columns(0).HeaderText = "Kode Produk"
            DataGridView1.Columns(1).HeaderText = "Produk"
            DataGridView1.Columns(2).HeaderText = "Kategori"
            DataGridView1.Columns(3).HeaderText = "Stok"
            DataGridView1.Columns(4).HeaderText = "Harga Beli"
            DataGridView1.Columns(5).HeaderText = "Satuan"
            DataGridView1.Columns(6).HeaderText = "Sub Total"
        Catch ex As Exception

        End Try
        styliseDG(DataGridView1)
        ' makeFillDG(DataGridView1)
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
            Dim preview As PreviewAset = New PreviewAset()
            preview.sql = sql
            preview.laporanBarangLengkap()
            preview.ShowDialog()
            preview.Dispose()
            open = True
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub eCari_TextChanged_1(sender As Object, e As EventArgs) Handles eCari.TextChanged
        laporanBarangLengkap()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        laporanBarangLengkap()
    End Sub
End Class