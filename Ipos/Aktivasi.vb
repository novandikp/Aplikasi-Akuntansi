Public Class Aktivasi
    Private Sub Aktivasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pesan.Text =
            "Aplikasi ini memiliki batasan sebesar 5 inputan dalam setiap menu. Untuk membuka batasan ini, aktifkan aplikasi ini dengan memasukkan lisence id. Berikut productId:"
        produkID.Text = getRegProduk()
        MaskedTextBox1.Text = ""
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles produkID.Click
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Process.Start("http://www.google.com")
    End Sub

    Sub setFull()
        Dim lisence = seperatorString(hashString(getRegProduk), "-", 4)
        Dim data As String() = lisence.Split("-")
        setLicense(data)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MaskedTextBox1.Text = seperatorString(hashString(produkID.Text), "-", 4) Then
            dialogInfo("Kode Lisensi Benar")
            setFull()

            Form1.setnama()
            Me.Close()
        Else
            dialogError("Kode Lisensi Salah ")
        End If
    End Sub

    Private Sub pesan_Click(sender As Object, e As EventArgs) Handles pesan.Click
    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) _
        Handles MaskedTextBox1.MaskInputRejected
    End Sub

    Dim status = True

    Private Sub MaskedTextBox1_TextChanged(sender As Object, e As EventArgs) Handles MaskedTextBox1.TextChanged
    End Sub

    Private Sub MaskedTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MaskedTextBox1.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Chat.ShowDialog()
        Chat.Dispose()
    End Sub

    Private Sub Aktivasi_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If checkLisence() Then
            Me.Hide()
            Form1.Show()
        Else
            Application.Exit()
        End If
    End Sub
End Class