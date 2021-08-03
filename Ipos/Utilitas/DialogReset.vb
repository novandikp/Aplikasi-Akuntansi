Public Class DialogReset
    Private Sub Button2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            proses()

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub

    Sub proses()
        exc("TRUNCATE tblreturjual, tbldetailjual,tbljual RESTART IDENTITY")
        ProgressBar1.Value = 20
        exc("TRUNCATE tblreturbeli, tbldetailbeli,tblbeli RESTART IDENTITY")
        ProgressBar1.Value = 40
        exc("TRUNCATE tblstok, tblstokopname RESTART IDENTITY")
        ProgressBar1.Value = 50
        exc("TRUNCATE tblhutang, tblpiutang, tblharga, tblproduk RESTART IDENTITY")
        ProgressBar1.Value = 70
        exc("DELETE FROM tblpelanggan where  idpelanggan != 1")
        exc("DELETE FROM tblsupplier where  idsupplier != 2")
        Form1.refreshProduk()
        ProgressBar1.Value = 100
        dialogInfo("Berhasil direset")
        ProgressBar1.Value = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        proses()

    End Sub

    Private Sub DialogReset_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        proses()
    End Sub

    Private Sub Button2_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Button8.KeyDown, Button2.KeyDown
        If e.KeyCode = Keys.F1 Then
            proses()

        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
End Class