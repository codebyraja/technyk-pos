Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportAppServer

Public Class frmSmartCardTransactionEnquiry
    Dim ds As New DataSet
    Dim NoOfrecords As Integer
    Dim NoOfrecordsStr As String
    Dim CardID As String = ""
    Dim MemberType As String
    Dim Flag As String = ""

    Private Sub frmSmartCardTransactionEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnPrintReport.Enabled = True
        btnSearch.Enabled = False
        BindSearchGridLoad()
        dgSearch.Columns(0).Visible = True
        dgSearch.RowHeadersVisible = True
        dgSearch.RowHeadersWidth = 20
        dgSearch.Columns(0).Width = 20
        PanelDisplay.Visible = False
        txtMainID.Focus()
        dtpDateFrom.Focus()
        lblOpeningBalanceCr.Visible = False
        lblOpeningBalanceDr.Visible = False
        lblOpeningBalance.Visible = False
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lblCount.Text = "Preparing Data." : Me.Refresh()
        txtCharge.Text = "0.00"
        txtSale.Text = "0.00"
        lblOpeningBalanceDr.Text = "0.00"
        txtClosingBalance.Text = "0.00"
        If txtMainID.Text = "" Then
            ErrorProvider1.SetError(txtMainID, "Enter Mem_ID/Card_ID")
            txtMainID.Focus()
            Exit Sub
        End If
        PopulateMemberTransactions(txtMainID.Text, Val(lblIssueNo.Text))
        BindSearchGrid()
        If dgSearch.RowCount > 0 Then
            btnPrintReport.Enabled = True
        Else
            btnPrintReport.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        BackToMainScreen = True
        Me.Dispose()
    End Sub

    Private Sub BindSearchGridLoad()
        strSql = "Select [MemberID] as MemberID,[MemberName] as Name,[BillNo],[BillDate] as BillDate,[CrAmount] as CrAmt,[DrAmount] as DrAmt,[Location],[TransType] as TransType,TransDescription,[IssueNo] as IssueNo,YearCode,LocationCode" & _
        " FROM [CM_MemberCardTransaction]" & _
        " where 1=2"
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(strSql, "member")
        dgSearch.DataSource = ds
        dgSearch.DataMember = ds.Tables(0).ToString()
        lblCount.Text = ""
        lblCount.Text = "Total Records = " & dgSearch.Rows.Count()
        FormatDataGridView(dgSearch)
        dgSearch.Columns("BillDate").DefaultCellStyle.Format = DateFormat
        dgSearch.RowHeadersVisible = False
        If ds.Tables(0).Rows.Count >= 0 Then
            CalculateSummary(ds)
            dgSearch.RowHeadersVisible = True
            dgSearch.RowHeadersWidth = 20
        End If
        FormatGrid()
    End Sub

    Private Sub BindSearchGrid()
        StrSql = "Select [MemberID] as MemberID,[MemberName] as Name,[BillNo],[BillDate] as BillDate,[CrAmount] as CrAmt,[DrAmount] as DrAmt,[Location],[TransType] as TransType,TransDescription,[IssueNo] as IssueNo,YearCode,LocationCode" & _
        " FROM [CM_MemberCardTransaction]" & _
        " where [BillDate] >= '" & Format(dtpDateFrom.Value, DateFormat) & "'" & _
        IIf(txtMainID.Text <> "", " and [MemberID] = '" & txtMainID.Text & "'", "") & _
        " Order by SettlementDate ASC"
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(StrSql, "member")
        dgSearch.DataSource = ds
        dgSearch.DataMember = ds.Tables(0).ToString()
        lblCount.Text = ""
        lblCount.Text = "Total Records = " & dgSearch.Rows.Count()
        FormatDataGridView(dgSearch)
        dgSearch.Columns("BillDate").DefaultCellStyle.Format = DateFormat
        dgSearch.RowHeadersVisible = False
        If ds.Tables(0).Rows.Count >= 0 Then
            CalculateSummary(ds)
            dgSearch.RowHeadersVisible = True
            dgSearch.RowHeadersWidth = 20
        End If
        FormatGrid()
    End Sub

    Private Sub FormatGrid()
        Try
            dgSearch.Columns(0).Visible = True
            dgSearch.Columns(0).Width = 25
            dgSearch.RowHeadersVisible = True
            dgSearch.Columns("LocationCode").Visible = False
            dgSearch.Columns("MemberID").Width = 80
            dgSearch.Columns("MemberID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgSearch.Columns("MemberID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgSearch.Columns("MemberID").HeaderText = "C_ID"
            dgSearch.Columns("Name").Visible = False
            dgSearch.Columns("TransDescription").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgSearch.Columns("TransDescription").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgSearch.Columns("TransDescription").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgSearch.Columns("BillNo").Width = 65
            dgSearch.Columns("BillNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("BillNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("BillNo").HeaderText = "Bill No"
            dgSearch.Columns("BillDate").Width = 100
            dgSearch.Columns("BillDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("BillDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("BillDate").DefaultCellStyle.Format = DateFormat
            dgSearch.Columns("BillDate").HeaderText = "BillDate"
            dgSearch.Columns("CrAmt").Width = 80
            dgSearch.Columns("CrAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("CrAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("CrAmt").DefaultCellStyle.Format = "#####0.00"
            dgSearch.Columns("DrAmt").Width = 80
            dgSearch.Columns("DrAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("DrAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("DrAmt").DefaultCellStyle.Format = "#####0.00"
            dgSearch.Columns("Location").Width = 110
            dgSearch.Columns("Location").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgSearch.Columns("Location").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgSearch.Columns("TransType").Width = 100
            dgSearch.Columns("TransType").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgSearch.Columns("TransType").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgSearch.Columns("IssueNo").Width = 60
            dgSearch.Columns("IssueNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("IssueNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgSearch.Columns("YearCode").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CalculateSummary(ByVal Data As DataSet)
        Dim OpDrAmt, OpCrAmt As Double
        StrSql = "Select isnull(SUM([DrAmount]),0) as DrAmt from CM_MemberCardTransaction where MemberID LIKE '" & txtMainID.Text & "%' AND [IssueNo]=" & Val(lblIssueNo.Text) & " AND [BillDate]<'" & dtpDateFrom.Value.ToString(DateFormat) & "'"
        OpDrAmt = ObjDatabase.ExecuteScalarN(StrSql)
        StrSql = "Select isnull(SUM([CrAmount]),0) as CrAmt from CM_MemberCardTransaction where MemberID LIKE '" & txtMainID.Text & "%' AND [IssueNo]=" & Val(lblIssueNo.Text) & " AND [BillDate]<'" & dtpDateFrom.Value.ToString(DateFormat) & "'"
        OpCrAmt = ObjDatabase.ExecuteScalarN(StrSql)
        lblOpeningBalanceCr.Visible = True
        lblOpeningBalanceDr.Visible = True
        lblOpeningBalance.Visible = True
        lblOpeningBalanceDr.Text = "0.00"
        lblOpeningBalanceCr.Text = "0.00"
        lblOpeningBalanceDr.Visible = True
        lblOpeningBalanceCr.Visible = True
        If OpDrAmt > OpCrAmt Then
            lblOpeningBalanceDr.Text = (OpDrAmt - OpCrAmt)
            lblOpeningBalanceCr.Visible = False
        ElseIf OpCrAmt > OpDrAmt Then
            lblOpeningBalanceDr.Visible = False
            lblOpeningBalanceCr.Text = (OpCrAmt - OpDrAmt)
        ElseIf OpCrAmt = OpDrAmt And OpDrAmt = 0 Then
            lblOpeningBalanceCr.Visible = True
            lblOpeningBalanceDr.Visible = False
            lblOpeningBalanceCr.Text = "0.00"
        End If
        Dim i As Integer
        Dim Recharge, Sale As Double
        Recharge = 0 : Sale = 0 '[DrAmount],[]
        For i = 0 To Data.Tables("member").Rows.Count - 1
            Sale += Data.Tables(0).Rows(i)("DrAmt")
            Recharge += Data.Tables(0).Rows(i)("CrAmt")
        Next
        txtCharge.Text = (Recharge).ToString("0.00")
        txtSale.Text = (Sale).ToString("0.00")
        lblOpeningBalanceDr.Text = Val(lblOpeningBalanceDr.Text).ToString("0.00")
        lblOpeningBalanceCr.Text = Val(lblOpeningBalanceCr.Text).ToString("0.00")
        txtClosingBalance.Text = Format((Val(txtCharge.Text) + Val(lblOpeningBalanceCr.Text)) - (Val(txtSale.Text) + Val(lblOpeningBalanceDr.Text)), "0.00")
    End Sub

    Private Sub GetMemberCardDetails(ByVal TCardID As String)
        If TCardID = "" Then Exit Sub
        MemberType = GetMemberType(TCardID)
        If Not MemberType = Nothing Then
            If (MemberType.ToUpper() = "NONMEMBER") Then
                Try
                    ds = New DataSet
                    If chbActiveCard.Checked = True Then
                        StrSql = "Select MemberID,IssuedName,IssueNo,IssuedID,Flag  From CM_CardIssue where MemberID='" & Trim(TCardID) & "' and Flag in('Y')"
                    Else
                        StrSql = "Select MemberID,IssuedName,IssueNo,IssuedID,Flag  From CM_CardIssue where MemberID='" & Trim(TCardID) & "' and Flag in('N') and IssueDate between '" & dtpDateFrom.Value.ToString(DateFormat) & "' And '" & dtpDateTo.Value.ToString(DateFormat) & "'"
                    End If
                    ds = ObjDatabase.BindDataSet(StrSql, "Member")
                    If ds.Tables(0).Rows.Count = 0 Then
                        MsgBox("Invalid M_ID/C_ID", MsgBoxStyle.Information, "Information")
                        TCardID = ""
                        txtMainID.Focus()
                    Else
                        TCardID = Trim(ds.Tables("Member").Rows(0)("MemberID"))
                        lblMemID.Text = Trim(ds.Tables("Member").Rows(0)("IssuedID"))
                        lblName.Text = Trim(ds.Tables("Member").Rows(0)("IssuedName"))
                        lblIssueNo.Text = Trim(ds.Tables("Member").Rows(0)("IssueNo"))
                        lblCategory.Text = "NONMEMBER"
                        Flag = Trim(ds.Tables("Member").Rows(0)("Flag"))
                        If Flag = "Y" Then lblStatus.Text = "Active" Else lblStatus.Text = "Inactive"
                        btnSearch.Enabled = True
                    End If
                Catch ex As Exception
                End Try
            Else
                Try
                    ObjDatabase.ConnectDatabse()
                    lblIssueNo.Text = ObjDatabase.ExecuteScalar("Select TOP 1 IssueNo FROM CM_CardIssue WHERE MemberID='" & TCardID & "' Order by IssueNo Desc")
                    lblIssueNo.Text = Val(lblIssueNo.Text)
                Catch ex As Exception
                End Try
            End If
        End If
        btnSearch.Enabled = True
    End Sub

    Private Sub txtMainID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMainID.TextChanged
        If txtMainID.Text = "" Then
            txtMainID.Text = ""
            lblMemID.Text = ""
            lblName.Text = ""
            lblIssueNo.Text = ""
            lblStatus.Text = ""
            lblCategory.Text = ""
            lblOpeningBalanceDr.Text = ""
            btnSearch.Enabled = True
            BindSearchGrid()
            txtCharge.Text = ""
            txtSale.Text = ""
            txtClosingBalance.Text = ""
        End If
    End Sub

    Private Sub txtMainID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMainID.Validated
        If txtMainID.Text = "" Then
            BindSearchGridLoad()
        Else
            MemberType = GetMemberType(txtMainID.Text)
            If MemberType = Nothing Then Exit Sub
            If MemberType.ToUpper() = "MEMBER" Or MemberType.ToUpper() = "CORPORATE" Then
                GetMemberDetails(txtMainID.Text)
                If GBName = "" Then
                    ErrorProvider1.SetError(txtMainID, "Invalid Member_ID")
                    txtMainID.Focus()
                    Exit Sub
                Else
                    txtMainID.Text = GBMemberID
                    lblName.Text = GBName
                    lblMemID.Text = GBOldMemNo
                    lblCategory.Text = GBCategoryName
                    lblStatus.Text = GBStatusName
                End If
            ElseIf MemberType.ToUpper() = "NONMEMBER" Then
                GetNonMemberDetails(txtMainID.Text)
                txtMainID.Text = GBMemberID
                lblName.Text = GBName
                lblMemID.Text = GBMemberID
                lblCategory.Text = "Non Member"
                lblStatus.Text = "Active"
            End If
            GetMemberCardDetails(GBMemberID)
        End If
    End Sub

    Private Sub PopulateMemberTransactions(ByVal MemberId As String, ByVal IssueNo As Integer)
        Try
            Dim cmd As New SqlCommand
            Dim adp As New SqlDataAdapter
            Dim con As New SqlConnection
            con.ConnectionString = "data source=" & SQLServerName & "; initial catalog=" & SQLServerDatabase & "; user id=" & SQLServerUserName & "; password=" & SQLServerPassword
            cmd.Connection = con
            cmd.CommandTimeout = 5000
            cmd.Connection.Open()
            cmd.CommandText = "Proc_SmartCardTransactionEnquiry"
            cmd.Parameters.AddWithValue("@Dateto", Format(dtpDateTo.Value, DateFormat))
            cmd.Parameters.AddWithValue("@MemberID", MemberId)
            cmd.Parameters.AddWithValue("@IssueNo", IssueNo)
            cmd.CommandType = CommandType.StoredProcedure
            adp.SelectCommand = cmd
            adp.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgsearch_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearch.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim MemberID As String = dgSearch.CurrentRow.Cells("MemberID").Value.ToString()
            Dim LocationType As String = dgSearch.CurrentRow.Cells("TransType").Value.ToString()
            Dim BillDate As String = dgSearch.CurrentRow.Cells("BillDate").Value.ToString()
            Dim _BillNo As String = dgSearch.CurrentRow.Cells("BillNo").Value.ToString()
            Dim _YearCode As String = dgSearch.CurrentRow.Cells("YearCode").Value.ToString()
            Dim _LocationName As String = dgSearch.CurrentRow.Cells("Location").Value.ToString()
            Dim DrAmount As String = dgSearch.CurrentRow.Cells("DrAmt").Value.ToString()
            Dim CrAmount As String = dgSearch.CurrentRow.Cells("CrAmt").Value.ToString()
            Dim IssueNo As String = dgSearch.CurrentRow.Cells("IssueNo").Value.ToString()
            Dim LocationCode As String = dgSearch.CurrentRow.Cells("LocationCode").Value.ToString()
            'If LocationType.ToUpper = "CHARGE/RECHARGE" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    PrintCrystalSmartCardCharge(_BillNo, _YearCode, 0)
            'ElseIf LocationType.ToUpper = "POS" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    PrintWindowsPOSBillThermal(_BillNo, _YearCode, LocationCode, 0)
            'ElseIf LocationType.ToUpper = "MISC BILLING" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    DisplayCrystalMiscellaeneousBill(_BillNo, _YearCode, 0)
            'ElseIf LocationType.ToUpper = "RECEIPT VOUCHER" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    PrintCrystalReceiptVoucher(_BillNo, _YearCode, LocationCode, 0)
            'ElseIf LocationType.ToUpper = "HEALTH CLUB" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    DisplayCrystalHealthClubBill(_BillNo, _YearCode, 0)
            'ElseIf LocationType.ToUpper = "CARD REFUND" Then
            '    CrystalReportViewer2.Visible = True
            '    PanelDisplay.Visible = True
            '    PrintCrystalRefundVoucher(_BillNo, _YearCode, 0)
            'ElseIf LocationType.ToUpper = "GREEN FEE" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    DisplayCrystalGreenFeeBill(_BillNo, _YearCode, 0)
            'End If
        End If
    End Sub

    Private Sub btnCloseDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseDisplay.Click
        PanelDisplay.Visible = False
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'CrystalReportViewer2.PrintReport()
    End Sub

    'Private Sub btnPrintSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintReport.Click
    '    Dim objfrmreport As New FrmReportView
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptDebitEnquiry.rpt")
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    StrSql = ""
    '    strSql = "{CM_MemberCardTransaction.MemberID}='" & txtMainID.Text & "' and {CM_MemberCardTransaction.BillDate} in  date(" & Format(dtpDateFrom.Value, "yyyy, MM, dd") & ") to date(" & Format(dtpDateTo.Value, "yyyy, MM, dd") & ")"
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "SmartCard Transaction Summary for the Period: " & dtpDateFrom.Value.ToString(DateFormat) & " To " & dtpDateTo.Value.ToString(DateFormat) & "; "
    '    If Val(lblOpeningBalanceDr.Text) > 0 Then
    '        CrystalReportDocument.SummaryInfo.ReportComments = Val(lblOpeningBalanceDr.Text) * -1
    '    ElseIf Val(lblOpeningBalanceCr.Text) > 0 Then
    '        CrystalReportDocument.SummaryInfo.ReportComments = Val(lblOpeningBalanceCr.Text)
    '    Else
    '        CrystalReportDocument.SummaryInfo.ReportComments = Val(0.0)
    '    End If
    '    CrystalReportDocument.RecordSelectionFormula = StrSql
    '    objfrmreport.CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    objfrmreport.Show()
    'End Sub

    'Private Sub PrintCrystalReceiptVoucher(ByVal _RCVNO As Integer, ByVal _YEARCode As Integer, ByVal _LOCATIONCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptReceiptVoucherPOS.rpt")
    '    CrystalReportDocument.RecordSelectionFormula = "{CM_RVHead.RCVNo}=" & Val(_RCVNO) & " AND {CM_RVHead.YearCode}=" & _YEARCode & " AND {CM_RVHead.LocationCode}=" & _LOCATIONCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE RECEIPT VOUCHER"
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    'Private Sub DisplayCrystalGreenFeeBill(ByVal Transno As Integer, ByVal YearCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptGreenFeeBillPOS.rpt")
    '    CrystalReportDocument.RecordSelectionFormula = "{CM_GreenFeeHead.VchNo}=" & Val(Transno) & " AND {CM_GreenFeeHead.YearCode}=" & YearCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE GREEN FEE"
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    'Private Sub PrintCrystalRefundVoucher(ByVal _VchNo As Integer, ByVal _YearCode As String, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptSmartCardRefundPOS.rpt")
    '    CrystalReportDocument.RecordSelectionFormula = "{CM_CardRefund.VchNo}=" & Val(_VchNo) & " AND {CM_CardRefund.YearCode}=" & _YearCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE SMARTCARD REFUND"
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    'Private Sub PrintCrystalSmartCardCharge(ByVal _VchNo As Integer, ByVal _YearCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptSmartCardChargePOS.rpt")
    '    CrystalReportDocument.RecordSelectionFormula = "{CM_CardIssueDetail.VchNo}=" & Val(_VchNo) & " AND {CM_CardIssueDetail.YearCode}=" & _YearCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE"
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    'Private Sub DisplayCrystalMiscellaeneousBill(ByVal VchNo As Integer, ByVal YearCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptMiscellaneousBillPOS.rpt")
    '    CrystalReportDocument.RecordSelectionFormula = "{CM_MiscBillHead.VchNo}=" & Val(VchNo) & " AND {CM_MiscBillHead.YearCode}=" & YearCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE MISCELLANEOUS BILL"
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    'Private Sub DisplayCrystalHealthClubBill(ByVal VchNo As Integer, ByVal YearCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptHealthClubBill.rpt")
    '    CrystalReportDocument.RecordSelectionFormula = "{HC_BillHead.VchNo}=" & Val(VchNo) & " AND {HC_BillHead.YearCode}=" & YearCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE HEALTH CLUB BILL"
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    Public Sub PrintWindowsPOSBillThermal(ByVal _BillNo As Integer, ByVal _YearCode As Integer, ByVal _LocationCode As Integer, ByVal PrintFlag As String)
        Dim KOTStr As String = ""
        ObjDatabase.ConnectDatabse()
        StrSql = "Select  STUFF((Select  ',' + CONVERT(VARCHAR(max),KOTNo) FROM FB_BillBody where BillNo=" & Val(_BillNo) & " and YearCode=" & Val(_YearCode) & " and LocationCode=" & Val(_LocationCode) & " FOR XML PATH('')), 1, 1, '') AS KOTNos"
        KOTStr = ObjDatabase.ExecuteScalarS(StrSql)
        StrSql = "Delete from TI_BillHead where BillNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
        ObjDatabase.ExecuteNonQuery(StrSql)
        StrSql = "Delete from TI_BillBody where BillNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
        ObjDatabase.ExecuteNonQuery(StrSql)
        StrSql = "Delete from TI_KOTBody where KOTNo in(" & KOTStr & ") and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
        ObjDatabase.ExecuteNonQuery(StrSql)
        StrSql = "Delete from TI_KOTHead where KOTNo in(" & KOTStr & ") and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
        ObjDatabase.ExecuteNonQuery(StrSql)
        StrSql = "INSERT INTO TI_BillHead" & _
        " Select * from FB_BillHead where BillNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
        ObjDatabase.ExecuteNonQuery(StrSql)
        StrSql = "INSERT INTO TI_BillBody" & _
        " Select * from FB_BillBody where BillNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
        ObjDatabase.ExecuteNonQuery(StrSql)
        StrSql = "INSERT INTO TI_KOTHead" & _
        " Select * from FB_KOTHead where KOTNo in(" & KOTStr & ") and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
        ObjDatabase.ExecuteNonQuery(StrSql)
        StrSql = "INSERT INTO TI_KOTBody" & _
        " Select * from FB_KOTBody where KOTNo in(" & KOTStr & ") and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
        ObjDatabase.ExecuteNonQuery(StrSql)
        'CrystalReportDocument = New ReportDocument
        'CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptFNBBill.rpt")
        'CrystalReportDocument.RecordSelectionFormula = "{TI_BillHead.BillNo}=" & _BillNo & " AND {TI_BillHead.YearCode}=" & _YearCode & " and {TI_BillHead.LocationCode}=" & _LocationCode
        'CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
        'CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
        'CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE BILL"
        'If PrintFlag = 1 Then
        '    CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
        'ElseIf PrintFlag = 0 Then
        '    CrystalReportViewer2.ReportSource = CrystalReportDocument
        'End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtMainID.Text = ""
        lblStatus.Text = ""
        lblCategory.Text = ""
        lblName.Text = ""
        lblIssueNo.Text = ""
        BindSearchGridLoad()
    End Sub
End Class