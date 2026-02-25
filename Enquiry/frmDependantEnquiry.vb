Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class frmDependantEnquiry
    Dim objDatabase As New Database
    Dim strsql As String
    Dim ds As DataSet
    Dim TopRecords As String

    Private Sub frmDependantEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindComboboxWithSelectOneNumeric("Select Code, [DepStatus] from [AC_DepStatus]", "Code", "DepStatus", cmbStatus)
        BindGrid(200)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        BackToMainScreen = True
        Me.Dispose()
    End Sub

    Public Sub BindGrid(ByVal RecordCount As Integer)
        If RecordCount = 200 Then
            TopRecords = " Top 200 "
        Else
            TopRecords = " Top 100 PERCENT "
        End If
        strsql = "Select " & TopRecords & " MP.MemberID,MP.OldMemNo [M_ID], MP.Full_Name  MemberName,DP.DepID DepID, DP.Name DepName," & _
        " isnull(DP.DOB,'01-01-1900') as DOB,  DP.MobileNo Mobile,DP.Email_ID as Email, DP.Status Status ,DP.Gender Gender" & _
        " FROM MM_DependantProfile DP, MM_MemberProfile MP where DP.MemberID = MP.MemberID " & _
        IIf(txtC_ID.Text <> "", " and MP.MemberID like '" & txtC_ID.Text.Trim & "%'", "") & _
        IIf(txtMemID.Text <> "", " and MP.OldMemNo like '" & txtMemID.Text.Trim & "%'", "") & _
        IIf(txtEmail.Text <> "", " and DP.Email_ID like '%" & txtEmail.Text & "%'", "") & _
        IIf(txtMobile.Text <> "", " and DP.MobileNo like '" & txtMobile.Text & "%'", "") & _
        IIf(txtMemName.Text <> "", " and MP.Full_Name like '%" & txtMemName.Text & "%'", "") & _
        IIf(txtDepName.Text <> "", " and DP.Name like '" & txtDepName.Text.Trim & "%'", "") & _
        IIf(cmbStatus.Text <> "", " and DP.Status like '%" & cmbStatus.Text.Trim & "%'", "") & _
        IIf(ChbDateOfBirth.Checked = True, " and DP.DOB between '" & dtpDoBFromDate.Value.ToString(DateFormat) & "' and '" & Format(dtpDoBToDate.Value.ToString(DateFormat) & "'", ""), "")
        ds = objDatabase.BindDataSet(strsql, "Enquiry")
        dgsearch.DataSource = ds
        dgsearch.DataMember = "Enquiry"
        FormatDataGridView(dgsearch)
        dgsearch.RowHeadersVisible = True
        FormatGrid()
        lblRecordCount.Visible = True
        lblRecordCount.Text = "Record Count: " & ds.Tables(0).Rows.Count
        dgsearch.Columns(0).Visible = False
    End Sub

    Private Sub FormatGrid()
        dgsearch.Columns("MemberID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("MemberID").HeaderText = "C_ID"
        dgsearch.Columns("MemberID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("M_ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("M_ID").HeaderText = "M_ID"
        dgsearch.Columns("M_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgsearch.Columns("MemberName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("MemberName").HeaderText = "MemberName"
        dgsearch.Columns("MemberName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgsearch.Columns("DepID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("DepID").HeaderText = "DepID"
        dgsearch.Columns("DepID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgsearch.Columns("DepName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("DepName").HeaderText = "DependantName"
        dgsearch.Columns("DepName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgsearch.Columns("DOB").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgsearch.Columns("DOB").HeaderText = "DOB"
        dgsearch.Columns("DOB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgsearch.Columns("DOB").DefaultCellStyle.Format = "dd/MM/yyyy"

        dgsearch.Columns("Mobile").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("Mobile").HeaderText = "Mobile"
        dgsearch.Columns("Mobile").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgsearch.Columns("Email").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("Email").HeaderText = "Email"
        dgsearch.Columns("Email").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgsearch.Columns("Status").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("Status").HeaderText = "Status"
        dgsearch.Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("Gender").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgsearch.Columns("Gender").HeaderText = "Gender"
        dgsearch.Columns("Gender").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgsearch.Columns("MemberID").Width = 65

        dgsearch.Columns("M_ID").Width = 65
        dgsearch.Columns("MemberName").Width = 150
        dgsearch.Columns("DepID").Width = 85
        dgsearch.Columns("DepName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgsearch.Columns("DOB").Width = 90
        dgsearch.Columns("Mobile").Width = 100
        dgsearch.Columns("Email").Width = 150
        dgsearch.Columns("Status").Width = 60
        dgsearch.Columns("Gender").Width = 60
        dgsearch.RowHeadersVisible = True
        dgsearch.RowHeadersWidth = 20
        dgsearch.Columns("MemberID").ReadOnly = True
        dgsearch.Columns("M_ID").ReadOnly = True
        dgsearch.Columns("MemberName").ReadOnly = True
        dgsearch.Columns("DepID").ReadOnly = True
        dgsearch.Columns("DepName").ReadOnly = True
        dgsearch.Columns("DOB").ReadOnly = True
        dgsearch.Columns("Mobile").ReadOnly = True
        dgsearch.Columns("Email").ReadOnly = True
        dgsearch.Columns("Status").ReadOnly = True
        dgsearch.Columns("Gender").ReadOnly = True
        lblRecordCount.Text = "Record Count: " & dgsearch.RowCount
    End Sub

    Private Sub txtChange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMobile.TextChanged, txtMemName.TextChanged, txtEmail.TextChanged, txtDepName.TextChanged, txtMemID.TextChanged, txtC_ID.TextChanged
        BindGrid(0)
    End Sub

    Private Sub cmbstatus_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatus.Validated
        BindGrid(0)
    End Sub

    Private Sub ChbDateOfBirth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChbDateOfBirth.CheckedChanged
        If ChbDateOfBirth.Checked = True Then
            BindGrid(0)
        Else
            ChbDateOfBirth.Checked = False
            BindGrid(0)
        End If
    End Sub

    Private Sub dtpDoBFromDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDoBFromDate.ValueChanged
        BindGrid(0)
    End Sub

    Private Sub dtpDoBToDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDoBToDate.ValueChanged
        BindGrid(0)
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged

    End Sub
End Class