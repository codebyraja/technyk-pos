Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmLinkPaymodes
    Private responsive As ResponsiveHelper
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand
    Dim ds As New DataSet
    Dim drLinkWaiter As DataRow
    Dim dtLinkWaiter As DataTable
    Dim Ctr As Integer = 0

    Private Sub FrmLinkPaymodes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisableControl(Me.PanelEntry)
        ClearText(Me.PanelEntry)
        EnableButton("CANCEL", Me)
        BindComboboxWithSelectOneNumeric("SELECT Code, ModeDesc FROM AC_ModeOfPayment WHERE Location='pos' AND Status='Active'", "Code", "ModeDesc", cmbPaymentMode)
        BindComboboxWithSelectOneNumeric("Select Code,LocationName From IM_LocationMaster where Type in(" & LOCATION_TYPE & ")", "Code", "LocationName", cmbLocation)
        cmbLocation.SelectedValue = 0
        cmbPaymentMode.SelectedValue = 0
        BindSearchGrid()

        responsive = New ResponsiveHelper(Me)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (btnAdd.Text = "Add") Then
            Me.ErrorProvider1.Dispose()
            ClearText(Me.PanelEntry)
            EnableControl(Me.PanelEntry)
            EnableButton("ADD", Me)
            cmbLocation.Focus()
        Else
            ObjDatabase.CloseDatabaseConnection()
            ObjDatabase.OpenDatabaseConnection()
            myTrans = ObjDatabase.con.BeginTransaction()
            myCommand = ObjDatabase.con.CreateCommand()
            myCommand.Transaction = myTrans
            Try
                If dtLinkWaiter.Rows.Count = 0 Then
                    MsgBox("Add Combination ", MsgBoxStyle.Information)
                    Exit Sub
                End If

                StrSql = "Delete From FB_PaymentModes Where [LocationCode]=" & Val(cmbLocation.SelectedValue)
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                If dtLinkWaiter.Rows.Count > 0 Then
                    For Me.Ctr = 0 To dtLinkWaiter.Rows.Count - 1
                        StrSql = "INSERT INTO FB_PaymentModes([PayModeCode],[LocationCode],[CreationDate],[ModificationDate],[UserCode])" & _
                        " VALUES (" & dgLinkLocationWaiter.Item("PayModeCode", Ctr).Value & _
                        "," & Val(dgLinkLocationWaiter.Item("LocationCode", Ctr).Value) & _
                        ",getdate()" & _
                        ",getdate()" & _
                        "," & UserCode & _
                         " )"
                        myCommand.CommandText = StrSql
                        myCommand.ExecuteNonQuery()
                    Next
                End If
                myTrans.Commit()
                DisableControl(Me.PanelEntry)
                ClearText(Me.PanelEntry)
                EnableButton("CANCEL", Me)
                MsgBox("Record saved successfully", MsgBoxStyle.Information)
                BindSearchGrid()
            Catch ex As SqlException
                myTrans.Rollback()
                FormatLabel("error")
                labelRecordCount.Text = ErrorMessageHeader & ex.Message
                ToolTip1.SetToolTip(labelRecordCount, labelRecordCount.Text)
            Finally
                ObjDatabase.CloseDatabaseConnection()
                myTrans.Dispose()
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DisableControl(Me.PanelEntry)
        ClearText(Me.PanelEntry)
        EnableButton("CANCEL", Me)
        BindSearchGrid()
        ErrorProvider1.Dispose()
    End Sub

    Private Function validation() As Boolean
        If Val(cmbLocation.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbLocation, "Select Location Name")
            validation = False
            cmbLocation.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If
        If Val(cmbPaymentMode.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbPaymentMode, "Select Payment Mode")
            validation = False
            cmbPaymentMode.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Me.Dispose()
        'BackToMainScreen = True
        General.Close(Me)
    End Sub

    Private Sub BindSearchGrid()
        StrSql = "Select FPM.LocationCode,L.LocationName,FPM.PayModeCode,MP.ModeDesc" & _
        " From FB_PaymentModes FPM,AC_ModeOfPayment MP,IM_LocationMaster L" & _
        " Where MP.Code=FPM.PayModeCode And L.Code=FPM.LocationCode And L.Code=" & Val(cmbLocation.SelectedValue) & ""
        ds = New DataSet
        dtLinkWaiter = New DataTable
        ds = ObjDatabase.BindDataSet(StrSql, "LinkLocationWaiter")
        dtLinkWaiter = ds.Tables("LinkLocationWaiter")
        dgLinkLocationWaiter.DataSource = dtLinkWaiter
        FormatDataGridView(dgLinkLocationWaiter)
        dgLinkLocationWaiter.Columns("LocationCode").Visible = False
        dgLinkLocationWaiter.Columns("PayModeCode").Visible = False
        dgLinkLocationWaiter.Columns(0).Visible = True
        dgLinkLocationWaiter.Columns(1).Visible = True
        dgLinkLocationWaiter.Columns(0).Width = 30
        dgLinkLocationWaiter.Columns(1).Width = 30
        dgLinkLocationWaiter.Columns("LocationName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkLocationWaiter.Columns("LocationName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkLocationWaiter.Columns("LocationName").Width = 280
        dgLinkLocationWaiter.Columns("ModeDesc").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkLocationWaiter.Columns("ModeDesc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkLocationWaiter.Columns("ModeDesc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgLinkLocationWaiter.Columns("ModeDesc").HeaderText = "PaymentMode"
        labelRecordCount.Text = "Record Count: " & dgLinkLocationWaiter.RowCount
    End Sub

    Private Sub btnAddWaiter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddWaiter.Click
        If validation() = False Then Exit Sub
        For Me.Ctr = 0 To dgLinkLocationWaiter.RowCount - 1
            If ((dgLinkLocationWaiter.Item("LocationCode", Me.Ctr).Value = cmbLocation.SelectedValue) And (dgLinkLocationWaiter.Item("PayModeCode", Me.Ctr).Value = cmbPaymentMode.SelectedValue)) Then
                MsgBox("Pay Mode already exists in the selected location", MsgBoxStyle.Information, ModuleName)
                cmbPaymentMode.Focus()
                Exit Sub
            End If
        Next
        drLinkWaiter = dtLinkWaiter.NewRow
        drLinkWaiter.Item("LocationCode") = Val(cmbLocation.SelectedValue & "")
        drLinkWaiter.Item("LocationName") = Trim(cmbLocation.Text)
        drLinkWaiter.Item("PayModeCode") = Val(cmbPaymentMode.SelectedValue)
        drLinkWaiter.Item("ModeDesc") = Trim(cmbPaymentMode.Text & "")
        dtLinkWaiter.Rows.Add(drLinkWaiter)
        dtLinkWaiter.AcceptChanges()
        cmbPaymentMode.SelectedValue = 0
        dgLinkLocationWaiter.DataSource = dtLinkWaiter
        labelRecordCount.Text = "Rcord Count: " & dgLinkLocationWaiter.Rows.Count
        cmbPaymentMode.Focus()
    End Sub

    Private Sub cmbLocation_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLocation.Validated
        BindSearchGrid()
    End Sub

    Private Sub dgLinkLocationWaiter_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLinkLocationWaiter.CellContentClick
        If e.ColumnIndex = 0 Then
            If dgLinkLocationWaiter.Rows.Count > 0 Then
                cmbLocation.SelectedValue = dtLinkWaiter.Rows(dgLinkLocationWaiter.CurrentRow.Index).Item("LocationCode")
                cmbPaymentMode.SelectedValue = dtLinkWaiter.Rows(dgLinkLocationWaiter.CurrentRow.Index).Item("PayModeCode")
                dtLinkWaiter.Rows(dgLinkLocationWaiter.CurrentRow.Index).Delete()
                dtLinkWaiter.AcceptChanges()
                dgLinkLocationWaiter.DataSource = dtLinkWaiter
            End If
        ElseIf e.ColumnIndex = 1 Then
            If dgLinkLocationWaiter.Rows.Count > 0 Then
                dtLinkWaiter.Rows(dgLinkLocationWaiter.CurrentRow.Index).Delete()
                dtLinkWaiter.AcceptChanges()
                dgLinkLocationWaiter.DataSource = dtLinkWaiter
            End If
        End If
    End Sub

    Public Sub FormatLabel(ByVal Flag As String)
        If Flag = "error" Then
            labelRecordCount.BackColor = ErrorBC
            labelRecordCount.ForeColor = Color.White
        Else
            labelRecordCount.BackColor = NormalBC
            labelRecordCount.ForeColor = Color.Black
        End If
    End Sub

    Private Sub PanelFooter_Resize(sender As Object, e As EventArgs) Handles PanelFooter.Resize
        CenterButtonsInPanel(PanelFooter)
    End Sub

    Private Sub FrmLinkPaymodes_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If responsive Is Nothing Then
            responsive = New ResponsiveHelper(Me)
        End If

        ApplyResponsiveLayout(Me, responsive)
    End Sub
End Class