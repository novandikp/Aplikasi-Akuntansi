Public Class FormUbahCabang
    Public idcabang As String = ""

    Sub setCabang()
        Dim tableCabang As DataTable = getData("SELECT cabang, ketcabang FROM tblcabang WHERE idcabang = " & idcabang)
        If tableCabang.Rows.Count > 0 Then
            TBpelanggan.Text = firstTable(tableCabang, "cabang")
            TBtelepon.Text = firstTable(tableCabang, "ketcabang")
        End If
        tableCabang.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub


    Sub awal()

        clearForm(GroupBox1)
        TBpelanggan.Focus()
        setCabang()
    End Sub

    Private Sub AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub


    Function cekUsername()
        Dim sql As String = "SELECT cabang FROM tblcabang where cabang='" & TBpelanggan.Text & "' and idcabang !=" &
                            idcabang
        If getCount(sql) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub simpanBarang()
        If Not limit("tblsupplier") Then
            Return
        End If
        If Not cekUsername() Then
            dialogError("Nama Cabang sudah dipakai")
        ElseIf adaKosong(GroupBox1) Then
            dialogError("Terdapat form yang masih kosong")
        Else
            Dim namaPelanggan As String = TBpelanggan.Text
            Dim alamatPelanggan As String = ""
            Dim noPelanggan As String = TBtelepon.Text


            Dim isi() As String = {namaPelanggan, noPelanggan, idcabang}
            If operationQuery("update tblcabang set cabang = ?, ketcabang = ? WHERE idcabang = ?;", isi) Then
                dialogInfo("Berhasil disimpan")


                Datagridcabang.getDataUser()
                closeTab()
            End If


        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles GroupBox1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        ElseIf e.KeyCode = Keys.F11 Then
            simpanBarang()
        ElseIf e.KeyCode = Keys.F12 Then
            clearForm(GroupBox1)
        End If
    End Sub


    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        clearForm(GroupBox1)
    End Sub

    Private Sub btnTutup_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBtelepon.KeyDown, TBpelanggan.KeyDown, MyBase.KeyDown, btnTutup.KeyDown, btnSimpan.KeyDown,
                btnBatal.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        ElseIf e.KeyCode = Keys.F11 Then
            simpanBarang()
        ElseIf e.KeyCode = Keys.F12 Then
            clearForm(GroupBox1)
        End If
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        closeTab()
    End Sub
End Class