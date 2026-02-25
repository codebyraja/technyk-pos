Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class frmSpouseEnquiry
    Dim objDatabase As New Database
    Dim ds As DataSet
    Dim TopRecord As String
    Dim strsql As String

    Private Sub frmSpouseEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGrid(200)
        txtC_ID.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        BackToMainScreen = True
        Me.Dispose()

    End Sub

    Public Sub BindGrid(ByVal RecordCount As Integer)
        If RecordCount = 200 Then
            TopRecord = " Top 200 "
        Else
            TopRecord = " Top 100 PERCENT "
        End If
        ds = New DataSet
        strsql = ""
        strsql = "Select " & TopRecord & " MP.MemberID [C_ID],MP.OldMemNo [M_ID], MP.Full_Name as MemberName, SP.Name as SpouseName," & vbCrLf & _
        " isnull(SP.DoB,'01-01-1900') as DOB, SP.MobileNo as Mobile" & vbCrLf & _
        ",SP.Email_ID as Email, ISNULL(SP.AnniversaryDate,'" & DateNotAvailable & "') as Anniversary" & vbCrLf & _
        " FROM MM_SpouseProfile SP, MM_MemberProfile MP " & vbCrLf & _
        " where SP.MemberID = MP.MemberID" & _
        IIf(txtC_ID.Text <> "", "  and SP.MemberID like '" & txtC_ID.Text.Trim & "%'", "") & _
        IIf(txtSpouseName.Text <> "", " and SP.Name like '" & txtSpouseName.Text & "%'", "") & _
        IIf(txtM_ID.Text <> "", "  and MP.OldMemNo like '" & txtM_ID.Text & "%'", "") & vbCrLf & _
        IIf(txtEmail.Text <> "", " and SP.Email_ID like '%" & txtEmail.Text & "%'", "") & _
        IIf(txtMobile.Text <> "", "  and SP.MobileNo like '" & txtMobile.Text & "%'", "") & _
        IIf(txtMemberName.Text <> "", " and MP.Full_Name like '%" & txtMemberName.Text & "%'", "") & vbCrLf & _
        IIf(chbDateOfBirthTo.Checked = True, " and convert(int, DAY(SP.dob)) <= '" & Format(dtpDoBTo.Value, "dd") & "'", "") & _
        IIf(chbDateOfBirthTo.Checked = True, " and convert(int, month(SP.dob)) <= '" & Format(dtpDoBTo.Value, "MM") & "'", "") & _
        IIf(chbAnniversaryDateFrom.Checked = True, " and convert(int, DAY(SP.AnniversaryDate)) >= '" & Format(dtpAnniversaryDateFrom.Value, "dd") & "'", "") & _
        IIf(chbAnniversaryDateFrom.Checked = True, " and convert(int, month(SP.AnniversaryDate)) >= '" & Format(dtpAnniversaryDateFrom.Value, "MM") & "'", "") & _
        IIf(chbAnniversaryDateTo.Checked = True, " and convert(int, DAY(SP.AnniversaryDate)) <= '" & Format(dtpAnniversaryDateTo.Value, "dd") & "'", "") & _
        IIf(chbAnniversaryDateTo.Checked = True, " and convert(int, month(SP.AnniversaryDate)) <= '" & Format(dtpAnniversaryDateTo.Value, "MM") & "'", "")

        ds = objDatabase.BindDataSet(strsql, "Enquiry")
        dgSearch.DataSource = ds
        dgSearch.DataMember = "Enquiry"
        FormatDataGridView(dgSearch)
        dgSearch.RowHeadersVisible = True
        FormatGrid()
    End Sub

    Private Sub FormatGrid()
        dgSearch.Columns("C_ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("C_ID").HeaderText = "C_ID"
        dgSearch.Columns("C_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("M_ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("M_ID").HeaderText = "M_ID"
        dgSearch.Columns("M_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("MemberName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("MemberName").HeaderText = "MemberName"
        dgSearch.Columns("MemberName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("SpouseName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("SpouseName").HeaderText = "SpouseName"
        dgSearch.Columns("SpouseName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("DOB").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("DOB").HeaderText = "DOB"
        dgSearch.Columns("DOB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("DOB").DefaultCellStyle.Format = "dd/MMM/yyyy"
        dgSearch.Columns("Mobile").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("Mobile").HeaderText = "Mobile"
        dgSearch.Columns("Mobile").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("Email").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("Email").HeaderText = "Email"
        dgSearch.Columns("Email").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgSearch.Columns("C_ID").Width = 70
        dgSearch.Columns("M_ID").Width = 70
        dgSearch.Columns("MemberName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgSearch.Columns("SpouseName").Width = 150
        dgSearch.Columns("DOB").Width = 90
        dgSearch.Columns("Mobile").Width = 90
        dgSearch.Columns("Email").Width = 165
        dgSearch.Columns("Anniversary").Width = 90
        dgSearch.Columns("C_ID").ReadOnly = True
        dgSearch.Columns("M_ID").ReadOnly = True
        dgSearch.Columns("MemberName").ReadOnly = True
        dgSearch.Columns("SpouseName").ReadOnly = True
        dgSearch.Columns("DOB").ReadOnly = True
        dgSearch.Columns("Mobile").ReadOnly = True
        dgSearch.Columns("Email").ReadOnly = True
        dgSearch.RowHeadersVisible = True
        dgSearch.RowHeadersWidth = 20
        lblRecordCount.Text = "Record Count: " & dgSearch.RowCount
    End Sub

    Private Sub ControlText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtC_ID.TextChanged, txtM_ID.TextChanged, txtSpouseName.TextChanged, txtEmail.TextChanged, txtMobile.TextChanged, txtMemberName.TextChanged
        BindGrid(0)
    End Sub

    Private Sub dtpAnniversaryDateFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAnniversaryDateFrom.ValueChanged, dtpDoBTo.ValueChanged, dtpAnniversaryDateTo.ValueChanged, dtpDoBFrom.ValueChanged
        BindGrid(0)
    End Sub
    
End Class