Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.ReportSource
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.ReportAppServer

Public Class frmCreditTransactionEnquiry
    Dim ds As DataSet
    Dim NoOfrecords As Integer
    Dim NoOfrecordsStr As String

    Private Sub frmCreditTransactionEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim StrSQL As String = "Select distinct LocationName from MM_MemberCreditEnquiry"
        comboBindingSelectAllOnly(StrSQL, "LocationName", "LocationName", cmbLocation)
        cmbLocation.SelectedValue = "[Select All]"
        cmbLocation.Text = "[Select All]"
        btnSearch.Enabled = False
        txtC_ID.Focus()
        dgCreditEnquiry.RowHeadersVisible = True
        PanelDisplay.Visible = False
        bindSearchGridLoad()
        chbDateFrom.Visible = True
        txtC_ID.Focus()
        dtpDateFrom.MinDate = MemberAccountOpening.ToString(DateFormat)
        lblAllotedLimit.Text = "0.00"
        lblAvailableLimit.Text = "0.00"
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lblCount.Text = "Preparing Data."
        Me.Refresh()
        txtAmountDr.Text = "0.00"
        PopulateMemberTransactions()
        bindSearchGrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        BackToMainScreen = True
        Me.Dispose()
    End Sub

    Private Sub BindSearchGrid()
        If txtC_ID.Text <> "" Then
            lblopeningDr.Text = ""
            lblopeningDr.Tag = ""
            lblOpeningCr.Text = ""
            lblOpeningCr.Tag = ""
            txtAmountCr.Text = "0.00"
            txtAmountDr.Text = "0.00"
            Dim OpeningAmt, DrOpeningAmt, CrOpeningAmt As Double
            If dtpDateFrom.Value.ToString(DateFormat) <= CDate(MemberAccountOpening) Then
                OpeningAmt = objDatabase.ExecuteScalarN("Select isnull([OpeningAmt],0) from [MM_MemberAccountOpening] where  [MemberID]='" & txtC_ID.Text & "'")
                If OpeningAmt > 0 Then
                    lblopeningDr.Tag = Math.Abs(OpeningAmt)
                    lblopeningDr.Text = Math.Abs(OpeningAmt).ToString("####0.00 Dr.")
                    lblopeningDr.Visible = True
                    lblOpeningCr.Visible = False
                Else
                    CrOpeningAmt = Math.Abs(OpeningAmt)
                    lblOpeningCr.Tag = Math.Abs(OpeningAmt)
                    lblOpeningCr.Text = Math.Abs(OpeningAmt).ToString("####0.00 Cr.")
                    lblOpeningCr.Visible = True
                    lblopeningDr.Visible = False
                End If
            Else
                OpeningAmt = objDatabase.ExecuteScalarN("Select top 1 isnull(PayableAmount,0) from MM_BillHead where BillDate<'" & dtpDateFrom.Value.ToString(DateFormat) & "' and  MemberID='" & txtC_ID.Text & "' Order by billdate desc")
                If OpeningAmt > 0 Then
                    DrOpeningAmt = Math.Abs(OpeningAmt)
                    lblopeningDr.Tag = Math.Abs(OpeningAmt)
                    lblopeningDr.Text = Math.Abs(OpeningAmt).ToString("####0.00 Dr.")
                    lblopeningDr.Visible = True
                    lblOpeningCr.Visible = False
                Else
                    CrOpeningAmt = Math.Abs(OpeningAmt)
                    lblOpeningCr.Tag = Math.Abs(OpeningAmt)
                    lblOpeningCr.Text = Math.Abs(OpeningAmt).ToString("####0.00 Cr.")
                    lblOpeningCr.Visible = True
                    lblopeningDr.Visible = False
                End If
            End If
            Try
                Dim DrAmt, CrAmt, DrNetAmt, CrNetAmt As Double
                If dtpDateFrom.Value.ToString(DateFormat) > CDate(MemberAccountOpening) Then
                    Dim LastBillDate As DateTime = objDatabase.ExecuteScalar("Select top 1 isnull(BillDate,getdate()) from MM_BillHead where BillDate<'" & dtpDateFrom.Value.ToString(DateFormat) & "' and  MemberID='" & txtC_ID.Text & "' Order by billdate desc")
                    StrSql = "Select isnull(sum(DrAmount),0) DrAmount ,isnull(sum(CrAmount),0) CrAmount from [MM_MemberCreditEnquiry] "
                    StrSql &= " where [MemberID] ='" & txtC_ID.Text & "' and  ([BillDate] > '" & LastBillDate.ToString(DateFormat) & "' and [BillDate] < '" & dtpDateFrom.Value.ToString(DateFormat) & "')"
                    ds = New DataSet
                    ds = objDatabase.BindDataSet(StrSql, "Opening")
                    If ds.Tables("Opening").Rows.Count > 0 Then
                        DrAmt = ds.Tables("Opening").Rows(0)("DrAmount")
                        CrAmt = ds.Tables("Opening").Rows(0)("CrAmount")
                        If DrAmt > CrAmt Then
                            DrNetAmt = DrAmt - CrAmt
                        ElseIf CrAmt > DrAmt Then
                            CrNetAmt = CrAmt - DrAmt
                        Else
                            DrNetAmt = 0 : CrNetAmt = 0
                        End If
                        If DrNetAmt + DrOpeningAmt > CrNetAmt + CrOpeningAmt Then
                            lblOpeningCr.Text = "0"
                            lblOpeningCr.Tag = "0"
                            lblOpeningCr.Visible = False
                            lblopeningDr.Tag = Math.Abs(DrNetAmt + DrOpeningAmt - CrNetAmt - CrOpeningAmt)
                            lblopeningDr.Text = Math.Abs(DrNetAmt + DrOpeningAmt - CrNetAmt - CrOpeningAmt).ToString("####0.00 Dr.")
                        ElseIf DrNetAmt + DrOpeningAmt < CrNetAmt + CrOpeningAmt Then
                            lblopeningDr.Text = "0"
                            lblopeningDr.Tag = "0"
                            lblopeningDr.Visible = False
                            lblOpeningCr.Tag = Math.Abs(CrNetAmt + CrOpeningAmt - DrNetAmt - DrOpeningAmt)
                            lblOpeningCr.Text = Math.Abs(CrNetAmt + CrOpeningAmt - DrNetAmt - DrOpeningAmt).ToString("####0.00 Cr.")
                        Else
                            lblOpeningCr.Tag = 0
                            lblOpeningCr.Text = 0
                            lblOpeningCr.Visible = False
                            lblopeningDr.Tag = 0
                            lblopeningDr.Text = "0.00 Dr."
                            lblopeningDr.Visible = True
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            If Trim(txtC_ID.Text) <> "" Then
                StrSql = "Select BillNo,BillDate,MemberID,OldMemNo,Full_Name,LocationType,LocationName,DrAmount,CrAmount,YearCode,LocationCode  from [MM_MemberCreditEnquiry] where "
                StrSql &= " ([MemberID] LIKE '" & txtC_ID.Text & "%' OR OldMemNo like '" & txtC_ID.Text & "%') and  ([BillDate] >= '" & dtpDateFrom.Value.ToString(DateFormat) & "' and [BillDate] <= '" & dtpDateTo.Value.ToString(DateFormat) & "')"
                StrSql &= IIf(cmbLocation.Text <> "[Select All]", " and LocationName='" & cmbLocation.Text & "'", "").ToString
                StrSql &= " Order by [BillDate],LocationName"
                ds = New DataSet
                ds = objDatabase.BindDataSet(StrSql, "member")
                dgCreditEnquiry.DataSource = ds
                dgCreditEnquiry.DataMember = ds.Tables(0).ToString()
                lblCount.Text = ""
                lblCount.Text = "Total Records = " & dgCreditEnquiry.Rows.Count()
                FormatDataGridView(dgCreditEnquiry)
                dgCreditEnquiry.RowHeadersVisible = False
                FormatGrid()
            End If
            If ds.Tables(0).Rows.Count >= 0 Then
                CalculateSummary(ds)
                dgCreditEnquiry.RowHeadersVisible = True
                dgCreditEnquiry.RowHeadersWidth = 20
            End If
        End If
    End Sub

    Private Sub FormatGrid()
        dgCreditEnquiry.RowHeadersVisible = True
        dgCreditEnquiry.RowHeadersWidth = 20
        dgCreditEnquiry.Columns(0).Width = 30
        dgCreditEnquiry.Columns("YearCode").Visible = False
        dgCreditEnquiry.Columns("LocationCode").Visible = False
        dgCreditEnquiry.Columns("BillNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCreditEnquiry.Columns("BillNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCreditEnquiry.Columns("BillNo").Width = 60
        dgCreditEnquiry.Columns("BillDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCreditEnquiry.Columns("BillDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCreditEnquiry.Columns("BillDate").DefaultCellStyle.Format = DateFormat
        dgCreditEnquiry.Columns("BillDate").Width = 100
        dgCreditEnquiry.Columns("MemberID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("MemberID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("MemberID").HeaderText = "C_ID"
        dgCreditEnquiry.Columns("MemberID").Width = 75
        dgCreditEnquiry.Columns("OldMemNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("OldMemNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("OldMemNo").HeaderText = "M_ID"
        dgCreditEnquiry.Columns("OldMemNo").Visible = False
        dgCreditEnquiry.Columns("Full_Name").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("Full_Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("Full_Name").HeaderText = "Name"
        dgCreditEnquiry.Columns("Full_Name").Visible = False
        dgCreditEnquiry.Columns("LocationType").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("LocationType").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("LocationType").HeaderText = "Trans Type"
        dgCreditEnquiry.Columns("LocationType").Width = 150
        dgCreditEnquiry.Columns("DrAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCreditEnquiry.Columns("DrAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCreditEnquiry.Columns("DrAmount").DefaultCellStyle.Format = "#####0.00"
        dgCreditEnquiry.Columns("DrAmount").Width = 85
        dgCreditEnquiry.Columns("DrAmount").HeaderText = "Dr. Amt."
        dgCreditEnquiry.Columns("CrAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCreditEnquiry.Columns("CrAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgCreditEnquiry.Columns("CrAmount").DefaultCellStyle.Format = "#####0.00"
        dgCreditEnquiry.Columns("CrAmount").Width = 85
        dgCreditEnquiry.Columns("CrAmount").HeaderText = "Cr. Amt."
        dgCreditEnquiry.Columns("LocationNAme").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("LocationNAme").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgCreditEnquiry.Columns("LocationNAme").HeaderText = "Transaction Desc."
        dgCreditEnquiry.Columns("LocationNAme").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub bindSearchGridLoad()
        lblopeningDr.Text = ""
        lblopeningDr.Tag = ""
        lblOpeningCr.Text = ""
        lblOpeningCr.Tag = ""
        strSql = "Select BillNo,BillDate,MemberID,OldMemNo,Full_Name,LocationType,LocationName,DrAmount,CrAmount,YearCode,LocationCode  from [MM_MemberCreditEnquiry] where 1=2 and "
        strsql &= " ([MemberID] ='" & txtC_ID.Text & "' OR OldMemNo='" & txtC_ID.Text & "') and  ([BillDate] >= '" & dtpDateFrom.Value.ToString(DateFormat) & "' and [BillDate] <= '" & dtpDateTo.Value.ToString(DateFormat) & "')"
        strsql &= IIf(cmbLocation.Text <> "[Select All]", " and LocationName='" & cmbLocation.Text & "'", "").ToString
        strsql &= " Order by [BillDate],LocationName"
        ds = New DataSet
        ds = objDatabase.BindDataSet(strsql, "member")
        dgCreditEnquiry.DataSource = ds
        dgCreditEnquiry.DataMember = ds.Tables(0).ToString()
        lblCount.Text = ""
        lblCount.Text = "Total Records = " & dgCreditEnquiry.Rows.Count()
        FormatDataGridView(dgCreditEnquiry)
        FormatGrid()
        If ds.Tables(0).Rows.Count > 0 Then
            CalculateSummary(ds)
            dgCreditEnquiry.RowHeadersVisible = True
            dgCreditEnquiry.RowHeadersWidth = 20
        End If
    End Sub

    Private Sub CalculateSummary(ByVal Data As DataSet)
        Dim i As Integer
        Dim Recharge, Sale As Double
        lblTotalCrAmount.Visible = True
        lblTotalDrAmount.Visible = True
        Recharge = 0 : Sale = 0 '[Dr. Amount],[]
        For i = 0 To Data.Tables("member").Rows.Count - 1
            Sale += CDbl(Data.Tables(0).Rows(i)("DrAmount"))
            Recharge += CDbl(Data.Tables(0).Rows(i)("CrAmount"))
        Next
        txtAmountDr.Text = Format((Sale + Val(lblopeningDr.Tag)), "0.00")
        txtAmountCr.Text = Format((Recharge + Val(lblOpeningCr.Tag)), "0.00")
        If Val(txtAmountDr.Text) > Val(txtAmountCr.Text) Then
            lblTotalDrAmount.Text = (Val(txtAmountDr.Text) - Val(txtAmountCr.Text)).ToString("###0.00")
            lblTotalCrAmount.Visible = False
        ElseIf Val(txtAmountCr.Text) > Val(txtAmountDr.Text) Then
            lblTotalCrAmount.Text = (Val(txtAmountCr.Text) - Val(txtAmountDr.Text)).ToString("###0.00")
            lblTotalDrAmount.Visible = False
        Else
            lblTotalCrAmount.Text = "0.00"
            lblTotalDrAmount.Text = "0.00"
            lblTotalCrAmount.Visible = False
            lblTotalDrAmount.Visible = False
        End If
        lblAvailableLimit.Text = Val(GBCreditLimit) - (-Val(lblTotalCrAmount.Text) + Val(lblTotalDrAmount.Text))
        lblAvailableLimit.Text = Val(lblAvailableLimit.Text).ToString(NumFormat)
    End Sub


    Private Sub txtC_ID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtC_ID.TextChanged
        If txtC_ID.Text = "" Then
            txtC_ID.Text = ""
            lblMemID.Text = ""
            lblName.Text = ""
            txtIssueNo.Text = ""
            lblStatus.Text = ""
            lblCategory.Text = ""
            btnSearch.Enabled = True
            bindSearchGrid()
            txtAmountDr.Text = ""
        End If
    End Sub

    Private Sub txtC_ID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtC_ID.Validated
        If txtC_ID.Text = "" Then Exit Sub
        GBName = ""
        GetMemberDetails(txtC_ID.Text)
        If GBName = "" Then
            MsgBox("Invalid M_ID/C ID", MsgBoxStyle.Information, "Information")
            txtC_ID.Focus()
        Else
            txtC_ID.Text = GBMemberID
            lblName.Text = GBName
            lblStatus.Text = GBStatusName
            lblCategory.Text = GBCategoryName
            lblMemID.Text = GBOldMemNo
            lblAllotedLimit.Text = GBCreditLimit.ToString(NumFormat)
        End If
        lblopeningDr.Tag = ""
        lblopeningDr.Text = ""
        lblOpeningCr.Tag = ""
        lblOpeningCr.Text = ""
        Dim OpeningAmt As Double = objDatabase.ExecuteScalarN("Select top 1 isnull(PayableAmount,0) from MM_BillHead where BillDate<'" & dtpDateFrom.Value.ToString(DateFormat) & "' and  MemberID='" & txtC_ID.Text & "' Order by billdate desc")
        If OpeningAmt > 0 Then
            lblopeningDr.Tag = Math.Abs(OpeningAmt)
            lblopeningDr.Text = Math.Abs(OpeningAmt).ToString("####0.00 Dr.")
        Else
            lblOpeningCr.Tag = Math.Abs(OpeningAmt)
            lblOpeningCr.Text = Math.Abs(OpeningAmt).ToString("####0.00 Cr.")
        End If
        btnSearch.Enabled = True
    End Sub

    Private Sub dgCreditEnquiry_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCreditEnquiry.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim MemberID As String = dgCreditEnquiry.CurrentRow.Cells("MemberID").Value.ToString()
            Dim LocationType As String = dgCreditEnquiry.CurrentRow.Cells("LocationType").Value.ToString()
            Dim BillDate As String = dgCreditEnquiry.CurrentRow.Cells("BillDate").Value.ToString()
            Dim BillNo As String = dgCreditEnquiry.CurrentRow.Cells("BillNo").Value.ToString()
            Dim YearCode As String = dgCreditEnquiry.CurrentRow.Cells("YearCode").Value.ToString()
            Dim LocationName As String = dgCreditEnquiry.CurrentRow.Cells("LocationName").Value.ToString()
            Dim DrAmount As String = dgCreditEnquiry.CurrentRow.Cells("DrAmount").Value.ToString()
            Dim CrAmount As String = dgCreditEnquiry.CurrentRow.Cells("CrAmount").Value.ToString()
            Dim LocationCode As String = dgCreditEnquiry.CurrentRow.Cells("LocationCode").Value.ToString()

            'If LocationType = "POS" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    PrintWindowsPOSBillThermal(BillNo, YearCode, LocationCode, 0)
            'ElseIf LocationType = "Reception" And LocationName = "Misc Billing" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    PrintCrystalMiscellaeneousBill(BillNo, YearCode, 0)
            'ElseIf LocationType = "Reception" And LocationName = "Receipt" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    PrintCrystalReceiptVoucher(BillNo, YearCode, 0)
            'ElseIf LocationType = "Reception" And LocationName = "Caddie Billing" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    PrintCrystalCaddieBill(BillNo, YearCode, 0)
            'ElseIf LocationType = "Adjustment" Then
            '    PanelDisplay.Visible = True
            '    PanelDisplay.BringToFront()
            '    EnableControl(PanelDisplay)
            '    PrintMonthlyAdjustment(BillNo, YearCode, 0)
            'ElseIf LocationType = "Direct Charge" Then
            '    PanelDisplay.Visible = True
            '    PrintDirectCharge(BillNo, YearCode, 0)
            'End If
        End If
    End Sub

    Private Sub btnPrintReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintReport.Click
        Dim objfrmreport As New FrmReportView
        Dim ReportTitle As String = ""
        'CrystalReportDocument = New ReportDocument
        'CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptCreditEnquirySP.rpt")
        'CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
        'CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
        strSql = ""
        strSql = "{MM_MemberCreditEnquiry.MemberID}='" & txtC_ID.Text & "' and {MM_MemberCreditEnquiry.BillDate} in  date(" & Format(dtpDateFrom.Value, "yyyy, MM, dd") & ") to date(" & Format(dtpDateTo.Value, "yyyy, MM, dd") & ")"
        strSql &= IIf(cmbLocation.Text <> "[Select All]", " AND {MM_MemberCreditEnquiry.LocationName}='" & Trim(cmbLocation.Text) & "'", "").ToString()
        ReportTitle = "M_ID: " & lblMemID.Text & "; C_ID: " & txtC_ID.Text & "; Period: " & dtpDateFrom.Value.ToString(DateFormat) & " To " & dtpDateTo.Value.ToString(DateFormat) & "; "
        ReportTitle &= "Location: " & IIf(cmbLocation.Text <> "[Select All]", Trim(cmbLocation.Text) & "; ", "All; ").ToString()
        'CrystalReportDocument.RecordSelectionFormula = strSql
        'objfrmreport.CrystalReportViewer2.ReportSource = CrystalReportDocument
        'CrystalReportDocument.SummaryInfo.ReportTitle = ReportTitle
        'If Val(lblOpeningCr.Text) > 0 Then
        '    CrystalReportDocument.SummaryInfo.ReportComments = -Val(lblOpeningCr.Tag)
        'ElseIf Val(lblopeningDr.Text) > 0 Then
        '    CrystalReportDocument.SummaryInfo.ReportComments = Val(lblopeningDr.Tag)
        'End If
        objfrmreport.Show()
    End Sub

    Private Sub btnCloseDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseDisplay.Click
        PanelDisplay.Visible = False
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'CrystalReportViewer2.PrintReport()
    End Sub

    Private Sub chbDateFrom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDateFrom.CheckedChanged
        If chbDateFrom.Checked = True Then
            dtpDateFrom.Value = MemberAccountOpening.ToString(DateFormat)
        End If
    End Sub

    'Public Sub PrintWindowsPOSBillThermal(ByVal _BillNo As Integer, ByVal _YearCode As Integer, ByVal _LocationCode As Integer, ByVal PrintFlag As String)
    '    Dim KOTStr As String = ""
    '    ObjDatabase.ConnectDatabse()
    '    BindTempTablesForPOSBillPrint(_BillNo, _LocationCode, _YearCode)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptFNBBill.rpt")
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.RecordSelectionFormula = "{TI_BillHead.BillNo}=" & _BillNo & " AND {TI_BillHead.YearCode}=" & _YearCode & " and {TI_BillHead.LocationCode}=" & _LocationCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE BILL"
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    'Private Sub PrintCrystalMiscellaeneousBill(ByVal VchNo As Integer, ByVal YearCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptMiscellaneousBillPOS.rpt")
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
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

    'Private Sub PrintCrystalCaddieBill(ByVal VchNo As Integer, ByVal YearCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptCaddieBillPOS.rpt")
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.RecordSelectionFormula = "{CM_MiscBillHead.VchNo}=" & Val(VchNo) & " AND {CM_MiscBillHead.YearCode}=" & YearCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE CADDIE BILL"
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    'Private Sub PrintCrystalReceiptVoucher(ByVal _RCVNO As Integer, ByVal _YEARCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptReceiptVoucherPOS.rpt")
    '    CrystalReportDocument.RecordSelectionFormula = "{CM_RVHead.RCVNo}=" & Val(_RCVNO) & " AND {CM_RVHead.YearCode}=" & _YEARCode & " AND {CM_RVHead.LocationCode}=" & 1
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "DUPLICATE RECEIPT VOUCHER"
    '    CrystalReportDocument.SetParameterValue("PAH", PAH)
    '    CrystalReportDocument.SetParameterValue("PBH", PBH)
    '    CrystalReportDocument.SetParameterValue("RAH", RAH)
    '    CrystalReportDocument.SetParameterValue("RBH", RBH)
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    'Private Sub PrintMonthlyAdjustment(ByVal BillNo As Integer, ByVal YearCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptMonthlyAdjustment.rpt")
    '    CrystalReportDocument.RecordSelectionFormula = "{MM_MonthlyAdjustment.VchNo}=" & BillNo & " AND {MM_MonthlyAdjustment.YearCode}=" & YearCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    'Private Sub PrintDirectCharge(ByVal BillNo As Integer, ByVal YearCode As Integer, ByVal PrintFlag As Integer)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptDirectCharges.rpt")
    '    CrystalReportDocument.RecordSelectionFormula = "{MM_DirectCharges.VchNo}=" & BillNo & " AND {MM_DirectCharges.YearCode}=" & YearCode
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    If PrintFlag = 1 Then
    '        CrystalReportDocument.PrintToPrinter(1, False, 1, 1)
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

    Private Sub PopulateMemberTransactions()
        Try
            Dim cmd As New SqlCommand
            Dim adp As New SqlDataAdapter
            Dim con As New SqlConnection
            con.ConnectionString = "data source=" & SQLServerName & "; initial catalog=" & SQLServerDatabase & "; user id=" & SQLServerUserName & "; password=" & SQLServerPassword
            cmd.Connection = con
            cmd.CommandTimeout = 5000
            cmd.Connection.Open()
            cmd.CommandText = "Proc_MemberCreditEnquiry"
            cmd.Parameters.AddWithValue("@MemberID", txtC_ID.Text)
            cmd.Parameters.AddWithValue("@DateFrom", Format(dtpDateFrom.Value, DateFormat))
            cmd.Parameters.AddWithValue("@Dateto", Format(dtpDateTo.Value, DateFormat))
            cmd.CommandType = CommandType.StoredProcedure
            adp.SelectCommand = cmd
            adp.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class