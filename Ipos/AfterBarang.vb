Public Class AfterBarang
    Dim status = True

    Sub buatProduk()
        status = False

        Me.Close()
    End Sub

    Sub tutupSemua()
        status = False

        Me.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        buatProduk()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tutupSemua()
    End Sub

    Private Sub Button1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Button2.KeyPress, Button1.KeyPress
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button2.KeyDown, Button1.KeyDown
        If e.KeyCode = Keys.F1 Then
            buatProduk()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            tutupSemua()
        End If
    End Sub

    Private Sub AfterBarang_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If status Then
            tutupSemua()
        End If
        status = True
    End Sub

    Private Sub AfterBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class