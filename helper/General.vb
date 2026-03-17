Public Class General

    Public Shared Sub Close(frm As Form)

        frm.Close()

        Dim mainForm As FrmFNBManagement =
            CType(Application.OpenForms("FrmFNBManagement"), FrmFNBManagement)

        If mainForm IsNot Nothing Then
            mainForm.ShowDashboard()
        End If

    End Sub

    Public Shared Sub ShowModalPanel(pnl As Panel, Optional overlay As Panel = Nothing)

        If pnl Is Nothing Then Exit Sub
        If pnl.Parent Is Nothing Then Exit Sub

        If overlay IsNot Nothing Then overlay.Visible = True
        If overlay IsNot Nothing Then overlay.BringToFront()

        pnl.Visible = True
        pnl.BringToFront()

        pnl.Left = (pnl.Parent.Width - pnl.Width) \ 2
        pnl.Top = (pnl.Parent.Height - pnl.Height) \ 2

    End Sub

    Public Shared Sub HideModalPanel(pnl As Panel, Optional overlay As Panel = Nothing)

        If pnl IsNot Nothing Then pnl.Visible = False
        If overlay IsNot Nothing Then overlay.Visible = False

    End Sub


    'Public Sub ShowMergeScreen()

    '    ' Hide normal content (left + right)
    '    PanelContentHost.Visible = False

    '    ' Hide other overlays (optional safety)
    '    PanelModifiers.Visible = False
    '    PanelSearchItem.Visible = False
    '    PanelClosedBills.Visible = False

    '    ' Show merge panel
    '    PanelMergeTables.Visible = True
    '    PanelMergeTables.BringToFront()

    'End Sub

    'Public Sub ShowBillingScreen()

    '    PanelMergeTables.Visible = False

    '    ' Show normal billing layout
    '    PanelContentHost.Visible = True
    '    PanelContentHost.BringToFront()

    'End Sub

End Class