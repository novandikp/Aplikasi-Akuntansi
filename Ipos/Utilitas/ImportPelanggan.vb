Imports System.IO

Public Class ImportPelanggan
    Private Sub ImportSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Sub browseFile()
        Dim save As OpenFileDialog = New OpenFileDialog
        Dim excel As String = "xlsx"

        If True Then
            excel = "xls"
        End If
        save.Filter = "File Excel|*." & excel


        Dim dialog As DialogResult = save.ShowDialog

        If dialog = DialogResult.OK Then
            TBAfter.Text = save.FileName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        browseFile()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        check()
    End Sub

    Sub check()
        If Not File.Exists(TBAfter.Text) Or String.IsNullOrWhiteSpace(TBAfter.Text) Then
            dialogError("Pilih file lokasi terlebih dahulu")
        Else
            Dim dt As DataTable = importExcelFromURL(TBAfter.Text, "Data Pelanggan")
            import_excel(dt)
        End If
    End Sub

    Private Function cekRow(row As DataRow, Optional tipe As Integer = 0) As Boolean
        Dim filled = True
        For i As Integer = 0 To 3
            If String.IsNullOrWhiteSpace(row.Item(i).ToString) Then
                filled = False
                Exit For
            End If

        Next

        Return filled
    End Function

    Dim load = True

    Private Sub import_excel(data As DataTable)
        If IsNothing(data) Then
            dialogError("File tidak sesuai format")
            Return
        End If

        Dim CTL As Control
        For Each CTL In Me.Controls
            CTL.Enabled = False
        Next
        load = False
        Dim status As Boolean = True
        Dim per As Integer = Math.Floor(100/data.Rows.Count)
        For Each row As DataRow In data.Rows

            If cekRow(row) Then
                If getCount("select * from tblpelanggan where pelanggan='" + row.Item(0).ToString + "'") > 0 Then
                    Dim baris = data.Rows.IndexOf(row) + 1
                    dialogError("Pada baris " & baris & ", " & row.Item(0).ToString & " sudah ada di database")
                    Continue For
                End If
                Dim idlevel As String = ""
                Dim sqllevel As String = "SELECT * FROM tbllevel where `level` ='" & row.Item(3).ToString & "'"

                Dim dt As DataTable = getData(sqllevel)
                If dt.Rows.Count = 0 Then
                    If exc("insert into tbllevel (`level`,diskon) values ( '" & row.Item(3).ToString & "' , 0);") Then
                        idlevel = getValue(sqllevel, "idlevel")

                    End If
                Else
                    idlevel = dt.Rows(0).Item("idlevel").ToString
                End If

                Dim isi() As String = {row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, idlevel}
                If _
                    operationQuery(
                        "insert into tblpelanggan (pelanggan, alamatpelanggan, nopelanggan, idlevel, statuspelanggan) values ( ?, ?, ?, ?, 1);",
                        isi) Then

                End If
            Else
                Dim baris = data.Rows.IndexOf(row) + 1
                dialogError("Terdapat kolom yang kosong di baris " & baris)
            End If
            ProgressBar1.Value += per
        Next
        ProgressBar1.Value = 100
        dialogInfo("Berhasil diimport")
        ProgressBar1.Value = 0
        TBAfter.Text = ""

        For Each CTL In Me.Controls
            CTL.Enabled = True
        Next
        load = True
    End Sub


    Private Sub ImportPelanggan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not load Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim savefile As New SaveFileDialog
        Dim excel As String = "xlsx"

        If True Then
            excel = "xls"
        End If
        savefile.Filter = "File Excel|*." & excel
        savefile.DefaultExt = excel
        savefile.FileName = "Template Pelanggan." & excel
        Dim ds As DialogResult = savefile.ShowDialog

        If ds = DialogResult.OK Then
            copyFile(Application.StartupPath & "/template/Template Pelanggan." & excel, savefile.FileName)
            Try
                Process.Start("explorer.exe", "/select," & savefile.FileName)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class