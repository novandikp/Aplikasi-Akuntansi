Imports System.ComponentModel

Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        setLocationDatabase(TextBox3.Text)
        If clearKoneksi() Then
            Dim username = TextBox1.Text
            Dim password = hashStringWithoutCut(TextBox2.Text)

            Dim sql As String = "SELECT role,cabang,tblcabang.idcabang FROM tbluser INNER JOIN tblcabang ON tbluser.idcabang = tblcabang.idcabang WHERE username = '" & username & "' and  password = '" & password & "'"
            Debug.WriteLine(sql)
            If getCount(sql) = 1 Then
                Me.Close()

            Else
                dialogError("Username atau password salah")
            End If
        Else
            dialogError("Address yang anda masukkan tidak ditemukan")
        End If

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.Text = getLocationDatabase()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.UseSystemPasswordChar Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = TextBox2
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = Button1
            Button1.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) 

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If dialog("Apakah anda yakin untuk keluar aplikasi ?") Then
            SplashScreen.Close()

        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = TextBox1
            TextBox1.Focus()
        End If
    End Sub
End Class