Public Class DatagridBukuBesar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cariAkun()
    End Sub

    Sub cariAkun()
        Dim dialogakun As New DialogAkun
        Dim ds As DialogResult = dialogakun.ShowDialog
        If ds = DialogResult.OK Then
            cbSub.SelectedValue = dialogakun.idakun
        End If
        dialogakun.Dispose()
    End Sub

    Sub addhandlertoAllComponent()
        For Each komponen As Control In Me.Controls
            AddHandler komponen.KeyDown, AddressOf eventKeydown
            If komponen.Controls.Count > 0 Then
                For Each komponen2 As Control In komponen.Controls
                    AddHandler komponen2.KeyDown, AddressOf eventKeydown
                    If komponen2.Controls.Count > 0 Then
                        For Each komponen3 As Control In komponen2.Controls
                            AddHandler komponen3.KeyDown, AddressOf eventKeydown
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub eventKeydown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F1 Then
            cariAkun()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub

    Sub fillAkun()
        Dim sql As String = "SELECT tblakun.akun, tblakun.kodeakun from tblakun"
        cbSub.DataSource = getData(sql)
        cbSub.DisplayMember = "akun"
        cbSub.ValueMember = "kodeakun"
        cbSub.SelectedIndex = 0
    End Sub

    Sub AllTotal()
        Dim totalakhir As Double = 0
        Dim totaldebit As Double = 0
        Dim totalkredit As Double = 0
        For Each row As DataGridViewRow In ListSat.Rows
            Dim debit = row.Cells(4).Value
            Dim kredit = row.Cells(5).Value
            totaldebit = totaldebit + debit
            totalkredit = totalkredit + kredit
            totalakhir = totalakhir + (debit - kredit)
        Next
        Dim tglAwal As String = dtAwal.Value.ToString("yyyy-MM-dd")
        Dim sql As String = "select sum(debit-kredit) as saldo from tbljurnal where kodeakun='" & cbSub.SelectedValue.ToString & "' and tgljurnal < '" & tglAwal & "'"
        Dim saldoawal As Double = toDouble(getValue(sql, "saldo"))
        lblSaldoAwal.Text = numberFormat(saldoawal.ToString)
        lbltotalAkhir.Text = numberFormat((totalakhir + saldoawal).ToString())
        lbltotalDebit.Text = numberFormat(totaldebit.ToString())
        lbltotalKredit.Text = numberFormat(totalkredit.ToString())
    End Sub



    Sub fillData()
        Dim cari As String = eCari.Text
        Dim tglAwal As String = dtAwal.Value.ToString("yyyy-MM-dd")
        Dim tglAkhir As String = dtAkhir.Value.ToString("yyyy-MM-dd")

        If Not IsNothing(cbSub.SelectedValue) Then
            Dim sql As String = "SELECT koderefrensi, tgljurnal,akun, pelanggan, debit,kredit  from tbljurnal inner join tblakun on tbljurnal.kodeakun = tblakun.kodeakun inner join tblkontak on tblkontak.idpelanggan = tbljurnal.kontak "
            Dim filter As String = "WHERE tblakun.kodeakun='" & cbSub.SelectedValue.ToString & "' and (koderefrensi ilike '%" & cari & "%' or akun ilike '%" & cari & "%'or pelanggan ilike '%" & cari & "%') AND tgljurnal BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' order by tgljurnal,idjurnal"

            ListSat.DataSource = getData(sql & filter)
            ListSat.Columns(0).HeaderText = "Kode Refrensi"
            ListSat.Columns(1).HeaderText = "Tanggal Jurnal"
            ListSat.Columns(2).HeaderText = "Akun"
            ListSat.Columns(3).HeaderText = "Kontak"
            ListSat.Columns(4).HeaderText = "Debit"
            ListSat.Columns(5).HeaderText = "Kredit"
            ListSat.Columns(4).DefaultCellStyle.Format = "n0"
            ListSat.Columns(5).DefaultCellStyle.Format = "n0"


            AllTotal()
        End If
        makeFillDG(ListSat)

    End Sub

    Private Sub DatagridBukuBesar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillAkun()
        fillData()
        styliseDG(ListSat)
        addhandlertoAllComponent()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        fillData()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        fillData()
    End Sub

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        If cbSub.Items.Count > 0 Then
            fillData()
        End If

    End Sub
End Class