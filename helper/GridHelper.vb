Imports System.Windows.Forms

Public Class GridHelper

    Public Shared Sub FormatEnquiryGrid(ByVal dgv As DataGridView, Optional ByVal frozenColumnIndex As Integer = 0)

        If dgv Is Nothing Then Exit Sub
        If dgv.Columns.Count = 0 Then Exit Sub

        ' General styling
        dgv.AutoGenerateColumns = False
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False
        dgv.RowHeadersVisible = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' Frozen column handling
        If frozenColumnIndex >= 0 AndAlso frozenColumnIndex < dgv.Columns.Count Then
            dgv.Columns(frozenColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgv.Columns(frozenColumnIndex).Width = 40
            dgv.Columns(frozenColumnIndex).Frozen = True
        End If

        ' Remaining columns fill
        For i As Integer = 0 To dgv.Columns.Count - 1
            If i <> frozenColumnIndex AndAlso dgv.Columns(i).Visible Then
                dgv.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        Next

    End Sub

End Class