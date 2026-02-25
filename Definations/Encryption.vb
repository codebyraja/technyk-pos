Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Xml

Module Encryption

    Public Sub ReadConfigurations()
        ApplicationStartupPath = Application.StartupPath
        Dim xml_file As String = ApplicationStartupPath & "\config.xml"
        Dim doc As New XmlDocument()
        doc.Load(xml_file)
        Try
            Dim nodes As XmlNodeList = doc.DocumentElement.SelectNodes("/CONNECTION")
            For Each node As XmlNode In nodes
                SQLServerName = node.SelectSingleNode("SERVER").InnerText
                SQLServerDatabase = node.SelectSingleNode("DATABASE").InnerText
                SQLServerUserName = node.SelectSingleNode("USERID").InnerText
                SQLServerPassword = (node.SelectSingleNode("PASSWORD").InnerText)
                DEFAULT_LOGIN_ID = node.SelectSingleNode("DEFAULT_LOGIN_ID").InnerText
                DEFAULT_LOGIN_PASSWORD = node.SelectSingleNode("DEFAULT_LOGIN_PWD").InnerText
                LOGINTYPE = node.SelectSingleNode("LOGIN_TYPE").InnerText
            Next
            ConnectionStr = "data source=" & SQLServerName & "; initial catalog=" & SQLServerDatabase & "; user id=" & SQLServerUserName & "; password=" & SQLServerPassword & ""

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

End Module
