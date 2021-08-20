Public Class LaporanDepartemen


    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String


    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        Dim cari As String = eCari.Text
        sql = "SELECT iddepartemen as kodedepartemen, departemen, pelanggan from tbldepartemen inner join tblkontak on tblkontak.idpelanggan = tbldepartemen.penanggunjawab where (pelanggan ilike '%" & cari & "%' or iddepartemen ilike '%" & cari & "%' or departemen ilike '%" & cari & "%')"

        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)

        ListSat.DataSource = dv
        Debug.WriteLine("SQL CARI :" & sql)
        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Departemen"
            ListSat.Columns(1).HeaderText = "Departemen"
            ListSat.Columns(2).HeaderText = "Penanggung Jawab"
        Catch ex As Exception

        End Try
        makeFillDG(ListSat)

    End Sub

    Public saldoawal As String = "0"

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        getDataLaporan()
    End Sub



    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewLaporanDepartemen.dataview = dv

        PreviewLaporanDepartemen.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub

End Class