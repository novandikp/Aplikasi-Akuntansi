Public Class DatagridGroup
    Dim update = False
    Dim role As String = ""

    Sub getRole()
        ListSat.DataSource = getData("select role from ""group""")
        styliseDG(ListSat)
        ListSat.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ListSat.Columns(0).HeaderText = "Role"
        deaksi()
        Me.ActiveControl = ListSat
    End Sub

    Sub aksi()
        AddBtn.Enabled = False
        HpsBtn.Enabled = False
        EdtBtn.Enabled = False
        btnSimpan.Enabled = True
        TBpelanggan.Enabled = True
        Button1.Enabled = True
        ListSat.Enabled = False
        FlowLayoutPanel1.Enabled = True
        Me.ActiveControl = TBpelanggan
        ListSat.ClearSelection()
    End Sub

    Sub deaksi()
        AddBtn.Enabled = True
        HpsBtn.Enabled = True
        EdtBtn.Enabled = True
        ListSat.Enabled = True
        btnSimpan.Enabled = False
        TBpelanggan.Enabled = False
        Button1.Enabled = False
        FlowLayoutPanel1.Enabled = False
    End Sub

    Sub setTambah()
        check = True
        Laporan.Checked = True
        MasterCheck.Checked = True
        TransaksiCheck.Checked = True
        GudangCheck.Checked = True
        UtilCheck.Checked = True

        TBpelanggan.Text = ""
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, True)
        Next
        For i As Integer = 0 To CheckedListBox2.Items.Count - 1
            CheckedListBox2.SetItemChecked(i, True)
        Next
        For i As Integer = 0 To CheckedListBox3.Items.Count - 1
            CheckedListBox3.SetItemChecked(i, True)
        Next
    End Sub

    Sub tambah()
        If AddBtn.Enabled = False Then
            Return
        End If
        update = False
        role = ""
        aksi()
        setTambah()
    End Sub

    Sub updateItem()
        If EdtBtn.Enabled = False Then
            Return
        End If
        If ListSat.SelectedRows.Count = 1 Then
            update = True
            role = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            setrole(ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString)
            aksi()
        Else
            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Function getItem() As String()
        Dim data(28) As String
        data(0) = TBpelanggan.Text
        If MasterCheck.Checked = True Then
            data(1) = "1"
        Else
            data(1) = "0"
        End If
        Dim pos As Integer = 1
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            pos += 1
            If CheckedListBox1.GetItemChecked(i) = True Then
                data(pos) = "1"
            Else
                data(pos) = "0"
            End If
        Next
        pos += 1
        If TransaksiCheck.Checked = True Then
            data(pos) = "1"
        Else
            data(pos) = "0"
        End If

        For i As Integer = 0 To CheckedListBox2.Items.Count - 1
            pos += 1
            If CheckedListBox2.GetItemChecked(i) = True Then
                data(pos) = "1"
            Else
                data(pos) = "0"
            End If
        Next

        pos += 1
        If Laporan.Checked = True Then
            data(pos) = "1"
        Else
            data(pos) = "0"
        End If


        pos += 1
        If GudangCheck.Checked = True Then
            data(pos) = "1"
        Else
            data(pos) = "0"
        End If


        pos += 1
        If UtilCheck.Checked = True Then
            data(pos) = "1"
        Else
            data(pos) = "0"
        End If

        For i As Integer = 0 To CheckedListBox3.Items.Count - 1
            pos += 1
            If CheckedListBox3.GetItemChecked(i) = True Then
                data(pos) = "1"
            Else
                data(pos) = "0"
            End If
        Next

        Return data
    End Function

    Sub setrole(role As String)


        Dim data =
                getData(
                    "select ""role"", mastertab, supplier, satuan, merk, kategori, produk, addproduk, pelanggan, ""level"", dokter, transaksi, listbeli, beli, returbeli, listjual, jual, returjual, hutang, piutang, laporan, gudang, utilitas, ""user"", identitas, grupmenu, backup, ""restore"", ""reset"" from ""group"" where role='" &
                    role & "'").Rows(0)
        TBpelanggan.Text = data.Item(0).ToString
        If data.Item(1).ToString = "1" Then
            MasterCheck.Checked = True
        Else
            MasterCheck.Checked = False
        End If
        Dim pos As Integer = 1
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            pos += 1

            If data.Item(pos).ToString = "1" Then
                CheckedListBox1.SetItemChecked(i, True)
            Else
                CheckedListBox1.SetItemChecked(i, False)
            End If
        Next
        pos += 1

        If data.Item(pos).ToString = "1" Then
            TransaksiCheck.Checked = True
        Else
            TransaksiCheck.Checked = False
        End If

        For i As Integer = 0 To CheckedListBox2.Items.Count - 1
            pos += 1
            If data.Item(pos).ToString = "1" Then
                CheckedListBox2.SetItemChecked(i, True)
            Else
                CheckedListBox2.SetItemChecked(i, False)
            End If
        Next

        pos += 1


        If data.Item(pos).ToString = "1" Then
            Laporan.Checked = True
        Else
            Laporan.Checked = False
        End If

        pos += 1

        If data.Item(pos).ToString = "1" Then
            GudangCheck.Checked = True
        Else
            GudangCheck.Checked = False
        End If

        pos += 1


        If data.Item(pos).ToString = "1" Then
            UtilCheck.Checked = True
        Else
            UtilCheck.Checked = False
        End If

        For i As Integer = 0 To CheckedListBox3.Items.Count - 1
            pos += 1
            If data.Item(pos).ToString = "1" Then
                CheckedListBox3.SetItemChecked(i, True)
            Else
                CheckedListBox3.SetItemChecked(i, False)
            End If
        Next
    End Sub

    Sub batal()
        If Button1.Enabled = False Then
            Return
        End If
        deaksi()
        setTambah()
    End Sub

    Sub simpan()
        If btnSimpan.Enabled = False Then
            Return
        End If
        If String.IsNullOrWhiteSpace(TBpelanggan.Text) Then
            dialogError("Isi role dengan benar")
        ElseIf update Then
            If _
                getCount("select role from ""group"" where role='" & TBpelanggan.Text & "'") > 0 And
                Not TBpelanggan.Text = role Then
                dialogError("Role sudah ada")
                Return
            End If

            operationQuery(
                "UPDATE ""group"" SET  role =?,  mastertab =?,  supplier = ?,  satuan =?,  merk =? ,  kategori =?,  produk =?, addproduk =?, pelanggan =?, level =?, dokter = ?, transaksi =?, listbeli =?, beli =? , returbeli =?, listjual =?, jual =?, returjual =?, hutang =?, piutang =?, laporan =?, gudang =? , utilitas =?, ""user"" =?, identitas =?, grupmenu =?, backup =?, restore =?, reset =? where  role ='" &
                role & "'", getItem())

            getRole()
            deaksi()
            setTambah()
        Else
            If getCount("select role from ""group"" where role='" & TBpelanggan.Text & "'") > 0 Then
                dialogError("Role sudah ada")
                Return
            End If
            operationQuery("INSERT INTO ""group"" VALUES (?,?,?,?,?,? ,?,?,?,?,?,?,? ,?,?,?,?,?,?,? ,?,?,?,?,?,?,?,?,?)",
                           getItem())
            getRole()
            deaksi()
            setTambah()
        End If
    End Sub

    Private Sub DatagridGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        getRole()
    End Sub

    Sub delete()
        If HpsBtn.Enabled = False Then
            Return
        End If
        If ListSat.SelectedRows.Count = 1 Then

            Dim id = ListSat.Rows(ListSat.SelectedRows(0).Index).Cells(0).Value.ToString
            If getCount("select role from tbluser where role='" & id & "'") Then
                dialogError("Role telah dipakai")
            Else
                If dialog("Apakah anda yakin untuk menghapus data ini ?") Then
                    exc("delete from ""group"" where role='" & id & "'")
                    getRole()
                End If

            End If

        Else

            dialogError("Pilih item terlebih dahulu")
        End If
        ListSat.ClearSelection()
    End Sub

    Dim check As Boolean = True

    Private Sub MasterCheck_CheckedChanged(sender As Object, e As EventArgs) Handles MasterCheck.CheckedChanged
        If check Then
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, MasterCheck.Checked)
            Next
        End If
    End Sub


    Private Sub TransaksiCheck_CheckedChanged(sender As Object, e As EventArgs) Handles TransaksiCheck.CheckedChanged
        If check Then
            For i As Integer = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, TransaksiCheck.Checked)
            Next
        End If
    End Sub

    Private Sub UtilCheck_CheckedChanged(sender As Object, e As EventArgs) Handles UtilCheck.CheckedChanged
        If check Then
            For i As Integer = 0 To CheckedListBox3.Items.Count - 1
                CheckedListBox3.SetItemChecked(i, UtilCheck.Checked)
            Next
        End If
    End Sub


    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click

        tambah()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpan()
    End Sub

    Private Sub EdtBtn_Click(sender As Object, e As EventArgs) Handles EdtBtn.Click
        updateItem()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        batal()
    End Sub

    Private Sub HpsBtn_Click(sender As Object, e As EventArgs) Handles HpsBtn.Click
        delete()
    End Sub

    Sub closeTab()
        Me.Close()
        Return
        Dim listItemForms As DatagridGroup = Application.OpenForms("DatagridGroup")
        If Not IsNothing(listItemForms) Then
            Form1.TabControl1.TabPages().Remove(Form1.TabControl1.TabPages(listItemForms))
        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles UtilCheck.KeyDown, TransaksiCheck.KeyDown, TBpelanggan.KeyDown, MasterCheck.KeyDown, ListSat.KeyDown,
                Laporan.KeyDown, HpsBtn.KeyDown, GudangCheck.KeyDown, EdtBtn.KeyDown, CheckedListBox3.KeyDown,
                CheckedListBox2.KeyDown, CheckedListBox1.KeyDown, Button1.KeyDown, btnSimpan.KeyDown, AddBtn.KeyDown

        If e.KeyCode = Keys.F6 Then
            ListSat.Focus()
            If ListSat.Rows.Count > 0 Then
                ListSat.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            tambah()
        ElseIf e.KeyCode = Keys.F2 Then
            updateItem()
        ElseIf e.KeyCode = Keys.Delete Then
            delete()
        ElseIf e.KeyCode = Keys.Escape Then
            batal()
        ElseIf e.KeyCode = Keys.F11 Then
            simpan()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            closeTab()

        End If
    End Sub

    Private Sub HpsBtn_KeyDown(sender As Object, e As KeyEventArgs) Handles HpsBtn.KeyDown
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles CheckedListBox1.SelectedIndexChanged
        check = False
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(i) = True Then
                MasterCheck.Checked = True
                Exit For
            Else
                MasterCheck.Checked = False
            End If
        Next

        For i As Integer = 0 To CheckedListBox2.Items.Count - 1
            If CheckedListBox2.GetItemChecked(i) = True Then
                TransaksiCheck.Checked = True
                Exit For
            Else
                TransaksiCheck.Checked = False
            End If
        Next

        For i As Integer = 0 To CheckedListBox3.Items.Count - 1
            If CheckedListBox3.GetItemChecked(i) = True Then
                UtilCheck.Checked = True
                Exit For
            Else
                UtilCheck.Checked = False
            End If
        Next
        check = True
    End Sub

    Private Sub CheckedListBox21_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles CheckedListBox2.SelectedIndexChanged
        check = False
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(i) = True Then
                MasterCheck.Checked = True
                Exit For
            Else
                MasterCheck.Checked = False
            End If
        Next

        For i As Integer = 0 To CheckedListBox2.Items.Count - 1
            If CheckedListBox2.GetItemChecked(i) = True Then
                TransaksiCheck.Checked = True
                Exit For
            Else
                TransaksiCheck.Checked = False
            End If
        Next

        For i As Integer = 0 To CheckedListBox3.Items.Count - 1
            If CheckedListBox3.GetItemChecked(i) = True Then
                UtilCheck.Checked = True
                Exit For
            Else
                UtilCheck.Checked = False
            End If
        Next
        check = True
    End Sub


    Private Sub CheckedListBox231_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles CheckedListBox3.SelectedIndexChanged
        check = False
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(i) = True Then
                MasterCheck.Checked = True
                Exit For
            Else
                MasterCheck.Checked = False
            End If
        Next

        For i As Integer = 0 To CheckedListBox2.Items.Count - 1
            If CheckedListBox2.GetItemChecked(i) = True Then
                TransaksiCheck.Checked = True
                Exit For
            Else
                TransaksiCheck.Checked = False
            End If
        Next

        For i As Integer = 0 To CheckedListBox3.Items.Count - 1
            If CheckedListBox3.GetItemChecked(i) = True Then
                UtilCheck.Checked = True
                Exit For
            Else
                UtilCheck.Checked = False
            End If
        Next
        check = True
    End Sub
End Class