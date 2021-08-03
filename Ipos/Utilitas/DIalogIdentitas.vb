Imports System.IO

Public Class DIalogIdentitas
    Public idpelanggan As String = "0"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub

    Sub setIsi()
        Dim query As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota, bank, anbank, rekening, pemilik, bendahara from tblidentitas where idtoko=1"
        TBpelanggan.ReadOnly = True
        TBpelanggan.Text = getValue(query, "namatoko")
        TBalamat.Text = getValue(query, "alamatoko")
        TBtelepon.Text = getValue(query, "notoko")
        TBKota.Text = getValue(query, "kota")
        cap1.Text = getValue(query, "caption1")
        cap2.Text = getValue(query, "caption2")
        cap3.Text = getValue(query, "caption3")
        PictureBox1.ImageLocation = getLogo()
        TBBank.Text = getValue(query, "bank")
        TBRek.Text = getValue(query, "rekening")
        TBAnBank.Text = getValue(query, "anbank")
        TBPemilik.Text = getValue(query, "pemilik")
        TBBendahara.Text = getValue(query, "bendahara")


        If getValue(query, "printstruk") = "58 mm" Then
            ComboBox1.SelectedIndex = 0
        ElseIf getValue(query, "printstruk") = "70 mm" Then
            ComboBox1.SelectedIndex = 1
        Else
            ComboBox1.SelectedIndex = 2

        End If
    End Sub


    Sub awal()

        If pro Then
            TBpelanggan.Enabled = True
            TBalamat.Enabled = True
            TBtelepon.Enabled = True
        Else
            TBpelanggan.Enabled = True
            TBalamat.Enabled = True
            TBtelepon.Enabled = True
        End If
        clearForm(GroupBox1)

        setIsi()
        TBpelanggan.Focus()
    End Sub

    Private Sub AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Sub simpanBarang()
        If adaKosong(GroupBox1) Then
            dialogError("Terdapat form yang masih kosong")
        ElseIf Not File.Exists(PictureBox1.ImageLocation) Then
            dialogError("File tidak ditemukan")
        Else
            Dim namaPelanggan As String = TBpelanggan.Text
            Dim alamatPelanggan As String = TBalamat.Text
            Dim noPelanggan As String = TBtelepon.Text

            Dim bank = TBBank.Text
            Dim rekening = TBRek.Text
            Dim anbank = TBAnBank.Text

            Dim pemilik = TBPemilik.Text
            Dim bendahara = TBBendahara.Text

            Dim struk As String
            If ComboBox1.SelectedIndex = 0 Then
                struk = "58 mm"
            ElseIf ComboBox1.SelectedIndex = 1 Then
                struk = "70 mm"
            Else
                struk = "A5"
            End If


            Dim isi() As String =
                    {namaPelanggan, alamatPelanggan, noPelanggan, cap1.Text, cap2.Text, cap3.Text, struk,
                     PictureBox1.ImageLocation, TBKota.Text, bank, anbank, rekening, pemilik, bendahara}
            If _
                operationQuery(
                    "update tblidentitas set namatoko =?, alamatoko = ?, notoko = ?, caption1 = ?, caption2 = ?, caption3 = ?, printstruk=?, logo=?, kota=?, bank = ?, anbank = ?, rekening = ?, pemilik = ?, bendahara = ? where idtoko=1",
                    isi) Then
                dialogInfo("Identitas berhasil diubah")

                Form1.setnama()
                closeTab()
            End If


        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBpelanggan.KeyDown, TBtelepon.KeyDown, TBalamat.KeyDown, btnSimpan.KeyDown, btnTutup.KeyDown,
                GroupBox1.KeyDown, Me.KeyDown, cap1.KeyDown, cap2.KeyDown, cap3.KeyDown, ComboBox1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        ElseIf e.KeyCode = Keys.F11 Then
            simpanBarang()

        End If
    End Sub

    Private Sub eHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBtelepon.KeyPress

        onlyNumber(e)
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs)
        setIsi()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As DialogResult = OpenFileDialog1.ShowDialog
        If ds = DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName

        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
    End Sub
End Class