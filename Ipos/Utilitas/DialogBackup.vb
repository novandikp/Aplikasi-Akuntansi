Public Class DialogBackup
    Sub browseFile()
        Dim save As SaveFileDialog = New SaveFileDialog
        save.Filter = "File Database|*." & "sql"
        save.FileName = "BackupData_" & Date.Now.ToString("yyyyMMdd_HHmmss")
        save.DefaultExt = "sql"

        Dim dialog As DialogResult = save.ShowDialog

        If dialog = DialogResult.OK Then
            TBAfter.Text = save.FileName
        End If
    End Sub

    Sub backup()

        Dim psi As New ProcessStartInfo(Application.StartupPath & "\Backup.exe")
        psi.RedirectStandardError = True
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = False

        psi.UseShellExecute = False

        Dim process As Process = Process.Start(psi)
    End Sub

    Sub proses()
        If String.IsNullOrWhiteSpace(TBAfter.Text) Then
            dialogError("Pilih folder terlebih dahulu")
        Else
            Button2.Enabled = False
            For value As Integer = 0 To 100
                ProgressBar1.Value = value
                Threading.Thread.Sleep(300)
            Next
            Dim sb
            Dim filenama As String() = TBAfter.Text.Split("/")
            For Each text As String In filenama
                Console.Write(text)
            Next

            Dim folder As String = "AplikasiBengkel"

            regEdit(folder, "BAKFOLDER", """" & (TBAfter.Text) & """")
            backup()
            dialogInfo("Backup Berhasil")
            Button2.Enabled = True
            ProgressBar1.Value = 0
            Form1.refreshProduk()
        End If

    End Sub


    Function getURLPath(url As String) As String
        Dim sb As New System.Text.StringBuilder
        Dim filename As String() = url.Split("/")
        Dim first As Boolean = True
        For Each text As String In filename
            If first Then
                sb.Append(text)
                first = False
            Else
                sb.Append("""" & text & """")
            End If
        Next
        Return sb.ToString()
    End Function

    Sub awal()
        TBBefore.Text = getLocationDatabase()
        TBAfter.Text = ""
    End Sub

    Private Sub DialogBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TBBefore.Text = getLocationDatabase()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        proses()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        browseFile()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click

    End Sub

    Private Sub Button2_KeyDown(sender As Object, e As KeyEventArgs) Handles TBBefore.KeyDown, TBAfter.KeyDown, Button8.KeyDown, Button2.KeyDown, Button1.KeyDown, Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            proses()
        ElseIf e.KeyCode = Keys.F2 Then
            browseFile()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub

    Private Sub TBAfter_TextChanged(sender As Object, e As EventArgs) Handles TBAfter.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
End Class