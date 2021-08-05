Public Class DaftarPiutangUsaha
    Private Sub DaftarPiutangUsaha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillData()
    End Sub


    Sub fillData()
        styliseDG(ListSat)
        Dim sql As String = "SELECT pelanggan,jumlahutang,jumlahbayar, sisa,idpelanggan from view_rekap_piutang where pelanggan ilike '%" & eCari.Text & "%'"
        ListSat.DataSource = getData(sql)
        makeFillDG(ListSat)


        ListSat.Columns(0).HeaderText = "Nama Pelanggan"
        ListSat.Columns(1).HeaderText = "Jumlah Hutang"
        ListSat.Columns(2).HeaderText = "Jumlah Bayar"
        ListSat.Columns(3).HeaderText = "Sisa Hutang"
        ListSat.Columns(4).Visible = False
        ListSat.Columns(1).DefaultCellStyle.Format = "c0"
        ListSat.Columns(2).DefaultCellStyle.Format = "c0"
        ListSat.Columns(3).DefaultCellStyle.Format = "c0"

    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        closeTab()
    End Sub

    Sub closeTab()
        Me.Close()
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
    End Sub

    Sub addhandlertoAllComponent()
        For Each komponen As Control In Me.Controls
            AddHandler komponen.KeyDown, AddressOf handlerAllComponent
            If komponen.Controls.Count > 0 Then
                For Each komponen2 As Control In komponen.Controls
                    AddHandler komponen2.KeyDown, AddressOf handlerAllComponent
                    If komponen2.Controls.Count > 0 Then
                        For Each komponen3 As Control In komponen2.Controls
                            AddHandler komponen3.KeyDown, AddressOf handlerAllComponent
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub handlerAllComponent(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            Me.ActiveControl = eCari
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()
        End If
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        If ListSat.SelectedRows.Count = 1 Then
            Dim idselected As String = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(4).Value
            Dim dialog As New DetailPiutangUsaha
            dialog.idkontak = idselected
            dialog.ShowDialog()
            fillData()
            dialog.Dispose()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
    End Sub
End Class