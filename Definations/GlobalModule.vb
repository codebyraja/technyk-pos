Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Color
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net.NetworkCredential

Module GlobalModule
    Public NumberFormat As String = "####0.00"
    Public LocationForConsumption As String = ""
    Public PartyBarStore As Integer = 0
    Public PartySubStoreCode As Integer = 0
    Public SELECT_ONE As String = "[SELECT ONE]"
    Public ChequeDays As Integer = 0
    Public ModificationDays As Integer = 0
    Public OrgCity As String = ""
    Public RecordCount As Integer = 0
    Public Const PrintType As String = "THERMAL"
    Public YearCodeSuffix As String = ""
    Public MDIForm As New FrmFNBManagement
    Public CompanyInfoName As String = ""
    Public ObjDatabase As database
    Public UserCodeForSpecialAccess As String = ""
    Public RecCount As Integer = 0
    Public ModuleName As String = "POS"
    Public FinYearTransaction As String
    Public ModuleCode As Integer = 2
    Public DEFAULT_LOGIN_ID, DEFAULT_LOGIN_PASSWORD As String
    Public HOST_IP_ADDRESS, HOST_NAME As String
    Public StrSql As String = ""
    Public LOCATIONTYPE As String = ""
    Public Const GB_VATPer As Integer = 20
    Public VENDOR_ID As Integer = 0
    Public LOGINTYPE As Integer = 0
    Public GLOBAL_USER_NAME As String = ""
    Public GLOBAL_USER_PWD As String = ""
    Public UserTypeCode As Integer = 0
    Public CheckCardIssue As String
    Public F1, F2, F3, F4, F5 As Boolean
    Public AllowedMainGroupCode As String = ""
    Public SuccessBC As New System.Drawing.Color
    Public ErrorBC As New System.Drawing.Color
    Public NormalBC As New System.Drawing.Color
    Public LabelBackColor As New System.Drawing.Color
    Public LabelForeColor As New System.Drawing.Color
    Public ErrorMessageHeader As String = ""

    Public GB_ServiceChargePer As Double = 0
    Public GB_OutstandingAsPerLastBill As Double = 0
    Public GB_CurrentOutstanding As Double = 0
    Public GB_DefinedCreditLimit As Double = 0

    'Public CrystalReportDocument As New ReportDocument
    Public GB_LastBillOutstanding As Double = 0
    Public EnableAutoDebit As String = ""

    Public NoOfCopiesOfSettledBill As Integer = 1
    Public SMSForPOSBillCancellationSmartCard, Temp_IDForPOSBillCancellationSmartCard As String
    Public SMSForPOSBillCancellationMemberAc, Temp_IDForPOSBillCancellationMemberAc As String
    Public SMSForPOSBillCancellationOther, Temp_IDForPOSBillCancellationOther As String
    Public [SMSForPOSBilling] As String = ""

    Public NumFormat = "###0.00"
    Public DateFormat = "dd/MMM/yyyy"
    Public DateNotAvailable As Date = "01/Jan/1900"

    Public MemberAcCardCharge As Integer = 0
    Public CardRechargeBillHead As Integer = 0


    Public SMSToBeSent As String = ""
    Public ReceiptVoucherPrintCount, MiscBillPrintCount, HealthClubPrintCount, GreenFeePrintCount, ChequeDishonourHead, CardChargePrintCount, CardRefundPrintCount As Integer
    Public MainID, MemberID, MemberName, IssueID, IssueNo, ClosingBalance As String
    Public BalanceAsPerLastBill As Decimal = 0
    Public GB_OpeningCreditLimit As Double = 0
    Public GB_ClosingCreditLimit As Double = 0
    Public MemberAcBilling As String = ""
    Public BackGroundColor As New System.Drawing.Color
    Public MemberAccountOpening As Date

    Public GBMemberID, GBOldMemNo, GBStatusName, GBCategoryName, GBName, GBEmailAdd, GBMobileNo As String
    Public GBStatusCode, GBCategoryCode, GBCitizenType, GBCategoryTypeCode As Integer
    Public GBCreditLimit As Double = 0
    Public FYLowerBound As Date
    Public FYUpperBound As Date
    Public FYBilling As String
    Public CustomerID, CustomerName, CustomerMobileNo, CustomerEmailID, CustomerAddress, CustomerLocalityID As String
    Public GlobalContactNo As String = ""
    Public NoFormRights As Boolean = False
    Public UserCode As Integer
    Public YearCode As Integer
    Public UserName As String
    Public LOCATION_Code As Integer
    Public LOCATION_NAME As String
    Public LOCATION_TYPE As String = ""
    Public BackToMainScreen As Boolean = True
    Public Message As String
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim str As String

    Public CurrentServerDate As DateTime
    Public CurrentBusinessDate As DateTime
    Public SUBSTORE_Code As Integer
    Public SubStoreName As String
    Public FormBackColor As New Color
    Public PartyBarLocationCode As Integer = 0
    Public FinancialYearString As String

    Public ServiceChargePer As Double
    Public GlobalServiceChargePer As Double
    Public ServiceTaxPer As Double
    Public ServiceTaxCalculated As Double
    Public ServiceTaxCalculatedOnPer As Double
    Public GlobalServiceTaxCalculatedOnPer As Double

    Public SQLServerUserName As String = ""
    Public SQLServerPassword As String = ""
    Public SQLServerName As String = ""
    Public SQLServerDatabase As String = ""

    Public ReportTitle As String
    Public ReportAuthor As String = ""
    Public ReportComments As String = ""
    Public RecordSelectionFormula As String = ""

    Public PAH As Integer = 0
    Public PBH As Integer = 0
    Public RAH As Integer = 0
    Public RBH As Integer = 0
    Public CMPrintCount As Integer = 0
    Public Filename As String = ""
    Public ExportedReportName As String = ""
    Public CrystalReportName As String = ""
    Public SESSION_ID As Double = 0
    Public OSK_PATH As String = ""
    Public SON As String = "[Select One]"
    Public ConnectionStr As String = ""
    Public KOTCount, ItemCodeType, KOTPrinter, DraftBillCount, FinalBillCount, RateType, SpecialMemID, PackingChargesItemCode, PackingChargesItemName, PackingChargesPercentage, PackingChargesCutOff As String
    Public ItemPrefix As String = ""
    Public ITEMSELECTION As String = ""
    Public CurrentYearCode As Integer
    Public BillingScreenType As String = ""
    Public VAT_ON_BAR, TAX_ON_BAR, Bar_SCPer As Double
    Public ApplicationStartupPath As String = ""
    Public CardManagementLocationCode As Integer = 1
    Public DefaultHeadMB As Integer = 0
    Public MCPrintCount As Integer = 0
    Public POSMainGroup As String = ""
    Public NonAlcoholicItemGroup, AlcoholicItemGroup, FoodItemGroup, FlagOTPValidation As String
    Public SecurityLedgerCode As Integer = 0
    Public DefaultHeadRV As Integer = 0
    Public CGSTCode14 As Integer = 0
    Public SGSTCode14 As Integer = 0
    Public CGSTCode9 As Integer = 0
    Public SGSTCode9 As Integer = 0
    Public CGSTCode6 As Integer = 0
    Public SGSTCode6 As Integer = 0
    Public CGSTCode2_5 As Integer = 0
    Public SGSTCode2_5 As Integer = 0
    Public CGSTHeadDescription9 As String = ""
    Public SGSTHeadDescription9 As String = ""
    Public CGSTHeadDescription6 As String = ""
    Public SGSTHeadDescription6 As String = ""
    Public CGSTHeadDescription2_5 As String = ""
    Public SGSTHeadDescription2_5 As String = ""
    Public CGSTHeadDescription14 As String = ""
    Public SGSTHeadDescription14 As String = ""
    Public [SMSForCardCharge], [SMSForMiscBilling] As String
    Public [Temp_IDForCardCharge], [Temp_IDForMiscBilling] As String
    Public SMSForPOSBillingOther, SMSForPOSBillingSmartCard, SMSForPOSBillingMemberAc As String
    Public Temp_IDForPOSBillingOther, Temp_IDForPOSBillingSmartCard, Temp_IDForPOSBillingMemberAc As String
    Public NonMemberCategoryCode As String = ""
    Public SMSForMiscBillOther, SMSForMiscBillMemberAc, SMSForMiscBillSmartCard As String
    Public Temp_IDForMiscBillOther, Temp_IDForMiscBillMemberAc, Temp_IDForMiscBillSmartCard As String
    Public [SMSForPaymentReceipt] As String = ""
    Public Temp_IDForPaymentReceipt As String = ""
    Public TaxType As String = ""
    Public MainStoreCode As String = ""
    Public SCApplicable, GSTPerOnServiceCharge, BAR_MAINGROUPS, REST_MAINGROUPS As String

    Public Sub LoadConfigurations()
        SuccessBC = Color.Green
        ErrorBC = Color.Red
        NormalBC = BackGroundColor

        CompanyInfoName = ObjDatabase.ExecuteScalarS("select Name FROM CompanyInfo")
        MemberAccountOpening = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MM_Configuration] where PropertyName='MemberAccountOpening'")
        MemberAcBilling = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MM_Configuration] where PropertyName='MemberAcBilling'")
        EnableAutoDebit = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MM_Configuration] where PropertyName='EnableAutoDebit'")
        SMSToBeSent = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSToBeSent'")
        SMSForPOSBillingSmartCard = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillingSmartCard' and SendSMS='Yes'")
        SMSForPOSBillingMemberAc = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillingMemberAc' and SendSMS='Yes'")
        SMSForPOSBillingOther = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillingOther' and SendSMS='Yes'")
        SMSForCardCharge = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForCardCharge' and SendSMS='Yes'")
        SMSForPaymentReceipt = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForPaymentReceipt' and SendSMS='Yes'")
        SMSForMiscBillSmartCard = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForMiscBillSmartCard' and SendSMS='Yes'")
        SMSForMiscBillMemberAc = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForMiscBillMemberAc' and SendSMS='Yes'")
        SMSForMiscBillOther = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForMiscBillOther' and SendSMS='Yes'")
        SMSForPOSBillCancellationSmartCard = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillCancellationSmartCard' and SendSMS='Yes'")
        SMSForPOSBillCancellationMemberAc = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillCancellationMemberAc' and SendSMS='Yes'")
        SMSForPOSBillCancellationOther = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillCancellationOther' and SendSMS='Yes'")
        Temp_IDForPOSBillingSmartCard = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillingSmartCard' and SendSMS='Yes'")
        Temp_IDForPOSBillingMemberAc = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillingMemberAc' and SendSMS='Yes'")
        Temp_IDForPOSBillingOther = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillingOther' and SendSMS='Yes'")
        Temp_IDForCardCharge = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForCardCharge' and SendSMS='Yes'")
        Temp_IDForPaymentReceipt = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForPaymentReceipt' and SendSMS='Yes'")
        Temp_IDForMiscBillSmartCard = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForMiscBillSmartCard' and SendSMS='Yes'")
        Temp_IDForMiscBillMemberAc = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForMiscBillMemberAc' and SendSMS='Yes'")
        Temp_IDForMiscBillOther = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForMiscBillOther' and SendSMS='Yes'")
        Temp_IDForPOSBillCancellationSmartCard = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillCancellationSmartCard' and SendSMS='Yes'")
        Temp_IDForPOSBillCancellationMemberAc = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillCancellationMemberAc' and SendSMS='Yes'")
        Temp_IDForPOSBillCancellationOther = ObjDatabase.ExecuteScalarS("SELECT isnull([TemplateID],'0') FROM [MC_Configuration] where PropertyName='SMSForPOSBillCancellationOther' and SendSMS='Yes'")
        ReceiptVoucherPrintCount = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='ReceiptVoucherPrint'")
        MiscBillPrintCount = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='MiscBillPrint'")
        HealthClubPrintCount = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='HealthClubPrint'")
        GreenFeePrintCount = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='GreenFeePrint'")
        CardChargePrintCount = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='CardChargePrint'")
        CardRefundPrintCount = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='CardRefundPrint'")
        DefaultHeadMB = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='DefaultHeadMB'")
        CardRechargeBillHead = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='CardRechargeBillHead'")
        SecurityLedgerCode = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='SecurityLedgerCode'")
        ChequeDays = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='ChequeDays'")
        ModificationDays = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='ModificationDays'")
        SpecialMemID = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [CM_Configuration] where PropertyName='SecurityLedgerCode'")
        PartyBarLocationCode = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [BM_Configuration] where PropertyName='PartyBarLocationCode'")
        PartyBarStore = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [BM_Configuration] where PropertyName='PartyBarStore'")
        UserCodeForSpecialAccess = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [MM_Configuration] where PropertyName='UserCodeForSpecialAccess'")
        OrgCity = ObjDatabase.ExecuteScalarS("select C.CityName from AC_CityMaster C, CompanyInfo I where C.CityCode=I.City")
        CompanyInfoName = ObjDatabase.ExecuteScalar("select Name from CompanyInfo")
        CMPrintCount = MiscBillPrintCount
        PAH = ObjDatabase.ExecuteScalar("SELECT PropertyValue FROM [BM_Configuration] where PropertyName='PartyAdvanceCode'")
        PBH = ObjDatabase.ExecuteScalar("SELECT PropertyValue FROM [BM_Configuration] where PropertyName='PartyBillCode'")
        RAH = ObjDatabase.ExecuteScalar("SELECT PropertyValue FROM [RM_Configuration] where PropertyName='RoomAdvanceCode'")
        RBH = ObjDatabase.ExecuteScalar("SELECT PropertyValue FROM [RM_Configuration] where PropertyName='RoomBillCode'")

        LOCATION_TYPE = ObjDatabase.ExecuteScalarS("SELECT [Type] FROM [IM_LocationMaster] WHERE Code=" & LOCATION_Code)
        GlobalServiceChargePer = ObjDatabase.ExecuteScalarS("select SCValue from AC_ServiceChargeMaster where SCCode=1")
        FinYearTransaction = ObjDatabase.ExecuteScalarS("select right(DATEPART(YEAR,datefrom),2) + '' + right(DATEPART(YEAR,DateTo),2) from AC_FinancialYear where YearCode=" & YearCode)
        CurrentYearCode = ObjDatabase.ExecuteScalarN("Select Isnull(MAX([YearCode]),1) FROM [AC_FinancialYear]")
        If CurrentYearCode = YearCode Then YearCodeSuffix = "" Else YearCodeSuffix = "_FY"

        Bar_SCPer = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [BM_Configuration] where PropertyName='SCPerOnPartyBar'")
        VAT_ON_BAR = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [BM_Configuration] where PropertyName='VATPer'")
        TAX_ON_BAR = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [BM_Configuration] where PropertyName='OtherPer'")

        AlcoholicItemGroup = ObjDatabase.ExecuteScalarS("SELECT isnull(STUFF((SELECT ',' + CONVERT(VARCHAR(MAX),Code) FROM IM_GroupMaster where GroupType='Alcoholic' FOR XML PATH('')), 1, 1, ''),'0')")
        NonAlcoholicItemGroup = ObjDatabase.ExecuteScalarS("SELECT isnull(STUFF((SELECT ',' + CONVERT(VARCHAR(MAX),Code) FROM IM_GroupMaster where GroupType='NonAlcoholic' FOR XML PATH('')), 1, 1, ''),'0')")
        FoodItemGroup = ObjDatabase.ExecuteScalarS("SELECT isnull(STUFF((SELECT ',' + CONVERT(VARCHAR(MAX),Code) FROM IM_GroupMaster where GroupType='Food' FOR XML PATH('')), 1, 1, ''),'0')")
        
        FlagOTPValidation = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [FB_Configuration] where PropertyName='FlagOTPValidation'")
        NonMemberCategoryCode = ObjDatabase.ExecuteScalarS("SELECT isnull([PropertyValue],'0') FROM [FB_Configuration] where PropertyName='NonMemberCategoryCode'")
        LoadDefaultSettings(LOCATION_Code)
        LocationForConsumption = ObjDatabase.ExecuteScalarS("SELECT isnull([LocationForConsumption],'') FROM [IM_Configuration]")
        POSMainGroup = REST_MAINGROUPS & "," & BAR_MAINGROUPS
    End Sub

    Public Sub LoadDefaultSettings(ByVal _LocationCode As Integer)
        Try
            Dim Parameter, ParameterValue As String
            Dim ds As New DataSet
            Dim con As New SqlClient.SqlConnection
            Dim cmd As New SqlClient.SqlCommand
            Dim adp As New SqlDataAdapter
            StrSql = "SELECT  PropertyName, PropertyValue from [FB_Configuration] where LocationCode=" & _LocationCode
            con.ConnectionString = ConnectionStr
            cmd.CommandText = StrSql
            cmd.Connection = con
            adp.SelectCommand = cmd
            adp.Fill(ds, "Config")
            If ds.Tables("Config").Rows.Count = 0 Then MsgBox("Unable to Load default settings for the Location", MsgBoxStyle.Critical)

            For i As Integer = 0 To ds.Tables("Config").Rows.Count - 1
                Parameter = ds.Tables("Config").Rows(i)("PropertyName")
                ParameterValue = ds.Tables("Config").Rows(i)("PropertyValue")

                If Parameter.ToUpper() = "ItemCodeType".ToUpper() Then
                    ItemCodeType = ParameterValue
                ElseIf Parameter.ToUpper() = "RateType".ToUpper() Then
                    RateType = ParameterValue
                ElseIf Parameter.ToUpper() = "BillingScreenType".ToUpper() Then
                    BillingScreenType = ParameterValue
                ElseIf Parameter.ToUpper() = "Prefix".ToUpper() Then
                    ItemPrefix = ParameterValue
                ElseIf Parameter.ToUpper() = "KOTPrinter".ToUpper() Then
                    KOTPrinter = ParameterValue
                ElseIf Parameter.ToUpper() = "KOTCount".ToUpper() Then
                    KOTCount = ParameterValue
                ElseIf Parameter.ToUpper() = "DraftBillCount".ToUpper() Then
                    DraftBillCount = ParameterValue
                ElseIf Parameter.ToUpper() = "FinalBillCount".ToUpper() Then
                    FinalBillCount = ParameterValue
                ElseIf Parameter.ToUpper() = "CheckCardIssue".ToUpper() Then
                    CheckCardIssue = ParameterValue
                ElseIf Parameter.ToUpper() = "SpecialMemID".ToUpper() Then
                    SpecialMemID = ParameterValue
                ElseIf Parameter.ToUpper() = "PackingChargesItemCode".ToUpper() Then
                    PackingChargesItemCode = ParameterValue
                ElseIf Parameter.ToUpper() = "PackingChargesItemName".ToUpper() Then
                    PackingChargesItemName = ParameterValue
                ElseIf Parameter.ToUpper() = "PackingChargesPercentage".ToUpper() Then
                    PackingChargesPercentage = ParameterValue
                ElseIf Parameter.ToUpper() = "PackingChargesCutOff".ToUpper() Then
                    PackingChargesCutOff = ParameterValue
                ElseIf Parameter.ToUpper() = "GSTONSCAMT" Then
                    GSTPerOnServiceCharge = Val(ParameterValue)
                ElseIf Parameter.ToUpper() = "SCAPPLICABLE" Then
                    SCApplicable = (ParameterValue)
                ElseIf Parameter.ToUpper() = "BAR_MAINGROUPS".ToUpper() Then
                    BAR_MAINGROUPS = ParameterValue
                ElseIf Parameter.ToUpper() = "REST_MAINGROUPS".ToUpper() Then
                    REST_MAINGROUPS = ParameterValue
                ElseIf Parameter.ToUpper() = "RAW_MAINGROUPS".ToUpper() Then
                    AllowedMainGroupCode = ParameterValue
                ElseIf Parameter.ToUpper() = "MAINSTORECODE".ToUpper() Then
                    MainStoreCode = ParameterValue
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub GetServerCurrentDate()
        StrSql = ""
        StrSql = "SELECT getdate() As ServerDate"
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(StrSql, "Data")
        CurrentServerDate = ds.Tables("Data")(0)("ServerDate")
    End Sub

    Public Function GetBusinessDate()
        StrSql = ""
        StrSql = "Proc_CurrentServerDate "
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(StrSql, "Data")
        StrSql = "select [CurrentServerDate] from AC_CurrentServerDate "
        Dim da As SqlDataReader
        da = ObjDatabase.DataReaderData(StrSql)
        If da.Read = True Then
            CurrentServerDate = da(0)
        End If
        da.Close()
        GetBusinessDate = CurrentServerDate
    End Function

    Public Function GetCurrentBusinessDate() As Date
        StrSql = "select Max([BusinessDate]) from [FB_BusinessDate] where [CurentStatus]=0"
        Dim CurrentServerDate As Date = CDate(ObjDatabase.ExecuteScalarS(StrSql)).ToString("dd/MMM/yyyy")
        GetCurrentBusinessDate = CurrentServerDate
    End Function

    Public Function BindDataSet(ByVal QryStr As String, ByVal TableName As String) As DataSet
        ds = ObjDatabase.BindDataSet(QryStr, TableName)
        BindDataSet = ds
        ObjDatabase.CloseDatabaseConnection()
    End Function

    Public Sub GetUpperAndLowerBoundsOfFinancialYear(ByVal YearCode As String)
        StrSql = ""
        StrSql = "select  DateFrom,DateTo from AC_FinancialYear where YearCode=" & Val(YearCode)
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(StrSql, "FY")
        If ds.Tables("FY").Rows.Count > 0 Then
            FYLowerBound = CDate(ds.Tables("FY").Rows(0).Item("DateFrom")).ToString("dd/MMM/yyyy")
            FYUpperBound = CDate(ds.Tables("FY").Rows(0).Item("DateTo")).ToString("dd/MMM/yyyy")
        End If
    End Sub


    Public Sub GetMemberDetails(ByVal MemberID As String)
        StrSql = "Select MemberID, OldMemNo, StatusName, CategoryName,Full_Name,Email_ID,MobileNo,StatusCode,CategoryCode,CitizenType,CategoryTypeCode,RateCode,CreditLimit" & _
        " FROM View_Member_Details WHERE (MemberID='" & MemberID & "' OR OldMemNo='" & MemberID & "')"
        GBName = "" : GBMemberID = "" : GBOldMemNo = "" : GBCategoryName = "" : GBEmailAdd = "" : GBMobileNo = "" : GBStatusCode = 0 : GBCategoryCode = 0 : GBCitizenType = 0 : GBCategoryTypeCode = 0 : GBCreditLimit = 0
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(StrSql, "Member")
        If ds.Tables("Member").Rows.Count > 0 Then
            GBMemberID = ds.Tables("Member").Rows(0)("MemberID")
            GBOldMemNo = ds.Tables("Member").Rows(0)("OldMemNo")
            GBStatusName = ds.Tables("Member").Rows(0)("StatusName")
            GBCategoryName = ds.Tables("Member").Rows(0)("CategoryName")
            GBName = ds.Tables("Member").Rows(0)("Full_Name")
            GBEmailAdd = ds.Tables("Member").Rows(0)("Email_ID")
            GBMobileNo = ds.Tables("Member").Rows(0)("MobileNo")
            GBStatusCode = ds.Tables("Member").Rows(0)("StatusCode")
            GBCategoryCode = ds.Tables("Member").Rows(0)("CategoryCode")
            GBCitizenType = ds.Tables("Member").Rows(0)("CitizenType")
            GBCategoryTypeCode = ds.Tables("Member").Rows(0)("CategoryTypeCode")
            GBCreditLimit = ds.Tables("Member").Rows(0)("CreditLimit")
        Else
            GBName = "" : GBMemberID = "" : GBOldMemNo = "" : GBCategoryName = "" : GBEmailAdd = "" : GBMobileNo = "" : GBStatusCode = 0 : GBCategoryCode = 0 : GBCitizenType = 0 : GBCategoryTypeCode = 0 : GBCreditLimit = 0
        End If
        ObjDatabase.CloseDatabaseConnection()
    End Sub

    Public Sub GetNonMemberDetails(ByVal MemberID As String)
        StrSql = "Select MemberID, Name" & _
        " FROM MM_MemberInformation" & _
        " WHERE (MemberID='" & MemberID & "')"
        GBName = "" : GBMemberID = "" : GBOldMemNo = "" : GBCategoryName = "" : GBEmailAdd = "" : GBMobileNo = "" : GBStatusCode = 0 : GBCategoryCode = 0 : GBCitizenType = 0 : GBCategoryTypeCode = 0
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(StrSql, "Member")
        If ds.Tables("Member").Rows.Count > 0 Then
            GBMemberID = ds.Tables("Member").Rows(0)("MemberID")
            GBName = ds.Tables("Member").Rows(0)("Name")
        Else
            GBName = "" : GBMemberID = "" : GBOldMemNo = "" : GBCategoryName = "" : GBEmailAdd = "" : GBMobileNo = "" : GBStatusCode = 0 : GBCategoryCode = 0 : GBCitizenType = 0 : GBCategoryTypeCode = 0
        End If
        ObjDatabase.CloseDatabaseConnection()
    End Sub

    Public Function ValidateMemberCard(ByVal CardSerailNo As String, ByVal MemberID As String)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adp As New SqlDataAdapter
        Dim ds As New DataSet
        Dim Flag As Integer = 0
        con.ConnectionString = ConnectionStr
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "Proc_ValidateMemberCard"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 10000
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@CardSerailNo", CardSerailNo)
        cmd.Parameters.AddWithValue("@MemberID", MemberID)
        adp.SelectCommand = cmd
        adp.Fill(ds, "Table")
        If ds.Tables(0).Rows.Count > 0 Then
            Flag = ds.Tables(0).Rows(0)(0)
        End If
        ValidateMemberCard = Flag
    End Function

    Public Function GetSmartCardBalance(ByVal MemberID As String) As DataSet
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adp As New SqlDataAdapter
        Dim ds As New DataSet
        Dim Flag As Integer = 0
        con.ConnectionString = ConnectionStr
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "Proc_SmartCardCurrentBalance"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 10000
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@MemberID", MemberID)
        adp.SelectCommand = cmd
        adp.Fill(ds, "Table")
        GetSmartCardBalance = ds
    End Function

    Public Function GetMemberAccountBalance(ByVal MemberID As String) As DataSet
        Dim AvailableCreditLimit As Double = 0
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adp As New SqlDataAdapter
        Dim ds As New DataSet
        Dim Flag As Integer = 0
        con.ConnectionString = ConnectionStr
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "Proc_GetOutstandingAmtForPOS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 10000
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@MemberID", MemberID)
        adp.SelectCommand = cmd
        adp.Fill(ds, "Table")
        GB_OpeningCreditLimit = IIf(IsDBNull(ds.Tables("Table").Rows(0)("AvailableCreditLimit")) = True, 0, ds.Tables("Table").Rows(0)("AvailableCreditLimit"))
        GB_ClosingCreditLimit = IIf(IsDBNull(ds.Tables("Table").Rows(0)("ClosingCreditLimit")) = True, 0, ds.Tables("Table").Rows(0)("ClosingCreditLimit"))
        GB_OutstandingAsPerLastBill = IIf(IsDBNull(ds.Tables("Table").Rows(0)("PayableAmt")) = True, 0, ds.Tables("Table").Rows(0)("PayableAmt"))
        GB_CurrentOutstanding = IIf(IsDBNull(ds.Tables("Table").Rows(0)("BalanceAmt")) = True, 0, ds.Tables("Table").Rows(0)("BalanceAmt"))
    End Function

    Public Function GetMemberAccountClosingBalance(ByVal MemberID As String) As Double
        Dim AvailableCreditLimit As Double = 0
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adp As New SqlDataAdapter
        Dim ds As New DataSet
        Dim Flag As Integer = 0
        con.ConnectionString = ConnectionStr
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "Proc_GetOutstandingAmtForPOS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 10000
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@MemberID", MemberID)
        adp.SelectCommand = cmd
        adp.Fill(ds, "Table")
        GB_CurrentOutstanding = IIf(IsDBNull(ds.Tables("Table").Rows(0)("BalanceAmt")) = True, 0, ds.Tables("Table").Rows(0)("BalanceAmt"))
        GetMemberAccountClosingBalance = GB_CurrentOutstanding
    End Function


    Public Function CheckBillingStatusforStatusName(ByVal StatusCode As String) As Integer
        StrSql = "SELECT TransactionAllowed from AC_StatusMaster where StatusCode=" & StatusCode
        StrSql = ObjDatabase.ExecuteScalarS(StrSql)
        If StrSql.ToUpper = "YES" Then
            CheckBillingStatusforStatusName = 1
        Else
            CheckBillingStatusforStatusName = 0
        End If
    End Function

    Public Function GetMemberType(ByVal MemberID As String) As String
        If MemberID = "" Then
            GetMemberType = ""
        Else
            If MemberID.Contains("-") Then
                Dim str As String = "select isnull(CM.CategoryType,'NonMember') from AC_Category CM, MM_MemberInformation MI where CM.CategoryCode=MI.category and MI.memberID='" & MemberID & "' and CM.CategoryType in('Corporate','Member','NonMember','NonMembers')"
                Dim MemberType As String = ObjDatabase.ExecuteScalar(str)
                GetMemberType = MemberType
            Else
                Dim str As String = "select isnull(CM.CategoryType,'NonMember') from AC_Category CM, MM_MemberProfile MI where CM.CategoryCode=MI.categoryCode and (MI.memberID='" & MemberID & "' or MI.OldMemNo='" & MemberID & "') and CM.CategoryType in('Corporate','Member','NonMember','NonMembers')"
                Dim MemberType As String = ObjDatabase.ExecuteScalar(str)
                GetMemberType = MemberType.ToUpper()
            End If
        End If
    End Function

    Public Function GetTypeOfMember(ByVal MemberID As String) As String
        Dim str As String = "select [Type] from MM_MemberInformation where memberID='" & MemberID & "'"
        Dim TypeOfMember As String = ObjDatabase.ExecuteScalar(str)
        GetTypeOfMember = TypeOfMember
    End Function

    Public Function GetMainID(ByVal MemberID As String) As String
        Dim str As String = "select [MainID] from MM_MemberInformation where memberID='" & MemberID & "'"
        Dim MainID As String = ObjDatabase.ExecuteScalar(str)
        GetMainID = MainID
    End Function

    Public Function GetCitizenType(ByVal MemberID As String) As String
        Dim CitizenType As String = ""
        Dim dsCitizenType As New DataSet
        Try
            StrSql = "select isnull(OldMemNo,'') from View_MemberMaster Where MemberID='" & MemberID & "'"
            CitizenType = ObjDatabase.ExecuteScalar(StrSql)
            GetCitizenType = CitizenType
        Catch ex As Exception
        End Try
        GetCitizenType = CitizenType
    End Function

    Public Function GetCitizenType_old(ByVal MemberID As String) As String
        Try
            Dim AgeAsOnDate As Integer = 0
            Dim MemberType As String = ""
            Dim Qry As String = "select datediff(year,dob,getdate()) dob,MemberType from View_MemberMaster where MemberID='" & MemberID & "'"
            Dim dsdob As New DataSet
            dsdob = ObjDatabase.BindDataSet(Qry, "CitizenType")
            If dsdob.Tables("CitizenType").Rows.Count > 0 Then
                AgeAsOnDate = dsdob.Tables("CitizenType").Rows(0)("dob")
                MemberType = dsdob.Tables("CitizenType").Rows(0)("MemberType")
                If MemberID.StartsWith("X-") = True Then
                    GetCitizenType_old = "NA"
                ElseIf MemberType = "D" Or MemberType = "D" Then
                    GetCitizenType_old = "NA"
                ElseIf AgeAsOnDate <= 60 Then
                    GetCitizenType_old = "Normal"
                ElseIf AgeAsOnDate > 60 And AgeAsOnDate <= 80 Then
                    GetCitizenType_old = "Senior Citizen"
                ElseIf AgeAsOnDate > 80 Then
                    GetCitizenType_old = "Super Senior"
                End If
            End If
        Catch ex As Exception
            Message = ex.Message
        End Try
    End Function


    Public Function GetAvailableCreditLimit(ByVal MemberID As String) As Double
        Dim CreditLimit As Double = 0
        GB_DefinedCreditLimit = 0
        Dim Qry As String = "SELECT MAINID FROM MM_MemberInformation WHERE MEMBERID='" & MemberID & "' and Type in('M','S','D')"
        Dim MainID As String = ObjDatabase.ExecuteScalarS(Qry)
        If MainID <> "" Then
            Dim str As String = "Proc_GetOutstandingAmtForPOS '" & MainID & "'"
            Dim OutstandingAmt As Double = 0
            ds = New DataSet
            ds = ObjDatabase.BindDataSet(str, "Outstanding")
            If ds.Tables(0).Rows.Count > 0 Then
                OutstandingAmt = Val(ds.Tables(0).Rows(0).Item("BalanceAmt") & "")
            Else
                OutstandingAmt = 0
            End If
            Qry = "select CreditLimit from MM_MemberProfile mm, MM_MemberInformation MI where MI.MemberID='" & MemberID & "' and mm.MemberID=mi.MainId and mi.Type in('M','S','D')"
            CreditLimit = ObjDatabase.ExecuteScalarS(Qry)
            GB_DefinedCreditLimit = CreditLimit
            GetAvailableCreditLimit = (CreditLimit - OutstandingAmt)
        Else
            GetAvailableCreditLimit = 0
        End If
    End Function

    Public Function GetCreditLimit(ByVal MemberID As String) As Double
        Dim CreditLimit As Double = 0
        Try
            Dim Qry As String = "select CreditLimit from MM_MemberProfile mm, MM_MemberInformation mi where mi.MemberID='" & MemberID & "' and mm.MemberID=mi.MainId and MI.Type in('M','S','D')"
            CreditLimit = ObjDatabase.ExecuteScalarS(Qry)
            GetCreditLimit = CreditLimit.ToString("###0.00")
        Catch ex As Exception
            GetCreditLimit = 0
        End Try
    End Function

    Public Function ChecktheValidityApplicability(ByVal Billhead As String) As String
        Dim QryString As String = ""
        Dim ValidityApplicability As String = ""
        QryString = "SELECT IsNull(FlagValidity,'No') FlagValidity FROM AC_BillHead where Code=" & Billhead
        Dim dr As SqlDataReader
        dr = ObjDatabase.DataReaderData(QryString)
        Try
            If (dr.Read) Then
                ValidityApplicability = dr(0)
            Else
                ValidityApplicability = "No"
            End If
            dr.Close()
            ObjDatabase.CloseDatabaseConnection()
        Catch ex As Exception

        End Try
        ChecktheValidityApplicability = ValidityApplicability
    End Function

    Public Function GetSmartCardClosingBalance(ByVal MemberID As String) As Double
        If MemberID = "" Then
            GetSmartCardClosingBalance = 0
            Exit Function
        End If
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adp As New SqlDataAdapter
        Dim ds As New DataSet
        Dim Flag As Integer = 0
        con.ConnectionString = ConnectionStr
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "Proc_SmartCardCurrentBalance"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 10000
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@MemberID", MemberID)
        adp.SelectCommand = cmd
        adp.Fill(ds, "Table")
        GetSmartCardClosingBalance = ds.Tables(0)(0)("ClosingBalance")
    End Function

    Public Function GetSmartCardIssueNo(ByVal MemberID As String) As Integer
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adp As New SqlDataAdapter
        Dim ds As New DataSet
        Dim Flag As Integer = 0
        con.ConnectionString = ConnectionStr
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "Proc_SmartCardCurrentBalance"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 10000
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@MemberID", MemberID)
        adp.SelectCommand = cmd
        adp.Fill(ds, "Table")
        GetSmartCardIssueNo = ds.Tables(0)(0)("IssueNo")
    End Function

    Public Function ValidateClientServerDate() As Boolean
        Dim Flag As Boolean
        Dim date1, date2 As DateTime
        date1 = Format(CurrentServerDate, DateFormat)
        date2 = Format(Now, DateFormat)
        If DateDiff(DateInterval.Day, date1, date2) <> 0 Then
            MsgBox("Client & Server date don't match", MsgBoxStyle.Critical, "Alert")
            Flag = False
        Else
            Flag = True
        End If
        ValidateClientServerDate = Flag
    End Function

    Public Function FinancialYearCheck(ByVal CurrentDate As Date) As Boolean
        ObjDatabase.ConnectDatabse()
        Dim strSql As String = ""
        Dim Flag As Boolean
        strSql = "select Count(*) from AC_FinancialYear where '" & CurrentDate.ToString(DateFormat) & "' Between DateFrom and DateTo and yearCode=" & YearCode
        Dim FinYearCheck As Integer = ObjDatabase.ExecuteScalarN(strSql)
        ObjDatabase.CloseDatabaseConnection()
        If FinYearCheck = 0 Then
            MsgBox("Current date should be within the Financial year", MsgBoxStyle.OkOnly, "Information")
            Flag = False
        Else
            Flag = True
        End If
        FinancialYearCheck = Flag
    End Function

    Public Function GetMemberAccountLastBillAmt(ByVal MemberID As String) As Double
        Dim AvailableCreditLimit As Double = 0
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adp As New SqlDataAdapter
        Dim ds As New DataSet
        Dim Flag As Integer = 0
        con.ConnectionString = ConnectionStr
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "Proc_GetOutstandingAmtLastBill"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 10000
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@MemberID", MemberID)
        adp.SelectCommand = cmd
        adp.Fill(ds, "Table")
        GB_LastBillOutstanding = IIf(IsDBNull(ds.Tables("Table").Rows(0)("BalanceAmt")) = True, 0, ds.Tables("Table").Rows(0)("BalanceAmt"))
        GetMemberAccountLastBillAmt = GB_LastBillOutstanding
    End Function

    Public Function GetSecurityAmt(ByVal MemberID As String) As Double
        Dim str As String = "select isnull(cm.SecurityAmount,0) from MM_MemberInformation MI, AC_Category CM where MI.Category=CM.CategoryCode and MI.MemberID='" & MemberID & "'"
        Dim MainID As String = ObjDatabase.ExecuteScalar(str)
        GetSecurityAmt = MainID
    End Function

    Public Sub BindTempTablesForPOSBillPrint(ByVal _BillNo As Integer, ByVal _Location As Integer, ByVal _YearCode As Integer)
        StrSql = "select Max(YearCode) from AC_FinancialYear"
        Dim _CurrFY As String = ObjDatabase.ExecuteScalarN(StrSql)

        If _YearCode = _CurrFY Then YearCodeSuffix = "" Else YearCodeSuffix = "_FY"
        Dim KOTStr As String = ""
        ObjDatabase.ConnectDatabse()
        StrSql = "SELECT  STUFF((SELECT  ',' + CONVERT(VARCHAR(max),KOTNo) FROM FB_BillBody" & YearCodeSuffix & " where BillNo=" & Val(_BillNo) & " and YearCode=" & Val(_YearCode) & " and LocationCode=" & Val(_Location) & " FOR XML PATH('')), 1, 1, '') AS KOTNos"
        KOTStr = ObjDatabase.ExecuteScalarS(StrSql)

        StrSql = "Delete from TI_BillHead where billNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _Location
        ObjDatabase.ExecuteNonQuery(StrSql)

        StrSql = "Delete from TI_BillBody where billNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _Location
        ObjDatabase.ExecuteNonQuery(StrSql)

        StrSql = "Delete from TI_KOTBody where KOTNo in(" & KOTStr & ") and YearCode=" & _YearCode & " and LocationCode=" & _Location
        ObjDatabase.ExecuteNonQuery(StrSql)

        StrSql = "Delete from TI_KOTHead where KOTNo in(" & KOTStr & ") and YearCode=" & _YearCode & " and LocationCode=" & _Location
        ObjDatabase.ExecuteNonQuery(StrSql)

        StrSql = "INSERT INTO TI_BillHead" & _
        " SELECT * from FB_BillHead" & YearCodeSuffix & " where BillNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _Location
        ObjDatabase.ExecuteNonQuery(StrSql)

        StrSql = "INSERT INTO TI_BillBody" & _
        " SELECT * from FB_BillBody" & YearCodeSuffix & " where BillNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _Location
        ObjDatabase.ExecuteNonQuery(StrSql)

        StrSql = "INSERT INTO TI_KOTHead" & _
        " SELECT * from FB_KOTHead" & YearCodeSuffix & " where KOTNo in(" & KOTStr & ") and YearCode=" & _YearCode & " and LocationCode=" & _Location
        ObjDatabase.ExecuteNonQuery(StrSql)

        StrSql = "INSERT INTO TI_KOTBody(KOTNo, ItemCode, ItemName, OpenItem, UnitCode, Qty, ActualQty, Rate, SchemeRate, Amount, DiscountPer, TaxType, TaxPer, SCPer, CreationDate, ModificationDate, UserCode, LocationCode, YearCode)" & _
        " SELECT KOTNo, ItemCode, ItemName, OpenItem, UnitCode, Qty, ActualQty, Rate, SchemeRate, Amount, DiscountPer, TaxType, TaxPer, SCPer, CreationDate, ModificationDate, UserCode, LocationCode, YearCode" & _
        " from FB_KOTBody" & YearCodeSuffix & " where KOTNo in(" & KOTStr & ") and YearCode=" & _YearCode & " and LocationCode=" & _Location
        ObjDatabase.ExecuteNonQuery(StrSql)
    End Sub

    Public Function GetLastTransactionDate(ByVal _TableName As String, ByVal _ColumnName As String, ByVal _StoreColumnName As String, ByVal _StoreCode As Integer) As Date
        ObjDatabase.ConnectDatabse()
        Dim LastTxnDate As Date = Now
        StrSql = "Select isnull(max(" & _ColumnName & "),getdate()) LastDate from " & _TableName & " where YearCode=" & Val(YearCode) & " and " & _StoreColumnName & "=" & _StoreCode
        LastTxnDate = ObjDatabase.ExecuteScalarString(StrSql)
        ObjDatabase.CloseDatabaseConnection()
        GetLastTransactionDate = LastTxnDate
    End Function

    Public Function GetClosingStock(ByVal ItemCode As String, ByVal LocationCode As Integer) As Double
        Dim ClosingStock As Double = 0 '[Proc_SubStoreStockItem] 10098,8
        StrSql = "Proc_SubStoreStockItem " & Val(ItemCode) & "," & LocationCode
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(StrSql, "Stock")
        If ds.Tables(0).Rows.Count > 0 Then
            ClosingStock = Val(ds.Tables("Stock").Rows(0).Item("ClosingStock"))
        Else
            ClosingStock = 0
        End If
        GetClosingStock = ClosingStock
    End Function

    Public Function GetClosingStockStore(ByVal StoreCode As Integer, ByVal ItemCode As Integer)
        Try
            Dim ClosingStock As Double = 0
            StrSql = "Proc_StoreStockItem '" & Format(CurrentServerDate, DateFormat) & "'," & Val(StoreCode) & "," & Val(ItemCode)
            ds = New DataSet
            ds = ObjDatabase.BindDataSet(StrSql, "CS")
            StrSql = "select Sum(ClosingBalance) ClosingBalance from [IM_StoreStockItem] where ItemCode=" & Val(ItemCode)
            ds = New DataSet
            ds = ObjDatabase.BindDataSet(StrSql, "CS")
            If ds.Tables(0).Rows.Count > 0 Then
                ClosingStock = Val(ds.Tables("CS").Rows(0).Item("ClosingBalance") & "")
            End If
            GetClosingStockStore = ClosingStock
        Catch ex As Exception
        End Try
    End Function

    Public Function CheckGSTApplicability(ByVal Billhead As String) As String
        Dim QryString As String = ""
        Dim GSTApplicability As Decimal = 0.0
        QryString = "select tm.ValuePercentage from AC_BillHead bh, AC_TaxMaster tm where bh.GSTTaxCode=tm.Code and bh.Code=" & Billhead
        Dim dr As SqlDataReader
        dr = ObjDatabase.DataReaderData(QryString)
        Try
            If (dr.Read) Then
                GSTApplicability = dr(0)
            Else
                GSTApplicability = "No"
            End If
            dr.Close()
            ObjDatabase.CloseDatabaseConnection()
        Catch ex As Exception

        End Try
        CheckGSTApplicability = GSTApplicability
    End Function

    Public Function GetBillingMode(ByVal MemberID As String) As String
        Dim _BillingMode As String = ""
        Dim Memtype, TypeOfMember As String
        Memtype = GetMemberType(MemberID)
        TypeOfMember = GetTypeOfMember(MemberID)
        If (Memtype.ToUpper = "NONMEMBER") Then
            _BillingMode = "Single"
        Else
            RecCount = ObjDatabase.ExecuteScalarN("select count(*) from AC_ModeOfPayment where Location='POS' and Status='Active'")
            If RecCount > 1 Then _BillingMode = "Dual" Else _BillingMode = "Single"
        End If
        GetBillingMode = _BillingMode
    End Function

    Public Sub BindTempTablesForPOSReports(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal _YearCode As Integer)
        StrSql = "Proc_POSMiscReports"
        Dim ReportComments As String = ""
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim adp As New SqlDataAdapter
        Dim ds As New DataSet
        Try
            con.ConnectionString = "data source=" & SQLServerName & "; initial catalog=" & SQLServerDatabase & "; user id=" & SQLServerUserName & "; password=" & SQLServerPassword & ""
            cmd.Connection = con
            cmd.CommandTimeout = 500000
            cmd.Connection.Open()
            cmd.CommandText = StrSql
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DateFrom", Format(DateFrom, "dd/MMM/yyyy"))
            cmd.Parameters.AddWithValue("@DateTo", Format(DateTo, "dd/MMM/yyyy"))
            cmd.Parameters.AddWithValue("@YearCode", Val(_YearCode))
            adp.SelectCommand = cmd
            adp.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

End Module

