Public Class FormEditSatuanBarang
    Public isidata As DataGridViewRow

    Public row As String = ""
    Public idbarang As String = ""

    Private Sub FormDetailSatuanBeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        getSatuan()
        clearForm(GroupBox1)

        If IsNothing(row) Then
            Dim idtemp = (getCount("select * from tblharga where idproduk='" & idbarang & "'") + 1).ToString
            If idtemp = "1" Then
                TBJenis.Text = "Dasar"
                tbKonversi.Text = "1"
                satuanBefore.Visible = False
                tbKonversi.Enabled = False
            ElseIf idtemp = "2" Then
                TBJenis.Text = "Konversi 1"
                tbKonversi.Text = "1"
                satuanBefore.Text =
                    getValue("select * from view_harga where idproduk='" & idbarang & "' order by tipedata desc",
                             "satuan")
                satuanBefore.Visible = True
                tbKonversi.Enabled = True
            Else
                TBJenis.Text = "Konversi 2"
                satuanBefore.Text =
                    getValue("select * from view_harga where idproduk='" & idbarang & "' order by tipedata desc",
                             "satuan")
                tbKonversi.Text = "1"
                tbKonversi.Enabled = True
            End If
        Else
            Dim query As String = "select * from view_harga where barcode=" & row
            Dim jenis = getValue(query, "tipedata")
            If jenis = "1" Then
                TBJenis.Text = "Dasar"
                tbKonversi.Text = "1"
                satuanBefore.Visible = False

                tbKonversi.Enabled = False
            ElseIf jenis = "2" Then
                TBJenis.Text = "Konversi 1"
                tbKonversi.Text = "1"
                satuanBefore.Text =
                    getValue(
                        "select * from view_harga where tipedata=" & (toDouble(row) - 1).ToString & " and  idproduk='" &
                        idbarang & "' order by tipedata desc", "satuan")
                satuanBefore.Visible = True
                tbKonversi.Enabled = True
            Else
                TBJenis.Text = "Konversi 2"
                tbKonversi.Text = "1"
                satuanBefore.Text =
                    getValue(
                        "select * from view_harga where tipedata=" & (toDouble(row) - 1).ToString & " and  idproduk='" &
                        idbarang & "' order by tipedata desc", "satuan")
                satuanBefore.Visible = True
                tbKonversi.Enabled = True
            End If


            cbSatuan.SelectedValue = getValue(query, "idsatuan")
            tbKonversi.Text = getValue(query, "konversi")
            TBBeli.Text = getValue(query, "hargabeli")
            TBJual.Text = getValue(query, "hargajual")

            If _
                Not _
                toDouble(getValue("SELECT (stok1+stok2+stok3) as stok FROM tblproduk where idproduk='" & idbarang & "'",
                                  "stok")) = 0 Then
                tbKonversi.Enabled = False
            End If


        End If
        cbSatuan.Focus()
    End Sub

    Sub simpanSatuan()
        Dim idsatuan = cbSatuan.SelectedValue.ToString
        If adaKosong(GroupBox1) Then
            dialogError("Terdapat form masih kosong")
        ElseIf _
            getCount("SELECT * FROM tblharga WHERE idproduk='" & idbarang & "' and idsatuan=" & idsatuan) > 0 And
            IsNothing(row) Then
            dialogError("Satuan telah dipakai")
        ElseIf _
            getCount("SELECT * FROM tblharga WHERE idproduk='" & idbarang & "' and  idsatuan=" & idsatuan) > 0 And
            Not getValue("select * from tblharga where barcode=" & row, "idsatuan") = idsatuan Then
            dialogError("Satuan telah dipakai")
        Else
            Dim tipe = "1"

            If TBJenis.Text = "Konversi 1" Then
                tipe = "2"
            ElseIf TBJenis.Text = "Konversi 2" Then
                tipe = "3"
            End If

            If IsNothing(row) Then


                Dim namasatuan = cbSatuan.Text
                Dim jenis = TBJenis.Text
                Dim konversi = tbKonversi.Text
                Dim hargabeli = TBBeli.Text.Replace(",", ".").Replace(".", "")
                Dim hargajual = TBJual.Text.Replace(",", ".").Replace(".", "")
                Dim isidata As String() = New String() {idbarang, hargajual, hargabeli, idsatuan, tipe, konversi}
                Dim sql As String =
                        "INSERT INTO tblharga (idproduk,hargajual,hargabeli,idsatuan,tipedata, konversi) VALUES (?,?,?,?,?,?)"
                If Not operationQuery(sql, isidata) Then
                    Return
                Else
                    If TBJenis.Text = "Konversi 1" Then
                        exc("update tblproduk set konversi1 = " & konversi & " where idproduk='" & idbarang & "'")
                    ElseIf TBJenis.Text = "Konversi 2" Then
                        exc("update tblproduk set konversi2 = " & konversi & " where idproduk='" & idbarang & "'")
                    End If
                End If

            Else
                Dim namasatuan = cbSatuan.Text
                Dim jenis = TBJenis.Text
                Dim konversi = tbKonversi.Text
                Dim hargabeli = TBBeli.Text.Replace(",", ".").Replace(".", "")
                Dim hargajual = TBJual.Text.Replace(",", ".").Replace(".", "")
                Dim isidata As String() = New String() {idsatuan, idbarang, tipe, konversi, hargabeli, hargajual}
                Dim sql As String =
                        "UPDATE tblharga set idsatuan= ?, idproduk=?, tipedata= ?, konversi = ?, hargabeli = ?, hargajual= ? where barcode= " &
                        row
                If Not operationQuery(sql, isidata) Then
                    Return
                Else
                    If TBJenis.Text = "Konversi 1" Then
                        exc("update tblproduk set konversi1 = " & konversi & " where idproduk='" & idbarang & "'")
                    ElseIf TBJenis.Text = "Konversi 2" Then
                        exc("update tblproduk set konversi2 = " & konversi & " where idproduk='" & idbarang & "'")
                    End If
                End If
            End If
            Form1.refreshSatuanEditProduk()

            Me.Close()
        End If
    End Sub


    Sub getSatuan()

        cbSatuan.DataSource = getData("select * from tblsatuan where idsatuan > 1")
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
        Handles cbSatuan.KeyDown, tbKonversi.KeyDown, TBBeli.KeyDown, TBJenis.KeyDown, TBJual.KeyDown, btnSimpan.KeyDown,
                btnTutup.KeyDown, Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            simpanSatuan()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()

        End If
    End Sub

    Private Sub TBJual_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles tbKonversi.KeyPress, TBJual.KeyPress, TBBeli.KeyPress
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