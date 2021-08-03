Public Class UbahHarga
    Public isidata As DataGridViewRow

    Public row As String = ""
    Public idbarang As String = ""

    Private Sub FormDetailSatuanBeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub awal()
        getSatuan()
        clearForm(GroupBox1)
        Dim query As String = "select * from view_harga where barcode=" & row
        cbSatuan.SelectedValue = getValue(query, "idsatuan")

        TBBeli.Text = getValue(query, "hargabeli")
        TBJual.Text = getValue(query, "hargajual")

        cbSatuan.Focus()
    End Sub

    Sub simpanSatuan()
        Dim idsatuan = cbSatuan.SelectedValue.ToString
        If adaKosong(GroupBox1) Then
            dialogError("Terdapat form masih kosong")

        Else
            Dim namasatuan = cbSatuan.Text
            '  Dim jenis = TBJenis.Text
            '   Dim konversi = tbKonversi.Text
            Dim hargabeli = TBBeli.Text.Replace(",", ".").Replace(".", "")
            Dim hargajual = TBJual.Text.Replace(",", ".").Replace(".", "")
            Dim isidata As String() = New String() {hargabeli, hargajual}
            Dim sql As String = "UPDATE tblharga set  hargabeli = ?, hargajual= ? where barcode= " & row

            If operationQuery(sql, isidata) Then
                LihatHarga.getDataProduk()

                Me.Close()
            End If
        End If
    End Sub


    Sub getSatuan()

        cbSatuan.DataSource = getData("select * from tblsatuan")
        cbSatuan.ValueMember = "idsatuan"
        cbSatuan.DisplayMember = "satuan"
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanSatuan()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub cbSatuan_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles cbSatuan.KeyDown, TBBeli.KeyDown, TBJual.KeyDown, btnSimpan.KeyDown, btnTutup.KeyDown, Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            simpanSatuan()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()

        End If
    End Sub

    Private Sub TBJual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBJual.KeyPress, TBBeli.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub TBBeli_HandleCreated(sender As Object, e As EventArgs) Handles TBBeli.HandleCreated
        TBBeli.Text = numberFormat(TBBeli.Text.ToString)
    End Sub

    Dim checkBeli As Boolean = True

    Private Sub TBBeli_TextChanged(sender As Object, e As EventArgs) Handles TBBeli.TextChanged
        If checkBeli Then
            checkBeli = False
            TBBeli.Text = numberFormat(unnumberFormat(TBBeli.Text))
            TBBeli.SelectionStart = TBBeli.Text.Count
            TBBeli.SelectionLength = 0
            checkBeli = True
        End If
    End Sub

    Private Sub TBJual_HandleCreated(sender As Object, e As EventArgs) Handles TBJual.HandleCreated
        TBJual.Text = numberFormat(TBJual.Text.ToString)
    End Sub

    Dim checkJual As Boolean = True

    Private Sub TBJual_TextChanged(sender As Object, e As EventArgs) Handles TBJual.TextChanged
        If checkJual Then
            checkJual = False
            TBJual.Text = numberFormat(unnumberFormat(TBJual.Text))
            TBJual.SelectionStart = TBJual.Text.Count
            TBJual.SelectionLength = 0
            checkJual = True
        End If
    End Sub
End Class