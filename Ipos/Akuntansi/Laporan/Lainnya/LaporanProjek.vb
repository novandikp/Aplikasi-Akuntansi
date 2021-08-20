Public Class LaporanProjek


    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String


    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        Dim cari As String = eCari.Text
        sql = "SELECT idprojek, projek, tblkontak.pelanggan,manager.pelanggan as manajer, persentase || '%'  as persentase,status from tblprojek 
inner join tblkontak on tblkontak.idpelanggan = tblprojek.pelanggan 
inner join tblkontak as manager on manager.idpelanggan = tblprojek.manajer 
inner join tblstatus on tblstatus.idstatus = tblprojek.idstatus
 where (tblkontak.pelanggan ilike '%" & cari & "%' or projek ilike '%" & cari & "%' )"

        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)

        ListSat.DataSource = dv

        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Projek"
            ListSat.Columns(1).HeaderText = "Projek"
            ListSat.Columns(2).HeaderText = "Pelanggan"
            ListSat.Columns(3).HeaderText = "Manajer"
            ListSat.Columns(4).HeaderText = "Persentase"
            ListSat.Columns(5).HeaderText = "Status"

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
        PreviewLaporanProjek.dataview = dv

        PreviewLaporanProjek.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub

End Class