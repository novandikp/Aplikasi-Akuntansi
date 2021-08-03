Public Class LaporanSupplier
    Public sql As String = ""
    Public  tipe as Integer  = 0

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

    Private Sub PreviewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' MyBase.WindowState = FormWindowState.Maximized
        getCabang()
        laporanBarangLengkap()
    End Sub

    Private Sub eCari_KeyDown_1(sender As Object, e As KeyEventArgs) _
        Handles MyBase.KeyDown, eCari.KeyDown, DataGridView1.KeyDown, Button4.KeyDown, Button1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            If open Then
                open = False
                Dim preview As PreviewSupplier = New PreviewSupplier()
                preview.sql = sql
                preview.laporanBarangLengkap()
                preview.ShowDialog()
                open = True
            End If

        End If
    End Sub


    Sub laporanBarangLengkap()

        If tipe = 0 Then
            Me.Text = "Laporan Supplier"
            Dim sqlidentitas As String =
                    "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
            sql = "SELECT supplier,alamatsupplier, nosupplier from tblsupplier  where (supplier like '%" & eCari.Text &
                  "%' or alamatsupplier like '%" & eCari.Text & "%') and not idsupplier = 2"
            If statusCabang Then
                If Not ComboBox3.SelectedIndex = 0 Then
                    sql &= " AND idcabang=" & ComboBox3.SelectedValue
                End If
            End If
            DataGridView1.DataSource = getData(sql)
            Try
                DataGridView1.Columns(0).HeaderText = "Supplier"
                DataGridView1.Columns(1).HeaderText = "Alamat"
                DataGridView1.Columns(2).HeaderText = "Telepon"


            Catch ex As Exception

            End Try
        Else
            Me.Text = "Laporan Teknisi"
            Dim sqlidentitas As String =
                    "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
            sql = "SELECT  dokter as supplier, alamatdokter as alamatsupplier, nodokter as nosupplier, sid as piutang from tbldokter  where (dokter like '%" & eCari.Text &
                  "%' or alamatdokter like '%" & eCari.Text & "%') and iddokter > 1 "
            If statusCabang Then
                If Not ComboBox3.SelectedIndex = 0 Then
                    sql &= " AND rs='" & ComboBox3.SelectedValue & "'"
                End If
            End If
            DataGridView1.DataSource = getData(sql)
            Try
                DataGridView1.Columns(0).HeaderText = "Teknisi"
                DataGridView1.Columns(1).HeaderText = "Alamat"
                DataGridView1.Columns(2).HeaderText = "Telepon"
                DataGridView1.Columns(3).HeaderText = "Pendapatan"


            Catch ex As Exception

            End Try
        End If
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
            Dim preview As PreviewSupplier = New PreviewSupplier()
            preview.sql = sql
            preview.tipe = tipe
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