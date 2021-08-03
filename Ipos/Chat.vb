Public Class Chat
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("https://api.whatsapp.com/send?phone=6281357911226")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start("https://api.whatsapp.com/send?phone=6281336779335")
    End Sub
End Class