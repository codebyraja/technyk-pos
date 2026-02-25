Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmSmartCardBalanceEnquiry
    Dim objDatabase As New Database
    Dim strsql As String
    Dim ds As DataSet
    
    Private Sub FrmSmartCardBalanceEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objDatabase.ConnectDatabse()
        txtMemberid.Focus()
        Message = "Provide the Search Criteria, then press <Tab>"
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        BackToMainScreen = True
        Me.Dispose()

    End Sub

    Private Sub txtMemberid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMemberid.TextChanged
        If txtMemberid.Text = "" Then
            lblMemID.Text = ""
            lblCategory.Text = ""
            lblName.Text = ""
            lblStatus.Text = ""
            lblUsableBalance.Text = ""
            txtMemberid.Focus()
        End If
    End Sub

    Private Sub btnShowBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowBalance.Click
        GetMemberCardDetails()
    End Sub

    Private Sub GetMemberCardDetails()
        Dim CategoryType As String = GetMemberType(txtMemberid.Text).ToUpper()
        If CategoryType.Length <> 0 Then
            If (CategoryType = "NONMEMBER") Then
                Try
                    strsql = "Select MemberID,IssuedName,IssueNo,0 as  Amount,IssuedID  From CM_CardIssue" & _
                    " where MemberID='" & Trim(txtMemberid.Text) & "' and Flag in('Y')"
                    ds = New DataSet
                    ds = objDatabase.BindDataSet(strsql, "Member")
                    If ds.Tables(0).Rows.Count = 0 Then
                        MsgBox("Invalid M_ID/C_ID", MsgBoxStyle.Information, "Information")
                        txtMemberid.Text = ""
                        txtMemberid.Focus()
                    Else
                        txtMemberid.Text = Trim(ds.Tables("Member").Rows(0)("MemberID"))
                        lblMemID.Text = Trim(ds.Tables("Member").Rows(0)("IssuedID"))
                        lblName.Text = Trim(ds.Tables("Member").Rows(0)("IssuedName"))
                        txtIssueNo.Text = Trim(ds.Tables("Member").Rows(0)("IssueNo"))
                        lblStatus.Text = "Active"
                        lblCategory.Text = "Non Member"
                        txtMemberid.Text = txtMemberid.Text
                    End If
                Catch ex As Exception
                End Try
            Else
                Try
                    strsql = "Select MemberID,OldMemNo,CategoryName,Full_Name,SM.StatusName from MM_MemberProfile M, AC_Category C, AC_StatusMaster SM where (M.MemberID= '" & Trim(txtMemberid.Text) & "' or M.OldMemNo='" & Trim(txtMemberid.Text) & "')" & _
                    " and M.CategoryCode=C.CategoryCode and SM.StatusCode=M.StatusCode"
                    ds = New DataSet
                    ds = objDatabase.BindDataSet(strsql, "Member")
                    If ds.Tables(0).Rows.Count = 0 Then
                        MsgBox("Invalid M_ID/C_ID", MsgBoxStyle.Information, "Information")
                        txtMemberid.Text = ""
                        txtMemberid.Focus()
                    Else
                        txtMemberid.Text = Trim(ds.Tables("Member").Rows(0)("MemberID"))
                        lblName.Text = Trim(ds.Tables("Member").Rows(0)("Full_Name"))
                        lblMemID.Text = Trim(ds.Tables("Member").Rows(0)("OldMemNo"))
                        lblCategory.Text = Trim(ds.Tables("Member").Rows(0)("CategoryName"))
                        lblStatus.Text = Trim(ds.Tables("Member").Rows(0)("StatusName"))
                        objDatabase.ConnectDatabse()
                        txtIssueNo.Text = objDatabase.ExecuteScalar("Select IssueNo FROM CM_CardIssue WHERE MemberID='" & txtMemberid.Text & "'")
                        txtIssueNo.Text = Val(txtIssueNo.Text)
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
        If txtMemberid.Text <> "" Then
            lblUsableBalance.Text = GetSmartCardClosingBalance(txtMemberid.Text).ToString(NumFormat)
        End If
    End Sub
End Class