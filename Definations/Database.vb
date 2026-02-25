Imports System.Data.SqlClient
Public Class database
    Public con As SqlConnection
    Private comm As SqlCommand
    Private dr As SqlDataReader
    Public da As SqlDataAdapter
    Private ds As New DataSet
    
    Public Sub ConnectDatabse()
        Dim str As String
        str = "data source=" & SQLServerName & "; initial catalog=" & SQLServerDatabase & "; user id=" & SQLServerUserName & "; password=" & SQLServerPassword & ""
        con = New SqlConnection(str)
    End Sub

    Public Sub OpenDatabaseConnection()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
    End Sub

    Public Sub CloseDatabaseConnection()
        con.Close()
    End Sub

    Public Function DataReaderData(ByVal value As String) As SqlDataReader
        Try
            ConnectDatabse()
            comm = New SqlCommand
            comm.CommandText = value
            comm.Connection = con
            con.Open()
            dr = comm.ExecuteReader
            Return dr
        Catch es As SqlException
            MsgBox(es.Message, MsgBoxStyle.OkOnly, "INFORMATION")
        Catch ee As System.Exception
            MsgBox(ee.Message, MsgBoxStyle.OkOnly, "INFORMATION")
        Finally
        End Try
    End Function

    Public Function ExecuteScalar(ByVal value As String) As String
        Try
            Dim ReturnValue As String = ""
            comm = New SqlCommand
            comm.CommandText = value
            comm.Connection = con
            OpenDatabaseConnection()
            ReturnValue = comm.ExecuteScalar
            Return ReturnValue
        Catch ee As System.Exception
            MsgBox(ee.Message)
        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function BindDataSet(ByVal strsql As String, ByVal table_name As String) As DataSet
        Try
            ConnectDatabse()
            OpenDatabaseConnection()
            ds = New DataSet
            da = New SqlDataAdapter(strsql, con)
            da.SelectCommand.CommandTimeout = 50000
            da.Fill(ds, table_name)
            Return ds
        Catch ex As System.Exception
        Finally
            If con.State = ConnectionState.Open Then
                CloseDatabaseConnection()
            End If
        End Try
    End Function

    Public Function ExecuteNonQuery(ByVal strsql As String)
        Try
            comm = New SqlCommand
            comm.CommandText = strsql
            comm.Connection = con
            OpenDatabaseConnection()
            comm.ExecuteNonQuery()
        Catch ex As System.Exception
        Finally
            If con.State = ConnectionState.Open Then
                CloseDatabaseConnection()
            End If
        End Try
    End Function

    Public Function ExecuteScalarS(ByVal SQLQry As String) As String
        Dim ReturnValue As String = ""
        Try
            comm = New SqlCommand
            comm.CommandText = SQLQry
            comm.Connection = con
            comm.CommandTimeout = 5000
            OpenDatabaseConnection()
            dr = comm.ExecuteReader
            If (dr.Read()) Then
                ReturnValue = dr(0)
            Else
                ReturnValue = ""
            End If
        Catch dd As System.Exception
            MsgBox(dd.Message)
        Finally
            CloseDatabaseConnection()
        End Try
        Return ReturnValue
    End Function

    Public Function ExecuteScalarString(ByVal SQLQry As String) As String
        Dim ReturnValue As String = ""
        Try
            comm = New SqlCommand
            comm.CommandText = SQLQry
            comm.Connection = con
            comm.CommandTimeout = 5000
            OpenDatabaseConnection()
            dr = comm.ExecuteReader
            If (dr.Read()) Then
                ReturnValue = dr(0)
            Else
                ReturnValue = 0
            End If
        Catch dd As System.Exception
            MsgBox(dd.Message)
        Finally
            CloseDatabaseConnection()
        End Try
        Return ReturnValue
    End Function

    Public Function ExecuteScalarN(ByVal SQLQry As String) As Double
        Dim ReturnValue As Double = 0
        Try
            comm = New SqlCommand
            comm.CommandText = SQLQry
            comm.Connection = con
            comm.CommandTimeout = 5000
            OpenDatabaseConnection()
            dr = comm.ExecuteReader
            If (dr.Read()) Then
                ReturnValue = dr(0)
            Else
                ReturnValue = 0
            End If
        Catch dd As System.Exception
            MsgBox(dd.Message)
        Finally
            CloseDatabaseConnection()
        End Try
        Return ReturnValue
    End Function

End Class