Imports System.ComponentModel
Imports Microsoft.Reporting.WinForms

Public Class DialogTransaksiBayar
    Public grandtotalResult As Double
    Public total As Double
    Public totalpajak As Double
    Public diskonPersen As Double
    Public diskonRupiah As Double
    Public biayaLain As Double
    Public kasBiayaLain As String
    Public nomerDokumen As String = ""
    Public tglDokumen As String = ""
    Public refrensi As String = ""
    Public tableRefrensi As String = ""
    Public keyRefrensi As String = ""
    Public kasDiskon As String

    Public bayar As Double
    Public kasPenerimaaan As String = ""
    Dim onEdited As Boolean = False

    Dim onEditCurrency As Boolean = False

    Sub awal()

        tbTotal.Text = numberFormat(total.ToString)
        tbPajak.Text = numberFormat(totalpajak.ToString)
        TBDiskon.Text = "0"
        TBPotongan.Text = "0"
        tbBiayaLain.Text = "0"
        diskonNominal.Checked = True
        panelDokumen.Enabled = checkDokumen.Checked
        setAkun()
        setAkunDiskon()
        setGrandTotal()
        setAkunPenerimaan()

        If Not String.IsNullOrEmpty(refrensi) Then
            Dim sqlorder As String = "select nomerdokumen, biayalain, diskonpersen, diskonrupiah, nomerdokumen, tgldokumen, kasdiskon, kasbiayalain from " & tableRefrensi & " where " & keyRefrensi & "='" & refrensi & "'"
            If getCount(sqlorder) > 0 Then
                TBNoDokumen.Text = getValue(sqlorder, "nomerdokumen")
                tbBiayaLain.Text = numberFormat(getValue(sqlorder, "biayalain"))
                TBDiskon.Text = getValue(sqlorder, "diskonpersen")
                Dim potongan As Double = total * (toDouble(unnumberFormat(TBDiskon.Text))) / 100
                TBPotongan.Text = numberFormat(potongan)
                TBNoDokumen.Text = getValue(sqlorder, "nomerdokumen")
                dtDokumen.Value = getValue(sqlorder, "tgldokumen")
                cbAkunDiskon.SelectedValue = getValue(sqlorder, "kasdiskon")
                cbKasBiayaLain.SelectedValue = getValue(sqlorder, "kasbiayalain")
            End If
        End If
    End Sub

    Sub setGrandTotal()
        Dim grandTotal As Double = ((total + totalpajak) * (100 - toDouble(TBDiskon.Text)) / 100) + toDouble(unnumberFormat(tbBiayaLain.Text))
        tbTotal.Text = numberFormat((total * (100 - toDouble(TBDiskon.Text)) / 100).ToString)
        tbPajak.Text = numberFormat((totalpajak * (100 - toDouble(TBDiskon.Text)) / 100).ToString)
        tbGrand.Text = numberFormat(grandTotal.ToString)
        If cbLunas.Checked Then
            tbBayar.Text = tbGrand.Text
        End If
    End Sub

    Private Sub DialogTransaksiTanpaBayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub


    Sub setAkun()
        cbKasBiayaLain.DataSource = getData("select kodeakun, akun from tblakun")
        cbKasBiayaLain.ValueMember = "kodeakun"
        cbKasBiayaLain.DisplayMember = "akun"
        cbKasBiayaLain.SelectedIndex = 0
    End Sub

    Sub setAkunDiskon()
        cbAkunDiskon.DataSource = getData("select kodeakun, akun from tblakun")
        cbAkunDiskon.ValueMember = "kodeakun"
        cbAkunDiskon.DisplayMember = "akun"
        cbAkunDiskon.SelectedIndex = 0
    End Sub

    Sub setAkunPenerimaan()
        cbAkunTerima.DataSource = getData("select kodeakun, akun from tblakun")
        cbAkunTerima.ValueMember = "kodeakun"
        cbAkunTerima.DisplayMember = "akun"
        cbAkunTerima.SelectedIndex = 0
    End Sub


    Private Sub checkDokumen_CheckedChanged(sender As Object, e As EventArgs) Handles checkDokumen.CheckedChanged
        TBNoDokumen.Text = ""
        panelDokumen.Enabled = checkDokumen.Checked
    End Sub

    Private Sub diskonNominal_CheckedChanged(sender As Object, e As EventArgs) Handles diskonNominal.CheckedChanged
        If Not diskonNominal.Checked Then
            TBPotongan.ReadOnly = True
            TBDiskon.ReadOnly = False
        Else
            TBDiskon.ReadOnly = True
            TBPotongan.ReadOnly = False
        End If
    End Sub

    Private Sub TBDiskon_TextChanged(sender As Object, e As EventArgs) Handles TBDiskon.TextChanged
        If Not onEdited And Not diskonNominal.Checked Then
            onEdited = True

            Dim potongan As Double = total * (toDouble(unnumberFormat(TBDiskon.Text))) / 100
            TBPotongan.Text = potongan.ToString
            setGrandTotal()
            onEdited = False
        End If
    End Sub

    Private Sub TBPotongan_TextChanged(sender As Object, e As EventArgs) Handles TBPotongan.TextChanged
        If Not onEdited And diskonNominal.Checked Then
            onEdited = True
            If toDouble(unnumberFormat(TBPotongan.Text)) = 0 Then
                TBDiskon.Text = "0"
            Else
                Dim potongan As Double = toDouble(unnumberFormat(TBPotongan.Text)) / total * 100
                TBDiskon.Text = Math.Round(potongan).ToString
            End If
            setGrandTotal()
            onEdited = False
        End If


        If Not onEditCurrency Then
            onEditCurrency = True
            TBPotongan.Text = numberFormat(TBPotongan.Text)
            TBPotongan.SelectionStart = TBPotongan.Text.Count
            TBPotongan.SelectionLength = 0
            onEditCurrency = False
        End If
    End Sub

    Private Sub tbBiayaLain_TextChanged(sender As Object, e As EventArgs) Handles tbBiayaLain.TextChanged
        If Not onEdited Then
            onEdited = True
            setGrandTotal()
            onEdited = False
        End If
        If Not onEditCurrency Then
            onEditCurrency = True
            tbBiayaLain.Text = numberFormat(tbBiayaLain.Text)
            tbBiayaLain.SelectionStart = tbBiayaLain.Text.Count
            tbBiayaLain.SelectionLength = 0
            onEditCurrency = False
        End If
    End Sub

    Private Sub tbBayar_TextChanged(sender As Object, e As EventArgs) Handles tbBayar.TextChanged
        If Not onEditCurrency Then
            onEditCurrency = True
            tbBayar.Text = numberFormat(tbBayar.Text)
            tbBayar.SelectionStart = tbBayar.Text.Count
            tbBayar.SelectionLength = 0
            onEditCurrency = False
        End If
    End Sub

    Private Sub TBPotongan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBPotongan.KeyPress, tbBiayaLain.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub btnCariAkun_Click(sender As Object, e As EventArgs) Handles btnCariAkun.Click
        Dim dialog As New DialogAkun
        If dialog.ShowDialog = DialogResult.OK Then
            cbKasBiayaLain.SelectedValue = dialog.idakun
        End If
        dialog.Dispose()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If toDouble(TBDiskon.Text) < 0 Or toDouble(TBDiskon.Text) > 100 Then
            dialogError("Masukkan jumlah diskon dengan benar")
            Return
        End If
        If dialog("Apakah anda yakin untuk menyimpan data ini ?") Then
            grandtotalResult = toDouble(unnumberFormat(tbGrand.Text))
            diskonPersen = toDouble(TBDiskon.Text)
            diskonRupiah = toDouble(unnumberFormat(TBPotongan.Text))
            biayaLain = toDouble(unnumberFormat(tbBiayaLain.Text))
            kasBiayaLain = cbKasBiayaLain.SelectedValue
            kasDiskon = cbAkunDiskon.SelectedValue
            nomerDokumen = TBNoDokumen.Text
            tglDokumen = dtDokumen.Value.ToString("yyyy-MM-dd")
            totalpajak = toDouble(unnumberFormat(tbPajak.Text.ToString))
            total = toDouble(unnumberFormat(tbTotal.Text.ToString))
            bayar = toDouble(unnumberFormat(tbBayar.Text))
            kasPenerimaaan = cbAkunTerima.SelectedValue
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialog As New DialogAkun
        If dialog.ShowDialog = DialogResult.OK Then
            cbAkunDiskon.SelectedValue = dialog.idakun
        End If
        dialog.Dispose()
    End Sub

    Private Sub cbLunas_CheckedChanged(sender As Object, e As EventArgs) Handles cbLunas.CheckedChanged
        tbBayar.Enabled = Not cbLunas.Checked
        If cbLunas.Checked Then
            tbBayar.Text = tbGrand.Text
        Else
            tbBayar.Text = "0"
        End If
    End Sub

    Private Sub btnCariAkunTerima_Click(sender As Object, e As EventArgs) Handles btnCariAkunTerima.Click
        Dim dialog As New DialogAkun
        If dialog.ShowDialog = DialogResult.OK Then
            cbAkunTerima.SelectedValue = dialog.idakun
        End If
        dialog.Dispose()
    End Sub
End Class

