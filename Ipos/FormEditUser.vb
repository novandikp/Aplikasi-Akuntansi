Public Class FormEditUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub


    Public username As String = ""

    Sub awal()

        clearForm(GroupBox1)
        ComboBox1.DataSource = getData("select role from ""group""")
        ComboBox1.ValueMember = "role"
        ComboBox1.DisplayMember = "role"
        TBpelanggan.Focus()
        TBpelanggan.Text = username

        Dim sql As String = "SELECT username, ""password"", ""role"", idcabang FROM tbluser where username='" &
                            TBpelanggan.Text & "'"
        ComboBox1.SelectedValue = getValue(sql, "role")
        ComboBox2.DataSource = getData("select idcabang, cabang from ""tblcabang""")
        ComboBox2.ValueMember = "idcabang"
        ComboBox2.DisplayMember = "cabang"
        ComboBox2.SelectedValue = getValue(sql, "idcabang")
    End Sub

    Private Sub AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub


    Function cekUsername()
        Dim sql As String = "SELECT username FROM tbluser where username='" & TBpelanggan.Text & "'"
        If TBpelanggan.Text = username Then
            Return True
        ElseIf getCount(sql) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub simpanBarang()
        If Not cekUsername() Then
            dialogError("Username sudah dipakai")
        ElseIf adaKosong(GroupBox1) Then
            dialogError("Terdapat form yang masih kosong")
        Else
            Dim namaPelanggan As String = TBpelanggan.Text
            Dim alamatPelanggan As String = ComboBox1.Text
            Dim noPelanggan As String = hashStringWithoutCut(TBtelepon.Text)


            Dim isi() As String =
                    {namaPelanggan, noPelanggan, alamatPelanggan, ComboBox2.SelectedValue.ToString, username}
            If operationQuery("update  tbluser set username=?, password=?, role=? , idcabang=? where username= ?;", isi) _
                Then
                dialogInfo("Berhasil disimpan")
                DatagridUser.getDataUser()
                closeTab()
            End If


        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBpelanggan.KeyDown, TBtelepon.KeyDown, btnSimpan.KeyDown, btnBatal.KeyDown, btnTutup.KeyDown,
                GroupBox1.KeyDown, Me.KeyDown
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

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub
End Class