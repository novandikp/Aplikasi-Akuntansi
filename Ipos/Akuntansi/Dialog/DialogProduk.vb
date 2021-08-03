Public Class DialogProduk

    Public visibleHargaJual As Boolean = True
    Public visibleHargaBeli As Boolean = True
    Public visibleHPP As Boolean = True
    Public visibleShowZero As Boolean = False
    Public idgudang As String = ""

    Public idproduk As String
    Public idharga As String

    Private Sub DialogSubklasifikasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillGudang()
        fillData()
        Me.ActiveControl = eCari
    End Sub

    Public tableProduk As DataTable

    Sub fillGudang()
        Dim sqlgudang = "SELECT idgudang, gudang from tblgudang"
        cbGudang.DataSource = getData(sqlgudang)
        cbGudang.DisplayMember = "gudang"
        cbGudang.ValueMember = "idgudang"
        cbGudang.SelectedValue = idgudang
        If IsNothing(cbGudang.SelectedValue) Then
            cbGudang.SelectedIndex = 0
        End If

    End Sub

    Sub countStok()
        If Not IsNothing(tableProduk) Then
            For Each row As DataRow In tableProduk.Rows
                If Not IsDBNull(row.Item("stok")) And Not IsDBNull(row.Item("nilaidasar")) Then
                    If row.Item("stok") >= row.Item("nilaidasar") Then
                        row.Item("stok") = Math.Floor(row.Item("stok") / row.Item("nilaidasar"))
                    Else
                        row.Item("stok") = 0
                    End If
                Else
                    row.Item("stok") = 0
                End If

            Next
        End If
    End Sub


    Sub fillData()
        Dim cari As String = eCari.Text
        If Not IsNothing(cbGudang.SelectedValue) Then

            Dim sqldata As String = "select tblharga.idharga,idproduk, produk,   tblstok.stok,nilaidasar, satuan,hargajual, hargabeli,hpp from tblharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan  left join (SELECT idbarang,sum(stok * tblharga.nilaidasar) as stok from tblstokgudang inner join tblharga on tblharga.idharga = tblstokgudang.idharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang where tblstokgudang.idgudang='" & cbGudang.SelectedValue.ToString & "'  group by idbarang) tblstok  on tblstok.idbarang = tblproduk.idproduk where (tblharga.idbarang ILIKE '%" & cari & "%' or produk ILIKE '%" & cari & "%') order by tblharga.idbarang,level"
            tableProduk = getData(sqldata)
            Dim dataview As DataView = tableProduk.AsDataView
            countStok()
            If visibleShowZero Then
                dataview.RowFilter = "stok > 0"
            End If
            ListSat.DataSource = dataview
            ListSat.Columns(0).Visible = False
            ListSat.Columns(1).HeaderText = "Kode Produk"
            ListSat.Columns(2).HeaderText = "Produk"
            ListSat.Columns(3).HeaderText = "Stok"
            ListSat.Columns(4).Visible = False
            ListSat.Columns(5).HeaderText = "Satuan"
            ListSat.Columns(6).Visible = visibleHargaJual
            ListSat.Columns(7).Visible = visibleHargaBeli
            ListSat.Columns(8).Visible = visibleHPP
            ListSat.Columns(6).HeaderText = "Harga Jual"
            ListSat.Columns(7).HeaderText = "Harga Beli"
            ListSat.Columns(8).HeaderText = "HPP"
            styliseDG(ListSat)
        End If
    End Sub

    Private Sub cbSub_SelectedIndexChanged(sender As Object, e As EventArgs)
        fillData()
    End Sub



    Private Sub ListSat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            idharga = ListSat.Rows(e.RowIndex).Cells(0).Value
            idproduk = ListSat.Rows(e.RowIndex).Cells(1).Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub ListSat_KeyDown(sender As Object, e As KeyEventArgs) Handles ListSat.KeyDown, Me.KeyDown
        If Not IsNothing(ListSat.CurrentRow) And e.KeyCode = Keys.Enter Then
            idharga = ListSat.Rows(ListSat.CurrentRow.Index).Cells(0).Value
            idproduk = ListSat.Rows(ListSat.CurrentRow.Index).Cells(1).Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub eCari_Click(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()
    End Sub

    Private Sub cbGudang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGudang.SelectedIndexChanged
        If Not IsNothing(cbGudang.SelectedValue) Then
            fillData()
        End If
    End Sub

    Private Sub ListSat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellContentClick

    End Sub
End Class