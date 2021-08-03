Public Class FormPelanggan
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanBarang()
    End Sub

    Sub getLevel()
        CBlevel.DataSource = getData("SELECT level, idlevel FROM tbllevel")
        CBlevel.DisplayMember = "level"
        CBlevel.ValueMember = "idlevel"
    End Sub

    Sub awal()
        getLevel()
        clearForm(GroupBox1)
        TBpelanggan.Focus()
    End Sub

    Private Sub AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Sub simpanBarang()

        If Not limit("tblpelanggan") Then
            Return
        End If
        If adaKosong(GroupBox1) Then
            dialogError("Terdapat form yang masih kosong")
        ElseIf getCount("select pelanggan from tblpelanggan where pelanggan='" + TBpelanggan.Text + "'") > 0 Then
            dialogError("Nama Pelanggan sudah digunakan")
        Else
            Dim namaPelanggan As String = TBpelanggan.Text
            Dim alamatPelanggan As String = TBalamat.Text
            Dim noPelanggan As String = TBtelepon.Text
            Dim level As String = CBlevel.SelectedValue.ToString


            Dim isi() As String = {namaPelanggan, alamatPelanggan, noPelanggan, level}
            If _
                operationQuery(
                    "insert into tblpelanggan (pelanggan, alamatpelanggan, nopelanggan, idlevel, statuspelanggan) values ( ?, ?, ?, ?, 1);",
                    isi) Then
                dialogInfo("Berhasil disimpan")

                ' Form1.openListPelanggan()
                DatagridPelanggan.getDataPelanggan()
                closeTab()
            End If


        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TBpelanggan.KeyDown, TBtelepon.KeyDown, TBalamat.KeyDown, btnSimpan.KeyDown, btnBatal.KeyDown,
                btnTutup.KeyDown, GroupBox1.KeyDown, Me.KeyDown, CBlevel.KeyDown
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

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        closeTab()
    End Sub
End Class