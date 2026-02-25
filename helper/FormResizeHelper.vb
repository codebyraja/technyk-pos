Imports System.Drawing
Imports System.Windows.Forms

Public Module FormResizeHelper

    Private Structure ControlInfo
        Public Name As String
        Public Left As Integer
        Public Top As Integer
        Public Width As Integer
        Public Height As Integer
        Public FontSize As Single
    End Structure

    Private OriginalFormSize As Size
    Private ControlList As New Dictionary(Of String, ControlInfo)

    ' ==============================
    ' Call this in Form_Load
    ' ==============================
    Public Sub InitializeResize(frm As Form)

        OriginalFormSize = frm.Size
        ControlList.Clear()

        StoreControls(frm)

    End Sub

    ' ==============================
    ' Store Original Controls
    ' ==============================
    Private Sub StoreControls(ctrl As Control)

        For Each c As Control In ctrl.Controls

            Dim info As New ControlInfo
            info.Name = c.Name
            info.Left = c.Left
            info.Top = c.Top
            info.Width = c.Width
            info.Height = c.Height
            info.FontSize = c.Font.Size

            ControlList.Add(c.Name, info)

            ' Recursive for panels/groupboxes
            If c.Controls.Count > 0 Then
                StoreControls(c)
            End If

        Next

    End Sub

    ' ==============================
    ' Call this in Form_Resize
    ' ==============================
    Public Sub ResizeControls(frm As Form)

        Dim xRatio As Double = frm.Width / OriginalFormSize.Width
        Dim yRatio As Double = frm.Height / OriginalFormSize.Height

        ResizeControlRecursive(frm, xRatio, yRatio)

    End Sub

    Private Sub ResizeControlRecursive(ctrl As Control, xRatio As Double, yRatio As Double)

        For Each c As Control In ctrl.Controls

            If ControlList.ContainsKey(c.Name) Then

                Dim info = ControlList(c.Name)

                c.Left = CInt(info.Left * xRatio)
                c.Top = CInt(info.Top * yRatio)
                c.Width = CInt(info.Width * xRatio)
                c.Height = CInt(info.Height * yRatio)

                ' Resize Font
                Dim newFontSize As Single = CSng(info.FontSize * Math.Min(xRatio, yRatio))
                c.Font = New Font(c.Font.FontFamily, newFontSize, c.Font.Style)

                ' Special handling for DataGridView
                If TypeOf c Is DataGridView Then
                    Dim dgv As DataGridView = CType(c, DataGridView)
                    For Each col As DataGridViewColumn In dgv.Columns
                        col.Width = CInt(col.Width * xRatio)
                    Next
                End If

            End If

            If c.Controls.Count > 0 Then
                ResizeControlRecursive(c, xRatio, yRatio)
            End If

        Next

    End Sub

End Module