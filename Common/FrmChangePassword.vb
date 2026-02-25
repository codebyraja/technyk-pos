Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Net

Public Class FrmChangePassword
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand
    Dim ObjDatabase As New Database
    Dim ds As DataSet
    Dim drr As SqlDataReader
    Dim OldPassword As String = ""

    Private Sub FrmChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ObjDatabase.ConnectDatabse()
        txtUserName.Text = Trim(UserName)
        txtCurrentPassword.Focus()
        btnAdd.Text = "Save"
        txtUserName.Enabled = False
        txtCurrentPassword.Focus()
        OldPassword = ObjDatabase.ExecuteScalarString("SELECT UPassword FROM AC_UserMaster WHERE UserCode=" & UserCode)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.ErrorProvider1.Dispose()
        EnableButton("CANCEL", Me)
        txtCurrentPassword.Text = ""
        txtNewPassword.Text = ""
        txtConfirmPassword.Text = ""
        btnRefresh.Enabled = True
        Message = "Provide new Password and Click on <Save>"
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        BackToMainScreen = True
        Me.Dispose()
    End Sub

    Private Sub txtNewPassWord_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNewPassword.Validated
        If OldPassword.ToUpper() = Trim(txtNewPassword.Text).ToUpper() Then
            ErrorProvider1.SetError(txtNewPassword, "'New Password' and 'Current Password' are same")
            txtNewPassword.Text = ""
            txtNewPassword.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Trim(txtCurrentPassword.Text) = "" Then
            MsgBox("Enter 'Current Password'", MsgBoxStyle.Critical, "")
            txtCurrentPassword.Text = ""
            txtCurrentPassword.Focus()
            Exit Sub
        End If
        If Trim(txtNewPassWord.Text) = "" Then
            MsgBox("Enter 'New Password'", MsgBoxStyle.Critical, "")
            txtNewPassWord.Text = ""
            txtNewPassWord.Focus()
            Exit Sub
        End If
        If Trim(txtConfirmPassword.Text) = "" Then
            MsgBox("Enter 'Confirm Password'", MsgBoxStyle.Critical, "")
            txtConfirmPassword.Text = ""
            txtConfirmPassword.Focus()
            Exit Sub
        End If

        If Trim(txtNewPassWord.Text) <> "" And Trim(txtConfirmPassword.Text) <> "" And Trim(UCase(txtNewPassWord.Text)) <> Trim(UCase(txtConfirmPassword.Text)) Then
            MsgBox("'New Password' and 'Confirm Password' are not same", MsgBoxStyle.Critical, "")
            txtNewPassWord.Text = ""
            txtConfirmPassword.Text = ""
            txtNewPassWord.Focus()
            Exit Sub
        End If
        If OldPassword.ToUpper() = Trim(txtNewPassWord.Text).ToUpper() Then
            ErrorProvider1.SetError(txtNewPassWord, "'New Password' and 'Current Password' are same")
            txtNewPassWord.Text = ""
            txtNewPassWord.Focus()
            Exit Sub
        End If
        If Trim(txtNewPassWord.Text).Contains("'") = True Then
            ErrorProvider1.SetError(txtNewPassWord, "Single Quote(') not allowed in password")
            txtNewPassWord.Text = ""
            txtNewPassWord.Focus()
            Exit Sub
        End If
        ObjDatabase.OpenDatabaseConnection()
        myTrans = ObjDatabase.con.BeginTransaction()
        myCommand = ObjDatabase.con.CreateCommand()
        myCommand.Transaction = myTrans
        Try
            StrSql = "INSERT INTO  AC_UserMaster_Log" & _
            " SELECT *,'','' FROM AC_UserMaster WHERE UserCode = " & Val(UserCode)
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            StrSql = "UPDATE AC_UserMaster_Log SET  SystemIP='" & HOST_IP_ADDRESS & "', Sys_name='" & HOST_NAME & "',Modificationdate=getdate()" & _
            " WHERE ModificationNo =(SELECT MAX(ModificationNo) FROM AC_UserMaster_Log)"
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            StrSql = " UPDATE AC_UserMaster set " & _
            " UPassword='" & UCase(Trim(txtNewPassWord.Text)) & "'" & _
            ",ModificationDate=getdate()" & _
            " where UserCode=" & Val(UserCode) & " "
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            StrSql = "DELETE FROM AC_UserLoginInfo WHERE SessionID=" & SESSION_ID & " AND ModuleCode=" & ModuleCode & " AND UserCode=" & UserCode
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            StrSql = "UPDATE AC_UserLoginDetail SET LogOutTime=getdate() WHERE SessionID=" & SESSION_ID & " AND ModuleCode=" & ModuleCode & " AND UserCode=" & UserCode
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            myTrans.Commit()
            MsgBox("User login Password has been changed successfully." & vbCrLf & "Please Login again with your new password.", MsgBoxStyle.Information, "Information")
            txtUserName.Enabled = False
            txtNewPassWord.Text = ""
            txtConfirmPassword.Text = ""
            txtCurrentPassword.Text = ""
            End
        Catch ex As SqlException
            myTrans.Rollback()
            If ex.Number = 2627 Then
                MsgBox("Entry Already Exists, Duplication Not Allowed.", MsgBoxStyle.OkOnly, "")
            End If
            Message = "Error in Changing the user Password"
        Catch ex1 As Exception
        Finally
            myTrans.Dispose()
            ObjDatabase.CloseDatabaseConnection()
        End Try
    End Sub
End Class