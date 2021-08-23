Public Class MasterHakAkses
    Private Sub MasterHakAkses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub focusData()
        clearForm(gbForm)
        gbData.Enabled = True
        gbForm.Enabled = False
        panelAksi.Enabled = True
        fillData()

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

        If e.KeyCode = Keys.F5 Then
            eCari.Focus()
            ListSat.ClearSelection()
        ElseIf e.KeyCode = Keys.F6 Then
            ListSat.Focus()
            If ListSat.Rows.Count > 0 Then
                ListSat.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            tambah()
        ElseIf e.KeyCode = Keys.F2 Then
            edit()
        ElseIf e.KeyCode = Keys.Delete Then
            hapus()
        ElseIf e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Escape Then
            If gbForm.Enabled Then
                focusData()
                recentId = ""
            End If

        End If
    End Sub

    Sub focusForm()
        gbData.Enabled = False
        gbForm.Enabled = True
        panelAksi.Enabled = False
    End Sub


    Sub fillData()
        styliseDG(ListSat)
        Dim sql = $"select hakakses from tblakses where hakakses ilike '%{eCari.Text}%'"
        ListSat.DataSource = getData(sql)
        makeFillDG(ListSat)
    End Sub


    Dim recentId As String = ""
    Sub simpanDataAkses()
        If adaKosong(gbForm) Then
            dialogError("Harap isi form dengan benar")
        ElseIf String.IsNullOrEmpty(recentId) Then
            insertDataAkses()
        Else
            updateDataAkses()
        End If
    End Sub


    Sub insertDataAkses()
        If exc($"INSERT INTO tblakses values ('{TBKode.Text}')") Then
            exc($"insert into hakakses (fitur,akses) SELECT id, '{TBKode.Text}' FROM tblfitur")
            dialogSukses("Berhasil Disimpan")

            focusData()
            recentId = ""
            isiCBRole()
        Else
            dialogError("Akses sudah ada didatabase")
        End If
    End Sub

    Sub updateDataAkses()
        If exc($"UPDATE tblakses SET hakakses='{TBKode.Text}' WHERE hakakses='{recentId}'") Then
            dialogSukses("Berhasil Disimpan")
            focusData()
            recentId = ""
            isiCBRole()
        Else
            dialogError("Akses sudah ada didatabase")
        End If
    End Sub

    Sub simpanFiturAkses()
        Dim idakses = cbAkses.SelectedValue
        'Hapus akses
        exc($"DELETE FROM hakakses where akses = '{idakses}'")

        'Masukan akses
        For urutan As Integer = 0 To MasterList.Items.Count - 1
            If MasterList.GetItemChecked(urutan) Then
                Dim fitur As DataRowView = MasterList.Items(urutan)
                exc($"INSERT INTO hakakses (fitur,akses) values ({fitur(0).ToString},'{idakses}')")
            End If
        Next


        For urutan As Integer = 0 To DataLainList.Items.Count - 1
            If DataLainList.GetItemChecked(urutan) Then
                Dim fitur As DataRowView = DataLainList.Items(urutan)
                exc($"INSERT INTO hakakses (fitur,akses) values ({fitur(0).ToString},'{idakses}')")
            End If
        Next


        For urutan As Integer = 0 To PenjualanList.Items.Count - 1
            If PenjualanList.GetItemChecked(urutan) Then
                Dim fitur As DataRowView = PenjualanList.Items(urutan)
                exc($"INSERT INTO hakakses (fitur,akses) values ({fitur(0).ToString},'{idakses}')")
            End If
        Next

        For urutan As Integer = 0 To PembelianList.Items.Count - 1
            If PembelianList.GetItemChecked(urutan) Then
                Dim fitur As DataRowView = PembelianList.Items(urutan)
                exc($"INSERT INTO hakakses (fitur,akses) values ({fitur(0).ToString},'{idakses}')")
            End If
        Next

        For urutan As Integer = 0 To KasList.Items.Count - 1
            If KasList.GetItemChecked(urutan) Then
                Dim fitur As DataRowView = KasList.Items(urutan)
                exc($"INSERT INTO hakakses (fitur,akses) values ({fitur(0).ToString},'{idakses}')")
            End If
        Next

        For urutan As Integer = 0 To LaporanList.Items.Count - 1
            If LaporanList.GetItemChecked(urutan) Then
                Dim fitur As DataRowView = LaporanList.Items(urutan)
                exc($"INSERT INTO hakakses (fitur,akses) values ({fitur(0).ToString},'{idakses}')")
            End If
        Next

        For urutan As Integer = 0 To UtilitasList.Items.Count - 1
            If UtilitasList.GetItemChecked(urutan) Then
                Dim fitur As DataRowView = UtilitasList.Items(urutan)
                exc($"INSERT INTO hakakses (fitur,akses) values ({fitur(0).ToString},'{idakses}')")
            End If
        Next

    End Sub

    Sub awal()
        isiFitur()
        isiCBRole()
        focusData()
        addhandlertoAllComponent()
    End Sub

    Sub allAkses(Optional selected As Boolean = True)
        For urutan As Integer = 0 To MasterList.Items.Count - 1
            MasterList.SetItemChecked(urutan, selected)
        Next


        For urutan As Integer = 0 To DataLainList.Items.Count - 1
            DataLainList.SetItemChecked(urutan, selected)
        Next


        For urutan As Integer = 0 To PenjualanList.Items.Count - 1
            PenjualanList.SetItemChecked(urutan, selected)
        Next


        For urutan As Integer = 0 To PembelianList.Items.Count - 1
            PembelianList.SetItemChecked(urutan, selected)
        Next


        For urutan As Integer = 0 To KasList.Items.Count - 1
            KasList.SetItemChecked(urutan, selected)
        Next


        For urutan As Integer = 0 To LaporanList.Items.Count - 1
            LaporanList.SetItemChecked(urutan, selected)
        Next

        For urutan As Integer = 0 To UtilitasList.Items.Count - 1
            UtilitasList.SetItemChecked(urutan, selected)
        Next
    End Sub

    Sub setAkses()
        If cbAkses.Items.Count > 0 Then
            Dim idakses = cbAkses.SelectedValue
            Dim sql = $"select * from hakakses where akses='{idakses}'"

            allAkses(False)
            Dim dataAkses As DataTable = getData(sql)
            For Each fiturTerpilih As DataRow In dataAkses.Rows


                For urutan As Integer = 0 To MasterList.Items.Count - 1
                    Dim fitur As DataRowView = MasterList.Items(urutan)
                    If fitur(0).ToString.Equals(fiturTerpilih("fitur").ToString) Then
                        MasterList.SetItemChecked(urutan, True)
                        Exit For
                    End If
                Next



                For urutan As Integer = 0 To DataLainList.Items.Count - 1
                    Dim fitur As DataRowView = DataLainList.Items(urutan)
                    If fitur(0).ToString.Equals(fiturTerpilih("fitur").ToString) Then
                        DataLainList.SetItemChecked(urutan, True)
                        Exit For
                    End If
                Next


                For urutan As Integer = 0 To PenjualanList.Items.Count - 1
                    Dim fitur As DataRowView = PenjualanList.Items(urutan)
                    If fitur(0).ToString.Equals(fiturTerpilih("fitur").ToString) Then
                        PenjualanList.SetItemChecked(urutan, True)
                        Exit For
                    End If
                Next


                For urutan As Integer = 0 To PembelianList.Items.Count - 1
                    Dim fitur As DataRowView = PembelianList.Items(urutan)
                    If fitur(0).ToString.Equals(fiturTerpilih("fitur").ToString) Then
                        PembelianList.SetItemChecked(urutan, True)
                        Exit For
                    End If
                Next


                For urutan As Integer = 0 To KasList.Items.Count - 1
                    Dim fitur As DataRowView = KasList.Items(urutan)
                    If fitur(0).ToString.Equals(fiturTerpilih("fitur").ToString) Then
                        KasList.SetItemChecked(urutan, True)
                        Exit For
                    End If
                Next


                For urutan As Integer = 0 To LaporanList.Items.Count - 1
                    Dim fitur As DataRowView = LaporanList.Items(urutan)
                    If fitur(0).ToString.Equals(fiturTerpilih("fitur").ToString) Then
                        LaporanList.SetItemChecked(urutan, True)
                        Exit For
                    End If
                Next


                For urutan As Integer = 0 To UtilitasList.Items.Count - 1
                    Dim fitur As DataRowView = UtilitasList.Items(urutan)
                    If fitur(0).ToString.Equals(fiturTerpilih("fitur").ToString) Then
                        UtilitasList.SetItemChecked(urutan, True)
                        Exit For
                    End If
                Next


            Next
        End If
    End Sub

    Sub isiCBRole()
        cbAkses.DataSource = getData("select hakakses from tblakses")
        cbAkses.DisplayMember = "hakakses"
        cbAkses.ValueMember = "hakakses"
        cbAkses.SelectedIndex = 0
        setAkses()
    End Sub

    Sub isiFitur()
        Dim dt As DataTable = getData("select id,asal,'   ' || fitur as fitur from tblfitur order by posisiasal, id")

        'Fitur Master
        Dim dvMaster As DataView = dt.AsDataView
        dvMaster.RowFilter = "asal='Master'"
        MasterList.DataSource = dvMaster
        MasterList.DisplayMember = "fitur"
        MasterList.ValueMember = "id"
        MasterList.Height = MasterList.Items.Count * MasterList.GetItemHeight(0)
        MasterList.ClearSelected()

        'Fitur DataLain
        Dim dvDataLain As DataView = dt.AsDataView
        dvDataLain.RowFilter = "asal='Data Lain'"
        DataLainList.DataSource = dvDataLain
        DataLainList.DisplayMember = "fitur"
        DataLainList.ValueMember = "id"
        DataLainList.Height = DataLainList.Items.Count * DataLainList.GetItemHeight(0)
        DataLainList.ClearSelected()

        'Fitur Penjualan
        Dim dvPenjualan As DataView = dt.AsDataView
        dvPenjualan.RowFilter = "asal='Penjualan'"
        PenjualanList.DataSource = dvPenjualan
        PenjualanList.DisplayMember = "fitur"
        PenjualanList.ValueMember = "id"
        PenjualanList.Height = PenjualanList.Items.Count * PenjualanList.GetItemHeight(0)
        PenjualanList.ClearSelected()

        'Fitur Pembelian
        Dim dvPembelian As DataView = dt.AsDataView
        dvPembelian.RowFilter = "asal='Pembelian'"
        PembelianList.DataSource = dvPembelian
        PembelianList.DisplayMember = "fitur"
        PembelianList.ValueMember = "id"
        PembelianList.Height = PembelianList.Items.Count * PembelianList.GetItemHeight(0)
        PembelianList.ClearSelected()

        'Fitur Kas
        Dim dvKas As DataView = dt.AsDataView
        dvKas.RowFilter = "asal='Kas'"
        KasList.DataSource = dvKas
        KasList.DisplayMember = "fitur"
        KasList.ValueMember = "id"
        KasList.Height = KasList.Items.Count * KasList.GetItemHeight(0)
        KasList.ClearSelected()

        'Fitur Laporan
        Dim dvLaporan As DataView = dt.AsDataView
        dvLaporan.RowFilter = "asal='Laporan'"
        LaporanList.DataSource = dvLaporan
        LaporanList.DisplayMember = "fitur"
        LaporanList.ValueMember = "id"
        LaporanList.Height = LaporanList.Items.Count * LaporanList.GetItemHeight(0)
        LaporanList.ClearSelected()

        'Fitur Utilitas
        Dim dvUtilitas As DataView = dt.AsDataView
        dvUtilitas.RowFilter = "asal='Utilitas'"
        UtilitasList.DataSource = dvUtilitas
        UtilitasList.DisplayMember = "fitur"
        UtilitasList.ValueMember = "id"
        UtilitasList.Height = UtilitasList.Items.Count * UtilitasList.GetItemHeight(0)
        UtilitasList.ClearSelected()
    End Sub

    Private Sub cbAkses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAkses.SelectedIndexChanged
        setAkses()
    End Sub




    Dim checkedParent As Boolean = False
    Dim dontChangeCheck As Boolean = True
    Private Sub List_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles MasterList.ItemCheck,
        DataLainList.ItemCheck,
        PenjualanList.ItemCheck,
        PembelianList.ItemCheck,
        KasList.ItemCheck,
        LaporanList.ItemCheck,
        UtilitasList.ItemCheck

        If checkedParent Then
            Return
        End If
        Dim checkComponent As CheckBox

        Select Case CType(sender, CheckedListBox).Name
            Case "MasterList"
                checkComponent = MasterCheck
            Case "DataLainList"
                checkComponent = DataLainCheck
            Case "PenjualanList"
                checkComponent = PenjualanCheck
            Case "PembelianList"
                checkComponent = PembelianCheck
            Case "KasList"
                checkComponent = KasCheck
            Case "LaporanList"
                checkComponent = LaporanCheck
            Case "UtilitasList"
                checkComponent = UtilitasCheck
        End Select

        Dim nilai As Integer = e.NewValue
        If e.NewValue = 0 And e.CurrentValue = 1 Then
            nilai = -1
        End If
        If sender.CheckedItems.Count + nilai = sender.Items.Count Then
            checkedParent = True
            checkComponent.Checked = True
            checkedParent = False
        Else
            dontChangeCheck = False
            checkComponent.Checked = False
        End If
    End Sub

    Private Sub Parent_CheckedChanged(sender As Object, e As EventArgs) Handles MasterCheck.CheckedChanged,
    DataLainCheck.CheckedChanged,
    PenjualanCheck.CheckedChanged,
    PembelianCheck.CheckedChanged,
    KasCheck.CheckedChanged,
    LaporanCheck.CheckedChanged,
    UtilitasCheck.CheckedChanged



        If Not checkedParent Then
            Dim checkComponent As CheckedListBox
            Select Case CType(sender, CheckBox).Name
                Case "MasterCheck"
                    checkComponent = MasterList
                Case "DataLainCheck"
                    checkComponent = DataLainList
                Case "PenjualanCheck"
                    checkComponent = PenjualanList
                Case "PembelianCheck"
                    checkComponent = PembelianList
                Case "KasCheck"
                    checkComponent = KasList
                Case "LaporanCheck"
                    checkComponent = LaporanList
                Case "UtilitasCheck"
                    checkComponent = UtilitasList
            End Select
            checkedParent = True
            Dim allChecked = checkComponent.CheckedItems.Count = checkComponent.Items.Count
            For urutan As Integer = 0 To checkComponent.Items.Count - 1

                If CType(sender, CheckBox).Checked Then
                    checkComponent.SetItemChecked(urutan, True)
                ElseIf allChecked And dontChangeCheck And CType(sender, CheckBox).Checked = False Then
                    checkComponent.SetItemChecked(urutan, False)
                End If

            Next
            checkedParent = False
            dontChangeCheck = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If dialog("Apakah anda yakin untuk menyimpan akses fitur ini ?") Then
            simpanFiturAkses()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        focusData()
        recentId = ""
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub ListSat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListSat.CellClick
        If e.RowIndex >= 0 Then
            recentId = ListSat.Rows(e.RowIndex).Cells(0).Value
            TBKode.Text = recentId
        End If

    End Sub

    Sub tambah()
        clearForm(gbForm)
        focusForm()
    End Sub

    Sub edit()
        If String.IsNullOrEmpty(recentId) Or recentId = "" Then
            dialogError("Harap Pilih data terlebih dahulu")
        Else
            focusForm()
        End If
    End Sub


    Sub hapus()
        If String.IsNullOrEmpty(recentId) Or recentId = "" Then
            dialogError("Harap Pilih data terlebih dahulu")
        Else
            dialog("Apakah anda yakin untuk menghapus data ini ?")
            If exc($"DELETE from tblakses where hakakses = '{recentId}'") Then
                focusData()
                recentId = ""
            Else
                dialogError("Akses masih dipakai user lain")
            End If
        End If
    End Sub

    Private Sub btnEdt_Click(sender As Object, e As EventArgs) Handles btnEdt.Click
        edit()
    End Sub

    Private Sub btnTmbh_Click(sender As Object, e As EventArgs) Handles btnTmbh.Click
        tambah()
    End Sub

    Private Sub BtnHps_Click(sender As Object, e As EventArgs) Handles BtnHps.Click
        hapus()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        simpanDataAkses()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        allAkses()
    End Sub

    Private Sub eCari_Click(sender As Object, e As EventArgs) Handles eCari.TextChanged
        fillData()

    End Sub
End Class