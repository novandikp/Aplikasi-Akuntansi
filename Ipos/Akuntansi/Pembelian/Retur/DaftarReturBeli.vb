Public Class DaftarReturBeli

    Sub addhandlertoAllComponent()
        For Each komponen As Control In Me.Controls
            AddHandler komponen.KeyDown, AddressOf eventKeydown
            If komponen.Controls.Count > 0 Then
                For Each komponen2 As Control In komponen.Controls
                    AddHandler komponen2.KeyDown, AddressOf eventKeydown
                    If komponen2.Controls.Count > 0 Then
                        For Each komponen3 As Control In komponen2.Controls
                            AddHandler komponen3.KeyDown, AddressOf eventKeydown
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub eventKeydown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F1 Then
            tambahData()
        ElseIf e.KeyCode = Keys.Delete Then
            hapusData()
        ElseIf e.KeyCode = Keys.F2 Then
            editData()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub

    Sub AllTotal()

        For Each row As DataGridViewRow In ListSat.Rows
            Dim total = row.Cells(3).Value
            Dim diskon = row.Cells(4).Value
            Dim biayalain = row.Cells(5).Value
            Dim pajak = row.Cells(6).Value
            row.Cells(3).Value = total + biayalain + pajak
        Next
        ListSat.Columns(3).DefaultCellStyle.Format = "n0"
    End Sub

    Sub fillData()
        Dim cari As String = eCari.Text
        Dim tglAwal As String = dtAwal.Value.ToString("yyyy-MM-dd")
        Dim tglAkhir As String = dtAkhir.Value.ToString("yyyy-MM-dd")


        Dim sql As String = "SELECT tglreturbeli,kodereturbeli, tblkontak.pelanggan, total,diskonrupiah,biayalain,totalpajak,cast(statusreturbeli as varchar) from tblreturbeli inner join tblkontak on tblkontak.idpelanggan = tblreturbeli.pelanggan "
        Dim filter As String = "WHERE (kodereturbeli ilike '%" & cari & "%' or tblkontak.pelanggan ilike '%" & cari & "%') AND tglreturbeli BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' order by tglreturbeli,kodereturbeli"
        ListSat.DataSource = getData(sql & filter)
        ListSat.Columns(0).HeaderText = "Tanggal"
        ListSat.Columns(1).HeaderText = "Retur Penbelian"
        ListSat.Columns(2).HeaderText = "Pelanggan"

        ListSat.Columns(3).HeaderText = "Nilai"
        ListSat.Columns(4).Visible = False
        ListSat.Columns(5).Visible = False
        ListSat.Columns(6).Visible = False
        ListSat.Columns(7).HeaderText = "Status"


        AllTotal()
        setStatusDataGrid(ListSat, 7)
        makeFillDG(ListSat)

    End Sub

    Private Sub DatagridBukuBesar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillData()
        styliseDG(ListSat)
        addhandlertoAllComponent()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        fillData()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        fillData()
    End Sub


    Sub tambahData()
        Dim ds As DialogResult = FormReturbeli.ShowDialog()
        If ds = DialogResult.OK Then

        End If
        fillData()
        FormReturbeli.Dispose()
    End Sub

    Sub editData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value

            Dim pesanan As New FormReturbeli
            pesanan.TBnotransaksi.Text = idselected
            pesanan.edited = True
            Dim ds As DialogResult = pesanan.ShowDialog()
            If ds = DialogResult.OK Then

            End If
            fillData()
            pesanan.Dispose()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub hapusData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value
            Dim sqlparent As String = "SELECT kodereturbeli from tblreturbeli where kodereturbeli='" & idselected & "'"
            If True Then
                If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                    Dim sqlhapus = "DELETE FROM tblreturbeli where kodereturbeli = '" & idselected & "';"
                    Dim sqlhapusdetail = "DELETE FROM tbldetailreturbeli where kodereturbeli = '" & idselected & "';"
                    If exc(sqlhapusdetail & sqlhapus) Then
                        fillData()
                    Else
                        dialogError("Data tidak bisa dihapus karena data telah digunakan")
                    End If
                End If
            Else
                dialogError("Transaksi telah dipakai")
            End If

        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub
    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambahData()
    End Sub

    Private Sub btnEdt_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
        editData()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapusData()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class