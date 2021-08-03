Public Class SplashScreen

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            Me.Hide()
            Form1.Show()

        Else
            ProgressBar1.Value += 2

        End If
    End Sub


    Sub setFull()
        Dim lisence = seperatorString(hashString(getRegProduk), "-", 4)
        Dim data As String() = lisence.Split("-")
        setLicense(data)
    End Sub

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'getRegProduk()
        'If fullver Then
        'setFull()
        'exc("UPDATE tblidentitas set namatoko='" & Modul.toko & "' where idtoko=1")
        'End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class