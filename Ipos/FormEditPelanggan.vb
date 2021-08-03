Public Class FormEditPelanggan
    Public idpelanggan As String = "0"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub

    Sub setIsi()
        Dim query As String =
                "SELECT idpelanggan, pelanggan, alamatpelanggan, nopelanggan, idlevel, hutang, statuspelanggan FROM tblpelanggan WHERE idpelanggan=" &
                idpelanggan

        TBpelanggan.Text = getValue(query, "pelanggan")
        TBalamat.Text = getValue(query, "alamatpelanggan")
        TBtelepon.Text = getValue(query, "nopelanggan")
        CBlevel.SelectedValue = getValue(query, "idlevel")
        ComboBox1.SelectedIndex = getValue(query, "statuspelanggan")
    End Sub

    Sub getLevel()
        CBlevel.DataSource = getData("SELECT idlevel,level FROM tbllevel")
        CBlevel.DisplayMember = "level"
        CBlevel.ValueMember = "idlevel"
    End Sub

    Sub awal()
        getLevel()

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
            Dim namaPelanggan As String = TBpelanggan.Text
            Dim alamatPelanggan As String = TBalamat.Text
            Dim noPelanggan As String = TBtelepon.Text
            Dim level As String = CBlevel.SelectedValue.ToString
            Dim status As String = ComboBox1.SelectedIndex.ToString


            Dim isi() As String = {namaPelanggan, alamatPelanggan, noPelanggan, level, status}
            If _
                operationQuery(
                    "update tblpelanggan set pelanggan= ?, alamatpelanggan = ?, nopelanggan = ?, idlevel = ?, statuspelanggan = ? where idpelanggan=" &
                    idpelanggan, isi) Then
                dialogInfo("Berhasil disimpan")

                ' Form1.openListPelanggan()
                DatagridPelanggan.getDataPelanggan()
                closeTab()
            End If


        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBpelanggan.KeyDown, TBtelepon.KeyDown, TBalamat.KeyDown, btnSimpan.KeyDown, btnBatal.KeyDown,
                btnTutup.KeyDown, GroupBox1.KeyDown, Me.KeyDown, CBlevel.KeyDown, ComboBox1.KeyDown
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