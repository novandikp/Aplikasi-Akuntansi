Public Class HubungiKami
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Process.Start("https://api.whatsapp.com/send?phone=6281357911226")
    End Sub

    Private Sub HubungiKami_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = "Versi Program : " & versi
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim url As String = "https://mail.google.com/mail/?view=cm&fs=1&to=help.itbrain@gmail.com"
        Process.Start(url)
    End Sub
End Class