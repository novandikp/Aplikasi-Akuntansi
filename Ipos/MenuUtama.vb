Public Class MenuUtama
    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, PictureBox1.KeyDown

        If e.KeyCode = Keys.Escape Then
            Form1.keluarAplikasi()
        ElseIf e.KeyCode = Keys.X Then
            Form1.logout()
        End If
    End Sub

    Dim nilai As Integer
    Sub setnama()
        nilai = 0
        If Not pro Then
            Dim tables As DataTable = checkLisence()
            If Not IsNothing(tables) Then
                If seperatorString(hashString(tables.Rows(0).Item("data")), "-", 4) = tables.Rows(0).Item("value") Then
                    pro = True
                End If
            End If
        End If
        If Modul.pro Then
            Button1.Visible = False
            Label1.Visible = False
            Button2.Visible = False
            Me.ActiveControl = PictureBox1

        Else
            Me.ActiveControl = Button1

        End If
    End Sub
    Private Sub MenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setnama()
        getProduk()
        getHutang()
        NamaToko.AutoSize = True
        NamaToko.Visible = True
        NamaToko.Text = getValue("select namatoko from tblidentitas where idtoko = 1", "namatoko")

        Dim p As New Point
        p.X = (Me.Width / 2) - (NamaToko.Width / 2)
        p.Y = NamaToko.Location.Y
        NamaToko.Location = p
        PictureBox1.Visible = False
    End Sub

    Sub getHutang()
        Dim tgl As String = Now.AddDays(1).ToString("yyyy-MM-dd")
        Dim jumlah As String = getCount("select idjual from view_hutang_temp where jatuhtempo ='" & tgl & "' and idcabang=" & Form1.idcabang)
        Debug.Write("select idjual from tblhutangtemporal where jatuhtempo ='" & tgl & "' and idcabang=" & Form1.idcabang)
        If toDouble(jumlah) = 0 Then
            Label4.Visible = False
            Label5.Visible = False

        Else
            Label4.Visible = True
            Label5.Visible = True
            Label4.Text = jumlah
        End If

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Aktivasi.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        HubungiKami.ShowDialog()


    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Form1.keluarAplikasi()
        ElseIf e.KeyCode = Keys.X Then
            Form1.logout()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Chat.ShowDialog()
    End Sub

    Sub setColor()
        If Label1.Visible Then
            If Label1.BackColor = Color.Chartreuse Then
                Label1.BackColor = Color.Yellow
            Else
                Label1.BackColor = Color.Chartreuse
            End If
        End If

        If Label2.Visible Then
            If Label2.BackColor = Color.Chartreuse Then
                Label2.BackColor = Color.Yellow
            Else
                Label2.BackColor = Color.Chartreuse
            End If
        End If

        If Label3.Visible Then
            If Label3.BackColor = Color.Chartreuse Then
                Label3.BackColor = Color.Yellow
            Else
                Label3.BackColor = Color.Chartreuse
            End If
        End If
        If Label4.Visible Then
            If Label4.BackColor = Color.Chartreuse Then
                Label4.BackColor = Color.Yellow
            Else
                Label4.BackColor = Color.Chartreuse
            End If
        End If
        If Label5.Visible Then
            If Label5.BackColor = Color.Chartreuse Then
                Label5.BackColor = Color.Yellow
            Else
                Label5.BackColor = Color.Chartreuse
            End If
        End If
    End Sub

    Sub getProduk()
        Dim jumlah As String = getCount("select produk from tblproduk where (stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2) < stokmin and cabang=" & Form1.idcabang)
        If toDouble(jumlah) = 0 Then
            Label2.Visible = False
            Label3.Visible = False

        Else
            Label2.Visible = True
            Label3.Visible = True
            Label3.Text = jumlah
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        nilai += 1
        If nilai Mod 2 = 0 Then
            Label1.BackColor = Color.Chartreuse
        Else
            Label1.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click, Label2.Click
        Dim form As New LaporanStokMin
        form.awal()
        form.ShowDialog()
    End Sub
End Class