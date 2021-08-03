Public Class DialogPiutang
    Public idsupplier As String = ""
    Public idhutangtemp As String = ""
    Public total As Double = 0

    Private Sub DialogHutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setIsi()
        Me.ActiveControl = tbBayar
    End Sub

    Sub setIsi()
        Dim sql As String = "select sisasaldp, supplier from view_piutang_temp where idpiutangtemp=" & idhutangtemp
        total = Double.Parse(getValue(sql, "sisasaldp"))
        tbTotal.Text = numberFormat(total.ToString)
        TextBox1.Text = getValue(sql, "supplier")
    End Sub

    Dim check As Boolean = True

    Private Sub tbBayar_TextChanged(sender As Object, e As EventArgs) Handles tbBayar.TextChanged
        If check Then
            check = False
            tbBayar.Text = numberFormat(unnumberFormat(tbBayar.Text))
            tbBayar.SelectionStart = tbBayar.Text.Count
            tbBayar.SelectionLength = 0
            check = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbBayar.Text = "10000"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbBayar.Text = "20000"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tbBayar.Text = "50000"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbBayar.Text = "100000"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Sub pembayaran()
        If String.IsNullOrWhiteSpace(tbBayar.Text) Then
            dialogError("Pembayaran masih kosong")
        Else
            If Double.Parse(unnumberFormat(tbBayar.Text)) > total Then
                dialogError("Pembayaran kelebihan")
            Else
                If String.IsNullOrWhiteSpace(Keterangan.Text.ToString) Then
                    Keterangan.Text = "-"
                End If
                Dim saldo As Double = total - Double.Parse(unnumberFormat(tbBayar.Text))
                Dim sql As String =
                        "INSERT INTO tblpiutang (idpiutangtemp, bayarpiutang, tglpiutang, ketpiutang, saldo) VALUES (?,?,?,?,?)"
                If _
                    operationQuery(sql,
                                   New String() _
                                      {idhutangtemp, unnumberFormat(tbBayar.Text),
                                       Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), Keterangan.Text,
                                       saldo.ToString}) Then
                    exc(
                        "update tblpituangtemporal set sisasaldp = sisasaldp - " & unnumberFormat(tbBayar.Text) &
                        ",jumlahbayar = jumlahbayar + " & unnumberFormat(tbBayar.Text) & " where idpiutangtemp=" &
                        idhutangtemp)
                    exc(
                        "update tblsupplier set piutang = piutang - " & unnumberFormat(tbBayar.Text) &
                        " where idsupplier=" & idsupplier)
                    DatagridPiutang.getDataPelanggan()
                    Me.Close()

                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TextBox1.KeyDown, tbTotal.KeyDown, tbBayar.KeyDown, Button6.KeyDown, Button5.KeyDown, Button4.KeyDown,
                Button3.KeyDown, Button2.KeyDown, Button1.KeyDown
        If e.KeyCode = Keys.F11 Then
            pembayaran()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub


    Private Sub tbBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBayar.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        pembayaran()
    End Sub
End Class