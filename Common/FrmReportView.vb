Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System.Net.Mail
Public Class FrmReportView

    Private Sub FrmReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Normal
        'Left = Top = 0
        'Dim FormHeight, FormWidth As Integer
        'FormHeight = Me.Height
        'FormWidth = Me.Width
        'Width = Screen.PrimaryScreen.WorkingArea.Width
        'Height = Screen.PrimaryScreen.WorkingArea.Height
        'Me.Size = New Point(Width, Height)
    End Sub

    Private Sub btnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

End Class