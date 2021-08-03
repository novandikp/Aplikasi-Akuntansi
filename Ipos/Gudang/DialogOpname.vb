Public Class DialogOpname
    Public iddetailjual As String = "0"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub

    Dim konversi As String

    Sub setIsi()
        Dim query As String =
                "SELECT idproduk, konversi, produk,  CASE WHEN tipedata = 1 THEN  view_harga.stok1 WHEN tipedata = 2 THEN view_harga.stok2 ELSE  view_harga.stok3 end as stok1, hargajual, hargabeli, satuan from view_harga where barcode=" &
                iddetailjual

        TBtelepon.Text = getValue(query, "produk")
        TextBox1.Text = getValue(query, "stok1")
        satuan1.Text = getValue(query, "satuan")
        satuan2.Text = getValue(query, "satuan")
        konversi = getValue(query, "konversi")
    End Sub


    Sub awal()


        clearForm(GroupBox1)

        setIsi()
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
        ElseIf Not Double.TryParse(TextBox2.Text, 0) Then
            dialogError("Jumlah salah")
        Else
            If Double.Parse(TextBox2.Text) < 0 Then
                dialogError("isi minimal 0")
                Return
            End If
            Dim jual = TextBox1.Text
            Dim jumlahretur = (Double.Parse(TextBox2.Text) - Double.Parse(jual)).ToString
            Dim sql As String =
                    "SELECT idproduk, tipedata, konversi, produk, stok1, stok2, stok3, konversi, hargajual, hargabeli, satuan from view_harga where barcode=" &
                    iddetailjual
            Dim idproduk = getValue(sql, "idproduk")

            Dim nilai = Double.Parse(konversi)*Double.Parse(jumlahretur)
            Dim sqlretur =
                    "INSERT INTO tblstokopname (tglstok, idproduk, tambahan, nilaidasar, awal, satuanstok,keterangan) VALUES (?,?,?,?,?,?,?)"
            If _
                operationQuery(sqlretur,
                               New String() _
                                  {Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), idproduk,
                                   jumlahretur.ToString.Replace(",", "."), nilai.ToString.Replace(",", "."),
                                   TextBox1.Text, satuan1.Text, TextBox3.Text}) Then


                Dim datastok As String() = New String() _
                        {idproduk, jumlahretur.ToString.Replace(",", "."), satuan1.Text,
                         nilai.ToString.Replace(",", "."), Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"),
                         "OPNAME"}
                Dim querystok =
                        "INSERT INTO tblstok (idproduk, tambahan, satuanstok, nilaidasar, tglstok, keterangan) values (?,?,?,?,?,?)"
                operationQuery(querystok, datastok)
                Dim tipe = getValue(sql, "tipedata")
                If tipe = "1" Then
                    exc(
                        "update tblproduk set stok1 = '" & Double.Parse(TextBox2.Text).ToString & "' where idproduk='" &
                        idproduk & "'")
                ElseIf tipe = "2" Then
                    exc(
                        "update tblproduk set stok2 = '" & Double.Parse(TextBox2.Text).ToString & "' where idproduk='" &
                        idproduk & "'")
                Else
                    exc(
                        "update tblproduk set stok3 = '" & Double.Parse(TextBox2.Text).ToString & "' where idproduk='" &
                        idproduk & "'")
                End If

                closeTab()
                Form1.refreshProduk()
                DataRefOpname.getDataProduk()
            End If


        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBtelepon.KeyDown, TextBox1.KeyDown, TextBox2.KeyDown, btnSimpan.KeyDown, btnTutup.KeyDown,
                GroupBox1.KeyDown, Me.KeyDown, TextBox3.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        ElseIf e.KeyCode = Keys.F11 Then
            simpanBarang()
        ElseIf e.KeyCode = Keys.F12 Then

        End If
    End Sub

    Private Sub eHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBtelepon.KeyPress

        onlyNumber(e)
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs)
        setIsi()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        onlyNumberWithComma(e)
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        closeTab()
    End Sub

    Private Sub satuan1_Click(sender As Object, e As EventArgs) Handles satuan1.Click
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
    End Sub
End Class