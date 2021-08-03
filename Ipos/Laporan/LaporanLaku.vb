Public Class LaporanLaku
    Public sql As String = ""

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DTawal.ValueChanged
        laporanBarangLengkap()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DtAkhir.ValueChanged
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

    Private Sub DtAkhir_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles MyBase.KeyDown, eCari.KeyDown, DTawal.KeyDown, DtAkhir.KeyDown, DataGridView1.KeyDown, Button4.KeyDown,
                Button1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            If open Then
                open = False
                Dim preview As PreviewTerlaris = New PreviewTerlaris()
                preview.sql = sql
                preview.laporanBarangLengkap()
                preview.ShowDialog()
                open = True
            End If

        End If
    End Sub

    Private Sub PreviewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' MyBase.WindowState = FormWindowState.Maximized
        getCabang()
        laporanBarangLengkap()
    End Sub


    Sub laporanBarangLengkap()

        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"

        Dim awal = DTawal.Value.ToString("yyyy/MM/dd")
        Dim akhir = DtAkhir.Value.ToString("yyyy/MM/dd")
        sql =
            "SELECT view_detailjual.barcode, (select tblproduk.produk from tblproduk where tblproduk.idproduk =view_detailjual.barcode) as produk, sum(view_detailjual.jumlahjual) as stok1, satuanjual,  (select view_harga.hargajual from view_harga where view_harga.satuan = view_detailjual.satuanjual and view_harga.idproduk =view_detailjual.barcode) as hargajual, sum(view_detailjual.jumlahjual) *   (select view_harga.hargajual from view_harga where view_harga.satuan = view_detailjual.satuanjual and view_harga.idproduk =view_detailjual.barcode) as sub  from view_detailjual  where tgljual between ('" &
            awal & " 00:00:00') and ('" & akhir & " 23:59:59') and flag=1 and (produk like '%" & eCari.Text &
            "%' or fakturjual like '%" & eCari.Text & "%') "
        If statusCabang Then
            If Not ComboBox3.SelectedIndex = 0 Then
                sql &= " AND cabang=" & ComboBox3.SelectedValue
            End If
        End If
        sql &= " group by barcode,satuanjual ORDER BY sum(view_detailjual.jumlahjual) desc;"
        Try
            DataGridView1.Columns(0).HeaderText = "Kode Produk"
            DataGridView1.Columns(1).HeaderText = "Produk"
            DataGridView1.Columns(2).HeaderText = "Jumlah"
            DataGridView1.Columns(3).HeaderText = "Satuan"
            DataGridView1.Columns(4).HeaderText = "Harga Jual"
            DataGridView1.Columns(5).HeaderText = "Sub Total"


        Catch ex As Exception

        End Try
        'sql = "SELECT fakturbeli,tglreturbeli, produk, jumlahreturbeli, jumlahbeli, satuanbeli from view_returbeli  where tglreturbeli between ('" & awal & " 00:00:00') and ('" & akhir & " 23:59:59') and (idproduk like '%" & eCari.Text & "%' or produk like '%" & eCari.Text & "%')"
        DataGridView1.DataSource = getData(sql)
        DataGridView1.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        styliseDG(DataGridView1)
        'makeFillDG(DataGridView1)
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
            Dim preview As PreviewTerlaris = New PreviewTerlaris()
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