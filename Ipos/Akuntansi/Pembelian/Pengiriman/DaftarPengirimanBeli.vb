Public Class DaftarPengirimanBeli
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


        Dim sql As String = "SELECT tglpengirimanbeli,kodepengirimanbeli, tblkontak.pelanggan, total,diskonrupiah,biayalain,totalpajak,cast(statuspengiriman as varchar) from tblpengirimanbeli inner join tblkontak on tblkontak.idpelanggan = tblpengirimanbeli.pelanggan "
        Dim filter As String = "WHERE (kodepengirimanbeli ilike '%" & cari & "%' or tblkontak.pelanggan ilike '%" & cari & "%') AND tglpengirimanbeli BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' order by tglpengirimanbeli,kodepengirimanbeli"
        ListSat.DataSource = getData(sql & filter)
        ListSat.Columns(0).HeaderText = "Tanggal"
        ListSat.Columns(1).HeaderText = "Kode Pengiriman"
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


    Sub cetakJurnal()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value
            Modul.openJurnalDialog(idselected)
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub


    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        fillData()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        fillData()
    End Sub


    Sub tambahData()
        Dim ds As DialogResult = FormPengirimanBeli.ShowDialog()
        If ds = DialogResult.OK Then

        End If
        fillData()
        FormPengirimanBeli.Dispose()
    End Sub

    Sub editData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value

            Dim pengiriman As New FormPengirimanBeli
            pengiriman.TBnotransaksi.Text = idselected
            pengiriman.edited = True
            Dim ds As DialogResult = pengiriman.ShowDialog()
            If ds = DialogResult.OK Then

            End If
            fillData()
            pengiriman.Dispose()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub

    Sub hapusData()
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(1).Value
            Dim sqlparent As String = "SELECT kodebeli from tblbeli where kodepengirimanbeli='" & idselected & "'"
            If getCount(sqlparent) = 0 Then
                If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                    Dim sqlhapus = "DELETE FROM tblpengirimanbeli where kodepengirimanbeli = '" & idselected & "';"
                    Dim sqlhapusdetail = "DELETE FROM tbldetailpengirimanbeli where kodepengirimanbeli = '" & idselected & "';"
                    exc("update tblstokgudang set stok = stok - sub.jumlahbeli from ( SELECT tbldetailpengirimanbeli.idharga, tbldetailpengirimanbeli.jumlahbeli,tblpengirimanbeli.kodegudang, tbldetailpengirimanbeli.kodepengirimanbeli from tbldetailpengirimanbeli  inner join tblpengirimanbeli on tbldetailpengirimanbeli.kodepengirimanbeli = tblpengirimanbeli.kodepengirimanbeli ) sub where tblstokgudang.idharga = sub.idharga and tblstokgudang.idgudang= sub.kodegudang and kodepengirimanbeli='" & idselected & "'")
                    If exc(sqlhapusdetail & sqlhapus) Then
                        exc("DELETE FROM tblhistoristok where refrensi='" & idselected & "';DELETE FROM tbljurnal WHERE koderefrensi='" & idselected & "';")

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cetakJurnal()
    End Sub
End Class