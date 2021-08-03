Imports System.IO

Public Class ImportItem
    Public tipe As Integer = 0
    Private Sub ImportSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tipe = 0 Then
            Label1.Text = "Import Produk"
            Me.Text = "Import Produk"
        Else
            Me.Text = "Import Jasa"
            Label1.Text = "Import Jasa"
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
        If Not File.Exists(TBAfter.Text) Or String.IsNullOrWhiteSpace(TBAfter.Text) Then
            dialogError("Pilih file lokasi terlebih dahulu")
        Else
            If Not limit("tblproduk") Then


                Return
            End If
            Dim dt As DataTable = importExcelFromURL(TBAfter.Text, "Data Produk")
            If tipe = 0 Then
                import_excel(dt)
            Else
                import_jasa(dt)
            End If
        End If
    End Sub

    Private Function cekRow(row As DataRow, Optional tipe As Integer = 0) As Boolean
        Dim filled = True

        For i As Integer = 0 To 7
            If IsNothing(row.Item(i)) Then
                filled = False
                Exit For

            Else
                If String.IsNullOrEmpty(row.Item(i).ToString) Then
                    filled = False
                    Exit For
                End If
            End If


        Next

        If String.IsNullOrWhiteSpace(row.Item(12).ToString) Then
            filled = False

        End If

        If String.IsNullOrWhiteSpace(row.Item(15).ToString) Then
            filled = False

        End If


        Return filled
    End Function

    Private Function cekRow2(row As DataRow, Optional tipe As Integer = 0) As Boolean
        Dim filled = True
        For i As Integer = 0 To 4
            If IsNothing(row.Item(i)) Then
                filled = False
                Exit For

            Else
                If String.IsNullOrEmpty(row.Item(i).ToString) Then
                    filled = False
                    Exit For
                End If
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
        Dim per As Integer = Math.Floor(100 / data.Rows.Count)
        For Each row As DataRow In data.Rows

            If cekRow(row) Then
                If getCount("select * from tblproduk where produk='" + row.Item(1).ToString + "'") > 0 Then
                    Dim baris = data.Rows.IndexOf(row) + 1
                    dialogError("Pada baris " & baris & " ," & row.Item(0).ToString & " sudah ada di database")
                    Continue For
                End If
                Dim idkategori As String = ""
                Dim sqlkategori As String = "SELECT idkategori FROM tblkategori where  kategori  ='" &
                                            row.Item(2).ToString & "'"

                Dim dt As DataTable = getData(sqlkategori)
                If dt.Rows.Count = 0 Then
                    If _
                        exc(
                            "insert into tblkategori ( kategori ,ketkategori) values ( '" & row.Item(2).ToString &
                            "' , '" & row.Item(2).ToString & "');") Then
                        idkategori = getValue(sqlkategori, "idkategori")

                    End If
                Else
                    idkategori = dt.Rows(0).Item("idkategori").ToString
                End If

                Dim idmerk As String = ""
                Dim sqlmerk As String = "SELECT idmerk FROM tblmerk where  merk  ='" & row.Item(3).ToString & "'"

                dt = getData(sqlmerk)
                If dt.Rows.Count = 0 Then
                    If _
                        exc(
                            "insert into tblmerk ( merk ,ketmerk) values ( '" & row.Item(3).ToString & "' , '" &
                            row.Item(3).ToString & "');") Then
                        idmerk = getValue(sqlmerk, "idmerk")

                    End If
                Else
                    idmerk = dt.Rows(0).Item("idmerk").ToString
                End If

                Dim idsatuan1 As String = ""
                Dim sqlsatuan As String = "SELECT idsatuan FROM tblsatuan where  satuan  ='" & row.Item(7).ToString &
                                          "'"

                dt = getData(sqlsatuan)
                If dt.Rows.Count = 0 Then
                    If _
                        exc(
                            "insert into tblsatuan ( satuan ,ketsatuan) values ( '" & row.Item(7).ToString & "' , '" &
                            row.Item(7).ToString & "');") Then
                        idsatuan1 = getValue(sqlsatuan, "idsatuan")

                    End If
                Else
                    idsatuan1 = dt.Rows(0).Item("idsatuan").ToString
                End If

                Dim idsatuan2 As String = ""
                Dim konversi1 As String = "1"
                If _
                    Not String.IsNullOrWhiteSpace(row.Item(8).ToString) And
                    Not String.IsNullOrWhiteSpace(row.Item(10).ToString) Then
                    If Not row.Item(7) = row.Item(8) Then
                        sqlsatuan = "SELECT idsatuan FROM tblsatuan where  satuan  ='" & row.Item(8).ToString & "'"

                        dt = getData(sqlsatuan)
                        If dt.Rows.Count = 0 Then
                            If _
                                exc(
                                    "insert into tblsatuan ( satuan ,ketsatuan) values ( '" & row.Item(8).ToString &
                                    "' , '" & row.Item(8).ToString & "');") Then
                                idsatuan2 = getValue(sqlsatuan, "idsatuan")

                            End If
                        Else
                            idsatuan2 = dt.Rows(0).Item("idsatuan").ToString
                        End If
                        konversi1 = row.Item(10).ToString
                    End If
                End If


                Dim idsatuan3 As String = ""
                Dim konversi2 As String = "1"
                If _
                    Not String.IsNullOrWhiteSpace(row.Item(9).ToString) And
                    Not String.IsNullOrWhiteSpace(row.Item(11).ToString) Then
                    If Not row.Item(8) = row.Item(9) And Not row.Item(7) = row.Item(9) Then
                        sqlsatuan = "SELECT idsatuan FROM tblsatuan where  satuan  ='" & row.Item(9).ToString & "'"

                        dt = getData(sqlsatuan)
                        If dt.Rows.Count = 0 Then
                            If _
                                exc(
                                    "insert into tblsatuan ( satuan ,ketsatuan) values ( '" & row.Item(9).ToString &
                                    "' , '" & row.Item(9).ToString & "');") Then
                                idsatuan3 = getValue(sqlsatuan, "idsatuan")

                            End If
                        Else
                            idsatuan3 = dt.Rows(0).Item("idsatuan").ToString
                        End If
                        konversi2 = row.Item(11).ToString
                    End If

                End If
                Dim flex As String = "0"
                If row.Item(6) = "Iya" Then
                    flex = "1"
                End If
                Dim sql As String =
                        "INSERT INTO tblproduk (idproduk,produk, idkategori, idmerk, ppnproduk, rak, gambar,statusbarang, konversi1, konversi2, flex, stokmin, cabang) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)"
                If _
                    operationQuery(sql,
                                   {row.Item(0), row.Item(1), idkategori, idmerk, "0", row.Item(5), "-", "1", konversi1,
                                    konversi2, flex, row.Item(4), Form1.idcabang}) Then
                    Dim kodebarang = row.Item(0)


                    Dim sql1 As String =
                            "INSERT INTO tblharga (idproduk, hargajual, hargabeli, idsatuan, tipedata, konversi) VALUES (?,?,?,?,?,?)"
                    If operationQuery(sql1, {kodebarang, row.Item(15), row.Item(12), idsatuan1, "1", "1"}) Then

                    End If
                    If Not String.IsNullOrWhiteSpace(idsatuan2) Then

                        If operationQuery(sql1, {kodebarang, row.Item(16), row.Item(13), idsatuan2, "2", konversi1}) _
                            Then

                        End If
                    End If
                    If Not String.IsNullOrWhiteSpace(idsatuan3) And Not String.IsNullOrWhiteSpace(idsatuan2) Then
                        If operationQuery(sql1, {kodebarang, row.Item(17), row.Item(14), idsatuan3, "3", konversi2}) _
                            Then

                        End If
                    End If
                    'simpanDataSatuan()

                    'closeTab()

                    'Form1.openListProduk()
                End If

            Else
                Dim baris = data.Rows.IndexOf(row) + 1
                dialogError("Terdapat kolom yang kosong di baris " & baris)
            End If
            ProgressBar1.Value += per
        Next
        ProgressBar1.Value = 100
        dialogInfo("Berhasil diimport")
        Form1.refreshProduk()
        ProgressBar1.Value = 0
        TBAfter.Text = ""

        For Each CTL In Me.Controls
            CTL.Enabled = True
        Next
        load = True
    End Sub

    Private Sub import_jasa(data As DataTable)
        If IsNothing(data) Then
            dialogError("File tidak sesuai format")
            Return
        End If
        Dim CTL As Control
        For Each CTL In Me.Controls
            CTL.Enabled = False
        Next
        load = False
        Dim per As Integer = Math.Floor(100 / data.Rows.Count)
        For Each row As DataRow In data.Rows

            If cekRow2(row) Then
                If getCount("select * from tblproduk where produk='" + row.Item(1).ToString + "'") > 0 Then
                    Dim baris = data.Rows.IndexOf(row) + 1
                    dialogError("Pada baris " & baris & " ," & row.Item(0).ToString & " sudah ada di database")
                    Continue For
                End If
                Dim idkategori As String = "1"

                Dim idmerk As String = "1"


                Dim idsatuan1 As String = "1"


                Dim flex As String = "0"
                If row.Item(4) = "Iya" Then
                    flex = "1"
                End If
                Dim sql As String =
                        "INSERT INTO tblproduk (idproduk,produk, idkategori, idmerk, ppnproduk, rak, gambar,statusbarang, konversi1, konversi2, flex, stokmin, cabang) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)"
                If _
                    operationQuery(sql,
                                   {row.Item(0), row.Item(1), idkategori, idmerk, "0", "-", "-", "1", "1",
                                    "1", flex, "0", Form1.idcabang}) Then
                    Dim kodebarang = row.Item(0)


                    Dim sql1 As String =
                            "INSERT INTO tblharga (idproduk, hargajual, hargabeli, idsatuan, tipedata, konversi) VALUES (?,?,?,?,?,?)"
                    If operationQuery(sql1, {kodebarang, row.Item(2), row.Item(3), idsatuan1, "1", "1"}) Then

                    End If

                    'simpanDataSatuan()

                    'closeTab()

                    'Form1.openListProduk()
                End If

            Else
                Dim baris = data.Rows.IndexOf(row) + 1
                dialogError("Terdapat kolom yang kosong di baris " & baris)
            End If
            ProgressBar1.Value += per
        Next
        ProgressBar1.Value = 100
        dialogInfo("Berhasil diimport")
        Form1.refreshProduk()
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
            savefile.FileName = "Template Produk." & excel
        Else
            savefile.FileName = "Template Jasa." & excel
        End If
        Dim ds As DialogResult = savefile.ShowDialog

        If ds = DialogResult.OK Then
            If tipe = 0 Then
                copyFile(Application.StartupPath & "/template/Template Produk." & excel, savefile.FileName)
            Else
                copyFile(Application.StartupPath & "/template/Template Jasa." & excel, savefile.FileName)
            End If

            Try
                Process.Start("explorer.exe", "/select," & savefile.FileName)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class