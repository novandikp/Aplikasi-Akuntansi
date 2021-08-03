Public Class FormUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub


    Sub awal()

        clearForm(GroupBox1)
        TBpelanggan.Focus()
        ComboBox1.DataSource = getData("select role from ""group""")
        ComboBox1.ValueMember = "role"
        ComboBox1.DisplayMember = "role"

        ComboBox2.DataSource = getData("select idcabang, cabang from ""tblcabang""")
        ComboBox2.ValueMember = "idcabang"
        ComboBox2.DisplayMember = "cabang"
    End Sub

    Private Sub AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub


    Function cekUsername()
        Dim sql As String = "SELECT username FROM tbluser where username='" & TBpelanggan.Text & "'"
        If getCount(sql) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub simpanBarang()
        If Not limit("tbluser") Then
            Return
        End If
        If Not cekUsername() Then
            dialogError("Username sudah dipakai")
        ElseIf adaKosong(GroupBox1) Then
            dialogError("Terdapat form yang masih kosong")
        Else
            Dim namaPelanggan As String = TBpelanggan.Text
            Dim alamatPelanggan As String = ComboBox1.Text
            Dim noPelanggan As String = hashStringWithoutCut(TBtelepon.Text)


            Dim isi() As String = {namaPelanggan, noPelanggan, alamatPelanggan, ComboBox2.SelectedValue.ToString}
            If operationQuery("insert into tbluser (username, password, role, idcabang ) values ( ?, ?, ?, ?);", isi) _
                Then
                dialogInfo("Berhasil disimpan")


                DatagridUser.getDataUser()
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
        Handles TBtelepon.KeyDown, TBpelanggan.KeyDown, MyBase.KeyDown, ComboBox1.KeyDown, btnTutup.KeyDown,
                btnSimpan.KeyDown, btnBatal.KeyDown
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