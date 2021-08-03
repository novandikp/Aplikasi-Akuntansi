Public Class LaporanDetailPesananJualKirim
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        If cbSub.SelectedIndex > 0 Then
            sql = "SELECT tblpesananjual.tglpesananjual, tblpesananjual.kodepesananjual, tblkontak.pelanggan, tbldepartemen.departemen, COALESCE(tblprojek.projek,'N/A') as projek, tblgudang.gudang, tbldetailpesananjual.idbarang, tblproduk.produk, tbldetailpesananjual.jumlahjual, jumlahkirim, tbldetailpesananjual.hargajual from tbldetailpesananjual inner join tblpesananjual on tblpesananjual.kodepesananjual = tbldetailpesananjual.kodepesananjual inner join  tblkontak on tblkontak.idpelanggan = tblpesananjual.pelanggan inner join tbldepartemen on tbldepartemen.iddepartemen = tblpesananjual.kodedepartemen inner join tblgudang on tblgudang.idgudang = tblpesananjual.kodegudang inner join tblproduk on tblproduk.idproduk = tbldetailpesananjual.idbarang left join tblprojek on tblprojek.idprojek  = tblpesananjual.kodeprojek
WHERE (tblpesananjual.kodepesananjual ILIKE '%" & eCari.Text & "%' or departemen ILIKE '%" & eCari.Text & "%'  )
          and kodedepartemen ='" & cbSub.SelectedValue & "' and tglpesananjual BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'"
        Else
            sql = "SELECT tblpesananjual.tglpesananjual, tblpesananjual.kodepesananjual, tblkontak.pelanggan, tbldepartemen.departemen, COALESCE(tblprojek.projek,'N/A') as projek, tblgudang.gudang, tbldetailpesananjual.idbarang, tblproduk.produk, tbldetailpesananjual.jumlahjual, jumlahkirim, tbldetailpesananjual.hargajual from tbldetailpesananjual inner join tblpesananjual on tblpesananjual.kodepesananjual = tbldetailpesananjual.kodepesananjual inner join  tblkontak on tblkontak.idpelanggan = tblpesananjual.pelanggan inner join tbldepartemen on tbldepartemen.iddepartemen = tblpesananjual.kodedepartemen inner join tblgudang on tblgudang.idgudang = tblpesananjual.kodegudang inner join tblproduk on tblproduk.idproduk = tbldetailpesananjual.idbarang left join tblprojek on tblprojek.idprojek  = tblpesananjual.kodeprojek
WHERE (tblpesananjual.kodepesananjual ILIKE '%" & eCari.Text & "%' or departemen ILIKE '%" & eCari.Text & "%'  )
           and tglpesananjual BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'"
        End If


        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        Debug.WriteLine(sql)
        styliseDG(ListSat)
        Try
            'ListSat.Columns(0).HeaderText = "Tipe"
            'ListSat.Columns(1).HeaderText = "Kode Akun"
            'ListSat.Columns(2).HeaderText = "Akun"
            'ListSat.Columns(3).HeaderText = "Tanggal"
            'ListSat.Columns(4).HeaderText = "Deskripsi"
            'ListSat.Columns(5).HeaderText = "Kode Refrensi"
            'ListSat.Columns(6).HeaderText = "Kode Departemen"
            'ListSat.Columns(7).HeaderText = "Debit"
            'ListSat.Columns(8).HeaderText = "Kredit"
            'ListSat.Columns(9).HeaderText = "Kode Projek"
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
        PreviewPenawaran.dataview = dv
        PreviewPenawaran.ringkasan = Me.ringkasan
        PreviewPenawaran.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub
End Class