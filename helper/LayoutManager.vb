Public Class LayoutManager

    Public Shared Sub ApplyResponsiveLayout(frm As Form)

        frm.SuspendLayout()

        For Each ctrl As Control In frm.Controls
            ProcessControl(ctrl)
        Next

        frm.ResumeLayout()

    End Sub


    Private Shared Sub ProcessControl(ctrl As Control)

        ' Skip menu / status strip
        If TypeOf ctrl Is StatusStrip Or TypeOf ctrl Is MenuStrip Then
            Return
        End If

        ' Main panels stretch
        If TypeOf ctrl Is Panel Then
            ctrl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        End If

        ' Grid stretch
        If TypeOf ctrl Is DataGridView Then
            ctrl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        End If

        ' Buttons bottom detect (auto detect if near bottom)
        If TypeOf ctrl Is Button Then
            If ctrl.Top > (ctrl.Parent.Height - 120) Then
                ctrl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
            End If
        End If

        ' Recursive for child controls
        If ctrl.HasChildren Then
            For Each child As Control In ctrl.Controls
                ProcessControl(child)
            Next
        End If

    End Sub

End Class