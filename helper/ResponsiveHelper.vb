Imports System.Drawing
Imports System.Windows.Forms

Public Class ResponsiveHelper

    Private baseWidth As Integer
    Private baseHeight As Integer

    Private originalBounds As New Dictionary(Of Control, Rectangle)
    Private originalFonts As New Dictionary(Of Control, Single)

    Public Sub New(frm As Form)
        baseWidth = frm.ClientSize.Width
        baseHeight = frm.ClientSize.Height
        StoreControls(frm)
    End Sub

    Private Sub StoreControls(parent As Control)
        For Each ctrl As Control In parent.Controls

            originalBounds(ctrl) = ctrl.Bounds
            originalFonts(ctrl) = ctrl.Font.Size

            If ctrl.HasChildren Then
                StoreControls(ctrl)
            End If
        Next
    End Sub

    Public Sub ResizeControls(frm As Form)

        If baseWidth = 0 Or baseHeight = 0 Then Exit Sub

        Dim scaleX As Double = frm.ClientSize.Width / baseWidth
        Dim scaleY As Double = frm.ClientSize.Height / baseHeight
        Dim fontScale As Double = (scaleX + scaleY) / 2

        For Each ctrl In originalBounds.Keys

            If ctrl Is Nothing OrElse ctrl.IsDisposed Then Continue For

            Dim rect = originalBounds(ctrl)

            ctrl.Left = CInt(rect.Left * scaleX)
            ctrl.Top = CInt(rect.Top * scaleY)
            ctrl.Width = CInt(rect.Width * scaleX)
            ctrl.Height = CInt(rect.Height * scaleY)

            ctrl.Font = New Font(ctrl.Font.FontFamily,
                                 CSng(originalFonts(ctrl) * fontScale),
                                 ctrl.Font.Style)

            If TypeOf ctrl Is DataGridView Then
                ScaleGridColumns(DirectCast(ctrl, DataGridView), scaleX)
            End If
        Next

    End Sub

    Private Sub ScaleGridColumns(dgv As DataGridView, scaleX As Double)

        For Each col As DataGridViewColumn In dgv.Columns
            If col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None Then
                col.Width = CInt(col.Width * scaleX)
            End If
        Next

    End Sub
End Class