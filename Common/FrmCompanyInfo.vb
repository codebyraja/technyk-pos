Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmCompanyInfo
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand

    Dim dAdapter As SqlDataAdapter
    Dim drr As SqlDataReader
    Dim ds As DataSet
    Dim Code As Integer

    Private Sub FrmCompanyInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisableControl(Me)
        EnableButton("ADD", Me)
        objDatabase.ConnectDatabse()
        DisableControl(Me)
        EnableButton("ADD", Me)
        BindComboboxWithSelectOneNumeric("Select CountryCode, CountryName From AC_CountryMaster", "CountryCode", "CountryName", cmbCounry)
        BindComboboxWithSelectOneNumeric("Select StateCodeateName From AC_StateMaster", "StateCode", "StateName", CmbState)
        BindComboboxWithSelectOneNumeric("Select CityCode, CityName From AC_CityMaster", "CityCode", "CityName", CmbCity)
        Try
            strsql = "Select * FROM [CompanyInfo]"
            ds = New DataSet
            ds = objDatabase.BindDataSet(strsql, "CompanyInfo")
            If ds.Tables(0).Rows.Count > 0 Then
                btnAdd.Enabled = False
                btnEdit.Enabled = True
                BindControls()
            Else
            End If
            Message = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub BindControls()
        ds = New DataSet
        strsql = "Select * FROM [CompanyInfo]"
        ds = objDatabase.BindDataSet(strsql, "CompanyInfo")
        If ds.Tables(0).Rows.Count > 0 Then
            TxtOrgName.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("Name"))
            TxtAddress.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("Address"))
            TxtPinno.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("PinCode"))
            TxtPhone1.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("Phone"))
            TxtFaxNO.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("Fax"))
            TxtEmail.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("Email"))
            TxtWebSite.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("Website"))
            TxtLTNo.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("Title"))
            TxtTincstno.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("TINNO"))
            TxtSTReg.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("STRegNo"))
            cmbCounry.SelectedValue = Val(ds.Tables("CompanyInfo").Rows(0)("Country"))
            CmbState.SelectedValue = Val(ds.Tables("CompanyInfo").Rows(0)("State"))
            CmbCity.SelectedValue = Val(ds.Tables("CompanyInfo").Rows(0)("City"))
            TxtLTNo.Text = Trim(ds.Tables("CompanyInfo").Rows(0)("LTNO"))
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        BackToMainScreen = True
        Me.Dispose()
    End Sub
End Class