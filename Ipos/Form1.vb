Imports MdiTabControl

Public Class Form1
    Public username As String = ""
    Public role As String = ""
    Public cabang As String = "-"
    Public idcabang As String = ""

    Sub setRole(role As String)

        Dim datarole As DataTable = getData("select * from  ""group"" where role='" & role & "'")
        Dim dat = datarole.Rows(0)
        Dim urutan = 1
        If dat.Item("mastertab") = "1" Then

            MasterTab.Visible = True
            Dim produkpanel = 0
            Dim pelangganpanel = 0
            If dat.Item("supplier") = "1" Then
                SupplierPanel.Visible = True
                SupplierTab.Visible = True
                SupplierTab.AltKey = urutan.ToString
                urutan += 1
                dat.Item("utilitas") = "1"
            Else
                SupplierPanel.Visible = False
                SupplierTab.Visible = False
                SupplierTab.AltKey = ""
            End If


            If dat.Item("kategori") = "1" Then

                DaftarKategoriBtn.Visible = True
                DaftarKategoriBtn.AltKey = urutan.ToString
                urutan += 1
                produkpanel = 1
            Else

                DaftarKategoriBtn.Visible = False
                DaftarKategoriBtn.AltKey = ""
            End If

            If dat.Item("merk") = "1" Then

                DaftarMerkBtn.Visible = True
                DaftarMerkBtn.AltKey = urutan.ToString
                urutan += 1
                produkpanel = 1
            Else

                DaftarMerkBtn.Visible = False
                DaftarMerkBtn.AltKey = ""
            End If

            If dat.Item("satuan") = "1" Then

                DaftarSatuanBtn.Visible = True
                DaftarSatuanBtn.AltKey = urutan.ToString
                urutan += 1
                produkpanel = 1
            Else

                DaftarSatuanBtn.Visible = False
                DaftarSatuanBtn.AltKey = ""
            End If
            If dat.Item("addproduk") = "1" Then

                tambahProdukRibbon.Visible = True
                tambahProdukRibbon.AltKey = urutan.ToString
                urutan += 1
                produkpanel = 1
            Else

                tambahProdukRibbon.Visible = False
                tambahProdukRibbon.AltKey = ""
            End If

            If dat.Item("produk") = "1" Then

                DaftarProdukBtn.Visible = True
                DaftarProdukBtn.AltKey = urutan.ToString
                urutan += 1
                produkpanel = 1
                dat.Item("utilitas") = "1"
            Else

                DaftarProdukBtn.Visible = False
                DaftarProdukBtn.AltKey = ""
            End If


            If produkpanel = 0 Then
                Me.ProdukPanel.Visible = False
            Else
                Me.ProdukPanel.Visible = True
            End If

            If dat.Item("pelanggan") = "1" Then

                ListPelangganBtn.Visible = True
                ListPelangganBtn.AltKey = urutan.ToString
                urutan += 1
                pelangganpanel = 1
                dat.Item("utilitas") = "1"
            Else

                ListPelangganBtn.Visible = False
                ListPelangganBtn.AltKey = ""
            End If

            If dat.Item("level") = "1" Then

                lvlPelangganBtn.Visible = True
                lvlPelangganBtn.AltKey = urutan.ToString
                urutan += 1
                pelangganpanel = 1
            Else

                lvlPelangganBtn.Visible = False
                lvlPelangganBtn.AltKey = ""
            End If

            If pelangganpanel = 0 Then
                Me.PelangganPanel.Visible = False
            Else
                Me.PelangganPanel.Visible = True
            End If
            If dat.Item("dokter") = "1" Then
                DokterPanel.Visible = True
                DaftarDokterBTN.Visible = True
                DaftarDokterBTN.AltKey = urutan.ToString
                urutan += 1

            Else
                DokterPanel.Visible = False
                DaftarDokterBTN.Visible = False
                DaftarDokterBTN.AltKey = ""
            End If

            If dat.Item("produk") = "1" Then

                RibbonButton39.Visible = True
                RibbonButton39.AltKey = urutan.ToString
                urutan += 1
                produkpanel = 1
                dat.Item("utilitas") = "1"
            Else

                RibbonButton39.Visible = False
                RibbonButton39.AltKey = ""
            End If
            MasterTab.AltKey = "M"

        Else
            MasterTab.Visible = False
            MasterTab.AltKey = ""
        End If

        urutan = 1
        If dat.Item("transaksi") = "1" Then

            TransaksiTab.Visible = True
            Dim belipanel = 0
            Dim jualpanel = 0
            Dim hutangpanel = 0

            If dat.Item("listbeli") = "1" Then

                PembelianBTN.Visible = True
                PembelianBTN.AltKey = urutan.ToString
                urutan += 1
                belipanel = 1
            Else

                PembelianBTN.Visible = False
                PembelianBTN.AltKey = ""
            End If

            If dat.Item("beli") = "1" Then

                KulakanTabBtn.Visible = True
                KulakanTabBtn.AltKey = urutan.ToString
                urutan += 1
                belipanel = 1
            Else

                KulakanTabBtn.Visible = False
                KulakanTabBtn.AltKey = ""
            End If

            If dat.Item("returbeli") = "1" Then

                ReturBeliTab.Visible = True
                ReturBeliTab.AltKey = urutan.ToString
                urutan += 1
                belipanel = 1
            Else

                ReturBeliTab.Visible = False
                ReturBeliTab.AltKey = ""
            End If

            If belipanel = 0 Then
                Me.PembelianPanel.Visible = False
            Else
                Me.PembelianPanel.Visible = True
            End If

            If dat.Item("listjual") = "1" Then

                DaftarPenjulan.Visible = True
                DaftarPenjulan.AltKey = urutan.ToString
                urutan += 1
                jualpanel = 1
            Else

                DaftarPenjulan.Visible = False
                DaftarPenjulan.AltKey = ""
            End If

            If dat.Item("jual") = "1" Then

                PenjualanTabBtn.Visible = True
                PenjualanTabBtn.AltKey = urutan.ToString
                urutan += 1
                jualpanel = 1
            Else

                PenjualanTabBtn.Visible = False
                PenjualanTabBtn.AltKey = ""
            End If

            If dat.Item("returjual") = "1" Then

                Returtab.Visible = True
                Returtab.AltKey = urutan.ToString
                urutan += 1
                jualpanel = 1
            Else

                Returtab.Visible = False
                Returtab.AltKey = ""
            End If

            If jualpanel = 0 Then
                Me.PenjualanPanel.Visible = False
            Else
                Me.PenjualanPanel.Visible = True
            End If


            If dat.Item("hutang") = "1" Then

                HutangTabBtn.Visible = True
                HutangTabBtn.AltKey = urutan.ToString
                urutan += 1
                hutangpanel = 1
            Else

                HutangTabBtn.Visible = False
                HutangTabBtn.AltKey = ""
            End If

            If dat.Item("piutang") = "1" Then

                PiutangTabBtn.Visible = True
                PiutangTabBtn.AltKey = urutan.ToString
                urutan += 1
                hutangpanel = 1
            Else

                PiutangTabBtn.Visible = False
                PiutangTabBtn.AltKey = ""
            End If

            If hutangpanel = 0 Then
                Me.RibbonPanel7.Visible = False
            Else
                Me.PenjualanPanel.Visible = True
            End If


            If dat.Item("jual") = "1" Then

                hargaPanel.Visible = True
                RibbonButton29.AltKey = urutan.ToString
                urutan += 1

            Else

                hargaPanel.Visible = False
                RibbonButton29.AltKey = ""
            End If

            TransaksiTab.AltKey = "T"
            If MasterTab.Visible = False Then
                MenuRibbon.ActiveTab = TransaksiTab
            End If

        Else
            TransaksiTab.Visible = False
            TransaksiTab.AltKey = ""
        End If
        urutan = 1
        If dat.Item("gudang") = "1" Then

            GudangTab.Visible = True

            GudangTab.AltKey = "G"
            If TransaksiTab.Visible = False Then
                MenuRibbon.ActiveTab = GudangTab
            End If

        Else
            GudangTab.Visible = False
            GudangTab.AltKey = ""
        End If
        urutan = 1
        If dat.Item("laporan") = "1" Then

            LaporanTab.Visible = True

            LaporanTab.AltKey = "G"
            If GudangTab.Visible = False Then
                MenuRibbon.ActiveTab = LaporanTab
            End If

        Else
            LaporanTab.Visible = False
            LaporanTab.AltKey = ""
        End If
        urutan = 1
        If dat.Item("utilitas") = "1" Then
            Dim settingpanel = 0
            Dim databasepanel = 0
            Dim importpanel = 0
            UtilitasTab.Visible = True
            If dat.Item("user") = "1" Then

                RibbonButton22.Visible = True
                RibbonButton22.AltKey = urutan.ToString
                urutan += 1
                settingpanel = 1
            Else

                RibbonButton22.Visible = False
                RibbonButton22.AltKey = ""
            End If

            If dat.Item("identitas") = "1" Then

                RibbonButton23.Visible = True
                RibbonButton23.AltKey = urutan.ToString
                urutan += 1
                settingpanel = 1
            Else

                RibbonButton23.Visible = False
                RibbonButton23.AltKey = ""
            End If
            If dat.Item("grupmenu") = "1" Then

                RibbonButton24.Visible = True
                RibbonButton24.AltKey = urutan.ToString
                urutan += 1
                settingpanel = 1
            Else

                RibbonButton24.Visible = False
                RibbonButton24.AltKey = ""
            End If

            If dat.Item("user") = "1" Then

                CabangTab.Visible = True
                CabangTab.AltKey = urutan.ToString
                urutan += 1
                settingpanel = 1
            Else

                CabangTab.Visible = False
                CabangTab.AltKey = ""
            End If

            If settingpanel = 0 Then
                RibbonPanel14.Visible = False
            Else
                RibbonPanel14.Visible = True
            End If

            If dat.Item("backup") = "1" Then

                BackupTabBtn.Visible = True
                BackupTabBtn.AltKey = urutan.ToString
                urutan += 1
                databasepanel = 1
            Else

                BackupTabBtn.Visible = False
                BackupTabBtn.AltKey = ""
            End If
            If dat.Item("restore") = "1" Then

                RestoreTabBtn.Visible = True
                RestoreTabBtn.AltKey = urutan.ToString
                urutan += 1
                databasepanel = 1
            Else

                RestoreTabBtn.Visible = False
                RestoreTabBtn.AltKey = ""
            End If

            If dat.Item("reset") = "1" Then

                ResetTabBtn.Visible = True
                ResetTabBtn.AltKey = urutan.ToString
                urutan += 1
                databasepanel = 1
            Else

                ResetTabBtn.Visible = False
                ResetTabBtn.AltKey = ""
            End If

            If databasepanel = 0 Then
                RibbonPanel9.Visible = False
            Else
                RibbonPanel9.Visible = True
            End If


            If dat.Item("supplier") = "1" Then

                RibbonButton31.Visible = True
                RibbonButton31.AltKey = urutan.ToString
                urutan += 1
                importpanel = 1
            Else

                RibbonButton31.Visible = False
                RibbonButton31.AltKey = ""
            End If
            If dat.Item("produk") = "1" Then

                RibbonButton30.Visible = True
                RibbonButton30.AltKey = urutan.ToString
                urutan += 1
                importpanel = 1

                impJasa.Visible = True
                impJasa.AltKey = urutan.ToString
                urutan += 1
                importpanel = 1
            Else

                RibbonButton30.Visible = False
                RibbonButton30.AltKey = ""

                impJasa.Visible = False
                impJasa.AltKey = ""
            End If

            If dat.Item("pelanggan") = "1" Then

                RibbonButton32.Visible = True
                RibbonButton32.AltKey = urutan.ToString
                urutan += 1
                importpanel = 1
            Else

                RibbonButton32.Visible = False
                RibbonButton32.AltKey = ""
            End If

            If importpanel = 0 Then
                RibbonPanel15.Visible = False
            Else
                RibbonPanel15.Visible = True
            End If

            UtilitasTab.AltKey = "U"


        Else
            UtilitasTab.Visible = False
            UtilitasTab.AltKey = ""
        End If


        If MasterTab.Visible Then
            MenuRibbon.ActiveTab = MasterTab
        ElseIf TransaksiTab.Visible Then
            MenuRibbon.ActiveTab = TransaksiTab
        ElseIf GudangTab.Visible Then
            MenuRibbon.ActiveTab = GudangTab
        ElseIf LaporanTab.Visible Then
            MenuRibbon.ActiveTab = LaporanTab
        ElseIf UtilitasTab.Visible Then
            MenuRibbon.ActiveTab = UtilitasTab
        End If
    End Sub

     Sub openMenuUtama(Optional role As String = "")
        If getValue("select tampilharga from ""group"" where role = '" & role & "'", "tampilharga") = "0" Then
            Modul.hargabeli = False
        Else
            Modul.hargabeli = True
        End If

        

        MenuRibbon.Visible = True

        setRole(role)
        Panel2.Visible = True
        TabControl1.Visible = True
        Dim addItemForms As MenuUtama = Application.OpenForms("MenuUtama")
        If IsNothing(addItemForms) Then
            addItemForms = New MenuUtama
            TabControl1.TabPages.Add(addItemForms)
            TabControl1.TabPages(addItemForms).CloseButtonVisible = False
            addItemForms.setnama()
            addItemForms.getProduk()
            addItemForms.getHutang()
        Else
            TabControl1.TabPages(addItemForms).Select()
            TabControl1.TabPages(addItemForms).CloseButtonVisible = False
            addItemForms.setnama()
            addItemForms.getProduk()
            addItemForms.getHutang()
        End If
    End Sub

    Sub refreshProduk()
        Dim addItemForms As MenuUtama = Application.OpenForms("MenuUtama")
        If Not IsNothing(addItemForms) Then
            addItemForms.getProduk()
        End If
    End Sub


    Sub refreshHutang()
        Dim addItemForms As MenuUtama = Application.OpenForms("MenuUtama")
        If Not IsNothing(addItemForms) Then
            addItemForms.getHutang()
        End If
    End Sub


    Sub refreshButton()
        Dim addItemForms As MenuUtama = Application.OpenForms("MenuUtama")
        If Not IsNothing(addItemForms) Then

            addItemForms.setnama()


        End If
    End Sub

    Sub setnama()
        Dim addItemForms As MenuUtama = Application.OpenForms("MenuUtama")
        If IsNothing(addItemForms) Then
            addItemForms = New MenuUtama
        End If

        addItemForms.setnama()
        addItemForms = Nothing
    End Sub

    Sub closeAllTab()
        For pages As Integer = 0 To Application.OpenForms.Count - 1
            Try
                If Not Application.OpenForms(pages).Name = "Form1" Then
                    TabControl1.TabPages().Remove(TabControl1.TabPages(Application.OpenForms(pages)))
                End If

            Catch ex As Exception
                closeAllTab()
            End Try

        Next
    End Sub

    Sub BukaLogin()
        closeAllTab()
        Panel2.Visible = False
        MenuRibbon.Visible = False
        TabControl1.Visible = False
        Login.ShowDialog()
    End Sub

    Sub BukaKoneksi()
        closeAllTab()
        Panel2.Visible = False
        MenuRibbon.Visible = False
        TabControl1.Visible = False
        Login.Hide()
        Dim kon As New KoneksiDatabase
        kon.ShowDialog()
        kon.Dispose()
    End Sub

    Sub logout()
        If dialog("Apakah anda yakin untuk logout dari akun ini ?") Then
            closeAllTab()
            MenuRibbon.Visible = False
            Panel2.Visible = False
            TabControl1.Visible = False
            cabang = "-"
            Login.ShowDialog()
        End If
    End Sub

    'start produk Function
    Sub openListProduk()
        Dim itemListForm As DatagridBarang = Application.OpenForms("DatagridBarang")
        If IsNothing(itemListForm) Then
            itemListForm = New DatagridBarang
            TabControl1.TabPages.Add(itemListForm)
        Else
            TabControl1.TabPages(itemListForm).Select()
            itemListForm.getDataProduk()
        End If
    End Sub

    Sub openEditProduk(Optional idbarang As String = "")
        FormEditBarang.idbarang = idbarang

        FormEditBarang.ShowDialog()
        FormEditBarang.Dispose()
    End Sub

    Sub refreshSatuanEditProduk()
        Dim addItemForms As FormEditBarang = Application.OpenForms("FormEditBarang")
        addItemForms.getDataSatuan()
    End Sub

    Sub refreshSatuanTambahProduk()

    End Sub

    Sub openTambahProduk()


    End Sub

    'end produk Function

    'Satuan function
    Sub openListSatuan()
        Dim itemListForm As DatagridSatuan = Application.OpenForms("DatagridSatuan")
        If IsNothing(itemListForm) Then
            itemListForm = New DatagridSatuan
            TabControl1.TabPages.Add(itemListForm)
        Else
            TabControl1.TabPages(itemListForm).Select()

        End If
    End Sub

    Sub openListMerk()
        Dim itemListForm As FormDatagridMerk = Application.OpenForms("FormDatagridMerk")
        If IsNothing(itemListForm) Then
            itemListForm = New FormDatagridMerk
            TabControl1.TabPages.Add(itemListForm)
        Else
            TabControl1.TabPages(itemListForm).Select()

        End If
    End Sub

    Sub openListKategori()
        FormDatagridKategori.ShowDialog()
        FormDatagridKategori.Dispose()
    End Sub

    Sub openListPelanggan()
        Dim itemListForm As DatagridPelanggan = Application.OpenForms("DataGridPelanggan")
        If IsNothing(itemListForm) Then
            itemListForm = New DatagridPelanggan
            TabControl1.TabPages.Add(itemListForm)
        Else
            TabControl1.TabPages(itemListForm).Select()
            itemListForm.getDataPelanggan()
        End If
    End Sub


    Sub openTambahPelanggan()

        FormPelanggan.ShowDialog()
        FormPelanggan.Dispose()
    End Sub

    Sub openEditPelanggan(Optional idpelanggan As String = "")

        FormEditPelanggan.idpelanggan = idpelanggan
        FormEditPelanggan.ShowDialog()
        FormEditPelanggan.Dispose()
    End Sub


    'Pelanggan 


    Sub openListSupplier()
        DatagridSupplier.ShowDialog()
        DatagridSupplier.Dispose()
    End Sub

    Sub openEditSupplier(Optional idsupplier As String = "")

        FormEditSupplier.idsupplier = idsupplier
        FormEditSupplier.ShowDialog()
        FormEditBarang.Dispose()
    End Sub


    Sub openTambahSupplier()

        FormSupplier.ShowDialog()
        FormSupplier.Dispose()
    End Sub

    Sub openListLevel()
        Dim addItemForms As FormDatagridLevel = Application.OpenForms("FormDatagridLevel")
        If IsNothing(addItemForms) Then
            addItemForms = New FormDatagridLevel
            TabControl1.TabPages.Add(addItemForms)
        Else
            TabControl1.TabPages(addItemForms).Select()

        End If
    End Sub

    Sub openListGroup()
        DatagridGroup.getRole()
        DatagridGroup.deaksi()
        DatagridGroup.ShowDialog()
    End Sub


    Sub openListKas()
        Dim addItemForms As DatagridKas = Application.OpenForms("DatagridKas")
        If IsNothing(addItemForms) Then
            addItemForms = New DatagridKas
            TabControl1.TabPages.Add(addItemForms)
        Else
            TabControl1.TabPages(addItemForms).Select()

        End If
        addItemForms.getDataKas()
    End Sub

    Sub openTambahKas()
        Dim addItemForms As FormKas = Application.OpenForms("FormKas")
        If IsNothing(addItemForms) Then
            addItemForms = New FormKas
            TabControl1.TabPages.Add(addItemForms)
        Else
            TabControl1.TabPages(addItemForms).Select()

        End If
    End Sub

    Sub openEditKas(Optional idbarang As String = "")

        FormEditKas.kodekas = idbarang
        FormEditKas.ShowDialog()
    End Sub

    Sub openListUser()

        DatagridUser.ShowDialog()
        DatagridUser.Dispose()
    End Sub

    Sub openTambahUser()

        FormUser.ShowDialog()
        FormUser.Dispose()
    End Sub

    Sub openEditUser(Optional idbarang As String = "")

        FormEditUser.username = idbarang
        FormEditUser.ShowDialog()
        FormEditUser.Dispose()
    End Sub

    Sub openPenjualan(Optional reload As Boolean = False)
        If reload Then

            FormPenawaranJual.Refresh()
        Else

        End If
        FormPenawaranJual.ShowDialog()
        FormPenawaranJual.Dispose()
        FormPenawaranJual.saved = False
        FormPenawaranJual.awal()
    End Sub

    Sub openEditPenjualan(idorder As String)
        FormPenawaranJual.continueOrder()
        FormPenawaranJual.ShowDialog()

        FormPenawaranJual.Dispose()
    End Sub


    Sub openPembelian(Optional reload As Boolean = False)
        FormPembelian.ShowDialog()
        FormPembelian.awal()
        FormPembelian.Dispose()
    End Sub

    Sub openListPenjualan()
        DaftarPenjualan.getDataPelanggan()
        DaftarPenjualan.ShowDialog()
    End Sub

    Sub openListPembelian()

        DaftarPembelian.ShowDialog()
        DaftarPembelian.Dispose()
    End Sub

    Sub openRetur()

        DatagridRetur.ShowDialog()
        DatagridRetur.Dispose()
    End Sub

    Sub openReturBeli()
        DatagridReturBeli.ShowDialog()
        DatagridReturBeli.Dispose()
    End Sub

    Sub openOpname()
        Datagridopname.ShowDialog()
        Datagridopname.Dispose()
    End Sub

    Sub openRefOpname()
        DataRefOpname.ShowDialog()
        DataRefOpname.Dispose()
    End Sub

    Sub openHutang()
        DatagridHutang.ShowDialog()
        DatagridHutang.Dispose()
    End Sub

    Sub openPiutang()
        DatagridPiutang.ShowDialog()
        DatagridPiutang.Dispose()
    End Sub


    Sub openLaporanBarang()
        Dim addItemForms As LaporanBarang = Application.OpenForms("LaporanBarang")
        If IsNothing(addItemForms) Then
            addItemForms = New LaporanBarang
            TabControl1.TabPages.Add(addItemForms)
        Else
            TabControl1.TabPages(addItemForms).Select()

        End If
    End Sub

    Sub openHistoryRetur()
        Dim addItemForms As HistoriRetur = Application.OpenForms("HistoriRetur")
        If IsNothing(addItemForms) Then
            addItemForms = New HistoriRetur
            TabControl1.TabPages.Add(addItemForms)
        Else
            TabControl1.TabPages(addItemForms).Select()

        End If
        addItemForms.getDataPelanggan()
    End Sub

    Sub openHistoryReturBeli()
        Dim addItemForms As HistoryReturBeli = Application.OpenForms("HistoryReturBeli")
        If IsNothing(addItemForms) Then
            addItemForms = New HistoryReturBeli
            TabControl1.TabPages.Add(addItemForms)
        Else
            TabControl1.TabPages(addItemForms).Select()

        End If
        addItemForms.getDataPelanggan()
    End Sub

    Sub setBarangBeli(Optional idbar As String = "", Optional row As Integer = 0, Optional satuan As String = "")

        Dim addItemForms As FormPembelian = Application.OpenForms("FormPembelian")
        If Not IsNothing(addItemForms) Then

            Try
                addItemForms.cariBarang(idbar, row, satuan)

            Catch ex As Exception

            End Try

        End If
    End Sub

    Sub setClearBarangBeli(row As Integer)

        Dim addItemForms As FormPembelian = Application.OpenForms("FormPembelian")
        If Not IsNothing(addItemForms) Then

            Try
                '  addItemForms.clearRow(row)

            Catch ex As Exception

            End Try

        End If
    End Sub

    Sub setBarangJual(Optional idbar As String = "", Optional row As Integer = 0, Optional satuan As String = "")

        Dim addItemForms As FormPenawaranJual = Application.OpenForms("FormPenjualan")
        If Not IsNothing(addItemForms) Then

            Try

            Catch ex As Exception

            End Try

        End If
    End Sub

    Sub setClearBarangJual(row As Integer)

        Dim addItemForms As FormPenawaranJual = Application.OpenForms("FormPenjualan")
        If Not IsNothing(addItemForms) Then

            Try
                addItemForms.clearRow(row)

            Catch ex As Exception

            End Try

        End If
    End Sub


    Sub setSupplierBeli(Optional idsup As String = "")
        Dim addItemForms As FormPembelian = Application.OpenForms("FormPembelian")
        If Not IsNothing(addItemForms) Then
            Try
                addItemForms.getSupplier()
                addItemForms.CBsupplier.SelectedValue = idsup
            Catch ex As Exception

            End Try

        End If
    End Sub

    Sub setDokterJual(Optional idsup As String = "")
        Dim addItemForms As FormPenawaranJual = Application.OpenForms("FormPenjualan")
        If Not IsNothing(addItemForms) Then
            Try


            Catch ex As Exception

            End Try

        End If
    End Sub

    Sub setPelangganjual(Optional idsup As String = "")
        Dim addItemForms As FormPenawaranJual = Application.OpenForms("FormPenjualan")
        If Not IsNothing(addItemForms) Then
            Try
                addItemForms.getPelanggan()
                addItemForms.CBsupplier.SelectedValue = idsup
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub RibbonOrbMenuItem6_Click(sender As Object, e As EventArgs) Handles RibbonOrbMenuItem6.Click
        keluarAplikasi()
    End Sub


    Public Sub keluarAplikasi()
        Me.Close()
    End Sub

    Private Sub DaftarProdukBtn_Click(sender As Object, e As EventArgs) Handles DaftarProdukBtn.Click
        DatagridBarang.ShowDialog()
        DatagridBarang.Dispose()
    End Sub

    Private Sub tambahProdukRibbon_Click(sender As Object, e As EventArgs) Handles tambahProdukRibbon.Click

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BukaLogin()
    End Sub

    Private Sub ListPelangganBtn_Click(sender As Object, e As EventArgs) Handles ListPelangganBtn.Click
        DatagridPelanggan.ShowDialog()
        DatagridPelanggan.Dispose()
    End Sub

    Private Sub addPelangganBTn_Click(sender As Object, e As EventArgs)
        openTambahPelanggan()
    End Sub

    Private Sub TabControl1_Load(sender As Object, e As EventArgs) Handles TabControl1.Load
        Dim tabcontrol As TabControl = sender
    End Sub

    Private Sub TabControl1_SelectedTabChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedTabChanged
        Dim tabcontrol As TabPage = sender

        If tabcontrol.TabIndex = 0 Then
            TabControl1.CloseButtonVisible = False
        Else
            TabControl1.CloseButtonVisible = True
        End If
    End Sub

    Private Sub PenjualanTabBtn_Click(sender As Object, e As EventArgs) Handles PenjualanTabBtn.Click
        openPenjualan()
    End Sub

    Private Sub DaftarSatuanBtn_Click(sender As Object, e As EventArgs) Handles DaftarSatuanBtn.Click
        DatagridSatuan.ShowDialog()
        DatagridSatuan.Dispose()
    End Sub

    Private Sub DaftarMerkBtn_Click(sender As Object, e As EventArgs) Handles DaftarMerkBtn.Click
        FormDatagridMerk.ShowDialog()
        FormDatagridMerk.Dispose()
    End Sub

    Private Sub DaftarKategoriBtn_Click(sender As Object, e As EventArgs) Handles DaftarKategoriBtn.Click

        openListKategori()
    End Sub


    Private Sub SuplierRibbon_Click(sender As Object, e As EventArgs) Handles SuplierRibbon.Click
        openListSupplier()
    End Sub

    Private Sub AddSupplierRibbon_Click(sender As Object, e As EventArgs)
        openTambahSupplier()
    End Sub

    Private Sub lvlPelangganBtn_Click(sender As Object, e As EventArgs) Handles lvlPelangganBtn.Click

        FormDatagridLevel.ShowDialog()
        FormDatagridLevel.Dispose()
        'openListLevel()
    End Sub

    Private Sub RibbonOrbMenuItem5_Click(sender As Object, e As EventArgs)
        logout()
    End Sub

    Private Sub PembelianBtnTab_Click(sender As Object, e As EventArgs) Handles PembelianBtnTab.Click
        openPembelian()
    End Sub

    Private Sub DaftarPenjulan_Click(sender As Object, e As EventArgs) Handles DaftarPenjulan.Click
        openListPenjualan()
    End Sub

    Private Sub Returtab_Click(sender As Object, e As EventArgs) Handles Returtab.Click
        openRetur()
    End Sub

    Private Sub HutangTabBtn_Click(sender As Object, e As EventArgs) Handles HutangTabBtn.Click
        openHutang()
    End Sub

    Private Sub PiutangTabBtn_Click(sender As Object, e As EventArgs) Handles PiutangTabBtn.Click
        openPiutang()
    End Sub

    Private Sub UserTabBtn_Click(sender As Object, e As EventArgs) Handles UserTabBtn.Click
        openListUser()
    End Sub

    Private Sub tmbUserTabBtn_Click(sender As Object, e As EventArgs) Handles tmbUserTabBtn.Click
        DIalogIdentitas.ShowDialog()
        DIalogIdentitas.Dispose()
    End Sub

    Private Sub BackupTabBtn_Click(sender As Object, e As EventArgs) Handles BackupTabBtn.Click
        DialogBackup.ShowDialog()
        DIalogIdentitas.Dispose()
    End Sub

    Private Sub RestoreTabBtn_Click(sender As Object, e As EventArgs) Handles RestoreTabBtn.Click
        DialogRestore.ShowDialog()
        DialogRestore.Dispose()
    End Sub

    Private Sub ResetTabBtn_Click(sender As Object, e As EventArgs) Handles ResetTabBtn.Click
        DialogReset.ShowDialog()
        DialogReset.Dispose()
    End Sub

    Private Sub RibbonButton1_Click(sender As Object, e As EventArgs) Handles RibbonButton1.Click
        PreviewReport.ShowDialog()
        PreviewReport.Dispose()
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        SplashScreen.Close()
    End Sub

    Private Sub ReturBeliTabBtn_Click(sender As Object, e As EventArgs) Handles ReturBeliTabBtn.Click
        openReturBeli()
    End Sub

    Private Sub DaftarOpname_Click(sender As Object, e As EventArgs) Handles DaftarOpname.Click
        openOpname()
    End Sub

    Private Sub RibbonButton11_Click(sender As Object, e As EventArgs) Handles RibbonButton11.Click
        openRefOpname()
    End Sub

    Private Sub RibbonButton3_Click(sender As Object, e As EventArgs) Handles RibbonButton3.Click
        PreviewSupplier.ShowDialog()
    End Sub

    Private Sub RibbonButton2_Click(sender As Object, e As EventArgs) Handles RibbonButton2.Click
        PreviewPelanggan.ShowDialog()
    End Sub

    Private Sub RibbonButton7_Click(sender As Object, e As EventArgs) Handles RibbonButton7.Click
        PreviewStok.ShowDialog()
    End Sub

    Private Sub RibbonButton4_Click(sender As Object, e As EventArgs) Handles RibbonButton4.Click
        LaporanPenjualan.awal()
        LaporanPenjualan.ShowDialog()
    End Sub

    Private Sub RibbonButton9_Click(sender As Object, e As EventArgs) Handles RibbonButton9.Click
        LaporanPendapatan.laporanBarangLengkap()
        LaporanPendapatan.ShowDialog()
    End Sub

    Private Sub RibbonButton6_Click(sender As Object, e As EventArgs) Handles RibbonButton6.Click
        LaporanReturJual.laporanBarangLengkap()
        LaporanReturJual.ShowDialog()
    End Sub

    Private Sub RibbonButton8_Click(sender As Object, e As EventArgs) Handles RibbonButton8.Click
        LaporanReturBeli.laporanBarangLengkap()
        LaporanReturBeli.ShowDialog()
    End Sub

    Private Sub RibbonButton10_Click(sender As Object, e As EventArgs) Handles RibbonButton10.Click
        LaporanLaba.laporanBarangLengkap()
        LaporanLaba.ShowDialog()
    End Sub

    Private Sub RibbonButton12_Click(sender As Object, e As EventArgs) Handles RibbonButton12.Click
        LaporanHutang.laporanBarangLengkap()
        LaporanHutang.ShowDialog()
    End Sub

    Private Sub RibbonButton13_Click(sender As Object, e As EventArgs) Handles RibbonButton13.Click
        LaporanPiutang.laporanBarangLengkap()
        LaporanPiutang.ShowDialog()
    End Sub

    Private Sub RibbonButton15_Click(sender As Object, e As EventArgs) Handles RibbonButton15.Click

    End Sub

    Private Sub RibbonButton5_Click(sender As Object, e As EventArgs) Handles RibbonButton5.Click
        LaporanPembelian.awal()
        LaporanPembelian.ShowDialog()
    End Sub

    Private Sub RibbonButton14_Click(sender As Object, e As EventArgs) Handles RibbonButton14.Click
        LaporanAset.awal()
        LaporanAset.ShowDialog()

        'PreviewAset.ShowDialog()
    End Sub

    '  Private Sub DaftarPembelian_Click(sender As Object, e As EventArgs) Handles DaftarPembelian.Click
    '     openListPembelian()
    ' End Sub

    Private Sub MenuRibbon_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub RibbonButton16_Click(sender As Object, e As EventArgs)
        openHistoryRetur()
    End Sub

    Private Sub RibbonButton17_Click(sender As Object, e As EventArgs)
        openHistoryReturBeli()
    End Sub


    Sub refreshMerk()

        Dim febarang As FormEditBarang = Application.OpenForms("FormEditBarang")
        If Not IsNothing(febarang) Then
            febarang.getMerk()
        End If
    End Sub


    Sub refreshKategori()

        Dim febarang As FormEditBarang = Application.OpenForms("FormEditBarang")
        If Not IsNothing(febarang) Then
            febarang.getJenis()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Header.Text = "Tanggal : " & Date.Now() + " - User :" + username + " - Cabang :" + cabang
        Dim addItemForms As MenuUtama = Application.OpenForms("MenuUtama")
        If Not IsNothing(addItemForms) Then
            addItemForms.setColor()
        End If
    End Sub

    Sub centerMe()
    End Sub

    Private Sub SupplierTab_Click(sender As Object, e As EventArgs) Handles SupplierTab.Click

        openListSupplier()
    End Sub

    Private Sub PembelianBTN_Click(sender As Object, e As EventArgs) Handles PembelianBTN.Click
        openListPembelian()
    End Sub

    Private Sub KulakanTabBtn_Click(sender As Object, e As EventArgs) Handles KulakanTabBtn.Click
        openPembelian()
    End Sub

    Private Sub ReturBeliTab_Click(sender As Object, e As EventArgs) Handles ReturBeliTab.Click
        openReturBeli()
    End Sub

    Private Sub RibbonButton16_Click_1(sender As Object, e As EventArgs) Handles RibbonButton16.Click
        openOpname()
    End Sub

    Private Sub RibbonButton17_Click_1(sender As Object, e As EventArgs) Handles RibbonButton17.Click
        openRefOpname()
    End Sub

    Private Sub RibbonButton18_Click(sender As Object, e As EventArgs) Handles RibbonButton18.Click
        PreviewReport.ShowDialog()
        PreviewReport.Dispose()
    End Sub

    Private Sub RibbonButton19_Click(sender As Object, e As EventArgs) Handles RibbonButton19.Click
        LaporanPelanggan.laporanBarangLengkap()
        LaporanPelanggan.ShowDialog()
        LaporanPelanggan.Dispose()
    End Sub

    Private Sub RibbonButton20_Click(sender As Object, e As EventArgs) Handles RibbonButton20.Click
        LaporanSupplier.laporanBarangLengkap()
        LaporanSupplier.ShowDialog()
        LaporanSupplier.Dispose()
    End Sub

    Private Sub RibbonButton21_Click(sender As Object, e As EventArgs) Handles RibbonButton21.Click
        LaporanStok.laporanBarangLengkap()
        LaporanStok.ShowDialog()
        LaporanStok.Dispose()
    End Sub

    Private Sub RibbonButton22_Click(sender As Object, e As EventArgs) Handles RibbonButton22.Click
        openListUser()
    End Sub

    Private Sub RibbonButton23_Click(sender As Object, e As EventArgs) Handles RibbonButton23.Click
        DIalogIdentitas.ShowDialog()
        DIalogIdentitas.Dispose()
    End Sub

    Private Sub RibbonButton24_Click(sender As Object, e As EventArgs) Handles RibbonButton24.Click
        openListGroup()
    End Sub

    Private Sub RibbonOrbMenuItem7_Click(sender As Object, e As EventArgs) Handles RibbonOrbMenuItem7.Click
        logout()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim dr As DialogResult = MessageBox.Show("Apakah anda yakin ingin keluar dari aplikasi", "Keluar Aplikasi",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If dr = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub


    Private Sub RibbonButton26_Click(sender As Object, e As EventArgs) Handles RibbonButton26.Click
        LaporanSupplierPiutang.laporanBarangLengkap()
        LaporanSupplierPiutang.ShowDialog()
        LaporanSupplierPiutang.Dispose()
    End Sub

    Private Sub RibbonButton25_Click(sender As Object, e As EventArgs) Handles RibbonButton25.Click
        LaporanPelangganHutang.laporanBarangLengkap()
        LaporanPelangganHutang.ShowDialog()
        LaporanPelangganHutang.Dispose()
    End Sub

    Private Sub RibbonButton27_Click(sender As Object, e As EventArgs) Handles RibbonButton27.Click
        LaporanLaku.laporanBarangLengkap()
        LaporanLaku.ShowDialog()
        LaporanLaku.Dispose()
    End Sub

    Private Sub RibbonButton28_Click(sender As Object, e As EventArgs) Handles RibbonButton28.Click

        LaporanBarang.awal()
        LaporanBarang.ShowDialog()
        LaporanBarang.Dispose()
    End Sub

    Private Sub RibbonButton29_Click(sender As Object, e As EventArgs) Handles RibbonButton29.Click
        LihatHarga.getDataProduk()
        LihatHarga.ShowDialog()
        LihatHarga.Dispose()
    End Sub

    Private Sub RibbonButton31_Click(sender As Object, e As EventArgs) Handles RibbonButton31.Click

        Dim import As New ImportSupplier
        import.ShowDialog()
    End Sub

    Private Sub RibbonButton32_Click(sender As Object, e As EventArgs) Handles RibbonButton32.Click

        Dim import As New ImportPelanggan
        import.ShowDialog()
    End Sub

    Private Sub RibbonButton33_Click(sender As Object, e As EventArgs) Handles RibbonButton33.Click
        Help.ShowHelp(ParentForm, Application.StartupPath & "/Bantuan.chm")
    End Sub

    Private Sub RibbonButton34_Click(sender As Object, e As EventArgs) Handles RibbonButton34.Click
        Dim hub As New HubungiKami
        hub.ShowDialog()
    End Sub

    Private Sub RibbonButton30_Click(sender As Object, e As EventArgs) Handles RibbonButton30.Click

        Dim import As New ImportItem
        import.ShowDialog()
    End Sub

    Private Sub CabangTab_Click(sender As Object, e As EventArgs) Handles CabangTab.Click
        Datagridcabang.ShowDialog()
        Datagridcabang.Dispose()
    End Sub

    Private Sub DaftarDokterBTN_Click(sender As Object, e As EventArgs) Handles DaftarDokterBTN.Click
        DatagridDokter.ShowDialog()
        DatagridDokter.Dispose()
    End Sub

    Private Sub RibbonButton35_DoubleClick(sender As Object, e As EventArgs) Handles RibbonButton35.Click
        LaporanRekomDokter.ShowDialog()
        LaporanRekomDokter.Dispose()
    End Sub

    Private Sub RibbonButton36_Click(sender As Object, e As EventArgs) Handles RibbonButton36.Click
        LaporanOrderDokter.ShowDialog()
        LaporanOrderDokter.Dispose()
    End Sub

    Private Sub RibbonButton37_Click(sender As Object, e As EventArgs) Handles RibbonButton37.Click
        LaporanDetailDokter.ShowDialog()
        LaporanDetailDokter.Dispose()
    End Sub

    Private Sub lapTeknisi_Click(sender As Object, e As EventArgs) Handles lapTeknisi.Click
        LaporanSupplier.tipe = 1
        LaporanSupplier.laporanBarangLengkap()
        LaporanSupplier.ShowDialog()
        LaporanSupplier.Dispose()
    End Sub

    Private Sub impJasa_Click(sender As Object, e As EventArgs) Handles impJasa.Click

        Dim import As New ImportItem
        import.tipe = 1
        import.ShowDialog()
    End Sub

    Private Sub RibbonButton38_Click(sender As Object, e As EventArgs) Handles RibbonButton38.Click

        Dim import As New ImportSupplier
        import.tipe = 1
        import.ShowDialog()
    End Sub

    Private Sub RibbonButton39_Click(sender As Object, e As EventArgs) Handles RibbonButton39.Click

        DatagridBarang.Text = "Daftar Jasa"
        DatagridBarang.ShowDialog()
        DatagridBarang.Dispose()
    End Sub
End Class
