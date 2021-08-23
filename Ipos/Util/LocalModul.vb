Imports System.Data.OleDb

Module LocalModul
    Dim conn As OleDbConnection
    Dim dt As DataTable
    Dim da As OleDbDataAdapter
    Dim cmd As OleDbCommand


    Public Sub localKoneksi()
        Try
            If IsNothing(conn) Then
                Dim QUERY = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath &
                            "\TOKOASLI.mdb" &
                            ";Jet OLEDB:Database Password=itbrain1milyar;"
                conn = New OleDbConnection(QUERY)
            End If
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function getLocalData(sql As String)
        localKoneksi()
        Try
            da = New OleDbDataAdapter(sql, conn)
            dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Return New DataTable
        Finally
            conn.Close()
            da.Dispose()
            dt.Dispose()
        End Try
    End Function

    Public Function exclocal(sql As String)
        localKoneksi()

        Try
            cmd = New OleDbCommand(sql, conn)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
            cmd.Dispose()

        End Try
    End Function


    Public Function getLocalValue(sql As String, col As String)
        Dim table As DataTable = getLocalData(sql)
        If Not IsNothing(table) Then
            If table.Rows.Count = 0 Then
                Return ""
            Else
                Return table.Rows(0).Item(col)
            End If
        Else
            Return ""
        End If
    End Function

    Public Function getLocalCount(sql As String)
        Dim table As DataTable = getLocalData(sql)
        If Not IsNothing(table) Then
            Return table.Rows.Count

        Else
            Return 0
        End If
    End Function
End Module
