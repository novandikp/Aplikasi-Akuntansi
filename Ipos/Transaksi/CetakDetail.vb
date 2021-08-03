Public Class CetakDetail

    Public sql As String
    Public a4 As Boolean = False
    Private Sub CetakDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListSat.DataSource = getData(sql)
        Try
            ListSat.Columns(0).Visible = False
            ListSat.Columns(1).ReadOnly = True
            ListSat.Columns(2).Visible = False
            ListSat.Columns(3).Visible = False
            ListSat.Columns(1).HeaderText = "Produk"
            ListSat.Columns(4).HeaderText = "Jumlah dicetak"
            ListSat.Columns(5).DisplayIndex = 2
            makeFillDG(ListSat)
            styliseDG(ListSat)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim status As Boolean = False
        For Each row As DataGridViewRow In ListSat.Rows
            If Not Double.TryParse(row.Cells(4).Value(), 0) Then
                status = True
                Exit For
            End If
        Next


        If status Then
            dialogError("Isi jumlah dengan benar")
            Return
        End If

        Dim preview As CetakBarcode = New CetakBarcode()
        preview.dgvdata = ListSat
        If a4 Then
            preview.bcdA4()
        Else
            preview.bcdbaru()
        End If

        preview.ShowDialog()
        preview.Dispose()
    End Sub

    Private Sub ListSat_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles ListSat.DataError
        dialogError("Isi dengan benar")
    End Sub
End Class