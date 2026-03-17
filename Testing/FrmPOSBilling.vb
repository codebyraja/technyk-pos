Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Public Class FrmPOSBilling1N
    Dim NewKOTNo As Integer
    Dim ItemCountDestinationTable As Integer
    Dim VendorCodes As String = ""
    Dim RFIDMemberID As String = "ID-0510"
    Dim LOCATION_TYPE11 As String = "'POS BAR','POS REST'"
    Dim dtSourceTable, dtDestinationTable As New DataTable
    Dim dsReq As New DataSet
    Dim OpenBillAmount As Double
    Dim OpenItemName As String = ""
    Dim retValue As Integer = 0
    Const BillType As Integer = 6
    Dim CardValidity As Date = Now
    Dim BillingMode As String = ""
    Dim Temp_BillingMode As String = ""
    Dim Temp_TableCode As String = ""
    Dim Temp_WaiterCode As String = ""
    Dim Temp_MemberID, Temp_MemberName, Temp_BillNo, Temp_KOTNo As String
    Dim SelectedButton As New Button
    Dim BilledItemPosition As Integer
    Dim ExistingItem As Boolean
    Dim Memtype As String = ""
    Dim TypeOfMember As String = ""
    Dim ItemTextFont As New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Dim GroupTextFont As New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Dim SubGroupTextFont As New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Dim TableTextFont As New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Dim ModeOfPayment As String = ""
    Dim KOTStr As String = ""
    Dim AmtBeforeRoundOff As Double = 0
    Dim AmtAfterRoundOff As Double = 0
    Dim RoundOff As Double = 0
    Dim CardSerialNo As String = ""
    Dim ReturnValue As Integer = 0
    Dim myTrans As SqlTransaction
    Dim myCommand As SqlCommand
    Dim ItemCode As Integer = 0
    Dim TableCode As Integer = 0
    Dim BasicAmount As Double = 0
    Dim AmountAfterDiscount As Double = 0
    Dim DiscountedAmount As Double
    Dim TaxableAmount As Double = 0
    Dim TaxAmount As Double = 0
    Dim SCAmount As Double = 0
    Dim SCPer As Double = 0
    Dim BalanceToBeDeductedFromCard As Double = 0
    Dim ds As New DataSet
    Dim UnitCode As Integer, UnitName, ItemName, Aliasname As String
    Dim TaxPer As String = "0"
    Dim ItemRate As String = "0"
    Dim OpenItem As Integer
    Dim _BillNo As Integer = 0
    Dim _LocationCode As Integer = 0
    Dim _YearCode As Integer = 0
    Dim _TableNo As String = ""
    Dim _MemID As String = ""
    Dim _ValidationMode As String = ""
    Dim SCOnItem As String
    Dim ctr As Integer = 0
    Dim RDiscountPer As Double = 0
    Dim RQty, RAmount, RGSTAmt, RDiscountAmt, RSTAmt, RSCAmt, RTotalAmt, RAmtAfterDiscount, AmtAfterDiscount As Double
    Dim Qty, Amount, VATAmt, RVATAmt, DiscountAmt, GSTAmt, TotalAmt, SCAmt As Double
    Dim Rate As Double = 0
    Dim liNewQty As Decimal = 0
    Dim TotalAmount As Double = 0
    Dim DiscountPer As Double = 0
    Dim KOTNo As Integer = 0
    Dim BillNo As Integer = 0
    Dim CheckCardBalance As Boolean = True
    Dim ItemGroup As Integer = 0
    Dim FlagServiceCharge As Integer = 0
    Dim KOTType As String = ""
    Dim RightPanelLocation As Point = New Point(320, 3)
    Dim LeftPanelLocation As Point = New Point(1, 3)
    Dim dsItemMaster As New DataSet
    Dim dsTable As New DataSet
    Dim dsTableLocation As New DataSet
    Dim dsTableMaster As New DataSet
    Dim LocationTableCounter As Integer = 0
    Dim GroupCounter As Integer = 0
    Dim TableCounter As Integer = 0
    Dim SelectedGroupCode As Integer = 0
    Dim SelectedSubGroupCode As Integer = 0
    Dim SelectedItemCode As Integer = 0
    Dim NoOfCopies As Integer = 1
    Dim CloseBill As Integer = 0
    Dim OpenBill As Integer = 0
    Dim BillStatus As Integer
    Dim dtKOTItems As DataTable
    Dim drKOTItems As DataRow
    Dim FocussedControl As New Object
    Dim OpenBillPanelLocation As Point = New Point(7, 35)
    Dim CheckStock As String
    Dim QtyCanBeSold As New ArrayList
    Dim LastBill As Boolean = False
    Dim ActionType As String = ""
    Dim LastBillNo As Integer
    Dim LastKOTNo As Integer

    Dim AvailableTableBackColor As Color = New System.Drawing.Color
    Dim BusyTableBackColor As Color = New System.Drawing.Color
    Dim AvailableTableForeColor As Color = New System.Drawing.Color
    Dim BusyTableForeColor As Color = New System.Drawing.Color
    Dim BillAmount As Double
    Dim BillGSTAmt As Double
    Dim BillSTAmount As Double
    Dim BillSCTAmount As Double
    Dim BillQty As Double
    Dim VoidRemarks As String = ""
    Dim dtCurrentKOT As New DataTable
    Dim ITEM_SNO As Double = 0
    Dim FlagGridFormatting As Boolean
    Dim OccupiedTableBackColor As Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(80, Byte), Integer))
    Dim VacantTableBackColor As Color = System.Drawing.Color.FromArgb(CType(CType(144, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(144, Byte), Integer))
    Dim NormalBackColor As Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Dim MainID, MemberID, MemberName, IssueID, IssueNo, ClosingBalance As String
    Dim BILL_TYPE As String = ""
    Dim ModeOpeningBalance As Double = 0
    Dim Temp_ModeOpeningBalance As Double = 0
    Dim ModeClosingBalance As Double = 0
    Dim SelectedTableName As String = ""
    Dim BtnLocationCode As Integer = 0
    Dim BillEstimate As Integer = 0
    Dim TopKOTNo As Integer = 0
    Dim ModifierItemCode, ModifierRemarks, ModifierItemName As String
    Dim FlagCheckBusinessDate As Boolean = False

    Private Sub FrmPOSKeyBoardBilling_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If txtQty.Focused Then
                Dim lsTemp As String
                lsTemp = ""
            End If
        ElseIf (e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.F12) And dgItemGrid.RowCount > 0 And btnShowTables.Enabled = True Then
            If btnShowTables.Enabled = True Then
                btnShowTables_Click(sender, e)
            End If
        ElseIf (e.KeyCode = Keys.F5) And btnShowTables.Text = "NEW BILL" Then
            btnTable_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F2) And btnShowTables.Text = "SAVE" Then
            txtSearchItemCode.Text = ""
            txtSearchItemName.Text = ""
            BindSearchGridForItem()
            txtSearchItemCode.Focus()
        End If
    End Sub

    Private Sub FrmPOSKeyBoardBilling_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ObjDatabase.ConnectDatabse()
        ClearText(Me)
        BindItemGrid()
        ObjDatabase.CloseDatabaseConnection()
        BindComboboxWithSelectOneNumeric("Select Code,LocationName From IM_LocationMaster where Type in(" & LOCATION_TYPE & ") and VendorID IN(" & VENDOR_ID & ")", "Code", "LocationName", cmbLocation)
        BindComboboxWithSelectOneNumeric("Select 0 Code,'[Select One]' as TableName ", "Code", "TableName", cmbTable)
        cmbTable.SelectedValue = 0
        BindComboboxWithSelectOneNumeric("Select 0 Code,'[Select One]' as ItemName ", "Code", "ItemName", cmbItemName)
        cmbItemName.SelectedValue = 0
        cmbLocation.SelectedValue = LOCATION_Code
        LoadDefaultSettings(LOCATION_Code)
        BindOpenBills()
        BindComboboxWithSelectOneNumeric("Select Code,WaiterName From FB_WaiterMaster Where Status='Active' and Code in(select WaiterCode from FB_LocationWaiterLink where LocationCode=" & LOCATION_Code & ")", "Code", "WaiterName", cmbWaiter)
        cmbWaiter.SelectedValue = 0
        Message = "Click <New Check> to create a new bill"
        dgItemGrid.Cursor = Cursors.Hand

        CurrentBusinessDate = GetCurrentBusinessDate()
        lblBillDate.Text = CurrentBusinessDate.ToString("dd/MMM/yyyy")
        ClearControls()
        EnableItemPanel()
        BillStatus = 1
        txtItemCode.Focus()
        PanelDisplayArea.Enabled = True
        DisableControl(PanelItem)
        DisableControl(PanelDisplayArea)
        PanelClosedBills.Location = LeftPanelLocation
        DisplayMemberPics("")
        BindComboboxWithSelectOneNumeric("Select UserCode,UserName From AC_UserMaster", "UserCode", "UserName", cmbCashier)
        cmbCashier.SelectedValue = UserCode
        cmbCashier.Enabled = False
        lblBillNo.Enabled = False
        btnShowTables.Enabled = True
        btnShowTables.Focus()
        If FinancialYearCheck(CurrentBusinessDate) = False Then
            Me.Enabled = False
        End If
        If ValidateClientServerDate() = False Then
            Me.Enabled = False
        End If
        PanelModifiers.Visible = False
        PanelSearchItem.Visible = False
        StrSql = "SELECT Code, Remarks FROM FB_KOTRemarks where Status='Active'"
        BindComboboxWithSelectOneNumeric(StrSql, "Code", "Remarks", cmbKOTRemarks)

        Dim ServerDate, BusinessDate As Date
        ServerDate = GetBusinessDate()
        BusinessDate = GetCurrentBusinessDate()
        FlagCheckBusinessDate = True
        If ServerDate.ToString(DateFormat) <> BusinessDate.ToString(DateFormat) Then
            If MsgBox("Server Date and Business Date don't match. Do you still wish to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Me.Enabled = False
            End If
            FlagCheckBusinessDate = False
        End If
    End Sub

    Protected Overloads Overrides Function _
    ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If TypeOf ActiveControl Is Button = False Then
            Select Case keyData
                Case Keys.Enter
                    Return MyBase.ProcessDialogKey(Keys.Tab)
                Case Keys.Escape
                    Return MyBase.ProcessDialogKey(Keys.Shift Or _
                    Keys.Tab)
            End Select
        Else
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Private Sub ClearControls()
        If FlagOTPValidation.ToUpper() = "YES" Then btnSendOTP.Visible = True Else btnSendOTP.Visible = False
        ClearText(Me)
        DisableControl(Me)
        lblBillNo.Text = 0
        CloseBill = 0
        BillEstimate = 0
        BindItemGrid()
        Me.ErrorProvider1.Dispose()
        LastBill = False
        lblROff.Text = ""
        lblSubTotal.Text = ""
        lblDiscountAmt.Text = ""
        lblSCAmt.Text = ""
        lblGSTAmt.Text = ""
        lblROff.Text = ""
        lblRoundOff.Text = ""
        btnSendOTP.Enabled = False
        btnSendOTP.Text = "Send OTP"
        BindComboboxWithSelectOneNumeric("Select 0 Code,'[Select One]' as TableName ", "Code", "TableName", cmbTable)
        cmbTable.SelectedValue = 0
        PanelRight.Visible = True
        PanelRight.BringToFront()
        PanelLocationAndTables.Visible = False
        lblBillingSmartCardOpeningStr.Text = "Card Opening"
        lblBillingSmartCardClosingStr.Text = "Card Closing"
        lblOpeningCreditLimitstr.Text = "Credit Limit"
        lblMemberAcClosingStr.Text = "Mem A/c Closing"
        PanelRight.Location = RightPanelLocation
        PanelClosedBills.Visible = True
        PanelSettleBill.Visible = False
        PanelSettleBill.Location = LeftPanelLocation
        btnShowTables.Enabled = True
        lblBillNo.Text = ""
        lblKOTNo.Text = ""
        DisableControl(Me)
        BindItemGrid()
        Me.ErrorProvider1.Dispose()
        ClearText(Me)
        LastBill = False
        ITEM_SNO = 0
        PanelClosedBills.Visible = True
        PanelItem.Visible = True
        lblBillNo.Text = ""
        ActionType = ""
        EnableControl(PanelClosedBills)
        btnShowTables.Tag = "0"

        lblTotalQty.Text = "0.00"
        lblSubTotal.Text = "0.00"
        lblDiscountAmt.Text = "0.00"
        lblSCAmt.Text = "0.00"
        lblGSTAmt.Text = "0.00"
        lblVATAmt.Text = "0.00"
        lblROff.Text = "0.00"
        lblGrossAmt.Text = "0.00"
        lblSmartCardOpeningBalance.Text = "0.00"
        lblSmartCardClosingBalance.Text = "0.00"


        lblTotalQty.TextAlign = ContentAlignment.MiddleRight
        lblSubTotal.TextAlign = ContentAlignment.MiddleRight
        lblDiscountAmt.TextAlign = ContentAlignment.MiddleRight
        lblSCAmt.TextAlign = ContentAlignment.MiddleRight
        lblGSTAmt.TextAlign = ContentAlignment.MiddleRight
        lblVATAmt.TextAlign = ContentAlignment.MiddleRight
        lblROff.TextAlign = ContentAlignment.MiddleRight
        lblGrossAmt.TextAlign = ContentAlignment.MiddleRight


        btnShowTables.Text = "NEW BILL"
        DisableControl(PanelItem)
        DisableControl(PanelDisplayArea)
        ClearCardDetails()
        PanelClosedBills.Visible = True
        PanelRight.Visible = True
        PanelLocationAndTables.Visible = False
        BindOpenBills()
        If LOCATION_Code > 0 Then
            cmbLocation.SelectedValue = LOCATION_Code
        Else
            cmbLocation.SelectedValue = 0
        End If
        cmbCashier.SelectedValue = UserCode
        cmbCashier.Enabled = False
        lblMemberName.Text = ""
        PanelDisplayBill.Visible = False
        PanelLocationAndTables.Visible = False
        DisplayMemberPics("")

        lblBillDate.Text = CurrentBusinessDate.ToString(DateFormat)
        PanelModifyKOT.Visible = False

        btnSaveNSettle.Enabled = False
        btnSettleBillHomePage.Enabled = False
        btnEstimate.Enabled = False
        btnModifyKOT.Enabled = False
        btnShiftTable.Enabled = False
        btnSaveNSettle.Enabled = False
        btnShowTables.Enabled = True
        btnEstimate.Enabled = True
        btnClose.Enabled = True
        btnHistory.Enabled = True

        btnSaveNSettle.Text = "SAVE && SETTLE"
        btnModifyKOT.Text = "MODIFY KOT"
        btnShiftTable.Text = "SHIFT TABLE"
        btnSettleBillHomePage.Text = "SETTLE BILL"
        btnShowTables.Text = "NEW BILL"
        btnShiftKOT.Text = "SHIFT KOT"

        btnShowTables.FlatStyle = FlatStyle.Popup
        btnHistory.FlatStyle = FlatStyle.Popup
        btnEstimate.FlatStyle = FlatStyle.Popup
        btnSaveNSettle.FlatStyle = FlatStyle.Popup
        btnModifyKOT.FlatStyle = FlatStyle.Popup
        btnShiftKOT.FlatStyle = FlatStyle.Popup
        btnRefresh.FlatStyle = FlatStyle.Popup
        btnModifiers.FlatStyle = FlatStyle.Popup
        btnShiftTable.FlatStyle = FlatStyle.Popup
        btnSettleBillHomePage.FlatStyle = FlatStyle.Popup
        btnClose.FlatStyle = FlatStyle.Popup
        btnModifyKOT.FlatStyle = FlatStyle.Popup
        btnSettleBill.FlatStyle = FlatStyle.Popup
        btnCancelBill.FlatStyle = FlatStyle.Popup

        btnClear.FlatStyle = FlatStyle.Popup
        btnDismiss.FlatStyle = FlatStyle.Popup
        btnItemModifierOK.FlatStyle = FlatStyle.Popup

        btnHistory.BackColor = Color.DarkTurquoise
        btnEstimate.BackColor = Color.DarkTurquoise
        btnSaveNSettle.BackColor = Color.DarkTurquoise
        btnModifyKOT.BackColor = Color.Tomato
        btnRefresh.BackColor = Color.Tomato
        btnClose.BackColor = Color.Tomato
        btnSendOTP.FlatStyle = FlatStyle.Popup

        btnModifiers.BackColor = Color.DarkTurquoise
        btnSendOTP.BackColor = System.Drawing.Color.FromArgb(255, 255, 128, 128)
        btnShiftTable.BackColor = Color.DarkTurquoise
        btnSettleBillHomePage.BackColor = Color.DarkTurquoise
        btnShowTables.BackColor = Color.Blue
        btnShowTables.ForeColor = Color.White
        btnShiftKOT.BackColor = Color.Tomato
        btnShiftKOT.ForeColor = Color.Black
        btnVoidKOT.BackColor = Color.Tomato
        btnVoidKOT.ForeColor = Color.White
        btnVoidKOT.FlatStyle = FlatStyle.Popup
        btnCancelBill.BackColor = Color.Tomato
        btnModifyKOT.BackColor = Color.Tomato
        btnClear.BackColor = Color.Yellow
        btnDismiss.BackColor = Color.Yellow
        btnItemModifierOK.BackColor = Color.Yellow
        btnRefresh.BackColor = Color.Yellow
        btnRefresh.ForeColor = Color.Black
        btnSettleBill.BackColor = Color.DarkTurquoise
        btnCancelBill.BackColor = Color.DarkTurquoise

        btnClose.BackColor = Color.Tomato
        btnMinus0.BackColor = Color.Tomato
        btnMinus0.ForeColor = Color.White
        btnMinus0.FlatStyle = FlatStyle.Popup

        btnMinus1.BackColor = Color.Tomato
        btnMinus1.ForeColor = Color.White
        btnMinus1.FlatStyle = FlatStyle.Popup

        btnMinus2.BackColor = Color.Tomato
        btnMinus2.ForeColor = Color.White
        btnMinus2.FlatStyle = FlatStyle.Popup

        btnMinus3.BackColor = Color.Tomato
        btnMinus3.ForeColor = Color.White
        btnMinus3.FlatStyle = FlatStyle.Popup

        btnMinus4.BackColor = Color.Tomato
        btnMinus4.ForeColor = Color.White
        btnMinus4.FlatStyle = FlatStyle.Popup

        btnMinus5.BackColor = Color.Tomato
        btnMinus5.ForeColor = Color.White
        btnMinus5.FlatStyle = FlatStyle.Popup

        btnMinus6.BackColor = Color.Tomato
        btnMinus6.ForeColor = Color.White
        btnMinus6.FlatStyle = FlatStyle.Popup

        btnMinus7.BackColor = Color.Tomato
        btnMinus7.ForeColor = Color.White
        btnMinus7.FlatStyle = FlatStyle.Popup

        btnMinus8.BackColor = Color.Tomato
        btnMinus8.ForeColor = Color.White
        btnMinus8.FlatStyle = FlatStyle.Popup

        btnMinus9.BackColor = Color.Tomato
        btnMinus9.ForeColor = Color.White
        btnMinus9.FlatStyle = FlatStyle.Popup
        PanelTables.Tag = ""
        PopulateTablesSC(cmbLocation.SelectedValue, cmbLocation.SelectedValue, 0)
        PanelModifiers.Visible = False
        btnHistory.Visible = True
        btnShiftKOT.Visible = True
        PanelMergeTables.Visible = False
        PanelSearchItem.Visible = False
        PanelClosedBills.Visible = True
        ControlAccess()
    End Sub

    Private Sub BindItemGrid()
        dgItemGrid.Refresh()
        dgItemGrid.Visible = True
        ds = New DataSet
        dtKOTItems = New DataTable
        StrSql = "select 0 as SNo,KB.KOTNo,KB.ItemCode, IM.Aliasname" & _
        " ,IM.ItemName, KB.UnitCode, UM.UnitName, KB.Qty, KB.Rate ,(KB.Qty*KB.Rate) as [Amount]" & _
        " ,KB.TaxPer, (KB.Amount-KB.Amount*DiscountPer*0.01)*KB.TaxPer*0.01 as [TaxAmount]" & _
        " ,KB.SCPer, (KB.Amount-KB.Amount*DiscountPer*0.01)*KB.SCPer*0.01 as [SCAmount]" & _
        ",(((KB.Qty*KB.Rate)-(KB.Qty*KB.Rate)*DiscountPer*0.01)+(((KB.Qty*KB.Rate)-(KB.Qty*KB.Rate)*DiscountPer*0.01)*KB.TaxPer*0.01)+((KB.Qty*KB.Rate)-(KB.Qty*KB.Rate)*DiscountPer*0.01)*KB.SCPer*0.01) as [GrossAmt]" & _
        ",getdate() as DisplayOrder,0 as OpenItem,KB.DiscountPer,KB.TaxType,KB.Remarks " & _
        " from FB_KOTBody KB ,IM_ItemMaster IM ,IM_UnitMaster UM" & _
        " where KB.ItemCode=IM.ItemCode AND KB.UnitCode=UM.Code" & _
        " and KB.KOTNo =" & Val(lblKOTNo.Text) & " and KB.YearCode=" & YearCode & " and KB.LocationCode=" & LOCATION_Code & " order by KB.KOTNo,IM.ItemName"
        ds = ObjDatabase.BindDataSet(StrSql, "Item")
        dtKOTItems = ds.Tables("Item")
        dgItemGrid.DataSource = dtKOTItems
        FormatDataGridView(dgItemGrid)

        dgItemGrid.Columns("TaxType").Visible = False
        dgItemGrid.Columns("OpenItem").Visible = False
        dgItemGrid.Columns("DisplayOrder").Visible = False
        dgItemGrid.Columns("UnitCode").Visible = False
        dgItemGrid.Columns("UnitName").Visible = True
        dgItemGrid.Columns("TaxPer").Visible = True
        dgItemGrid.Columns("SCPer").Visible = True
        dgItemGrid.Columns("SNo").Visible = False
        dgItemGrid.Columns("TaxPer").Visible = False
        dgItemGrid.Columns("TaxAmount").Visible = False
        dgItemGrid.Columns("SCPer").Visible = False
        dgItemGrid.Columns("SCAmount").Visible = False
        dgItemGrid.Columns("Amount").Visible = False
        dgItemGrid.Columns("GrossAmt").Visible = True
        dgItemGrid.Columns("KOTNo").Visible = False
        dgItemGrid.Columns("DiscountPer").Visible = False
        dgItemGrid.Columns("Remarks").Visible = False

        dgItemGrid.Columns("SNo").Width = 30
        dgItemGrid.Columns("SNo").HeaderText = "#"
        dgItemGrid.Columns("ItemCode").Visible = False
        dgItemGrid.Columns("ItemCode").HeaderText = "ICode"
        dgItemGrid.Columns("ItemCode").Width = 60
        dgItemGrid.Columns("Aliasname").HeaderText = "ItemCode"
        dgItemGrid.Columns("Aliasname").Visible = True
        dgItemGrid.Columns("ItemName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgItemGrid.Columns("UnitName").Width = 80
        dgItemGrid.Columns("Qty").Width = 45
        dgItemGrid.Columns("Rate").Width = 58
        dgItemGrid.Columns("Rate").Visible = True
        dgItemGrid.Columns("GrossAmt").Width = 60
        dgItemGrid.Columns("GrossAmt").Width = 75
        dgItemGrid.Columns("GrossAmt").HeaderText = "GrossAmt"


        dgItemGrid.Columns("ItemCode").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("ItemCode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgItemGrid.Columns("UnitName").HeaderText = "Unit"
        dgItemGrid.Columns("UnitName").Width = 80
        dgItemGrid.Columns("UnitName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgItemGrid.Columns("Qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Qty").DefaultCellStyle.Format = NumFormat

        dgItemGrid.Columns("Rate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Rate").DefaultCellStyle.Format = NumFormat

        dgItemGrid.Columns("Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Amount").DefaultCellStyle.Format = NumFormat

        dgItemGrid.Columns("TaxPer").DefaultCellStyle.Format = NumFormat
        dgItemGrid.Columns("TaxPer").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgItemGrid.Columns("TaxAmount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("TaxAmount").DefaultCellStyle.Format = NumFormat

        dgItemGrid.Columns("SCPer").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgItemGrid.Columns("SCPer").DefaultCellStyle.Format = NumFormat

        dgItemGrid.Columns("SCAmount").DefaultCellStyle.Format = NumFormat
        dgItemGrid.Columns("SCAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgItemGrid.Columns("GrossAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("GrossAmt").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("GrossAmt").DefaultCellStyle.Format = NumFormat

        dgItemGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgItemGrid.Tag = "Items"
        dgItemGrid.ClearSelection()
        dgItemGrid.RowTemplate.Height = 25
        dgItemGrid.Columns(0).Width = 25
        dgItemGrid.Columns(1).Width = 25
        dgItemGrid.Columns(2).Width = 25
        dgItemGrid.RowHeadersVisible = True
        dgItemGrid.RowHeadersWidth = 20
    End Sub

    Public Sub AddItemToGrid(ByVal PassedItemCode As Integer, ByVal PassedQty As Decimal, ByVal PItemRate As Double)

        Try
            If FlagCheckBusinessDate = False And Val(lblBillNo.Text) = 0 Then
                btnShowTables.Text = "NOT ALLOWED"
            End If
            StrSql = "Select IM.ItemCode,IM.ItemName,UM.Code SaleUnit,UM.UnitName,IM.SP,TM.ValuePercentage TaxPer,IM.OpenItem,IM.ServiceCharge, TM.TaxType,IM.Aliasname" & _
            " From IM_ItemMaster IM,AC_TaxMaster TM,IM_UnitMaster UM" & _
            " Where IM.ItemCode='" & Val(PassedItemCode) & "'" & _
            " AND IM.SaleTaxCode=TM.Code" & _
            " and IM.SaleUnit=UM.Code" & _
            " Order by IM.ItemName"
            ds = New DataSet
            ds = ObjDatabase.BindDataSet(StrSql, "Item")
            If ds.Tables(0).Rows.Count > 0 Then
                ItemName = ds.Tables(0).Rows(0).Item("ItemName")
                UnitCode = Val(ds.Tables(0).Rows(0).Item("SaleUnit"))
                UnitName = ds.Tables(0).Rows(0).Item("UnitName")
                ItemRate = Val(ds.Tables(0).Rows(0).Item("SP"))
                TaxPer = Val(ds.Tables(0).Rows(0).Item("TaxPer"))
                OpenItem = Val(ds.Tables(0).Rows(0).Item("OpenItem"))
                TaxType = ds.Tables(0).Rows(0).Item("TaxType")
                Aliasname = ds.Tables(0).Rows(0).Item("Aliasname")
            End If
            ObjDatabase.CloseDatabaseConnection()
        Catch ex As Exception
        End Try
        If OpenItem = 1 Then
            ItemName = lblOpenItemName.Text.Trim
            ItemRate = Val(txtRate.Text)
        End If
        If chbComplementory.Checked = True Then
            '30% ON 06-12-2023
            ItemRate = 0
            PItemRate = 0
            TaxPer = 0
        End If
        If PItemRate > 0 And ItemRate = 0 Then
            ItemRate = PItemRate
        End If
        Try
            ExistingItem = False
            For Me.ctr = 0 To dgItemGrid.Rows.Count - 1
                If (dgItemGrid.Item("ItemCode", ctr).Value) = Val(PassedItemCode) And IsDBNull((dgItemGrid.Item("KOTNo", ctr).Value)) = True Then
                    If MsgBox("Item Already exists. Do you wish to add the item again?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ExistingItem = True
                        BilledItemPosition = ctr
                    Else
                        Exit Sub
                    End If
                End If
            Next
            CheckStock = ObjDatabase.ExecuteScalarN("Select isnull(CheckStock,0) from IM_ItemMaster where ItemCode=" & Val(cmbItemName.SelectedValue))
            If CheckStock = 1 Then
                Dim DS1, DS_ItemName As DataSet
                Dim BilledQty As Double = 0
                Dim liQuantity As Integer = 0

                For Ctr As Int16 = 0 To dgItemGrid.RowCount - 1
                    If dgItemGrid.Item("ItemCode", Ctr).Value = Val(cmbItemName.SelectedValue) Then
                        BilledQty = BilledQty + dgItemGrid.Item("Qty", Ctr).Value
                    End If
                Next
                QtyCanBeSold = New ArrayList
                ds = ObjDatabase.BindDataSet("Select MainItemCode,BOMItemQty from IM_ItemBOMMaster where BOMItemCode=" & Val(cmbItemName.SelectedValue) & "", "BOM")
                If ds.Tables("BOM").Rows.Count > 0 Then
                    For ctr = 0 To ds.Tables("BOM").Rows.Count - 1
                        StrSql = "Proc_SubStoreStockItem " & Val(ds.Tables("BOM").Rows(ctr)("MainItemCode")) & "," & Val(SUBSTORE_Code) & ""
                        ObjDatabase.BindDataSet(StrSql, "Data")

                        ObjDatabase.ConnectDatabse()
                        ObjDatabase.OpenDatabaseConnection()
                        StrSql = "select S.[ClosingStock], I.ItemName from IM_SubStoreStockItem S, IM_ItemMaster I where S.itemCode=" & Val(ds.Tables("BOM").Rows(ctr)(0)) & " and S.ItemCode=I.ItemCode"
                        DS1 = ObjDatabase.BindDataSet(StrSql, "CheckQty")
                        If DS1.Tables("checkqty").Rows.Count > 0 Then
                            LabelClosingStock.Text = Val(DS1.Tables("CheckQty").Rows(0)("ClosingStock"))
                            LabelClosingStock.Text = Math.Round(Val(LabelClosingStock.Text), 2)
                            If Val(DS1.Tables("checkqty").Rows(0)(0)) < (Val(ds.Tables("BOM").Rows(ctr)("bomitemqty")) * Val(txtQty.Text) + BilledQty) Then
                                DS_ItemName = ObjDatabase.BindDataSet("Select ItemName from IM_ItemMaster where itemCode = " & Val(ds.Tables("BOM").Rows(ctr)("mainitemCode")) & "", "ItemName")
                                If DS_ItemName.Tables("ItemName").Rows.Count > 0 Then
                                    MsgBox("Stock not available for: " & vbCrLf & DS_ItemName.Tables("ItemName").Rows(0)("ItemName"), MsgBoxStyle.Information, "INFORMATION")
                                    txtQty.Text = ""
                                    txtItemCode.Text = ""
                                    txtItemCode.Focus()
                                End If
                                Exit Sub
                            End If
                            QtyCanBeSold.Add(Val(DS1.Tables("checkqty").Rows(0)("ClosingStock")) / (Val(ds.Tables("BOM").Rows(ctr)("bomitemqty"))))
                        End If
                    Next
                Else
                    MsgBox("Recipe not defined for the selected item", MsgBoxStyle.Information, "INFORMATION")
                    txtItemCode.Focus()
                    Exit Sub
                End If
                LabelClosingStock.Visible = True
                If QtyCanBeSold.Count > 0 Then
                    LabelClosingStock.Text = QtyCanBeSold(0)
                    LabelClosingStock.Text = Val(LabelClosingStock.Text) - Val(txtQty.Text)
                    LabelClosingStock.Visible = True
                    LabelClosingStock.Text = LabelClosingStock.Text & " " & lblUnit.Text.Trim
                End If
                QtyCanBeSold.Sort()
            End If

            BasicAmount = Val((ItemRate) * Val(PassedQty))
            AmountAfterDiscount = BasicAmount * (100 - Val(txtDiscountPer.Text)) * 0.01
            TaxableAmount = AmountAfterDiscount
            TaxAmount = TaxableAmount * (TaxPer * 0.01)

            If FlagServiceCharge = 1 Then
                SCAmount = TaxableAmount * (GlobalServiceChargePer * 0.01)
                TaxAmount += SCAmount * Val(GSTPerOnServiceCharge) * 0.01
            Else
                SCAmount = 0
            End If
            DiscountedAmount = 0

            BalanceToBeDeductedFromCard = AmountAfterDiscount + TaxAmount + SCAmount
            Dim BillingMode As String = GetBillingMode(txtMemID.Text)

            If BillEstimate = 0 Then
                If BalanceToBeDeductedFromCard > Val(lblSmartCardClosingBalance.Text) And BillingMode = "Single" Then
                    MsgBox("Insufficient Balance", MsgBoxStyle.Critical)
                    Exit Sub
                ElseIf (BalanceToBeDeductedFromCard + Val(lblGrossAmt.Text) + Val(lblBillAmtPerviousKOT.Text)) > Val(Val(lblSmartCardClosingBalance.Text) + Val(lblMemberAcClosingBalance.Text)) And BillingMode = "Dual" Then 'Raj
                    MsgBox("Insufficient Card+Credit Balance", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            If ExistingItem Then
                drKOTItems = dtKOTItems.Rows(BilledItemPosition)
                PassedQty = Val(drKOTItems.Item("Qty")) + Val(PassedQty)
                BasicAmount = Val((ItemRate) * Val(PassedQty))
            Else
                drKOTItems = dtKOTItems.NewRow
            End If
            drKOTItems.Item("ItemCode") = Val(PassedItemCode)
            drKOTItems.Item("ItemName") = Trim(ItemName)
            drKOTItems.Item("Qty") = Val(PassedQty)
            drKOTItems.Item("UnitCode") = Val(UnitCode)
            drKOTItems.Item("UnitName") = Trim(UnitName)
            drKOTItems.Item("Rate") = Val(ItemRate)
            drKOTItems.Item("Amount") = BasicAmount
            drKOTItems.Item("TaxType") = TaxType
            drKOTItems.Item("Aliasname") = Aliasname
            '
            drKOTItems.Item("Remarks") = ""

            If Val(FlagServiceCharge) > 0 Then
                drKOTItems.Item("SCPer") = Val(GlobalServiceChargePer)
                SCAmount = Math.Round(BasicAmount * Val(GlobalServiceChargePer) * 0.01, 2)
                drKOTItems.Item("SCAmount") = SCAmount
            Else
                TaxAmount = 0
                drKOTItems.Item("SCPer") = 0
                drKOTItems.Item("SCAmount") = 0
            End If

            If Val(TaxPer) > 0 Then
                drKOTItems.Item("TaxPer") = Val(TaxPer)
                TaxAmount = Math.Round(BasicAmount * Val(TaxPer) * 0.01, 2)
            Else
                TaxAmount = 0
                drKOTItems.Item("TaxPer") = 0
                drKOTItems.Item("TaxAmount") = 0
            End If

            If GSTPerOnServiceCharge > 0 Then
                TaxAmount += SCAmount * Val(GSTPerOnServiceCharge) * 0.01
            End If

            drKOTItems.Item("TaxAmount") = TaxAmount
            drKOTItems.Item("GrossAmt") = BasicAmount + TaxAmount + SCAmount
            drKOTItems.Item("DisplayOrder") = Now
            drKOTItems.Item("OpenItem") = OpenItem
            drKOTItems.Item("DiscountPer") = Val(txtDiscountPer.Text)
            If ExistingItem = False Then
                dtKOTItems.Rows.InsertAt(drKOTItems, 0)
            End If
            ITEM_SNO = ITEM_SNO + 100
            drKOTItems.Item("SNo") = ITEM_SNO
            dtKOTItems.AcceptChanges()

            dtKOTItems.DefaultView.Sort = "DisplayOrder DESC"
            dtKOTItems = dtKOTItems.DefaultView.ToTable()
            dgItemGrid.DataSource = dtKOTItems
            Me.ErrorProvider1.Dispose()
            dgItemGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            GetFinalBillAmount()
            txtItemCode.Focus()
            txtRate.Text = ""
            btnModifyKOT.Enabled = False
            txtItemCode.Text = ""
            lblUnit.Text = ""
            lblUnit.Text = ""
            lblGSTPer.Text = ""
            lblSCPer.Text = ""
            FlagGridFormatting = True
            cmbItemName.SelectedValue = 0
            dgItemGrid.Enabled = True
            btnSettleBillHomePage.Enabled = False
            btnEstimate.Enabled = False
            btnModifyKOT.Enabled = False
            btnShiftTable.Enabled = False
            btnHistory.Enabled = False
        Catch ex As Exception
        End Try

    End Sub

    Public Sub GetFinalBillAmount()
        Qty = 0 : Amount = 0 : TaxAmount = 0 : SCAmount = 0 : TotalAmt = 0 : DiscountAmt = 0
        RQty = 0 : RAmount = 0 : RGSTAmt = 0 : RSTAmt = 0 : RSCAmt = 0 : RTotalAmt = 0 : RDiscountAmt = 0
        TaxAmount = 0 : RGSTAmt = 0 : BillAmount = 0 : BillQty = 0 : VATAmt = 0 : RVATAmt = 0

        For Me.ctr = 0 To dtKOTItems.Rows.Count - 1
            Qty = Val(dtKOTItems.Rows(ctr)("Qty"))
            TaxPer = Val(dtKOTItems.Rows(ctr)("TaxPer"))
            TaxType = Trim(dtKOTItems.Rows(ctr)("TaxType"))
            RQty += Qty

            Amount = Val(dtKOTItems.Rows(ctr)("Amount"))
            RAmount += Amount

            RDiscountPer = Val(dtKOTItems.Rows(ctr)("DiscountPer"))
            AmtAfterDiscount = Amount * (100 - Val(RDiscountPer)) * 0.01
            SCAmount = (AmtAfterDiscount) * Val(dtKOTItems.Rows(ctr)("SCPer")) * 0.01

            RAmtAfterDiscount += AmtAfterDiscount


            DiscountAmt = Amount * Val(RDiscountPer) * 0.01
            RDiscountAmt += DiscountAmt
            If TaxType = "VAT" Then
                VATAmt = (AmtAfterDiscount) * Val(dtKOTItems.Rows(ctr)("TaxPer")) * 0.01
                RVATAmt += VATAmt
                TaxAmount = 0
            End If
            If TaxType = "GST" Or Val(SCPer) > 0 Then
                VATAmt = 0
                TaxAmount = (AmtAfterDiscount) * Val(dtKOTItems.Rows(ctr)("TaxPer")) * 0.01 + SCAmount * Val(GSTPerOnServiceCharge) * 0.01
                RGSTAmt += TaxAmount
            End If

            RSCAmt += SCAmount
            TotalAmt = AmtAfterDiscount + TaxAmount + VATAmt + SCAmount
            RTotalAmt += TotalAmt

        Next ctr
        lblTotalQty.Text = RQty
        lblSubTotal.Text = RAmount.ToString("###0.00")
        lblSCAmt.Text = Val(RSCAmt).ToString("####0.00")
        lblGSTAmt.Text = Format(Math.Round(RGSTAmt, 2), NumFormat)
        lblVATAmt.Text = Format(Math.Round(RVATAmt, 2), NumFormat)

        AmtBeforeRoundOff = Format(Math.Round(RTotalAmt, 2), NumFormat)
        AmtAfterRoundOff = Format(Math.Round(RTotalAmt + 0.01, 0), NumFormat)
        RoundOff = Math.Round(AmtAfterRoundOff - AmtBeforeRoundOff, 2)

        lblRoundOff.Text = RoundOff.ToString("####0.00")
        lblGrossAmt.Text = AmtAfterRoundOff.ToString("####0.00")

        labelBillBasicAmount.Text = lblSubTotal.Text
        labelBillSCAmount.Text = lblSCAmt.Text
        labelBillGSTAmount.Text = lblGSTAmt.Text
        labelBillNetAmount.Text = AmtBeforeRoundOff.ToString("####0.00")
        labelBillRoundOff.Text = RoundOff.ToString("####0.00")
        lblROff.Text = RoundOff.ToString("####0.00")
        labelBillGrossAmount.Text = AmtAfterRoundOff.ToString("####0.00")
        If GetBillingMode(txtMemID.Text) = "Single" Then
            lblSmartCardClosingBalance.Text = Val(Val(lblSmartCardOpeningBalance.Text) - Val(lblGrossAmt.Text)).ToString("###0.00")
            labelBillPayModeOpeningStr.Text = lblBillingSmartCardOpeningStr.Text
            labelBillPayModeClosingStr.Text = lblBillingSmartCardClosingStr.Text
        Else
            labelBillPayModeOpeningStr.Text = "NA"
            labelBillPayModeClosingStr.Text = "NA"
        End If
    End Sub

    Private Sub txtItemCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ValidateWholeNumberInput(sender, e)
    End Sub

    Private Sub EnableItemPanel()
        LastBillNo = Val(lblBillNo.Text)
        lblKOTNo.Text = ""
        lblBillNo.Text = ""
        VoidRemarks = ""
        PanelDisplayArea.Visible = True
        ITEM_SNO = 0
        BindItemGrid()
    End Sub

    Private Function validation() As Boolean
        If cmbLocation.SelectedValue = 0 Then
            Message = "Select Location"
            ErrorProvider1.SetError(cmbLocation, Message)
            cmbLocation.Focus()
            validation = False
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If cmbWaiter.SelectedValue = 0 Then
            Message = "Select Waiter"
            ErrorProvider1.SetError(cmbWaiter, Message)
            cmbWaiter.Focus()
            validation = False
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If cmbTable.SelectedValue = 0 Then
            Message = "Select Table No."
            cmbTable.Focus()
            validation = False
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If

        If dgItemGrid.RowCount = 0 Then
            ErrorProvider1.SetError(txtItemCode, "Enter Items to grid before saving")
            validation = False
            txtItemCode.Focus()
            Exit Function
        Else
            ErrorProvider1.Dispose()
            validation = True
        End If
        validation = True
    End Function

    Private Sub ClearControlsAfterCheckSave()
        BillEstimate = 0
        BillingMode = ""
        LastBillNo = Val(lblBillNo.Text)
        lblKOTNo.Text = ""
        lblBillNo.Text = ""
        dgItemGrid.Visible = False
        PanelDisplayArea.Visible = False
        dgItemGrid.Visible = False
        VoidRemarks = ""
        dgItemGrid.Visible = True
        PanelDisplayArea.Visible = True
        txtItemCode.Focus()
        ITEM_SNO = 0
        BindItemGrid()
        lblGSTAmt.Text = "0.00"
        lblTotalQty.Text = "0"
        lblGrossAmt.Text = "0.00"
        lblSubTotal.Text = "0.00"
        PanelClosedBills.Visible = True
        ActionType = ""
        DisableControl(PanelItem)
        EnableItemPanel()
        PanelDisplayArea.Enabled = True
        EnableControl(PanelDisplayArea)
        txtItemCode.Focus()
        btnClose.Enabled = True
        DisableControl(PanelItem)
        DisableControl(PanelDisplayArea)
        btnShowTables.Focus()
        btnShowTables.Text = "NEW BILL"
        btnShowTables.Enabled = True
        btnShowTables.Tag = ""
        PanelClosedBills.Visible = True
        btnShowTables.Text = "NEW BILL"
        btnShowTables.Enabled = True
        lblBillNo.Text = ""
        lblKOTNo.Text = ""
        ClearCardDetails()
        ClearControls()
        ControlAccess()
        PopulateTablesSC(cmbLocation.SelectedValue, cmbLocation.SelectedValue, 1)
        cmbTableNoSC.SelectedValue = 0
    End Sub

    Private Sub ClearCardDetails()
        lblBillingSmartCardOpeningStr.Text = "Card Opening"
        lblBillingSmartCardClosingStr.Text = "Card Closing"
        lblSmartCardOpeningBalance.BackColor = Color.Green
        lblSmartCardClosingBalance.BackColor = Color.Tomato
        lblSmartCardOpeningBalance.Text = ""
        lblSmartCardClosingBalance.Text = ""

        lblOpeningCreditLimitstr.Text = "Credit Limit"
        lblMemberAcClosingStr.Text = "Mem A/c Closing"
        lblOpeningCreditLimit.BackColor = Color.Green
        lblMemberAcClosingBalance.BackColor = Color.Tomato
        lblOpeningCreditLimit.Text = ""
        lblMemberAcClosingBalance.Text = ""
        lblIssueNo.Text = ""

    End Sub

    Private Function GetBilledQty(ByVal ItemCode As Integer) As Integer
        StrSql = "select sum(qty) from FB_KOTBody k, FB_BillBody b where k.KOTNo=IM.KOTNo and k.YearCode=IM.YearCode and IM.BillNo=" & lblBillNo.Text & " and IM.YearCode=2 and itemCode=" & ItemCode
        Dim BilledQty As Integer = ObjDatabase.ExecuteScalar(StrSql)
        GetBilledQty = BilledQty
    End Function

    Private Sub btnClearScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        ClearControls()
        EnableItemPanel()
        txtItemCode.Focus()
        PanelDisplayArea.Enabled = True
    End Sub


    Private Function PickItemDetails() As Integer
        retValue = 0
        OpenItem = 0
        OpenItemName = ""
        txtRate.ReadOnly = True
        Try
            If txtItemCode.Text = "" Then
                cmbItemName.Focus()
                Exit Function
            End If
            If RateType.ToUpper = "SPECIAL" Then
                If ItemCodeType = "I" Then
                    StrSql = "Select IM.ItemCode,IM.ItemName,UM.Code UnitCode,UM.UnitName,IM.EventRate SP,TM.ValuePercentage VAT ,IM.OpenItem, IM.AliasName" & _
                    " From IM_ItemMaster IM,AC_TaxMaster TM,IM_UnitMaster UM" & _
                    " Where IM.ItemCode=" & Val(txtItemCode.Text) & " AND IM.SaleTaxCode=TM.Code and IM.SaleUnit=UM.Code  and IM.Status='Active' and IM.EventRate>0 Order by IM.ItemName"
                Else
                    StrSql = "Select IM.ItemCode,IM.ItemName,UM.Code UnitCode,UM.UnitName,IM.EventRate SP,TM.ValuePercentage VAT ,IM.OpenItem,IM.AliasName" & _
                    " From IM_ItemMaster IM, AC_TaxMaster TM, IM_UnitMaster UM" & _
                    " Where IM.AliasName='" & ItemPrefix & Trim(txtItemCode.Text) & "' AND IM.SaleTaxCode=TM.Code and IM.SaleUnit=UM.Code  and IM.Status='Active' and IM.EventRate>0 Order by IM.ItemName"
                End If
            Else
                If ItemCodeType = "I" Then
                    StrSql = "Select IM.ItemCode,IM.ItemName,UM.Code UnitCode,UM.UnitName,IM.SP SP,TM.ValuePercentage VAT ,IM.OpenItem,IM.AliasName" & _
                    " From IM_ItemMaster IM,AC_TaxMaster TM,IM_UnitMaster UM" & _
                    " Where IM.ItemCode=" & Val(txtItemCode.Text) & " AND IM.SaleTaxCode=TM.Code and IM.SaleUnit=UM.Code  and IM.Status='Active' Order by IM.ItemName"
                Else
                    StrSql = "Select IM.ItemCode,IM.ItemName,UM.Code UnitCode,UM.UnitName,IM.SP SP,TM.ValuePercentage VAT ,IM.OpenItem,IM.AliasName" & _
                    " From IM_ItemMaster IM,AC_TaxMaster TM,IM_UnitMaster UM" & _
                    " Where IM.AliasName='" & ItemPrefix & Trim(txtItemCode.Text) & "' AND IM.SaleTaxCode=TM.Code and IM.SaleUnit=UM.Code  and IM.Status='Active' Order by IM.ItemName"
                End If
            End If

            ds = New DataSet
            ds = ObjDatabase.BindDataSet(StrSql, "Itemdetail")
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("ItemName") = "" Then
                    cmbItemName.SelectedIndex = 0
                    MsgBox("Item doesn't exist.", MsgBoxStyle.Information, "INFORMATION")
                    txtItemCode.Text = ""
                    txtItemCode.Focus()
                    retValue = 0
                    Exit Function
                End If
                lblAliasCode.Text = (ds.Tables(0).Rows(0).Item("AliasName") & "")
                txtItemCode.Text = Val(ds.Tables(0).Rows(0).Item("ItemCode") & "")
                cmbItemName.SelectedValue = Val(ds.Tables(0).Rows(0).Item("ItemCode") & "")
                txtRate.Text = Val(ds.Tables(0).Rows(0).Item("SP") & "")
                lblUnit.Text = ds.Tables(0).Rows(0).Item("UnitName")
                OpenItem = Val(ds.Tables(0).Rows(0).Item("OpenItem") & "")
                txtQty.Text = "1"
                txtQty.SelectionLength = 1
                txtQty.SelectionStart = 0
                txtQty.Focus()
                retValue = 1
                lblItemName.Text = cmbItemName.Text
                If OpenItem = 1 Then
                    OpenItemName = InputBox("Enter Open item Name", "Open Item")
                    If OpenItemName = "" Then
                        Exit Function
                    Else
                        lblItemName.Text = OpenItemName
                        txtRate.Enabled = True
                        txtRate.ReadOnly = False
                        txtRate.Focus()
                    End If
                ElseIf Val(txtRate.Text) = 0 Then
                    txtRate.Enabled = True
                    txtRate.ReadOnly = False
                    txtRate.Focus()
                Else
                    txtRate.Enabled = False
                End If
                retValue = 1
                If FlagServiceCharge = 1 Then
                    lblSCPer.Text = (GlobalServiceChargePer).ToString(NumberFormat)
                Else
                    lblSCPer.Text = "0.00"
                End If
                SubCheckStockBefore(cmbItemName.SelectedValue)
            Else
                cmbItemName.SelectedValue = 0
                MsgBox("Item doesn't exist.", MsgBoxStyle.Information, "INFORMATION")
                txtItemCode.Text = ""
                txtItemCode.Focus()
                retValue = 0
                Exit Function
            End If
            ObjDatabase.CloseDatabaseConnection()
            PickItemDetails = retValue
        Catch ex As Exception
            txtItemCode.Focus()
        End Try
    End Function

    Private Function PickItemDetailsItemCombo() As Integer
        txtRate.ReadOnly = True
        retValue = 0
        OpenItem = 0
        ItemName = ""
        If RateType.ToUpper = "SPECIAL" Then
            StrSql = "Select IM.ItemCode,IM.ItemName,UM.Code UnitCode,UM.UnitName, IM.EventRate SP,TM.ValuePercentage VAT,IM.OpenItem,IM.AliasName" & _
            " From IM_ItemMaster IM,AC_TaxMaster TM,IM_UnitMaster UM" & _
            " Where IM.ItemCode='" & Val(cmbItemName.SelectedValue) & "'" & _
            " AND IM.SaleTaxCode=TM.Code and IM.EventRate>0" & _
            " and IM.SaleUnit=UM.Code" & _
            " Order by IM.ItemName"
        Else
            StrSql = "Select IM.ItemCode,IM.ItemName,UM.Code UnitCode,UM.UnitName, IM.SP SP,TM.ValuePercentage VAT,IM.OpenItem,IM.AliasName" & _
            " From IM_ItemMaster IM,AC_TaxMaster TM,IM_UnitMaster UM" & _
            " Where IM.ItemCode='" & Val(cmbItemName.SelectedValue) & "'" & _
            " AND IM.SaleTaxCode=TM.Code" & _
            " and IM.SaleUnit=UM.Code" & _
            " Order by IM.ItemName"
        End If

        ds = New DataSet
        ds = ObjDatabase.BindDataSet(StrSql, "Item")
        If ds.Tables(0).Rows.Count > 0 Then
            lblAliasCode.Text = (ds.Tables(0).Rows(0).Item("AliasName") & "")
            txtItemCode.Text = Val(ds.Tables(0).Rows(0).Item("ItemCode") & "")
            cmbItemName.SelectedValue = Val(ds.Tables(0).Rows(0).Item("ItemCode") & "")
            txtRate.Text = Val(ds.Tables(0).Rows(0).Item("SP") & "")
            lblUnit.Text = ds.Tables(0).Rows(0).Item("UnitName")
            lblGSTPer.Text = ds.Tables(0).Rows(0).Item("VAT")
            OpenItem = Val(ds.Tables(0).Rows(0).Item("OpenItem") & "")
            If (Val(ds.Tables(0).Rows(0).Item("SP") & "") = "0.0") Then
                txtRate.Enabled = True
                txtRate.Focus()
            Else
                txtQty.Focus()
            End If
            lblItemName.Text = cmbItemName.Text
            If OpenItem = 1 Then
                OpenItemName = InputBox("Enter Open item Name", "Open Item")
                If OpenItemName = "" Then
                    Exit Function
                Else
                    lblItemName.Text = OpenItemName
                    lblOpenItemName.Text = lblItemName.Text
                    txtRate.Enabled = True
                    txtRate.ReadOnly = False
                    txtRate.Focus()
                End If
            ElseIf Val(txtRate.Text) = 0 Then
                txtRate.Enabled = True
                txtRate.ReadOnly = False
                txtRate.Focus()
            Else
                txtRate.Enabled = False
            End If

            If FlagServiceCharge = 1 Then
                lblSCPer.Text = (GlobalServiceChargePer).ToString(NumberFormat)
            Else
                lblSCPer.Text = "0.00"
            End If

            retValue = 1
            SubCheckStockBefore(cmbItemName.SelectedValue)
        Else
            cmbItemName.SelectedValue = 0
            MsgBox("Item doesn't exist.", MsgBoxStyle.Information, "INFORMATION")
            txtItemCode.Text = ""
            txtItemCode.Focus()
            retValue = 0
            Exit Function
        End If
        ObjDatabase.CloseDatabaseConnection()
        PickItemDetailsItemCombo = retValue
    End Function

    Private Sub dgDisplayGrid_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemGrid.CellContentClick
        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            dtKOTItems.Rows(dgItemGrid.CurrentRow.Index).Delete()
            dtKOTItems.AcceptChanges()
            dgItemGrid.DataSource = dtKOTItems
            cmbItemName.SelectedValue = 0
            txtQty.Focus()
            GetFinalBillAmount()
            txtItemCode.Focus()
        ElseIf e.RowIndex >= 0 And e.ColumnIndex = 1 Then
            ItemCode = dgItemGrid.Rows(dgItemGrid.CurrentRow.Index).Cells("ItemCode").Value()
            ItemRate = dgItemGrid.Rows(dgItemGrid.CurrentRow.Index).Cells("Rate").Value()
            TaxPer = dgItemGrid.Rows(dgItemGrid.CurrentRow.Index).Cells("TaxPer").Value()
            Qty = dgItemGrid.Rows(dgItemGrid.CurrentRow.Index).Cells("Qty").Value()
            cmbItemName.SelectedValue = ItemCode
            cmbItemName_Validated(sender, e)
            txtQty.Text = Qty
            txtRate.Text = ItemRate
            dtKOTItems.Rows(dgItemGrid.CurrentRow.Index).Delete()
            dtKOTItems.AcceptChanges()
            dgItemGrid.DataSource = dtKOTItems
            GetFinalBillAmount()
            txtQty.Text = ""
            txtQty.Focus()
        ElseIf e.ColumnIndex = 2 Then
            BindItemModifiers()
            ModifierItemCode = dgItemGrid.Rows(dgItemGrid.CurrentRow.Index).Cells("ItemCode").Value()
            ModifierRemarks = dgItemGrid.Rows(dgItemGrid.CurrentRow.Index).Cells("Remarks").Value()
            PanelModifiers.Location = LeftPanelLocation
            PanelModifiers.BringToFront()
            EnableControl(PanelModifiers)
            PanelModifiers.Visible = True
            btnClear.BackColor = Color.Yellow
            btnDismiss.BackColor = Color.Yellow
            btnItemModifierOK.BackColor = Color.Yellow
            txtKOTRemarks.Text = ModifierRemarks
        End If
    End Sub

    Private Sub btnCloseDuplicateBillScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PanelClosedBills.Visible = True
        PanelItem.Visible = True
        BindItemGrid()
        txtQty.Focus()
        ActionType = ""
    End Sub

    Private Sub txtItemCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemCode.Validated
        LabelClosingStock.Text = ""
        PickItemDetails()
        txtRate.Enabled = True
    End Sub

    Private Sub cmbItemName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbItemName.Validated
        If cmbItemName.SelectedValue > 0 Then
            If PickItemDetailsItemCombo() = 1 Then
                ' SubCheckStockBefore(cmbItemName.SelectedValue)
                'LabelClosingStock.Text = ""
                txtQty.Text = "1"
                txtQty.SelectionStart = 0
                txtQty.SelectionLength = 1
            End If
        Else
            'cmbItemName.Focus()
        End If
    End Sub

    Private Sub dgHistory_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHistory.CellContentClick
        If dgHistory.Tag = "History" And e.ColumnIndex = 0 Then
            _BillNo = dgHistory.Rows(e.RowIndex).Cells("BillNo").Value()
            _LocationCode = dgHistory.Rows(e.RowIndex).Cells("LocationCode").Value()
            _YearCode = dgHistory.Rows(e.RowIndex).Cells("YearCode").Value()
            _TableNo = dgHistory.Rows(e.RowIndex).Cells("TableNo").Value()
            _MemID = dgHistory.Rows(e.RowIndex).Cells("MemberID").Value()
            _ValidationMode = dgHistory.Rows(e.RowIndex).Cells("ValidationMode").Value()
            lblBillNo.Text = Val(_BillNo)
            lblLocationCode_KOTModify.Text = _LocationCode
            lblYearCode_KOTModify.Text = YearCode
            lblMemID.Text = _MemID
            PanelModifyKOT.Visible = True
            PanelModifyKOT.Location = RightPanelLocation
            PanelRight.Visible = False
            labelKOTModificationHeader.Text = "KOT belonging to the Table No. " & _TableNo & "; Bill No: " & Val(lblBillNo.Text)
            BindKOTNosForModification()
            BindKOTModifyItemDetails(0, 0, 0)
            btnModifyKOT.Text = "SAVE KOT"

            lblActualQty.Text = "0"
            lblModifiedQty.Text = "0"
            lblModifiedKOTAmt.Text = "0.00"
            lblModifiedQty.Text = "0.00"
            lblReducedKOTQty.Text = "0"
            lblReducedKOTAmt.Text = "0.00"

            cmbKOTRemarks.Enabled = True
            btnShowTables.Enabled = False
            btnSaveNSettle.Enabled = False
            btnSettleBillHomePage.Enabled = False
            btnShiftTable.Enabled = False
            If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True

        ElseIf (dgHistory.Tag = "History") And e.ColumnIndex = 1 Then
            _BillNo = dgHistory.Rows(e.RowIndex).Cells("BillNo").Value()
            _LocationCode = dgHistory.Rows(e.RowIndex).Cells("LocationCode").Value()
            _YearCode = dgHistory.Rows(e.RowIndex).Cells("YearCode").Value()
            lblTempBillNo.Text = _BillNo
            lblTempLocationCode.Text = _LocationCode
            lblTempYearCode.Text = _YearCode
            If e.ColumnIndex = 1 Then
                PanelDisplayBill.BringToFront()
                PanelDisplayBill.Visible = True
                PanelDisplayBill.Location = New Point(676, 2)
                'PrintWindowsPOSBillThermal(_BillNo, 0, _LocationCode, "DUPLICATE BILL")
                EnableControl(PanelDisplayBill)
            End If
        ElseIf dgHistory.Tag = "OpenBills" Then
            _BillNo = dgHistory.Rows(e.RowIndex).Cells("BillNo").Value()
            _LocationCode = dgHistory.Rows(e.RowIndex).Cells("LocationCode").Value()
            _YearCode = dgHistory.Rows(e.RowIndex).Cells("YearCode").Value()
            lblTempBillNo.Text = _BillNo
            lblTempLocationCode.Text = _LocationCode
            lblTempYearCode.Text = _YearCode
            If e.ColumnIndex = 1 Then
                Dim Choice As Integer = MsgBox("TO PRINT KOT/STEWARD CLICK <YES>/<NO>", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Exclamation)
                If Choice = 6 Then
                    'PrintWindowsPOSBillKOT(_BillNo, _LocationCode, _YearCode, "KOT")
                    PanelDisplayBill.BringToFront()
                    PanelDisplayBill.Visible = True
                    PanelDisplayBill.Location = New Point(676, 2)
                    EnableControl(PanelDisplayBill)
                ElseIf Choice = 7 Then
                    'PrintWindowsPOSBillKOT(_BillNo, _LocationCode, _YearCode, "STEWARD")
                    PanelDisplayBill.BringToFront()
                    PanelDisplayBill.Visible = True
                    PanelDisplayBill.Location = New Point(676, 2)
                    EnableControl(PanelDisplayBill)
                End If
            ElseIf e.ColumnIndex = 2 Then
                PanelDisplayBill.BringToFront()
                PanelDisplayBill.Visible = True
                PanelDisplayBill.Location = New Point(676, 2)
                'PrintWindowsPOSBillThermal(_BillNo, 0, _LocationCode, "DRAFT BILL")
                EnableControl(PanelDisplayBill)
            End If
        End If
    End Sub

    Private Sub FrmPOSKeyBoard_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cmbLocation.Focus()
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        If cmbLocation.SelectedValue = 0 Then
            Message = "Select Location"
            cmbLocation.Focus()
            Exit Sub
        End If
        dgHistory.Tag = "History"
        BindClosedBills()
        btnRefresh.Enabled = True
        btnClose.Enabled = True
    End Sub

    Private Sub dgItemGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgItemGrid.CellFormatting
        For i As Integer = 0 To Me.dgItemGrid.Rows.Count - 1
            Me.dgItemGrid.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            Me.dgItemGrid.Rows(i).DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Next
    End Sub

    Private Sub DisplayMemberPics(ByVal MemberID As String)
        Try
            PBMember.Image = Image.FromFile(ApplicationStartupPath & "\Photo_Sign\photo\" & MemberID & ".jpg")
        Catch
            PBMember.Image = Image.FromFile(ApplicationStartupPath & "\Photo_Sign\photo\blank.jpg")
        End Try
        Try
            PBSpouse.Image = Image.FromFile(ApplicationStartupPath & "\Photo_Sign\photo\" & MemberID & "S.jpg")
        Catch
            PBSpouse.Image = Image.FromFile(ApplicationStartupPath & "\Photo_Sign\photo\blank.jpg")
        End Try

        Try
            PBMemberSign.Image = Image.FromFile(ApplicationStartupPath & "\Photo_Sign\sign\" & MemberID & ".jpg")
        Catch
            PBMemberSign.Image = Image.FromFile(ApplicationStartupPath & "\Photo_Sign\sign\blank.jpg")
        End Try
        Try
            PBSpouseSign.Image = Image.FromFile(ApplicationStartupPath & "\Photo_Sign\sign\" & MemberID & "S.jpg")
        Catch
            PBSpouseSign.Image = Image.FromFile(ApplicationStartupPath & "\Photo_Sign\sign\blank.jpg")
        End Try
    End Sub

    Private Sub btnRecallBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
        BackToMainScreen = True
    End Sub

    Private Sub cmbBillingLocation_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLocation.Validated
        If cmbLocation.SelectedValue > 0 Then
            CurrentBusinessDate = GetCurrentBusinessDate()
            lblBillDate.Text = CurrentBusinessDate.ToString("dd/MMM/yyyy")
            LOCATION_Code = cmbLocation.SelectedValue
            LoadDefaultSettings(LOCATION_Code)
            BindOpenBills()
            ClearControls()
            EnableItemPanel()
            txtItemCode.Focus()
            PanelDisplayArea.Enabled = True
            StrSql = "Select ItemCode, ItemName from IM_ItemMaster WHERE Maingroup IN (" & BAR_MAINGROUPS & ") AND ItemGroup IN(SELECT GroupCode FROM FB_LocationGroupLink WHERE [LocationCode]=" & LOCATION_Code & ") and status='Active' and itemCode in (select distinct BOMItemCode from IM_ItemBOMMaster)"
            StrSql &= " UNION ALL"
            StrSql &= " Select ItemCode, ItemName from IM_ItemMaster WHERE Maingroup IN (" & REST_MAINGROUPS & ") AND ItemGroup IN(SELECT GroupCode FROM FB_LocationGroupLink WHERE [LocationCode]=" & LOCATION_Code & ") and status='Active'"
            BindComboboxWithSelectOneNumeric(StrSql, "ItemCode", "ItemName", cmbItemName)
            cmbItemName.SelectedValue = 0
            StrSql = "Select Code,WaiterName From FB_WaiterMaster Where Status='Active' and Code in(select WaiterCode from FB_LocationWaiterLink where LocationCode=" & LOCATION_Code & ")"
            BindComboboxWithSelectOneNumeric(StrSql, "Code", "WaiterName", cmbWaiter)
            cmbWaiter.SelectedValue = 0
            PopulateTablesSC(cmbLocation.SelectedValue, cmbLocation.SelectedValue, 1)
            cmbTableNoSC.SelectedValue = 0
            StrSql = "select SubStore from IM_LocationMaster where Code=" & LOCATION_Code
            ds = ObjDatabase.BindDataSet(StrSql, "Location")
            If ds.Tables("Location").Rows.Count > 0 Then
                SUBSTORE_Code = (ds.Tables("Location").Rows(0)("SubStore") & "")
            End If
        End If
        FlagServiceCharge = IIf(SCApplicable.ToUpper() = "YES", 1, 0)
    End Sub


    Private Sub btnShowTables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowTables.Click
        If cmbLocation.SelectedValue = 0 Then
            Message = "Select Location"
            cmbLocation.Focus()
            Exit Sub
        End If
        If btnShowTables.Text = "NEW BILL" Then
            Message = "Select Table No for the Check"
            PanelLocationTables.Tag = "LocationTable"
            PanelLocationAndTables.Location = RightPanelLocation
            PanelLocationAndTables.Visible = True
            PanelModifyKOT.Visible = False
            PanelRight.Visible = False
            PanelDisplayBill.Visible = False
            LocationTableCounter = 0
            PopulateLocationButtons()
            dsTable = New DataSet
            dsTable = PopulateTables(LOCATION_Code, Val(cmbLocation.SelectedValue), 1)
            PopulateTableNoWithStatus()
            Message = "Select Table No"
            PanelTables.Tag = "Table"
            BindOpenBills()
            btnRefresh.Enabled = True
            btnEstimate.Enabled = False
            PanelTables.Tag = "Table"
        ElseIf btnShowTables.Text = "SAVE" Then
            PanelTables.Visible = True
            If validation() = False Then Exit Sub
            btnModifyKOT.Enabled = False
            TableCode = cmbTable.SelectedValue

            BillingMode = GetBillingMode(txtMemID.Text)
            ObjDatabase.ConnectDatabse()
            ObjDatabase.OpenDatabaseConnection()

            myTrans = ObjDatabase.con.BeginTransaction()
            myCommand = ObjDatabase.con.CreateCommand()
            myCommand.Transaction = myTrans
            KOTNo = 0 : BillNo = 0

            If KOTType = "N" Then
                StrSql = "Select IsNull(Max(KOTNo),0) + 1 From FB_KOTHead where YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code
                myCommand.CommandText = StrSql
                KOTNo = myCommand.ExecuteScalar
                lblKOTNo.Text = KOTNo
                StrSql = "Select IsNull(Max(BillNo),0) + 1 From FB_BillHead where YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code
                myCommand.CommandText = StrSql
                BillNo = myCommand.ExecuteScalar
                lblBillNo.Text = BillNo
            End If

            If KOTType = "A" Then
                StrSql = "Select IsNull(Max(KOTNo),0) + 1 From FB_KOTHead where YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code
                myCommand.CommandText = StrSql
                KOTNo = myCommand.ExecuteScalar
                BillNo = lblBillNo.Text
            End If
            Try
                StrSql = ""
                lblKOTNo.Text = KOTNo
                StrSql = "INSERT INTO [FB_KOTHead]" & _
                "([KOTNo]" & _
                ",[KOTDate]" & _
                ",[MemberID]" & _
                ",[IssueNo]" & _
                ",[WaiterCode]" & _
                ",[TableCode]" & _
                ",[PAX]" & _
                ",[RefNo]" & _
                ",[ModeOfPayment]" & _
                ",[OpeningBalance]" & _
                ",[ClosingBalance]" & _
                ",[CreationDate]" & _
                ",[ModificationDate]" & _
                ",[UserCode]" & _
                ",[LocationCode]" & _
                ",[YearCode]" & _
                ")" & _
                " VALUES" & _
                "(" & _
                Val(lblKOTNo.Text) & _
                ",'" & Format(CDate(lblBillDate.Text), "dd/MMM/yyyy") & "'" & _
                ",'" & Trim(txtMemID.Text) & "'" & _
                "," & IIf(BillingMode = "Single", Val(lblIssueNo.Text), 0) & "" & _
                "," & Val(cmbWaiter.SelectedValue) & _
                "," & Val(cmbTable.SelectedValue) & _
                "," & Val(txtPAX.Text) & _
                "," & Val(txtRefNo.Text) & "" & _
                ",'" & IIf(BillingMode = "Single", "SmartCard", "") & "'" & _
                "," & Val(lblSmartCardOpeningBalance.Text) & _
                "," & Val(lblSmartCardClosingBalance.Text) & _
                ",getdate()" & _
                ",getdate()" & _
                "," & Val(UserCode) & _
                "," & LOCATION_Code & _
                "," & YearCode & _
                ")"
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                For ictr = 0 To dtKOTItems.Rows.Count - 1
                    If Val(dtKOTItems.Rows(ictr)("ItemCode")) > 0 And Val(dtKOTItems.Rows(ictr)("Qty")) > 0 Then
                        StrSql = "INSERT INTO FB_KOTBody " & _
                        "([KOTNo]" & _
                        ",[ItemCode]" & _
                        ",[ItemName]" & _
                        ",[OpenItem]" & _
                        ",[UnitCode]" & _
                        ",[Qty]" & _
                        ",[ActualQty]" & _
                        ",[Rate]" & _
                        ",[SchemeRate]" & _
                        ",[Amount]" & _
                        ",[DiscountPer]" & _
                        ",[TaxPer]" & _
                        ",[TaxType]" & _
                        ",[SCPer]" & _
                        ",[CreationDate]" & _
                        ",[ModificationDate]" & _
                        ",[UserCode]" & _
                        ",[LocationCode]" & _
                        ",[YearCode],[Remarks],[IsNC]" & _
                        ")" & _
                        " select " & Val(lblKOTNo.Text) & _
                        "," & Val(dtKOTItems.Rows(ictr)("ItemCode")) & _
                        ",'" & Trim(dtKOTItems.Rows(ictr)("ItemName")).Replace("'", "''") & "'" & _
                        "," & Val(dtKOTItems.Rows(ictr)("OpenItem")) & _
                        "," & Val(dtKOTItems.Rows(ictr)("UnitCode")) & _
                        "," & Val(dtKOTItems.Rows(ictr)("Qty")) & _
                        "," & Val(dtKOTItems.Rows(ictr)("Qty")) & _
                        "," & Val(dtKOTItems.Rows(ictr)("Rate")) & _
                        "," & Val(dtKOTItems.Rows(ictr)("Rate")) & _
                        "," & Val(dtKOTItems.Rows(ictr)("Qty") * Val(dtKOTItems.Rows(ictr)("Rate"))) & _
                        "," & Val(dtKOTItems.Rows(ictr)("DiscountPer")) & _
                        "," & Val(dtKOTItems.Rows(ictr)("TaxPer")) & _
                        ",'" & Trim(dtKOTItems.Rows(ictr)("TaxType")) & "'" & _
                        "," & Val(dtKOTItems.Rows(ictr)("SCPer")) & _
                        ",getdate()" & _
                        ",getdate()" & _
                        "," & UserCode & _
                        "," & LOCATION_Code & _
                        "," & YearCode & _
                        ",''" & _
                        "," & IIf(chbComplementory.Checked = True, "1", "0") & ""
                        myCommand.CommandText = StrSql
                        myCommand.ExecuteNonQuery()
                    End If
                Next ictr

                lblBillNo.Text = BillNo
                If KOTType = "N" Then
                    StrSql = "INSERT INTO [FB_BillHead]" & _
                    "([BillNo]" & _
                    ",[BillDate]" & _
                    ",[MemberID]" & _
                    ",[MemberName]" & _
                    ",[WaiterCode]" & _
                    ",[TableCode]" & _
                    ",[BookingNo]" & _
                    ",[RoomCode]" & _
                    ",[IssueNo]" & _
                    ",[PAX]" & _
                    ",[BillStatus]" & _
                    ",[BillType]" & _
                    ",[Amount]" & _
                    ",[RoundOff]" & _
                    ",[ModeOfPayment]" & _
                    ",[RefNo]" & _
                    ",[RefDate]" & _
                    ",[ValidationMode]" & _
                    ",[Remarks]" & _
                    ",[OpeningBalance]" & _
                    ",[ClosingBalance]" & _
                    ",[CreationDate]" & _
                    ",[ModificationDate]" & _
                    ",[UserCode]" & _
                    ",[LocationCode]" & _
                    ",[YearCode])" & _
                    " VALUES" & _
                    "(" & Val(lblBillNo.Text) & _
                    ",'" & Format(CDate(lblBillDate.Text), "dd/MMM/yyyy") & "'" & _
                    ",'" & Trim(txtMemID.Text) & "'" & _
                    ",'" & Trim(lblMemberName.Text) & "'" & _
                    "," & Val(cmbWaiter.SelectedValue) & "" & _
                    "," & Val(cmbTable.SelectedValue) & _
                    ",0" & _
                    ",0" & _
                    "," & IIf(BillingMode = "Single", Val(lblIssueNo.Text), 0) & "" & _
                    "," & Val(txtPAX.Text) & _
                    ",0" & _
                    "," & BillType & _
                    "," & Val(lblGrossAmt.Text) & _
                    "," & Val(lblRoundOff.Text) & _
                    ",'" & IIf(BillingMode = "Single", "SmartCard", "") & "'" & _
                    ",'" & txtRefNo.Text & "'" & _
                    ",'" & Format(CDate(lblBillDate.Text), "dd/MMM/yyyy") & "'" & _
                    ",'" & lblValidationMode.Text & "'" & _
                    ",''" & _
                    "," & Val(lblSmartCardOpeningBalance.Text) & _
                    "," & Val(lblSmartCardClosingBalance.Text) & _
                    ",getdate()" & _
                    ",getdate()" & _
                    "," & UserCode & _
                    "," & LOCATION_Code & _
                    "," & YearCode & _
                    ")"
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()
                End If

                StrSql = "INSERT INTO [FB_BillBody]" & _
                "([BillNo]" & _
                ",[KOTNo]" & _
                ",[CreationDate]" & _
                ",[ModificationDate]" & _
                ",[UserCode]" & _
                ",[LocationCode]" & _
                ",[YearCode])" & _
                " VALUES (" & _
                Val(lblBillNo.Text) & _
                "," & Val(lblKOTNo.Text) & _
                ",getdate()" & _
                ",getdate()" & _
                "," & UserCode & _
                "," & LOCATION_Code & _
                "," & YearCode & _
                ")"
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                StrSql = "SELECT STUFF((SELECT ',' + CONVERT(VARCHAR(MAX),KOTNo) FROM FB_BillBody where BillNo=" & Val(lblBillNo.Text) & " and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code) & " FOR XML PATH('')), 1, 1, '') AS KOTNos"
                myCommand.CommandText = StrSql
                KOTStr = myCommand.ExecuteScalar()

                StrSql = "SELECT sum(Qty*Rate*(100-DiscountPer)*0.01+(Qty*Rate*(100-DiscountPer)*0.01*TaxPer*0.01)+(Qty*Rate*(100-DiscountPer)*0.01*SCPer*0.01" & _
                " + (Qty*Rate*(100-DiscountPer)*0.01*SCPer*0.01*" & GSTPerOnServiceCharge * 0.01 & "))) as BillAmount FROM FB_KOTBody" & _
                " where KOTNo in(" & KOTStr & ") and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code)
                myCommand.CommandText = StrSql
                AmtBeforeRoundOff = myCommand.ExecuteScalar()
                AmtAfterRoundOff = Math.Round(AmtBeforeRoundOff + 0.01, 0)
                RoundOff = Math.Round(AmtAfterRoundOff - AmtBeforeRoundOff, 2)

                StrSql = "UPDATE FB_BillHead SET Amount=" & AmtAfterRoundOff & ",RoundOff=" & RoundOff & ",ClosingBalance=OpeningBalance-" & AmtAfterRoundOff & _
                " WHERE BillNo=" & Val(lblBillNo.Text) & " and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code)
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()
                myTrans.Commit()
                Temp_KOTNo = KOTNo
                Temp_BillNo = BillNo
                Temp_MemberID = Trim(txtMemID.Text)
                Temp_MemberName = lblMemberName.Text
                Temp_BillingMode = lblValidationMode.Text.Trim
                'PrintWindowsPOSKOT(KOTNo, LOCATION_Code, YearCode, "Y")
                ClearControlsAfterCheckSave()
                If KOTType = "N" Then
                    If MsgBox("Bill No: " & Val(BillNo) & " saved successfully" & vbCrLf & "Do you wish to settle the Bill?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        lblBillNo.Text = Temp_BillNo
                        txtMemID.Text = Temp_MemberID
                        lblMemberName.Text = Temp_MemberName
                        lblValidationMode.Text = Temp_BillingMode
                        btnDraftBill_Click(sender, e)
                    End If
                Else
                    MsgBox("KOT No: " & Val(KOTNo) & " saved successfully", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                MsgBox("Error" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
                myTrans.Rollback()
            End Try
        End If
    End Sub

    Private Sub btnBillingLocation1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBillingLocation1.Click, btnBillingLocation2.Click, btnBillingLocation3.Click, btnBillingLocation4.Click, btnBillingLocation5.Click, btnBillingLocation6.Click, btnBillingLocation7.Click, btnBillingLocation1.Click, btnBillingLocation8.Click
        'BtnLocationCode = 0
        'TableCounter = 0
        'SelectedButton = New Button
        'SelectedButton = CType(sender, Button)
        'dsTable = New DataSet
        'ResetTables()
        'If PanelTables.Tag = "MoveTable" Then
        '    dsTable = PopulateTables(LOCATION_Code, Val(SelectedButton.Tag), 0)
        'Else
        '    dsTable = PopulateTables(LOCATION_Code, Val(SelectedButton.Tag), 1)
        'End If
        'PopulateTableNoWithStatus()
        'BtnLocationCode = Val(SelectedButton.Tag)
        'PanelTables.Tag = "Table"
    End Sub

    Private Sub btnTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable1.Click, btnTable2.Click, btnTable3.Click, btnTable4.Click, btnTable5.Click, btnTable6.Click, btnTable7.Click, btnTable8.Click, btnTable9.Click, btnTable10.Click, btnTable11.Click, btnTable12.Click, btnTable13.Click, btnTable14.Click, btnTable15.Click, btnTable16.Click, btnTable17.Click, btnTable18.Click, btnTable19.Click, btnTable20.Click, btnTable21.Click, btnTable22.Click, btnTable23.Click, btnTable24.Click, btnTable25.Click, btnTable26.Click, btnTable27.Click, btnTable28.Click, btnTable29.Click, btnTable30.Click, btnTable31.Click, btnTable32.Click, btnTable33.Click, btnTable34.Click, btnTable35.Click, btnTable36.Click, btnTable37.Click, btnTable38.Click, btnTable39.Click
        lblBillAmtPerviousKOT.Text = ""
        SelectedButton = New Button
        SelectedButton = CType(sender, Button)
        cmbTable.Text = SelectedButton.Text
        If PanelTables.Tag <> "MoveTable" Then
            Dim strTableDetail1() As String = SelectedButton.Tag.ToString.Split(",")
            TableCode = strTableDetail1(1)
            BillNo = strTableDetail1(0)
            lblBillNo.Text = BillNo
            cmbTable.SelectedValue = TableCode
        End If
        If PanelTables.Tag = "MoveTable" Then
            btnSaveNSettle.Enabled = False
            btnShowTables.Enabled = False
            btnSettleBillHomePage.Enabled = False
            btnShiftTable.Enabled = True
            btnModifyKOT.Enabled = False

            PanelLocationAndTables.Visible = False
            PanelRight.Visible = True
            EnableControl(PanelItem)
            EnableControl(PanelMemberDetails)
            cmbLocation.Enabled = False
            txtMemID.Enabled = False
            cmbTable.Enabled = False
            txtItemCode.Focus()
            btnShiftTable.Enabled = True
            btnShiftTable.Focus()
        Else
            If BillNo > 0 Then
                btnModifyKOT.Enabled = True
                btnShiftKOT.Enabled = True
                btnSaveNSettle.Enabled = True
                lblBillNo.Text = BillNo
                ObjDatabase.ConnectDatabse()
                cmbWaiter.SelectedValue = ObjDatabase.ExecuteScalarN("Select WaiterCode from FB_BillHead where BillNo=" & BillNo & " and YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code)
                txtMemID.Text = ObjDatabase.ExecuteScalarS("Select MemberID from FB_BillHead H where H.BillNo=" & BillNo & " and H.YearCode=" & YearCode & " and H.LocationCode=" & LOCATION_Code)
                Dim MainId As String = GetMainID(txtMemID.Text)
                lblOpenBillString.Text = "Open Bill Amt."
                lblBillAmtPerviousKOT.Text = ObjDatabase.ExecuteScalarS("Select sum(isnull(Amount,0)) from FB_BillHead H where H.BillDate='" & lblBillDate.Text & "' and BillStatus=0 and MemberID like '" & MainId.Trim() & "%'")
                'lblBillAmtPerviousKOT.Text = ObjDatabase.ExecuteScalarS("Select isnull(Amount,0) from FB_BillHead H where H.BillNo=" & BillNo & " and H.YearCode=" & YearCode & " and H.LocationCode=" & LOCATION_Code)
                lblIssueNo.Text = ObjDatabase.ExecuteScalarS("Select IssueNo from FB_BillHead H where H.BillNo=" & BillNo & " and H.YearCode=" & YearCode & " and H.LocationCode=" & LOCATION_Code)
                BILL_TYPE = ObjDatabase.ExecuteScalarS("Select ValidationMode from FB_BillHead H where H.BillNo=" & BillNo & " and H.YearCode=" & YearCode & " and H.LocationCode=" & LOCATION_Code)
                lblValidationMode.Text = BILL_TYPE
                Memtype = GetMemberType(txtMemID.Text)
                MemberID = txtMemID.Text.Trim
                lblMemID.Text = MemberID
                If Memtype.ToUpper = "NONMEMBER" Then
                    CardValidity = Now
                    StrSql = "SELECT isnull(ValidUpto,getdate()) from CM_CardIssue where IssueNo=" & Val(lblIssueNo.Text)
                    CardValidity = ObjDatabase.ExecuteScalar(StrSql)
                    If CDate(CurrentBusinessDate.ToString("dd/MMM/yyyy")) > CDate(CardValidity.ToString("dd/MMM/yyyy")) Then
                        MsgBox("Validity of the SmartCard has expired", MsgBoxStyle.Critical)
                        ClearControlsAfterCheckSave()
                    End If
                    lblSmartCardOpeningBalance.Text = GetSmartCardClosingBalance(txtMemID.Text).ToString(NumFormat)
                    lblSmartCardClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                    lblOpeningCreditLimit.Text = "NA"
                    lblMemberAcClosingBalance.Text = "NA"
                Else
                    lblSmartCardOpeningBalance.Text = GetSmartCardClosingBalance(txtMemID.Text).ToString(NumFormat)
                    lblSmartCardClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                    lblOpeningCreditLimit.Text = GetCreditLimit(txtMemID.Text).ToString(NumFormat)
                    lblMemberAcClosingBalance.Text = GetAvailableCreditLimit(txtMemID.Text).ToString(NumFormat)

                End If
                lblIssueNo.Text = ObjDatabase.ExecuteScalarS("Select IssueNo from FB_BillHead H where H.BillNo=" & BillNo & " and H.YearCode=" & YearCode & " and H.LocationCode=" & LOCATION_Code)
                lblMemberName.Text = ObjDatabase.ExecuteScalarS("Select MemberName from FB_BillHead BH where BH.BillNo=" & BillNo & " and BH.YearCode=" & YearCode & " and BH.LocationCode=" & LOCATION_Code)
                txtPAX.Text = ObjDatabase.ExecuteScalarN("Select PAX from FB_BillHead where BillNo=" & BillNo & " and YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code)
                btnShiftTable.Enabled = True
                btnSettleBillHomePage.Enabled = True
                btnSaveNSettle.Enabled = False
                btnRefresh.Enabled = True
                PanelLocationAndTables.Visible = False
                PanelRight.Visible = True
                EnableControl(PanelItem)
                If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True
                txtItemCode.Focus()
                ObjDatabase.CloseDatabaseConnection()
                KOTType = "A"
            Else
                btnRefresh.Enabled = True
                btnSaveNSettle.Enabled = True
                btnSettleBillHomePage.Enabled = False
                lblBillNo.Text = ""
                KOTType = "N"
                txtPAX.Text = "1"
                cmbWaiter.SelectedValue = 1
                txtItemCode.Focus()
            End If
            ControlAccess()
            PanelTables.Tag = "Item"
            btnShowTables.Text = "SAVE"
            Try
                If BillNo = 0 Then
                    MemberID = Trim(RFIDMemberID)
                    ReturnValue = 0
                    If MemberID.Contains("-") = False Then
                        If FlagOTPValidation.ToUpper = "NO" Then
                            MsgBox("Unable to Read card on the card Reader", MsgBoxStyle.Critical)
                            ClearControlsAfterCheckSave()
                            Exit Sub
                        End If
                        EnableControl(PanelMemberDetails)
                        EnableControl(PanelItem)
                        btnSendOTP.Text = "Send OTP"
                        BILL_TYPE = "OTP"
                        lblValidationMode.Text = BILL_TYPE
                        lblCardID.Text = MemberID
                        cmbLocation.Enabled = False
                        cmbTable.Enabled = False
                        PanelLocationAndTables.Visible = False
                        PanelItem.Enabled = True
                        PanelRight.Visible = True
                        If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True
                        btnShiftTable.Enabled = True
                        btnRefresh.Enabled = True
                        txtMemID.Enabled = True
                        txtMemID.Focus()
                        Exit Sub
                    ElseIf MemberID.Contains("MC") = True Then
                        EnableControl(PanelMemberDetails)
                        EnableControl(PanelItem)
                        BILL_TYPE = "MC"
                        lblValidationMode.Text = BILL_TYPE
                        btnSendOTP.Text = "Send OTP"
                        btnSendOTP.Enabled = False
                        lblCardID.Text = MemberID
                        cmbLocation.Enabled = False
                        cmbTable.Enabled = False
                        PanelLocationAndTables.Visible = False
                        PanelItem.Enabled = True
                        PanelRight.Visible = True
                        If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True
                        btnShiftTable.Enabled = True
                        btnRefresh.Enabled = True
                        txtMemID.Enabled = True
                        txtMemID.Focus()
                        Exit Sub
                    Else
                        ReturnValue = ValidateMemberCard(CardSerialNo, MemberID)

                        txtMemID.Text = MemberID
                        DisplayMemberPics(txtMemID.Text)
                        ds = New DataSet
                        ds = GetSmartCardBalance(txtMemID.Text)
                        If ds.Tables(0).Rows.Count > 0 Then
                            MainID = ds.Tables(0).Rows(0)("MainID")
                            MemberName = ds.Tables(0).Rows(0)("MemberName")
                            IssueID = ds.Tables(0).Rows(0)("IssuedID")
                            IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                            ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                            lblMemberName.Text = MemberName
                            lblSmartCardOpeningBalance.Text = ClosingBalance
                            lblSmartCardClosingBalance.Text = ClosingBalance
                            lblIssueNo.Text = IssueNo
                        End If
                        Memtype = GetMemberType(txtMemID.Text)
                        lblMainScreebCitizenType.Text = GetCitizenType(txtMemID.Text)
                        If Memtype.ToUpper = "NONMEMBER" Then
                            CardValidity = Now
                            StrSql = "SELECT isnull(ValidUpto,getdate()) from CM_CardIssue where IssueNo=" & Val(lblIssueNo.Text)
                            CardValidity = ObjDatabase.ExecuteScalar(StrSql)

                            If CDate(CurrentBusinessDate.ToString("dd/MMM/yyyy")) > CDate(CardValidity.ToString("dd/MMM/yyyy")) Then
                                MsgBox("Validity of the SmartCard has expired", MsgBoxStyle.Critical)
                                ClearControlsAfterCheckSave()
                            End If
                            lblSmartCardOpeningBalance.Text = GetSmartCardClosingBalance(txtMemID.Text).ToString(NumFormat)
                            lblSmartCardClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                            lblOpeningCreditLimit.Text = "NA"
                            lblMemberAcClosingBalance.Text = "NA"
                        Else
                            lblSmartCardOpeningBalance.Text = GetSmartCardClosingBalance(txtMemID.Text).ToString(NumFormat)
                            lblSmartCardClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                            lblOpeningCreditLimit.Text = GetCreditLimit(txtMemID.Text).ToString(NumFormat)
                            lblMemberAcClosingBalance.Text = GetAvailableCreditLimit(txtMemID.Text).ToString(NumFormat)
                        End If
                        Dim Main_Id As String = GetMainID(txtMemID.Text)
                        lblOpenBillString.Text = "Open Bill Amt."
                        lblBillAmtPerviousKOT.Text = ObjDatabase.ExecuteScalarS("Select isnull(sum(Amount),0) from FB_BillHead H where H.BillDate='" & lblBillDate.Text & "' and BillStatus=0 and MemberID like '" & Main_Id.Trim() & "%'")
                        EnableControl(PanelMemberDetails)
                        EnableControl(PanelItem)
                        BILL_TYPE = "SMARTCARD"
                        lblValidationMode.Text = BILL_TYPE
                        btnSendOTP.Text = "Send OTP"
                        btnSendOTP.Enabled = False
                        lblCardID.Text = MemberID

                        cmbLocation.Enabled = False
                        cmbTable.Enabled = False
                        PanelLocationAndTables.Visible = False
                        PanelItem.Enabled = True
                        PanelRight.Visible = True
                        If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True
                        btnShiftTable.Enabled = True
                        btnRefresh.Enabled = True
                        txtMemID.Enabled = False
                        cmbWaiter.SelectedValue = 0
                        cmbWaiter.Focus()
                    End If
                ElseIf BillNo > 0 And Val(lblIssueNo.Text) > 0 Then
                    DisplayMemberPics(txtMemID.Text)
                    ds = New DataSet
                    ds = GetSmartCardBalance(txtMemID.Text)
                    If ds.Tables(0).Rows.Count > 0 Then
                        MainID = ds.Tables(0).Rows(0)("MainID")
                        MemberName = ds.Tables(0).Rows(0)("MemberName")
                        IssueID = ds.Tables(0).Rows(0)("IssuedID")
                        IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                        ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                        lblMemberName.Text = MemberName
                        lblSmartCardOpeningBalance.Text = ClosingBalance
                        lblSmartCardClosingBalance.Text = ClosingBalance
                        lblIssueNo.Text = IssueNo
                        btnSettleBillHomePage.Enabled = True
                        btnSaveNSettle.Enabled = False
                    End If
                    lblMemberName.Text = ObjDatabase.ExecuteScalarS("Select MemberName from FB_BillHead BH where BH.BillNo=" & BillNo & " and BH.YearCode=" & YearCode & " and BH.LocationCode=" & LOCATION_Code)
                    txtPAX.Text = ObjDatabase.ExecuteScalarN("Select PAX from FB_BillHead where BillNo=" & BillNo & " and YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code)
                    BILL_TYPE = "SMARTCARD"
                    lblValidationMode.Text = "SMARTCARD"
                    btnSendOTP.Text = "Send OTP"
                    btnSendOTP.Enabled = False
                    lblCardID.Text = MemberID
                    EnableControl(PanelMemberDetails)
                    EnableControl(PanelItem)
                    cmbLocation.Enabled = False
                    cmbTable.Enabled = False
                    PanelLocationAndTables.Visible = False
                    PanelItem.Enabled = True
                    PanelRight.Visible = True
                    If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True
                    btnShiftTable.Enabled = True
                    btnRefresh.Enabled = True
                    txtMemID.Enabled = False
                    cmbTable.Enabled = False
                    txtItemCode.Focus()
                    ControlAccess()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        ValidateWholeNumberInput(sender, e)
    End Sub

    Private Sub txtQty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.Validated
        If Val(txtQty.Text) > 0 Then
            If cmbItemName.SelectedValue = 0 Then
                Message = "Select Item"
                cmbItemName.Focus()
                Exit Sub
            End If
            If Val(txtQty.Text) = 0 Then
                Message = "Enter Qty"
                txtQty.Focus()
                Exit Sub
            End If
            AddItemToGrid(Val(cmbItemName.SelectedValue), Val(txtQty.Text), Val(txtRate.Text))
            cmbItemName.SelectedValue = 0
            txtQty.Text = ""
            txtItemCode.Text = ""
            txtItemCode.Focus()
            lblUnit.Text = ""
        End If
    End Sub

    Private Sub btnSaveNSettle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNSettle.Click
        If validation() = False Then Exit Sub
        EnableDiscount()
        lblBillSettlementHeader.Text = "SETTLE BILL"
        btnSettleBill.Tag = "SAVE N SETTLE"
        PanelClosedBills.Visible = False
        PanelSettleBill.Visible = True
        PanelSettleBill.Location = LeftPanelLocation
        lblBillSettlementHeader.BackColor = Color.Teal
        lblBillSettlementHeader.ForeColor = Color.White
        btnSettleBillHomePage.Enabled = False
        GetFinalBillAmount()

        If BILL_TYPE = "SMARTCARD" Then
            MemberID = Trim(RFIDMemberID)
            If txtMemID.Text <> MemberID Then
                MsgBox("Card_ID and Bill Mem_ID don't match", MsgBoxStyle.Critical)
                Exit Sub
            End If
            ReturnValue = ValidateMemberCard(CardSerialNo, MemberID)
            Select Case ReturnValue
                Case 101
                    MsgBox("Invalid Card. Card does not exist in the Card issued database", MsgBoxStyle.Critical)
                    Exit Sub
                Case 102
                    MsgBox("Member status is not allowed for transaction", MsgBoxStyle.Critical)
                    Exit Sub
                Case 103
                    MsgBox("Card is not Active for Transactions", MsgBoxStyle.Critical)
                    Exit Sub
                Case 100
                    txtMemID.Text = MemberID
                    DisplayMemberPics(txtMemID.Text)
                    ds = New DataSet
                    ds = GetSmartCardBalance(txtMemID.Text)
                    If ds.Tables(0).Rows.Count > 0 Then
                        MainID = ds.Tables(0).Rows(0)("MainID")
                        MemberName = ds.Tables(0).Rows(0)("MemberName")
                        IssueID = ds.Tables(0).Rows(0)("IssuedID")
                        IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                        ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                        lblMemberName.Text = MemberName
                        lblSmartCardOpeningBalance.Text = ClosingBalance
                        lblSmartCardClosingBalance.Text = Val(ClosingBalance - Val(lblGrossAmt.Text)).ToString("###0.00")
                        lblIssueNo.Text = IssueNo
                    End If
            End Select
        ElseIf BILL_TYPE = "OTP" Then
            MemberID = txtMemID.Text
            MainID = txtMemID.Text
            txtMemID.Text = MemberID
            DisplayMemberPics(txtMemID.Text)
            ds = New DataSet
            ds = GetSmartCardBalance(txtMemID.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                MainID = ds.Tables(0).Rows(0)("MainID")
                MemberName = ds.Tables(0).Rows(0)("MemberName")
                IssueID = ds.Tables(0).Rows(0)("IssuedID")
                IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                lblMemberName.Text = MemberName
                lblSmartCardOpeningBalance.Text = ClosingBalance
                lblSmartCardClosingBalance.Text = Val(ClosingBalance - Val(lblGrossAmt.Text)).ToString("###0.00")
                lblIssueNo.Text = IssueNo
            End If
        End If
        btnModifyKOT.Enabled = False
        btnShowTables.Enabled = False
        BillingMode = GetBillingMode(txtMemID.Text)
        ObjDatabase.ConnectDatabse()
        ObjDatabase.OpenDatabaseConnection()
        myTrans = ObjDatabase.con.BeginTransaction()
        myCommand = New SqlCommand
        myCommand = ObjDatabase.con.CreateCommand()
        myCommand.Transaction = myTrans
        KOTNo = 0 : BillNo = 0

        StrSql = "Select IsNull(Max(KOTNo),0) + 1 From FB_KOTHead where YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code
        myCommand.CommandText = StrSql
        KOTNo = myCommand.ExecuteScalar

        StrSql = "Select IsNull(Max(BillNo),0) + 1 From FB_BillHead where YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code
        myCommand.CommandText = StrSql
        BillNo = myCommand.ExecuteScalar

        TableCode = cmbTable.SelectedValue
        lblKOTNo.Text = KOTNo
        lblBillNo.Text = BillNo
        Try
            StrSql = "INSERT INTO [FB_KOTHead]" & _
                "([KOTNo]" & _
                ",[KOTDate]" & _
                ",[MemberID]" & _
                ",[IssueNo]" & _
                ",[WaiterCode]" & _
                ",[TableCode]" & _
                ",[PAX]" & _
                ",[RefNo]" & _
                ",[ModeOfPayment]" & _
                ",[OpeningBalance]" & _
                ",[ClosingBalance]" & _
                ",[CreationDate]" & _
                ",[ModificationDate]" & _
                ",[UserCode]" & _
                ",[LocationCode]" & _
                ",[YearCode]" & _
                ")" & _
                " VALUES" & _
                "(" & _
                Val(lblKOTNo.Text) & _
                ",'" & Format(CDate(lblBillDate.Text), "dd/MMM/yyyy") & "'" & _
                ",'" & Trim(txtMemID.Text) & "'" & _
                "," & IIf(BillingMode = "Single", Val(lblIssueNo.Text), 0) & _
                "," & Val(cmbWaiter.SelectedValue) & _
                "," & Val(cmbTable.SelectedValue) & _
                "," & Val(txtPAX.Text) & _
                "," & Val(txtRefNo.Text) & "" & _
                ",'" & IIf(BillingMode = "Single", "SmartCard", "") & "'" & _
                "," & Val(lblSmartCardOpeningBalance.Text) & _
                "," & Val(lblSmartCardClosingBalance.Text) & _
                ",getdate()" & _
                ",getdate()" & _
                "," & Val(UserCode) & _
                "," & LOCATION_Code & _
                "," & YearCode & _
                ")"
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            For ictr = 0 To dtKOTItems.Rows.Count - 1
                If Val(dtKOTItems.Rows(ictr)("ItemCode")) > 0 And Val(dtKOTItems.Rows(ictr)("Qty")) > 0 Then
                    StrSql = "INSERT INTO FB_KOTBody " & _
                    "([KOTNo]" & _
                    ",[ItemCode]" & _
                    ",[ItemName]" & _
                    ",[OpenItem]" & _
                    ",[UnitCode]" & _
                    ",[Qty]" & _
                    ",[ActualQty]" & _
                    ",[Rate]" & _
                    ",[SchemeRate]" & _
                    ",[Amount]" & _
                    ",[DiscountPer]" & _
                    ",[TaxType]" & _
                    ",[TaxPer]" & _
                    ",[SCPer]" & _
                    ",[CreationDate]" & _
                    ",[ModificationDate]" & _
                    ",[UserCode]" & _
                    ",[LocationCode]" & _
                    ",[YearCode]" & _
                    ")" & _
                    " select " & Val(lblKOTNo.Text) & _
                    "," & Val(dtKOTItems.Rows(ictr)("ItemCode")) & _
                    ",'" & Trim(dtKOTItems.Rows(ictr)("ItemName")) & "'" & _
                    "," & Val(dtKOTItems.Rows(ictr)("OpenItem")) & _
                    "," & Val(dtKOTItems.Rows(ictr)("UnitCode")) & _
                    "," & Val(dtKOTItems.Rows(ictr)("Qty")) & _
                    "," & Val(dtKOTItems.Rows(ictr)("Qty")) & _
                    "," & Val(dtKOTItems.Rows(ictr)("Rate")) & _
                    "," & Val(dtKOTItems.Rows(ictr)("Rate")) & _
                    "," & Val(dtKOTItems.Rows(ictr)("Qty") * Val(dtKOTItems.Rows(ictr)("Rate"))) & _
                    "," & Val(dtKOTItems.Rows(ictr)("DiscountPer")) & _
                    ",'" & Trim(dtKOTItems.Rows(ictr)("TaxType")) & "'" & _
                    "," & Val(dtKOTItems.Rows(ictr)("TaxPer")) & _
                    "," & Val(dtKOTItems.Rows(ictr)("SCPer")) & _
                    ",getdate()" & _
                    ",getdate()" & _
                    "," & UserCode & _
                    "," & LOCATION_Code & _
                    "," & YearCode
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()
                End If
            Next ictr

            lblBillNo.Text = BillNo
            StrSql = "INSERT INTO [FB_BillHead]" & _
            "([BillNo]" & _
            ",[BillDate]" & _
            ",[MemberID]" & _
            ",[MemberName]" & _
            ",[WaiterCode]" & _
            ",[TableCode]" & _
            ",[BookingNo]" & _
            ",[RoomCode]" & _
            ",[IssueNo]" & _
            ",[PAX]" & _
            ",[BillStatus]" & _
            ",[BillType]" & _
            ",[Amount]" & _
            ",[RoundOff]" & _
            ",[ModeOfPayment]" & _
            ",[RefNo]" & _
            ",[RefDate]" & _
            ",[ValidationMode]" & _
            ",[Remarks]" & _
            ",[OpeningBalance]" & _
            ",[ClosingBalance]" & _
            ",[CreationDate]" & _
            ",[ModificationDate]" & _
            ",[UserCode]" & _
            ",[LocationCode]" & _
            ",[YearCode])" & _
            " VALUES" & _
            "(" & Val(lblBillNo.Text) & _
            ",'" & Format(CDate(lblBillDate.Text), "dd/MMM/yyyy") & "'" & _
            ",'" & Trim(txtMemID.Text) & "'" & _
            ",'" & Trim(lblMemberName.Text) & "'" & _
            "," & Val(cmbWaiter.SelectedValue) & "" & _
            "," & Val(cmbTable.SelectedValue) & _
            ",0" & _
            ",0" & _
            "," & IIf(BillingMode = "Single", Val(lblIssueNo.Text), 0) & _
            "," & Val(txtPAX.Text) & _
            ",0" & _
            "," & BillType & _
            "," & Val(lblGrossAmt.Text) & _
            "," & Val(lblRoundOff.Text) & _
            ",'" & IIf(BillingMode = "Single", "SmartCard", "") & "'" & _
            ",'" & txtRefNo.Text & "'" & _
            ",'" & Format(CDate(lblBillDate.Text), "dd/MMM/yyyy") & "'" & _
            ",'" & lblValidationMode.Text & "'" & _
            ",''" & _
            "," & Val(lblSmartCardOpeningBalance.Text) & _
            "," & Val(lblSmartCardClosingBalance.Text) & _
            ",getdate()" & _
            ",getdate()" & _
            "," & UserCode & _
            "," & LOCATION_Code & _
            "," & YearCode & _
            ")"
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            StrSql = "INSERT INTO [FB_BillBody]" & _
            "([BillNo]" & _
            ",[KOTNo]" & _
            ",[CreationDate]" & _
            ",[ModificationDate]" & _
            ",[UserCode]" & _
            ",[LocationCode]" & _
            ",[YearCode])" & _
            " VALUES (" & _
            Val(lblBillNo.Text) & _
            "," & Val(lblKOTNo.Text) & _
            ",getdate()" & _
            ",getdate()" & _
            "," & UserCode & _
            "," & LOCATION_Code & _
            "," & YearCode & _
            ")"
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            AmtAfterRoundOff = 0 : RoundOff = 0 : AmtBeforeRoundOff = 0 : KOTStr = ""

            StrSql = "SELECT  STUFF((SELECT  ',' + CONVERT(VARCHAR(max),KOTNo)" & _
            " FROM FB_BillBody where BillNo=" & Val(lblBillNo.Text) & " and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code) & " FOR XML PATH('')), 1, 1, '') AS KOTNos"
            myCommand.CommandText = StrSql
            KOTStr = myCommand.ExecuteScalar()

            StrSql = "SELECT  sum(Qty*Rate*(100-DiscountPer)*0.01 + Qty*Rate*(100-DiscountPer)*0.01*TaxPer*0.01 + Qty*Rate*(100-DiscountPer)*0.01*SCPer*0.01) as BillAmount" & _
            " FROM FB_KOTBody where KOTNo in(" & KOTStr & ") and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code)
            myCommand.CommandText = StrSql

            AmtBeforeRoundOff = myCommand.ExecuteScalar()
            AmtAfterRoundOff = Math.Round(AmtBeforeRoundOff + 0.01, 0)
            RoundOff = Math.Round(AmtAfterRoundOff - AmtBeforeRoundOff, 2)

            StrSql = "UPDATE FB_BillHead SET Amount=" & AmtAfterRoundOff & ",RoundOff=" & RoundOff & ",ClosingBalance=OpeningBalance-" & AmtAfterRoundOff & _
            " WHERE BillNo=" & Val(lblBillNo.Text) & " and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code)
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            myTrans.Commit()

        Catch ex As Exception
            MsgBox("Error" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            myTrans.Rollback()
        End Try
        If BillingMode = "Single" Then
            BindComboboxWithSelectOneNumeric("select MP.Code,MP.ModeDesc from AC_ModeOfPayment MP,FB_PaymentModes FBP where MP.Status='Active' AND MP.ModeDesc='SmartCard' and MP.Code=FBP.PayModeCode and FBP.LocationCode=" & LOCATION_Code, "Code", "ModeDesc", cmbModeOfPayment)
            cmbModeOfPayment.Text = "SMARTCARD"
            cmbModeOfPayment.Enabled = False
            labelBillPayModeOpeningStr.Text = "OPENING CARD BALANCE"
            labelBillPayModeClosingStr.Text = "CLOSING CARD BALANCE"
            labelBillPayModeOpeningAmount.Text = Val(lblSmartCardOpeningBalance.Text).ToString("###0.00")
            labelBillPayModeClosingAmount.Text = Val(lblSmartCardClosingBalance.Text).ToString("###0.00")
            labelBillPayModeOpeningStr.Text = lblBillingSmartCardOpeningStr.Text
            labelBillPayModeClosingStr.Text = lblBillingSmartCardClosingStr.Text
        Else
            SelectedTableName = cmbTable.Text.ToUpper
            If lblValidationMode.Text = "MC" And (SelectedTableName.Contains("TAKEAWAY") Or SelectedTableName.Contains("HOME DELIVERY")) Then
                BindComboboxWithSelectOneNumeric("select MP.Code,MP.ModeDesc from AC_ModeOfPayment MP,FB_PaymentModes FBP where MP.Status='Active' AND MP.ModeDesc not in('SmartCard','Member A/c') and MP.Code=FBP.PayModeCode and FBP.LocationCode=" & LOCATION_Code, "Code", "ModeDesc", cmbModeOfPayment)
            ElseIf lblValidationMode.Text = "MC" And Not (SelectedTableName.Contains("TAKEAWAY") Or SelectedTableName.Contains("HOME DELIVERY")) Then
                BindComboboxWithSelectOneNumeric("select MP.Code,MP.ModeDesc from AC_ModeOfPayment MP,FB_PaymentModes FBP where MP.Status='Active' AND MP.ModeDesc not in('SmartCard','Cash') and MP.Code=FBP.PayModeCode and FBP.LocationCode=" & LOCATION_Code, "Code", "ModeDesc", cmbModeOfPayment)
            Else
                BindComboboxWithSelectOneNumeric("select MP.Code,MP.ModeDesc from AC_ModeOfPayment MP,FB_PaymentModes FBP where MP.Status='Active' AND MP.ModeDesc not in('Cash') and MP.Code=FBP.PayModeCode and FBP.LocationCode=" & LOCATION_Code, "Code", "ModeDesc", cmbModeOfPayment)
            End If
            cmbModeOfPayment.SelectedValue = 0
            cmbModeOfPayment.Enabled = True
            btnSaveNSettle.Enabled = False
            labelBillPayModeOpeningAmount.Text = "0.00"
            labelBillPayModeClosingAmount.Text = "0.00"
            labelBillPayModeOpeningStr.Text = "0.00"
            labelBillPayModeClosingStr.Text = "0.00"
            cmbModeOfPayment.Focus()
        End If
        btnSaveNSettle.Enabled = False
        btnSettleBill.Enabled = True
        btnCancelBill.Enabled = True
        btnSettleBill.BackColor = Color.DarkTurquoise
        btnCancelBill.BackColor = Color.Tomato
        EnableDiscount()
    End Sub

    Private Sub btnDraftBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettleBillHomePage.Click
        If btnSettleBillHomePage.Text = "SETTLE BILL" Then
            EnableDiscount()
            lblBillSettlementHeader.Text = "SETTLE BILL"
            BindItemGridForSettlement(lblBillNo.Text)
            btnSettleBillHomePage.Text = "SETTLE BILL"
            btnShowTables.Enabled = False
            btnSaveNSettle.Enabled = False
            ObjDatabase.ConnectDatabse()

            Temp_WaiterCode = ObjDatabase.ExecuteScalarN("Select WaiterCode from FB_BillHead where BillNo=" & Val(lblBillNo.Text) & " and LocationCode=" & LOCATION_Code & " and YearCode=" & YearCode)
            cmbWaiter.SelectedValue = Temp_WaiterCode
            Temp_BillingMode = ObjDatabase.ExecuteScalar("Select ValidationMode from FB_BillHead where BillNo=" & Val(lblBillNo.Text) & " and LocationCode=" & LOCATION_Code & " and YearCode=" & YearCode)
            Temp_TableCode = ObjDatabase.ExecuteScalarN("Select TableCode from FB_BillHead where BillNo=" & Val(lblBillNo.Text) & " and LocationCode=" & LOCATION_Code & " and YearCode=" & YearCode)
            BindComboboxWithoutSelectOneNumeric("select Code,TableNo from FB_TableMaster", "Code", "TableNo", cmbTable)
            cmbTable.SelectedValue = Temp_TableCode
            lblValidationMode.Text = Temp_BillingMode
            If lblValidationMode.Text.ToUpper = "SMARTCARD" Then
                MemberID = txtMemID.Text
                btnSendOTP.Text = "Send OTP"
            ElseIf lblValidationMode.Text.ToUpper = "MC" Then
                MemberID = txtMemID.Text
                btnSendOTP.Text = "Send OTP"
            ElseIf lblValidationMode.Text.ToUpper = "OTP" Then
                MemberID = txtMemID.Text
                btnSendOTP.Text = "OTP Verified"
            End If

            BillingMode = GetBillingMode(txtMemID.Text)
            If BillingMode = "Single" Then
                BindComboboxWithSelectOneNumeric("select MP.Code,MP.ModeDesc from AC_ModeOfPayment MP,FB_PaymentModes FBP where MP.Status='Active' AND MP.ModeDesc='SmartCard' and MP.Code=FBP.PayModeCode and FBP.LocationCode=" & LOCATION_Code, "Code", "ModeDesc", cmbModeOfPayment)
                cmbModeOfPayment.Text = "SMARTCARD"
                ds = New DataSet
                ds = GetSmartCardBalance(txtMemID.Text)
                If ds.Tables(0).Rows.Count > 0 Then
                    MainID = ds.Tables(0).Rows(0)("MainID")
                    MemberName = ds.Tables(0).Rows(0)("MemberName")
                    IssueID = ds.Tables(0).Rows(0)("IssuedID")
                    IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                    ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                    lblMemberName.Text = MemberName
                    lblSmartCardOpeningBalance.Text = ClosingBalance
                    lblSmartCardClosingBalance.Text = ClosingBalance
                    lblIssueNo.Text = IssueNo
                End If
                RecCount = ObjDatabase.ExecuteScalarN("Select Count(IssueNo) from FB_BillHead where BillNo=" & Val(lblBillNo.Text) & " and LocationCode=" & LOCATION_Code & " and YearCode=" & YearCode & " and IssueNo>0")
                If RecCount = 0 Then
                    labelBillPayModeOpeningAmount.Text = Val(ClosingBalance).ToString("###0.00")
                    labelBillPayModeClosingAmount.Text = Val(Val(ClosingBalance) - Val(labelBillGrossAmount.Text)).ToString("###0.00")
                Else
                    labelBillPayModeOpeningAmount.Text = (Val(ClosingBalance) + Val(labelBillGrossAmount.Text)).ToString("###0.00")
                    labelBillPayModeClosingAmount.Text = Val(Val(ClosingBalance).ToString("###0.00")).ToString(NumFormat)
                End If

                cmbModeOfPayment.Enabled = False
                labelBillPayModeOpeningStr.Text = "OPENING CARD BALANCE"
                labelBillPayModeClosingStr.Text = "CLOSING CARD BALANCE"
                lblSmartCardOpeningBalance.Text = labelBillPayModeOpeningAmount.Text
                lblSmartCardClosingBalance.Text = labelBillPayModeClosingAmount.Text
                cmbModeOfPayment.Text = "SmartCard"
                btnSettleBill.Focus()
            Else
                SelectedTableName = cmbTable.Text
                If lblValidationMode.Text = "MC" And (SelectedTableName.Contains("TAKEAWAY") Or SelectedTableName.Contains("HOME DELIVERY") Or SelectedTableName.Contains("PACKING")) Then
                    BindComboboxWithSelectOneNumeric("select MP.Code,MP.ModeDesc from AC_ModeOfPayment MP,FB_PaymentModes FBP where MP.Status='Active' AND MP.ModeDesc not in('SmartCard','Member A/c') and MP.Code=FBP.PayModeCode and FBP.LocationCode=" & LOCATION_Code, "Code", "ModeDesc", cmbModeOfPayment)
                ElseIf lblValidationMode.Text = "MC" And Not (SelectedTableName.Contains("TAKEAWAY") Or SelectedTableName.Contains("HOME DELIVERY") Or SelectedTableName.Contains("PACKING")) Then
                    BindComboboxWithSelectOneNumeric("select MP.Code,MP.ModeDesc from AC_ModeOfPayment MP,FB_PaymentModes FBP where MP.Status='Active' AND MP.ModeDesc not in('SmartCard','Cash') and MP.Code=FBP.PayModeCode and FBP.LocationCode=" & LOCATION_Code, "Code", "ModeDesc", cmbModeOfPayment)
                Else
                    BindComboboxWithSelectOneNumeric("select MP.Code,MP.ModeDesc from AC_ModeOfPayment MP,FB_PaymentModes FBP where MP.Status='Active' AND MP.ModeDesc not in('Cash') and MP.Code=FBP.PayModeCode and FBP.LocationCode=" & LOCATION_Code, "Code", "ModeDesc", cmbModeOfPayment)
                End If
                cmbModeOfPayment.SelectedValue = 0
                cmbModeOfPayment.Enabled = True
                btnSaveNSettle.Enabled = False
                labelBillPayModeOpeningAmount.Text = "0.00"
                labelBillPayModeClosingAmount.Text = "0.00"
                labelBillPayModeOpeningStr.Text = "0.00"
                labelBillPayModeClosingStr.Text = "0.00"
                labelBillPayModeOpeningStr.Text = "NA"
                labelBillPayModeClosingStr.Text = "NA"
                cmbModeOfPayment.Text = "SmartCard"
                cmbModeOfPayment.Focus()
            End If
            PanelClosedBills.Visible = False
            PanelSettleBill.Visible = True
            PanelSettleBill.Location = LeftPanelLocation
            lblBillSettlementHeader.BackColor = Color.Teal
            lblBillSettlementHeader.ForeColor = Color.White
            btnSettleBillHomePage.Enabled = False
            GetFinalBillAmount()
            btnSettleBill.Tag = "SETTLE BILL"
            btnShowTables.Enabled = False
            btnSettleBill.Enabled = True
            btnCancelBill.Enabled = True
            btnSettleBill.BackColor = Color.DarkTurquoise
            btnCancelBill.BackColor = Color.Tomato
            btnRefresh.Enabled = True
            EnableDiscount()
            cmbModeOfPayment.Focus()
        End If
    End Sub

    Private Sub EnableDiscount()

        If NonAlcoholicItemGroup = "" Then txtDiscNonAlcoholicPer.Enabled = False Else txtDiscNonAlcoholicPer.Enabled = True
        If AlcoholicItemGroup = "" Then txtDiscAlcoholicPer.Enabled = False Else txtDiscAlcoholicPer.Enabled = True
        If FoodItemGroup = "" Then txtDiscFoodPer.Enabled = False Else txtDiscFoodPer.Enabled = True

        If NonAlcoholicItemGroup = "" Then txtDiscNonAlcoholicAmt.Enabled = False Else txtDiscNonAlcoholicAmt.Enabled = True
        If AlcoholicItemGroup = "" Then txtDiscAlcoholicAmt.Enabled = False Else txtDiscAlcoholicAmt.Enabled = True
        If FoodItemGroup = "" Then txtDiscFoodAmt.Enabled = False Else txtDiscFoodAmt.Enabled = True

        lblCitizenType.Text = GetCitizenType(txtMemID.Text)
    End Sub

    Private Sub btnPrintDuplicateBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDuplicateBill.Click
        'CrystalReportViewer2.PrintReport()
    End Sub

    Private Sub btnCloseView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseView.Click
        PanelRight.Visible = True
        PanelDisplayBill.Visible = False
        PanelRight.Location = RightPanelLocation
    End Sub

    Private Sub btnShiftTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftTable.Click
        If btnShiftTable.Text = "SHIFT TABLE" Then
            Message = "Select Table No to move to"
            TableCounter = 0
            btnBillingLocation1.Tag = 0
            btnBillingLocation2.Tag = 0
            btnBillingLocation3.Tag = 0
            btnBillingLocation4.Tag = 0
            btnBillingLocation5.Tag = 0
            btnBillingLocation6.Tag = 0
            btnBillingLocation7.Tag = 0
            btnBillingLocation8.Tag = 0
            btnShiftTable.Text = "SAVE TABLE"
            PanelLocationTables.Tag = "MoveTableLocation"
            PanelTables.Tag = "MoveTable"
            ResetTables()
            dsTable = PopulateTables(LOCATION_Code, Val(cmbLocation.SelectedValue), 0)
            PopulateTableNoWithStatus()
            'PopulateLocationButtons()
            PanelLocationAndTables.Location = RightPanelLocation
            PanelLocationAndTables.Visible = True
            PanelRight.Visible = False
            btnSettleBillHomePage.Enabled = False
            btnModifyKOT.Enabled = False
        ElseIf btnShiftTable.Text = "SAVE TABLE" Then
            If cmbTable.SelectedValue > 0 Then
                ObjDatabase.ConnectDatabse()
                StrSql = "UPDATE FB_BillHead Set TableCode=" & Val(cmbTable.SelectedValue) & " where BillNo=" & Val(lblBillNo.Text) & " and LocationCode=" & LOCATION_Code & " and YearCode=" & YearCode
                ObjDatabase.ExecuteNonQuery(StrSql)
                Message = "Table Shifted successfully"
                ClearControlsAfterCheckSave()
            End If
        End If
    End Sub

    Private Sub dgKOTItemList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKOTItemList.CellContentClick
        If e.ColumnIndex = 0 Then
            lblActualQty.Text = dgKOTItemList.Rows(e.RowIndex).Cells("OriginalQty").Value()
            lblModifiedQty.Text = dgKOTItemList.Rows(e.RowIndex).Cells("ModifiedQty").Value()
        End If
    End Sub

    Private Sub btnModifyKOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifyKOT.Click
        If btnModifyKOT.Text = "MODIFY KOT" Then
            PanelModifyKOT.Visible = True
            PanelModifyKOT.Location = RightPanelLocation
            PanelRight.Visible = False
            labelKOTModificationHeader.Text = "KOT belonging to the Table No. " & cmbTable.Text & "; Bill No: " & Val(lblBillNo.Text)
            If dgHistory.Tag = "OpenBills" Then
                lblBillNo.Text = lblBillNo.Text
                lblLocationCode_KOTModify.Text = cmbLocation.SelectedValue
                lblYearCode_KOTModify.Text = YearCode
            End If
            BindKOTNosForModification()
            BindKOTModifyItemDetails(0, 0, 0)
            btnModifyKOT.Text = "SAVE KOT"
            lblBillNo.Text = Val(lblBillNo.Text)
            lblActualQty.Text = ""
            lblModifiedQty.Text = ""
            cmbKOTRemarks.Text = "[Select One]"
            cmbKOTRemarks.Enabled = True
            btnShowTables.Enabled = False
            btnSaveNSettle.Enabled = False
            btnSettleBillHomePage.Enabled = False
            btnShiftTable.Enabled = False
        ElseIf btnModifyKOT.Text = "SAVE KOT" Then
            _ValidationMode = ObjDatabase.ExecuteScalar("SELECT ValidationMode from FB_BillHead Where BillNo=" & Val(lblBillNo.Text) & " and YearCode=" & YearCode & " and LocationCode=" & cmbLocation.SelectedValue)
            If _ValidationMode.ToUpper <> "MC" Then
                MemberID = Trim(RFIDMemberID)
                txtMemID.Text = MemberID.Trim()
                ReturnValue = 0
                If txtMemID.Text = "" Then
                    MsgBox("Unable to detect SmartCard on the card reader", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                ReturnValue = ValidateMemberCard(CardSerialNo, MemberID)
                Select Case ReturnValue
                    Case 101
                        MsgBox("Invalid Card. Card does not exist in the Card issued database", MsgBoxStyle.Critical)
                        Exit Sub
                    Case 102
                        MsgBox("Member status is not allowed for transaction", MsgBoxStyle.Critical)
                        Exit Sub
                End Select
                If lblMemID.Text.Trim() <> txtMemID.Text.Trim() Then
                    MsgBox("Billed Card ID and current Card_ID dont match.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            Dim [ModificationNo] As Integer = 0
            ErrorProvider1.Dispose()
            If Val(lblReducedKOTAmt.Text) > 0 Then
                If cmbKOTRemarks.SelectedValue = 0 Then
                    Message = "Select KOT Modification Remarks"
                    cmbKOTRemarks.Focus()
                    Exit Sub
                End If
                ObjDatabase.ConnectDatabse()
                ObjDatabase.OpenDatabaseConnection()
                myTrans = ObjDatabase.con.BeginTransaction()
                myCommand = New SqlCommand
                myCommand = ObjDatabase.con.CreateCommand()
                myCommand.Transaction = myTrans
                Try
                    StrSql = "SELECT isnull(MAX([ModificationNo]),0)+1 FROM [FB_DuplicateKOTHead_1]"
                    myCommand.CommandText = StrSql
                    [ModificationNo] = myCommand.ExecuteScalar

                    StrSql = "INSERT INTO [FB_DuplicateKOTHead_1] " & _
                    "SELECT " & [ModificationNo] & "," & UserCode & " as ModifiedBy,getdate(),'" & cmbKOTRemarks.Text & "'" & _
                    ",*,'" & HOST_NAME & "','" & HOST_IP_ADDRESS & "'" & _
                    " from FB_KOTHead where YearCode=" & Val(lblYearCode_KOTModify.Text) & " and LocationCode=" & Val(lblLocationCode_KOTModify.Text) & " and KOTNo=" & Val(lblKOTNo_KOTModify.Text)
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()

                    StrSql = "INSERT INTO [FB_DuplicateKOTBody_1] " & _
                    "SELECT " & [ModificationNo] & " as [ModificationNo],*" & _
                    " from FB_KOTBody" & _
                    " where YearCode=" & Val(lblYearCode_KOTModify.Text) & " and LocationCode=" & Val(lblLocationCode_KOTModify.Text) & " and KOTNo=" & Val(lblKOTNo_KOTModify.Text)
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()

                    For i As Integer = 0 To dtKOTItems.Rows.Count - 1
                        Qty = dtKOTItems.Rows(i)("ModifiedQty")
                        ItemCode = dtKOTItems.Rows(i)("Code")
                        StrSql = "UPDATE FB_KOTBody SET Qty=" & Qty & " where YearCode=" & Val(lblYearCode_KOTModify.Text) & " and LocationCode=" & Val(lblLocationCode_KOTModify.Text) & " and KOTNo=" & Val(lblKOTNo_KOTModify.Text) & " and ItemCode=" & ItemCode
                        myCommand.CommandText = StrSql
                        myCommand.ExecuteNonQuery()
                    Next

                    StrSql = "SELECT STUFF((SELECT ',' + CONVERT(VARCHAR(MAX),KOTNo) FROM FB_BillBody where BillNo=" & Val(lblBillNo.Text) & " and YearCode=" & Val(lblYearCode_KOTModify.Text) & " and LocationCode=" & Val(lblLocationCode_KOTModify.Text) & " FOR XML PATH('')), 1, 1, '') AS KOTNos"
                    myCommand.CommandText = StrSql
                    KOTStr = myCommand.ExecuteScalar()

                    StrSql = "SELECT sum((Qty*Rate)*(100-DiscountPer)*0.01+((Qty*Rate)*(100-DiscountPer)*0.01)*TaxPer*0.01+((Qty*Rate)*(100-DiscountPer)*0.01)*SCPer*0.01) as BillAmount" & _
                    " FROM FB_KOTBody where KOTNo in(" & KOTStr & ") and YearCode=" & Val(lblYearCode_KOTModify.Text) & " and LocationCode=" & Val(lblLocationCode_KOTModify.Text)
                    myCommand.CommandText = StrSql
                    AmtBeforeRoundOff = myCommand.ExecuteScalar()
                    AmtAfterRoundOff = Math.Round(AmtBeforeRoundOff + 0.01, 0)
                    RoundOff = Math.Round(AmtAfterRoundOff - AmtBeforeRoundOff, 2)

                    StrSql = "UPDATE [FB_BillHead]" & _
                    " SET [Amount]=" & AmtAfterRoundOff & _
                    ",[PAX]=" & Val(txtPAX.Text) & _
                    ",[ClosingBalance]=[OpeningBalance]-" & Val(AmtAfterRoundOff) & _
                    ",[RoundOff]=" & Math.Round(RoundOff, 2) & _
                    " where BillNo=" & Val(lblBillNo.Text) & " and YearCode=" & Val(lblYearCode_KOTModify.Text) & " and LocationCode=" & Val(lblLocationCode_KOTModify.Text)
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()

                    StrSql = "INSERT INTO [FB_DuplicateKOTHead_2] " & _
                    "SELECT " & [ModificationNo] & "," & UserCode & " as ModifiedBy,getdate(),'" & cmbKOTRemarks.Text & "'" & _
                    ",*,'" & HOST_NAME & "','" & HOST_IP_ADDRESS & "'" & _
                    " from FB_KOTHead where YearCode=" & Val(lblYearCode_KOTModify.Text) & " and LocationCode=" & Val(lblLocationCode_KOTModify.Text) & " and KOTNo=" & Val(lblKOTNo_KOTModify.Text)
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()

                    StrSql = "INSERT INTO [FB_DuplicateKOTBody_2] " & _
                    "SELECT " & [ModificationNo] & " as [ModificationNo],*" & _
                    " from FB_KOTBody" & _
                    " where YearCode=" & Val(lblYearCode_KOTModify.Text) & " and LocationCode=" & Val(lblLocationCode_KOTModify.Text) & " and KOTNo=" & Val(lblKOTNo_KOTModify.Text)
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()

                    myTrans.Commit()
                    UpdateOpeningAndClosingBalance(lblMemID.Text, CDate(lblBillDate.Text).ToString("dd/MMM/yyyy"), AmtAfterRoundOff, Val(lblBillNo.Text), Val(lblLocationCode_KOTModify.Text), Val(lblYearCode_KOTModify.Text), "N")
                    Message = "KOT Modified successfully"
                    MsgBox(Message, MsgBoxStyle.Information)
                    SEND_SMS_ALERT_MODIFY_BILL(lblMemID.Text, Val(lblReducedKOTAmt.Text), "SmartCard", Val(lblBillNo.Text))
                    'PrintWindowsPOSBillThermal(Val(lblBillNo.Text), 1, Val(lblLocationCode_KOTModify.Text), "AMENDED BILL")
                    ClearControlsAfterCheckSave()
                Catch ex As Exception
                    myTrans.Rollback()
                End Try
            Else
                ErrorProvider1.SetError(lblReducedKOTQty, "Modified Qty should be more than ZERO")
            End If
        End If
    End Sub

    Public Sub UpdateOpeningAndClosingBalance(ByVal MemberID As String, ByVal BillDate As Date, ByVal AmtAfterRoundOff As Double, ByVal _BillNo As Integer, ByVal _LocationCode As Integer, ByVal _YearCode As Integer, ByVal BillSettle As String)
        Dim ModeOpeningBalance, Temp_ModeOpeningBalance, OpenBillAmount, ModeClosingBalance As Double
        ModeOpeningBalance = GetSmartCardClosingBalance(MemberID)
        Dim ModeOfPayment As String = ""

        StrSql = "select MainID from MM_MemberInformation where Memberid='" & MemberID & "'"
        MainID = ObjDatabase.ExecuteScalarS(StrSql)

        StrSql = "SELECT isnull(ModeOfPayment,'') FROM FB_BillHead BH WHERE BH.BillNo=" & _BillNo & " and BH.YearCode=" & _YearCode & " and BH.LocationCode=" & _LocationCode
        ModeOfPayment = ObjDatabase.ExecuteScalar(StrSql)
        If ModeOfPayment = "" Then Exit Sub

        If ModeOfPayment = "SmartCard" Then
            ModeOpeningBalance = GetSmartCardClosingBalance(MemberID)
            StrSql = "SELECT ISNULL(sum(Amount),0) FROM FB_BillHead BH,MM_MemberInformation MI where BillDate='" & CDate(BillDate).ToString("dd/MMM/yyyy") & "' and BillStatus=0 and IssueNo>0 and BH.MemberID=MI.MemberID and MI.MainID='" & MainID & "'"
            OpenBillAmount = ObjDatabase.ExecuteScalarN(StrSql)
        ElseIf ModeOfPayment = "Member A/c" Then
            StrSql = "SELECT ISNULL(sum(Amount),0) FROM FB_BillHead BH,MM_MemberInformation MI where BillDate='" & CDate(BillDate).ToString("dd/MMM/yyyy") & "' and BillStatus=0 and IssueNo=0 and BH.MemberID=MI.MemberID and MI.MainID='" & MainID & "'"
            OpenBillAmount = ObjDatabase.ExecuteScalarN(StrSql)
            ModeOpeningBalance = Val(GetAvailableCreditLimit(txtMemID.Text))
        End If

        Temp_ModeOpeningBalance = ModeOpeningBalance
        ModeOpeningBalance = Temp_ModeOpeningBalance + OpenBillAmount
        ModeClosingBalance = Temp_ModeOpeningBalance + OpenBillAmount - AmtAfterRoundOff

        If BillSettle = "Y" Then
            StrSql = "UPDATE [FB_BillHead]" & _
            " SET [Amount]=" & AmtAfterRoundOff & _
            ",[BillStatus]=1" & _
            ",[OpeningBalance]=" & ModeOpeningBalance & _
            ",[ClosingBalance]=" & ModeClosingBalance & _
            ",[ModificationDate]=getdate()" & _
            " WHERE BillNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
            ObjDatabase.ExecuteNonQuery(StrSql)
        Else
            StrSql = "UPDATE [FB_BillHead]" & _
            " SET [Amount]=" & AmtAfterRoundOff & _
            ",[OpeningBalance]=" & ModeOpeningBalance & _
            ",[ClosingBalance]=" & ModeClosingBalance & _
            ",[ModificationDate]=getdate()" & _
            " WHERE BillNo=" & _BillNo & " and YearCode=" & _YearCode & " and LocationCode=" & _LocationCode
            ObjDatabase.ExecuteNonQuery(StrSql)
        End If
    End Sub

    Private Sub dgKOTList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKOTList.CellContentClick
        If e.ColumnIndex = 0 Then
            lblActualQty.Text = "0"
            lblModifiedQty.Text = "0"
            lblModifiedKOTAmt.Text = "0.00"
            lblModifiedQty.Text = "0.00"
            lblReducedKOTQty.Text = "0"
            lblReducedKOTAmt.Text = "0.00"
            KOTNo = dgKOTList.Rows(e.RowIndex).Cells("KOTNo").Value()
            _LocationCode = dgKOTList.Rows(e.RowIndex).Cells("LocationCode").Value()
            YearCode = dgKOTList.Rows(e.RowIndex).Cells("YearCode").Value()
            BindKOTModifyItemDetails(KOTNo, YearCode, _LocationCode)
            lblYearCode_KOTModify.Text = YearCode
            lblLocationCode_KOTModify.Text = _LocationCode
            lblKOTNo_KOTModify.Text = KOTNo
        End If
    End Sub

    Private Sub IncreaseDecreaseQtyForModifyKOT(ByVal Qty As Decimal)
        If dgKOTItemList.SelectedRows.Count > 0 Then
            UnitName = "" : ItemName = ""
            If dgKOTItemList.Rows.Count > 0 Then
                drKOTItems = dtKOTItems.Rows(dgKOTItemList.CurrentRow.Index)
                liNewQty = Qty
                If liNewQty < 0 Then
                    MsgBox("Billed Qty cannot be less than ZERO", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                ItemRate = drKOTItems.Item("Rate")
                DiscountPer = drKOTItems.Item("DiscountPer")
                Amount = Val(ItemRate) * liNewQty
                TaxPer = Val(drKOTItems.Item("TaxPer"))
                AmountAfterDiscount = Amount * (100 - DiscountPer) * 0.01
                TaxAmount = AmountAfterDiscount * TaxPer * 0.01
                TotalAmount = AmountAfterDiscount + TaxAmount

                drKOTItems.Item("ModifiedQty") = liNewQty
                drKOTItems.Item("Amount") = Amount
                drKOTItems.Item("TaxAmount") = TaxAmount
                drKOTItems.Item("GrossAmt") = TotalAmount
                dtKOTItems.AcceptChanges()
                dgKOTItemList.DataSource = dtKOTItems
                Me.ErrorProvider1.Dispose()
                dgKOTItemList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                GetKOTAmount()
            End If
        End If
    End Sub

    Private Sub ValidateKOTQty(ByVal ModifiedQty As Double)
        If Val(lblActualQty.Text) < ModifiedQty Then
            MsgBox("Modified Qty can not be mote than the actual Billed Qty", MsgBoxStyle.Critical)
            Exit Sub
        Else
            IncreaseDecreaseQtyForModifyKOT(ModifiedQty)
        End If
    End Sub

    Private Sub btnKOTCancellation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinus0.Click, btnMinus1.Click, btnMinus2.Click, btnMinus3.Click, btnMinus0.Click, btnMinus4.Click, btnMinus5.Click, btnMinus6.Click, btnMinus0.Click, btnMinus7.Click, btnMinus8.Click, btnMinus9.Click, btnMinus0.Click
        Dim SelectedButton As New Object
        If lblActualQty.Text = "" Then
            Message = "Select the Item from below grid to modify"
            dgKOTItemList.Focus()
        Else
            SelectedButton = CType(sender, Button)
            ValidateKOTQty(SelectedButton.Text)
        End If
    End Sub

    Public Sub GetKOTAmount()
        BillAmount = 0
        BillQty = 0
        Qty = 0 : Amount = 0 : TaxAmount = 0 : SCAmount = 0 : TotalAmt = 0 : DiscountAmt = 0
        RQty = 0 : RAmount = 0 : RGSTAmt = 0 : RSCAmt = 0 : RTotalAmt = 0 : RDiscountAmt = 0
        TaxAmount = 0 : RGSTAmt = 0
        VATAmt = 0 : RVATAmt = 0
        Dim dtKOTItems As DataTable
        dtKOTItems = New DataTable
        dtKOTItems = CType(dgKOTItemList.DataSource, DataTable)
        For ctr = 0 To dtKOTItems.Rows.Count - 1

            Rate = Val(dtKOTItems.Rows(ctr)("Rate"))
            Qty = Val(dtKOTItems.Rows(ctr)("ModifiedQty"))
            TaxPer = Val(dtKOTItems.Rows(ctr)("TaxPer"))
            RQty += Qty

            Amount = Rate * Qty
            RAmount += Amount

            RDiscountPer = Val(dtKOTItems.Rows(ctr)("DiscountPer"))
            AmtAfterDiscount = Amount * (100 - Val(RDiscountPer)) * 0.01
            RAmtAfterDiscount += AmtAfterDiscount

            DiscountAmt = Amount * Val(RDiscountPer) * 0.01
            RDiscountAmt += DiscountAmt
            If TaxPer = GB_VATPer Then
                VATAmt = (AmtAfterDiscount) * Val(dtKOTItems.Rows(ctr)("TaxPer")) * 0.01
                RVATAmt += VATAmt
                TaxAmount = 0
            Else
                VATAmt = 0
                TaxAmount = (AmtAfterDiscount) * Val(dtKOTItems.Rows(ctr)("TaxPer")) * 0.01
                RGSTAmt += TaxAmount
            End If

            SCAmount = (AmtAfterDiscount) * Val(dtKOTItems.Rows(ctr)("SCPer")) * 0.01
            RSCAmt += SCAmount


            TotalAmt = AmtAfterDiscount + TaxAmount + VATAmt + SCAmount
            RTotalAmt += TotalAmt

        Next ctr
        lblModifiedKOTQty.Text = RQty
        lblModifiedKOTAmt.Text = Format(Math.Round(RTotalAmt, 2), NumFormat)
        lblReducedKOTAmt.Text = Val(Val(lblTotalOriginalKOTAmt.Text) - Val(lblModifiedKOTAmt.Text)).ToString("###.00")
        lblReducedKOTQty.Text = Val(Val(lblTotalOriginalQty.Text) - Val(lblModifiedKOTQty.Text)).ToString("####0.00")
    End Sub

    Private Sub btnTableMoveRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTableMoveRight.Click
        Try
            ResetTables()
            For i As Integer = 0 To 38
                TableCounter = TableCounter + 1
                If TableCounter + 39 > dsTable.Tables(0).Rows.Count - 1 Then TableCounter = dsTable.Tables(0).Rows.Count - 39
                If TableCounter < 0 Then TableCounter = 0
                PopulateTableNoWithStatus()
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTableMoveLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTableMoveLeft.Click
        Try
            ResetTables()
            For i As Integer = 0 To 38
                TableCounter = TableCounter - 1
                If TableCounter < 0 Then TableCounter = 0
                PopulateTableNoWithStatus()
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVoidKOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoidKOT.Click
        If dtKOTItems.Rows.Count = 0 Then
            Message = "Select KOT No from the above grid."
            Exit Sub
        End If
        Dim UnitName, ItemName As String
        Dim TaxPer As String = "0"
        Dim ItemRate As String = "0"
        UnitName = "" : ItemName = ""
        Dim liNewQty As Decimal = 0
        Dim Amount, TaxAmount, AmountAfterDiscount As Double
        Dim TotalAmount As Double = 0
        Dim DiscountPer As Double = 0
        For i As Integer = 0 To dtKOTItems.Rows.Count - 1
            liNewQty = 0
            drKOTItems = dtKOTItems.Rows(i)
            ItemRate = drKOTItems.Item("Rate")
            DiscountPer = drKOTItems.Item("DiscountPer")
            Amount = Val(ItemRate) * 0
            TaxPer = Val(drKOTItems.Item("TaxPer"))
            AmountAfterDiscount = Amount * (100 - DiscountPer) * 0.01
            TaxAmount = AmountAfterDiscount * TaxPer * 0.01
            TotalAmount = AmountAfterDiscount + TaxAmount

            drKOTItems.Item("ModifiedQty") = liNewQty
            drKOTItems.Item("Amount") = Amount
            drKOTItems.Item("TaxAmount") = TaxAmount
            drKOTItems.Item("GrossAmt") = TotalAmount
            dtKOTItems.AcceptChanges()
            dgKOTItemList.DataSource = dtKOTItems
        Next
        dgKOTItemList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        GetKOTAmount()
    End Sub

    Private Function CalculateDiscountAmt(ByVal ItemGroup As String, ByVal DiscPer As Double) As Double
        Dim DiscountAmt As Double = 0
        StrSql = "SELECT isnull(sum((KB.Qty*KB.Rate)*(" & DiscPer & ")*0.01),0) as DiscountAmt" & _
        " from FB_KOTBody KB , FB_BillBody BB where KB.itemCode in(Select itemCode from IM_ItemMaster" & _
        " where ItemGroup in(" & ItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
        " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_Code
        DiscountAmt = ObjDatabase.ExecuteScalarN(StrSql)
        CalculateDiscountAmt = DiscountAmt
    End Function

    Private Function CalculateDiscountPer(ByVal ItemGroup As String, ByVal DiscAmt As Double) As Double
        Dim DiscountPer As Double = 0
        Dim BasicAmt As Double = 0
        StrSql = "SELECT isnull(sum(KB.Qty*KB.Rate),0) as BasicAmt" & _
        " from FB_KOTBody KB , FB_BillBody BB where KB.itemCode in(Select itemCode from IM_ItemMaster" & _
        " where ItemGroup in(" & ItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
        " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_Code
        BasicAmt = ObjDatabase.ExecuteScalarN(StrSql)
        If BasicAmt = 0 Then
            DiscountPer = 0
        Else
            DiscountPer = (DiscAmt / BasicAmt) * 100
        End If
        CalculateDiscountPer = DiscountPer
    End Function

    Private Sub btnSettleBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettleBill.Click
        If cmbModeOfPayment.Text.ToUpper = "[SELECT ONE]" Or cmbModeOfPayment.Text = "" Then
            Message = "Select Mode of Payment"
            cmbModeOfPayment.Focus()
            Exit Sub
        End If
        cmbModeOfPayment_Validated(sender, e)
        PanelTables.Visible = True
        If validation() = False Then Exit Sub
        btnModifyKOT.Enabled = False

        StrSql = "SELECT count(*) from CM_GuestCardValidity where CardID='" & txtMemID.Text & "' AND Extendvalidity='Y'"
        RecCount = ObjDatabase.ExecuteScalarN(StrSql)
        If RecCount > 0 Then
            CheckCardBalance = 1
        Else
            CheckCardBalance = 0
        End If
        RecCount = 0

        If cmbModeOfPayment.Text.ToUpper() = "SMARTCARD" Then
            RecCount = ObjDatabase.ExecuteScalarN("Select Count(IssueNo) from FB_BillHead where BillNo=" & Val(lblBillNo.Text) & " and LocationCode=" & LOCATION_Code & " and YearCode=" & YearCode & " and IssueNo>0 AND ModeOfPayment='SmartCard' and [BillStatus]=0")
            ModeOpeningBalance = GetSmartCardClosingBalance(txtMemID.Text)
            ModeClosingBalance = 0
        ElseIf cmbModeOfPayment.Text.ToUpper() = "MEMBER A/C" Then
            RecCount = ObjDatabase.ExecuteScalarN("Select Count(IssueNo) from FB_BillHead where BillNo=" & Val(lblBillNo.Text) & " and LocationCode=" & LOCATION_Code & " and YearCode=" & YearCode & " and IssueNo=0 AND ModeOfPayment='Member A/c' and [BillStatus]=0")
            ModeOpeningBalance = Val(GetAvailableCreditLimit(txtMemID.Text))
            ModeClosingBalance = 0
        Else
            ModeOpeningBalance = 0
            ModeClosingBalance = 0
        End If

        ObjDatabase.ConnectDatabse()
        ObjDatabase.OpenDatabaseConnection()
        myTrans = ObjDatabase.con.BeginTransaction()
        myCommand = New SqlCommand
        myCommand = ObjDatabase.con.CreateCommand()
        myCommand.Transaction = myTrans
        BillNo = Val(lblBillNo.Text)
        Try

            If Val(txtDiscFoodPer.Text) > 0 Then
                StrSql = "UPDATE FB_KOTBody set DiscountPer=" & Val(txtDiscFoodPer.Text) & _
                " from FB_KOTBody KB , FB_BillBody BB where KB.itemCode in(Select itemCode from IM_ItemMaster" & _
                " where ItemGroup in(" & FoodItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
                " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_Code
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()
            End If

            If Val(txtDiscAlcoholicPer.Text) > 0 Then
                StrSql = "UPDATE FB_KOTBody set DiscountPer=" & Val(txtDiscAlcoholicPer.Text) & _
                " from FB_KOTBody KB , FB_BillBody BB where KB.itemCode in(Select itemCode from IM_ItemMaster" & _
                " where ItemGroup in(" & AlcoholicItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
                " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_Code
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()
            End If

            If Val(txtDiscNonAlcoholicPer.Text) > 0 Then
                StrSql = "UPDATE FB_KOTBody set DiscountPer=" & Val(txtDiscNonAlcoholicPer.Text) & _
                " from FB_KOTBody KB , FB_BillBody BB where KB.itemCode in(Select itemCode from IM_ItemMaster" & _
                " where ItemGroup in(" & NonAlcoholicItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
                " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_Code
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()
            End If

            StrSql = "SELECT STUFF((SELECT ',' + CONVERT(VARCHAR(MAX),KOTNo) FROM FB_BillBody where BillNo=" & Val(BillNo) & " and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code) & " FOR XML PATH('')), 1, 1, '') AS KOTNos"
            myCommand.CommandText = StrSql
            KOTStr = myCommand.ExecuteScalar()

            StrSql = "SELECT sum(Qty*Rate*(100-DiscountPer)*0.01+(Qty*Rate*(100-DiscountPer)*0.01*TaxPer*0.01)+(Qty*Rate*(100-DiscountPer)*0.01*SCPer*0.01  +(Qty*Rate*(100-DiscountPer)*0.01*SCPer*0.01*" & GSTPerOnServiceCharge * 0.01 & "))) as BillAmount FROM FB_KOTBody where KOTNo in(" & KOTStr & ") and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code)
            myCommand.CommandText = StrSql
            AmtBeforeRoundOff = myCommand.ExecuteScalar()

            AmtAfterRoundOff = Math.Round(AmtBeforeRoundOff + 0.01, 0)
            RoundOff = Math.Round((AmtAfterRoundOff - AmtBeforeRoundOff), 2)

            If cmbModeOfPayment.Text.ToUpper() = "SMARTCARD" Then
                StrSql = "SELECT ISNULL(sum(Amount),0) FROM FB_BillHead where BillDate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' and BillStatus=0 and IssueNo>0 and Memberid='" & txtMemID.Text & "' and BillNo<>" & Val(lblBillNo.Text)
                myCommand.CommandText = StrSql
                OpenBillAmount = myCommand.ExecuteScalar()
                Temp_ModeOpeningBalance = 0
                If RecCount = 0 Then
                    Temp_ModeOpeningBalance = ModeOpeningBalance
                    ModeOpeningBalance = Temp_ModeOpeningBalance
                    ModeClosingBalance = Temp_ModeOpeningBalance - AmtAfterRoundOff
                Else
                    Temp_ModeOpeningBalance = ModeOpeningBalance
                    ModeOpeningBalance = Temp_ModeOpeningBalance + OpenBillAmount + AmtAfterRoundOff
                    ModeClosingBalance = Temp_ModeOpeningBalance + OpenBillAmount
                End If

            ElseIf cmbModeOfPayment.Text.ToUpper() = "MEMBER A/C" Then
                StrSql = "SELECT ISNULL(sum(Amount),0) FROM FB_BillHead where BillDate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' and BillStatus=0 and IssueNo=0 and Memberid='" & txtMemID.Text & "' and BillNo<>" & Val(lblBillNo.Text)
                myCommand.CommandText = StrSql
                OpenBillAmount = myCommand.ExecuteScalar()
                Temp_ModeOpeningBalance = 0
                ModeClosingBalance = ModeOpeningBalance - AmtAfterRoundOff
            Else
                ModeOpeningBalance = 0
                ModeClosingBalance = 0
            End If

            StrSql = "UPDATE [FB_BillHead]" & _
            " SET [Amount]=" & AmtAfterRoundOff & _
            ",[PAX]=" & Val(txtPAX.Text) & _
            ",[BillStatus]=1" & _
            ",[IssueNo]=" & IIf(Val(lblIssueNo.Text) > 0, Val(lblIssueNo.Text), 0) & _
            ",[OpeningBalance]=" & ModeOpeningBalance & _
            ",[ClosingBalance]=" & ModeClosingBalance & _
            ",[RoundOff]=" & Math.Round(RoundOff, 2) & _
            ",[ModeOfPayment]='" & cmbModeOfPayment.Text & "'" & _
            ",[ModificationDate]=getdate()" & _
            " where BillNo=" & Val(BillNo) & " and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code)
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            StrSql = "UPDATE [FB_KOTHead]" & _
            " SET [ModeOfPayment]='" & cmbModeOfPayment.Text & "'" & _
            ",[IssueNo]=" & IIf(Val(lblIssueNo.Text) > 0, Val(lblIssueNo.Text), 0) & _
            " WHERE KOTNo in(" & KOTStr & ") and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code)
            myCommand.CommandText = StrSql
            myCommand.ExecuteNonQuery()

            myTrans.Commit()

            Message = "Bill No: " & lblBillNo.Text & " settled successfully"
            'PrintWindowsPOSBillThermal(Val(lblBillNo.Text), 1, LOCATION_Code, "BILL")
            If SMSToBeSent.ToUpper = "YES" Then
                SEND_SMS_ALERT_FNB(txtMemID.Text, AmtAfterRoundOff, cmbModeOfPayment.Text.ToUpper, lblBillNo.Text)
            End If
            ClearControlsAfterCheckSave()
        Catch ex As Exception
            MsgBox("Error" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            myTrans.Rollback()
        End Try
    End Sub

    Private Sub txtMemID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMemID.Validated
        GetMemberDetails(txtMemID.Text)
        If GBName = "" Then
            MsgBox("Invalid Mem_ID", MsgBoxStyle.Critical)
            ClearControlsAfterCheckSave()
            Exit Sub
        End If
        If CheckBillingStatusforStatusName(GBStatusCode) = 0 Then
            MsgBox("Member status not allowed for transaction", MsgBoxStyle.Critical)
            ClearControls()
            Exit Sub
        Else
            txtMemID.Text = GBMemberID
            DisplayMemberPics(txtMemID.Text)
            lblMainScreebCitizenType.Text = GetCitizenType(txtMemID.Text)
            ds = New DataSet
            txtMemID.Text = GBMemberID
            lblMemberName.Text = GBName
            Try
                Dim MainId As String = GetMainID(txtMemID.Text)
                lblOpenBillString.Text = "Open Bill Amt."
                lblBillAmtPerviousKOT.Text = ObjDatabase.ExecuteScalarS("Select isnull(sum(Amount),0) from FB_BillHead H where H.BillDate='" & lblBillDate.Text & "' and BillStatus=0 and MemberID like '" & MainId.Trim() & "%'")
            Catch ex As Exception

            End Try

            If BILL_TYPE = "OTP" Then
                ds = GetSmartCardBalance(txtMemID.Text)
                If ds.Tables(0).Rows.Count > 0 Then
                    MainID = ds.Tables(0).Rows(0)("MainID")
                    MemberName = ds.Tables(0).Rows(0)("MemberName")
                    IssueID = ds.Tables(0).Rows(0)("IssuedID")
                    IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                    ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                    If Val(ClosingBalance) = 0 Then
                        MsgBox("Insufficient SmartCard Balance", MsgBoxStyle.Critical)
                        ClearControlsAfterCheckSave()
                        Exit Sub
                    End If
                    lblMemberName.Text = MemberName
                    lblSmartCardOpeningBalance.Text = ClosingBalance
                    lblSmartCardClosingBalance.Text = ClosingBalance
                    lblIssueNo.Text = IssueNo
                    PanelItem.Enabled = False
                End If
                txtMemID.Enabled = False
                btnSendOTP.Focus()

            ElseIf BILL_TYPE = "MC" Then
                lblSmartCardOpeningBalance.Text = GetSmartCardClosingBalance(txtMemID.Text).ToString(NumFormat)
                lblSmartCardClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                lblOpeningCreditLimit.Text = GetCreditLimit(txtMemID.Text).ToString(NumFormat)
                lblMemberAcClosingBalance.Text = GetAvailableCreditLimit(txtMemID.Text).ToString(NumFormat)
                txtMemID.Text = GBMemberID
                lblMemberName.Text = GBName
                txtMemID.Enabled = False
                cmbWaiter.SelectedValue = 0
                cmbWaiter.Focus()
                Try
                    Dim MainId As String = GetMainID(txtMemID.Text)
                    lblOpenBillString.Text = "Open Bill Amt."
                    lblBillAmtPerviousKOT.Text = ObjDatabase.ExecuteScalarS("Select isnull(sum(Amount),0) from FB_BillHead H where H.BillDate='" & lblBillDate.Text & "' and BillStatus=0 and MemberID like '" & MainId.Trim() & "%'")
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub btnCancelBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelBill.Click
        ClearControls()
    End Sub

    Private Sub cmbModeOfPayment_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModeOfPayment.Validated
        lblIssueNo.Text = ""
        labelBillPayModeOpeningAmount.Text = ""
        labelBillPayModeClosingAmount.Text = ""
        If cmbModeOfPayment.Text.ToUpper = "MEMBER A/C" Then
            labelBillPayModeOpeningStr.Text = "OPENING CREDIT LIMIT"
            labelBillPayModeClosingStr.Text = "CLOSING CREDIT LIMIT"
            labelBillPayModeOpeningAmount.Text = Val(GetAvailableCreditLimit(txtMemID.Text)).ToString("###0.00")
            labelBillPayModeClosingAmount.Text = Val(Val(labelBillPayModeOpeningAmount.Text).ToString("###0.00") - Val(labelBillGrossAmount.Text)).ToString(NumFormat)
            If GB_DefinedCreditLimit = 0 Then
                MsgBox("Member A/c/Credit Billing not allowed on the current Member_ID", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If Val(labelBillPayModeClosingAmount.Text) < 0 Then
                MsgBox("Bill cannot be settled using 'Member A/c' settlement mode", MsgBoxStyle.Critical)
                cmbModeOfPayment.SelectedValue = 0
                Exit Sub
            End If
        ElseIf cmbModeOfPayment.Text.ToUpper = "SMARTCARD" Then
            labelBillPayModeOpeningStr.Text = "OPENING CARD BALANCE"
            labelBillPayModeClosingStr.Text = "CLOSING CARD BALANCE"
            ds = New DataSet
            ds = GetSmartCardBalance(txtMemID.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                MainID = ds.Tables(0).Rows(0)("MainID")
                MemberName = ds.Tables(0).Rows(0)("MemberName")
                IssueID = ds.Tables(0).Rows(0)("IssuedID")
                IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                lblMemberName.Text = MemberName
                lblSmartCardOpeningBalance.Text = ClosingBalance
                lblSmartCardClosingBalance.Text = ClosingBalance
                lblIssueNo.Text = IssueNo
            End If
            RecCount = ObjDatabase.ExecuteScalarN("Select Count(IssueNo) from FB_BillHead where BillNo=" & Val(lblBillNo.Text) & " and LocationCode=" & LOCATION_Code & " and YearCode=" & YearCode & " and IssueNo>0")
            If RecCount = 0 Then
                labelBillPayModeOpeningAmount.Text = (Val(ClosingBalance)).ToString("###0.00")
                labelBillPayModeClosingAmount.Text = Val(Val(ClosingBalance) - Val(labelBillGrossAmount.Text)).ToString("###0.00")
            Else
                labelBillPayModeOpeningAmount.Text = (Val(ClosingBalance) + Val(labelBillGrossAmount.Text)).ToString("###0.00")
                labelBillPayModeClosingAmount.Text = Val(Val(ClosingBalance).ToString("###0.00")).ToString(NumFormat)
            End If

            If Val(labelBillPayModeClosingAmount.Text) < 0 Then
                MsgBox("Bill cannot be settled using 'Smart Card A/c' settlement mode", MsgBoxStyle.Critical)
                cmbModeOfPayment.SelectedValue = 0
                Exit Sub
            End If
        Else
            labelBillPayModeOpeningStr.Text = "NOT APPLICABLE"
            labelBillPayModeClosingStr.Text = "NOT APPLICABLE"
            labelBillPayModeOpeningAmount.Text = "0.00"
            labelBillPayModeClosingAmount.Text = "0.00"
            lblIssueNo.Text = ""
        End If
    End Sub

    Private Sub btnSendOTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendOTP.Click
        If btnSendOTP.Text = "Send OTP" Then
            '"#OTP is your one time password (OTP) for transaction at #LOC on your Smartcard A/c #CID. Valid till #VALID."
            Dim random As New Random
            Dim SMSForOTPValidation As String = ObjDatabase.ExecuteScalar("SELECT SMSForOTPValidation from MC_Configuration")
            Dim MobileNo As String = ObjDatabase.ExecuteScalarS("SELECT Mobile1 from MM_MemberProfile WHERE MemberID='" & txtMemID.Text & "'")
            If MobileNo = "0" Then
                MsgBox("No Mobile no is linked with the entered SmartCard A/c", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim OTPExpiryMins As Integer = ObjDatabase.ExecuteScalarN("select SMSExpiryInMinutes from MC_Configuration")
            Dim OTPExpiry As Date = ObjDatabase.ExecuteScalar("Select Getdate()")
            OTPExpiry = OTPExpiry.AddMinutes(OTPExpiryMins)
            Dim OTPtobeSent As String = random.Next(100000, 999999)

            StrSql = "INSERT INTO FB_OTPVerification([Member_ID],[MobileNo],[OTPCode],[BillingLocation],[SendTimeStamp],[ExpiryTimeStamp],[OTPValidated],[UserCode])" & _
            " VALUES('" & txtMemID.Text & "','" & MobileNo & "','" & OTPtobeSent & "'," & LOCATION_Code & ",getdate(),'" & OTPExpiry & "',0," & UserCode & ")"
            ObjDatabase.ExecuteNonQuery(StrSql)

            Dim OTPText As String = ObjDatabase.ExecuteScalarS("SELECT SMSForOTPValidation FROM MC_Configuration")
            Dim TempText = OTPText
            TempText = TempText.Replace("#OTP", OTPtobeSent)
            TempText = TempText.Replace("#LOC", LOCATION_NAME)
            TempText = TempText.Replace("#CID", txtMemID.Text)
            TempText = TempText.Replace("#VALID", OTPExpiry.ToString("HH:mm"))

            StrSql = "INSERT INTO [MC_TransactionSMS]([MemberID],[MobileNo],[SMSType],[SMSText],[CreationDate],[ModificationDate],[UserCode],SentStatus)" & _
            " VALUES ('" & txtMemID.Text & "','" & MobileNo & "','POS OTP','" & TempText & "',GETDATE(),GETDATE(),1,0)"
            ObjDatabase.ExecuteNonQuery(StrSql)
            MsgBox("OTP sent successfully on Mobile No XXXXX" & MobileNo.Substring(6) & " linked with SmartCard A/c '" & txtMemID.Text & "'. Sent OTP with expire in " & OTPExpiryMins & " mins", MsgBoxStyle.Information)
            btnSendOTP.Text = "Verify OTP"
        ElseIf btnSendOTP.Text = "Verify OTP" Then
            Dim SentOTP As String = ObjDatabase.ExecuteScalarS("SELECT TOP 1 [OTPCode] FROM FB_OTPVerification WHERE [Member_ID]='" & txtMemID.Text & "'" & _
            " and [BillingLocation]=" & LOCATION_Code & " and [SendTimeStamp]<=getdate() and [ExpiryTimeStamp]>=getdate()" & _
            " and [OTPValidated]=0 order by [SendTimeStamp] DESC")
            Dim MobileNo As String = ObjDatabase.ExecuteScalarS("SELECT Mobile1 from MM_MemberProfile WHERE MemberID='" & txtMemID.Text & "'")
            Dim ReceivedOTP As String = InputBox("Enter the 6 digit OTP sent on Mobile No. " & MobileNo & " to start POS billing", "OTP Validation")
            If ReceivedOTP = SentOTP Then
                StrSql = "UPDATE FB_OTPVerification SET [OTPValidated]=1" & _
                " where [Member_ID]='" & txtMemID.Text & "' and [OTPCode]='" & SentOTP & "' and [BillingLocation]=" & LOCATION_Code
                ObjDatabase.ExecuteNonQuery(StrSql)
                btnSendOTP.Text = "OTP Verified"
                btnShowTables.Text = "SAVE"
                btnSendOTP.Enabled = False
                DisplayMemberPics(txtMemID.Text)
                ds = New DataSet
                ds = GetSmartCardBalance(txtMemID.Text)
                If ds.Tables(0).Rows.Count > 0 Then
                    MainID = ds.Tables(0).Rows(0)("MainID")
                    MemberName = ds.Tables(0).Rows(0)("MemberName")
                    IssueID = ds.Tables(0).Rows(0)("IssuedID")
                    IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                    ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                    If Val(ClosingBalance) = 0 Then
                        MsgBox("Insufficient SmartCard Balance", MsgBoxStyle.Critical)
                        ClearControlsAfterCheckSave()
                        Exit Sub
                    End If
                    lblMemberName.Text = MemberName
                    lblSmartCardOpeningBalance.Text = ClosingBalance
                    lblSmartCardClosingBalance.Text = ClosingBalance
                    lblIssueNo.Text = IssueNo
                    PanelRight.Visible = True
                    EnableControl(PanelItem)
                    EnableControl(PanelMemberDetails)
                    cmbLocation.Enabled = False
                    txtMemID.Enabled = False
                    cmbTable.Enabled = False
                    cmbWaiter.Focus()
                    btnModifyKOT.Enabled = False
                    PanelItem.Enabled = True
                End If
            Else
                MsgBox("Invalid OTP", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub btnRemoveServiceCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        StrSql = "SELECT STUFF((SELECT ',' + CONVERT(VARCHAR(MAX),KOTNo) FROM FB_BillBody where BillNo=" & Val(lblBillNo.Text) & _
        " and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code) & " FOR XML PATH('')), 1, 1, '') AS KOTNos"
        ObjDatabase.ConnectDatabse()
        KOTStr = ObjDatabase.ExecuteScalarS(StrSql)

        StrSql = "UPDATE fb_kotBody set ServiceCharge=0 where KOTNo in(" & KOTStr & ") and LocationCode=" & LOCATION_Code & _
        " and YearCode=" & YearCode
        ObjDatabase.ExecuteNonQuery(StrSql)

        StrSql = "SELECT sum(Qty*Rate*(100-DiscountPer)*0.01+(Qty*Rate)*(100-DiscountPer)*0.01*Tax*0.01) as BillAmount" & _
        " FROM FB_KOTBody where KOTNo in(" & KOTStr & ") and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code)
        AmtBeforeRoundOff = ObjDatabase.ExecuteScalarS(StrSql)

        AmtAfterRoundOff = Math.Round(AmtBeforeRoundOff + 0.01, 0)
        RoundOff = Math.Round((AmtAfterRoundOff - AmtBeforeRoundOff), 2)

        StrSql = "UPDATE FB_BillHead SET Amount=" & AmtAfterRoundOff & ",RoundOff=" & RoundOff & ",ClosingBalance=OpeningBalance-" & AmtAfterRoundOff & _
        " WHERE BillNo=" & Val(lblBillNo.Text) & " and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code)
        ObjDatabase.ExecuteNonQuery(StrSql)
        BindItemGridForSettlement(Val(lblBillNo.Text))

        ds = GetSmartCardBalance(txtMemID.Text)
        If ds.Tables(0).Rows.Count > 0 Then
            ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
            labelBillPayModeClosingAmount.Text = CDbl(ClosingBalance).ToString(NumFormat)
            labelBillPayModeOpeningAmount.Text = (CDbl(ClosingBalance) + AmtAfterRoundOff).ToString(NumFormat)
        End If
    End Sub

#Region "Print"
    'Public Sub PrintWindowsPOSBillKOT(ByVal _BillNo As Integer, ByVal _LocationCode As Integer, ByVal _YearCode As Integer, ByVal KOTType As String)
    '    Dim KOTStr As String = ""
    '    ObjDatabase.ConnectDatabse()
    '    StrSql = "SELECT  STUFF((SELECT  ',' + CONVERT(VARCHAR(max),KOTNo) FROM FB_BillBody where BillNo=" & Val(_BillNo) & " and YearCode=" & Val(_YearCode) & " and LocationCode=" & Val(_LocationCode) & " FOR XML PATH('')), 1, 1, '') AS KOTNos"
    '    KOTStr = ObjDatabase.ExecuteScalarS(StrSql)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptKOT.rpt")
    '    RecordSelectionFormula = "{FB_KOTHead.KOTNo} in [" & KOTStr & "] AND {FB_KOTHead.YearCode}=" & YearCode & " AND {FB_KOTHead.LocationCode}=" & _LocationCode
    '    CrystalReportDocument.RecordSelectionFormula = RecordSelectionFormula
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = "KOT"
    '    If KOTType = "KOT" Then
    '        CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "KITCHEN KOT")
    '    ElseIf KOTType = "STEWARD" Then
    '        CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "STEWARD KOT", "STEWARD KOT")
    '    End If
    '    CrystalReportViewer2.ReportSource = CrystalReportDocument
    'End Sub

    'Public Sub PrintWindowsPOSKOT(ByVal _KOTNo As Integer, ByVal _LocationCode As Integer, ByVal _YearCode As Integer, ByVal PrintKOT As String)
    '    If PrintKOT = "Y" And KOTPrinter.Trim() = "" Then
    '        Dim GroupName As String = ""
    '        StrSql = "Select distinct IM.HSNCode PrinterName from FB_KOTBody KB, IM_ItemMaster IM " & _
    '        " where KB.ItemCode=IM.ItemCode and KB.KOTNo=" & _KOTNo & " and YearCode=" & YearCode & " and LocationCode=" & _LocationCode
    '        ds = ObjDatabase.BindDataSet(StrSql, "KOT")
    '        For i As Integer = 0 To ds.Tables("KOT").Rows.Count - 1
    '            GroupName = "RP3200" 'ds.Tables("KOT").Rows(i)("PrinterName")
    '            RecordSelectionFormula = "{FB_KOTHead.KOTNo}=" & _KOTNo & " AND {FB_KOTHead.YearCode}=" & YearCode & " AND {FB_KOTHead.LocationCode}=" & _LocationCode & " and {IM_ItemMaster.HSNCode}='" & GroupName & "'"
    '            CrystalReportDocument = New ReportDocument
    '            CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptKOTNetwork.rpt")
    '            CrystalReportDocument.RecordSelectionFormula = RecordSelectionFormula
    '            CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '            CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '            CrystalReportDocument.SummaryInfo.ReportTitle = "KOT"
    '            'CrystalReportDocument.PrintOptions.PrinterName = GroupName.ToUpper()
    '            Select Case KOTCount
    '                Case 1
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "REST KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                Case 2
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "REST KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR STEWARD KOT", "REST STEWARD KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                    CrystalReportDocument.Refresh()
    '                Case 3
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "REST KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR STEWARD KOT", "REST STEWARD KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "REST KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '            End Select
    '        Next

    '        'CrystalReportDocument = New ReportDocument
    '        'CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptKOT.rpt")
    '        'RecordSelectionFormula = "{FB_KOTHead.KOTNo}=" & _KOTNo & " AND {FB_KOTHead.YearCode}=" & YearCode & " AND {FB_KOTHead.LocationCode}=" & _LocationCode
    '        'CrystalReportDocument.RecordSelectionFormula = RecordSelectionFormula
    '        'CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '        'CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '        'CrystalReportDocument.SummaryInfo.ReportTitle = "KOT"
    '        'Select Case KOTCount
    '        '    Case 1
    '        '        CrystalReportDocument.Refresh()
    '        '        CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "KITCHEN KOT")
    '        '        CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 1)
    '        '    Case 2
    '        '        CrystalReportDocument.Refresh()
    '        '        CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "KITCHEN KOT")
    '        '        CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '        '        CrystalReportDocument.Refresh()
    '        '        CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "STEWARD KOT", "STEWARD KOT")
    '        '        CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '        '        CrystalReportDocument.Refresh()
    '        '    Case 3
    '        '        CrystalReportDocument.Refresh()
    '        '        CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "KITCHEN KOT")
    '        '        CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '        '        CrystalReportDocument.Refresh()
    '        '        CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "STEWARD KOT", "STEWARD KOT")
    '        '        CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '        '        CrystalReportDocument.Refresh()
    '        '        CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "KITCHEN KOT")
    '        '        CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '        'End Select
    '    ElseIf PrintKOT = "Y" And KOTPrinter.Trim() <> "" Then
    '        Dim GroupName As String = ""
    '        StrSql = "Select distinct IM.HSNCode PrinterName from FB_KOTBody KB, IM_ItemMaster IM " & _
    '        " where KB.ItemCode=IM.ItemCode and KB.KOTNo=" & _KOTNo & " and YearCode=" & YearCode & " and LocationCode=" & _LocationCode
    '        ds = ObjDatabase.BindDataSet(StrSql, "KOT")
    '        For i As Integer = 0 To ds.Tables("KOT").Rows.Count - 1
    '            GroupName = ds.Tables("KOT").Rows(i)("PrinterName")
    '            RecordSelectionFormula = "{FB_KOTHead.KOTNo}=" & _KOTNo & " AND {FB_KOTHead.YearCode}=" & YearCode & " AND {FB_KOTHead.LocationCode}=" & _LocationCode & " and {IM_ItemMaster.HSNCode}='" & GroupName & "'"
    '            CrystalReportDocument = New ReportDocument
    '            CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptKOTNetwork.rpt")
    '            CrystalReportDocument.RecordSelectionFormula = RecordSelectionFormula
    '            CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '            CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '            CrystalReportDocument.SummaryInfo.ReportTitle = "KOT"
    '            CrystalReportDocument.PrintOptions.PrinterName = GroupName.ToUpper()
    '            Select Case KOTCount
    '                Case 1
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "REST KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                Case 2
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "REST KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR STEWARD KOT", "REST STEWARD KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                    CrystalReportDocument.Refresh()
    '                Case 3
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "REST KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR STEWARD KOT", "REST STEWARD KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '                    CrystalReportDocument.Refresh()
    '                    CrystalReportDocument.SummaryInfo.ReportComments = IIf(LOCATION_NAME.Contains("BAR") = True, "BAR KOT", "REST KOT")
    '                    CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 10)
    '            End Select
    '        Next


    '    End If
    'End Sub

    'Public Sub PrintWindowsPOSBillThermal(ByVal BillNo As Integer, ByVal PrintFlag As Integer, ByVal SelectedLocation As Integer, ByVal ReportTitle As String)
    '    BindTempTablesForPOSBillPrint(BillNo, SelectedLocation, YearCode)
    '    CrystalReportDocument = New ReportDocument
    '    CrystalReportDocument.Load(ApplicationStartupPath & "\TransactionPrint\crptFNBBill.rpt")
    '    RecordSelectionFormula = "{TI_BillHead.BillNo}=" & BillNo & " AND {TI_BillHead.YearCode}=" & YearCode & " and {TI_BillHead.LocationCode}=" & SelectedLocation
    '    CrystalReportDocument.RecordSelectionFormula = RecordSelectionFormula
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetConnection(SQLServerName, SQLServerDatabase, False)
    '    CrystalReportDocument.DataSourceConnections.Item(0).SetLogon(SQLServerUserName, SQLServerPassword)
    '    CrystalReportDocument.SummaryInfo.ReportTitle = ReportTitle

    '    If PrintFlag = 1 Then
    '        Select Case DraftBillCount
    '            Case 1
    '                CrystalReportDocument.SummaryInfo.ReportComments = "MEMBER COPY"
    '                CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 1)
    '            Case 2
    '                CrystalReportDocument.SummaryInfo.ReportComments = "MEMBER COPY"
    '                CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 1)
    '                CrystalReportDocument.Refresh()
    '                CrystalReportDocument.SummaryInfo.ReportComments = "CASHIER COPY"
    '                CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 1)
    '            Case 3
    '                CrystalReportDocument.SummaryInfo.ReportComments = "MEMBER COPY"
    '                CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 1)
    '                CrystalReportDocument.Refresh()
    '                CrystalReportDocument.SummaryInfo.ReportComments = "CASHIER COPY"
    '                CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 1)
    '                CrystalReportDocument.Refresh()
    '                CrystalReportDocument.SummaryInfo.ReportComments = "CASHIER COPY"
    '                CrystalReportDocument.PrintToPrinter(NoOfCopiesOfSettledBill, False, 1, 1)
    '        End Select
    '    ElseIf PrintFlag = 0 Then
    '        CrystalReportViewer2.ReportSource = CrystalReportDocument
    '    End If
    'End Sub

#End Region

#Region "Populate Tables"
    Public Sub PopulateLocationButtons()
        PanelTables.Enabled = True
        StrSql = "Select Code,LocationName as Name from IM_LocationMaster where Code in (select LocationCode from FB_LocationTableLink where MainLocationCode=" & LOCATION_Code & ") Order by 1"
        dsTableLocation = New DataSet
        dsTableLocation = ObjDatabase.BindDataSet(StrSql, "Table")
        ResetTables()
        btnBillingLocationMoveLeft.FlatStyle = FlatStyle.Popup
        btnBillingLocationMoveRight.FlatStyle = FlatStyle.Popup
        If dsTableLocation.Tables(0).Rows.Count > 8 Then
            btnBillingLocationMoveLeft.Enabled = True
            btnBillingLocationMoveRight.Enabled = True
        Else
            btnBillingLocationMoveLeft.Enabled = False
            btnBillingLocationMoveRight.Enabled = False
        End If

        Try
            btnBillingLocation1.Font = SubGroupTextFont : btnBillingLocation2.Font = SubGroupTextFont : btnBillingLocation3.Font = SubGroupTextFont : btnBillingLocation4.Font = SubGroupTextFont
            btnBillingLocation5.Font = SubGroupTextFont : btnBillingLocation6.Font = SubGroupTextFont : btnBillingLocation7.Font = SubGroupTextFont : btnBillingLocation8.Font = SubGroupTextFont

            btnBillingLocation1.BackColor = Color.Yellow : btnBillingLocation2.BackColor = Color.Yellow : btnBillingLocation3.BackColor = Color.Yellow : btnBillingLocation4.BackColor = Color.Yellow
            btnBillingLocation5.BackColor = Color.Yellow : btnBillingLocation6.BackColor = Color.Yellow : btnBillingLocation7.BackColor = Color.Yellow : btnBillingLocation8.BackColor = Color.Yellow

            If LocationTableCounter <= dsTableLocation.Tables(0).Rows.Count - 1 Then
                btnBillingLocation1.Enabled = True
                btnBillingLocation1.Text = dsTableLocation.Tables("Table")(LocationTableCounter)("Name")
                btnBillingLocation1.Tag = dsTableLocation.Tables("Table")(LocationTableCounter)("Code")
            Else
                btnBillingLocation1.Enabled = False
                btnBillingLocation1.Text = ""
                btnBillingLocation1.Tag = ""
            End If
            If LocationTableCounter + 1 <= dsTableLocation.Tables(0).Rows.Count - 1 Then
                btnBillingLocation2.Enabled = True
                btnBillingLocation2.Text = dsTableLocation.Tables("Table")(LocationTableCounter + 1)("Name")
                btnBillingLocation2.Tag = dsTableLocation.Tables("Table")(LocationTableCounter + 1)("Code")
            Else
                btnBillingLocation2.Text = ""
                btnBillingLocation2.Tag = ""
                btnBillingLocation2.Enabled = False
            End If
            If LocationTableCounter + 2 <= dsTableLocation.Tables(0).Rows.Count - 1 Then
                btnBillingLocation3.Enabled = True
                btnBillingLocation3.Text = dsTableLocation.Tables("Table")(LocationTableCounter + 2)("Name")
                btnBillingLocation3.Tag = dsTableLocation.Tables("Table")(LocationTableCounter + 2)("Code")
            Else
                btnBillingLocation3.Text = ""
                btnBillingLocation3.Tag = ""
                btnBillingLocation3.Enabled = False
            End If
            If LocationTableCounter + 3 <= dsTableLocation.Tables(0).Rows.Count - 1 Then
                btnBillingLocation4.Enabled = True
                btnBillingLocation4.Text = dsTableLocation.Tables("Table")(LocationTableCounter + 3)("Name")
                btnBillingLocation4.Tag = dsTableLocation.Tables("Table")(LocationTableCounter + 3)("Code")
            Else
                btnBillingLocation4.Text = ""
                btnBillingLocation4.Tag = ""
                btnBillingLocation4.Enabled = False
            End If
            If LocationTableCounter + 4 <= dsTableLocation.Tables(0).Rows.Count - 1 Then
                btnBillingLocation5.Enabled = True
                btnBillingLocation5.Text = dsTableLocation.Tables("Table")(LocationTableCounter + 4)("Name")
                btnBillingLocation5.Tag = dsTableLocation.Tables("Table")(LocationTableCounter + 4)("Code")
            Else
                btnBillingLocation5.Text = ""
                btnBillingLocation5.Tag = ""
                btnBillingLocation5.Enabled = False
            End If

            If LocationTableCounter + 5 <= dsTableLocation.Tables(0).Rows.Count - 1 Then
                btnBillingLocation6.Enabled = True
                btnBillingLocation6.Text = dsTableLocation.Tables("Table")(LocationTableCounter + 5)("Name")
                btnBillingLocation6.Tag = dsTableLocation.Tables("Table")(LocationTableCounter + 5)("Code")
            Else
                btnBillingLocation6.Text = ""
                btnBillingLocation6.Tag = ""
                btnBillingLocation6.Enabled = False
            End If

            If LocationTableCounter + 6 <= dsTableLocation.Tables(0).Rows.Count - 1 Then
                btnBillingLocation7.Enabled = True
                btnBillingLocation7.Text = dsTableLocation.Tables("Table")(LocationTableCounter + 6)("Name")
                btnBillingLocation7.Tag = dsTableLocation.Tables("Table")(LocationTableCounter + 6)("Code")
            Else
                btnBillingLocation7.Text = ""
                btnBillingLocation7.Tag = ""
                btnBillingLocation7.Enabled = False
            End If
            If LocationTableCounter + 7 <= dsTableLocation.Tables(0).Rows.Count - 1 Then
                btnBillingLocation8.Enabled = True
                btnBillingLocation8.Text = dsTableLocation.Tables("Table")(LocationTableCounter + 7)("Name")
                btnBillingLocation8.Tag = dsTableLocation.Tables("Table")(LocationTableCounter + 7)("Code")
            Else
                btnBillingLocation8.Text = ""
                btnBillingLocation8.Tag = ""
                btnBillingLocation8.Enabled = False
            End If
            btnBillingLocation1.FlatStyle = FlatStyle.Popup : btnBillingLocation2.FlatStyle = FlatStyle.Popup : btnBillingLocation3.FlatStyle = FlatStyle.Popup : btnBillingLocation4.FlatStyle = FlatStyle.Popup
            btnBillingLocation5.FlatStyle = FlatStyle.Popup : btnBillingLocation6.FlatStyle = FlatStyle.Popup : btnBillingLocation7.FlatStyle = FlatStyle.Popup : btnBillingLocation8.FlatStyle = FlatStyle.Popup

            'If PanelLocationTables.Tag = "LocationTable" Then
            '    dsTable = New DataSet
            '    dsTable = PopulateTables(LOCATION_Code, Val(btnBillingLocation1.Tag), 1)
            '    PopulateTableNoWithStatus()
            '    Message = "Select Table No"
            '    PanelTables.Tag = "Table"
            'ElseIf PanelLocationTables.Tag = "MoveTableLocation" Then
            '    dsTable = New DataSet
            '    dsTable = PopulateTables(LOCATION_Code, Val(btnBillingLocation1.Tag), 0)
            '    PanelLocationAndTables.Location = RightPanelLocation
            '    PanelLocationAndTables.Visible = True
            '    PanelRight.Visible = False
            '    LocationTableCounter = 0 'raj
            '    PopulateTableNoWithStatus()
            '    Message = "Select Table No to Move table"
            '    PanelTables.Tag = "MoveTable"
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ResetTables()
        btnTable1.Text = "" : btnTable2.Text = "" : btnTable3.Text = "" : btnTable4.Text = "" : btnTable5.Text = "" : btnTable6.Text = "" : btnTable7.Text = "" : btnTable8.Text = "" : btnTable9.Text = "" : btnTable10.Text = ""
        btnTable11.Text = "" : btnTable12.Text = "" : btnTable13.Text = "" : btnTable14.Text = "" : btnTable15.Text = "" : btnTable16.Text = "" : btnTable17.Text = "" : btnTable18.Text = "" : btnTable19.Text = "" : btnTable20.Text = ""
        btnTable21.Text = "" : btnTable22.Text = "" : btnTable23.Text = "" : btnTable24.Text = "" : btnTable25.Text = "" : btnTable26.Text = "" : btnTable27.Text = "" : btnTable28.Text = "" : btnTable29.Text = "" : btnTable30.Text = ""
        btnTable31.Text = "" : btnTable32.Text = "" : btnTable33.Text = "" : btnTable34.Text = "" : btnTable34.Text = "" : btnTable35.Text = "" : btnTable36.Text = "" : btnTable37.Text = "" : btnTable38.Text = "" : btnTable39.Text = ""

        btnTable1.Tag = "" : btnTable2.Tag = "" : btnTable3.Tag = "" : btnTable4.Tag = "" : btnTable5.Tag = "" : btnTable6.Tag = "" : btnTable7.Tag = "" : btnTable8.Tag = "" : btnTable9.Tag = "" : btnTable10.Tag = ""
        btnTable11.Tag = "" : btnTable12.Tag = "" : btnTable13.Tag = "" : btnTable14.Tag = "" : btnTable15.Tag = "" : btnTable16.Tag = "" : btnTable17.Tag = "" : btnTable18.Tag = "" : btnTable19.Tag = "" : btnTable20.Tag = ""
        btnTable21.Tag = "" : btnTable22.Tag = "" : btnTable23.Tag = "" : btnTable24.Tag = "" : btnTable25.Tag = "" : btnTable26.Tag = "" : btnTable27.Tag = "" : btnTable28.Tag = "" : btnTable29.Tag = "" : btnTable30.Tag = ""
        btnTable31.Tag = "" : btnTable32.Tag = "" : btnTable13.Tag = "" : btnTable34.Tag = "" : btnTable34.Tag = "" : btnTable35.Tag = "" : btnTable36.Tag = "" : btnTable37.Tag = "" : btnTable38.Tag = "" : btnTable39.Tag = ""

        btnTable1.Font = ItemTextFont : btnTable2.Font = ItemTextFont : btnTable3.Font = ItemTextFont : btnTable4.Font = ItemTextFont : btnTable5.Font = ItemTextFont : btnTable6.Font = ItemTextFont : btnTable7.Font = ItemTextFont : btnTable8.Font = ItemTextFont : btnTable9.Font = ItemTextFont : btnTable10.Font = ItemTextFont
        btnTable11.Font = ItemTextFont : btnTable12.Font = ItemTextFont : btnTable13.Font = ItemTextFont : btnTable14.Font = ItemTextFont : btnTable15.Font = ItemTextFont : btnTable16.Font = ItemTextFont : btnTable17.Font = ItemTextFont : btnTable18.Font = ItemTextFont : btnTable19.Font = ItemTextFont : btnTable20.Font = ItemTextFont
        btnTable21.Font = ItemTextFont : btnTable22.Font = ItemTextFont : btnTable23.Font = ItemTextFont : btnTable24.Font = ItemTextFont : btnTable25.Font = ItemTextFont : btnTable26.Font = ItemTextFont : btnTable27.Font = ItemTextFont : btnTable28.Font = ItemTextFont : btnTable29.Font = ItemTextFont : btnTable30.Font = ItemTextFont
        btnTable31.Font = ItemTextFont : btnTable32.Font = ItemTextFont : btnTable33.Font = ItemTextFont : btnTable34.Font = ItemTextFont : btnTable35.Font = ItemTextFont : btnTable36.Font = ItemTextFont : btnTable37.Font = ItemTextFont : btnTable38.Font = ItemTextFont : btnTable39.Font = ItemTextFont

        btnTable1.Enabled = False : btnTable2.Enabled = False : btnTable3.Enabled = False : btnTable4.Enabled = False : btnTable5.Enabled = False : btnTable6.Enabled = False : btnTable7.Enabled = False : btnTable8.Enabled = False : btnTable9.Enabled = False : btnTable10.Enabled = False
        btnTable11.Enabled = False : btnTable12.Enabled = False : btnTable13.Enabled = False : btnTable14.Enabled = False : btnTable15.Enabled = False : btnTable16.Enabled = False : btnTable17.Enabled = False : btnTable18.Enabled = False : btnTable19.Enabled = False : btnTable20.Enabled = False
        btnTable21.Enabled = False : btnTable22.Enabled = False : btnTable23.Enabled = False : btnTable24.Enabled = False : btnTable25.Enabled = False : btnTable26.Enabled = False : btnTable27.Enabled = False : btnTable28.Enabled = False : btnTable29.Enabled = False : btnTable30.Enabled = False
        btnTable31.Enabled = False : btnTable32.Enabled = False : btnTable33.Enabled = False : btnTable34.Enabled = False : btnTable35.Enabled = False : btnTable36.Enabled = False : btnTable37.Enabled = False : btnTable38.Enabled = False : btnTable39.Enabled = False

        btnTable1.BackColor = AvailableTableBackColor : btnTable2.BackColor = AvailableTableBackColor : btnTable3.BackColor = AvailableTableBackColor : btnTable4.BackColor = AvailableTableBackColor : btnTable5.BackColor = AvailableTableBackColor : btnTable6.BackColor = AvailableTableBackColor : btnTable7.BackColor = AvailableTableBackColor : btnTable8.BackColor = AvailableTableBackColor : btnTable9.BackColor = AvailableTableBackColor : btnTable10.BackColor = AvailableTableBackColor
        btnTable11.BackColor = AvailableTableBackColor : btnTable12.BackColor = AvailableTableBackColor : btnTable13.BackColor = AvailableTableBackColor : btnTable14.BackColor = AvailableTableBackColor : btnTable15.BackColor = AvailableTableBackColor : btnTable16.BackColor = AvailableTableBackColor : btnTable17.BackColor = AvailableTableBackColor : btnTable18.BackColor = AvailableTableBackColor : btnTable19.BackColor = AvailableTableBackColor : btnTable20.BackColor = AvailableTableBackColor
        btnTable21.BackColor = AvailableTableBackColor : btnTable22.BackColor = AvailableTableBackColor : btnTable23.BackColor = AvailableTableBackColor : btnTable24.BackColor = AvailableTableBackColor : btnTable25.BackColor = AvailableTableBackColor : btnTable26.BackColor = AvailableTableBackColor : btnTable27.BackColor = AvailableTableBackColor : btnTable28.BackColor = AvailableTableBackColor : btnTable29.BackColor = AvailableTableBackColor : btnTable30.BackColor = AvailableTableBackColor
        btnTable31.BackColor = AvailableTableBackColor : btnTable32.BackColor = AvailableTableBackColor : btnTable33.BackColor = AvailableTableBackColor : btnTable34.BackColor = AvailableTableBackColor : btnTable35.BackColor = AvailableTableBackColor : btnTable36.BackColor = AvailableTableBackColor : btnTable37.BackColor = AvailableTableBackColor : btnTable38.BackColor = AvailableTableBackColor : btnTable39.BackColor = AvailableTableBackColor

        btnTable1.FlatStyle = FlatStyle.Popup : btnTable2.FlatStyle = FlatStyle.Popup : btnTable3.FlatStyle = FlatStyle.Popup : btnTable4.FlatStyle = FlatStyle.Popup : btnTable5.FlatStyle = FlatStyle.Popup : btnTable6.FlatStyle = FlatStyle.Popup : btnTable7.FlatStyle = FlatStyle.Popup : btnTable8.FlatStyle = FlatStyle.Popup : btnTable9.FlatStyle = FlatStyle.Popup : btnTable10.FlatStyle = FlatStyle.Popup
        btnTable11.FlatStyle = FlatStyle.Popup : btnTable12.FlatStyle = FlatStyle.Popup : btnTable13.FlatStyle = FlatStyle.Popup : btnTable14.FlatStyle = FlatStyle.Popup : btnTable15.FlatStyle = FlatStyle.Popup : btnTable16.FlatStyle = FlatStyle.Popup : btnTable17.FlatStyle = FlatStyle.Popup : btnTable18.FlatStyle = FlatStyle.Popup : btnTable19.FlatStyle = FlatStyle.Popup : btnTable20.FlatStyle = FlatStyle.Popup
        btnTable21.FlatStyle = FlatStyle.Popup : btnTable22.FlatStyle = FlatStyle.Popup : btnTable23.FlatStyle = FlatStyle.Popup : btnTable24.FlatStyle = FlatStyle.Popup : btnTable25.FlatStyle = FlatStyle.Popup : btnTable26.FlatStyle = FlatStyle.Popup : btnTable27.FlatStyle = FlatStyle.Popup : btnTable28.FlatStyle = FlatStyle.Popup : btnTable29.FlatStyle = FlatStyle.Popup : btnTable30.FlatStyle = FlatStyle.Popup
        btnTable31.FlatStyle = FlatStyle.Popup : btnTable32.FlatStyle = FlatStyle.Popup : btnTable33.FlatStyle = FlatStyle.Popup : btnTable34.FlatStyle = FlatStyle.Popup : btnTable35.FlatStyle = FlatStyle.Popup : btnTable36.FlatStyle = FlatStyle.Popup : btnTable37.FlatStyle = FlatStyle.Popup : btnTable38.FlatStyle = FlatStyle.Popup : btnTable39.FlatStyle = FlatStyle.Popup
    End Sub

    Private Function PopulateTablesSC(ByVal MainLocation As Integer, ByVal BillingLocation As Integer, ByVal FlAG As Integer) As DataSet
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adp As New SqlDataAdapter
        dsTable = New DataSet
        con.ConnectionString = ConnectionStr
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "Proc_TableStatus"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 10000
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@BillDate", CDate(lblBillDate.Text).ToString("dd/MMM/yyyy"))
        cmd.Parameters.AddWithValue("@MainLocationCode", MainLocation)
        cmd.Parameters.AddWithValue("@BillingLocationCode", BillingLocation)
        cmd.Parameters.AddWithValue("@Flag", FlAG)
        adp.SelectCommand = cmd
        adp.Fill(dsTable, "Table")
        StrSql = "Select TableCode as Code,TableName Name From FB_TableStatus where BillNo>=0 and LocationCode=" & cmbLocation.SelectedValue
        BindComboboxWithSelectOneNumeric(StrSql, "Code", "Name", cmbTableNoSC)
        StrSql = "Select TableCode as Code,TableName Name From FB_TableStatus where BillNo>=0 and LocationCode=" & cmbLocation.SelectedValue
        BindComboboxWithSelectOneNumeric(StrSql, "Code", "Name", cmbTable)
        cmbTableNoSC.SelectedValue = 0
    End Function

    Private Function PopulateTables(ByVal MainLocation As Integer, ByVal BillingLocation As Integer, ByVal FlAG As Integer) As DataSet
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adp As New SqlDataAdapter
        dsTable = New DataSet
        con.ConnectionString = ConnectionStr
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "Proc_TableStatus"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 10000
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@BillDate", CDate(lblBillDate.Text).ToString("dd/MMM/yyyy"))
        cmd.Parameters.AddWithValue("@MainLocationCode", MainLocation)
        cmd.Parameters.AddWithValue("@BillingLocationCode", BillingLocation)
        cmd.Parameters.AddWithValue("@Flag", FlAG)
        adp.SelectCommand = cmd
        adp.Fill(dsTable, "Table")
        PopulateTables = dsTable
        StrSql = "Select TableCode as Code,TableName Name From FB_TableStatus"
        BindComboboxWithSelectOneNumeric(StrSql, "Code", "Name", cmbTable)
        cmbTable.SelectedValue = 0
    End Function

    Public Sub PopulateTableNoWithStatus()
        btnTableMoveLeft.FlatStyle = FlatStyle.Popup
        btnTableMoveRight.FlatStyle = FlatStyle.Popup
        If dsTable.Tables(0).Rows.Count > 39 Then
            btnTableMoveLeft.Enabled = True
            btnTableMoveRight.Enabled = True
        Else
            btnTableMoveLeft.Enabled = False
            btnTableMoveRight.Enabled = False
        End If
        Try
            If TableCounter <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable1.Enabled = True
                btnTable1.Text = dsTable.Tables("Table")(TableCounter)("TableName")
                btnTable1.Tag = dsTable.Tables("Table")(TableCounter)("BillNo") & "," & dsTable.Tables("Table")(TableCounter)("TableCode")
                If Val(btnTable1.Tag) > 0 Then btnTable1.BackColor = OccupiedTableBackColor Else btnTable1.BackColor = VacantTableBackColor
            End If
            If TableCounter + 1 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable2.Enabled = True
                btnTable2.Text = dsTable.Tables("Table")(TableCounter + 1)("TableName")
                btnTable2.Tag = dsTable.Tables("Table")(TableCounter + 1)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 1)("TableCode")
                If Val(btnTable2.Tag) > 0 Then btnTable2.BackColor = OccupiedTableBackColor Else btnTable2.BackColor = VacantTableBackColor
            End If
            If TableCounter + 2 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable3.Enabled = True
                btnTable3.Text = dsTable.Tables("Table")(TableCounter + 2)("TableName")
                btnTable3.Tag = dsTable.Tables("Table")(TableCounter + 2)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 2)("TableCode")
                If Val(btnTable3.Tag) > 0 Then btnTable3.BackColor = OccupiedTableBackColor Else btnTable3.BackColor = VacantTableBackColor
            End If
            If TableCounter + 3 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable4.Enabled = True
                btnTable4.Text = dsTable.Tables("Table")(TableCounter + 3)("TableName")
                btnTable4.Tag = dsTable.Tables("Table")(TableCounter + 3)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 3)("TableCode")
                If Val(btnTable4.Tag) > 0 Then btnTable4.BackColor = OccupiedTableBackColor Else btnTable4.BackColor = VacantTableBackColor
            End If
            If TableCounter + 4 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable5.Enabled = True
                btnTable5.Text = dsTable.Tables("Table")(TableCounter + 4)("TableName")
                btnTable5.Tag = dsTable.Tables("Table")(TableCounter + 4)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 4)("TableCode")
                If Val(btnTable5.Tag) > 0 Then btnTable5.BackColor = OccupiedTableBackColor Else btnTable5.BackColor = VacantTableBackColor
            End If
            If TableCounter + 5 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable6.Enabled = True
                btnTable6.Text = dsTable.Tables("Table")(TableCounter + 5)("TableName")
                btnTable6.Tag = dsTable.Tables("Table")(TableCounter + 5)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 5)("TableCode")
                If Val(btnTable6.Tag) > 0 Then btnTable6.BackColor = OccupiedTableBackColor Else btnTable6.BackColor = VacantTableBackColor
            End If
            If TableCounter + 6 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable7.Enabled = True
                btnTable7.Text = dsTable.Tables("Table")(TableCounter + 6)("TableName")
                btnTable7.Tag = dsTable.Tables("Table")(TableCounter + 6)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 6)("TableCode")
                If Val(btnTable7.Tag) > 0 Then btnTable7.BackColor = OccupiedTableBackColor Else btnTable7.BackColor = VacantTableBackColor
            End If
            If TableCounter + 7 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable8.Enabled = True
                btnTable8.Text = dsTable.Tables("Table")(TableCounter + 7)("TableName")
                btnTable8.Tag = dsTable.Tables("Table")(TableCounter + 7)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 7)("TableCode")
                If Val(btnTable8.Tag) > 0 Then btnTable8.BackColor = OccupiedTableBackColor Else btnTable8.BackColor = VacantTableBackColor
            End If
            If TableCounter + 8 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable9.Enabled = True
                btnTable9.Text = dsTable.Tables("Table")(TableCounter + 8)("TableName")
                btnTable9.Tag = dsTable.Tables("Table")(TableCounter + 8)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 8)("TableCode")
                If Val(btnTable9.Tag) > 0 Then btnTable9.BackColor = OccupiedTableBackColor Else btnTable9.BackColor = VacantTableBackColor
            End If
            If TableCounter + 9 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable10.Enabled = True
                btnTable10.Text = dsTable.Tables("Table")(TableCounter + 9)("TableName")
                btnTable10.Tag = dsTable.Tables("Table")(TableCounter + 9)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 9)("TableCode")
                If Val(btnTable10.Tag) > 0 Then btnTable10.BackColor = OccupiedTableBackColor Else btnTable10.BackColor = VacantTableBackColor
            End If
            If TableCounter + 10 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable11.Enabled = True
                btnTable11.Text = dsTable.Tables("Table")(TableCounter + 10)("TableName")
                btnTable11.Tag = dsTable.Tables("Table")(TableCounter + 10)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 10)("TableCode")
                If Val(btnTable11.Tag) > 0 Then btnTable11.BackColor = OccupiedTableBackColor Else btnTable11.BackColor = VacantTableBackColor
            End If
            If TableCounter + 11 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable12.Enabled = True
                btnTable12.Text = dsTable.Tables("Table")(TableCounter + 11)("TableName")
                btnTable12.Tag = dsTable.Tables("Table")(TableCounter + 11)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 11)("TableCode")
                If Val(btnTable12.Tag) > 0 Then btnTable12.BackColor = OccupiedTableBackColor Else btnTable12.BackColor = VacantTableBackColor
            End If
            If TableCounter + 12 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable13.Enabled = True
                btnTable13.Text = dsTable.Tables("Table")(TableCounter + 12)("TableName")
                btnTable13.Tag = dsTable.Tables("Table")(TableCounter + 12)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 12)("TableCode")
                If Val(btnTable13.Tag) > 0 Then btnTable13.BackColor = OccupiedTableBackColor Else btnTable13.BackColor = VacantTableBackColor
            End If
            If TableCounter + 13 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable14.Enabled = True
                btnTable14.Text = dsTable.Tables("Table")(TableCounter + 13)("TableName")
                btnTable14.Tag = dsTable.Tables("Table")(TableCounter + 13)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 13)("TableCode")
                If Val(btnTable14.Tag) > 0 Then btnTable14.BackColor = OccupiedTableBackColor Else btnTable14.BackColor = VacantTableBackColor
            End If

            If TableCounter + 14 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable15.Enabled = True
                btnTable15.Text = dsTable.Tables("Table")(TableCounter + 14)("TableName")
                btnTable15.Tag = dsTable.Tables("Table")(TableCounter + 14)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 14)("TableCode")
                If Val(btnTable15.Tag) > 0 Then btnTable15.BackColor = OccupiedTableBackColor Else btnTable15.BackColor = VacantTableBackColor
            End If

            If TableCounter + 15 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable16.Enabled = True
                btnTable16.Text = dsTable.Tables("Table")(TableCounter + 15)("TableName")
                btnTable16.Tag = dsTable.Tables("Table")(TableCounter + 15)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 15)("TableCode")
                If Val(btnTable16.Tag) > 0 Then btnTable16.BackColor = OccupiedTableBackColor Else btnTable16.BackColor = VacantTableBackColor
            End If

            If TableCounter + 16 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable17.Enabled = True
                btnTable17.Text = dsTable.Tables("Table")(TableCounter + 16)("TableName")
                btnTable17.Tag = dsTable.Tables("Table")(TableCounter + 16)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 16)("TableCode")
                If Val(btnTable17.Tag) > 0 Then btnTable17.BackColor = OccupiedTableBackColor Else btnTable17.BackColor = VacantTableBackColor
            End If

            If TableCounter + 17 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable18.Enabled = True
                btnTable18.Text = dsTable.Tables("Table")(TableCounter + 17)("TableName")
                btnTable18.Tag = dsTable.Tables("Table")(TableCounter + 17)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 17)("TableCode")
                If Val(btnTable18.Tag) > 0 Then btnTable18.BackColor = OccupiedTableBackColor Else btnTable18.BackColor = VacantTableBackColor
            End If

            If TableCounter + 18 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable19.Enabled = True
                btnTable19.Text = dsTable.Tables("Table")(TableCounter + 18)("TableName")
                btnTable19.Tag = dsTable.Tables("Table")(TableCounter + 18)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 18)("TableCode")
                If Val(btnTable19.Tag) > 0 Then btnTable19.BackColor = OccupiedTableBackColor Else btnTable19.BackColor = VacantTableBackColor
            End If

            If TableCounter + 19 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable20.Enabled = True
                btnTable20.Text = dsTable.Tables("Table")(TableCounter + 19)("TableName")
                btnTable20.Tag = dsTable.Tables("Table")(TableCounter + 19)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 19)("TableCode")
                If Val(btnTable20.Tag) > 0 Then btnTable20.BackColor = OccupiedTableBackColor Else btnTable20.BackColor = VacantTableBackColor
            End If

            If TableCounter + 20 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable21.Enabled = True
                btnTable21.Text = dsTable.Tables("Table")(TableCounter + 20)("TableName")
                btnTable21.Tag = dsTable.Tables("Table")(TableCounter + 20)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 20)("TableCode")
                If Val(btnTable21.Tag) > 0 Then btnTable21.BackColor = OccupiedTableBackColor Else btnTable21.BackColor = VacantTableBackColor
            End If

            If TableCounter + 21 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable22.Enabled = True
                btnTable22.Text = dsTable.Tables("Table")(TableCounter + 21)("TableName")
                btnTable22.Tag = dsTable.Tables("Table")(TableCounter + 21)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 21)("TableCode")
                If Val(btnTable22.Tag) > 0 Then btnTable22.BackColor = OccupiedTableBackColor Else btnTable22.BackColor = VacantTableBackColor
            End If

            If TableCounter + 22 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable23.Enabled = True
                btnTable23.Text = dsTable.Tables("Table")(TableCounter + 22)("TableName")
                btnTable23.Tag = dsTable.Tables("Table")(TableCounter + 22)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 22)("TableCode")
                If Val(btnTable23.Tag) > 0 Then btnTable23.BackColor = OccupiedTableBackColor Else btnTable23.BackColor = VacantTableBackColor
            End If

            If TableCounter + 23 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable24.Enabled = True
                btnTable24.Text = dsTable.Tables("Table")(TableCounter + 23)("TableName")
                btnTable24.Tag = dsTable.Tables("Table")(TableCounter + 23)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 23)("TableCode")
                If Val(btnTable24.Tag) > 0 Then btnTable24.BackColor = OccupiedTableBackColor Else btnTable24.BackColor = VacantTableBackColor
            End If

            If TableCounter + 24 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable25.Enabled = True
                btnTable25.Text = dsTable.Tables("Table")(TableCounter + 24)("TableName")
                btnTable25.Tag = dsTable.Tables("Table")(TableCounter + 24)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 24)("TableCode")
                If Val(btnTable25.Tag) > 0 Then btnTable25.BackColor = OccupiedTableBackColor Else btnTable25.BackColor = VacantTableBackColor
            End If

            If TableCounter + 25 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable26.Enabled = True
                btnTable26.Text = dsTable.Tables("Table")(TableCounter + 25)("TableName")
                btnTable26.Tag = dsTable.Tables("Table")(TableCounter + 25)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 25)("TableCode")
                If Val(btnTable26.Tag) > 0 Then btnTable26.BackColor = OccupiedTableBackColor Else btnTable26.BackColor = VacantTableBackColor
            End If

            If TableCounter + 26 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable27.Enabled = True
                btnTable27.Text = dsTable.Tables("Table")(TableCounter + 26)("TableName")
                btnTable27.Tag = dsTable.Tables("Table")(TableCounter + 26)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 26)("TableCode")
                If Val(btnTable27.Tag) > 0 Then btnTable27.BackColor = OccupiedTableBackColor Else btnTable27.BackColor = VacantTableBackColor
            End If

            If TableCounter + 27 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable28.Enabled = True
                btnTable28.Text = dsTable.Tables("Table")(TableCounter + 27)("TableName")
                btnTable28.Tag = dsTable.Tables("Table")(TableCounter + 27)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 27)("TableCode")
                If Val(btnTable28.Tag) > 0 Then btnTable28.BackColor = OccupiedTableBackColor Else btnTable28.BackColor = VacantTableBackColor
            End If

            If TableCounter + 28 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable29.Enabled = True
                btnTable29.Text = dsTable.Tables("Table")(TableCounter + 28)("TableName")
                btnTable29.Tag = dsTable.Tables("Table")(TableCounter + 28)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 28)("TableCode")
                If Val(btnTable29.Tag) > 0 Then btnTable29.BackColor = OccupiedTableBackColor Else btnTable29.BackColor = VacantTableBackColor
            End If

            If TableCounter + 29 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable30.Enabled = True
                btnTable30.Text = dsTable.Tables("Table")(TableCounter + 29)("TableName")
                btnTable30.Tag = dsTable.Tables("Table")(TableCounter + 29)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 29)("TableCode")
                If Val(btnTable30.Tag) > 0 Then btnTable30.BackColor = OccupiedTableBackColor Else btnTable30.BackColor = VacantTableBackColor
            End If

            If TableCounter + 30 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable31.Enabled = True
                btnTable31.Text = dsTable.Tables("Table")(TableCounter + 30)("TableName")
                btnTable31.Tag = dsTable.Tables("Table")(TableCounter + 30)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 30)("TableCode")
                If Val(btnTable31.Tag) > 0 Then btnTable31.BackColor = OccupiedTableBackColor Else btnTable31.BackColor = VacantTableBackColor
            End If

            If TableCounter + 31 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable32.Enabled = True
                btnTable32.Text = dsTable.Tables("Table")(TableCounter + 31)("TableName")
                btnTable32.Tag = dsTable.Tables("Table")(TableCounter + 31)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 31)("TableCode")
                If Val(btnTable32.Tag) > 0 Then btnTable32.BackColor = OccupiedTableBackColor Else btnTable32.BackColor = VacantTableBackColor
            End If

            If TableCounter + 32 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable33.Enabled = True
                btnTable33.Text = dsTable.Tables("Table")(TableCounter + 32)("TableName")
                btnTable33.Tag = dsTable.Tables("Table")(TableCounter + 32)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 32)("TableCode")
                If Val(btnTable33.Tag) > 0 Then btnTable33.BackColor = OccupiedTableBackColor Else btnTable33.BackColor = VacantTableBackColor
            End If

            If TableCounter + 33 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable34.Enabled = True
                btnTable34.Text = dsTable.Tables("Table")(TableCounter + 33)("TableName")
                btnTable34.Tag = dsTable.Tables("Table")(TableCounter + 33)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 33)("TableCode")
                If Val(btnTable34.Tag) > 0 Then btnTable34.BackColor = OccupiedTableBackColor Else btnTable34.BackColor = VacantTableBackColor
            End If

            If TableCounter + 34 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable35.Enabled = True
                btnTable35.Text = dsTable.Tables("Table")(TableCounter + 34)("TableName")
                btnTable35.Tag = dsTable.Tables("Table")(TableCounter + 34)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 34)("TableCode")
                If Val(btnTable35.Tag) > 0 Then btnTable35.BackColor = OccupiedTableBackColor Else btnTable35.BackColor = VacantTableBackColor
            End If

            If TableCounter + 35 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable36.Enabled = True
                btnTable36.Text = dsTable.Tables("Table")(TableCounter + 35)("TableName")
                btnTable36.Tag = dsTable.Tables("Table")(TableCounter + 35)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 35)("TableCode")
                If Val(btnTable36.Tag) > 0 Then btnTable36.BackColor = OccupiedTableBackColor Else btnTable36.BackColor = VacantTableBackColor
            End If

            If TableCounter + 36 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable37.Enabled = True
                btnTable37.Text = dsTable.Tables("Table")(TableCounter + 36)("TableName")
                btnTable37.Tag = dsTable.Tables("Table")(TableCounter + 36)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 36)("TableCode")
                If Val(btnTable37.Tag) > 0 Then btnTable37.BackColor = OccupiedTableBackColor Else btnTable37.BackColor = VacantTableBackColor
            End If

            If TableCounter + 37 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable38.Enabled = True
                btnTable38.Text = dsTable.Tables("Table")(TableCounter + 37)("TableName")
                btnTable38.Tag = dsTable.Tables("Table")(TableCounter + 37)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 37)("TableCode")
                If Val(btnTable38.Tag) > 0 Then btnTable38.BackColor = OccupiedTableBackColor Else btnTable38.BackColor = VacantTableBackColor
            End If
            If TableCounter + 38 <= dsTable.Tables(0).Rows.Count - 1 Then
                btnTable39.Enabled = True
                btnTable39.Text = dsTable.Tables("Table")(TableCounter + 38)("TableName")
                btnTable39.Tag = dsTable.Tables("Table")(TableCounter + 38)("BillNo") & "," & dsTable.Tables("Table")(TableCounter + 38)("TableCode")
                If Val(btnTable39.Tag) > 0 Then btnTable39.BackColor = OccupiedTableBackColor Else btnTable39.BackColor = VacantTableBackColor
            End If

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "BindGrids"

    Private Sub BindClosedBills()
        Try
            Dim dsOpenBills As New DataSet
            lblBillDate.Text = CurrentBusinessDate.ToString("dd/MMM/yyyy")
            dgHistory.Visible = True
            If UserCodeForSpecialAccess.Contains(UserCode) = True Then
                dgHistory.Columns(0).Visible = True
            Else
                dgHistory.Columns(0).Visible = False
            End If
            dgHistory.Columns(1).Visible = True
            dgHistory.Columns(2).Visible = False
            'StrSql = "SELECT BH.BillNo,MI.OldMemNo MemNo,TM.TableNo,BH.MemberName as Name,Amount,BH.MemberID,BH.[YearCode],BH.LocationCode,bh.ValidationMode
            StrSql = "SELECT BH.BillNo,MI.OldMemNo MemNo,TM.TableNo,BH.MemberName as Name,Amount,BH.MemberID,BH.[YearCode],BH.LocationCode,bh.ValidationMode" & _
            " FROM FB_BillHead BH, view_MemberInformation MI,FB_TableMaster TM " & _
            " WHERE BH.TableCode=TM.Code and MI.MemberID=BH.MemberID and BH.BillStatus=1 and BH.Amount>0 and BH.[LocationCode]=" & LOCATION_Code & " and BH.YearCode=" & YearCode & _
            " and BH.Billdate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' and BillType in(" & BillType & ")" & _
            IIf(txtMemIDSC.Text <> "", " and (BH.MemberID Like '" & txtMemIDSC.Text & "%' or MI.OldMemNo Like '" & txtMemIDSC.Text & "%')", "") & _
            " ORDER BY 1 DESC"

            dsOpenBills = ObjDatabase.BindDataSet(StrSql, "Bills")
            dgHistory.DataSource = dsOpenBills.Tables("Bills")
            FormatDataGridView(dgHistory)

            dgHistory.Columns("LocationCode").Visible = False
            dgHistory.Columns("YearCode").Visible = False
            dgHistory.Columns("ValidationMode").Visible = False

            dgHistory.Columns("BillNo").Width = 70
            dgHistory.Columns("BillNo").HeaderText = "Bill#"
            dgHistory.Columns("BillNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgHistory.Columns("BillNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgHistory.Columns("Amount").HeaderText = "Amount"
            dgHistory.Columns("Amount").Visible = False
            dgHistory.Columns("Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgHistory.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgHistory.Columns("MemNo").HeaderText = "MemNo"
            dgHistory.Columns("MemNo").Width = 80
            dgHistory.Columns("MemNo").Visible = True
            dgHistory.Columns("MemNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("MemNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            dgHistory.Columns("MemberID").HeaderText = "Mem_ID"
            dgHistory.Columns("MemberID").Width = 80
            dgHistory.Columns("MemberID").Visible = True
            dgHistory.Columns("MemberID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("MemberID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            dgHistory.Columns("Name").HeaderText = "Name"
            dgHistory.Columns("Name").Width = 150
            dgHistory.Columns("Name").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            dgHistory.Columns("TableNo").HeaderText = "T#"
            dgHistory.Columns("TableNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("TableNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("TableNo").Visible = True

            dgHistory.RowHeadersVisible = True
            dgHistory.RowHeadersWidth = 20
            dgHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgHistory.RowTemplate.Height = 30
            dgHistory.Tag = "History"
            btnModifyKOT.Tag = "0"
            Message = "Displaying Bill History"
            dgHistory.Columns(0).Visible = IIf((EditRight = 0), False, True)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BindOpenBills()
        Try

            Dim dsOpenBills As New DataSet
            lblBillDate.Text = CurrentBusinessDate.ToString("dd/MMM/yyyy")
            dgHistory.Visible = True
            dgHistory.Columns(0).Visible = False
            dgHistory.Columns(1).Visible = True
            dgHistory.Columns(2).Visible = True
            'bill no,mem no,table no,mem name
            StrSql = "SELECT BH.BillNo,MI.OldMemNo MemNo,TM.TableNo,BH.MemberName as Name,Amount,BH.MemberID,BH.[YearCode],BH.LocationCode,bh.ValidationMode" & _
            " FROM FB_BillHead BH, view_MemberInformation MI,FB_TableMaster TM " & _
            " WHERE BH.TableCode=TM.Code and MI.MemberID=BH.MemberID and BH.BillStatus=0 and BH.Amount>0 and BH.[LocationCode]=" & LOCATION_Code & " and BH.YearCode=" & YearCode & _
            " and BH.Billdate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' and BillType in(" & BillType & ")" & _
            IIf(txtMemIDSC.Text <> "", " and BH.MemberID Like '" & txtMemIDSC.Text & "%'", "") & _
            " ORDER BY 1 DESC"

            dsOpenBills = ObjDatabase.BindDataSet(StrSql, "Bills")
            dgHistory.DataSource = dsOpenBills.Tables("Bills")
            FormatDataGridView(dgHistory)

            dgHistory.Columns("LocationCode").Visible = False
            dgHistory.Columns("YearCode").Visible = False
            dgHistory.Columns("ValidationMode").Visible = False

            dgHistory.Columns("BillNo").Width = 70
            dgHistory.Columns("BillNo").HeaderText = "Bill#"
            dgHistory.Columns("BillNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgHistory.Columns("BillNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgHistory.Columns("Amount").HeaderText = "Amount"
            dgHistory.Columns("Amount").Visible = False
            dgHistory.Columns("Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgHistory.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgHistory.Columns("MemNo").HeaderText = "MemNo"
            dgHistory.Columns("MemNo").Visible = True
            dgHistory.Columns("MemNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("MemNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("MemNo").Width = 80

            dgHistory.Columns("MemberID").HeaderText = "Mem_ID"
            dgHistory.Columns("MemberID").Visible = True
            dgHistory.Columns("MemberID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("MemberID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("MemberID").Width = 80

            dgHistory.Columns("TableNo").HeaderText = "T#"
            dgHistory.Columns("TableNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("TableNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("TableNo").Width = 50

            dgHistory.Columns("Name").HeaderText = "Name"
            dgHistory.Columns("Name").Width = 150
            dgHistory.Columns("Name").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgHistory.Columns("Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            dgHistory.RowHeadersVisible = True
            dgHistory.RowHeadersWidth = 20
            dgHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgHistory.RowTemplate.Height = 30
            dgHistory.Tag = "OpenBills"
            btnModifyKOT.Tag = "0"
            Message = "Displaying Open Checks"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BindItemGridForSettlement(ByVal BillNo As Integer)
        dgItemGrid.Refresh()
        StrSql = "SELECT STUFF((SELECT ',' + CONVERT(VARCHAR(MAX),KOTNo) FROM FB_BillBody where BillNo=" & Val(BillNo) & " and YearCode=" & Val(YearCode) & " and LocationCode=" & Val(LOCATION_Code) & " FOR XML PATH('')), 1, 1, '') AS KOTNos"
        ObjDatabase.ConnectDatabse()
        KOTStr = ObjDatabase.ExecuteScalarS(StrSql)
        dgItemGrid.Visible = True
        ds = New DataSet
        dtKOTItems = New DataTable
        StrSql = "select 0 as SNo,KB.KOTNo,KB.ItemCode as [ItemCode],IM.Aliasname," & _
        " IM.ItemName [ItemName], KB.UnitCode UnitCode,KB.QTY as Qty,UM.UnitName as [Unit], KB.Rate as [Rate],KB.QTY*KB.Rate as [Amount]," & _
        " KB.TaxPer as [TaxPer],KB.SCPer SCPer, ((KB.QTY*KB.Rate)-(KB.QTY*KB.Rate*DiscountPer*0.01))*KB.TaxPer*0.01 as [TaxAmount]" & _
        ",((KB.QTY*KB.Rate)-(KB.QTY*KB.Rate*DiscountPer*0.01))*KB.SCPer*0.01 as [SCAmount]" & _
        ",(((KB.QTY*KB.Rate)-(KB.QTY*KB.Rate*DiscountPer*0.01))+((KB.QTY*KB.Rate)-(KB.QTY*KB.Rate*DiscountPer*0.01))*KB.TaxPer*0.01+((KB.QTY*KB.Rate)-(KB.QTY*KB.Rate*DiscountPer*0.01))*KB.SCPer*0.01 +((KB.QTY*KB.Rate)-(KB.QTY*KB.Rate*DiscountPer*0.01))*KB.SCPer*0.01*" & GSTPerOnServiceCharge * 0.01 & ") as [GrossAmt]" & _
        ",getdate() as DisplayOrder,0 as OpenItem,DiscountPer,KB.TaxType,KB.Remarks " & _
        " from FB_KOTBody KB ,IM_ItemMaster IM ,IM_UnitMaster UM" & _
        " where KB.ITEMCode=IM.ITEMCode AND KB.UnitCode=UM.Code" & _
        " and KB.KOTNo in(" & KOTStr & ") and KB.yearCode=" & YearCode & " and KB.LocationCode=" & LOCATION_Code & " order by KB.KOTNo,IM.ItemName"
        ds = ObjDatabase.BindDataSet(StrSql, "Item")
        dtKOTItems = ds.Tables("Item")
        dgItemGrid.DataSource = dtKOTItems
        FormatDataGridView(dgItemGrid)
        dgItemGrid.Columns("OpenItem").Visible = False
        dgItemGrid.Columns("DisplayOrder").Visible = False
        dgItemGrid.Columns("UnitCode").Visible = False
        dgItemGrid.Columns("unit").Visible = False
        dgItemGrid.Columns("TaxPer").Visible = False
        dgItemGrid.Columns("SCPer").Visible = False
        dgItemGrid.Columns("SNo").Visible = False
        dgItemGrid.Columns("TaxAmount").Visible = False
        dgItemGrid.Columns("SCAmount").Visible = False
        dgItemGrid.Columns("TaxType").Visible = False
        dgItemGrid.Columns("Remarks").Visible = False

        dgItemGrid.Columns("GrossAmt").Visible = True
        dgItemGrid.Columns("KOTNo").Width = 60
        dgItemGrid.Columns("KOTNo").Visible = False
        dgItemGrid.Columns("ItemCode").Width = 45
        dgItemGrid.Columns("ItemCode").HeaderText = "Code"
        dgItemGrid.Columns("ItemCode").Visible = False

        dgItemGrid.Columns("Aliasname").HeaderText = "ItemCode"
        dgItemGrid.Columns("Aliasname").Visible = True

        dgItemGrid.Columns("SNo").Width = 30
        dgItemGrid.Columns("SNo").HeaderText = "#"
        dgItemGrid.Columns("ItemName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgItemGrid.Columns("Unit").Width = 80
        dgItemGrid.Columns("Qty").Width = 45
        dgItemGrid.Columns("Rate").Width = 58
        dgItemGrid.Columns("Rate").Visible = True
        dgItemGrid.Columns("Amount").Width = 60
        dgItemGrid.Columns("TaxPer").HeaderText = "GST%"
        dgItemGrid.Columns("TaxPer").Visible = False
        dgItemGrid.Columns("Amount").HeaderText = "Amt"
        dgItemGrid.Columns("Amount").Visible = False
        dgItemGrid.Columns("TaxAmount").Width = 65
        dgItemGrid.Columns("TaxAmount").HeaderText = "TaxAmt"
        dgItemGrid.Columns("Unit").Visible = True
        dgItemGrid.Columns("GrossAmt").Visible = True
        dgItemGrid.Columns("GrossAmt").Width = 75
        dgItemGrid.Columns("GrossAmt").HeaderText = "GrossAmt"
        dgItemGrid.Columns("DiscountPer").Visible = False
        dgItemGrid.RowHeadersVisible = True
        dgItemGrid.RowHeadersWidth = 20
        dgItemGrid.Columns("ItemCode").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Rate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("TaxAmount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("ItemCode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("TaxAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("GrossAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("GrossAmt").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgItemGrid.Columns("TaxPer").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgItemGrid.Columns("TaxPer").DefaultCellStyle.Format = NumFormat
        dgItemGrid.Columns("TaxAmount").DefaultCellStyle.Format = NumFormat
        dgItemGrid.Columns("Qty").DefaultCellStyle.Format = NumFormat
        dgItemGrid.Columns("Rate").DefaultCellStyle.Format = NumFormat
        dgItemGrid.Columns("Amount").DefaultCellStyle.Format = NumFormat
        dgItemGrid.Columns("GrossAmt").DefaultCellStyle.Format = NumFormat
        dgItemGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgItemGrid.RowTemplate.Height = 25
        dgItemGrid.RowHeadersVisible = True
        dgItemGrid.Tag = "Items"
        dgItemGrid.ClearSelection()
        dgItemGrid.Columns("ItemCode").Visible = False
        dgItemGrid.Columns("ItemCode").SortMode = DataGridViewColumnSortMode.NotSortable
        dgItemGrid.Columns("ItemName").SortMode = DataGridViewColumnSortMode.NotSortable
        dgItemGrid.Columns("Qty").SortMode = DataGridViewColumnSortMode.NotSortable
        dgItemGrid.Columns("Rate").SortMode = DataGridViewColumnSortMode.NotSortable
        dgItemGrid.Columns("Amount").SortMode = DataGridViewColumnSortMode.NotSortable
        dgItemGrid.Columns("TaxAmount").SortMode = DataGridViewColumnSortMode.NotSortable
        dgItemGrid.Columns(0).Width = 25
        dgItemGrid.Columns(1).Width = 25
        GetFinalBillAmount()
        dgItemGrid.Enabled = True
    End Sub

    Private Sub BindKOTNosForModification()
        StrSql = "select LM.LocationName,BB.BillNo,KH.KOTNo,KH.CreationDate KOTDate,TM.TableNo,KH.IssueNo, KH.LocationCode,KH.YearCode" & _
        " from FB_KOTHead KH, FB_BillBody BB,IM_LocationMaster LM, FB_TableMaster TM" & _
        " where KH.KOTNo=BB.KOTNo and KH.LocationCode=BB.LocationCode and KH.YearCode=BB.YearCode " & _
        " and BB.BillNo=" & Val(lblBillNo.Text) & " and BB.LocationCode=" & Val(lblLocationCode_KOTModify.Text) & " and bb.YearCode=" & Val(lblYearCode_KOTModify.Text) & _
        " and KH.LocationCode=LM.Code and TM.Code=KH.TableCode order by KH.CreationDate desc"

        ds = ObjDatabase.BindDataSet(StrSql, "KOT")
        dtKOTItems = ds.Tables("KOT")
        dgKOTList.DataSource = dtKOTItems
        FormatDataGridView(dgKOTList)
        dgKOTList.Columns("IssueNo").Visible = False
        dgKOTList.Columns("LocationCode").Visible = False
        dgKOTList.Columns("YearCode").Visible = False

        dgKOTList.Columns("LocationName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgKOTList.Columns("LocationName").HeaderText = "Location"
        dgKOTList.Columns("LocationName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgKOTList.Columns("LocationName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgKOTList.Columns("BillNo").HeaderText = "BillNo"
        dgKOTList.Columns("BillNo").Width = 60
        dgKOTList.Columns("BillNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgKOTList.Columns("BillNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgKOTList.Columns("KOTNo").HeaderText = "KOTNo"
        dgKOTList.Columns("KOTNo").Width = 60
        dgKOTList.Columns("KOTNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgKOTList.Columns("KOTNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgKOTList.Columns("KOTDate").HeaderText = "KOTDate"
        dgKOTList.Columns("KOTDate").Width = 100
        dgKOTList.Columns("KOTDate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgKOTList.Columns("KOTDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgKOTList.Columns("KOTDate").DefaultCellStyle.Format = "dd/MMM/yyyy"

        dgKOTList.Columns("TableNo").HeaderText = "TableNo"
        dgKOTList.Columns("TableNo").Width = 70
        dgKOTList.Columns("TableNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgKOTList.Columns("TableNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgKOTList.RowHeadersWidth = 20
    End Sub

    Private Sub BindKOTModifyItemDetails(ByVal _KOTNo As Integer, ByVal _YearCode As Integer, ByVal _LocationCode As Integer)
        StrSql = "select KB.KOTNo as [KOTNo],KB.ItemCode as [Code],IM.Aliasname,KB.ItemName as [Item],UM.Unitname as [Unit],KB.rate as Rate" & _
        ",KB.ActualQty as [OriginalQty],KB.Qty as [ModifiedQty],(KB.Qty*KB.Rate-KB.Qty*KB.Rate*DiscountPer*0.01) as Amount ,KB.TaxPer TaxPer" & _
        ",(KB.Qty*KB.Rate-KB.Qty*KB.Rate*DiscountPer*0.01)*KB.TaxPer*0.01 TaxAmount,KB.SCPer SCPer" & _
        ",(KB.Qty*KB.Rate-KB.Qty*KB.Rate*DiscountPer*0.01)*KB.SCPer*0.01 SCAmount " & _
        ",Convert(decimal(18,2),((KB.Qty*KB.Rate-KB.Qty*KB.Rate*DiscountPer*0.01) + (KB.Qty*KB.Rate-KB.Qty*KB.Rate*DiscountPer*0.01) * KB.TaxPer * 0.01 + (KB.Qty*KB.Rate-KB.Qty*KB.Rate*DiscountPer*0.01) * KB.SCPer * 0.01 + (KB.Qty*KB.Rate-KB.Qty*KB.Rate*DiscountPer*0.01) * KB.SCPer * 0.01*" & GSTPerOnServiceCharge * 0.01 & ")) as [GrossAmt] " & _
        ",KB.DiscountPer,KH.LocationCode,KH.YearCode from FB_KOTBody KB,IM_ItemMaster IM,IM_UnitMaster UM,FB_KOTHead KH " & _
        " where KB.yearCode=KH.yearCode and KB.itemCode=IM.itemCode and KB.UnitCode=UM.Code and KB.KOTNo=KH.KOTNo and KB.YearCode=KH.YearCode" & _
        " and KB.LocationCode=KH.LocationCode AND KH.KOTNo=" & _KOTNo & " and KH.yearCode=" & _YearCode & " and KH.LocationCode=" & _LocationCode & " and KB.Qty>0"

        ds = ObjDatabase.BindDataSet(StrSql, "KOT")
        dtKOTItems = ds.Tables("KOT")
        dgKOTItemList.DataSource = dtKOTItems
        FormatDataGridView(dgKOTItemList)
        dgKOTItemList.Columns("Amount").Visible = False
        dgKOTItemList.Columns("TaxPer").Visible = False
        dgKOTItemList.Columns("TaxAmount").Visible = False
        dgKOTItemList.Columns("SCPer").Visible = False
        dgKOTItemList.Columns("SCAmount").Visible = False
        dgKOTItemList.Columns("KOTNo").Visible = False
        dgKOTItemList.Columns("DiscountPer").Visible = False
        dgKOTItemList.Columns("LocationCode").Visible = False
        dgKOTItemList.Columns("YearCode").Visible = False
        dgKOTItemList.Columns("Code").Visible = False

        dgKOTItemList.Columns("Aliasname").Width = 80
        dgKOTItemList.Columns("Aliasname").HeaderText = "ItemCode"
        dgKOTItemList.Columns("Aliasname").Visible = True
        dgKOTItemList.Columns("Aliasname").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgKOTItemList.Columns("Aliasname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgKOTItemList.Columns("Item").HeaderText = "Item"
        dgKOTItemList.Columns("Item").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgKOTItemList.Columns("Item").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgKOTItemList.Columns("Item").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgKOTItemList.Columns("Unit").HeaderText = "Unit"
        dgKOTItemList.Columns("Unit").Visible = False
        dgKOTItemList.Columns("Unit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgKOTItemList.Columns("Unit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgKOTItemList.Columns("Rate").HeaderText = "Rate"
        dgKOTItemList.Columns("Rate").Width = 80
        dgKOTItemList.Columns("Rate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgKOTItemList.Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgKOTItemList.Columns("OriginalQty").HeaderText = "ActualQty"
        dgKOTItemList.Columns("OriginalQty").Width = 80
        dgKOTItemList.Columns("OriginalQty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgKOTItemList.Columns("OriginalQty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgKOTItemList.Columns("OriginalQty").DefaultCellStyle.Format = "#0"

        dgKOTItemList.Columns("ModifiedQty").HeaderText = "ModifiedQty"
        dgKOTItemList.Columns("ModifiedQty").Width = 90
        dgKOTItemList.Columns("ModifiedQty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgKOTItemList.Columns("ModifiedQty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgKOTItemList.Columns("ModifiedQty").DefaultCellStyle.Format = "#0"

        dgKOTItemList.Columns("GrossAmt").Width = 80
        dgKOTItemList.Columns("GrossAmt").HeaderText = "GrossAmt"
        dgKOTItemList.Columns("GrossAmt").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgKOTItemList.Columns("GrossAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgKOTItemList.RowHeadersWidth = 20

        labelKOTModificationItemDetails.Text = "Item for KOT No. " & _KOTNo

        StrSql = "select ISNULL(sum(KB.Qty),0)" & _
        " FROM FB_KOTBody KB where KB.KOTNo=" & _KOTNo & " and KB.yearCode=" & _YearCode & " and KB.LocationCode=" & _LocationCode
        lblTotalOriginalQty.Text = ObjDatabase.ExecuteScalarN(StrSql).ToString("####0.00")

        StrSql = "SELECT ISNULL(sum(Convert(decimal(18,2),((KB.Qty*KB.Rate-KB.Qty*KB.Rate*DiscountPer*0.01) + (KB.Qty*KB.Rate-KB.Qty*KB.Rate*DiscountPer*0.01) * KB.TaxPer * 0.01 + (KB.Qty*KB.Rate-KB.Qty*KB.Rate*KB.DiscountPer*0.01) * KB.SCPer * 0.01))),0) as [GrossAmt]" & _
        " FROM FB_KOTBody KB where KB.KOTNo=" & _KOTNo & " and KB.yearCode=" & _YearCode & " and KB.LocationCode=" & _LocationCode
        lblTotalOriginalKOTAmt.Text = ObjDatabase.ExecuteScalarN(StrSql).ToString("####0.00")
        btnRefresh.Enabled = True
        EnableControl(PanelModifyKOT)
    End Sub

#End Region

    Private Sub btnMoveKOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimate.Click
        ClearControlsAfterCheckSave()
        BillEstimate = 1
        btnRefresh.Enabled = True
        EnableControl(PanelItem)
        PanelItem.Enabled = True
        txtItemCode.Focus()
    End Sub

#Region "Discount"
    Private Sub DiscPercentage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscAlcoholicPer.KeyPress, txtDiscNonAlcoholicPer.KeyPress, txtDiscFoodPer.KeyPress, txtDiscAlcoholicAmt.KeyPress, txtDiscNonAlcoholicAmt.KeyPress, txtDiscFoodAmt.KeyPress
        ValidateWholeNumberInput(sender, e)
    End Sub

    Private Sub txtDiscFoodPer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscFoodPer.Validated
        If Val(txtDiscFoodPer.Text) > 100 Or Val(txtDiscFoodPer.Text) < 0 Then
            ErrorProvider1.SetError(txtDiscFoodPer, "Invalid Disc Per")
            txtDiscFoodPer.Text = ""
            txtDiscFoodPer.Focus()
        End If
        If txtDiscFoodPer.Text = "" Then txtDiscFoodPer.Text = "0.00"
        DiscountAmt = CalculateDiscountAmt(FoodItemGroup, Val(txtDiscFoodPer.Text)).ToString(NumFormat)
        txtDiscFoodAmt.Text = DiscountAmt
        lblDiscFood.Text = DiscountAmt
        CalculateAmtAfterDiscount()
    End Sub

    Private Sub txtDiscNonAlcoholicPer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscNonAlcoholicPer.Validated
        If Val(txtDiscNonAlcoholicPer.Text) > 100 Or Val(txtDiscNonAlcoholicPer.Text) < 0 Then
            ErrorProvider1.SetError(txtDiscNonAlcoholicPer, "Invalid Disc Per")
            txtDiscNonAlcoholicPer.Text = ""
            txtDiscNonAlcoholicPer.Focus()
        End If
        If txtDiscNonAlcoholicPer.Text = "" Then txtDiscNonAlcoholicPer.Text = "0.00"
        DiscountAmt = CalculateDiscountAmt(NonAlcoholicItemGroup, Val(txtDiscNonAlcoholicPer.Text)).ToString(NumFormat)
        txtDiscNonAlcoholicAmt.Text = DiscountAmt
        lblDiscNonAlcoholic.Text = DiscountAmt
        CalculateAmtAfterDiscount()
    End Sub

    Private Sub txtDiscNonAlcoholicAmt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscNonAlcoholicAmt.Validated
        If Val(txtDiscNonAlcoholicAmt.Text) < 0 Then
            ErrorProvider1.SetError(txtDiscNonAlcoholicAmt, "Invalid Disc Amt")
            txtDiscNonAlcoholicAmt.Text = ""
            txtDiscNonAlcoholicAmt.Focus()
        End If
        If txtDiscNonAlcoholicAmt.Text = "" Then txtDiscAlcoholicAmt.Text = "0.00"
        txtDiscNonAlcoholicPer.Text = CalculateDiscountPer(NonAlcoholicItemGroup, Val(txtDiscNonAlcoholicAmt.Text)).ToString(NumFormat)
        txtDiscNonAlcoholicPer_Validated(sender, e)
        CalculateAmtAfterDiscount()
    End Sub


    Private Sub txtDiscAlcoholicPer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscAlcoholicPer.Validated
        If Val(txtDiscAlcoholicPer.Text) > 100 Or Val(txtDiscAlcoholicPer.Text) < 0 Then
            ErrorProvider1.SetError(txtDiscAlcoholicPer, "Invalid Disc Per")
            txtDiscAlcoholicPer.Text = ""
            txtDiscAlcoholicPer.Focus()
        End If
        If txtDiscAlcoholicPer.Text = "" Then txtDiscAlcoholicPer.Text = "0.00"
        DiscountAmt = CalculateDiscountAmt(AlcoholicItemGroup, Val(txtDiscAlcoholicPer.Text)).ToString(NumFormat)
        txtDiscAlcoholicAmt.Text = DiscountAmt
        lblDiscAlcoholic.Text = DiscountAmt
        CalculateAmtAfterDiscount()
    End Sub

    Private Sub txtDiscAlcoholicAmt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscAlcoholicAmt.Validated
        If Val(txtDiscAlcoholicAmt.Text) < 0 Then
            ErrorProvider1.SetError(txtDiscAlcoholicAmt, "Invalid Disc Amt")
            txtDiscAlcoholicAmt.Text = ""
            txtDiscAlcoholicAmt.Focus()
        End If
        If txtDiscAlcoholicAmt.Text = "" Then txtDiscAlcoholicAmt.Text = "0.00"
        txtDiscAlcoholicPer.Text = CalculateDiscountPer(AlcoholicItemGroup, Val(txtDiscAlcoholicAmt.Text)).ToString(NumFormat)
        txtDiscAlcoholicPer_Validated(sender, e)
        CalculateAmtAfterDiscount()
    End Sub

    Private Sub CalculateAmtAfterDiscount()
        Dim DiscPer As Double = 0
        Dim VATAmt1 As Double = 0
        Dim VATAmt2 As Double = 0
        Dim VATAmt3 As Double = 0
        Dim SCAmt1 As Double = 0
        Dim SCAmt2 As Double = 0
        Dim SCAmt3 As Double = 0
        Dim GSTAmt1 As Double = 0
        Dim GSTAmt2 As Double = 0
        Dim GSTAmt3 As Double = 0
        labelBillDiscountAmount.Text = Val(Val(lblDiscFood.Text) + Val(lblDiscAlcoholic.Text) + Val(lblDiscNonAlcoholic.Text)).ToString(NumFormat)

        DiscPer = Val(txtDiscAlcoholicPer.Text)
        If DiscPer >= 0 Then
            StrSql = "SELECT isnull(Sum((KB.Qty*KB.Rate)*(100-" & DiscPer & ")*0.01*(TaxPer)*0.01),0) as Amount" & _
            " from FB_KOTBody KB , FB_BillBody BB where KB.itemcode in(Select itemcode from IM_ItemMaster" & _
            " where ItemGroup in(" & AlcoholicItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
            " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_CODE & " and KB.TaxType='VAT'"
            VATAmt1 = ObjDatabase.ExecuteScalarN(StrSql)

            StrSql = "SELECT isnull(Sum((KB.Qty*KB.Rate)*(100-" & DiscPer & ")*0.01*(SCPer)*0.01),0) as Amount" & _
            " from FB_KOTBody KB , FB_BillBody BB where KB.itemcode in(Select itemcode from IM_ItemMaster" & _
            " where ItemGroup in(" & AlcoholicItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
            " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_CODE
            SCAmt1 = ObjDatabase.ExecuteScalarN(StrSql)

            StrSql = "SELECT isnull(Sum((KB.Qty*KB.Rate)*(100-" & DiscPer & ")*0.01*(TaxPer)*0.01),0) as Amount" & _
            " from FB_KOTBody KB , FB_BillBody BB where KB.itemcode in(Select itemcode from IM_ItemMaster" & _
            " where ItemGroup in(" & AlcoholicItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
            " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_CODE & " and KB.TaxType='GST'"
            GSTAmt1 = ObjDatabase.ExecuteScalarN(StrSql)
        End If

        DiscPer = Val(txtDiscNonAlcoholicPer.Text)
        If DiscPer >= 0 Then
            StrSql = "SELECT isnull(Sum((KB.Qty*KB.Rate)*(100-" & DiscPer & ")*0.01*(TaxPer)*0.01),0) as Amount" & _
            " from FB_KOTBody KB , FB_BillBody BB where KB.itemcode in(Select itemcode from IM_ItemMaster" & _
            " where ItemGroup in(" & NonAlcoholicItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
            " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_CODE & " and KB.TaxType='VAT'"
            VATAmt2 = ObjDatabase.ExecuteScalarN(StrSql)

            StrSql = "SELECT isnull(Sum((KB.Qty*KB.Rate)*(100-" & DiscPer & ")*0.01*(SCPer)*0.01),0) as Amount" & _
            " from FB_KOTBody KB , FB_BillBody BB where KB.itemcode in(Select itemcode from IM_ItemMaster" & _
            " where ItemGroup in(" & NonAlcoholicItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
            " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_CODE
            SCAmt2 = ObjDatabase.ExecuteScalarN(StrSql)

            StrSql = "SELECT isnull(Sum((KB.Qty*KB.Rate)*(100-" & DiscPer & ")*0.01*(TaxPer)*0.01),0) as Amount" & _
            " from FB_KOTBody KB , FB_BillBody BB where KB.itemcode in(Select itemcode from IM_ItemMaster" & _
            " where ItemGroup in(" & NonAlcoholicItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
            " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_CODE & " and KB.TaxType='GST'"
            GSTAmt2 = ObjDatabase.ExecuteScalarN(StrSql)
        End If

        DiscPer = Val(txtDiscFoodPer.Text)
        If DiscPer >= 0 Then
            StrSql = "SELECT isnull(Sum((KB.Qty*KB.Rate)*(100-" & DiscPer & ")*0.01*(TaxPer)*0.01),0) as Amount" & _
            " from FB_KOTBody KB , FB_BillBody BB where KB.itemcode in(Select itemcode from IM_ItemMaster" & _
            " where ItemGroup in(" & FoodItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
            " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_CODE & " and KB.TaxType='VAT'"
            VATAmt3 = ObjDatabase.ExecuteScalarN(StrSql)

            StrSql = "SELECT isnull(Sum((KB.Qty*KB.Rate)*(100-" & DiscPer & ")*0.01*(SCPer)*0.01),0) as Amount" & _
            " from FB_KOTBody KB , FB_BillBody BB where KB.itemcode in(Select itemcode from IM_ItemMaster" & _
            " where ItemGroup in(" & FoodItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
            " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_CODE
            SCAmt3 = ObjDatabase.ExecuteScalarN(StrSql)

            StrSql = "SELECT isnull(Sum((KB.Qty*KB.Rate)*(100-" & DiscPer & ")*0.01*(TaxPer)*0.01),0) as Amount" & _
            " from FB_KOTBody KB , FB_BillBody BB where KB.itemcode in(Select itemcode from IM_ItemMaster" & _
            " where ItemGroup in(" & FoodItemGroup & ")) and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
            " and BB.BillNo=" & Val(lblBillNo.Text) & " AND BB.[YearCode]=" & YearCode & " AND BB.[LocationCode]=" & LOCATION_CODE & " and KB.TaxType='GST'"
            GSTAmt3 = ObjDatabase.ExecuteScalarN(StrSql)
        End If



        labelBillVATAmount.Text = Val(VATAmt1 + VATAmt2 + VATAmt3).ToString(NumFormat)
        labelBillSCAmount.Text = Val(SCAmt1 + SCAmt2 + SCAmt3).ToString(NumFormat)
        labelBillGSTAmount.Text = Val(Val(GSTAmt1 + GSTAmt2 + GSTAmt3) + Val(labelBillSCAmount.Text) * GSTPerOnServiceCharge * 0.01).ToString(NumFormat)
        labelBillNetAmount.Text = Val(labelBillBasicAmount.Text) - Val(labelBillDiscountAmount.Text) + Val(labelBillVATAmount.Text) + Val(labelBillSCAmount.Text) + Val(labelBillGSTAmount.Text)

        AmtBeforeRoundOff = Val(labelBillNetAmount.Text)
        AmtAfterRoundOff = Math.Round(AmtBeforeRoundOff + 0.01, 0)
        RoundOff = Math.Round((AmtAfterRoundOff - AmtBeforeRoundOff), 2)
        labelBillRoundOff.Text = RoundOff.ToString(NumFormat)
        labelBillGrossAmount.Text = AmtAfterRoundOff.ToString(NumFormat)
        labelBillPayModeClosingAmount.Text = Val(labelBillPayModeOpeningAmount.Text) - Val(labelBillGrossAmount.Text)
        lblGSTAmt.Text = labelBillGSTAmount.Text
        lblROff.Text = labelBillRoundOff.Text
        lblGrossAmt.Text = labelBillGrossAmount.Text
    End Sub


    Private Sub txtDiscFoodAmt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscFoodAmt.Validated
        If Val(txtDiscFoodAmt.Text) < 0 Then
            ErrorProvider1.SetError(txtDiscFoodAmt, "Invalid Disc Amt")
            txtDiscFoodAmt.Text = ""
            txtDiscFoodAmt.Focus()
        End If
        If txtDiscFoodAmt.Text = "" Then txtDiscFoodAmt.Text = "0.00"
        txtDiscFoodPer.Text = CalculateDiscountPer(FoodItemGroup, Val(txtDiscFoodAmt.Text)).ToString(NumFormat)
        txtDiscFoodPer_Validated(sender, e)
        CalculateAmtAfterDiscount()
    End Sub
#End Region

    Private Sub cmbTableNoSC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTableNoSC.Validated
        If cmbTableNoSC.SelectedValue > 0 Then
            StrSql = "select Billno from FB_TableStatus where TableCode=" & cmbTableNoSC.SelectedValue & " and LocationCode=" & cmbLocation.SelectedValue
            BillNo = ObjDatabase.ExecuteScalarN(StrSql)
            If BillNo > 0 Then
                PopulateTables(cmbLocation.SelectedValue, cmbLocation.SelectedValue, 1)
                cmbTable.SelectedValue = cmbTableNoSC.SelectedValue
                btnSaveNSettle.Enabled = True
                lblBillNo.Text = BillNo
                ObjDatabase.ConnectDatabse()
                cmbWaiter.SelectedValue = ObjDatabase.ExecuteScalarN("Select WaiterCode from FB_BillHead where BillNo=" & BillNo & " and YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code)
                txtMemID.Text = ObjDatabase.ExecuteScalarS("Select MemberID from FB_BillHead H where H.BillNo=" & BillNo & " and H.YearCode=" & YearCode & " and H.LocationCode=" & LOCATION_Code)
                lblIssueNo.Text = ObjDatabase.ExecuteScalarS("Select IssueNo from FB_BillHead H where H.BillNo=" & BillNo & " and H.YearCode=" & YearCode & " and H.LocationCode=" & LOCATION_Code)
                BILL_TYPE = ObjDatabase.ExecuteScalarS("Select ValidationMode from FB_BillHead H where H.BillNo=" & BillNo & " and H.YearCode=" & YearCode & " and H.LocationCode=" & LOCATION_Code)
                lblValidationMode.Text = BILL_TYPE
                Memtype = GetMemberType(txtMemID.Text)
                MemberID = txtMemID.Text.Trim
                lblMemID.Text = MemberID
                If Memtype.ToUpper = "NONMEMBER" Then
                    CardValidity = Now
                    StrSql = "SELECT isnull(ValidUpto,getdate()) from CM_CardIssue where IssueNo=" & Val(lblIssueNo.Text)
                    CardValidity = ObjDatabase.ExecuteScalar(StrSql)
                    If CDate(CurrentBusinessDate.ToString("dd/MMM/yyyy")) > CDate(CardValidity.ToString("dd/MMM/yyyy")) Then
                        MsgBox("Validity of the SmartCard has expired", MsgBoxStyle.Critical)
                        ClearControlsAfterCheckSave()
                    End If
                    lblSmartCardOpeningBalance.Text = GetSmartCardClosingBalance(txtMemID.Text).ToString(NumFormat)
                    lblSmartCardClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                    lblOpeningCreditLimit.Text = "NA"
                    lblMemberAcClosingBalance.Text = "NA"
                Else
                    lblSmartCardOpeningBalance.Text = GetSmartCardClosingBalance(txtMemID.Text).ToString(NumFormat)
                    lblSmartCardClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                    lblOpeningCreditLimit.Text = GetCreditLimit(txtMemID.Text).ToString(NumFormat)
                    lblMemberAcClosingBalance.Text = GetAvailableCreditLimit(txtMemID.Text).ToString(NumFormat)

                End If
                lblIssueNo.Text = ObjDatabase.ExecuteScalarS("Select IssueNo from FB_BillHead H where H.BillNo=" & BillNo & " and H.YearCode=" & YearCode & " and H.LocationCode=" & LOCATION_Code)
                lblMemberName.Text = ObjDatabase.ExecuteScalarS("Select MemberName from FB_BillHead BH where BH.BillNo=" & BillNo & " and BH.YearCode=" & YearCode & " and BH.LocationCode=" & LOCATION_Code)
                txtPAX.Text = ObjDatabase.ExecuteScalarN("Select PAX from FB_BillHead where BillNo=" & BillNo & " and YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code)
                btnShiftTable.Enabled = True
                btnSettleBillHomePage.Enabled = True
                btnSaveNSettle.Enabled = False
                btnRefresh.Enabled = True
                PanelLocationAndTables.Visible = False
                PanelRight.Visible = True
                EnableControl(PanelItem)
                If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True
                txtItemCode.Focus()
                ObjDatabase.CloseDatabaseConnection()
                KOTType = "A"
                btnShowTables.Text = "SAVE"
                cmbTable.SelectedValue = cmbTableNoSC.SelectedValue
            Else
                MemberID = Trim(RFIDMemberID)
                ReturnValue = 0
                If MemberID.Contains("-") = False Then
                    If FlagOTPValidation.ToUpper = "NO" Then
                        MsgBox("Unable to Read card on the card Reader", MsgBoxStyle.Critical)
                        ClearControlsAfterCheckSave()
                        Exit Sub
                    End If
                    EnableControl(PanelMemberDetails)
                    EnableControl(PanelItem)
                    btnSendOTP.Text = "Send OTP"
                    BILL_TYPE = "OTP"
                    lblValidationMode.Text = BILL_TYPE
                    lblCardID.Text = MemberID
                    cmbLocation.Enabled = False
                    cmbTable.Enabled = False
                    PanelLocationAndTables.Visible = False
                    PanelItem.Enabled = True
                    PanelRight.Visible = True
                    If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True
                    btnShiftTable.Enabled = True
                    btnRefresh.Enabled = True
                    txtMemID.Enabled = True
                    txtMemID.Focus()
                    Exit Sub
                ElseIf MemberID.Contains("MC") = True Then
                    ReturnValue = ValidateMemberCard(CardSerialNo, MemberID)
                    If ReturnValue = 101 Then
                        MsgBox("Invalid Card. Card does not exist in the Card issued database", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    EnableControl(PanelMemberDetails)
                    EnableControl(PanelItem)
                    BILL_TYPE = "MC"
                    lblValidationMode.Text = BILL_TYPE
                    btnSendOTP.Text = "Send OTP"
                    btnSendOTP.Enabled = False
                    lblCardID.Text = MemberID
                    cmbLocation.Enabled = False
                    cmbTable.Enabled = False
                    PanelLocationAndTables.Visible = False
                    PanelItem.Enabled = True
                    PanelRight.Visible = True
                    If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True
                    btnShiftTable.Enabled = True
                    btnRefresh.Enabled = True
                    txtMemID.Enabled = True
                    txtMemID.Focus()
                    Exit Sub
                Else
                    ReturnValue = ValidateMemberCard(CardSerialNo, MemberID)
                    Select Case ReturnValue
                        Case 101
                            MsgBox("Invalid Card. Card does not exist in the Card issued database", MsgBoxStyle.Critical)
                            Exit Sub
                        Case 102
                            MsgBox("Member status is not allowed for transaction", MsgBoxStyle.Critical)
                            Exit Sub
                        Case 103
                            MsgBox("Card is not Active for Transactions", MsgBoxStyle.Critical)
                            Exit Sub
                        Case 100
                            txtMemID.Text = MemberID
                            DisplayMemberPics(txtMemID.Text)
                            ds = New DataSet
                            ds = GetSmartCardBalance(txtMemID.Text)
                            If ds.Tables(0).Rows.Count > 0 Then
                                MainID = ds.Tables(0).Rows(0)("MainID")
                                MemberName = ds.Tables(0).Rows(0)("MemberName")
                                IssueID = ds.Tables(0).Rows(0)("IssuedID")
                                IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                                ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                                lblMemberName.Text = MemberName
                                lblSmartCardOpeningBalance.Text = ClosingBalance
                                lblSmartCardClosingBalance.Text = ClosingBalance
                                lblIssueNo.Text = IssueNo
                            End If
                            Memtype = GetMemberType(txtMemID.Text)
                            lblMainScreebCitizenType.Text = GetCitizenType(txtMemID.Text)
                            If Memtype.ToUpper = "NONMEMBER" Then
                                CardValidity = Now
                                StrSql = "SELECT isnull(ValidUpto,getdate()) from CM_CardIssue where IssueNo=" & Val(lblIssueNo.Text)
                                CardValidity = ObjDatabase.ExecuteScalar(StrSql)

                                If CDate(CurrentBusinessDate.ToString("dd/MMM/yyyy")) > CDate(CardValidity.ToString("dd/MMM/yyyy")) Then
                                    MsgBox("Validity of the SmartCard has expired", MsgBoxStyle.Critical)
                                    ClearControlsAfterCheckSave()
                                End If
                                lblSmartCardOpeningBalance.Text = GetSmartCardClosingBalance(txtMemID.Text).ToString(NumFormat)
                                lblSmartCardClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                                lblOpeningCreditLimit.Text = "NA"
                                lblMemberAcClosingBalance.Text = "NA"
                            Else
                                lblSmartCardOpeningBalance.Text = GetSmartCardClosingBalance(txtMemID.Text).ToString(NumFormat)
                                lblSmartCardClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                                lblOpeningCreditLimit.Text = GetCreditLimit(txtMemID.Text).ToString(NumFormat)
                                lblMemberAcClosingBalance.Text = GetAvailableCreditLimit(txtMemID.Text).ToString(NumFormat)
                            End If
                    End Select
                    Dim Main_Id As String = GetMainID(txtMemID.Text)
                    lblOpenBillString.Text = "Open Bill Amt."
                    lblBillAmtPerviousKOT.Text = ObjDatabase.ExecuteScalarS("Select isnull(sum(Amount),0) from FB_BillHead H where H.BillDate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' and BillStatus=0 and MemberID like '" & Main_Id.Trim() & "%'")
                    EnableControl(PanelMemberDetails)
                    EnableControl(PanelItem)
                    BILL_TYPE = "SMARTCARD"
                    lblValidationMode.Text = BILL_TYPE
                    btnSendOTP.Text = "Send OTP"
                    btnSendOTP.Enabled = False
                    lblCardID.Text = MemberID
                    cmbLocation.Enabled = False
                    cmbTable.Enabled = False
                    PanelLocationAndTables.Visible = False
                    PanelItem.Enabled = True
                    PanelRight.Visible = True
                    If EditRight = 0 Then btnModifyKOT.Enabled = False Else btnModifyKOT.Enabled = True
                    btnShiftTable.Enabled = True
                    btnRefresh.Enabled = True
                    txtMemID.Enabled = False
                    cmbWaiter.SelectedValue = 0
                    cmbWaiter.Focus()
                    cmbTable.SelectedValue = cmbTableNoSC.SelectedValue
                    KOTType = "N"
                    btnShowTables.Text = "SAVE"
                    cmbTableNoSC.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub txtMemIDSC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMemIDSC.TextChanged
        If dgHistory.Tag = "History" Then
            BindClosedBills()
        Else
            BindOpenBills()
        End If
    End Sub

    Private Sub txtItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemCode.TextChanged

    End Sub

    Private Function SubCheckStockBefore(ByVal ItemCode As Integer) As Integer
        Dim FlagStock As Integer = 1
        LabelClosingStock.Text = ""
        CheckStock = ObjDatabase.ExecuteScalarN("Select isnull(CheckStock,0) from IM_ItemMaster where ItemCode=" & Val(ItemCode))
        If Val(CheckStock) = 1 And LOCATION_TYPE.ToUpper().Contains("POS BAR") = True Then
            Dim DS1, DS_ItemName As DataSet
            Dim BilledQty As Double = 0
            Dim liQuantity As Integer = 0

            For i As Int16 = 0 To dgItemGrid.RowCount - 1
                If dgItemGrid.Item("ItemCode", i).Value = Val(ItemCode) Then
                    BilledQty = BilledQty + dgItemGrid.Item("Qty", i).Value
                End If
            Next

            QtyCanBeSold = New ArrayList
            ds = ObjDatabase.BindDataSet("Select MainItemCode,BOMItemQty from IM_ItemBOMMaster where BOMItemCode=" & Val(ItemCode) & "", "BOM")
            If ds.Tables("BOM").Rows.Count > 0 Then
                Dim i As Integer = 0
                For i = 0 To ds.Tables("BOM").Rows.Count - 1
                    StrSql = "Proc_SubStoreStockItem " & Val(ds.Tables("BOM").Rows(i)("MainItemCode")) & "," & Val(SUBSTORE_Code) & ""
                    ObjDatabase.BindDataSet(StrSql, "Data")
                    ObjDatabase.ConnectDatabse()
                    ObjDatabase.OpenDatabaseConnection()
                    StrSql = "select S.[ClosingStock], I.ItemName from IM_SubStoreStockItem S, IM_ItemMaster I where S.itemCode=" & Val(ds.Tables("BOM").Rows(i)(0)) & " and S.ItemCode=I.ItemCode"
                    DS1 = ObjDatabase.BindDataSet(StrSql, "checkqty")
                    If DS1.Tables("checkqty").Rows.Count > 0 Then
                        LabelClosingStock.Text = Val(DS1.Tables("checkqty").Rows(0)("ClosingStock"))
                        LabelClosingStock.Text = Math.Round(Val(LabelClosingStock.Text), 2)
                        If Val(DS1.Tables("checkqty").Rows(0)(0)) < (Val(ds.Tables("BOM").Rows(i)("bomitemqty")) * Val(txtQty.Text)) Then
                            DS_ItemName = ObjDatabase.BindDataSet("Select ItemName from IM_ItemMaster where itemCode = " & Val(ds.Tables("BOM").Rows(i)("mainitemCode")) & "", "ItemName")
                            If DS_ItemName.Tables("ItemName").Rows.Count > 0 Then
                                FlagStock = 0
                                MsgBox("Stock not available for: " & vbCrLf & DS_ItemName.Tables("ItemName").Rows(0)("ItemName"), MsgBoxStyle.Information, "INFORMATION")
                                txtQty.Text = ""
                                txtItemCode.Text = ""
                                txtItemCode.Focus()
                            End If
                            Exit Function
                        End If
                        QtyCanBeSold.Add(Val(DS1.Tables("checkqty").Rows(0)("ClosingStock")) / (Val(ds.Tables("BOM").Rows(i)("bomitemqty"))))
                    Else
                        FlagStock = 0
                        MsgBox("Stock not available", MsgBoxStyle.Information, "INFORMATION")
                        txtQty.Text = ""
                        txtItemCode.Text = ""
                        txtItemCode.Focus()
                        Exit Function
                    End If
                Next
            Else
                FlagStock = 0
                MsgBox("Recipe not defined for the selected item", MsgBoxStyle.Information, "INFORMATION")
                cmbItemName.Focus()
                Exit Function
            End If
            LabelClosingStock.Visible = True
            If QtyCanBeSold.Count > 0 Then
                LabelClosingStock.Text = QtyCanBeSold(0)
                LabelClosingStock.Text = Val(LabelClosingStock.Text)
                LabelClosingStock.Visible = True
                LabelClosingStock.Text = LabelClosingStock.Text & " " & lblUnit.Text.Trim
            End If
            QtyCanBeSold.Sort()
        End If
        SubCheckStockBefore = FlagStock
    End Function

    Private Function SubCheckStock(ByVal ItemCode As Integer) As Integer
        Dim FlagStock As Integer = 1
        LabelClosingStock.Text = ""
        CheckStock = ObjDatabase.ExecuteScalarN("Select isnull(CheckStock,0) from IM_ItemMaster where ItemCode=" & Val(ItemCode))
        If Val(CheckStock) = 1 And LOCATION_TYPE.ToUpper().Contains("POS BAR") = True Then
            Dim DS1, DS_ItemName As DataSet
            Dim BilledQty As Double = 0
            Dim liQuantity As Integer = 0

            For i As Int16 = 0 To dgItemGrid.RowCount - 1
                If dgItemGrid.Item("ItemCode", i).Value = Val(ItemCode) Then
                    BilledQty = BilledQty + dgItemGrid.Item("Qty", i).Value
                End If
            Next

            QtyCanBeSold = New ArrayList
            ds = ObjDatabase.BindDataSet("Select MainItemCode,BOMItemQty from IM_ItemBOMMaster where BOMItemCode=" & Val(ItemCode) & "", "BOM")
            If ds.Tables("BOM").Rows.Count > 0 Then
                Dim i As Integer = 0
                For i = 0 To ds.Tables("BOM").Rows.Count - 1
                    StrSql = "Proc_SubStoreStockItem " & Val(ds.Tables("BOM").Rows(i)("MainItemCode")) & "," & Val(SUBSTORE_Code) & ""
                    ObjDatabase.BindDataSet(StrSql, "Data")
                    ObjDatabase.ConnectDatabse()
                    ObjDatabase.OpenDatabaseConnection()
                    StrSql = "select S.[ClosingStock], I.ItemName from IM_SubStoreStockItem S, IM_ItemMaster I where S.itemCode=" & Val(ds.Tables("BOM").Rows(i)(0)) & " and S.ItemCode=I.ItemCode"
                    DS1 = ObjDatabase.BindDataSet(StrSql, "checkqty")
                    If DS1.Tables("checkqty").Rows.Count > 0 Then
                        LabelClosingStock.Text = Val(DS1.Tables("checkqty").Rows(0)("ClosingStock"))
                        LabelClosingStock.Text = Math.Round(Val(LabelClosingStock.Text), 2)
                        If Val(DS1.Tables("checkqty").Rows(0)(0)) < (Val(ds.Tables("BOM").Rows(i)("bomitemqty")) * Val(txtQty.Text) + BilledQty) Then
                            DS_ItemName = ObjDatabase.BindDataSet("Select ItemName from IM_ItemMaster where itemCode = " & Val(ds.Tables("BOM").Rows(i)("mainitemCode")) & "", "ItemName")
                            If DS_ItemName.Tables("ItemName").Rows.Count > 0 Then
                                FlagStock = 0
                                MsgBox("Stock not available for: " & vbCrLf & DS_ItemName.Tables("ItemName").Rows(0)("ItemName"), MsgBoxStyle.Information, "INFORMATION")
                                txtQty.Text = ""
                                txtItemCode.Text = ""
                                txtItemCode.Focus()
                            End If
                            Exit Function
                        End If
                        QtyCanBeSold.Add(Val(DS1.Tables("checkqty").Rows(0)("ClosingStock")) / (Val(ds.Tables("BOM").Rows(i)("bomitemqty"))))
                    Else
                        FlagStock = 0
                        MsgBox("Stock not available", MsgBoxStyle.Information, "INFORMATION")
                        txtQty.Text = ""
                        txtItemCode.Text = ""
                        txtItemCode.Focus()
                        Exit Function
                    End If
                Next
            Else
                FlagStock = 0
                MsgBox("Recipe not defined for the selected item", MsgBoxStyle.Information, "INFORMATION")
                cmbItemName.Focus()
                Exit Function
            End If
            LabelClosingStock.Visible = True
            If QtyCanBeSold.Count > 0 Then
                LabelClosingStock.Text = QtyCanBeSold(0)
                LabelClosingStock.Text = Val(LabelClosingStock.Text) - Val(txtQty.Text)
                LabelClosingStock.Visible = True
                LabelClosingStock.Text = LabelClosingStock.Text & " " & lblUnit.Text.Trim
            End If
            QtyCanBeSold.Sort()
        End If
        SubCheckStock = FlagStock
    End Function

    Private Sub btnItemModifierOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemModifierOK.Click
        For Each dr As DataRow In dtKOTItems.Rows
            If dr.Item("ItemCode") = Val(ModifierItemCode) Then
                dr.Item("Remarks") = txtKOTRemarks.Text
                Exit For
            End If
        Next
        dtKOTItems.AcceptChanges()
        PanelModifiers.Visible = False
        Message = "Adding KOT Items"
        txtKOTRemarks.Text = ""
    End Sub

    Private Sub BindItemModifiers()
        Try
            Dim dsModifiers As New DataSet
            StrSql = "SELECT ModifierName FROM FB_KOTModifiers where Status='Active'"
            dsModifiers = ObjDatabase.BindDataSet(StrSql, "Bills")
            dgModifiers.DataSource = dsModifiers.Tables("Bills")
            dgModifiers.RowHeadersWidth = 20
            dgModifiers.RowTemplate.Height = 50
            FormatDataGridView(dgModifiers)
            dgModifiers.Columns("ModifierName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgModifiers.Columns("ModifierName").HeaderText = "Modifier Name"
            dgModifiers.Columns("ModifierName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgModifiers.Columns("ModifierName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgModifiers.RowHeadersVisible = True
            dgModifiers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgModifiers.Columns(0).Visible = True
            dgModifiers.RowHeadersWidth = 20
            dgModifiers.RowTemplate.Height = 50
            Message = "Displaying Item Modifiers"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgModifiers_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgModifiers.CellContentClick
        Dim ModifierName As String = dgModifiers.Rows(dgModifiers.CurrentRow.Index).Cells("ModifierName").Value()
        If txtKOTRemarks.Text.Contains(ModifierName) = False Then
            If txtKOTRemarks.Text = "" Then
                txtKOTRemarks.Text = ModifierName
            Else
                txtKOTRemarks.Text &= ", " & ModifierName
            End If
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtKOTRemarks.Text = ""
    End Sub

    Private Sub btnDismiss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDismiss.Click
        PanelModifiers.Visible = False
        ModifierItemCode = ""
    End Sub

    Private Sub btnModifiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifiers.Click
        If ModifierItemCode Is Nothing Then
            Message = "Select Item from the Item Grid"
            Exit Sub
        End If
        If ModifierItemCode = "" Or ModifierItemCode = "0" Then
            Message = "Select Item from the Item Grid"
            Exit Sub
        End If
        PanelModifiers.BringToFront()
        EnableControl(PanelModifiers)
        PanelModifiers.Visible = True
        BindItemModifiers()
        txtKOTRemarks.Text = ModifierRemarks
    End Sub


#Region "MoveTable"

    Private Sub BindItemGridForSourceTable()
        dsReq = New DataSet
        StrSql = "select 0 as SNo,0 as TempKOTNo,KB.KOTNO,KB.ItemCode,IM.Aliasname" & _
       " ,KB.ItemName, KB.UnitCode, UM.UnitName, sum(KB.Qty) Qty, KB.Rate ,sum(KB.Qty*KB.Rate) as [Amount]" & _
       " ,KB.TaxPer, sum((KB.Amount-KB.Amount*DiscountPer*0.01)*KB.TaxPer*0.01) as [TaxAmount]" & _
       " ,KB.SCPer, sum((KB.Amount-KB.Amount*DiscountPer*0.01)*KB.SCPer*0.01) as [SCAmount]" & _
       " ,sum(((KB.Qty*KB.Rate)-(KB.Qty*KB.Rate)*DiscountPer*0.01)+(((KB.Qty*KB.Rate)-(KB.Qty*KB.Rate)*DiscountPer*0.01)*KB.TaxPer*0.01)+(((KB.Qty*KB.Rate)-(KB.Qty*KB.Rate)*DiscountPer*0.01)*KB.SCPer*0.01)*" & (100 + GSTPerOnServiceCharge) * 0.01 & ") as [GrossAmt]" & _
       " ,getdate() as DisplayOrder,0 as OpenItem,DiscountPer, TaxType " & _
       " from FB_KOTBody KB ,IM_ItemMaster IM ,IM_UnitMaster UM, FB_BillHead BH, FB_BillBody BB" & _
       " where KB.ItemCode=IM.ItemCode AND KB.UnitCode=UM.Code and KB.QTY>0" & _
       " and BH.BillNo=BB.BillNo and BH.YearCode=BB.YearCode and BH.LocationCode=BB.LocationCode" & _
       " and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode" & _
       " and KB.LocationCode=" & LOCATION_Code & _
       " and BH.TableCode=" & Val(cmbSourceTable.SelectedValue) & " and BH.BillDate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' and BH.BillStatus=0" & _
       " group by KB.KOTNO,KB.ItemCode,KB.SCPer,DiscountPer, TaxType,KB.SCPer,KB.TaxPer,KB.ItemName, KB.UnitCode, UM.UnitName,KB.Rate" & _
       " order by KB.KOTNo,KB.ItemName"

        dsReq = ObjDatabase.BindDataSet(StrSql, "ITEM")
        dtSourceTable = dsReq.Tables("ITEM")
        dgSourceTable.DataSource = dtSourceTable
        FormatDataGridView(dgSourceTable)
        dgSourceTable.Columns("SCAmount").Visible = False
        dgSourceTable.Columns("SNo").Visible = False
        dgSourceTable.Columns("TempKOTNo").Visible = False
        dgSourceTable.Columns("OpenItem").Visible = False
        dgSourceTable.Columns("TaxType").Visible = False
        dgSourceTable.Columns("DisplayOrder").Visible = False
        dgSourceTable.Columns("UnitCode").Visible = False
        dgSourceTable.Columns("UnitName").HeaderText = "Unit"

        dgSourceTable.Columns("TaxPer").Visible = False
        dgSourceTable.Columns("TaxAmount").Visible = True
        dgSourceTable.Columns("SCPer").Visible = False
        dgSourceTable.Columns("SCPer").Visible = True
        dgSourceTable.Columns("GrossAmt").Visible = True
        dgSourceTable.Columns("KOTNo").HeaderText = "KOT#"
        dgSourceTable.Columns("KOTNo").Width = 60
        dgSourceTable.Columns("KOTNo").Visible = True
        dgSourceTable.Columns("ItemCode").Width = 50
        dgSourceTable.Columns("ItemName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgSourceTable.Columns("UnitName").Width = 50
        dgSourceTable.Columns("Qty").Width = 40
        dgSourceTable.Columns("Rate").Width = 70
        dgSourceTable.Columns("Amount").Width = 70
        dgSourceTable.Columns("Amount").HeaderText = "Amt"
        dgSourceTable.Columns("Amount").Visible = True
        dgSourceTable.Columns("TaxAmount").Width = 70
        dgSourceTable.Columns("TaxAmount").HeaderText = "TaxAmt"
        dgSourceTable.Columns("TaxAmount").Visible = False
        dgSourceTable.Columns("SCPer").Width = 60
        dgSourceTable.Columns("SCPer").Visible = False
        dgSourceTable.Columns("SCPer").HeaderText = "SCAmt"
        dgSourceTable.Columns("GrossAmt").Width = 80
        dgSourceTable.Columns("GrossAmt").HeaderText = "NetAmt"
        dgSourceTable.Columns("DiscountPer").Visible = False
        dgDestinationTable.Columns("ItemCode").Visible = False
        dgDestinationTable.Columns("ItemCode").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("Aliasname").HeaderText = "ItemCode"
        dgDestinationTable.Columns("Aliasname").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        dgSourceTable.Columns("ItemCode").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("Qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("Rate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("SCPer").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("TaxAmount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("ItemCode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("TaxAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("SCPer").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("GrossAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgSourceTable.Columns("GrossAmt").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        dgSourceTable.Columns("Qty").DefaultCellStyle.Format = "###"
        dgSourceTable.Columns("Rate").DefaultCellStyle.Format = NumberFormat
        dgSourceTable.Columns("Amount").DefaultCellStyle.Format = NumberFormat
        dgSourceTable.Columns("TaxAmount").DefaultCellStyle.Format = NumberFormat
        dgSourceTable.Columns("SCPer").DefaultCellStyle.Format = NumberFormat
        dgSourceTable.Columns("GrossAmt").DefaultCellStyle.Format = NumberFormat
        dgSourceTable.RowTemplate.Height = 25
        dgSourceTable.RowHeadersVisible = True
        dgSourceTable.RowHeadersWidth = 20
        dgSourceTable.Cursor = Cursors.Hand
        CalculateSourceTotalsBill()
        dgSourceTable.Enabled = True
        dgSourceTable.Columns("ItemName").SortMode = DataGridViewColumnSortMode.NotSortable
        dgSourceTable.Columns("ItemCode").SortMode = DataGridViewColumnSortMode.NotSortable
        dgSourceTable.Columns("Qty").SortMode = DataGridViewColumnSortMode.NotSortable
        dgSourceTable.Columns("UnitName").SortMode = DataGridViewColumnSortMode.NotSortable
        dgSourceTable.Columns("Rate").SortMode = DataGridViewColumnSortMode.NotSortable
        dgSourceTable.Columns("GrossAmt").SortMode = DataGridViewColumnSortMode.NotSortable

    End Sub

    Private Sub BindItemGridForDestinationTable()
        dsReq = New DataSet
        StrSql = "select 0 as SNo,0 as TempKOTNo,KB.KOTNO,KB.ItemCode,IM.Aliasname" & _
       " ,KB.ItemName, KB.UnitCode, UM.UnitName, sum(KB.Qty) Qty, KB.Rate ,sum(KB.Qty*KB.Rate) as [Amount]" & _
       " ,KB.TaxPer, sum((KB.Amount-KB.Amount*DiscountPer*0.01)*KB.TaxPer*0.01) as [TaxAmount]" & _
       " ,KB.SCPer, sum((KB.Amount-KB.Amount*DiscountPer*0.01)*KB.SCPer*0.01) as [SCAmount]" & _
       " ,sum(((KB.Qty*KB.Rate)-(KB.Qty*KB.Rate)*DiscountPer*0.01)+(((KB.Qty*KB.Rate)-(KB.Qty*KB.Rate)*DiscountPer*0.01)*KB.TaxPer*0.01)+((KB.Qty*KB.Rate)-(KB.Qty*KB.Rate)*DiscountPer*0.01)*KB.SCPer*0.01*" & (100 + GSTPerOnServiceCharge) * 0.01 & ") as [GrossAmt]" & _
       " ,getdate() as DisplayOrder,0 as OpenItem,DiscountPer, TaxType " & _
       " from FB_KOTBody KB ,IM_ItemMaster IM ,IM_UnitMaster UM, FB_BillHead BH, FB_BillBody BB" & _
       " where KB.ItemCode=IM.ItemCode AND KB.UnitCode=UM.Code and KB.QTY>0" & _
       " and BH.BillNo=BB.BillNo and BH.YearCode=BB.YearCode and BH.LocationCode=BB.LocationCode" & _
       " and KB.KOTNo=BB.KOTNo and KB.YearCode=BB.YearCode and KB.LocationCode=BB.LocationCode and BH.BillStatus=0" & _
       " and KB.LocationCode=" & LOCATION_Code & _
       " and BH.TableCode=" & Val(cmbDestinationTable.SelectedValue) & " and BH.BillDate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' and BH.BillNo=" & Val(lblDestinationBillNo.Text) & _
       " group by KB.KOTNO,KB.ItemCode,KB.SCPer,DiscountPer, TaxType,KB.SCPer,KB.TaxPer,KB.ItemName, KB.UnitCode, UM.UnitName,KB.Rate" & _
       " order by KB.KOTNo,KB.ItemName"

        dsReq = ObjDatabase.BindDataSet(StrSql, "ITEM")
        dtDestinationTable = dsReq.Tables("ITEM")
        dgDestinationTable.DataSource = dtDestinationTable
        FormatDataGridView(dgDestinationTable)
        '
        dgDestinationTable.Columns("SCAmount").Visible = False
        dgDestinationTable.Columns("SNo").Visible = False
        dgDestinationTable.Columns("TempKOTNo").Visible = False
        dgDestinationTable.Columns("OpenItem").Visible = False
        dgDestinationTable.Columns("TaxType").Visible = False
        dgDestinationTable.Columns("DisplayOrder").Visible = False
        dgDestinationTable.Columns("UnitCode").Visible = False
        dgDestinationTable.Columns("UnitName").HeaderText = "Unit"
        dgDestinationTable.Columns("TaxPer").Visible = False
        dgDestinationTable.Columns("TaxAmount").Visible = True
        dgDestinationTable.Columns("SCPer").Visible = False
        dgDestinationTable.Columns("SCPer").Visible = True
        dgDestinationTable.Columns("GrossAmt").Visible = True
        dgDestinationTable.Columns("KOTNo").HeaderText = "KOT#"
        dgDestinationTable.Columns("KOTNo").Width = 60
        dgDestinationTable.Columns("KOTNo").Visible = True
        dgDestinationTable.Columns("ItemCode").Width = 50
        dgDestinationTable.Columns("ItemName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgDestinationTable.Columns("UnitName").Width = 50
        dgDestinationTable.Columns("Qty").Width = 40
        dgDestinationTable.Columns("Rate").Width = 70
        dgDestinationTable.Columns("Amount").Width = 70
        dgDestinationTable.Columns("Amount").HeaderText = "Amt"
        dgDestinationTable.Columns("Amount").Visible = True
        dgDestinationTable.Columns("TaxAmount").Width = 70
        dgDestinationTable.Columns("TaxAmount").HeaderText = "TaxAmt"
        dgDestinationTable.Columns("TaxAmount").Visible = False
        dgDestinationTable.Columns("SCPer").Width = 60
        dgDestinationTable.Columns("SCPer").Visible = False
        dgDestinationTable.Columns("SCAmount").HeaderText = "SCAmt"
        dgDestinationTable.Columns("GrossAmt").Width = 80
        dgDestinationTable.Columns("GrossAmt").HeaderText = "NetAmt"
        dgDestinationTable.Columns("DiscountPer").Visible = False
        dgDestinationTable.RowHeadersVisible = True
        dgDestinationTable.RowHeadersWidth = 20
        dgDestinationTable.Columns("ItemCode").Visible = False
        dgDestinationTable.Columns("ItemCode").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("Aliasname").HeaderText = "ItemCode"
        dgDestinationTable.Columns("Aliasname").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("Qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("Rate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("SCPer").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("TaxAmount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("ItemCode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("TaxAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("SCPer").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("GrossAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgDestinationTable.Columns("GrossAmt").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        dgDestinationTable.Columns("Qty").DefaultCellStyle.Format = "###"
        dgDestinationTable.Columns("Rate").DefaultCellStyle.Format = NumberFormat
        dgDestinationTable.Columns("Amount").DefaultCellStyle.Format = NumberFormat
        dgDestinationTable.Columns("TaxAmount").DefaultCellStyle.Format = NumberFormat
        dgDestinationTable.Columns("SCPer").DefaultCellStyle.Format = NumberFormat
        dgDestinationTable.Columns("GrossAmt").DefaultCellStyle.Format = NumberFormat
        dgDestinationTable.RowTemplate.Height = 25
        dgDestinationTable.Cursor = Cursors.Hand
        dgDestinationTable.Enabled = True
        dgDestinationTable.Columns("ItemName").SortMode = DataGridViewColumnSortMode.NotSortable
        dgDestinationTable.Columns("ItemCode").SortMode = DataGridViewColumnSortMode.NotSortable
        dgDestinationTable.Columns("Qty").SortMode = DataGridViewColumnSortMode.NotSortable
        dgDestinationTable.Columns("UnitName").SortMode = DataGridViewColumnSortMode.NotSortable
        dgDestinationTable.Columns("Rate").SortMode = DataGridViewColumnSortMode.NotSortable
        dgDestinationTable.Columns("GrossAmt").SortMode = DataGridViewColumnSortMode.NotSortable
        ItemCountDestinationTable = dgDestinationTable.RowCount

        CalculateDestinationTotalsBill()
    End Sub

    Private Sub btnShiftKOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftKOT.Click
        If btnShiftKOT.Text = "SHIFT KOT" Then
            PanelModifiers.Visible = False
            btnShowTables.Enabled = False
            PanelMergeTables.Location = LeftPanelLocation
            BindComboboxWithSelectOneNumeric("select Code,TableNo from FB_TableMaster where Code in (Select TableCode from FB_BillHead where BillDate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' and BillStatus=0 and LocationCode=" & LOCATION_Code & ")", "Code", "TableNo", cmbSourceTable)
            EnableControl(PanelMergeTables)
            PanelRight.Visible = False
            PanelMergeTables.Visible = True
            cmbSourceTable.Focus()
            ActionType = "M"
            btnShiftKOT.Text = "SAVE"
            btnRefresh.Enabled = True
            BindItemGridForSourceTable()
            BindItemGridForDestinationTable()
            cmbSourceTable.SelectedValue = 0
            cmbDestinationTable.SelectedValue = 0
            cmbSourceTable.SelectedValue = cmbTable.SelectedValue
            cmbSourceTable_Validated(sender, e)
            cmbSourceTable.Enabled = False
            lblDestinationBillNo.Text = ""
            lblDestinationGrossAmt.Text = ""
            lblDestinationTotalQty.Text = ""
            btnShiftKOT.Enabled = True
            btnShiftTable.Enabled = False
            btnSettleBillHomePage.Enabled = False
            btnSaveNSettle.Enabled = False
            btnModifyKOT.Enabled = False
            btnHistory.Enabled = False
            btnShowTables.Text = "NEW BILL"
            btnModifiers.Enabled = False
            PanelClosedBills.Visible = False
        ElseIf btnShiftKOT.Text = "SAVE" Then
            If cmbSourceTable.SelectedValue = 0 Then
                MsgBox("Select Source Table No", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If cmbDestinationTable.SelectedValue = 0 Then
                MsgBox("Select Destination Table No", MsgBoxStyle.Critical)
                Exit Sub
            End If
            MergeTables()
            ClearControlsAfterCheckSave()
            ActionType = ""
            Exit Sub
        End If
    End Sub

    Private Sub ReadCardForNewBill()
        MemberID = Trim(RFIDMemberID)
        If MemberID.Trim() = "" Then
            MsgBox("Please place the card on the card Reader for Opening New Table", MsgBoxStyle.Information)
            Exit Sub
        End If
        ReturnValue = ValidateMemberCard(CardSerialNo, MemberID)
        Select Case ReturnValue
            Case 101
                MsgBox("Invalid Card. Card does not exist in the Card issued database", MsgBoxStyle.Critical)
                Exit Sub
            Case 102
                MsgBox("Member status is not allowed for transaction", MsgBoxStyle.Critical)
                Exit Sub
            Case 103
                MsgBox("Card is not Active for Transactions", MsgBoxStyle.Critical)
                Exit Sub
            Case 100
                lblDestinationMemID.Text = MemberID
                ds = New DataSet
                ds = GetSmartCardBalance(lblDestinationMemID.Text)
                If ds.Tables(0).Rows.Count > 0 Then
                    MainID = ds.Tables(0).Rows(0)("MainID")
                    MemberName = ds.Tables(0).Rows(0)("MemberName")
                    IssueID = ds.Tables(0).Rows(0)("IssuedID")
                    IssueNo = ds.Tables(0).Rows(0)("IssueNo")
                    ClosingBalance = ds.Tables(0).Rows(0)("ClosingBalance")
                    lblDestinationMemName.Text = MemberName
                    lblDestinationOpeningBalance.Text = ClosingBalance
                    lblDestinationClosingBalance.Text = ClosingBalance
                    lblDestinationIssueNo.Text = IssueNo
                    If IssueNo = 0 Then
                        MsgBox("No issue No linked with the selected Card_ID", MsgBoxStyle.Critical)
                        ClearControlsAfterCheckSave()
                    End If
                End If
                Memtype = GetMemberType(lblDestinationMemID.Text)
                If Memtype.ToUpper = "NONMEMBER" Then
                    CardValidity = Now
                    StrSql = "SELECT isnull(ValidUpto,getdate()) from CM_CardIssue where IssueNo=" & Val(lblDestinationIssueNo.Text)
                    CardValidity = ObjDatabase.ExecuteScalar(StrSql)
                    If CDate(CurrentBusinessDate.ToString("dd/MMM/yyyy")) > CDate(CardValidity.ToString("dd/MMM/yyyy")) Then
                        MsgBox("Validity of the SmartCard has expired", MsgBoxStyle.Critical)
                        ClearControlsAfterCheckSave()
                    End If
                    lblDestinationOpeningBalance.Text = GetSmartCardClosingBalance(lblDestinationMemID.Text).ToString(NumFormat)
                    lblDestinationClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                Else
                    lblDestinationOpeningBalance.Text = GetSmartCardClosingBalance(lblDestinationMemID.Text).ToString(NumFormat)
                    lblDestinationClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
                End If
        End Select
    End Sub

    Public Sub CalculateSourceTotalsBill()
        lblTotalQty.Text = ""
        lblTotalQty.Text = ""
        lblSubTotal.Text = ""
        lblSCAmt.Text = ""
        lblGSTAmt.Text = ""
        lblVATAmt.Text = ""
        lblDiscountAmt.Text = ""
        Dim TaxType As String = ""
        Dim ctr As Integer = 0
        Dim dtKOTItemDetails As DataTable
        Dim RQty, RAmount, RVATAmt, RDiscountAmt, RGSTAmt, RSCAmt, RTotalAmt, TaxPer, SCPer, DiscountPer As Double
        Dim Qty, Amount, GSTAmt, DiscountAmt, VATAmt, SCAmt, TotalAmt, AmtAfterDis, Rate As Double
        Qty = 0 : Amount = 0 : VATAmt = 0 : GSTAmt = 0 : SCAmt = 0 : TotalAmt = 0 : DiscountAmt = 0
        RQty = 0 : RAmount = 0 : RVATAmt = 0 : RGSTAmt = 0 : RSCAmt = 0 : RTotalAmt = 0 : RDiscountAmt = 0 : AmtAfterDis = 0
        VATAmt = 0 : GSTAmt = 0 : SCAmt = 0 : DiscountAmt = 0 : Amount = 0
        dtKOTItemDetails = CType(dgSourceTable.DataSource, DataTable)
        For ctr = 0 To dtKOTItemDetails.Rows.Count - 1
            RQty = Val(dtKOTItemDetails.Rows(ctr)("Qty"))
            Rate = Val(dtKOTItemDetails.Rows(ctr)("Rate"))
            SCPer = Val(dtKOTItemDetails.Rows(ctr)("SCPer"))
            TaxPer = Val(dtKOTItemDetails.Rows(ctr)("TaxPer"))
            TaxType = Trim(dtKOTItemDetails.Rows(ctr)("TaxType"))
            DiscountPer = Val(dtKOTItemDetails.Rows(ctr)("DiscountPer"))

            Qty += RQty
            RAmount = RQty * Rate
            Amount += RAmount
            RDiscountAmt = RAmount * DiscountPer * 0.01
            DiscountAmt += RDiscountAmt
            AmtAfterDis = RAmount - RDiscountAmt
            RSCAmt = AmtAfterDis * SCPer * 0.01
            SCAmt += RSCAmt
            RVATAmt = 0
            RGSTAmt = 0
            If TaxType = "VAT" Then
                RVATAmt = AmtAfterDis * TaxPer * 0.01 + RSCAmt * GSTPerOnServiceCharge * 0.01
            ElseIf TaxType = "GST" Then
                RGSTAmt = AmtAfterDis * TaxPer * 0.01 + RSCAmt * GSTPerOnServiceCharge * 0.01
            End If

            GSTAmt += RGSTAmt
            VATAmt += RVATAmt
            RTotalAmt = RAmount - RDiscountAmt + RSCAmt + RVATAmt + RGSTAmt
            TotalAmt += RTotalAmt
        Next ctr
        lblSourceTotalQty.Text = Format(Qty, "#####")
        lblGrossAmtSource.Text = Format(TotalAmt, "#####0.00")
    End Sub

    Public Sub CalculateDestinationTotalsBill()
        lblTotalQty.Text = ""
        lblTotalQty.Text = ""
        lblSubTotal.Text = ""
        lblSCAmt.Text = ""
        lblGSTAmt.Text = ""
        lblVATAmt.Text = ""
        lblDiscountAmt.Text = ""
        Dim ctr As Integer = 0
        Dim dtKOTItemDetails As DataTable
        Dim RQty, RAmount, RVATAmt, RDiscountAmt, GSTAmt, RGSTAmt, RSCAmt, RTotalAmt, TaxPer, SCPer, DiscountPer As Double
        Dim Qty, Amount, VATAmt, DiscountAmt, SCAmt, TotalAmt, AmtAfterDis, Rate As Double
        Qty = 0 : Amount = 0 : VATAmt = 0 : GSTAmt = 0 : GSTAmt = 0 : SCAmt = 0 : TotalAmt = 0 : DiscountAmt = 0
        RQty = 0 : RAmount = 0 : RVATAmt = 0 : RGSTAmt = 0 : RSCAmt = 0 : RTotalAmt = 0 : RDiscountAmt = 0 : AmtAfterDis = 0
        VATAmt = 0 : GSTAmt = 0 : SCAmt = 0 : DiscountAmt = 0 : Amount = 0
        dtKOTItemDetails = CType(dgDestinationTable.DataSource, DataTable)
        For ctr = 0 To dtKOTItemDetails.Rows.Count - 1
            RQty = Val(dtKOTItemDetails.Rows(ctr)("Qty"))
            Rate = Val(dtKOTItemDetails.Rows(ctr)("Rate"))
            SCPer = Val(dtKOTItemDetails.Rows(ctr)("SCPer"))
            TaxPer = Val(dtKOTItemDetails.Rows(ctr)("TaxPer"))
            TaxType = Trim(dtKOTItemDetails.Rows(ctr)("TaxType"))
            DiscountPer = Val(dtKOTItemDetails.Rows(ctr)("DiscountPer"))

            RQty = Val(dtKOTItemDetails.Rows(ctr)("Qty"))
            Rate = Val(dtKOTItemDetails.Rows(ctr)("Rate"))
            Qty += RQty

            RAmount = RQty * Rate
            Amount += RAmount
            RDiscountAmt = RAmount * Val(DiscountPer) * 0.01
            DiscountAmt += RDiscountAmt

            AmtAfterDis = RAmount - RDiscountAmt

            RSCAmt = AmtAfterDis * SCPer * 0.01
            SCAmt += RSCAmt
            RVATAmt = 0
            RGSTAmt = 0
            If TaxType = "VAT" Then
                RVATAmt = AmtAfterDis * TaxPer * 0.01 + RSCAmt * GSTPerOnServiceCharge * 0.01
            ElseIf TaxType = "GST" Then
                RGSTAmt = AmtAfterDis * TaxPer * 0.01 + RSCAmt * GSTPerOnServiceCharge * 0.01
            End If
            VATAmt += RVATAmt
            GSTAmt += RGSTAmt
            RTotalAmt = RAmount - RDiscountAmt + RSCAmt + RVATAmt + RGSTAmt
            TotalAmt += RTotalAmt

        Next ctr

        lblDestinationTotalQty.Text = Format(Qty, "#####")
        lblDestinationGrossAmt.Text = Format(TotalAmt, "#####0.00")
    End Sub

    Private Sub MergeTables()
        CalculateDestinationTotalsBill()
        CalculateSourceTotalsBill()
        Dim StrQry, DestinationKOTNos As String
        StrQry = ""
        DestinationKOTNos = ""
        If lblDestinationBillNo.Text <> "" And lblDestinationBillNo.Text <> "New" Then
            StrQry = "SELECT  STUFF((SELECT  ',' + CONVERT(VARCHAR(4),KOTNo) FROM FB_BillBody WHERE BillNo=" & lblDestinationBillNo.Text & " AND YearCode=" & YearCode & " AND LocationCode=" & LOCATION_CODE & " FOR XML PATH('')), 1, 1, '') AS ItemList"
            DestinationKOTNos = ObjDatabase.ExecuteScalarS(StrQry)
        Else
            If DestinationKOTNos = "" Then DestinationKOTNos = "0"
        End If
        Dim table As DataTable = dtDestinationTable
        Dim foundRows() As DataRow
        Dim expression As String
        expression = "KOTNo IS NULL"
        foundRows = table.Select(expression)
        If foundRows.Length = 0 Then
            MsgBox("Move at least One item before saving", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim FlagFound As Integer = 0
        For ictr As Integer = 0 To dgDestinationTable.Rows.Count - 1
            If IsDBNull((dgDestinationTable.Item("KOTNo", ictr).Value)) = True Then
                FlagFound = 1
                Exit For
            Else
            End If
        Next
        If FlagFound = 0 Then
            MsgBox("Move at least One item before saving", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim i As Integer
        Dim KOTNo, ItemCode, Rate, Qty, data As String
        data = ""
        Dim QrySourceTable1 As String = ""
        Dim QrySourceTable2 As String = ""

        ObjDatabase.ConnectDatabse()
        ObjDatabase.OpenDatabaseConnection()
        Dim myTrans As SqlTransaction = ObjDatabase.con.BeginTransaction()
        Dim myCommand As SqlCommand = ObjDatabase.con.CreateCommand()
        myCommand.Transaction = myTrans

        Dim SourceBillAmtBR, SourceBillAmtAR, SourceRoundOff, DestinationBillAmtBR, DestinationBillAmtAR, DestinationRoundOff As Double

        btnShiftKOT.Enabled = False
        Try
            If lblDestinationBillNo.Text <> "New" Then
                StrSql = "Select Max(KOTNo)+1 From FB_KOTHead WHERE YearCode=" & YearCode & " AND LocationCode=" & LOCATION_CODE
                myCommand.CommandText = StrSql
                Dim NewKOTNo As String = myCommand.ExecuteScalar()

                QrySourceTable1 = "INSERT INTO FB_KOTHead(KOTNo, KOTDate, MemberID, IssueNo, WaiterCode, TableCode, PAX, RefNo, ModeOfPayment, OpeningBalance, ClosingBalance, CreationDate, ModificationDate, UserCode, LocationCode, YearCode)"
                QrySourceTable2 = " SELECT " & NewKOTNo & ",'" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "','" & lblDestinationMemID.Text & "'," & lblDestinationIssueNo.Text & _
                "," & cmbWaiter.SelectedValue & "," & cmbDestinationTable.SelectedValue & ",1,'0',''," & Val(lblDestinationOpeningBalance.Text) & _
                "," & Val(lblDestinationClosingBalance.Text) & ",getdate(),getdate()," & UserCode & "," & LOCATION_CODE & "," & YearCode
                StrSql = QrySourceTable1 & vbCrLf & QrySourceTable2
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()


                StrSql = "INSERT INTO FB_BillBody(Billno,KOTNo,CreationDate,ModificationDate,UserCode,LocationCode,YearCode)" & _
                " values(" & Val(lblDestinationBillNo.Text) & "," & NewKOTNo & ",Getdate(),Getdate()," & UserCode & "," & LOCATION_CODE & "," & YearCode & ")"
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                For i = 0 To foundRows.GetUpperBound(0)
                    KOTNo = foundRows(i).ItemArray(1)
                    ItemCode = foundRows(i).ItemArray(3)
                    Rate = foundRows(i).ItemArray(8)
                    Qty = foundRows(i).ItemArray(7)

                    QrySourceTable1 = "INSERT INTO FB_KOTBody(KOTNo, Itemcode, ItemName, OpenItem, UnitCode, Qty, ActualQty, Rate, SchemeRate, Amount, DiscountPer, TaxType, TaxPer, SCPer, CreationDate, ModificationDate, UserCode, LocationCode, YearCode, remarks)"
                    QrySourceTable2 = " SELECT " & NewKOTNo & ",[ItemCode],ItemName,OpenItem,[UnitCode]," & Qty & ",Qty,[Rate],[Rate]," & Rate * Qty & ",[DiscountPer],[TaxType],[TaxPer],[SCPer],[CreationDate],[ModificationDate],[UserCode],[LocationCode],[YearCode],'to be deleted'" & _
                    " FROM [FB_KOTBody] WHERE KOTNo=" & KOTNo & " AND YearCode=" & YearCode & " AND ItemCode=" & ItemCode & " And Rate=" & Rate & " And Qty>0 and LocationCode=" & LOCATION_CODE
                    StrSql = QrySourceTable1 & vbCrLf & QrySourceTable2
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()

                    QrySourceTable2 = "UPDATE [FB_KOTBody] SET Qty=0, Remarks='Item shifted' WHERE KOTNo=" & KOTNo & " AND YearCode=" & YearCode & " AND ItemCode=" & ItemCode & " And Rate=" & Rate & " And Qty>0 and LocationCode=" & LOCATION_CODE
                    StrSql = QrySourceTable2
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()

                Next i

                QrySourceTable1 = "INSERT INTO FB_KOTBody(KOTNo, Itemcode, ItemName, OpenItem, UnitCode, Qty, ActualQty, Rate, SchemeRate, Amount, DiscountPer, TaxType, TaxPer, SCPer, CreationDate, ModificationDate, UserCode, LocationCode, YearCode, remarks)"
                QrySourceTable2 = "select KOTNo,ItemCode,ItemName,OpenItem,UnitCode,sum(qty),sum(qty),Rate,Rate,sum(amount),DiscountPer,TaxType,TaxPer,SCPer,getdate(),getdate()," & UserCode & "," & LOCATION_CODE & "," & YearCode & ", 'Table Moved/Merged' as Remarks" & _
                " from FB_KOTBody WHERE KOTNo=" & NewKOTNo & " AND YearCode=" & YearCode & " and LocationCode=" & LOCATION_CODE & _
                " group by KOTNo,ItemCode,UnitCode,DiscountPer,TaxPer,TaxType,SCPer, ItemName,OpenItem,Rate"
                StrSql = QrySourceTable1 & vbCrLf & QrySourceTable2
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                StrSql = "DELETE FROM FB_KOTBody WHERE KOTNo=" & NewKOTNo & " AND YearCode=" & YearCode & " and LocationCode=" & LOCATION_CODE & " and Remarks<>'Table Moved/Merged'"
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                SourceBillAmtBR = Math.Round(Val(lblGrossAmtSource.Text), 2)
                SourceBillAmtAR = Math.Round(Val(lblGrossAmtSource.Text), 0)
                SourceRoundOff = Math.Round(SourceBillAmtAR - SourceBillAmtBR, 2)

                DestinationBillAmtBR = Math.Round(Val(lblDestinationGrossAmt.Text), 2)
                DestinationBillAmtAR = Math.Round(Val(lblDestinationGrossAmt.Text), 0)
                DestinationRoundOff = Math.Round(DestinationBillAmtAR - DestinationBillAmtBR, 2)

                If Val(lblGrossAmtSource.Text) = 0 Then
                    StrSql = "UPDATE FB_BillHead SET Amount=" & SourceBillAmtAR & ", RoundOff=" & SourceRoundOff & ", BillStatus=1 WHERE [BillNo]=" & Val(lblSourceBillNo.Text) & " AND [YearCode]=" & YearCode & " and LocationCode=" & LOCATION_CODE
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()
                Else
                    StrSql = "UPDATE FB_BillHead SET Amount=" & Val(SourceBillAmtAR) & ",RoundOff=" & SourceRoundOff & " WHERE [BillNo]=" & Val(lblSourceBillNo.Text) & " AND [YearCode]=" & YearCode & " and LocationCode=" & LOCATION_CODE
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()
                End If

                StrSql = "UPDATE FB_BillHead SET Amount=" & DestinationBillAmtAR & ", RoundOff=" & DestinationRoundOff & " WHERE [BillNo]=" & Val(lblDestinationBillNo.Text) & " AND [YearCode]=" & YearCode & " and LocationCode=" & LOCATION_CODE
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

            ElseIf lblDestinationBillNo.Text = "New" And dgSourceTable.RowCount > 0 Then
                StrSql = "Select Max(BillNo)+1 From FB_BillHead WHERE YearCode=" & YearCode & " AND LocationCode=" & LOCATION_CODE
                myCommand.CommandText = StrSql
                Dim NewBillNo As String = myCommand.ExecuteScalar()

                StrSql = "Select Max(KOTNo)+1 From FB_KOTHead WHERE YearCode=" & YearCode & " AND LocationCode=" & LOCATION_CODE
                myCommand.CommandText = StrSql
                Dim NewKOTNo As String = myCommand.ExecuteScalar()

                StrSql = "INSERT INTO FB_BillHead(BillNo, BillDate, MemberID, MemberName, WaiterCode, TableCode, BookingNo, RoomCode, IssueNo, PAX, BillStatus, BillType, Amount, RoundOff, ModeOfPayment, RefNo, RefDate, ValidationMode, Remarks, OpeningBalance,ClosingBalance, CreationDate, ModificationDate, UserCode, LocationCode, YearCode)" & _
                " VALUES(" & NewBillNo & ",'" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "','" & lblDestinationMemID.Text & "','" & lblDestinationMemName.Text & "'," & cmbWaiter.SelectedValue & "," & cmbDestinationTable.SelectedValue & ",0,0," & Val(lblDestinationIssueNo.Text) & ",1,0," & BillType & "," & lblDestinationGrossAmt.Text & ",0,'','','" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "','SmartCard','From Table Shifting'," & Val(lblDestinationOpeningBalance.Text) & "," & Val(lblDestinationClosingBalance.Text) & ",getdate(),getdate()," & UserCode & "," & LOCATION_CODE & "," & YearCode & ")"
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                StrSql = "INSERT INTO FB_BillBody(Billno,KOTNo,CreationDate,ModificationDate,UserCode,LocationCode,YearCode)" & _
                " values(" & NewBillNo & "," & NewKOTNo & ",Getdate(),Getdate()," & UserCode & "," & LOCATION_CODE & "," & YearCode & ")"
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                QrySourceTable1 = "INSERT INTO FB_KOTHead(KOTNo, KOTDate, MemberID, IssueNo, WaiterCode, TableCode, PAX, RefNo, ModeOfPayment, OpeningBalance, ClosingBalance, CreationDate, ModificationDate, UserCode, LocationCode, YearCode)"
                QrySourceTable2 = " SELECT " & NewKOTNo & ",'" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "','" & lblDestinationMemID.Text & "'," & Val(lblDestinationIssueNo.Text) & _
                "," & cmbWaiter.SelectedValue & "," & cmbDestinationTable.SelectedValue & ",1,'0',''," & Val(lblDestinationOpeningBalance.Text) & _
                "," & Val(lblDestinationClosingBalance.Text) & ",getdate(),getdate()," & UserCode & "," & LOCATION_CODE & "," & YearCode
                StrSql = QrySourceTable1 & vbCrLf & QrySourceTable2
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                For i = 0 To foundRows.GetUpperBound(0)
                    KOTNo = foundRows(i).ItemArray(1)
                    ItemCode = foundRows(i).ItemArray(3)
                    Rate = foundRows(i).ItemArray(8)
                    Qty = foundRows(i).ItemArray(7)

                    QrySourceTable1 = "INSERT INTO FB_KOTBody(KOTNo, Itemcode, ItemName, OpenItem, UnitCode, Qty, ActualQty, Rate, SchemeRate, Amount, DiscountPer, TaxType, TaxPer, SCPer, CreationDate, ModificationDate, UserCode, LocationCode, YearCode, remarks)"
                    QrySourceTable2 = "SELECT " & NewKOTNo & ",[ItemCode],ItemName,OpenItem,[UnitCode]," & Qty & ",Qty,[Rate],[Rate]," & Rate * Qty & ",[DiscountPer],[TaxType],[TaxPer],[SCPer],[CreationDate],[ModificationDate],[UserCode],[LocationCode],[YearCode],'to be deleted'" & _
                    " FROM [FB_KOTBody] WHERE KOTNo=" & KOTNo & " AND YearCode=" & YearCode & " AND ItemCode=" & ItemCode & " And Rate=" & Rate & " And Qty>0"
                    StrSql = QrySourceTable1 & vbCrLf & QrySourceTable2
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()

                    QrySourceTable2 = "UPDATE [FB_KOTBody] SET Qty=0, Remarks='Item shifted'" & _
                    " WHERE KOTNo=" & KOTNo & " AND YearCode=" & YearCode & " AND LocationCode=" & LOCATION_CODE & " AND ItemCode=" & ItemCode & " And Rate=" & Rate & " And Qty>0"
                    StrSql = QrySourceTable2
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()

                Next i

                QrySourceTable1 = "INSERT INTO FB_KOTBody(KOTNo, Itemcode, ItemName, OpenItem, UnitCode, Qty, ActualQty, Rate, SchemeRate, Amount, DiscountPer, TaxType, TaxPer, SCPer, CreationDate, ModificationDate, UserCode, LocationCode, YearCode, remarks)"
                QrySourceTable2 = "select KOTNo,ItemCode,ItemName,OpenItem,UnitCode,sum(qty),sum(qty),Rate,Rate,sum(amount),DiscountPer,TaxType,TaxPer,SCPer,getdate(),getdate()," & UserCode & "," & LOCATION_CODE & "," & YearCode & ", 'Table Moved/Merged' as Remarks" & _
                " from FB_KOTBody WHERE KOTNo=" & NewKOTNo & " AND YearCode=" & YearCode & " and LocationCode=" & LOCATION_CODE & _
                " group by KOTNo,ItemCode,UnitCode,DiscountPer,TaxPer,TaxType,SCPer, ItemName,OpenItem,Rate"
                StrSql = QrySourceTable1 & vbCrLf & QrySourceTable2
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                StrSql = "DELETE FROM FB_KOTBody WHERE KOTNo=" & NewKOTNo & " AND YearCode=" & YearCode & _
                " and Remarks<>'Table Moved/Merged' and Locationcode=" & LOCATION_CODE
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                SourceBillAmtBR = Math.Round(Val(lblGrossAmtSource.Text), 2)
                SourceBillAmtAR = Math.Round(Val(lblGrossAmtSource.Text), 0)
                SourceRoundOff = Math.Round(SourceBillAmtAR - SourceBillAmtBR, 2)

                DestinationBillAmtBR = Math.Round(Val(lblDestinationGrossAmt.Text), 2)
                DestinationBillAmtAR = Math.Round(Val(lblDestinationGrossAmt.Text), 0)
                DestinationRoundOff = Math.Round(DestinationBillAmtAR - DestinationBillAmtBR, 2)

                If Val(lblGrossAmtSource.Text) = 0 Then
                    StrSql = "UPDATE FB_BillHead SET Amount=" & SourceBillAmtAR & ", RoundOff=" & SourceRoundOff & ", BillStatus=1 WHERE [BillNo]=" & Val(lblSourceBillNo.Text) & " AND [YearCode]=" & YearCode & " and LocationCode=" & LOCATION_CODE
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()
                Else
                    StrSql = "UPDATE FB_BillHead SET Amount=" & Val(SourceBillAmtAR) & ",RoundOff=" & SourceRoundOff & " WHERE [BillNo]=" & Val(lblSourceBillNo.Text) & " AND [YearCode]=" & YearCode & " and LocationCode=" & LOCATION_CODE
                    myCommand.CommandText = StrSql
                    myCommand.ExecuteNonQuery()
                End If

                StrSql = "UPDATE FB_BillHead SET Amount=" & DestinationBillAmtAR & ", RoundOff=" & DestinationRoundOff & " WHERE [BillNo]=" & Val(lblDestinationBillNo.Text) & " AND [YearCode]=" & YearCode & " and LocationCode=" & LOCATION_CODE
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

            ElseIf lblDestinationBillNo.Text = "New" And dgSourceTable.RowCount = 0 Then

                StrSql = "UPDATE FB_BillHead SET TableCode=" & cmbDestinationTable.SelectedValue & _
                " WHERE [BillNo]=" & Val(lblSourceBillNo.Text) & " AND [YearCode]=" & YearCode & " and LocationCode=" & LOCATION_CODE
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

                StrSql = "UPDATE FB_KOTHead SET TableCode=" & cmbDestinationTable.SelectedValue & " WHERE [KOTNo]=" & NewKOTNo & " and YearCode=" & YearCode & " and LocationCode=" & LOCATION_CODE
                myCommand.CommandText = StrSql
                myCommand.ExecuteNonQuery()

            End If


            If MsgBox("Are you sure to Move Item/Merge Tables?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                myTrans.Commit()
            Else
                myTrans.Rollback()
                Exit Sub
            End If
            Message = "Click <New Bill> to create New Bill"
            btnShiftKOT.Focus()
            ClearControlsAfterCheckSave()
            btnRefresh.Enabled = False
            cmbCashier.Enabled = False
            txtRate.Enabled = False
            txtRate.Text = ""
            lblGSTPer.Text = ""
            txtQty.Text = ""
            cmbItemName.SelectedIndex = 0
            lblqty.Text = ""
            lblAmount.Text = ""
            lblGSTAmt.Text = ""
            LblFinalAmount.Text = ""
            lblDiscountAmt.Text = ""
            ClearText(Me)
            txtRate.Enabled = False
            cmbItemName.Text = ""
            cmbItemName.SelectedValue = 0
            BindItemGrid()
            DisableControl(Me)
            Me.ErrorProvider1.Dispose()
            btnShiftKOT.Focus()
            LastBill = False
            lblSCAmt.Text = ""
            lblVATAmt.Text = ""
            lblUnit.Text = "--"
            txtRate.Text = ""
            btnShiftKOT.Enabled = True
            cmbWaiter.Enabled = False
            txtRefNo.Enabled = False
            txtPAX.Enabled = False
            BindOpenBills()
            cmbLocation.Enabled = True
            lblBillDate.Text = CurrentBusinessDate
        Catch ex As SqlException
            myTrans.Rollback()
            Message = "Record is not saved"
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "INFORMATION")
        Catch ex1 As Exception
        Finally
            myTrans.Dispose()
            ObjDatabase.CloseDatabaseConnection()
        End Try
    End Sub

    Private Sub cmbSourceTable_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSourceTable.Validated
        dgSourceTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        lblSourceBillNo.Text = ObjDatabase.ExecuteScalarS("Select BillNo From FB_BillHead Where TableCode=" & cmbSourceTable.SelectedValue & " and BillDate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' And BillStatus=0")
        StrSql = "SELECT TM.Code, TM.TableNo" & _
        " FROM FB_LocationTableLink LTL,FB_TableMaster TM,IM_LocationMaster LM" & _
        " where  LTL.TableCode = TM.Code and LTL.LocationCode = LM.code " & _
        " AND LTL.LocationCode=" & LOCATION_CODE & " and LTL.MainLocationCode=" & LOCATION_CODE & " and TM.Code<>" & cmbSourceTable.SelectedValue
        BindComboboxWithSelectOneNumeric(StrSql, "Code", "TableNo", cmbDestinationTable)
        BindItemGridForSourceTable()
        BindItemGridForDestinationTable()
        lblDestinationBillNo.Text = ""
        lblDestinationGrossAmt.Text = ""
        lblDestinationTotalQty.Text = ""
        If cmbSourceTable.SelectedValue > 0 Then
            cmbDestinationTable.Enabled = True
            btnMoveAll.Enabled = True
        Else
            cmbDestinationTable.Enabled = False
            btnMoveAll.Enabled = False
        End If
    End Sub

    Private Sub cmbDestinationTable_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDestinationTable.Validated
        dgDestinationTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        lblDestinationBillNo.Text = ObjDatabase.ExecuteScalarS("Select BillNo From FB_BillHead Where TableCode=" & cmbDestinationTable.SelectedValue & " and BillDate='" & CDate(lblBillDate.Text).ToString("dd/MMM/yyyy") & "' And BillStatus=0 and LocationCode=" & LOCATION_CODE)
        BindItemGridForDestinationTable()
        If lblDestinationBillNo.Text = "" Then
            ReadCardForNewBill()
            lblDestinationBillNo.Text = "New"
        Else
            StrSql = "select IssueNo, MemberID, MemberName From FB_BillHead where BillNo=" & Val(lblDestinationBillNo.Text) & " and YearCode=" & YearCode & " and LocationCode=" & LOCATION_CODE
            ds = New DataSet
            ds = ObjDatabase.BindDataSet(StrSql, "CardInfo")
            If ds.Tables("CardInfo").Rows.Count > 0 Then
                lblDestinationIssueNo.Text = ds.Tables("CardInfo").Rows(0)("IssueNo")
                lblDestinationMemID.Text = ds.Tables("CardInfo").Rows(0)("MemberID")
                lblDestinationMemName.Text = ds.Tables("CardInfo").Rows(0)("MemberName")
                lblDestinationOpeningBalance.Text = GetSmartCardClosingBalance(lblDestinationMemID.Text).ToString(NumFormat)
                lblDestinationClosingBalance.Text = Val(lblSmartCardOpeningBalance.Text).ToString(NumFormat)
            End If
        End If
    End Sub

    Private Sub dgSourceTable_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSourceTable.CellContentClick
        Dim RowIndex As Integer = e.RowIndex
        If e.ColumnIndex = 0 Then
            If cmbDestinationTable.SelectedValue = cmbSourceTable.SelectedValue Then
                MsgBox("Move from Table# and Move to Table# cannot be same", MsgBoxStyle.Critical)
                cmbDestinationTable.Focus()
                Exit Sub
            End If
            If cmbDestinationTable.SelectedValue = 0 Then
                MsgBox("Select a Table No before moving the items", MsgBoxStyle.Critical)
                cmbDestinationTable.Focus()
                Exit Sub
            End If

            Dim Destinationtablerow As DataRow
            Dim Sourcetablerow As DataRow
            Sourcetablerow = dtSourceTable.Rows(RowIndex)

            Dim KOTNo, ItemCode, UnitCode, Qty, SourceQty As Integer
            Dim Rate, TaxableAmount, DiscountPer, TaxPer, TempKOTNo, TaxAmt, ServiceTax, ServiceCharge, ServiceChargeAmt, NetAmt, ActualQty, OpenItem, Amount, AmountAfterDiscount As Double

            TaxAmt = 0 : ServiceCharge = 0 : ServiceChargeAmt = 0 : NetAmt = 0 : ActualQty = 0 : NetAmt = 0
            Dim ItemName, UnitName, Remarks As String
            'TempKOTNo = dtSourceTable.Rows(RowIndex)("KOTNo")
            KOTNo = dtSourceTable.Rows(RowIndex)("KOTNo")
            ItemCode = dtSourceTable.Rows(RowIndex)("ItemCode")
            ItemName = dtSourceTable.Rows(RowIndex)("ItemName")
            UnitCode = dtSourceTable.Rows(RowIndex)("UnitCode")
            UnitName = dtSourceTable.Rows(RowIndex)("UnitName")
            Rate = dtSourceTable.Rows(RowIndex)("Rate")
            SourceQty = dtSourceTable.Rows(RowIndex)("Qty")
            DiscountPer = 0 'dtSourceTable.Rows(RowIndex)("DiscountPer")
            Amount = dtSourceTable.Rows(RowIndex)("Amount")
            TaxPer = dtSourceTable.Rows(RowIndex)("TaxPer")
            SCPer = dtSourceTable.Rows(RowIndex)("SCPer")
            TaxType = dtSourceTable.Rows(RowIndex)("TaxType")
            Remarks = ""
            OpenItem = dtSourceTable.Rows(RowIndex)("OpenItem")
            Qty = 1
            If SourceQty < 0 Then Exit Sub
            Dim EnteredQty As Integer = 0
            Dim liPosition As Integer = -1
            For ictr As Integer = 0 To dgDestinationTable.Rows.Count - 1
                If (dgDestinationTable.Item("ItemCode", ictr).Value) = ItemCode And (dgDestinationTable.Item("TempKOTNo", ictr).Value) = KOTNo Then
                    liPosition = ictr
                    EnteredQty = dgDestinationTable.Item("Qty", ictr).Value
                    Exit For
                Else
                End If
            Next
            If liPosition = -1 Then
                Destinationtablerow = dtDestinationTable.NewRow
                Destinationtablerow.Item("TempKOTNo") = KOTNo
                Destinationtablerow.Item("ItemCode") = ItemCode
                Destinationtablerow.Item("ItemName") = ItemName
                Destinationtablerow.Item("UnitCode") = UnitCode
                Destinationtablerow.Item("UnitName") = UnitName
                Destinationtablerow.Item("Rate") = Rate
                Destinationtablerow.Item("Qty") = Qty
                Destinationtablerow.Item("TaxType") = TaxType
                Amount = Rate * 1
                AmountAfterDiscount = Amount * (100 - DiscountPer) * 0.01
                TaxableAmount = AmountAfterDiscount
                Destinationtablerow.Item("Amount") = Amount
                Destinationtablerow.Item("TaxPer") = TaxPer
                Sourcetablerow.Item("TaxType") = TaxType
                TaxAmt = TaxableAmount * TaxPer * 0.01
                Destinationtablerow.Item("TaxAmount") = TaxAmt

                Destinationtablerow.Item("SCPer") = SCPer
                ServiceChargeAmt = TaxableAmount * SCPer * 0.01
                Destinationtablerow.Item("SCAmount") = ServiceChargeAmt
                Destinationtablerow.Item("GrossAmt") = AmountAfterDiscount + TaxAmt + ServiceChargeAmt * (100 + GSTPerOnServiceCharge) * 0.01
                Destinationtablerow.Item("DisplayOrder") = Now
                Destinationtablerow.Item("OpenItem") = OpenItem
                Destinationtablerow.Item("DiscountPer") = Val(txtDiscountPer.Text)
                dtDestinationTable.Rows.InsertAt(Destinationtablerow, 0)
                dtDestinationTable.AcceptChanges()
                dtDestinationTable.DefaultView.Sort = "DisplayOrder DESC"
                dtDestinationTable = dtDestinationTable.DefaultView.ToTable()
                dgDestinationTable.DataSource = dtDestinationTable
                If dgDestinationTable.RowCount > 0 Then
                    dgDestinationTable.ClearSelection()
                    dgDestinationTable.Rows(0).Selected = True
                End If
            Else
                Destinationtablerow = dtDestinationTable.Rows(liPosition)
                Destinationtablerow.Item("TempKOTNo") = KOTNo
                Destinationtablerow.Item("ItemCode") = ItemCode
                Destinationtablerow.Item("ItemName") = ItemName
                Destinationtablerow.Item("UnitCode") = UnitCode
                Destinationtablerow.Item("UnitName") = UnitName
                Destinationtablerow.Item("Rate") = Rate
                Qty = (EnteredQty + 1)
                Destinationtablerow.Item("Qty") = Qty

                Amount = Rate * Qty
                AmountAfterDiscount = Amount * (100 - DiscountPer) * 0.01
                TaxableAmount = AmountAfterDiscount
                Destinationtablerow.Item("Amount") = Amount
                Destinationtablerow.Item("TaxPer") = TaxPer
                Destinationtablerow.Item("TaxType") = TaxType
                TaxAmt = TaxableAmount * TaxPer * 0.01
                Destinationtablerow.Item("TaxAmount") = TaxAmt
                Destinationtablerow.Item("SCPer") = SCPer
                Destinationtablerow.Item("SCAmount") = ServiceChargeAmt
                Destinationtablerow.Item("GrossAmt") = AmountAfterDiscount + TaxAmt + ServiceChargeAmt * (100 + GSTPerOnServiceCharge) * 0.01
                Destinationtablerow.Item("DisplayOrder") = Now
                Destinationtablerow.Item("OpenItem") = OpenItem
                Destinationtablerow.Item("DiscountPer") = Val(txtDiscountPer.Text)
            End If
            dtDestinationTable.AcceptChanges()
            dtDestinationTable.DefaultView.Sort = "DisplayOrder DESC"
            dtDestinationTable = dtDestinationTable.DefaultView.ToTable()
            dgDestinationTable.DataSource = dtDestinationTable
            If dgDestinationTable.RowCount > 0 Then
                dgDestinationTable.ClearSelection()
                dgDestinationTable.Rows(0).Selected = True
            End If

            SourceQty = SourceQty - 1

            TaxAmt = 0 : ServiceTax = 0 : ServiceCharge = 0 : ServiceChargeAmt = 0 : NetAmt = 0 : ActualQty = 0 : NetAmt = 0
            Sourcetablerow.Item("ItemCode") = ItemCode
            Sourcetablerow.Item("ItemName") = ItemName
            Sourcetablerow.Item("UnitCode") = UnitCode
            Sourcetablerow.Item("UnitName") = UnitName
            Sourcetablerow.Item("Rate") = Rate
            Sourcetablerow.Item("Qty") = SourceQty

            Amount = Rate * SourceQty
            AmountAfterDiscount = Amount * (100 - DiscountPer) * 0.01
            TaxableAmount = AmountAfterDiscount
            Sourcetablerow.Item("Amount") = Amount
            Sourcetablerow.Item("TaxPer") = TaxPer
            Sourcetablerow.Item("TaxType") = TaxType
            TaxAmt = TaxableAmount * TaxPer * 0.01
            Sourcetablerow.Item("TaxAmount") = TaxAmt
            Sourcetablerow.Item("SCPer") = SCPer
            ServiceChargeAmt = TaxableAmount * SCPer * 0.01
            Sourcetablerow.Item("SCAmount") = ServiceChargeAmt
            Sourcetablerow.Item("GrossAmt") = AmountAfterDiscount + TaxAmt + ServiceChargeAmt
            Sourcetablerow.Item("DisplayOrder") = Now
            Sourcetablerow.Item("OpenItem") = OpenItem
            Sourcetablerow.Item("DiscountPer") = Val(txtDiscountPer.Text)
            dtSourceTable.AcceptChanges()
            dgSourceTable.DataSource = dtSourceTable
            If SourceQty = 0 Then
                dtSourceTable.Rows(RowIndex).Delete()
                dtSourceTable.AcceptChanges()
                dgSourceTable.DataSource = dtSourceTable
            End If
            CalculateSourceTotalsBill()
            CalculateDestinationTotalsBill()
        End If
    End Sub

    Private Sub dgDestinationTable_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDestinationTable.CellContentClick
        Dim RowIndex As Integer = e.RowIndex

        If e.ColumnIndex = 0 Then
            If cmbDestinationTable.SelectedValue = cmbSourceTable.SelectedValue Then
                MsgBox("Move from Table# and Move to Table# cannot be same", MsgBoxStyle.Critical)
                cmbSourceTable.Focus()
                Exit Sub
            End If
            If cmbDestinationTable.SelectedValue = 0 Then
                MsgBox("Select a Table No before moving the items", MsgBoxStyle.Critical)
                cmbSourceTable.Focus()
                Exit Sub
            End If
            If IsDBNull((dgDestinationTable.Item("KOTNo", e.RowIndex).Value)) = False Then
                MsgBox("Item cannot be Moved. Item does not belong to Source Table", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim Destinationtablerow As DataRow
            Dim SourcetableRow As DataRow
            Destinationtablerow = dtDestinationTable.Rows(RowIndex)

            Dim KOTNo, GroupCode, SubGroupCode, ItemCode, UnitCode, Qty, DestinationQty, TempKOTNo As Integer
            Dim Rate, TaxableAmount, DiscountPer, TaxPer, TaxAmt, ServiceCharge, ServiceChargeAmt, NetAmt, ActualQty, OpenItem, Amount, AmountAfterDiscount As Double

            TaxAmt = 0 : ServiceCharge = 0 : ServiceChargeAmt = 0 : NetAmt = 0 : ActualQty = 0 : NetAmt = 0
            Dim GroupName, SubGroupName, ItemName, UnitName, Remarks As String
            KOTNo = dtDestinationTable.Rows(RowIndex)("TempKOTNo")
            TempKOTNo = dtDestinationTable.Rows(RowIndex)("TempKOTNo")
            ItemCode = dtDestinationTable.Rows(RowIndex)("ItemCode")
            ItemName = dtDestinationTable.Rows(RowIndex)("ItemName")
            UnitCode = dtDestinationTable.Rows(RowIndex)("UnitCode")
            UnitName = dtDestinationTable.Rows(RowIndex)("UnitName")
            Rate = dtDestinationTable.Rows(RowIndex)("Rate")
            DestinationQty = dtDestinationTable.Rows(RowIndex)("Qty")
            DiscountPer = dtDestinationTable.Rows(RowIndex)("DiscountPer")
            Amount = dtDestinationTable.Rows(RowIndex)("Amount")
            TaxPer = dtDestinationTable.Rows(RowIndex)("TaxPer")
            SCPer = dtDestinationTable.Rows(RowIndex)("SCPer")
            TaxType = dtDestinationTable.Rows(RowIndex)("TaxType")
            Remarks = ""
            OpenItem = dtDestinationTable.Rows(RowIndex)("OpenItem")
            Qty = 1
            If DestinationQty < 0 Then Exit Sub
            Dim EnteredQty As Integer = 0
            Dim liPosition As Integer = -1
            For ictr As Integer = 0 To dgSourceTable.Rows.Count - 1
                If (dgSourceTable.Item("ItemCode", ictr).Value) = ItemCode And dgSourceTable.Item("KOTNo", ictr).Value = KOTNo Then
                    liPosition = ictr
                    EnteredQty = dgSourceTable.Item("Qty", ictr).Value
                    Exit For
                Else
                End If
            Next
            If liPosition = -1 Then
                SourcetableRow = dtSourceTable.NewRow
                SourcetableRow.Item("KOTNo") = KOTNo
                SourcetableRow.Item("TempKOTNo") = KOTNo
                SourcetableRow.Item("ItemCode") = ItemCode
                SourcetableRow.Item("ItemName") = ItemName
                SourcetableRow.Item("UnitCode") = UnitCode
                SourcetableRow.Item("UnitName") = UnitName
                SourcetableRow.Item("Rate") = Rate
                SourcetableRow.Item("Qty") = Qty
                Amount = Rate * 1
                AmountAfterDiscount = Amount * (100 - DiscountPer) * 0.01
                TaxableAmount = AmountAfterDiscount
                SourcetableRow.Item("Amount") = Amount
                SourcetableRow.Item("TaxPer") = TaxPer
                SourcetableRow.Item("TaxType") = TaxType
                TaxAmt = TaxableAmount * TaxPer * 0.01
                SourcetableRow.Item("TaxAmount") = TaxAmt
                SourcetableRow.Item("SCPer") = SCPer
                ServiceChargeAmt = AmountAfterDiscount * SCPer * 0.01
                SourcetableRow.Item("SCAmount") = ServiceChargeAmt
                SourcetableRow.Item("GrossAmt") = AmountAfterDiscount + TaxAmt + ServiceChargeAmt * (100 + GSTPerOnServiceCharge) * 0.01
                SourcetableRow.Item("DisplayOrder") = Now
                SourcetableRow.Item("OpenItem") = OpenItem
                SourcetableRow.Item("DiscountPer") = Val(txtDiscountPer.Text)
                dtSourceTable.Rows.InsertAt(SourcetableRow, 0)
                dtSourceTable.AcceptChanges()
                dgSourceTable.DataSource = dtSourceTable
            Else
                SourcetableRow = dtSourceTable.Rows(liPosition)
                SourcetableRow.Item("KOTNo") = KOTNo
                SourcetableRow.Item("TempKOTNo") = KOTNo
                SourcetableRow.Item("ItemCode") = ItemCode
                SourcetableRow.Item("ItemName") = ItemName
                SourcetableRow.Item("UnitCode") = UnitCode
                SourcetableRow.Item("UnitName") = UnitName
                SourcetableRow.Item("Rate") = Rate
                Qty = (EnteredQty + 1)
                SourcetableRow.Item("Qty") = Qty

                Amount = Rate * Qty
                AmountAfterDiscount = Amount * (100 - DiscountPer) * 0.01
                TaxableAmount = AmountAfterDiscount
                SourcetableRow.Item("Amount") = Amount
                SourcetableRow.Item("TaxPer") = TaxPer
                TaxAmt = TaxableAmount * TaxPer * 0.01
                SourcetableRow.Item("TaxAmount") = TaxAmt
                SourcetableRow.Item("SCPer") = 0
                ServiceChargeAmt = AmountAfterDiscount * 0
                SourcetableRow.Item("SCAmount") = ServiceChargeAmt
                SourcetableRow.Item("GrossAmt") = AmountAfterDiscount + TaxAmt + ServiceChargeAmt * (100 + GSTPerOnServiceCharge) * 0.01
                SourcetableRow.Item("DisplayOrder") = Now
                SourcetableRow.Item("OpenItem") = OpenItem
                SourcetableRow.Item("DiscountPer") = Val(txtDiscountPer.Text)
            End If
            dtSourceTable.AcceptChanges()

            DestinationQty = DestinationQty - 1

            TaxAmt = 0 : ServiceCharge = 0 : ServiceChargeAmt = 0 : NetAmt = 0 : ActualQty = 0 : NetAmt = 0
            Destinationtablerow.Item("ItemCode") = ItemCode
            Destinationtablerow.Item("ItemName") = ItemName
            Destinationtablerow.Item("UnitCode") = UnitCode
            Destinationtablerow.Item("UnitName") = UnitName
            Destinationtablerow.Item("Rate") = Rate
            Destinationtablerow.Item("Qty") = DestinationQty

            Amount = Rate * DestinationQty
            AmountAfterDiscount = Amount * (100 - DiscountPer) * 0.01
            TaxableAmount = AmountAfterDiscount
            Destinationtablerow.Item("Amount") = Amount
            Destinationtablerow.Item("TaxPer") = TaxPer
            TaxAmt = TaxableAmount * TaxPer * 0.01
            Destinationtablerow.Item("TaxAmount") = TaxAmt
            Destinationtablerow.Item("SCPer") = 0
            ServiceChargeAmt = AmountAfterDiscount * SCPer * 0.01
            Destinationtablerow.Item("SCAmount") = ServiceChargeAmt
            Destinationtablerow.Item("GrossAmt") = AmountAfterDiscount + TaxAmt + ServiceChargeAmt * (100 + GSTPerOnServiceCharge) * 0.01
            Destinationtablerow.Item("DisplayOrder") = Now
            Destinationtablerow.Item("OpenItem") = OpenItem
            Destinationtablerow.Item("DiscountPer") = Val(txtDiscountPer.Text)
            dtDestinationTable.AcceptChanges()
            dgDestinationTable.DataSource = dtDestinationTable

            If DestinationQty = 0 Then
                dtDestinationTable.Rows(RowIndex).Delete()
                dtDestinationTable.AcceptChanges()
                dgDestinationTable.DataSource = dtDestinationTable
            End If
            CalculateSourceTotalsBill()
            CalculateDestinationTotalsBill()
        End If
    End Sub

#End Region

    Private Sub ControlAccess()
        btnShiftTable.Enabled = IIf(EditRight = 0, False, True)
        btnShiftKOT.Enabled = IIf(EditRight = 0, False, True)
        btnModifyKOT.Enabled = IIf(DeleteRight = 0, False, True)
        btnHistory.Enabled = IIf(SearchRight = 0, False, True)
    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged

    End Sub

    Private Sub btnCancelMemberSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelMemberSearch.Click
        PanelSearchItem.Visible = False
    End Sub

    Private Sub dgSearchItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearchItem.CellContentClick
        If e.ColumnIndex = 0 Then
            PanelSearchItem.Visible = False
            Dim ItemCode As String = dgSearchItem.Rows(dgSearchItem.CurrentRow.Index).Cells("Itemcode").Value()
            cmbItemName.SelectedValue = Val(ItemCode)
            cmbItemName_Validated(sender, e)
            PanelSearchItem.Visible = False
        End If
    End Sub

    Private Sub BindSearchGridForItem()
        EnableControl(PanelSearchItem)
        PanelSearchItem.Visible = True
        PanelSearchItem.Location = New Point(264, 186)
        PanelSearchItem.BringToFront()
        Dim dsSearchItem As New DataSet
        StrSql = "Select ItemCode,AliasName, ItemName from IM_ItemMaster WHERE Maingroup IN (" & BAR_MAINGROUPS & ") AND ItemGroup IN (SELECT GroupCode FROM FB_LocationGroupLink WHERE [LocationCode]=" & LOCATION_Code & ") and status='Active' and itemCode in (select distinct BOMItemCode from IM_ItemBOMMaster)"
        StrSql &= IIf(txtSearchItemCode.Text <> "", " AND (AliasName Like '" & txtSearchItemCode.Text & "%')", "")
        StrSql &= IIf(txtSearchItemName.Text <> "", " AND (ItemName Like '%" & txtSearchItemName.Text & "%')", "")
        StrSql &= " UNION ALL"
        StrSql &= " Select ItemCode,AliasName, ItemName from IM_ItemMaster WHERE Maingroup IN (" & REST_MAINGROUPS & ") AND ItemGroup IN(SELECT GroupCode FROM FB_LocationGroupLink WHERE [LocationCode]=" & LOCATION_Code & ") and status='Active'"
        StrSql &= IIf(txtSearchItemCode.Text <> "", " AND (AliasName Like '" & txtSearchItemCode.Text & "%')", "")
        StrSql &= IIf(txtSearchItemName.Text <> "", " AND (ItemName Like '%" & txtSearchItemName.Text & "%')", "")
        StrSql &= "  order by 2"
        dsSearchItem = ObjDatabase.BindDataSet(StrSql, "member")
        dgSearchItem.DataSource = dsSearchItem
        dgSearchItem.DataMember = dsSearchItem.Tables(0).ToString()
        FormatDataGridView(dgSearchItem)
        dgSearchItem.Columns("ItemCode").Width = 100
        dgSearchItem.Columns("AliasName").Width = 100
        dgSearchItem.Columns("ItemName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgSearchItem.Columns("ItemCode").HeaderText = "Itemcode(I)"
        dgSearchItem.Columns("AliasName").HeaderText = "Itemcode(A)"
        dgSearchItem.Columns("ItemName").HeaderText = "ItemName"
        dgbtnSelectMember.Width = 25
        dgSearchItem.RowHeadersWidth = 20
        dgSearchItem.RowHeadersVisible = True
    End Sub

    Private Sub txtSearchItemName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchItemName.TextChanged, txtSearchItemCode.TextChanged
        BindSearchGridForItem()
    End Sub

    Private Sub cmbTableNoSC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLocation.SelectedIndexChanged

    End Sub

    Private Sub txtSearchItemCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchItemCode.KeyDown, txtSearchItemName.KeyDown
        If e.KeyCode = Keys.Down Then
            dgSearchItem.Focus()
        End If
    End Sub

    Private Sub dgSearchItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgSearchItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            PanelSearchItem.Visible = False
            Dim ItemCode As String = dgSearchItem.Rows(dgSearchItem.CurrentRow.Index).Cells("Itemcode").Value()
            cmbItemName.SelectedValue = Val(ItemCode)
            cmbItemName_Validated(sender, e)
            txtQty.Focus()
        End If
    End Sub

    Private Sub txtTableNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtTableNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        BindOpenBills()
    End Sub

    Private Sub cmbTableNoSC_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTableNoSC.SelectedIndexChanged

    End Sub
End Class
