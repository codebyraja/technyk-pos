Imports System.Data.SqlClient
Imports System.Net

Public Class FrmLogin
    Dim cmd As New SqlClient.SqlCommand
    Dim ds As DataSet
    Dim Code As Integer
    Dim myTran As SqlTransaction
    Dim myCommand As SqlCommand
    Dim FocussedControl As Integer
    Private mArgs() As String

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ReadConfigurations()
        ObjDatabase = New database
        ObjDatabase.ConnectDatabse()
        If LOGINTYPE = 0 Then
            LoadFinancialYear()
            LoadBillingLocation()
            GetServerCurrentDate()
            txtUserName.Text = DEFAULT_LOGIN_ID
            txtPassword.Text = DEFAULT_LOGIN_PASSWORD
            txtUserName.Focus()
        Else

            Try
                Dim Credential() As String = GetArguments(1).Split(",")
                txtUserName.Text = Credential(0)
                txtPassword.Text = Credential(1)
                YearCode = Credential(2)
                VENDOR_ID = Credential(3)
                UserCode = Credential(4)
                USERNAME = txtUserName.Text

                BindComboboxWithSelectOneNumeric("select VendorID,LoginName from CompanyInfoVendor where VendorID=" & VENDOR_ID, "VendorID", "LoginName", cmbBillingLocaion)
                cmbBillingLocaion.SelectedValue = VENDOR_ID

                BindComboboxWithSelectOneNumeric("SELECT  YearCode, FinancialYear as FinYearDesc FROM AC_FinancialYear where YearCode=" & YearCode, "YearCode", "FinYearDesc", cmbFinancialYear)
                cmbFinancialYear.SelectedValue = YearCode
                FinancialYearString = cmbFinancialYear.Text

                StrSql = "select TOP 1 Code, LocationName,Type,SubStore from IM_LocationMaster where VendorID=" & VENDOR_ID
                ds = ObjDatabase.BindDataSet(StrSql, "Location")
                If ds.Tables("Location").Rows.Count > 0 Then
                    LOCATION_Code = (ds.Tables("Location").Rows(0)("Code") & "")
                    LOCATION_NAME = (ds.Tables("Location").Rows(0)("LocationName") & "")
                    LOCATION_NAME = LOCATION_NAME
                    LOCATION_TYPE = (ds.Tables("Location").Rows(0)("Type") & "")
                    SUBSTORE_Code = (ds.Tables("Location").Rows(0)("SubStore") & "")
                End If

                StrSql = "select isnull(max([SessionId]),0)+1 FROM [AC_UserLoginDetail]"
                SESSION_ID = ObjDatabase.ExecuteScalarN(StrSql)

                StrSql = "select TypeCode FROM [AC_UserMaster] where UserCode=" & UserCode
                UserTypeCode = ObjDatabase.ExecuteScalarN(StrSql)

                StrSql = "INSERT INTO [AC_UserLoginDetail] (SessionId, userCode, moduleCode, locationCode, yearCode, logintime, logouttime, SystemName, SystemIP)" & _
                " values (" & SESSION_ID & "," & UserCode & "," & ModuleCode & "," & cmbBillingLocaion.SelectedValue & "," & YearCode & ",Getdate(),null,'" & HOST_NAME & "','" & HOST_IP_ADDRESS & "'" & ")"
                ObjDatabase.ExecuteNonQuery(StrSql)

                Me.Visible = False
                Me.Opacity = 100
                Dim frm As New FrmFNBManagement
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowDialog()
                Me.Close()
                Me.Dispose()
            Catch ex As Exception
                MsgBox("Point Of Sale Module cannot be launched directly. " & vbCrLf & "Use Module Launcher to use the Module" + ex.Message, MsgBoxStyle.Critical)
                End
            End Try
        End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        ErrorProvider1.Dispose()

        If cmbFinancialYear.SelectedValue = 0 Then
            MsgBox("Select Financial Year")
            cmbFinancialYear.Focus()
            Exit Sub
        End If

        If cmbBillingLocaion.SelectedValue = 0 Then
            MsgBox("Select Billing Location")
            cmbBillingLocaion.Focus()
            Exit Sub
        End If

        If Trim(txtUserName.Text) = "" And Trim(txtPassword.Text) = "" Then
            ErrorProvider1.SetError(txtUserName, "Enter Login Credentials")
            txtUserName.Focus()
            Exit Sub
        Else
            ErrorProvider1.Dispose()
        End If
        If Trim(txtUserName.Text).Contains("'") = True Then
            ErrorProvider1.SetError(txtUserName, "Invalid User Name")
            txtUserName.Focus()
            Exit Sub
        Else
            ErrorProvider1.Dispose()
        End If

        If Trim(txtPassword.Text).Contains("'") = True Then
            ErrorProvider1.SetError(txtPassword, "Invalid Password")
            txtPassword.Focus()
            Exit Sub
        Else
            ErrorProvider1.Dispose()
        End If

        If Trim(txtUserName.Text) = "" Then
            ErrorProvider1.SetError(txtUserName, "Enter User Name")
            txtUserName.Focus()
            Exit Sub
        Else
            ErrorProvider1.Dispose()
        End If

        If Trim(txtPassword.Text) = "" Then
            ErrorProvider1.SetError(txtPassword, "Enter Password")
            txtPassword.Focus()
            Exit Sub
        Else
            ErrorProvider1.Dispose()
        End If

        Try
            StrSql = "select TOP 1 Code, LocationName,Type,SubStore from IM_LocationMaster where VendorID=" & cmbBillingLocaion.SelectedValue
            ds = ObjDatabase.BindDataSet(StrSql, "Location")
            If ds.Tables("Location").Rows.Count > 0 Then
                LOCATION_Code = (ds.Tables("Location").Rows(0)("Code") & "")
                LOCATION_NAME = (ds.Tables("Location").Rows(0)("LocationName") & "")
                LOCATION_TYPE = (ds.Tables("Location").Rows(0)("Type") & "")
                SUBSTORE_Code = (ds.Tables("Location").Rows(0)("SubStore") & "")
                VENDOR_ID = cmbBillingLocaion.SelectedValue
            End If

            StrSql = " SELECT UserCode,UserName,UPassword,TypeCode FROM AC_UserMaster" & _
            " WHERE Username='" & Trim(txtUserName.Text & "") & "'  AND UPassword='" & Trim(txtPassword.Text & "") & "'"
            ds = ObjDatabase.BindDataSet(StrSql, "User")
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Invalid User Name or Password", MsgBoxStyle.OkOnly, "")
                ObjDatabase.CloseDatabaseConnection()
                txtUserName.Focus()
                Exit Sub
            Else
                UserCode = ds.Tables("User").Rows(0)("UserCode")
                USERNAME = ds.Tables("User").Rows(0)("UserName")
                GLOBAL_USER_NAME = ds.Tables("User").Rows(0)("UserName")
                GLOBAL_USER_PWD = ds.Tables("User").Rows(0)("UPassword")
                UserTypeCode = ds.Tables("User").Rows(0)("TypeCode")
                YearCode = cmbFinancialYear.SelectedValue
                FinancialYearString = cmbFinancialYear.Text
            End If

            StrSql = "SELECT COUNT(*)  FROM AC_UserRights WHERE LocationCode=" & LOCATION_Code & " AND AUserCode=" & UserCode & " and (AddRight='Y' or EditRight='Y' or DeleteRight='Y' or SearchRight='Y')"
            RecCount = ObjDatabase.ExecuteScalar(StrSql)
            If RecCount = 0 And UserCode > 1 Then
                MsgBox("Sorry you don't have rights for the selected location.", MsgBoxStyle.Critical)
                Exit Sub
            Else
                txtUserName.Enabled = False
                txtPassword.Enabled = False
                StrSql = "select isnull(max([SessionId]),0)+1 FROM [AC_UserLoginDetail]"
                SESSION_ID = ObjDatabase.ExecuteScalarN(StrSql)

                StrSql = "INSERT INTO [AC_UserLoginDetail] (SessionId, userCode, moduleCode, locationCode, yearCode, logintime, logouttime, SystemName, SystemIP)" & _
                " values (" & SESSION_ID & "," & UserCode & "," & ModuleCode & "," & cmbBillingLocaion.SelectedValue & "," & YearCode & ",Getdate(),null,'" & HOST_NAME & "','" & HOST_IP_ADDRESS & "'" & ")"
                ObjDatabase.ExecuteNonQuery(StrSql)

                Me.Visible = False
                MDIForm = New FrmFNBManagement
                MDIForm.StartPosition = FormStartPosition.CenterScreen
                MDIForm.Show()
                Me.Opacity = 100
            End If
        Catch ex As Exception
        Finally
            ObjDatabase.CloseDatabaseConnection()
        End Try
    End Sub

    Private Sub FrmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure to Exit the application?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Function GetArguments() As String()
        mArgs = Environment.GetCommandLineArgs
        If mArgs.Length > 0 Then
        End If
        GetArguments = mArgs
    End Function

    Private Sub LoadFinancialYear()
        strSql = "SELECT  YearCode, FinancialYear as FinYearDesc FROM AC_FinancialYear"
        BindComboboxWithSelectOneNumeric(strSql, "YearCode", "FinYearDesc", cmbFinancialYear)
        cmbFinancialYear.SelectedValue = 0
        strSql = "SELECT  max(YearCode) FROM AC_FinancialYear"
        Dim _YearCode As Integer = ObjDatabase.ExecuteScalarN(strSql)
        cmbFinancialYear.SelectedValue = _YearCode
    End Sub

    Private Sub LoadBillingLocation()
        strSql = "select VendorID,LoginName from CompanyInfoVendor where VendorType='POS'"
        BindComboboxWithSelectOneNumeric(strSql, "VendorID", "LoginName", cmbBillingLocaion)
    End Sub

    Private Sub txt_UserName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.GotFocus
        FocussedControl = 1
    End Sub

    Private Sub Alphabet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQ.Click, btnW.Click, btnE.Click, btnR.Click, btnT.Click, btnY.Click, btnU.Click, btnI.Click, btnO.Click, btnP.Click, btnA.Click, btnS.Click, btnD.Click, btnF.Click, btnG.Click, btnH.Click, btnJ.Click, btnK.Click, btnL.Click, btnZ.Click, btnX.Click, btnC.Click, btnV.Click, btnB.Click, btnN.Click, btnM.Click
        Dim btn As New Button
        btn = sender
        If FocussedControl = 1 Then
            txtUserName.Text &= btn.Text
        ElseIf FocussedControl = 2 Then
            txtPassword.Text &= btn.Text
        End If
    End Sub

    Private Sub btnNumericOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumericOK.Click
        Dim btn As New Button
        If FocussedControl = 1 Then
            txtUserName.Text &= btn.Text
        ElseIf FocussedControl = 2 Then
            txtPassword.Text &= btn.Text
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SendKeys.Send("{ENTER}")
    End Sub

    Private Sub btnClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClr.Click
        If FocussedControl = 1 Then
            txtUserName.Text = ""
        ElseIf FocussedControl = 2 Then
            txtPassword.Text = ""
        End If
    End Sub

    Private Sub btnNuericClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuericClear.Click
        If FocussedControl = 1 Then
            txtUserName.Text = ""
        ElseIf FocussedControl = 2 Then
            txtPassword.Text = ""
        End If
    End Sub

    Private Sub Txt_Password_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        FocussedControl = 2
    End Sub

    Private Sub Txt_Password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub NumericKeyPad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn0.Click
        Dim btn As New Button
        btn = sender
        If FocussedControl = 1 Then
            txtUserName.Text &= btn.Text
        ElseIf FocussedControl = 2 Then
            txtPassword.Text &= btn.Text
        End If
    End Sub

    Private Sub BtnOSK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOSK.Click
        Dim str As String = OSK_PATH & "\OSK.exe"
        Process.Start(str)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub FrmLogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim AppForms As String = ""
        Dim Myforms As String = ""
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim types As Type() = myAssembly.GetTypes()
        For Each myType In types
            If myType.BaseType.FullName = "System.Windows.Forms.Form" Then
                AppForms = myType.Name
                Myforms = Myforms & vbCrLf & AppForms
            End If
        Next


    End Sub
End Class