Public Class BasePOSForm
    Inherits Form

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Me.AutoScaleMode = AutoScaleMode.None
        Me.AutoSize = False

        If Me.MdiParent IsNot Nothing Then
            Me.Dock = DockStyle.Fill
        End If

        'ApplySafeResponsive(Me)

    End Sub

    Private Sub ApplySafeResponsive(parent As Control)

        For Each ctrl As Control In parent.Controls

            ' Only stretch main outer panel
            If TypeOf ctrl Is Panel AndAlso ctrl.Dock <> DockStyle.Fill Then
                ctrl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            End If

        Next

    End Sub

End Class

'Public Class BasePOSForm
'    Inherits Form

'    Protected Overrides Sub OnLoad(e As EventArgs)
'        MyBase.OnLoad(e)

'        Me.AutoScaleMode = AutoScaleMode.None
'        Me.AutoSize = False

'        ' If MDI child → fill parent
'        If Me.MdiParent IsNot Nothing Then
'            Me.Dock = DockStyle.Fill
'        End If

'        ' Stretch main background panel automatically
'        StretchMainContainer(Me)

'    End Sub

'    Private Sub StretchMainContainer(parent As Control)

'        For Each ctrl As Control In parent.Controls

'            ' Only stretch biggest outer panel
'            If TypeOf ctrl Is Panel Then
'                ctrl.Dock = DockStyle.Fill
'                Exit For
'            End If

'        Next

'    End Sub

'End Class

'Public Class BasePOSForm
'    Inherits Form

'    Protected Overrides Sub OnLoad(e As EventArgs)
'        MyBase.OnLoad(e)

'        Me.AutoScaleMode = AutoScaleMode.None
'        Me.AutoSize = False

'        If Me.MdiParent IsNot Nothing Then
'            Me.Dock = DockStyle.Fill
'        End If

'        LayoutManager.ApplyResponsiveLayout(Me)

'    End Sub

'End Class

'Public Class BasePOSForm
'    Inherits Form

'    Protected Overrides Sub OnLoad(e As EventArgs)
'        MyBase.OnLoad(e)

'        ' Important
'        Me.AutoScaleMode = AutoScaleMode.None
'        Me.AutoSize = False

'        ' Stretch inside MDI
'        If Me.MdiParent IsNot Nothing Then
'            Me.Dock = DockStyle.Fill
'        End If

'        FixMainContainer()

'    End Sub

'    Private Sub FixMainContainer()

'        ' Find biggest panel (Main container)
'        Dim mainPanel As Panel = Nothing

'        For Each ctrl As Control In Me.Controls
'            If TypeOf ctrl Is Panel Then
'                mainPanel = DirectCast(ctrl, Panel)
'                Exit For
'            End If
'        Next

'        If mainPanel IsNot Nothing Then
'            mainPanel.Dock = DockStyle.Fill
'            mainPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
'        End If

'    End Sub

'    Private Sub FixDockLayout(parent As Control)

'        For Each ctrl As Control In parent.Controls

'            ' Skip status strip
'            If TypeOf ctrl Is StatusStrip Then Continue For

'            ' If panel → stretch it
'            If TypeOf ctrl Is Panel Then
'                ctrl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
'            End If

'            ' If DataGridView → fill parent panel
'            If TypeOf ctrl Is DataGridView Then
'                ctrl.Dock = DockStyle.Fill
'            End If

'            ' Recursive
'            If ctrl.HasChildren Then
'                FixDockLayout(ctrl)
'            End If

'        Next

'    End Sub

'End Class

