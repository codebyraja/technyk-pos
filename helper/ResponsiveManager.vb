Public Module ResponsiveManager

    Public Sub ApplyResponsiveLayout(frm As Form, responsive As ResponsiveHelper)

        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        If screenWidth >= 1200 And screenHeight >= 700 Then

            frm.SuspendLayout()
            responsive.ResizeControls(frm)
            frm.ResumeLayout()

        End If

    End Sub

End Module