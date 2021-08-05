
Module QueryModule
    Function operationQuery(query As String, value As String()) As Boolean
        Dim newquery As String = ""
        Dim array As String() = query.Split("?")
        MsgBox(array.Length)
        MsgBox(value.Length)
        If array.Count = value.Count + 1 Then
            For a As Integer = 0 To value.Count - 1
                If value(a) = "NULL" Then
                    newquery = newquery & array(a) & value(a)
                Else
                    newquery = newquery & array(a) & "'" & value(a) & "'"
                End If

            Next
        End If

        newquery &= array(array.Count - 1)

        Debug.WriteLine(newquery)
        Return exc(newquery)
    End Function

    Function operationQueryString(query As String, value As String()) As String
        Dim newquery As String = ""
        Dim array As String() = query.Split("?")

        If array.Count = value.Count + 1 Then
            For a As Integer = 0 To value.Count - 1
                If value(a) = "NULL" Then
                    newquery = newquery & array(a) & value(a)
                Else
                    newquery = newquery & array(a) & "'" & value(a) & "'"
                End If
            Next
        End If

        newquery &= array(array.Count - 1)

        Return newquery
    End Function


    Function excQuery(query As String, value As String()) As Boolean
        Dim newquery As String = ""
        Dim array As String() = query.Split("?")

        If array.Count = value.Count + 1 Then
            For a As Integer = 0 To value.Count - 1
                Dim hasil = value(a)
                If Not Double.TryParse(hasil, 0) Then
                    hasil = "'" & value(a) & "'"
                End If
                newquery = newquery & array(a) & hasil

            Next
        End If

        newquery &= array(array.Count - 1)

        Debug.WriteLine(newquery)
        Return exc(newquery)
    End Function

    Function selectQuery(table As String, Optional colum As String = "*") As String
        Return "SELECT " & colum & " FROM " & table
    End Function
End Module
