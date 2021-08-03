Public Class LaporanArusKas

    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String
    Sub getDataLaporan()

        If cbSub.SelectedIndex > 0 Then
            sql = " SELECT tblakun.kodeakun,
        tblakun.idsubklasifikasi,
        tblklasifikasi.idklasifikasi,
        tblklasifikasi.klasifikasi,
        tblsubklasifikasi.idsubklasifikasi ,
        tblsubklasifikasi.subklasifikasi ,
        tblakun.akun,
        tblsubklasifikasi.tipearuskas,
        COALESCE(sum(tbljurnal.debit - tbljurnal.kredit),0) as saldo
        FROM 
        tblakun
        LEFT join tbljurnal
        on tbljurnal.kodeakun = tblakun.kodeakun and  tbljurnal.tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'
        INNER  JOIN tblsubklasifikasi ON tblakun.idsubklasifikasi = tblsubklasifikasi.idsubklasifikasi AND tipearuskas != 'UNDEFINED' and tblsubklasifikasi.idsubklasifikasi = '" & cbSub.SelectedValue & "'
        INNER join tblklasifikasi on  tblklasifikasi.idklasifikasi = tblsubklasifikasi.idklasifikasi
        WHERE tblakun.kodeakun ILIKE '%" & eCari.Text & "%' OR akun ILIKE '%" & eCari.Text & "%'
        GROUP by 
        tblakun.kodeakun,
        tblklasifikasi.idklasifikasi, 
        tblsubklasifikasi.idsubklasifikasi,
        tipearuskas
        "
        Else
            sql = " SELECT tblakun.kodeakun,
        tblakun.idsubklasifikasi,
        tblklasifikasi.idklasifikasi,
        tblklasifikasi.klasifikasi,
        tblsubklasifikasi.idsubklasifikasi ,
        tblsubklasifikasi.subklasifikasi ,
        tblakun.akun,
        tblsubklasifikasi.tipearuskas,
        COALESCE(sum(tbljurnal.debit - tbljurnal.kredit),0) as saldo
        FROM 
        tblakun
        LEFT join tbljurnal
        on tbljurnal.kodeakun = tblakun.kodeakun and  tbljurnal.tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'
        INNER  JOIN tblsubklasifikasi ON tblakun.idsubklasifikasi = tblsubklasifikasi.idsubklasifikasi AND tipearuskas != 'UNDEFINED' 
        INNER join tblklasifikasi on  tblklasifikasi.idklasifikasi = tblsubklasifikasi.idklasifikasi
        WHERE tblakun.kodeakun ILIKE '%" & eCari.Text & "%' OR akun ILIKE '%" & eCari.Text & "%'
        GROUP by 
        tblakun.kodeakun,
        tblklasifikasi.idklasifikasi, 
        tblsubklasifikasi.idsubklasifikasi,
        tipearuskas
        "

        End If



        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        If Not cbSaldo0.Checked Then
            dv.RowFilter = "saldo > 0"
        End If

        ListSat.DataSource = dv


        If Not cbKodeKas.Checked Then
            For Each row As DataGridViewRow In ListSat.Rows
                row.Cells(0).Value = "-"
            Next
        End If

        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Akun"
            ListSat.Columns(1).Visible = False
            ListSat.Columns(2).Visible = False
            ListSat.Columns(3).Visible = False
            ListSat.Columns(4).Visible = False
            ListSat.Columns(5).Visible = False
            ListSat.Columns(6).HeaderText = "Akun"
            ListSat.Columns(7).HeaderText = "Arus Kas"
            ListSat.Columns(8).HeaderText = "Saldo"
            ListSat.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            ListSat.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception

        End Try


    End Sub

    Public saldoawal As String = "0"
    Sub getSaldoAwal()
        Dim sqltotal As String
        If cbSub.SelectedIndex > 0 Then
            sqltotal = "SELECT COALESCE(sum(tbljurnal.debit - tbljurnal.kredit),0) as saldo from tbljurnal 
        INNER JOIN tblakun   on tblakun.kodeakun = tbljurnal.kodeakun
        RIGHT JOIN tblsubklasifikasi   on tblakun.idsubklasifikasi = tblsubklasifikasi.idsubklasifikasi  and tblsubklasifikasi.tipearuskas != 'UNDEFINED' and tblsubklasifikasi.idklasifikasi = '" & cbSub.SelectedValue & "'
        WHERE tbljurnal.tgljurnal < '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' 
        and (tbljurnal.kodeakun ILIKE '%" & eCari.Text & "%' OR akun ILIKE '%" & eCari.Text & "%')
        "
        Else
            sqltotal = "SELECT COALESCE(sum(tbljurnal.debit - tbljurnal.kredit),0) as saldo from tbljurnal 
        INNER JOIN tblakun   on tblakun.kodeakun = tbljurnal.kodeakun
        RIGHT JOIN tblsubklasifikasi   on tblakun.idsubklasifikasi = tblsubklasifikasi.idsubklasifikasi  and tblsubklasifikasi.tipearuskas != 'UNDEFINED'
        WHERE tbljurnal.tgljurnal < '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' 
        and (tbljurnal.kodeakun ILIKE '%" & eCari.Text & "%' OR akun ILIKE '%" & eCari.Text & "%')
        "

        End If

        saldoawal = getValue(sqltotal, "saldo")


    End Sub

    Sub getAllTotal()
        Dim sqltotal As String
        If cbSub.SelectedIndex > 0 Then
            sqltotal = "SELECT COALESCE(sum(tbljurnal.debit - tbljurnal.kredit),0) as saldo, tblsubklasifikasi.tipearuskas from tbljurnal 
        INNER JOIN tblakun   on tblakun.kodeakun = tbljurnal.kodeakun
        RIGHT JOIN tblsubklasifikasi   on tblakun.idsubklasifikasi = tblsubklasifikasi.idsubklasifikasi and tblsubklasifikasi.idsubklasifikasi = '" & cbSub.SelectedValue.ToString & "'
        WHERE tbljurnal.tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'
        and (tbljurnal.kodeakun ILIKE '%" & eCari.Text & "%' OR akun ILIKE '%" & eCari.Text & "%')
        GROUP by tblsubklasifikasi.tipearuskas"
        Else
            sqltotal = "SELECT COALESCE(sum(tbljurnal.debit - tbljurnal.kredit),0) as saldo, tblsubklasifikasi.tipearuskas from tbljurnal 
        INNER JOIN tblakun   on tblakun.kodeakun = tbljurnal.kodeakun
        RIGHT JOIN tblsubklasifikasi   on tblakun.idsubklasifikasi = tblsubklasifikasi.idsubklasifikasi
        WHERE tbljurnal.tgljurnal BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'
        and (tbljurnal.kodeakun ILIKE '%" & eCari.Text & "%' OR akun ILIKE '%" & eCari.Text & "%')
        GROUP by tblsubklasifikasi.tipearuskas"

        End If


        Dim totalinvesting As String = "0"
        Dim totaloperation As String = "0"
        Dim totalfinancing As String = "0"
        Dim dataTotal As DataTable = getData(sqltotal)

        For Each row As DataRow In dataTotal.Rows
            If row.Item("tipearuskas") = "Investing" Then
                totalinvesting = numberFormat(row.Item("saldo"))
            ElseIf row.Item("tipearuskas") = "Financial" Then
                totalfinancing = numberFormat(row.Item("saldo"))
            ElseIf row.Item("tipearuskas") = "Operating" Then
                totaloperation = numberFormat(row.Item("saldo"))
            End If
        Next

        tbTotalFinancing.Text = "Financing : "
        tbTotalInvesting.Text = "Investing : "
        tbTotalOperating.Text = "Operating : "

        MetroLabel1.Text = totalfinancing & Environment.NewLine
        MetroLabel2.Text = totalinvesting & Environment.NewLine
        MetroLabel3.Text = totaloperation & Environment.NewLine
        getSaldoAwal()
    End Sub

    Private Sub getSubKlasifikasi()
        Dim dt As DataTable = getData("select idklasifikasi, klasifikasi from tblklasifikasi order by idklasifikasi")
        Dim dr As DataRow = dt.NewRow
        dr.Item("idklasifikasi") = 0
        dr.Item("klasifikasi") = "Semua"
        dt.Rows.InsertAt(dr, 0)
        cbSub.DataSource = dt
        cbSub.DisplayMember = "klasifikasi"
        cbSub.ValueMember = "idklasifikasi"
    End Sub

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getSubKlasifikasi()
        getDataLaporan()
        getAllTotal()

    End Sub

    Private Sub MetroCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbSaldo0.CheckedChanged
        getDataLaporan()
    End Sub

    Private Sub cbKodeKas_CheckedChanged(sender As Object, e As EventArgs) Handles cbKodeKas.CheckedChanged
        getDataLaporan()

    End Sub

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
        getAllTotal()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged

        getDataLaporan()
        getAllTotal()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        getDataLaporan()
        getAllTotal()
    End Sub


    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
        getAllTotal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewArusKAs.sql = sql
        PreviewArusKAs.dataview = dv
        PreviewArusKAs.saldoawal = CDbl(saldoawal)
        PreviewArusKAs.Show()
    End Sub
End Class