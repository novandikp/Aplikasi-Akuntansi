Imports Npgsql

Public Class KoneksiDatabase
    Dim Conn As NpgsqlConnection
    Dim CMD As NpgsqlCommand
    Dim row As NpgsqlDataReader
    Dim DA As NpgsqlDataAdapter

    Sub koneksi()

        Dim Query32 = "Server=" & TextBox1.Text &
                      ";Port=5432;Database=tokosaya;username=postgres;password=itbrain1milyar"
        Try
            Conn = New NpgsqlConnection(Query32)
            If Conn.State = Conn.State.Closed Then
                Conn.Open()
            End If
            dialogInfo("Koneksi Database Berhasil")
            setLocationDatabase(TextBox1.Text)
            Me.Close()
            Form1.BukaLogin()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            dialogError("Address yang anda masukkan tidak ditemukan")
        End Try
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        koneksi()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If dialog("Apakah anda yakin untuk keluar aplikasi ?") Then
            SplashScreen.Close()
            Form1.Close()
        End If
    End Sub
End Class