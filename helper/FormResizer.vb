Imports System.Windows.Forms
Imports System.Drawing

Public Class ResolutionResizer

    Private DesignWidth As Integer
    Private DesignHeight As Integer

    Private OriginalBounds As New Dictionary(Of Control, Rectangle)
    Private OriginalFontSize As New Dictionary(Of Control, Single)

    Public Sub New(designW As Integer, designH As Integer)
        DesignWidth = designW
        DesignHeight = designH
    End Sub

    Public Sub RegisterForm(frm As Form)
        StoreControls(frm)
    End Sub

    Private Sub StoreControls(parent As Control)
        For Each ctrl As Control In parent.Controls

            OriginalBounds(ctrl) = ctrl.Bounds
            OriginalFontSize(ctrl) = ctrl.Font.Size

            If ctrl.HasChildren Then
                StoreControls(ctrl)
            End If
        Next
    End Sub

    Public Sub ResizeToScreen(frm As Form)

        Dim workingArea = Screen.PrimaryScreen.WorkingArea

        Dim scaleX As Double = workingArea.Width / DesignWidth
        Dim scaleY As Double = workingArea.Height / DesignHeight

        frm.Bounds = workingArea

        For Each ctrl In OriginalBounds.Keys

            Dim r = OriginalBounds(ctrl)

            ctrl.Left = CInt(r.Left * scaleX)
            ctrl.Top = CInt(r.Top * scaleY)
            ctrl.Width = CInt(r.Width * scaleX)
            ctrl.Height = CInt(r.Height * scaleY)

            ctrl.Font = New Font(ctrl.Font.FontFamily,
                                 CSng(OriginalFontSize(ctrl) * ((scaleX + scaleY) / 2)),
                                 ctrl.Font.Style)

            ' DataGridView handling (VB6 MSFlexGrid equivalent)
            If TypeOf ctrl Is DataGridView Then
                Dim dgv As DataGridView = CType(ctrl, DataGridView)

                For Each col As DataGridViewColumn In dgv.Columns
                    col.Width = CInt(col.Width * scaleX)
                Next
            End If

        Next

    End Sub

End Class

'Imports System.Windows.Forms
'Imports System.Drawing

'Public Class FormResizer

'    Private _originalFormSize As Size
'    Private _controlsInfo As New Dictionary(Of Control, ControlInfo)

'    Private Class ControlInfo
'        Public Property OriginalBounds As Rectangle
'        Public Property OriginalFontSize As Single
'    End Class

'    ' Register once in Form Load
'    Public Sub Register(form As Form)

'        _originalFormSize = form.ClientSize

'        _controlsInfo.Clear()
'        RegisterControls(form)

'    End Sub

'    Private Sub RegisterControls(parent As Control)

'        For Each ctrl As Control In parent.Controls

'            Dim info As New ControlInfo With {
'                .OriginalBounds = ctrl.Bounds,
'                .OriginalFontSize = ctrl.Font.Size
'            }

'            _controlsInfo(ctrl) = info

'            If ctrl.HasChildren Then
'                RegisterControls(ctrl)
'            End If
'        Next

'    End Sub

'    ' Call in Form Resize Event
'    Public Sub Resize(form As Form)

'        If _originalFormSize.Width = 0 OrElse _originalFormSize.Height = 0 Then Exit Sub

'        Dim xRatio As Double = form.ClientSize.Width / _originalFormSize.Width
'        Dim yRatio As Double = form.ClientSize.Height / _originalFormSize.Height

'        For Each kvp In _controlsInfo

'            Dim ctrl As Control = kvp.Key
'            Dim info As ControlInfo = kvp.Value

'            Dim newX As Integer = CInt(info.OriginalBounds.X * xRatio)
'            Dim newY As Integer = CInt(info.OriginalBounds.Y * yRatio)
'            Dim newWidth As Integer = CInt(info.OriginalBounds.Width * xRatio)
'            Dim newHeight As Integer = CInt(info.OriginalBounds.Height * yRatio)

'            ctrl.Bounds = New Rectangle(newX, newY, newWidth, newHeight)

'            ' Font scaling (based on height ratio)
'            Dim newFontSize As Single = CSng(info.OriginalFontSize * yRatio)

'            If newFontSize > 6 Then
'                ctrl.Font = New Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style)
'            End If

'            ' Special handling for DataGridView
'            'If TypeOf ctrl Is DataGridView Then
'            '    Dim dgv As DataGridView = CType(ctrl, DataGridView)
'            '    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
'            'End If

'            If TypeOf ctrl Is DataGridView Then

'                Dim dgv As DataGridView = CType(ctrl, DataGridView)

'                If dgv.Columns.Count > 0 Then

'                    Dim totalWidth As Integer = dgv.ClientSize.Width
'                    Dim frozenWidth As Integer = 0
'                    Dim normalColumns As New List(Of DataGridViewColumn)

'                    For Each col As DataGridViewColumn In dgv.Columns
'                        If col.Visible Then
'                            If col.Frozen Then
'                                frozenWidth += col.Width
'                            Else
'                                normalColumns.Add(col)
'                            End If
'                        End If
'                    Next

'                    If normalColumns.Count > 0 Then
'                        Dim remainingWidth As Integer = totalWidth - frozenWidth
'                        Dim perColumnWidth As Integer = remainingWidth \ normalColumns.Count

'                        For Each col In normalColumns
'                            col.Width = perColumnWidth
'                        Next
'                    End If

'                End If

'            End If
'        Next

'    End Sub

'End Class