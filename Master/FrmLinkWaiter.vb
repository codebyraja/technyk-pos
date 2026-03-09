Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmLinkWaiter
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand
    Dim ds As New DataSet
    Dim drLinkWaiter As DataRow
    Dim dtLinkWaiter As DataTable
    Dim Ctr As Integer = 0
    Private responsive As ResponsiveHelper

    Private Sub Frm_LocationWiseGroupBind_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisableControl(Me.PanelEntry)
        ClearText(Me.PanelEntry)
        EnableButton("CANCEL", Me)
        BindComboboxWithSelectOneNumeric("Select Code,WaiterName From FB_WaiterMaster Where Status='Active'", "Code", "WaiterName", cmbWaiter)
        BindComboboxWithSelectOneNumeric("Select Code,LocationName From IM_LocationMaster where Type in(" & LOCATION_TYPE & ")", "Code", "LocationName", cmbLocation)
        cmbLocation.SelectedValue = 0
        cmbWaiter.SelectedValue = 0
        BindSearchGrid()

        responsive = New ResponsiveHelper(Me)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
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

                StrSql = "Delete From FB_LocationWaiterLink Where [LocationCode]=" & Val(cmbLocation.SelectedValue)
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                If dtLinkWaiter.Rows.Count > 0 Then
                    For Me.Ctr = 0 To dtLinkWaiter.Rows.Count - 1
                        StrSql = "INSERT INTO FB_LocationWaiterLink([WaiterCode],[LocationCode],[CreationDate],[ModificationDate],[UserCode])" & _
                        " VALUES (" & dgLinkLocationWaiter.Item("WaiterCode", Ctr).Value & _
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
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
        If Val(cmbWaiter.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbWaiter, "Select Waiter Name")
            validation = False
            cmbWaiter.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Me.Dispose()
        'BackToMainScreen = True
        General.Close(Me)
    End Sub

    Private Sub BindSearchGrid()
        StrSql = "Select LW.LocationCode,L.LocationName,LW.WaiterCode,W.WaiterName" & _
        " From FB_LocationWaiterLink LW,FB_WaiterMaster W,IM_LocationMaster L" & _
        " Where W.Code=LW.WaiterCode And L.Code=LW.LocationCode And L.Code=" & Val(cmbLocation.SelectedValue) & ""
        ds = New DataSet
        dtLinkWaiter = New DataTable
        ds = ObjDatabase.BindDataSet(StrSql, "LinkLocationWaiter")
        dtLinkWaiter = ds.Tables("LinkLocationWaiter")
        dgLinkLocationWaiter.DataSource = dtLinkWaiter
        FormatDataGridView(dgLinkLocationWaiter)
        dgLinkLocationWaiter.Columns("LocationCode").Visible = False
        dgLinkLocationWaiter.Columns("WaiterCode").Visible = False
        dgLinkLocationWaiter.Columns(0).Visible = True
        dgLinkLocationWaiter.Columns(1).Visible = True
        dgLinkLocationWaiter.Columns(0).Width = 30
        dgLinkLocationWaiter.Columns(1).Width = 30
        dgLinkLocationWaiter.Columns("LocationName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkLocationWaiter.Columns("LocationName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkLocationWaiter.Columns("LocationName").Width = 280
        dgLinkLocationWaiter.Columns("WaiterName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkLocationWaiter.Columns("WaiterName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkLocationWaiter.Columns("WaiterName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        labelRecordCount.Text = "Record Count: " & dgLinkLocationWaiter.RowCount
    End Sub

    Private Sub btnAddWaiter_Click(sender As Object, e As EventArgs) Handles btnAddWaiter.Click
        If validation() = False Then Exit Sub
        For Me.Ctr = 0 To dgLinkLocationWaiter.RowCount - 1
            If ((dgLinkLocationWaiter.Item("LocationCode", Me.Ctr).Value = cmbLocation.SelectedValue) And (dgLinkLocationWaiter.Item("WaiterCode", Me.Ctr).Value = cmbWaiter.SelectedValue)) Then
                MsgBox("WaiterCode already exists in the selected location", MsgBoxStyle.Information, ModuleName)
                cmbWaiter.Focus()
                Exit Sub
            End If
        Next
        drLinkWaiter = dtLinkWaiter.NewRow
        drLinkWaiter.Item("LocationCode") = Val(cmbLocation.SelectedValue & "")
        drLinkWaiter.Item("LocationName") = Trim(cmbLocation.Text)
        drLinkWaiter.Item("WaiterCode") = Val(cmbWaiter.SelectedValue)
        drLinkWaiter.Item("WaiterName") = Trim(cmbWaiter.Text & "")
        dtLinkWaiter.Rows.Add(drLinkWaiter)
        dtLinkWaiter.AcceptChanges()
        cmbWaiter.SelectedValue = 0
        dgLinkLocationWaiter.DataSource = dtLinkWaiter
        labelRecordCount.Text = "Rcord Count: " & dgLinkLocationWaiter.Rows.Count
        cmbWaiter.Focus()
    End Sub

    Private Sub cmbLocation_Validated(sender As Object, e As EventArgs) Handles cmbLocation.Validated
        BindSearchGrid()
    End Sub

    Private Sub dgLinkLocationWaiter_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLinkLocationWaiter.CellContentClick
        If e.ColumnIndex = 0 Then
            If dgLinkLocationWaiter.Rows.Count > 0 Then
                cmbLocation.SelectedValue = dtLinkWaiter.Rows(dgLinkLocationWaiter.CurrentRow.Index).Item("LocationCode")
                cmbWaiter.SelectedValue = dtLinkWaiter.Rows(dgLinkLocationWaiter.CurrentRow.Index).Item("WaiterCode")
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

    Private Sub PanelFooter_Resize() Handles PanelFooter.Resize
        CenterButtonsInPanel(PanelFooter)
    End Sub

    Private Sub FrmLinkWaiter_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If responsive Is Nothing Then Exit Sub

        Me.SuspendLayout()

        responsive.ResizeControls(Me)

        Me.ResumeLayout()
    End Sub

    Private Sub PanelFooter_Paint(sender As Object, e As PaintEventArgs) Handles PanelFooter.Paint

    End Sub
End Class