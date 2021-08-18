Public Class LaporanLabaRugiStandard
    Dim dataLaporan As New DataTable
    Dim dataview As DataView
    Sub getDataLaporan()
        Dim sql As String = "SELECT tblakun.kodeakun,
    tblsubklasifikasi.idsubklasifikasi,
    tblklasifikasi.idklasifikasi,
    tblklasifikasi.klasifikasi,
    tblakun.akun,
    tblsubklasifikasi.subklasifikasi ,
    COALESCE(sum(tbljurnal.debit - tbljurnal.kredit),0) as saldo
    FROM 
    tblakun
    LEFT join tbljurnal
    on tbljurnal.kodeakun = tblakun.kodeakun
    and tbljurnal.tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' and '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'
    INNER  JOIN tblsubklasifikasi ON tblakun.idsubklasifikasi = tblsubklasifikasi.idsubklasifikasi 
    and idklasifikasi > 3
    INNER join tblklasifikasi on  tblklasifikasi.idklasifikasi = tblsubklasifikasi.idklasifikasi
    where (tblakun.kodeakun ILIKE '%" & eCari.Text & "%' OR akun ILIKE '%" & eCari.Text & "%')
    GROUP by 
    tblakun.kodeakun,
    tblklasifikasi.idklasifikasi, 
    tblsubklasifikasi.idsubklasifikasi
    order by tblklasifikasi.idklasifikasi
    "
        Debug.WriteLine(sql)
        dataLaporan = getData(sql)

        dataview = New DataView(dataLaporan)


        If Not MetroCheckBox1.Checked Then
            dataview.RowFilter = "saldo > 0"
        End If

        ListSat.DataSource = dataview
        Dim total As Double = 0


        styliseDG(ListSat)
        makeFillDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Akun"
            ListSat.Columns(1).Visible = False
            ListSat.Columns(2).Visible = False
            ListSat.Columns(3).Visible = False
            ListSat.Columns(5).Visible = False

            ListSat.Columns(4).HeaderText = "Akun"
            ListSat.Columns(4).DefaultCellStyle.Format = "c0"
            ListSat.Columns(6).HeaderText = "Saldo"


        Catch ex As Exception

        End Try
        For Each row As DataGridViewRow In ListSat.Rows
            total += CDbl(row.Cells(6).Value)
        Next

        tblTotal.Text = "Total : " & total.ToString
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
        PreviewLabaRugi.dataview = dataview

        PreviewLabaRugi.Show()
    End Sub
End Class