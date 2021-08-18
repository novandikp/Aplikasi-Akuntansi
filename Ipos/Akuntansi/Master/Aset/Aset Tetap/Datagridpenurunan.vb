Public Class Datagridpenurunan
    Public idaset As String = ""
    Public dataAset As DataRow
    Private Sub Datagridpenurunan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillData()
        addhandlertoAllComponent()
    End Sub

    Sub addhandlertoAllComponent()
        For Each komponen As Control In Me.Controls
            AddHandler komponen.KeyDown, AddressOf eventKeydown
            If komponen.Controls.Count > 0 Then
                For Each komponen2 As Control In komponen.Controls
                    AddHandler komponen2.KeyDown, AddressOf eventKeydown
                    If komponen2.Controls.Count > 0 Then
                        For Each komponen3 As Control In komponen2.Controls
                            AddHandler komponen3.KeyDown, AddressOf eventKeydown
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub eventKeydown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()

        End If
    End Sub


    Sub fillData()
        Dim sql As String = "select kodeaset, tblaset.idkategoriaset, aset, tanggaldapat, nilaibeli, nilairesidu, kategoriaset, metodepenyusutan, penggunaan from tblaset
        inner join tblkategoriaset on tblaset.idkategoriaset = tblkategoriaset.idkategoriaset where kodeaset = '" & idaset & "'"
        Dim table As DataTable = getData(sql)
        If Not IsNothing(table) AndAlso table.Rows.Count > 0 Then
            dataAset = table.Rows(0)
            initData()
        Else
            dialogError("Terjadi kesalahan dikarenakan data tidak ditemukan")
        End If
        styliseDG(ListSat)
    End Sub


    Sub initData()
        tabelPenurunan()
    End Sub



    Function getPenurunan(jumlahBulan As Double, nilaiBuku As Double) As Double
        Dim metode As String = dataAset.Item("metodepenyusutan")
        If metode = "GARIS LURUS" Then
            Return (toDouble(dataAset.Item("nilaibeli")) - toDouble(dataAset.Item("nilairesidu"))) / Math.Round(toDouble(dataAset.Item("penggunaan")))
        ElseIf metode = "SALDO MENURUN" Then
            Dim penggunaan As Double = (1 / Math.Round(toDouble(dataAset.Item("penggunaan")))) * 2
            Dim tahun As Double = 12 / jumlahBulan

            Return Math.Round(penggunaan * tahun * nilaiBuku)
        Else
            Return 0
        End If
    End Function

    Sub tabelPenurunan()
        Dim tglPerolehan As Date = Date.Parse(dataAset.Item("tanggaldapat"))
        If tglPerolehan.Day > 15 Then
            tglPerolehan = tglPerolehan.AddDays(16)

        End If
        Dim tglSampai As Date = tglPerolehan.AddMonths(Math.Round(toDouble(dataAset.Item("penggunaan")) * 12))
        tglSampai = tglSampai.AddMonths(-1)
        Dim sqlDetail As String = "SELECT (max(date_trunc('day', dd):: date )), count(date_trunc('day', dd):: date) as jumlahBulan,  date_part('year',dd) as year,0.0,0.0,0.0 as nilaibuku from
        generate_series( '" & tglPerolehan.ToString("yyyy-MM-dd") & "'::timestamp 
        , '" & tglSampai.ToString("yyyy-MM-dd") & "'::timestamp
        , '1 month'::interval) dd group by year order by year;"

        Dim tableDetail As DataTable = getData(sqlDetail)
        Dim nilaiBuku As Double = dataAset.Item("nilaibeli")
        Dim nilaiBuku2 As Double = dataAset.Item("nilaibeli")
        For Each row As DataRow In tableDetail.Rows
            Dim deprisasi As Double = getPenurunan(toDouble(row.Item("jumlahBulan")), nilaiBuku)
            Dim deprisasiBulan As Double = deprisasi / 12
            nilaiBuku = nilaiBuku - deprisasi
            Dim metode As String = dataAset.Item("metodepenyusutan")
            If metode = "SALDO MENURUN" Then
                nilaiBuku2 = nilaiBuku2 - nilaiBuku
                row.Item(3) = Math.Round(nilaiBuku / 12)
                row.Item(4) = Math.Round(nilaiBuku)
                row.Item(5) = Math.Round(nilaiBuku2)
            Else
                row.Item(3) = Math.Round(deprisasiBulan)
                row.Item(4) = Math.Round(deprisasi)
                row.Item(5) = Math.Round(nilaiBuku)
            End If
            Dim tglMax As Date = Date.Parse(row.Item(0))
            Dim temp As New Date(tglMax.Year, tglMax.Month, 1)
            temp = temp.AddMonths(1).AddDays(-1)
            row.Item(0) = temp.ToString("yyyy-MM-dd")


        Next
        Dim dataView As DataView = tableDetail.AsDataView
        dataView.RowFilter = "nilaibuku >= 0"
        ListSat.DataSource = dataView


        Try
            ListSat.Columns(0).HeaderText = "Tanggal"
            ListSat.Columns(1).HeaderText = "Jumlah Bulan"
            ListSat.Columns(2).HeaderText = "Tahun"
            ListSat.Columns(3).HeaderText = "Penurunan per Tahun"
            ListSat.Columns(4).HeaderText = "Penurunan per Bulan"
            ListSat.Columns(5).HeaderText = "Nilai Aset"
            ListSat.Columns(3).DefaultCellStyle.Format = "n0"
            ListSat.Columns(4).DefaultCellStyle.Format = "n0"
            ListSat.Columns(5).DefaultCellStyle.Format = "n0"
        Catch ex As Exception

        End Try
    End Sub
End Class