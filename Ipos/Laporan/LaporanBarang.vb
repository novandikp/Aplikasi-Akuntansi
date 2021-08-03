Public Class LaporanBarang
    Public sql As String = ""
    Dim status = True

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

        laporanBarangTanpaHarga()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        status = False
        ComboBox2.DataSource = Nothing
        ComboBox2.Items.Clear()

        If ComboBox1.SelectedIndex = 0 Then
            ComboBox2.Items.Add("STOK NOL")
            ComboBox2.Items.Add("STOK LEBIH DARI STOK MINIMAL")
            ComboBox2.Items.Add("STOK KURANG DARI STOK MINIMAL")
        Else
            ' ComboBox2.Items.Add("SEMUA")
            Dim dt As DataTable = getData("select idkategori,kategori from tblkategori")
            Dim dr As DataRow = dt.NewRow
            dr(0) = "0"
            dr(1) = "SEMUA"

            dt.Rows.InsertAt(dr, 0)
            ComboBox2.DataSource = dt
            ComboBox2.ValueMember = "idkategori"
            ComboBox2.DisplayMember = "kategori"
        End If
        ComboBox2.SelectedIndex = 0
        laporanBarangTanpaHarga()
        status = True
    End Sub


    Sub awal()
        ' Me.WindowState = FormWindowState.Maximized
        ComboBox1.SelectedIndex = 0
        If status Then
            laporanBarangTanpaHarga()
        End If
        getCabang()
    End Sub

    Private Sub PreviewBarangPer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub laporanBarangTanpaHarga()

        Dim cari = ""
        If ComboBox1.SelectedIndex = 0 Then
            If ComboBox2.SelectedIndex = 0 Then
                cari = "and (stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2) = 0"
            ElseIf ComboBox2.SelectedIndex = 1 Then
                cari = "and (stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2) > stokmin"
            Else
                cari = "and (stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2) < stokmin"

            End If
        Else
            If ComboBox2.SelectedIndex = 0 Then
                cari = ""
            Else
                cari = "and idkategori = " & ComboBox2.SelectedValue
            End If


        End If
        sql =
            "Select idproduk, produk, kategori,  (stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2) As stokis from view_produk As T1 where (produk Like '%" &
            eCari.Text & "%' or idproduk like '%" & eCari.Text & "%') " & cari
        If statusCabang Then
            If Not ComboBox3.SelectedIndex = 0 Then
                sql &= " AND cabang=" & ComboBox3.SelectedValue
            End If
        End If
        Try
            DataGridView1.Columns(0).HeaderText = "Kode Produk"
            DataGridView1.Columns(1).HeaderText = "Produk"

            DataGridView1.Columns(2).HeaderText = "Kategori"
            DataGridView1.Columns(3).HeaderText = "Stok"

        Catch ex As Exception

        End Try
        DataGridView1.DataSource = getData(sql)
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        styliseDG(DataGridView1)
        ' makeFillDG(DataGridView1)
    End Sub


    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        laporanBarangTanpaHarga()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        laporanBarangTanpaHarga()
    End Sub

    Private Sub ReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            laporanBarangTanpaHarga()

        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If status Then
            laporanBarangTanpaHarga()
        End If
    End Sub

    Dim open As Boolean = True

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If open Then
            open = False
            Dim preview As PreviewBarangPer = New PreviewBarangPer()
            preview.sql = sql
            preview.awal()
            preview.ShowDialog()
            preview.Dispose()
            open = True
        End If
    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles eCari.KeyDown, DataGridView1.KeyDown, ComboBox2.KeyDown, ComboBox1.KeyDown, Button4.KeyDown,
                Button1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            If open Then
                open = False
                Dim preview As PreviewBarangPer = New PreviewBarangPer()
                preview.sql = sql
                preview.awal()
                preview.ShowDialog()
                open = True
            End If

        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) _
        Handles StatusStrip1.ItemClicked
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellContentClick
    End Sub
End Class