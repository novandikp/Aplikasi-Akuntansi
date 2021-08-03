Public Class FormEditSupplier
    Public idsupplier As String = "0"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub

    Sub setIsi()
        Dim query As String = "SELECT  supplier, alamatsupplier, nosupplier FROM tblsupplier WHERE idsupplier=" &
                              idsupplier

        TBpelanggan.Text = getValue(query, "supplier")
        TBalamat.Text = getValue(query, "alamatsupplier")
        TBtelepon.Text = getValue(query, "nosupplier")
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
        If adaKosong(GroupBox1) Then
            dialogError("Terdapat form yang masih kosong")
        Else
            Dim namasupplier As String = TBpelanggan.Text
            Dim alamatsupplier As String = TBalamat.Text
            Dim nosupplier As String = TBtelepon.Text


            Dim isi() As String = {namasupplier, alamatsupplier, nosupplier}
            If _
                operationQuery(
                    "update tblsupplier set supplier= ?, alamatsupplier = ?, nosupplier = ? where idsupplier=" &
                    idsupplier, isi) Then
                dialogInfo("Berhasil disimpan")

                DatagridSupplier.getDataPelanggan()
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