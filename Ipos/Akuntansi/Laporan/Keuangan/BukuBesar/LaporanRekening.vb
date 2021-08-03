﻿Public Class LaporanRekening
    Dim dataLaporan As New DataTable

    Sub getDataLaporan()
        Dim sql As String = " SELECT tblklasifikasi.idklasifikasi, tblklasifikasi.klasifikasi, tblsubklasifikasi.idsubklasifikasi,
tblsubklasifikasi.subklasifikasi, tblakun.kodeakun, tblakun.akun
from tblakun
inner join tblsubklasifikasi
on tblakun.idsubklasifikasi = tblsubklasifikasi.idsubklasifikasi
inner join tblklasifikasi
on tblsubklasifikasi.idklasifikasi = tblklasifikasi.idklasifikasi
where kodeakun ilike '%" & eCari.Text & "%' and akun ilike '%" & eCari.Text & "%'
order by tblklasifikasi.idklasifikasi,tblsubklasifikasi.idsubklasifikasi, kodeakun"

        dataLaporan = getData(sql)
        ListSat.DataSource = dataLaporan



    End Sub




    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        getDataLaporan()

    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewRekening.dataview = New DataView(dataLaporan)
        PreviewRekening.Show()
    End Sub
End Class