Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmWaiterMaster
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As DataSet

    Private Sub FrmWaiterMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisableControl(Me.PanelEntry)
        EnableControl(Me.PanelSearch)
        ClearText(Me.PanelEntry)
        EnableButton("CANCEL", Me)
        cmbStatusSearch.Text = "[Select All]"
        BindGridForSearch()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (btnAdd.Text = "Add") Then
            Me.ErrorProvider1.Dispose()
            ClearText(Me.PanelEntry)
            EnableControl(Me.PanelEntry)
            EnableControl(Me.PanelSearch)
            EnableButton("ADD", Me)
            cmbStatus.Text = "Active"
            txtWaiter.Focus()
        Else
            If (validation() = False) Then Exit Sub
            ObjDatabase.ConnectDatabse()
            ObjDatabase.CloseDatabaseConnection()
            ObjDatabase.OpenDatabaseConnection()
            myTrans = ObjDatabase.con.BeginTransaction()
            myCommand = ObjDatabase.con.CreateCommand()
            myCommand.Transaction = myTrans
            Try

                StrSql = "SELECT Count(*) FROM FB_WaiterMaster WHERE WaiterName='" & Trim(txtWaiter.Text) & "'"
                myCommand.CommandText = StrSql
                RecCount = myCommand.ExecuteScalar
                If RecCount > 0 Then
                    MsgBox("Waiter Name already exists", MsgBoxStyle.Information, ModuleName)
                    txtWaiter.Focus()
                    Exit Sub
                End If

                StrSql = "SELECT ISNULL(Max(Code),0)+1 FROM FB_WaiterMaster"
                myCommand.CommandText = StrSql
                txtCode.Text = myCommand.ExecuteScalar

                StrSql = "INSERT INTO FB_WaiterMaster(Code, WaiterName, DisplayAs, Status, CreationDate, ModificationDate, UserCode)" & _
                " values(" & _
                Val(txtCode.Text) & _
                ",'" & Trim(txtWaiter.Text) & "'" & _
                ",'" & Trim(txtDisplayAs.Text) & "'" & _
                ",'" & cmbStatus.Text & "'" & _
                ",getdate()" & _
                ",getdate()" & _
                "," & Val(UserCode) & _
                ")"
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()
                myTrans.Commit()
                DisableControl(Me.PanelEntry)
                EnableControl(Me.PanelSearch)
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

    Private Sub dgSearch_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearch.CellContentClick
        If e.ColumnIndex = 0 Then
            txtCode.Text = dgSearch.Item("Code", dgSearch.CurrentRow.Index).Value
            txtWaiter.Text = dgSearch.Item("WaiterName", dgSearch.CurrentRow.Index).Value
            txtDisplayAs.Text = dgSearch.Item("DisplayAs", dgSearch.CurrentRow.Index).Value
            cmbStatus.Text = dgSearch.Item("Status", dgSearch.CurrentRow.Index).Value
            DisableControl(Me.PanelEntry)
            EnableButton("EDIT", Me)
            StrSql = "select count(*) from FB_KOTHead where WaiterCode=" & Val(txtCode.Text)
            RecCount = ObjDatabase.ExecuteScalarS(StrSql)
            If RecCount > 0 Then
                btnDelete.Enabled = False
                btnEdit.Enabled = False
            Else
                btnDelete.Enabled = True
                btnEdit.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            EnableControl(Me.PanelEntry)
            EnableControl(Me.PanelSearch)
            EnableButton("EDIT", Me)
            btnEdit.Text = "Update"
            btnDelete.Enabled = False
        ElseIf btnEdit.Text = "Update" Then
            If validation() = False Then Exit Sub
            ObjDatabase.OpenDatabaseConnection()
            myTrans = ObjDatabase.con.BeginTransaction()
            myCommand = ObjDatabase.con.CreateCommand()
            myCommand.Transaction = myTrans
            Try
                StrSql = "SELECT Count(*) FROM FB_WaiterMaster WHERE WaiterName='" & Trim(txtWaiter.Text) & "' and Code<>" & Val(txtCode.Text)
                myCommand.CommandText = StrSql
                RecCount = myCommand.ExecuteScalar
                If RecCount > 0 Then
                    MsgBox("Waiter Name already exists", MsgBoxStyle.Information, ModuleName)
                    txtWaiter.Focus()
                    Exit Sub
                End If

                StrSql = "Update FB_WaiterMaster" & _
                " set WaiterName='" & Trim(txtWaiter.Text) & "'" & _
                ",DisplayAs='" & Trim(txtDisplayAs.Text) & "'" & _
                ", ModificationDate=getdate()" & _
                ",Status='" & cmbStatus.Text.Trim & "'" & _
                " where Code=" & Val(txtCode.Text) & ""
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()
                myTrans.Commit()
                DisableControl(Me.PanelEntry)
                EnableControl(Me.PanelSearch)
                ClearText(Me.PanelEntry)
                EnableButton("CANCEL", Me)
                MsgBox("Record updated successfully", MsgBoxStyle.Information)
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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        ObjDatabase.OpenDatabaseConnection()
        myTrans = ObjDatabase.con.BeginTransaction()
        myCommand = ObjDatabase.con.CreateCommand()
        myCommand.Transaction = myTrans
        Try
            If MsgBox("Are you sure to delete the selected record??", MsgBoxStyle.YesNo, ModuleName) = MsgBoxResult.No Then Exit Sub
            StrSql = "DELETE FROM FB_WaiterMaster where Code=" & Val(txtCode.Text) & ""
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()
            myTrans.Commit()
            DisableControl(Me.PanelEntry)
            EnableControl(Me.PanelSearch)
            ClearText(Me.PanelEntry)
            EnableButton("CANCEL", Me)
            MsgBox("Record deleted successfully", MsgBoxStyle.Information)
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
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DisableControl(Me.PanelEntry)
        EnableControl(Me.PanelSearch)
        ClearText(Me.PanelEntry)
        EnableButton("CANCEL", Me)
        BindGridForSearch()
        ErrorProvider1.Dispose()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
        BackToMainScreen = True
    End Sub

    Private Sub txtWaiter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWaiter.TextChanged
        txtDisplayAs.Text = txtWaiter.Text
    End Sub

    Private Function validation() As Boolean
        If Trim(txtWaiter.Text) = "" Then
            ErrorProvider1.SetError(txtWaiter, "Enter Waiter Name")
            validation = False
            txtWaiter.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If
    End Function

    Public Sub FormatLabel(ByVal Flag As String)
        If Flag = "success" Then
            labelRecordCount.BackColor = SuccessBC
            labelRecordCount.ForeColor = Color.White
        ElseIf Flag = "error" Then
            labelRecordCount.BackColor = ErrorBC
            labelRecordCount.ForeColor = Color.White
        Else
            labelRecordCount.BackColor = NormalBC
            labelRecordCount.ForeColor = Color.Black
        End If
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
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Public Sub BindGridForSearch()
        ds = New DataSet
        StrSql = ""
        StrSql = "select Code, WaiterName as [WaiterName],DisplayAs DisplayAs,Status from FB_WaiterMaster WHERE 1=1" & _
        IIf(txtDisplayAsSearch.Text <> "", " and DisplayAs like '" & txtWaiterSearch.Text & "%'", "") & _
        IIf(txtWaiterSearch.Text <> "", " and WaiterName like '" & txtWaiterSearch.Text & "%'", "") & _
        IIf(cmbStatusSearch.Text <> "[Select All]", " and Status = '" & cmbStatusSearch.Text & "'", "") & _
        " Order by 2"

        ds = ObjDatabase.BindDataSet(StrSql, "Waiter")
        dgSearch.DataSource = ds
        FormatDataGridView(dgSearch)
        dgSearch.DataMember = "Waiter"

        dgSearch.Columns("Code").Width = 50
        dgSearch.Columns("Code").HeaderText = "Code"

        dgSearch.Columns("WaiterName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("WaiterName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("WaiterName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dgSearch.Columns("DisplayAs").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("DisplayAs").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("DisplayAs").Width = 100

        dgSearch.Columns("Status").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("Status").Width = 70

        dgSearch.Columns(0).HeaderText = ""
        dgSearch.Columns(0).Width = 30
        dgSearch.RowHeadersVisible = True
        dgSearch.RowHeadersWidth = 20
        labelRecordCount.Text = "Record Count: " & dgSearch.Rows.Count
        FormatLabel("search")
    End Sub

    Private Sub txtWaiterSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWaiterSearch.TextChanged, txtDisplayAsSearch.TextChanged
        BindGridForSearch()
    End Sub

    Private Sub cmbSearchWaiter_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatusSearch.Validated
        BindGridForSearch()
    End Sub
End Class