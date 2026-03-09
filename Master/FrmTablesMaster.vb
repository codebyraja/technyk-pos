Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmTableMaster
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As DataSet

    Private Sub FrmTableMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ObjDatabase.ConnectDatabse()
        DisableControl(Me.PanelEntry)
        EnableControl(PanelSearch)
        EnableButton("Cancel", Me)
        BindGridForSearch()
        BindComboboxWithSelectOneNumeric("Select Code,LocationName From IM_LocationMaster where Type in(" & LOCATION_TYPE & ")", "Code", "LocationName", cmbLocation)
        BindComboboxWithSelectOneNumeric("Select Code,LocationName From IM_LocationMaster where Type in(" & LOCATION_TYPE & ")", "Code", "LocationName", cmbLocationSearch)
        cmbLocation.SelectedValue = 0
        cmbLocationSearch.SelectedValue = 0

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (btnAdd.Text = "Add") Then
            EnableControl(Me.PanelEntry)
            EnableControl(Me.PanelSearch)
            EnableButton("ADD", Me)
            ClearText(Me.PanelEntry)
            BindGridForSearch()
            txtTableNo.Focus()
        Else
            If (validation() = False) Then Exit Sub
            ObjDatabase.ConnectDatabse()
            ObjDatabase.CloseDatabaseConnection()
            ObjDatabase.OpenDatabaseConnection()
            myTrans = ObjDatabase.con.BeginTransaction()
            myCommand = ObjDatabase.con.CreateCommand()
            myCommand.Transaction = myTrans
            Try
                StrSql = "SELECT Count(*) FROM FB_TableMaster WHERE TableNo='" & Trim(txtTableNo.Text) & "'"
                myCommand.CommandText = StrSql
                RecCount = myCommand.ExecuteScalar
                If RecCount > 0 Then
                    MsgBox("TableNo Name already exists", MsgBoxStyle.Information, ModuleName)
                    txtTableNo.Focus()
                    Exit Sub
                End If

                StrSql = "SELECT ISNULL(Max(Code),0)+1 FROM FB_TableMaster"
                myCommand.CommandText = StrSql
                txtCode.Text = myCommand.ExecuteScalar

                StrSql = "INSERT INTO FB_TableMaster" & _
                "(Code, TableNo, Description, MainLocationCode, CreationDate, ModificationDate, UserCode) VALUES (" & _
                "" & Val(txtCode.Text) & _
                ",'" & Trim(txtTableNo.Text) & "'" & _
                ",'" & Trim(txtDescription.Text) & "'" & _
                "," & cmbLocation.SelectedValue & _
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
                LabelRecordCount.Text = ErrorMessageHeader & ex.Message
                ToolTip1.SetToolTip(LabelRecordCount, LabelRecordCount.Text)
            Finally
                ObjDatabase.CloseDatabaseConnection()
                myTrans.Dispose()
            End Try
        End If
    End Sub

    Private Sub dgsearch_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgsearch.CellContentClick
        If e.ColumnIndex = 0 Then
            txtCode.Text = dgsearch.Item("Code", dgsearch.CurrentRow.Index).Value
            txtTableNo.Text = dgsearch.Item("TableNo", dgsearch.CurrentRow.Index).Value
            txtDescription.Text = dgsearch.Item("Description", dgsearch.CurrentRow.Index).Value
            cmbLocation.SelectedValue = dgsearch.Item("MainLocationCode", dgsearch.CurrentRow.Index).Value
            DisableControl(Me.PanelEntry)
            EnableButton("EDIT", Me)
            StrSql = "select count(*) from FB_KOTHead where TableCode=" & Val(txtCode.Text)
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

                StrSql = "SELECT Count(*) FROM FB_TableMaster WHERE [TableNo]='" & Trim(txtTableNo.Text) & "' and Code<>" & Val(txtCode.Text)
                myCommand.CommandText = StrSql
                RecCount = myCommand.ExecuteScalar
                If RecCount > 0 Then
                    MsgBox("TableNo Name already exists", MsgBoxStyle.Information, ModuleName)
                    txtTableNo.Focus()
                    Exit Sub
                End If

                StrSql = "Update FB_TableMaster " & _
                " set [TableNo]='" & Trim(txtTableNo.Text) & "'" & _
                ",[Description]='" & Trim(txtDescription.Text) & "'" & _
                ",[MainLocationCode]=" & cmbLocation.SelectedValue & _
                ",[ModificationDate]='" & CurrentServerDate & "'" & _
                " where  Code=" & Val(txtCode.Text) & ""
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
                LabelRecordCount.Text = ErrorMessageHeader & ex.Message
                ToolTip1.SetToolTip(LabelRecordCount, LabelRecordCount.Text)
            Catch ex1 As Exception
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
            StrSql = "DELETE FROM FB_TableMaster where  Code=" & Val(txtCode.Text) & ""
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
            LabelRecordCount.Text = ErrorMessageHeader & ex.Message
            ToolTip1.SetToolTip(LabelRecordCount, LabelRecordCount.Text)
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
        General.Close(Me)
    End Sub

    Private Sub txtTableNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTableNo.TextChanged
        txtDescription.Text = txtTableNo.Text
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

    Private Function validation() As Boolean
        If Trim(txtTableNo.Text) = "" Then
            ErrorProvider1.SetError(txtTableNo, "Enter TableNo.")
            validation = False
            txtTableNo.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If Val(cmbLocation.SelectedValue) = 0 Then
            ErrorProvider1.SetError(txtTableNo, "Select Table Location")
            validation = False
            cmbLocation.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        RecCount = ObjDatabase.ExecuteScalarN("SELECT Count(*) FROM FB_TableMaster WHERE TableNo='" & Trim(txtTableNo.Text) & "'")
        If RecCount > 0 Then
            MsgBox("TableNo already exists", MsgBoxStyle.Information, ModuleName)
            txtTableNo.Focus()
            validation = False
            Exit Function
        Else
            Me.ErrorProvider1.Dispose()
            validation = True
        End If
    End Function

    Public Sub FormatLabel(ByVal Flag As String)
        If Flag = "success" Then
            LabelRecordCount.BackColor = SuccessBC
            LabelRecordCount.ForeColor = Color.White
        ElseIf Flag = "error" Then
            LabelRecordCount.BackColor = ErrorBC
            LabelRecordCount.ForeColor = Color.White
        Else
            LabelRecordCount.BackColor = NormalBC
            LabelRecordCount.ForeColor = Color.Black
        End If
    End Sub

    Public Sub BindGridForSearch()
        ds = New DataSet
        StrSql = "select TM.Code, TM.TableNo as [TableNo],TM.Description Description,LM.LocationName,TM.MainLocationCode " & _
        " FROM FB_TableMaster TM, IM_LocationMaster LM WHERE TM.MainLocationCode=LM.Code"
        StrSql &= IIf(txtDescriptionSearch.Text <> "", " AND Description like '" & txtDescriptionSearch.Text & "%'", "")
        StrSql &= IIf(txtTableNoSearch.Text <> "", " AND TableNo like '" & txtTableNoSearch.Text & "%'", "")
        StrSql &= IIf(cmbLocationSearch.SelectedValue > 0, " AND TM.MainLocationCode=" & cmbLocationSearch.SelectedValue, "")
        ds = ObjDatabase.BindDataSet(StrSql, "Data")
        dgsearch.DataSource = ds
        dgsearch.DataMember = "Data"
        FormatDataGridView(dgsearch)

        dgsearch.Columns("Code").Width = 50
        dgsearch.Columns("Code").HeaderText = "Code"
        dgsearch.Columns("MainLocationCode").Visible = False

        dgsearch.Columns("TableNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("TableNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("TableNo").Width = 80
        dgsearch.Columns("TableNo").HeaderText = "TableNo"

        dgsearch.Columns("Description").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("Description").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("Description").Width = 150

        dgsearch.Columns("LocationName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("LocationName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("LocationName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgsearch.Columns("LocationName").HeaderText = "Location"

        dgsearch.Columns(0).HeaderText = ""
        dgsearch.Columns(0).Width = 30
        dgsearch.RowHeadersVisible = True
        dgsearch.RowHeadersWidth = 20
        LabelRecordCount.Text = "Record Count: " & dgsearch.Rows.Count
        FormatLabel("search")
    End Sub

    Private Sub txtDescriptionSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescriptionSearch.TextChanged
        BindGridForSearch()
    End Sub

    Private Sub cmbLocationSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLocationSearch.SelectedIndexChanged

    End Sub

    Private Sub cmbLocationSearch_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLocationSearch.Validated
        BindGridForSearch()
    End Sub

    Private Sub PanelFooter_Resize(sender As Object, e As EventArgs) Handles PanelFooter.Resize
        CenterButtonsInPanel(PanelFooter)
    End Sub
End Class