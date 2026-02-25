Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports System.Windows.Forms
Imports System.Windows.Forms.Control

Module ValidationFunctions

    Public Function EmailAddressCheck(ByVal emailAddress As String) As Boolean
        Dim pattern As String = "^[-a-zA-Z0-9][-._a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True
        Else
            EmailAddressCheck = False
        End If
    End Function

    Public Function URLAddressCheck(ByVal URLAddress As String) As Boolean
        Dim pattern As String = "^(((ht|f)tp(s?):\/\/)|(www\.[^ \[\]\(\)\n\r\t]+)|(([012]?[0-9]{1,2}\.){3}[012]?[0-9]{1,2})\/)([^ \[\]\(\),;&quot;'&lt;&gt;\n\r\t]+)([^\. \[\]\(\),;&quot;'&lt;&gt;\n\r\t])|(([012]?[0-9]{1,2}\.){3}[012]?[0-9]{1,2})$"
        Dim emailAddressMatch As Match = Regex.Match(URLAddress, pattern)
        If emailAddressMatch.Success Then
            URLAddressCheck = True
        Else
            URLAddressCheck = False
            MsgBox("Invalid Format", MsgBoxStyle.Information, "Banquet Management")
        End If
    End Function

    Public Sub ValidateWholeNumberInput(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = True
        If e.KeyChar = "-" And txt.SelectionStart = 0 Then e.Handled = False
        If e.KeyChar = Chr(13) Then
            txt.Focus()
            If e.KeyChar = Chr(13) And txt.Text = "." Then txt.Clear()
            Exit Sub
        End If
        Dim i As Integer = txt.Text.IndexOf(".")
        Dim len As Integer = txt.Text.Length
        If Not e.Handled Then
            If i = -1 Then
                e.Handled = False
            Else
                If (len - i) > 2 Then e.Handled = True
            End If
        End If
        If e.KeyChar = Chr(8) Then e.Handled = False
    End Sub

    Public Sub ValidateDecimalInput(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
        If e.KeyChar = "-" And txt.SelectionStart = 0 Then e.Handled = False
        If e.KeyChar = Chr(13) Then
            txt.Focus()
            If e.KeyChar = Chr(13) And txt.Text = "." Then txt.Clear()
            Exit Sub
        End If
        Dim i As Integer = txt.Text.IndexOf(".")
        Dim len As Integer = txt.Text.Length
        If Not e.Handled Then
            If i = -1 Then
                e.Handled = False
            Else
                If (len - i) > 2 Then e.Handled = True
            End If
        End If
        If e.KeyChar = Chr(8) Then e.Handled = False
    End Sub

End Module
