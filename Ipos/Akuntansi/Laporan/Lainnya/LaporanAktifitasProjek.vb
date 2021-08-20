Public Class LaporanAktifitasProjek
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        Dim cari As String = eCari.Text
        If cbSub.SelectedIndex = 0 Then
            sql = "SELECT tbljurnal.tgljurnal, kodeprojek, projek, tbljurnal.kodeakun,akun,tipe,koderefrensi,debit,kredit,(sum(debit-kredit) OVER (PARTITION by tbljurnal.kodeakun order by tgljurnal,idjurnal)) as mutasi from tbljurnal inner join tblakun on tblakun.kodeakun = tbljurnal.kodeakun inner join tblprojek on tbljurnal.kodeprojek = tblprojek.idprojek 
where (projek like '%" & cari & "%' OR akun like '%" & cari & "%') and  tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "' order by tgljurnal,idjurnal
"
        Else
            sql = "SELECT tbljurnal.tgljurnal, kodeprojek, projek, tbljurnal.kodeakun,akun,tipe,koderefrensi,debit,kredit,(sum(debit-kredit) OVER (PARTITION by tbljurnal.kodeakun order by tgljurnal,idjurnal)) as mutasi from tbljurnal inner join tblakun on tblakun.kodeakun = tbljurnal.kodeakun inner join tblprojek on tbljurnal.kodeprojek = tblprojek.idprojek 
where (projek like '%" & cari & "%' OR akun like '%" & cari & "%') and  tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "' and kodeprojek = '" & cbSub.SelectedValue & "' order by tgljurnal,idjurnal
"
        End If




        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv

        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Tanggal"
            ListSat.Columns(1).HeaderText = "Kode Projek"
            ListSat.Columns(2).HeaderText = "Projek"
            ListSat.Columns(3).HeaderText = "Kode Akun"
            ListSat.Columns(4).HeaderText = "Akun"
            ListSat.Columns(5).HeaderText = "Tipe"
            ListSat.Columns(6).HeaderText = "Kode Refrensi"
            ListSat.Columns(7).HeaderText = "Debit"
            ListSat.Columns(8).HeaderText = "Kredit"
            ListSat.Columns(9).HeaderText = "Mutasi"
        Catch ex As Exception

        End Try


    End Sub

    Public saldoawal As String = "0"

    Private Sub getSubKlasifikasi()
        Dim dt As DataTable = getData("select idprojek, projek from tblprojek order by idprojek")
        Dim dr As DataRow = dt.NewRow
        dr.Item(0) = 0
        dr.Item(1) = "Semua"
        dt.Rows.InsertAt(dr, 0)
        cbSub.DataSource = dt
        cbSub.DisplayMember = "projek"
        cbSub.ValueMember = "idprojek"
    End Sub

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getSubKlasifikasi()
        getDataLaporan()
    End Sub



    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewLaporanAktivitasProjek.dataview = dv

        PreviewLaporanAktivitasProjek.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        getDataLaporan()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        getDataLaporan()
    End Sub
End Class