Public Class General

    Public Shared Sub Close(frm As Form)

        frm.Close()

        Dim mainForm As FrmFNBManagement =
            CType(Application.OpenForms("FrmFNBManagement"), FrmFNBManagement)

        If mainForm IsNot Nothing Then
            mainForm.ShowDashboard()
        End If

    End Sub

End Class