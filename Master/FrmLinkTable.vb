Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmLinkTable
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim drLinkTable As DataRow
    Dim dtLinkTable As DataTable
    Dim ctr As Integer = 0

    Private Sub FrmLinkTable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisableControl(Me.PanelEntry)
        ClearText(Me.PanelEntry)
        EnableButton("CANCEL", Me)
        BindGridForSearch()
        BindComboboxWithSelectOneNumeric("Select Code,LocationName From IM_LocationMaster  where Type in(" & LOCATION_TYPE & ")", "Code", "LocationName", cmbBillingLocation)
        BindComboboxWithSelectOneNumeric("Select Code,LocationName From IM_LocationMaster  where Type in(" & LOCATION_TYPE & ")", "Code", "LocationName", cmbTableLocation)
        BindComboboxWithSelectOneNumeric("Select Code,TableNo From FB_TableMaster", "Code", "TableNo", cmbTable)
        cmbBillingLocation.SelectedValue = 0
        cmbTableLocation.SelectedValue = 0
        cmbTable.SelectedValue = 0
        btnAddTable.Enabled = False
    End Sub

    Protected Overloads Overrides Function _
           ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If TypeOf ActiveControl Is Button = False Then
            Select Case keyData
                Case Keys.Enter
                    Return MyBase.ProcessDialogKey(Keys.Tab)
                Case Keys.Escape
                    Return MyBase.ProcessDialogKey(Keys.Shift Or _
                        Keys.Tab)
            End Select
        Else
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (btnAdd.Text = "Add") Then
            Me.ErrorProvider1.Dispose()
            ClearText(Me.PanelEntry)
            EnableControl(Me.PanelEntry)
            EnableButton("ADD", Me)
            cmbBillingLocation.Focus()
        Else
            ObjDatabase.CloseDatabaseConnection()
            ObjDatabase.OpenDatabaseConnection()
            myTrans = ObjDatabase.con.BeginTransaction()
            myCommand = ObjDatabase.con.CreateCommand()
            myCommand.Transaction = myTrans
            Try
                If dtLinkTable.Rows.Count < 1 Then
                    MsgBox("Add Location & Table combination before saving", MsgBoxStyle.Information)
                    Exit Sub
                End If
                StrSql = "Delete From FB_LocationTableLink Where LocationCode=" & Val(cmbBillingLocation.SelectedValue) & ""
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()
                If dtLinkTable.Rows.Count > 0 Then
                    For Me.ctr = 0 To dtLinkTable.Rows.Count - 1
                        StrSql = "INSERT INTO FB_LocationTableLink(MainLocationCode,LocationCode, TableCode, PAX, CreationDate, ModificationDate, UserCode)" & _
                        " VALUES (" & _
                        "" & dgLinkTable.Item("MCode", ctr).Value & _
                        "," & Val(dgLinkTable.Item("LCode", ctr).Value) & _
                        "," & dgLinkTable.Item("TCode", ctr).Value & _
                        "," & dgLinkTable.Item("PAX", ctr).Value & _
                        ",getdate()" & _
                        ",getdate()" & _
                        ", " & UserCode & _
                        ")"
                        myCommand.CommandText = StrSql
                        myCommand.ExecuteNonQuery()
                    Next
                End If
                myTrans.Commit()
                DisableControl(Me.PanelEntry)
                ClearText(Me.PanelEntry)
                EnableButton("CANCEL", Me)
                MsgBox("Record saved successfully", MsgBoxStyle.Information)
                BindGridForSearch()
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
        BindGridForSearch()
        ErrorProvider1.Dispose()
    End Sub

    Private Function validation() As Boolean
        If Val(cmbBillingLocation.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbBillingLocation, "Select Billing Location")
            validation = False
            cmbBillingLocation.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If Val(cmbTableLocation.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbTableLocation, "Select Table Location")
            validation = False
            cmbTableLocation.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If Val(cmbTable.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbTable, "Select Table No")
            validation = False
            cmbTable.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If Val(txtPAX.Text) = 0 Then
            ErrorProvider1.SetError(txtPAX, "Enter the PAX")
            validation = False
            txtPAX.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
        BackToMainScreen = True
    End Sub

    Private Sub BindGridForSearch()
        StrSql = "Select LT.LocationCode LCode,BL.LocationName BillingLocation,ML.LocationName TableLocation,LT.TableCode TCode" & _
        ",TM.TableNo [TableNo],LT.PAX,LT.MainLocationCode MCode" & _
        " From FB_LocationTableLink LT,IM_LocationMaster BL,IM_LocationMaster ML ,FB_TableMaster TM " & _
        " Where TM.Code=LT.TableCode And BL.Code=LT.LocationCode and ML.Code=LT.MainLocationCode" & _
        " And LT.LocationCode=" & Val(cmbBillingLocation.SelectedValue) & ""
        ds = New DataSet
        dtLinkTable = New DataTable
        ds = ObjDatabase.BindDataSet(StrSql, "LocationTableLink")
        dtLinkTable = ds.Tables("LocationTableLink")
        dgLinkTable.DataSource = dtLinkTable
        FormatDataGridView(dgLinkTable)

        dgLinkTable.Columns("LCode").Visible = False
        dgLinkTable.Columns("MCode").Visible = False
        dgLinkTable.Columns("TCode").Visible = False

        dgLinkTable.Columns("BillingLocation").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkTable.Columns("BillingLocation").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkTable.Columns("BillingLocation").Width = 250

        dgLinkTable.Columns("TableLocation").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkTable.Columns("TableLocation").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkTable.Columns("TableLocation").Width = 250

        dgLinkTable.Columns("TableNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkTable.Columns("TableNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkTable.Columns("TableNo").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dgLinkTable.Columns("PAX").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkTable.Columns("PAX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLinkTable.Columns("PAX").Width = 50

        dgLinkTable.Columns(0).Width = 30
        dgLinkTable.Columns(1).Width = 30
        dgLinkTable.RowHeadersVisible = True
        dgLinkTable.Cursor = Cursors.Hand
        labelRecordCount.Text = "Record Count: " & dgLinkTable.RowCount
        FormatLabel("search")
    End Sub

    Private Sub btnAddTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTable.Click
        If validation() = False Then Exit Sub
        For Me.ctr = 0 To dgLinkTable.RowCount - 1
            If dgLinkTable.Item("LCode", ctr).Value = cmbBillingLocation.SelectedValue And dgLinkTable.Item("MCode", ctr).Value = cmbTableLocation.SelectedValue And dgLinkTable.Item("TCode", ctr).Value = cmbTable.SelectedValue Then
                MsgBox("Duplicate Entry Not Allowed", MsgBoxStyle.Information, ModuleName)
                Exit Sub
            End If
        Next

        Try
            drLinkTable = dtLinkTable.NewRow
            drLinkTable.Item("MCode") = Val(cmbTableLocation.SelectedValue & "")
            drLinkTable.Item("LCode") = Val(cmbBillingLocation.SelectedValue & "")
            drLinkTable.Item("BillingLocation") = Trim(cmbBillingLocation.Text)
            drLinkTable.Item("TableLocation") = Val(cmbTableLocation.SelectedValue)
            drLinkTable.Item("TCode") = Trim(cmbTable.SelectedValue & "")
            drLinkTable.Item("TableNo") = Trim(cmbTable.Text & "")
            drLinkTable.Item("PAX") = Val(txtPAX.Text & "")
            dtLinkTable.Rows.Add(drLinkTable)
            dtLinkTable.AcceptChanges()
            cmbTable.SelectedValue = 0
            dgLinkTable.DataSource = dtLinkTable
            cmbTable.Focus()
            labelRecordCount.Text = "Record Count: " & dgLinkTable.RowCount
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtPAX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPAX.KeyPress
        ValidateWholeNumberInput(sender, e)
    End Sub

    Private Sub txtPAX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPAX.Validated
        If IsNumeric(txtPAX.Text) = False And txtPAX.Text <> "" Then
            MsgBox("Enter the PAXS", MsgBoxStyle.Information)
            txtPAX.Text = ""
            txtPAX.Focus()
        End If
    End Sub

    Private Sub dgLinkTable_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLinkTable.CellContentClick
        If e.ColumnIndex = 0 Then
            If dgLinkTable.Rows.Count > 0 Then
                cmbTableLocation.SelectedValue = dtLinkTable.Rows(dgLinkTable.CurrentRow.Index).Item("LCode")
                cmbTable.SelectedValue = dtLinkTable.Rows(dgLinkTable.CurrentRow.Index).Item("TCode")
                dtLinkTable.Rows(dgLinkTable.CurrentRow.Index).Delete()
                dtLinkTable.AcceptChanges()
                dgLinkTable.DataSource = dtLinkTable
            End If
        ElseIf e.ColumnIndex = 1 Then
            If dgLinkTable.Rows.Count > 0 Then
                dtLinkTable.Rows(dgLinkTable.CurrentRow.Index).Delete()
                dtLinkTable.AcceptChanges()
                dgLinkTable.DataSource = dtLinkTable
            End If
        End If
    End Sub

    Private Sub cmbBillingLocation_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBillingLocation.Validated
        BindGridForSearch()
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

    Private Sub cmbTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTable.SelectedIndexChanged

    End Sub
End Class