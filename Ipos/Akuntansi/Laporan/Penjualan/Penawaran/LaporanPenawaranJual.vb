Public Class LaporanPenawaranJual
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()
        If ringkasan Then
            makeFillDG(ListSat)
            If cbSub.SelectedIndex > 0 Then
                sql = "SELECT tglpenawaranjual as tglpenawaran, kodepenawaranjual, tblkontak.pelanggan as idkontak,total, totalpajak
FROM tblpenawaranjual
INNER join tblkontak
on tblkontak.idpelanggan = tblpenawaranjual.pelanggan
        WHERE (kodepenawaranjual ILIKE '%" & eCari.Text & "%' or tblkontak.pelanggan ILIKE '%" & eCari.Text & "%'  )
          and kodedepartemen ='" & cbSub.SelectedValue & "' and tglpenawaranjual BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'"
            Else
                sql = "SELECT tglpenawaranjual as tglpenawaran, kodepenawaranjual, tblkontak.pelanggan as idkontak,total, totalpajak
FROM tblpenawaranjual
INNER join tblkontak
on tblkontak.idpelanggan = tblpenawaranjual.pelanggan
        WHERE (kodepenawaranjual ILIKE '%" & eCari.Text & "%' or tblkontak.pelanggan ILIKE '%" & eCari.Text & "%'  )
          and  tglpenawaranjual BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'"
            End If
        Else
            If cbSub.SelectedIndex > 0 Then
                sql = "SELECT tglpenawaranjual as tglpenawaran, kodepenawaranjual, tbldepartemen.departemen as kodedepartemen, COALESCE(kodeprojek,'N\A') as kodeprojek,total, diskonrupiah, diskonpersen, totalpajak, biayalain
FROM tblpenawaranjual
INNER join tbldepartemen
on tbldepartemen.iddepartemen = tblpenawaranjual.kodedepartemen
WHERE (kodepenawaranjual ILIKE '%" & eCari.Text & "%' or departemen ILIKE '%" & eCari.Text & "%'  )
          and kodedepartemen ='" & cbSub.SelectedValue & "' and tglpenawaranjual BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'"
            Else
                sql = "SELECT tglpenawaranjual as tglpenawaran, kodepenawaranjual, tbldepartemen.departemen as kodedepartemen, COALESCE(kodeprojek,'N\A') as kodeprojek,total, diskonrupiah, diskonpersen, totalpajak, biayalain
FROM tblpenawaranjual
INNER join tbldepartemen
on tbldepartemen.iddepartemen = tblpenawaranjual.kodedepartemen
WHERE (kodepenawaranjual ILIKE '%" & eCari.Text & "%' or departemen ILIKE '%" & eCari.Text & "%'  )
           and tglpenawaranjual BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'"
            End If

        End If
        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        Debug.WriteLine(sql)
        styliseDG(ListSat)
        Try

            If ringkasan Then
                ListSat.Columns(0).HeaderText = "Tanggal"
                ListSat.Columns(1).HeaderText = "Kode Penawaran"
                ListSat.Columns(2).HeaderText = "Pelanggan"
                ListSat.Columns(3).HeaderText = "Total"
                ListSat.Columns(4).HeaderText = "Total Pajak"
            Else
                ListSat.Columns(0).HeaderText = "Tanggal"
                ListSat.Columns(1).HeaderText = "Kode Penawaran"
                ListSat.Columns(2).HeaderText = "Departemen"
                ListSat.Columns(3).HeaderText = "Projek"
                ListSat.Columns(4).HeaderText = "Total"
                ListSat.Columns(5).HeaderText = "Diskon Rupiah"
                ListSat.Columns(6).HeaderText = "Diskon Persen"
                ListSat.Columns(7).HeaderText = "Total Pajak"
                ListSat.Columns(8).HeaderText = "Biaya Lain"
                ListSat.Columns(4).DisplayIndex = 6
            End If
        Catch ex As Exception

        End Try


    End Sub

    Public saldoawal As String = "0"

    Private Sub getSubKlasifikasi()
        Dim dt As DataTable = getData("select iddepartemen, departemen from tbldepartemen order by iddepartemen")
        Dim dr As DataRow = dt.NewRow
        dr.Item(0) = 0
        dr.Item(1) = "Semua"
        dt.Rows.InsertAt(dr, 0)
        cbSub.DataSource = dt
        cbSub.DisplayMember = "departemen"
        cbSub.ValueMember = "iddepartemen"
    End Sub

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getSubKlasifikasi()
        getDataLaporan()
    End Sub


    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        getDataLaporan()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        getDataLaporan()
    End Sub


    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewPenawaranJual.dataview = dv
        PreviewPenawaranJual.ringkasan = Me.ringkasan
        PreviewPenawaranJual.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub
End Class