Public Class ImportSupplier

    Public tipe As Integer = 0
    Private Sub ImportSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not tipe = 0 Then
            Me.Text = "Import Teknisi"
            Label1.Text = "Import Data Teknisi"
            Label2.Text = "Import data ini digunakan untuk menginputkan data dokter mengguanakan file excel yang telah disediakan"
        End If
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
        If Not System.IO.File.Exists(TBAfter.Text) Or String.IsNullOrWhiteSpace(TBAfter.Text) Then
            dialogError("Pilih file lokasi terlebih dahulu")
        Else
            If tipe = 0 Then
                import_excel(importExcelFromURL(TBAfter.Text, "Data Supplier"))
            Else
                import_dokter(importExcelFromURL(TBAfter.Text, "Data Teknisi"))
            End If

        End If
    End Sub

    Private Function cekRow(row As DataRow, Optional tipe As Integer = 0) As Boolean
        Dim filled = True
        For i As Integer = 0 To row.ItemArray.Length - 1
            If Not IsNothing(row.Item(i)) Then

                If String.IsNullOrWhiteSpace(row.Item(i).ToString) Then
                    filled = False
                    Exit For
                End If
            Else
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
        If data.Rows.Count = 0 Then
            dialogError("Data kosong")
            Return
        End If
        Dim per As Integer = Math.Floor(100 / data.Rows.Count)
        For Each row As DataRow In data.Rows

            If cekRow(row) Then
                If getCount("select * from tblsupplier where supplier='" + row.Item(0).ToString + "'") > 0 Then
                    Dim baris = data.Rows.IndexOf(row) + 1
                    dialogError("Pada baris " & baris & " ," & row.Item(0).ToString & " sudah ada di database")
                    Continue For
                End If
                If operationQuery("insert into tblsupplier (supplier, alamatsupplier, nosupplier, idcabang ) values ( ?, ?, ?, ?);", New String() {row.Item(0), row.Item(1), row.Item(2), Form1.idcabang}) Then

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

    Private Sub import_dokter(data As DataTable)
        If IsNothing(data) Then
            dialogError("File tidak sesuai format")
            Return
        End If
        Dim CTL As Control
        For Each CTL In Me.Controls
            CTL.Enabled = False
        Next
        load = False
        If data.Rows.Count = 0 Then
            dialogError("Data kosong")
            Return
        End If
        Dim per As Integer = Math.Floor(100 / data.Rows.Count)
        For Each row As DataRow In data.Rows

            If cekRow(row) Then
                If getCount("select * from tbldokter where dokter='" + row.Item(0).ToString + "'") > 0 Then
                    Dim baris = data.Rows.IndexOf(row) + 1
                    dialogError("Pada baris " & baris & " ," & row.Item(0).ToString & " sudah ada di database")
                    Continue For
                End If
                If operationQuery("insert into tbldokter (dokter, alamatdokter, nodokter, rs, sid ) values ( ?, ?, ?, ?, ?);", New String() {row.Item(0), row.Item(1), row.Item(2), Form1.idcabang, "0"}) Then

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
        If tipe = 0 Then
            savefile.FileName = "Template Supplier." & excel
        Else
            savefile.FileName = "Template Teknisi." & excel
        End If

        Dim ds As DialogResult = savefile.ShowDialog

        If ds = DialogResult.OK Then
            If tipe = 0 Then
                copyFile(Application.StartupPath & "/template/Template Supplier." & excel, savefile.FileName)
            Else
                copyFile(Application.StartupPath & "/template/Template Teknisi." & excel, savefile.FileName)
            End If
            Try
                Process.Start("explorer.exe", "/select," & savefile.FileName)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class