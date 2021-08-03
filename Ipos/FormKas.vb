Public Class FormKas
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub


    Sub awal()

        clearForm(GroupBox1)
        TBTelepon.Text = "0"
        TBpelanggan.Focus()
    End Sub

    Private Sub AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub closeTab()
        Dim addItemForms As FormKas = Application.OpenForms("FormKas")
        If Not IsNothing(addItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(addItemForms))
        End If
    End Sub

    Function cekKodeKas()
        Dim sql As String = "SELECT * FROM tblkas where kodekas='" & TBpelanggan.Text & "'"
        If getCount(sql) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub simpanBarang()
        If Not cekKodeKas() Then
            dialogError("Kode Kas telah dipakai")
        ElseIf adaKosong(GroupBox1) Then
            dialogError("Terdapat form yang masih kosong")
        Else
            Dim namaPelanggan As String = TBpelanggan.Text
            Dim alamatPelanggan As String = TBalamat.Text
            Dim noPelanggan As String = TBTelepon.Text

            Dim isi() As String = {namaPelanggan, alamatPelanggan, noPelanggan}
            If operationQuery("insert into tblkas (kodekas, kas, saldo ) values ( ?, ?, ?);", isi) Then
                MsgBox("berhasil")
                Form1.openListKas()
                closeTab()
            End If


        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBpelanggan.KeyDown, TBtelepon.KeyDown, TBalamat.KeyDown, btnSimpan.KeyDown, btnBatal.KeyDown,
                btnTutup.KeyDown, GroupBox1.KeyDown, Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        ElseIf e.KeyCode = Keys.F11 Then
            simpanBarang()
        ElseIf e.KeyCode = Keys.F12 Then
            clearForm(GroupBox1)
        End If
    End Sub

    Private Sub eHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBtelepon.KeyPress

        onlyNumber(e)
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        clearForm(GroupBox1)
    End Sub
End Class