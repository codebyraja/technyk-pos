Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmConfigurations
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As DataSet

    Private Sub FrmConfigurations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ObjDatabase.ConnectDatabse()
        DisableControl(Me.PanelEntry)
        EnableControl(PanelSearch)
        EnableButton("Cancel", Me)
        BindGridForSearch()
        BindComboboxWithSelectOneNumeric("Select Code,LocationName From IM_LocationMaster where Type in(" & LOCATION_TYPE & ")", "Code", "LocationName", cmbLocation)
        BindComboboxWithSelectAllNumeric("Select Code,LocationName From IM_LocationMaster where Type in(" & LOCATION_TYPE & ")", "Code", "LocationName", cmbLocationSearch)
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
            txtPropertyName.Focus()
        Else
            If (validation() = False) Then Exit Sub
            ObjDatabase.ConnectDatabse()
            ObjDatabase.CloseDatabaseConnection()
            ObjDatabase.OpenDatabaseConnection()
            myTrans = ObjDatabase.con.BeginTransaction()
            myCommand = ObjDatabase.con.CreateCommand()
            myCommand.Transaction = myTrans
            Try     'SELECT SNo, PropertyName, PropertyValue, LocationCode FROM FB_Configuration
                StrSql = "SELECT Count(*) FROM FB_Configuration WHERE PropertyName='" & Trim(txtPropertyName.Text) & "' and LocationCode=" & cmbLocation.SelectedValue
                myCommand.CommandText = StrSql
                RecCount = myCommand.ExecuteScalar
                If RecCount > 0 Then
                    MsgBox("Property Name Name already exists", MsgBoxStyle.Information, ModuleName)
                    txtPropertyName.Focus()
                    Exit Sub
                End If

                StrSql = "SELECT ISNULL(Max(Code),0)+1 FROM FB_Configuration"
                myCommand.CommandText = StrSql
                txtCode.Text = myCommand.ExecuteScalar

                StrSql = "INSERT INTO FB_Configuration" & _
                "(Code, PropertyName, PropertyValue, LocationCode, CreationDate, ModificationDate, UserCode) VALUES (" & _
                "" & Val(txtCode.Text) & _
                ",'" & Trim(txtPropertyName.Text) & "'" & _
                ",'" & Trim(txtPropertyValue.Text) & "'" & _
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
            txtPropertyName.Enabled = False
            txtCode.Text = dgsearch.Item("Code", dgsearch.CurrentRow.Index).Value
            txtPropertyName.Text = dgsearch.Item("PropertyName", dgsearch.CurrentRow.Index).Value
            txtPropertyValue.Text = dgsearch.Item("PropertyValue", dgsearch.CurrentRow.Index).Value
            cmbLocation.SelectedValue = dgsearch.Item("LocationCode", dgsearch.CurrentRow.Index).Value
            DisableControl(Me.PanelEntry)
            EnableButton("EDIT", Me)
            btnDelete.Enabled = True
            btnEdit.Enabled = True
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            EnableControl(Me.PanelEntry)
            EnableControl(Me.PanelSearch)
            EnableButton("EDIT", Me)
            btnEdit.Text = "Update"
            btnDelete.Enabled = False
            txtPropertyName.Enabled = False
        ElseIf btnEdit.Text = "Update" Then
            If validation() = False Then Exit Sub
            ObjDatabase.OpenDatabaseConnection()
            myTrans = ObjDatabase.con.BeginTransaction()
            myCommand = ObjDatabase.con.CreateCommand()
            myCommand.Transaction = myTrans
            Try

                StrSql = "SELECT Count(*) FROM FB_Configuration WHERE [PropertyName]='" & Trim(txtPropertyName.Text) & "' and Code<>" & Val(txtCode.Text) & " AND LocationCode=" & cmbLocation.SelectedValue
                myCommand.CommandText = StrSql
                RecCount = myCommand.ExecuteScalar
                If RecCount > 0 Then
                    MsgBox("Property Name Name already exists", MsgBoxStyle.Information, ModuleName)
                    txtPropertyName.Focus()
                    Exit Sub
                End If

                StrSql = "Update FB_Configuration " & _
                " set [PropertyName]='" & Trim(txtPropertyName.Text) & "'" & _
                ",[PropertyValue]='" & Trim(txtPropertyValue.Text) & "'" & _
                ",[LocationCode]=" & cmbLocation.SelectedValue & _
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
            If MsgBox("Are you sure to delete the selected record?", MsgBoxStyle.YesNo, ModuleName) = MsgBoxResult.No Then Exit Sub
            StrSql = "DELETE FROM FB_Configuration where  Code=" & Val(txtCode.Text) & ""
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
        Me.Dispose()
        BackToMainScreen = True
    End Sub

    Private Sub txtPropertyName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPropertyName.TextChanged
        txtPropertyValue.Text = txtPropertyName.Text
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
        If Trim(txtPropertyName.Text) = "" Then
            ErrorProvider1.SetError(txtPropertyName, "Enter Property Name")
            validation = False
            txtPropertyName.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If Trim(txtPropertyValue.Text) = "" And 1 = 2 Then
            ErrorProvider1.SetError(txtPropertyValue, "Enter Property Value")
            validation = False
            txtPropertyValue.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If Val(cmbLocation.SelectedValue) = 0 Then
            ErrorProvider1.SetError(txtPropertyName, "Select Location")
            validation = False
            cmbLocation.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If
        StrSql = "SELECT Count(*) FROM FB_Configuration WHERE PropertyName='" & Trim(txtPropertyName.Text) & "' AND LocationCode=" & cmbLocation.SelectedValue & " and Code<>" & Val(txtCode.Text)
        RecCount = ObjDatabase.ExecuteScalarN(StrSql)
        If RecCount > 0 Then
            MsgBox("Property Name already exists", MsgBoxStyle.Information, ModuleName)
            txtPropertyName.Focus()
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
        StrSql = "select TM.Code, TM.PropertyName as [PropertyName],TM.PropertyValue PropertyValue,LM.LocationName,TM.LocationCode "
        StrSql &= " FROM FB_Configuration TM, IM_LocationMaster LM" & _
        " WHERE TM.LocationCode=LM.Code AND TM.IsEditable='Yes' and LM.Type in(" & LOCATION_TYPE & ")"
        StrSql &= IIf(txtProprtyValueSearch.Text <> "", " AND PropertyValue like '" & txtProprtyValueSearch.Text & "%'", "")
        StrSql &= IIf(txtPropertyNameSearch.Text <> "", " AND PropertyName like '" & txtPropertyNameSearch.Text & "%'", "")
        StrSql &= IIf(cmbLocationSearch.SelectedValue > 0, " AND TM.LocationCode=" & cmbLocationSearch.SelectedValue, "")
        ds = ObjDatabase.BindDataSet(StrSql, "Data")
        dgsearch.DataSource = ds
        dgsearch.DataMember = "Data"
        FormatDataGridView(dgsearch)

        dgsearch.Columns("Code").Width = 50
        dgsearch.Columns("Code").HeaderText = "Code"
        dgsearch.Columns("LocationCode").Visible = False

        dgsearch.Columns("PropertyName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("PropertyName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("PropertyName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgsearch.Columns("PropertyName").HeaderText = "PropertyName"

        dgsearch.Columns("PropertyValue").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("PropertyValue").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("PropertyValue").Width = 200

        dgsearch.Columns("LocationName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("LocationName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("LocationName").Width = 150
        dgsearch.Columns("LocationName").HeaderText = "Location"

        dgsearch.Columns(0).HeaderText = ""
        dgsearch.Columns(0).Width = 30
        dgsearch.RowHeadersVisible = True
        dgsearch.RowHeadersWidth = 20
        LabelRecordCount.Text = "Record Count: " & dgsearch.Rows.Count
        FormatLabel("search")
    End Sub

    Private Sub txtDescriptionSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProprtyValueSearch.TextChanged, txtPropertyNameSearch.TextChanged
        BindGridForSearch()
    End Sub


    Private Sub cmbLocationSearch_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLocationSearch.Validated
        BindGridForSearch()
    End Sub
End Class