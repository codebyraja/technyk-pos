Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmLocationMenu
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand
    Dim ds As New DataSet
    Dim drLocationMenu As DataRow
    Dim dtLocationMenu As DataTable
    Dim ctr As Integer = 0

    Private Sub FrmLinkGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisableControl(Me.PanelEntry)
        ClearText(Me)
        EnableButton("Cancel", Me)
        BindComboboxWithSelectOneNumeric("Select Code,LocationName From IM_LocationMaster where Type in (" & LOCATION_TYPE & ")", "Code", "LocationName", cmbLocation)
        BindComboboxWithSelectOneNumeric("select Code, MaingroupName from  IM_MainGroupMaster where Code in(" & POSMainGroup & ") ", "Code", "MaingroupName", cmbMainGroup)
        cmbMainGroup.SelectedValue = 0
        BindGridForSearch()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (btnAdd.Text = "Add") Then
            ClearText(Me)
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
                If dtLocationMenu.Rows.Count = 0 Then
                    MsgBox("No Records to Save", MsgBoxStyle.Information)
                    Exit Sub
                End If
                StrSql = "Delete From FB_LocationGroupLink Where LocationCode=" & Val(cmbLocation.SelectedValue) & ""
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()
                For Me.ctr = 0 To dtLocationMenu.Rows.Count - 1
                    StrSql = "Insert into FB_LocationGroupLink(MainGroupCode, GroupCode, LocationCode, CreationDate, ModificationDate, UserCode)" & _
                    " values (" & Val(cmbMainGroup.SelectedValue) & _
                    "," & dgLocationMenu.Item("GroupCode", ctr).Value & _
                    "," & dgLocationMenu.Item("LocationCode", ctr).Value & _
                    ",getdate()" & _
                    ",getdate()" & _
                    "," & UserCode & _
                    ")"
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()
                Next
                myTrans.Commit()
                MsgBox("Record Saved Successfully", MsgBoxStyle.Information)
                ClearText(Me.PanelEntry)
                DisableControl(Me.PanelEntry)
                EnableButton("Cancel", Me)
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
        EnableButton("Cancel", Me)
        ClearText(Me.PanelEntry)
        DisableControl(Me.PanelEntry)
        BindGridForSearch()
        ErrorProvider1.Dispose()
    End Sub

    Private Function validation() As Boolean
        If Val(cmbLocation.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbLocation, "Select LocationName")
            validation = False
            cmbLocation.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If Val(cmbMainGroup.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbMainGroup, "Select Main Group Name")
            validation = False
            cmbMainGroup.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If Val(cmbGroup.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbGroup, "Select Group Name")
            validation = False
            cmbGroup.Focus()
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

    Private Sub BindGridForSearch()
        StrSql = "Select LG.MainGroupCode,LG.GroupCode,IG.GroupName,LG.LocationCode,LM.LocationName" & _
        " From FB_LocationGroupLink LG,IM_GroupMaster IG,IM_LocationMaster LM" & _
        " where IG.Code=LG.GroupCode and LM.Code=LG.LocationCode and LG.LocationCode=" & Val(cmbLocation.SelectedValue) & ""
        ds = New DataSet
        dtLocationMenu = New DataTable
        ds = ObjDatabase.BindDataSet(StrSql, "LinkGroup")
        dtLocationMenu = ds.Tables("LinkGroup")
        dgLocationMenu.DataSource = dtLocationMenu
        FormatDataGridView(dgLocationMenu)
        dgLocationMenu.RowHeadersVisible = True
        dgLocationMenu.Columns("MainGroupCode").Visible = False
        dgLocationMenu.Columns("GroupCode").Visible = False
        dgLocationMenu.Columns("LocationCode").Visible = False
        dgLocationMenu.Columns("GroupName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLocationMenu.Columns("GroupName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLocationMenu.Columns("GroupName").Width = 260
        dgLocationMenu.Columns("LocationName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLocationMenu.Columns("LocationName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLocationMenu.Columns("LocationName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgLocationMenu.RowHeadersVisible = True
        dgLocationMenu.Columns(0).Width = 30
        dgLocationMenu.Columns(1).Width = 30
        dgLocationMenu.Cursor = Cursors.Hand
        labelRecordCount.Text = "Record Count: " & dgLocationMenu.RowCount
        FormatLabel("search")
    End Sub

    Private Sub btnAddGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGroup.Click
        If validation() = False Then Exit Sub
        For ctr = 0 To dgLocationMenu.RowCount - 1
            If ((dgLocationMenu.Item("GroupCode", ctr).Value = cmbGroup.SelectedValue) And (dgLocationMenu.Item("LocationCode", ctr).Value = cmbLocation.SelectedValue)) Then
                MsgBox("Entry in this Combination already entered", MsgBoxStyle.Information, ModuleName)
                Exit Sub
            End If
        Next
        Try
            drLocationMenu = dtLocationMenu.NewRow
            drLocationMenu.Item("MainGroupCode") = Val(cmbMainGroup.SelectedValue & "")
            drLocationMenu.Item("GroupCode") = Val(cmbGroup.SelectedValue & "")
            drLocationMenu.Item("GroupName") = Trim(cmbGroup.Text)
            drLocationMenu.Item("LocationCode") = Val(cmbLocation.SelectedValue)
            drLocationMenu.Item("LocationName") = Trim(cmbLocation.Text & "")
            dtLocationMenu.Rows.Add(drLocationMenu)
            dtLocationMenu.AcceptChanges()
            dgLocationMenu.DataSource = dtLocationMenu
            cmbGroup.Focus()
            labelRecordCount.Text = "Record Count: " & dgLocationMenu.RowCount
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbMainGroup_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMainGroup.Validated
        BindComboboxWithSelectOneNumeric("Select Code,groupName From IM_GroupMaster Where MainGroupCode=" & Val(cmbMainGroup.SelectedValue), "Code", "groupName", cmbGroup)
    End Sub

    Private Sub dgLocationMenu_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLocationMenu.CellContentClick
        If e.ColumnIndex = 0 Then
            If dgLocationMenu.Rows.Count > 0 Then
                cmbGroup.SelectedValue = dtLocationMenu.Rows(dgLocationMenu.CurrentRow.Index).Item("GroupCode")
                cmbLocation.SelectedValue = dtLocationMenu.Rows(dgLocationMenu.CurrentRow.Index).Item("LocationCode")
                dtLocationMenu.Rows(dgLocationMenu.CurrentRow.Index).Delete()
                dtLocationMenu.AcceptChanges()
                dgLocationMenu.DataSource = dtLocationMenu
            End If
        ElseIf e.ColumnIndex = 1 Then
            If dgLocationMenu.Rows.Count > 0 Then
                dtLocationMenu.Rows(dgLocationMenu.CurrentRow.Index).Delete()
                dtLocationMenu.AcceptChanges()
                dgLocationMenu.DataSource = dtLocationMenu
            End If
        End If
    End Sub

    Private Sub cmbLocation_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLocation.Validated
        BindGridForSearch()
    End Sub

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

    Private Sub PanelFooter_Paint(sender As Object, e As PaintEventArgs) Handles PanelFooter.Paint
        CenterButtonsInPanel(PanelFooter)
    End Sub
End Class