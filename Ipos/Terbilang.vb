Public Class Terbilang
    Private ReadOnly STRANGKA As String() = {"", "satu ", "dua ", "tiga ", "empat ", "lima ",
                                             "enam ", "tujuh ", "delapan ", "sembilan "}

    Private ReadOnly STRDESIMAL As String() = {"puluh ", "ratus ", "ribu ", "juta ",
                                               "milyar ", "trilyun ", "bilyun "}

    Private m_Text As String

    Property Text As String
        Get
            Return FormatTerbilang(m_Text)
        End Get
        Set
            m_Text = value
        End Set
    End Property

    Private Function Satuan(s As String, x As Integer) As String
        On Error Resume Next
        Dim Hasil As String = ""

        Dim i As Integer = Val(s(x))

        Hasil = IIf(i = 1, "se", STRANGKA(i))

        Return Hasil
    End Function

    Private Function Puluhan(s As String, x As Integer) As String
        On Error Resume Next

        Dim Hasil As String = ""
        Dim i As Integer = Val(s(x))
        Dim j As Integer = Val(s(x + 1))

        Select Case i
            Case 0
                Hasil = STRANGKA(j)
            Case 1
                Select Case j
                    Case 0
                        Hasil = "sepuluh "
                    Case 1
                        Hasil = "sebelas "
                    Case Else
                        Hasil = STRANGKA(j)
                        Hasil = Hasil + "belas "
                End Select
            Case Else
                Hasil = STRANGKA(i)
                Hasil = Hasil + STRDESIMAL(0) + STRANGKA(j)
        End Select
        Return Hasil
    End Function

    Private Function Ratusan(s As String, x As Integer) As String
        On Error Resume Next

        Dim Hasil As String = ""
        Dim i As Integer = Val(s(x))

        Select Case i
            Case 0
                Hasil = Puluhan(s, x + 1)
            Case Else
                Hasil = IIf(i = 1, "se", STRANGKA(i))
                Hasil = Hasil + STRDESIMAL(1)
                Hasil = Hasil + Puluhan(s, x + 1)
        End Select
        Return Hasil
    End Function

    Private Function SemuaNol(s As String, x As Integer) As Boolean
        On Error Resume Next

        Dim i As Integer = Val(s(x - 1))
        Dim j As Integer = Val(s(x - 2))
        Dim k As Integer = Val(s(x - 3))

        Return ((i = 0) And (j = 0) And (k = 0))
    End Function

    Private Function FormatTerbilang(s As String) As String
        On Error Resume Next

        Dim strTemp As String = s

        If strTemp.Length = 0 Then
            Return ""
            Exit Function
        End If

        If strTemp.Length > 18 Or Not IsNumeric(strTemp) Then
            Return "Cannot convert this string."
            Exit Function
        End If

        If strTemp.IndexOf(",") > 0 Then strTemp = strTemp.Replace(",", "")

        If Not IsNumeric(strTemp.Substring(strTemp.Length - 1, 1)) Then _
            strTemp = strTemp.Substring(0, strTemp.Length - 1)

        If Not IsNumeric(strTemp.Substring(1, 1)) Then strTemp = strTemp.Substring(0, strTemp.Length - 1)

        Dim hasilCent As String = ""

        If strTemp.IndexOf(".") > 0 Then
            Dim posCent As Integer = strTemp.IndexOf(".") + 2
            Dim strCent As String = strTemp.Substring(strTemp.IndexOf(".") + 1)

            strTemp = strTemp.Substring(0, strTemp.Length - (strCent.Length + 1))

            hasilCent = IIf(strCent.Length = 1, IIf(Satuan(strCent, 0) <> "", Satuan(strCent, 0) & "sen", ""),
                            IIf(Puluhan(strCent, 0) <> "", Puluhan(strCent, 0) & "sen", ""))
        End If

        Dim Hasil As String = ""
        Dim len As Integer = strTemp.Length

        If (len = 1) Then
            If Val(strTemp(0)) = 0 Then
                Hasil = "nol "
            Else
                Hasil = STRANGKA(Val(strTemp(0)))
            End If
            Return Hasil & "rupiah"
        End If

        Dim counter As Integer = 0
        Dim sisa As Integer = len Mod 3

        Select Case sisa
            Case 2
                Hasil = Puluhan(strTemp, 0)
                counter = 2
            Case 1
                Hasil = Satuan(strTemp, 0)
                counter = 1
            Case 0
                Hasil = Ratusan(strTemp, 0)
                counter = 3
        End Select

        Dim x As Integer = IIf(sisa = 0, (len \ 3), (len \ 3) + 1)
        While (counter < len)
            If Not SemuaNol(strTemp, counter) Then Hasil = Hasil + STRDESIMAL(x)

            Select Case Mid(Hasil, 1, 4)
                Case "seju"
                    Hasil = "satu juta "
                Case "semi"
                    Hasil = "satu milyar "
                Case "setr"
                    Hasil = "satu trilyun "
                Case "sebi"
                    Hasil = "satu bilyun "
            End Select

            Hasil = Hasil + Ratusan(strTemp, counter)
            counter += 3
            x = x - 1
        End While

        Return Hasil & "rupiah " & hasilCent
    End Function
End Class