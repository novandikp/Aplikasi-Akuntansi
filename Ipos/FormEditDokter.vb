Public Class FormEditDokter
    Public idpelanggan As String = "0"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub

    Sub setIsi()
        Dim query As String =
                "SELECT iddokter, dokter, alamatdokter, nodokter, sid, rs FROM tbldokter WHERE iddokter=" & idpelanggan

        TBpelanggan.Text = getValue(query, "dokter")
        TBalamat.Text = getValue(query, "alamatdokter")
        TBtelepon.Text = getValue(query, "nodokter")
        TextBox1.Text = getValue(query, "sid")
        TextBox2.Text = getValue(query, "rs")
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
        Me.Close()
    End Sub

    Sub simpanBarang()
        TextBox1.Text = "-"
        TextBox2.Text = "-"
        If adaKosong(GroupBox1) Then
            dialogError("Terdapat form yang masih kosong")
        Else
            Dim namaPelanggan As String = TBpelanggan.Text
            Dim alamatPelanggan As String = TBalamat.Text
            Dim noPelanggan As String = TBtelepon.Text
            Dim level As String = TextBox1.Text
            Dim status As String = TextBox2.Text


            Dim isi() As String = {namaPelanggan, alamatPelanggan, noPelanggan}
            If _
                operationQuery(
                    "update tbldokter set dokter= ?, alamatdokter = ?, nodokter = ? where iddokter=" & idpelanggan, isi) _
                Then
                dialogInfo("Berhasil disimpan")

                ' Form1.openListPelanggan()
                DatagridDokter.getDataPelanggan()
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
            setIsi()
        End If
    End Sub

    Private Sub eHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBtelepon.KeyPress

        onlyNumber(e)
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        setIsi()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        closeTab()
    End Sub
End Class