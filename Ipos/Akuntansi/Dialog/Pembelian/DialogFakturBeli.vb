Public Class DialogFakturBeli
    Public kodebeli As String
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

    Private Sub eventKeydown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
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


        Dim sql As String = "SELECT tglbeli,kodebeli, tblkontak.pelanggan, total,diskonrupiah,biayalain,totalpajak,cast(statusbeli as varchar) from tblbeli inner join tblkontak on tblkontak.idpelanggan = tblbeli.pelanggan "
        Dim filter As String = "WHERE (kodebeli ilike '%" & cari & "%' or tblkontak.pelanggan ilike '%" & cari & "%') AND tglbeli BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' order by tglbeli,kodebeli"
        ListSat.DataSource = getData(sql & filter)
        ListSat.Columns(0).HeaderText = "Tanggal"
        ListSat.Columns(1).HeaderText = "Faktur Penbelian"
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


    Private Sub btnKeluar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ListSat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            kodebeli = ListSat.Rows(e.RowIndex).Cells(1).Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class