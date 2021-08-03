Public Class LaporanUmurPiutang

    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()
        sql = "SELECT tbljual.tgljual , tblkontak.pelanggan, tbljual.kodejual, kembali, kembali, kembali, kembali from tbljual inner join tblkontak
        on tblkontak.idpelanggan = tbljual.pelanggan where kembali > 0 and tgljual <= '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' and tblkontak.pelanggan ilike '%" & eCari.Text & "%'"
        dataLaporan = getData(sql)
        Debug.WriteLine(sql)
        For Each row As DataRow In dataLaporan.Rows
            Dim hariData As Date = CDate(row.Item(0))
            Dim hariini As Date = dtAwal.Value
            Dim harike30 As Date = dtAwal.Value.AddDays(-30)
            Dim harike60 As Date = dtAwal.Value.AddDays(-60)
            Dim harike90 As Date = dtAwal.Value.AddDays(-90)
            If hariData <= hariini And hariData >= harike30 Then
                row.Item(4) = "0"
                row.Item(5) = "0"
                row.Item(6) = "0"
            ElseIf hariData < harike30 And hariData >= harike60 Then
                row.Item(3) = "0"
                row.Item(5) = "0"
                row.Item(6) = "0"
            ElseIf hariData < harike60 And hariData >= harike90 Then
                row.Item(4) = "0"
                row.Item(3) = "0"
                row.Item(6) = "0"
            Else
                row.Item(4) = "0"
                row.Item(3) = "0"
                row.Item(5) = "0"
            End If
        Next
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        ListSat.Columns(3).HeaderText = "0 - 30"
        ListSat.Columns(4).HeaderText = "31 - 60"
        ListSat.Columns(5).HeaderText = "61 - 90"
        ListSat.Columns(6).HeaderText = "90 >"
        styliseDG(ListSat)

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

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        getDataLaporan()
    End Sub


    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewPesananJual.dataview = dv
        PreviewPesananJual.ringkasan = Me.ringkasan
        PreviewPesananJual.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
            getDataLaporan()
        End Sub
    End Class