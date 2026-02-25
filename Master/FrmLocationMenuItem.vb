Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmLocationMenuItem
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
        BindComboboxWithSelectOneNumeric("select Code, MaingroupName from  IM_MainGroupMaster where Code in(" & REST_MAINGROUPS & "," & BAR_MAINGROUPS & ") ", "Code", "MaingroupName", cmbMainGroup)
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
                StrSql = "Delete From FB_LocationItemLink Where LocationCode=" & Val(cmbLocation.SelectedValue) & ""
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()
                For Me.ctr = 0 To dtLocationMenu.Rows.Count - 1
                    StrSql = "Insert into FB_LocationItemLink(MainGroupCode, ItemCode, LocationCode, CreationDate, ModificationDate, UserCode)" & _
                    " values (" & Val(cmbMainGroup.SelectedValue) & _
                    "," & dgLocationMenu.Item("ItemCode", ctr).Value & _
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
            ErrorProvider1.SetError(cmbMainGroup, "Select Main GroupName")
            validation = False
            cmbMainGroup.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If Val(cmbItem.SelectedValue) = 0 Then
            ErrorProvider1.SetError(cmbItem, "Select GroupName")
            validation = False
            cmbItem.Focus()
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
        StrSql = "Select LG.MainGroupCode,LG.ItemCode,IM.ItemName,LG.LocationCode,LM.LocationName" & _
        " From FB_LocationItemLink LG,IM_ItemMaster IM,IM_LocationMaster LM" & _
        " where IM.ItemCode=LG.ItemCode and LM.Code=LG.LocationCode and LG.LocationCode=" & Val(cmbLocation.SelectedValue) & ""
        ds = New DataSet
        dtLocationMenu = New DataTable
        ds = ObjDatabase.BindDataSet(StrSql, "LinkGroup")
        dtLocationMenu = ds.Tables("LinkGroup")
        dgLocationMenu.DataSource = dtLocationMenu
        FormatDataGridView(dgLocationMenu)
        dgLocationMenu.RowHeadersVisible = True
        dgLocationMenu.Columns("MainGroupCode").Visible = False
        dgLocationMenu.Columns("ItemCode").Visible = False
        dgLocationMenu.Columns("LocationCode").Visible = False
        dgLocationMenu.Columns("ItemName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLocationMenu.Columns("ItemName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgLocationMenu.Columns("ItemName").Width = 260
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
            If ((dgLocationMenu.Item("ItemCode", ctr).Value = cmbItem.SelectedValue) And (dgLocationMenu.Item("LocationCode", ctr).Value = cmbLocation.SelectedValue)) Then
                MsgBox("Entry in this Combination already entered", MsgBoxStyle.Information, ModuleName)
                Exit Sub
            End If
        Next
        Try
            drLocationMenu = dtLocationMenu.NewRow
            drLocationMenu.Item("MainGroupCode") = Val(cmbMainGroup.SelectedValue & "")
            drLocationMenu.Item("ItemCode") = Val(cmbItem.SelectedValue & "")
            drLocationMenu.Item("ItemName") = Trim(cmbItem.Text)
            drLocationMenu.Item("LocationCode") = Val(cmbLocation.SelectedValue)
            drLocationMenu.Item("LocationName") = Trim(cmbLocation.Text & "")
            dtLocationMenu.Rows.Add(drLocationMenu)
            dtLocationMenu.AcceptChanges()
            dgLocationMenu.DataSource = dtLocationMenu
            cmbItem.Focus()
            labelRecordCount.Text = "Record Count: " & dgLocationMenu.RowCount
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbMainGroup_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMainGroup.Validated
        BindComboboxWithSelectOneNumeric("Select ItemCode,ItemName From IM_ItemMaster Where MainGroup=" & Val(cmbMainGroup.SelectedValue) & " and [Status]='Active'", "ItemCode", "ItemName", cmbItem)
    End Sub

    Private Sub dgLocationMenu_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLocationMenu.CellContentClick
        If e.ColumnIndex = 0 Then
            If dgLocationMenu.Rows.Count > 0 Then
                cmbItem.SelectedValue = dtLocationMenu.Rows(dgLocationMenu.CurrentRow.Index).Item("ItemCode")
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

    Private Sub PanelEntry_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelEntry.Paint

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class