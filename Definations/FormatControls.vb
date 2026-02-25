Imports System.Data.SqlClient

Module FormatControls

    Public AddRight, EditRight, SearchRight, DeleteRight As Integer

    Public Sub ClearText(ByVal frm As Object)
        Dim ctl As New Control
        Dim txtbox As TextBox
        Dim lbl As Label
        Dim combo As ComboBox
        Dim chb As CheckBox
        Dim dtp As DateTimePicker
        Dim grid As DataGrid
        Dim gridv As DataGridView
        Dim pict As PictureBox
        For Each ctl In frm.Controls
            If ctl.Controls.Count > 0 Then
                ClearText(ctl)
            ElseIf TypeOf (ctl) Is TextBox Then
                txtbox = ctl
                txtbox.Text = ""
            ElseIf TypeOf (ctl) Is Label Then
                lbl = ctl
                If lbl.Name.StartsWith("lbl") Then lbl.Text = ""
            ElseIf TypeOf (ctl) Is ComboBox Then
                combo = ctl
                combo.SelectedValue = 0
            ElseIf TypeOf (ctl) Is CheckBox Then
                chb = ctl
                chb.Checked = False
            ElseIf TypeOf (ctl) Is DataGrid Then
                grid = ctl
                grid.Text = ""
            ElseIf TypeOf (ctl) Is DataGridView Then
                gridv = ctl
                gridv.Text = ""
            ElseIf TypeOf (ctl) Is DateTimePicker Then
                dtp = ctl
                dtp.Value = Now.ToString("dd/MMM/yyyy")
            ElseIf TypeOf (ctl) Is PictureBox Then
                pict = ctl
                pict.Image = Nothing
            End If
        Next
    End Sub

    Public Sub EnableControl(ByVal frm As Object)
        Dim ctl As New Control
        Dim txtBox As TextBox
        Dim lbl As Label
        Dim cmbBox As ComboBox
        Dim grid As DataGridView
        Dim dtp As DateTimePicker
        Dim lstBox As ListBox
        Dim btn As Button
        Dim chkBox As CheckBox
        Dim RadioBtn As RadioButton
        For Each ctl In frm.Controls
            If ctl.Controls.Count > 0 Then
                EnableControl(ctl)
            ElseIf TypeOf (ctl) Is TextBox And ((LCase(ctl.Name) = "txtCode")) Then
                txtBox = ctl
                txtBox.ReadOnly = True
            ElseIf TypeOf (ctl) Is TextBox And ((LCase(ctl.Name) <> "txtCode")) Then
                txtBox = ctl
                txtBox.Enabled = True
            ElseIf TypeOf (ctl) Is Label Then
                lbl = ctl
                lbl.TextAlign = ContentAlignment.MiddleLeft
            ElseIf TypeOf (ctl) Is ComboBox Then
                cmbBox = ctl
                cmbBox.Enabled = True
            ElseIf TypeOf (ctl) Is DataGridView Then
                grid = ctl
                grid.Enabled = True
            ElseIf TypeOf (ctl) Is CheckBox Then
                chkBox = ctl
                chkBox.Enabled = True
                chkBox.Checked = False
            ElseIf TypeOf (ctl) Is ListBox Then
                lstBox = ctl
                lstBox.Enabled = True
            ElseIf TypeOf (ctl) Is DateTimePicker Then
                dtp = ctl
                dtp.Enabled = True
            ElseIf TypeOf (ctl) Is RadioButton Then
                RadioBtn = ctl
                RadioBtn.Enabled = True
                RadioBtn.Checked = False
            ElseIf TypeOf (ctl) Is Button Then
                btn = ctl
                btn.Cursor = Cursors.Hand
                btn.Enabled = True
            End If
        Next
    End Sub

    Public Sub DisableControl(ByVal frm As Object)
        Dim ctl As New Control
        Dim btn As Button
        Dim txtBox As TextBox
        Dim cmbBox As ComboBox
        Dim grid As DataGridView
        Dim lstBox As ListBox
        Dim chkBox As CheckBox
        Dim RadioBtn As RadioButton
        Dim dtp As DateTimePicker
        For Each ctl In frm.Controls
            If ctl.Controls.Count > 0 Then
                DisableControl(ctl)
            ElseIf TypeOf (ctl) Is TextBox And Not UCase(ctl.Name) = "txtCode" Then
                txtBox = ctl
                txtBox.Enabled = False
            ElseIf TypeOf (ctl) Is ComboBox Then
                cmbBox = ctl
                cmbBox.Enabled = False
            ElseIf TypeOf (ctl) Is DataGridView Then
                grid = ctl
                grid.Enabled = False
            ElseIf TypeOf (ctl) Is CheckBox Then
                chkBox = ctl
                chkBox.Enabled = False
            ElseIf TypeOf (ctl) Is ListBox Then
                lstBox = ctl
                lstBox.Enabled = False
            ElseIf TypeOf (ctl) Is DateTimePicker Then
                dtp = ctl
                dtp.Enabled = False
            ElseIf TypeOf (ctl) Is RadioButton Then
                RadioBtn = ctl
                RadioBtn.Enabled = False
            ElseIf TypeOf (ctl) Is Button Then
                btn = ctl
                If ctl.Text = "Add" Or ctl.Text = "Edit" Or ctl.Text = "Delete" Or ctl.Text = "Search" Or ctl.Text = "Cancel" Or ctl.Text = "Close" Then
                    btn.Enabled = True
                Else
                    btn.Enabled = False
                End If
            End If
        Next
    End Sub

    Public Sub EnableButton(ByVal btnText As String, ByVal frm As Object)
        Dim ctl As New Control
        Dim btnAdd As Button
        Dim btnEdit As Button
        Dim btnDelete As Button
        Dim btnCancel As Button
        Dim btnSearch As Button
        Dim btnSet As Boolean
        btnSet = False
        For Each ctl In frm.Controls
            If ctl.Controls.Count > 0 Then
                EnableButton(btnText, ctl)
            ElseIf TypeOf (ctl) Is Button Then
                If Trim(UCase(ctl.Text)) = "ADD" Or Trim(UCase(ctl.Text)) = "SAVE" Then
                    btnAdd = ctl
                    btnSet = True
                ElseIf Trim(UCase(ctl.Text)) = "EDIT" Or Trim(UCase(ctl.Text)) = "UPDATE" Then
                    btnEdit = ctl
                    btnSet = True
                ElseIf Trim(UCase(ctl.Text)) = "DELETE" Then
                    btnDelete = ctl
                    btnSet = True
                ElseIf Trim(UCase(ctl.Text)) = "CANCEL" Then
                    btnCancel = ctl
                    btnSet = True
                ElseIf Trim(UCase(ctl.Text)) = "SEARCH" Then
                    btnSearch = ctl
                    btnSet = True
                End If
            End If
        Next
        If btnSet = True Then

            Try
                If btnText.ToUpper = "ADD" Then
                    If Not btnAdd Is Nothing Then
                        If AddRight = 1 Then btnAdd.Enabled = True Else btnAdd.Enabled = False
                        If AddRight = 1 Then btnAdd.Text = "Save" Else btnAdd.Text = "Add"
                        If AddRight = 1 Then btnAdd.Focus()
                    End If
                    If Not btnEdit Is Nothing Then
                        btnEdit.Enabled = False
                        btnEdit.Text = "Edit"
                        btnEdit.Focus()
                    End If
                    If Not btnSearch Is Nothing Then
                        If SearchRight = 1 Then btnSearch.Enabled = True Else btnSearch.Enabled = False
                        btnSearch.Enabled = False
                    End If
                    If Not btnCancel Is Nothing Then
                        btnCancel.Enabled = True
                    End If
                ElseIf btnText.ToUpper = "EDIT" Then
                    If Not btnEdit Is Nothing Then
                        If EditRight = 1 Then btnEdit.Enabled = True Else btnEdit.Enabled = False
                    End If
                    If Not btnEdit Is Nothing Then
                        If EditRight = 1 Then btnEdit.Text = "Edit"
                    End If
                    If Not btnDelete Is Nothing Then
                        btnDelete.Enabled = True
                    End If
                    If Not btnAdd Is Nothing Then
                        btnAdd.Enabled = False
                        btnAdd.Text = "Add"
                    End If
                    If Not btnSearch Is Nothing Then
                        btnSearch.Enabled = False
                    End If
                    If Not btnCancel Is Nothing Then
                        btnCancel.Enabled = True
                    End If
                ElseIf btnText.ToUpper = "SEARCH" Then
                    If Not btnSearch Is Nothing Then
                        If SearchRight = 1 Then btnSearch.Enabled = True Else btnSearch.Enabled = False
                    End If
                    If Not btnSearch Is Nothing Then
                        btnSearch.Enabled = False
                    End If
                    If Not btnCancel Is Nothing Then
                        btnCancel.Enabled = True
                    End If
                    If Not btnAdd Is Nothing Then
                        btnAdd.Enabled = False
                    End If
                ElseIf btnText.ToUpper = "CANCEL" Or btnText.ToUpper = "LOAD" Then
                    If Not btnAdd Is Nothing Then
                        If AddRight = 1 Then btnAdd.Enabled = True Else btnAdd.Enabled = False
                    End If
                    If Not btnSearch Is Nothing Then
                        If SearchRight = 1 Then btnSearch.Enabled = True Else btnSearch.Enabled = False
                    End If
                    If Not btnEdit Is Nothing Then
                        btnEdit.Enabled = False
                        btnEdit.Text = "Edit"
                    End If
                    If Not btnDelete Is Nothing Then
                        btnDelete.Enabled = False
                    End If
                    If Not btnAdd Is Nothing Then
                        btnAdd.Text = "Add"
                    End If
                    If Not btnCancel Is Nothing Then
                        btnCancel.Enabled = False
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Sub ControlBackColor(ByVal frm As Object)
        Dim ctl As New Control
        Dim txtBox As TextBox
        Dim cmbBox As ComboBox
        Dim grid As DataGrid
        Dim lstBox As ListBox
        Dim chkBox As CheckBox
        Dim dtp As DateTimePicker
        Dim cmd As Button
        Try
            For Each ctl In frm.Controls
                If ctl.Controls.Count > 0 Then
                    ControlBackColor(ctl)
                ElseIf TypeOf (ctl) Is TextBox And Not UCase(ctl.Name) = "txtCode" Then
                    txtBox = ctl
                    txtBox.BackColor = Color.White
                ElseIf TypeOf (ctl) Is ComboBox Then
                    cmbBox = ctl
                    cmbBox.BackColor = Color.White
                    cmbBox.Cursor = Cursors.Hand
                ElseIf TypeOf (ctl) Is DataGrid Then
                    grid = ctl
                ElseIf TypeOf (ctl) Is CheckBox Then
                    chkBox = ctl
                ElseIf TypeOf (ctl) Is ListBox Then
                    lstBox = ctl
                ElseIf TypeOf (ctl) Is DateTimePicker Then
                    dtp = ctl
                ElseIf TypeOf (ctl) Is Button Then
                    cmd = ctl
                    cmd.Cursor = Cursors.Hand
                    cmd.FlatStyle = FlatStyle.Standard
                    cmd.UseVisualStyleBackColor = True
                    cmd.ForeColor = Color.Black
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
