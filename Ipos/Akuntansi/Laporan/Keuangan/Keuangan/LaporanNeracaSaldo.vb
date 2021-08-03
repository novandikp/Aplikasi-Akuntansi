Public Class LaporanNeracaSaldo
    Dim dataLaporan As New DataTable
    Dim dataview As DataView
    Sub getDataLaporan()
        Dim sql As String = " SELECT 	
	tblakun.kodeakun,
    tblakun.akun,
    COALESCE(sum(jurnal.debit - jurnal.kredit),0) as saldoawal,
    COALESCE(sum(tbljurnal.debit),0) as debit,
    COALESCE(sum(tbljurnal.kredit),0) as kredit    
    FROM 
    tblakun
    LEFT join tbljurnal
    on tbljurnal.kodeakun = tblakun.kodeakun
    and tbljurnal.tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' and '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'
    LEFT join tbljurnal as jurnal
    on jurnal.kodeakun = tblakun.kodeakun
    and jurnal.tgljurnal < '" & dtAwal.Value.ToString("yyyy-MM-dd") & "'
    INNER  JOIN tblsubklasifikasi ON tblakun.idsubklasifikasi = tblsubklasifikasi.idsubklasifikasi 
    and idklasifikasi <= 3
    INNER join tblklasifikasi on  tblklasifikasi.idklasifikasi = tblsubklasifikasi.idklasifikasi
    WHERE tblakun.akun ILIKE '%" & eCari.Text & "%' OR tblakun.kodeakun ILIKE '%" & eCari.Text & "%'
    GROUP by 
    tblakun.kodeakun,
    tblklasifikasi.idklasifikasi, 
    tblsubklasifikasi.idsubklasifikasi
    "

        dataLaporan = getData(sql)

        dataview = New DataView(dataLaporan)


        If Not MetroCheckBox1.Checked Then
            dataview.RowFilter = "saldoawal > 0 OR and debit > 0 and kredit > 0"
        End If

        ListSat.DataSource = dataview
        Dim total As Double = 0


        styliseDG(ListSat)
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Akun"


            ListSat.Columns(1).HeaderText = "Akun"
            ListSat.Columns(2).HeaderText = "Saldo Awal"
            ListSat.Columns(3).HeaderText = "Debit"
            ListSat.Columns(4).HeaderText = "Kredit"


        Catch ex As Exception

        End Try
        For Each row As DataGridViewRow In ListSat.Rows
            total += CDbl(row.Cells(2).Value) + CDbl(row.Cells(3).Value) - CDbl(row.Cells(4).Value)
        Next

        tblTotal.Text = "Total : " & numberFor(total)
    End Sub




    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getDataLaporan()

    End Sub

    Private Sub MetroCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox1.CheckedChanged
        getDataLaporan()
    End Sub

    Private Sub cbKodeKas_CheckedChanged(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        getDataLaporan()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        getDataLaporan()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub tblTotal_Click(sender As Object, e As EventArgs) Handles tblTotal.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewNeracaSaldo.dataview = dataview

        PreviewNeracaSaldo.Show()
    End Sub
End Class