Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing.Color
Imports System.Drawing.Point
Imports System.IO
Imports System.Data
Imports System.Configuration

Public Class frmMemberEnquiry
    Private responsive As ResponsiveHelper

    Dim ds As DataSet
    Dim NoOfrecords As Integer
    Dim NoOfrecordsStr As String
    Private Declare Function ShellEx Lib "shell32.dll" Alias "ShellExecuteA" ( _
           ByVal hWnd As Integer, ByVal lpOperation As String, _
           ByVal lpFile As String, ByVal lpParameters As String, _
           ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer

    Private Sub frmMemberEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindComboboxWithSelectAllNumeric("select Code,CitizenType from AC_CitizenType", "Code", "CitizenType", cmbCitizenType)
        BindComboboxWithSelectAllNumeric("Select StatusCode,StatusName  from AC_StatusMaster ", "StatusCode", "StatusName", cmbStatus)
        BindComboboxWithSelectAllNumeric("Select Code,CitizenType from AC_CitizenType", "Code", "CitizenType", cmbCitizenType)
        BindComboboxWithSelectAllNumeric("Select Code,Categorytype from AC_CategoryType", "Code", "Categorytype", cmbCategoryType)
        BindComboboxWithSelectAllNumeric("Select Code,CategorytypeSub from AC_CategoryTypeSub", "Code", "CategorytypeSub", cmbCategoryTypeSub)

        cmbStatus.SelectedValue = 0
        cmbStatus.Text = "[Select All]"
        cmbCitizenType.SelectedValue = 0
        cmbCitizenType.Text = "[Select All]"
        cmbCategoryType.Text = "[Select All]"
        cmbCategoryTypeSub.Text = "[Select All]"
        BindGrid(200)

        responsive = New ResponsiveHelper(Me)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        labelRecordCount.Text = "Fetching data from data source"
        Me.Refresh()
        NoOfrecordsStr = ""
        BindGrid(0)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        General.Close(Me)
    End Sub

    Private Sub BindGrid(ByVal Records As Integer)
        Try
            If Records > 0 Then
                NoOfrecordsStr = " TOP 100 "
            Else
                NoOfrecordsStr = " TOP 100 percent"
            End If
            StrSql = "Select " & NoOfrecordsStr & " MM.MemberID [C_ID],MM.OldMemNo [M_ID], " & _
        " isnull(TM.DisplayAs + ' ', '') + isnull(MM.fName + ' ','') + isnull(MM.mName + ' ','')+ " & _
        " isnull(MM.lName + ' ','') + isnull(MM.Decoration,'') Name,isnull(MM.dob,'') DOB,isnull(SM.StatusName,'') Status " & _
        " ,MM.ICardNo,MM.Mobile1,MM.Mobile2,MM.Email_ID,isnull(CT.CategoryType,'') Categorytype,isnull(CTS.CategoryTypeSub,'') Subcategorytype,ctz.CitizenType CitizenType" & _
        " ,MM.vToDate ValidUpto,isnull(MM.cfullAddress ,'') Address" & _
        " ,MM.cPhoneNo PhoneNo, isnull(TM.DisplayAs,'') Title" & _
        " ,MM.MaritalStatus, isnull(City.cityname,'') City,isnull(State.STATENAME,'') State" & _
        " from MM_MemberProfile MM,AC_TitleMaster TM , AC_CityMaster City, AC_StateMaster State, AC_StatusMaster SM" & _
        " ,AC_Category CM ,AC_CategoryType CT,AC_CategoryTypeSub CTS, AC_CitizenType ctz" & _
        " where MM.CategoryCode =CM.CategoryCode AND ctz.[Code]=MM.[CitizenCode] " & _
        " and CM.CategoryType IN ('Member','Corporate') " & _
        " and MM.CCityCode=City.cityCode and MM.cStateCode=State.stateCode and MM.TitleCode=TM.Code " & _
        " and MM.StatusCode=SM.StatusCode" & _
        " and MM.CategoryTypeCode=CT.Code" & _
        " and MM.CategoryTypeSubCode=CTS.Code" & _
        IIf(Val(cmbStatus.SelectedValue) > 0, " and MM.StatusCode=" & Val(cmbStatus.SelectedValue), "") & _
        IIf(Val(cmbCitizenType.SelectedValue) > 0, " and ctz.[Code]=" & Val(cmbCitizenType.SelectedValue), "") & _
        IIf(Val(cmbCategoryType.SelectedValue) > 0, " and CT.Code=" & Trim(cmbCategoryType.SelectedValue), "") & _
        IIf(Val(cmbCategoryTypeSub.SelectedValue) > 0, " and CTS.Code=" & Val(cmbCategoryTypeSub.SelectedValue), "") & _
        IIf(Trim(txtC_ID.Text) <> "", " and MM.MemberID like '" & Trim(txtC_ID.Text) & "%'", "") & _
        IIf(Trim(txtM_ID.Text) <> "", " and (MM.OldMemNo = '" & Trim(txtM_ID.Text) & "' or MM.OldMemNo Like '" & Trim(txtM_ID.Text) & "_O%' )", "") & _
        IIf(Trim(txtFName.Text) <> "", " and MM.FName like '" & Trim(txtFName.Text) & "%'", "") & _
        IIf(txtMName.Text <> "", " and MM.MName like '" & Trim(txtMName.Text) & "%'", "") & _
        IIf(Trim(txtLName.Text) <> "", " and MM.LName like '" & Trim(txtLName.Text) & "%'", "") & _
        IIf(Trim(txtAddress.Text) <> "", " and MM.CFullAddress like '%" & Trim(txtAddress.Text) & "%'", "") & _
        IIf(Trim(txtServiceNo.Text) <> "", " and MM.ICardNo like '" & Trim(txtServiceNo.Text) & "%'", "") & _
        IIf(chbDoBFrom.Checked = True, " and convert(int, DAY(MM.dob)) >= '" & Format(dtpDoBFrom.Value, "dd") & "'", "") & _
        IIf(chbDoBFrom.Checked = True, " and convert(int, month(MM.dob)) >= '" & Format(dtpDoBFrom.Value, "MM") & "'", "") & _
        IIf(chbDateOfBirthTo.Checked = True, " and convert(int, DAY(MM.dob)) <= '" & Format(dtpDoBTo.Value, "dd") & "'", "") & _
        IIf(chbDateOfBirthTo.Checked = True, " and convert(int, month(MM.dob)) <= '" & Format(dtpDoBTo.Value, "MM") & "'", "") & _
        IIf(Trim(txtTitle.Text) <> "", " and TM.DisplayAs like '" & Trim(txtTitle.Text) & "%'", "") & _
        IIf(Trim(txtCity.Text) <> "", " and City.CityName like '" & Trim(txtCity.Text) & "%'", "") & _
        IIf(Trim(txtState.Text) <> "", " and State.StateName like '" & Trim(txtState.Text) & "%'", "") & _
        IIf(Trim(txtMobile1.Text) <> "", " and MM.Mobile1 like '" & Trim(txtMobile1.Text) & "%'", "") & _
        IIf(Trim(txtMobile2.Text) <> "", " and MM.Mobile2 like '" & Trim(txtMobile2.Text) & "%'", "") & _
        IIf(txtEmail.Text <> "", " and MM.Email_ID like '" & Trim(txtEmail.Text) & "%'", "") & _
        " Order by MM.MemberID "
            ds = New DataSet
            ds = ObjDatabase.BindDataSet(StrSql, "Enquiry")
            dgsearch.DataSource = ds
            dgsearch.DataMember = ds.Tables(0).ToString()
            labelRecordCount.Text = ""
            labelRecordCount.Text = "Record Count: " & dgsearch.Rows.Count()
            FormatDataGridView(dgsearch)
            dgsearch.RowHeadersVisible = True
            dgsearch.RowHeadersWidth = 20
            dgsearch.Columns("C_ID").ReadOnly = True
            dgsearch.Columns("C_ID").Width = 73
            dgsearch.Columns("M_ID").ReadOnly = True
            dgsearch.Columns("M_ID").Width = 80
            dgsearch.Columns("Name").ReadOnly = True
            dgsearch.Columns("Name").Width = 250
            dgsearch.Columns("DOB").ReadOnly = True
            dgsearch.Columns("DOB").Width = 100
            dgsearch.Columns("Status").ReadOnly = True
            dgsearch.Columns("Status").Width = 80
            dgsearch.Columns("Email_ID").ReadOnly = True
            dgsearch.Columns("Email_ID").HeaderText = "Email_ID"
            dgsearch.Columns("Email_ID").Width = 210
            dgsearch.Columns("Mobile1").ReadOnly = True
            dgsearch.Columns("Mobile1").Width = 100
            dgsearch.Columns("Mobile2").ReadOnly = True
            dgsearch.Columns("Mobile2").Width = 100
            dgsearch.Columns("CitizenType").ReadOnly = True
            dgsearch.Columns("CitizenType").Width = 100
            dgsearch.Columns("Categorytype").ReadOnly = True
            dgsearch.Columns("Categorytype").Width = 150
            dgsearch.Columns("Categorytype").HeaderText = "CatType"
            dgsearch.Columns("Subcategorytype").ReadOnly = True
            dgsearch.Columns("Subcategorytype").Width = 120
            dgsearch.Columns("Subcategorytype").HeaderText = "CatTypeSub"
            dgsearch.Columns("ValidUpto").ReadOnly = True
            dgsearch.Columns("ValidUpto").Width = 100
            dgsearch.Columns("Address").ReadOnly = True
            dgsearch.Columns("Address").Width = 450
            dgsearch.Columns("PhoneNo").ReadOnly = True
            dgsearch.Columns("PhoneNo").Width = 130
            dgsearch.Columns("Title").Visible = False
            dgsearch.Columns("Title").ReadOnly = True
            dgsearch.Columns("Title").Width = 100
            dgsearch.Columns("MaritalStatus").ReadOnly = True
            dgsearch.Columns("MaritalStatus").HeaderText = "MaritalStatus"
            dgsearch.Columns("City").ReadOnly = True
            dgsearch.Columns("City").Width = 100
            dgsearch.Columns("State").ReadOnly = True
            dgsearch.Columns("State").Width = 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Dim EXCLS As New clsExcelReport
        BindGrid(10)
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim FileName As String = SaveFileDialog1.FileName
            EXCLS.exportExcel(dgsearch, FileName & ".xls")
            ShellEx(Me.Handle, "Open", EXCLS.myFile, "", "", 10)
        End If
    End Sub

    Private Sub PanelFooter_Resize(sender As Object, e As EventArgs) Handles PanelFooter.Resize
        CenterButtonsInPanel(PanelFooter)
    End Sub

    Private Sub frmMemberEnquiry_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If responsive Is Nothing Then
            responsive = New ResponsiveHelper(Me)
        End If

        ApplyResponsiveLayout(Me, responsive)
    End Sub
End Class