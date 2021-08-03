Public Class DialogRetur
    Public iddetailjual As String = "0"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub

    Sub setIsi()
        Dim query As String =
                "SELECT fakturjual, satuanjual, produk, (jumlahjual - returjual) as jumlahjual FROM view_detailjual WHERE iddetailjual=" &
                iddetailjual

        TBpelanggan.Text = getValue(query, "fakturjual")

        TBtelepon.Text = getValue(query, "produk")
        TextBox1.Text = getValue(query, "jumlahjual")
        satuan1.Text = getValue(query, "satuanjual")
        satuan2.Text = getValue(query, "satuanjual")
    End Sub


    Sub awal()


        clearForm(GroupBox1)

        setIsi()
        TBpelanggan.Focus()
    End Sub

    Private Sub AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub closeTab()
        DatagridRetur.getDataPelanggan()
        Me.Close()
    End Sub

    Sub simpanBarang()
        If adaKosong(GroupBox1) Then
            dialogError("Terdapat form yang masih kosong")

        ElseIf Not Double.TryParse(TextBox2.Text, 0) Then
            dialogError("Isi jumlah retur dengan benar")
        Else
            Dim sql =
                    "SELECT (nilaijual/jumlahjual) as konversi, barcode, stok1, stok2, stok3, konversi1, konversi2 FROM view_detailjual WHERE iddetailjual=" &
                    iddetailjual
            Dim jual = TextBox1.Text
            Dim jumlahretur As String = TextBox2.Text
            Dim konversi = getValue(sql, "konversi")

            Dim nilai As Double = Double.Parse(konversi)*Double.Parse(jumlahretur)
            If Double.Parse(jumlahretur) > 0 And Double.Parse(jumlahretur) <= Double.Parse(jual) Then
                exc(
                    "update tbldetailjual set returjual= returjual+'" & jumlahretur.Replace(",", ".") &
                    "' WHERE iddetailjual=" & iddetailjual)
                Dim sqlretur =
                        "INSERT INTO tblreturjual (tglreturjual, iddetailjual, jumlahreturjual, nilaireturjual, satuanreturjual) VALUES (?,?,?,?,?)"
                If _
                    operationQuery(sqlretur,
                                   New String() _
                                      {Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), iddetailjual,
                                       jumlahretur, nilai.ToString, satuan1.Text}) Then
                    Dim stok1 As Double = Double.Parse(getValue(sql, "stok1")),
                        stok2 As Double = Double.Parse(getValue(sql, "stok2")),
                        stok3 As Double = Double.Parse(getValue(sql, "stok3"))
                    Dim konversi1 As Double = Double.Parse(getValue(sql, "konversi1"))
                    Dim konversi2 As Double = konversi1*Double.Parse(getValue(sql, "konversi2"))
                    Dim idproduk = getValue(sql, "barcode")
                    Dim datastok As String() = New String() _
                            {idproduk, jumlahretur.Replace(",", "."), satuan1.Text, nilai.ToString.Replace(",", "."),
                             Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"),
                             "RETUR PENJUALAN " & TBpelanggan.Text, "0"}
                    Dim querystok =
                            "INSERT INTO tblstok (idproduk, tambahan, satuanstok, nilaidasar, tglstok, keterangan,idbeli) values (?,?,?,?,?,?,?)"
                    operationQuery(querystok, datastok)

                    If nilai Mod 1 = 0 Then
                        If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                            stok3 += nilai\konversi2
                            nilai = nilai Mod konversi2
                        End If


                        If konversi1 <= nilai And konversi1 > 1 Then
                            stok2 += nilai\konversi1

                            nilai = nilai Mod konversi1
                        End If
                    Else
                        If konversi2 <= nilai And konversi2 > konversi1 And konversi2 > 1 Then
                            stok3 += Math.Floor(nilai/konversi2)
                            nilai -= Math.Floor(nilai/konversi2)*konversi2
                        End If


                        If konversi1 <= nilai And konversi1 > 1 Then
                            stok2 += Math.Floor(nilai/konversi1)

                            nilai -= Math.Floor(nilai/konversi1)*konversi1
                        End If
                    End If

                    stok1 += nilai

                    Dim databarang As String() = New String() _
                            {stok1.ToString.Replace(",", "."), stok2.ToString.Replace(",", "."),
                             stok3.ToString.Replace(",", "."), idproduk}
                    Dim barangsql = "UPDATE tblproduk set stok1=?, stok2=?, stok3=? where idproduk=?"
                    operationQuery(barangsql, databarang)

                    Form1.refreshProduk()
                    closeTab()

                End If
            Else
                dialogError("Isi jumlah retur dengan benar")
            End If


        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBtelepon.KeyDown, TextBox1.KeyDown, TextBox2.KeyDown, btnSimpan.KeyDown, btnTutup.KeyDown,
                GroupBox1.KeyDown, Me.KeyDown, TBpelanggan.KeyDown
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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
    End Sub
End Class