<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditTransactionEnquiry
    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the Code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblTotalDrAmount = New System.Windows.Forms.Label
        Me.lblTotalCrAmount = New System.Windows.Forms.Label
        Me.btnPrintReport = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtOpening = New System.Windows.Forms.TextBox
        Me.txtIssueNo = New System.Windows.Forms.TextBox
        Me.LabelHeader = New System.Windows.Forms.Label
        Me.lblCount = New System.Windows.Forms.Label
        Me.PanelSearch = New System.Windows.Forms.Panel
        Me.PanelDisplay = New System.Windows.Forms.Panel
        'Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnCloseDisplay = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblAvailableLimit = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblAllotedLimit = New System.Windows.Forms.Label
        Me.txtAmountDr = New System.Windows.Forms.Label
        Me.dgCreditEnquiry = New System.Windows.Forms.DataGridView
        Me.dgbtnViewBill = New System.Windows.Forms.DataGridViewImageColumn
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.chbDateFrom = New System.Windows.Forms.CheckBox
        Me.M_ID = New System.Windows.Forms.Label
        Me.lblMemID = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblCategory = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.txtC_ID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbLocation = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker
        Me.LblNameSearch = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblopeningDr = New System.Windows.Forms.Label
        Me.txtAmountCr = New System.Windows.Forms.Label
        Me.lblOpeningCr = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Panel3.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        Me.PanelDisplay.SuspendLayout()
        CType(Me.dgCreditEnquiry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblTotalDrAmount)
        Me.Panel3.Controls.Add(Me.lblTotalCrAmount)
        Me.Panel3.Controls.Add(Me.btnPrintReport)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.txtOpening)
        Me.Panel3.Controls.Add(Me.txtIssueNo)
        Me.Panel3.Controls.Add(Me.LabelHeader)
        Me.Panel3.Controls.Add(Me.lblCount)
        Me.Panel3.Controls.Add(Me.PanelSearch)
        Me.Panel3.Controls.Add(Me.btnClose)
        Me.Panel3.Controls.Add(Me.btnSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1019, 680)
        Me.Panel3.TabIndex = 0
        '
        'lblTotalDrAmount
        '
        Me.lblTotalDrAmount.BackColor = System.Drawing.Color.Black
        Me.lblTotalDrAmount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTotalDrAmount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDrAmount.ForeColor = System.Drawing.Color.White
        Me.lblTotalDrAmount.Location = New System.Drawing.Point(841, 638)
        Me.lblTotalDrAmount.Name = "lblTotalDrAmount"
        Me.lblTotalDrAmount.Size = New System.Drawing.Size(80, 20)
        Me.lblTotalDrAmount.TabIndex = 275
        Me.lblTotalDrAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblTotalDrAmount, "Debit Balance")
        '
        'lblTotalCrAmount
        '
        Me.lblTotalCrAmount.BackColor = System.Drawing.Color.Black
        Me.lblTotalCrAmount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTotalCrAmount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCrAmount.ForeColor = System.Drawing.Color.White
        Me.lblTotalCrAmount.Location = New System.Drawing.Point(925, 638)
        Me.lblTotalCrAmount.Name = "lblTotalCrAmount"
        Me.lblTotalCrAmount.Size = New System.Drawing.Size(80, 20)
        Me.lblTotalCrAmount.TabIndex = 274
        Me.lblTotalCrAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblTotalCrAmount, "Credit Balance")
        '
        'btnPrintReport
        '
        Me.btnPrintReport.BackColor = System.Drawing.Color.Transparent
        Me.btnPrintReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrintReport.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btnPrintReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnPrintReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPrintReport.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnPrintReport.ForeColor = System.Drawing.Color.Black
        Me.btnPrintReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintReport.ImageKey = "(none)"
        Me.btnPrintReport.Location = New System.Drawing.Point(469, 640)
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(80, 30)
        Me.btnPrintReport.TabIndex = 3
        Me.btnPrintReport.Text = "Print"
        Me.btnPrintReport.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(-4, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 2)
        Me.Panel1.TabIndex = 0
        '
        'txtOpening
        '
        Me.txtOpening.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOpening.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOpening.Location = New System.Drawing.Point(1030, 655)
        Me.txtOpening.Name = "txtOpening"
        Me.txtOpening.Size = New System.Drawing.Size(83, 22)
        Me.txtOpening.TabIndex = 99
        Me.txtOpening.Visible = False
        '
        'txtIssueNo
        '
        Me.txtIssueNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIssueNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIssueNo.Location = New System.Drawing.Point(1051, 655)
        Me.txtIssueNo.Name = "txtIssueNo"
        Me.txtIssueNo.Size = New System.Drawing.Size(83, 22)
        Me.txtIssueNo.TabIndex = 98
        Me.txtIssueNo.Visible = False
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.LabelHeader.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHeader.ForeColor = System.Drawing.Color.Black
        Me.LabelHeader.Location = New System.Drawing.Point(0, 1)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(1018, 26)
        Me.LabelHeader.TabIndex = 0
        Me.LabelHeader.Text = "CREDIT TRANSACTION ENQUIRY"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.lblCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCount.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.Location = New System.Drawing.Point(16, 645)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(367, 20)
        Me.lblCount.TabIndex = 16
        '
        'PanelSearch
        '
        Me.PanelSearch.BackColor = System.Drawing.Color.Transparent
        Me.PanelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearch.Controls.Add(Me.PanelDisplay)
        Me.PanelSearch.Controls.Add(Me.Label4)
        Me.PanelSearch.Controls.Add(Me.lblAvailableLimit)
        Me.PanelSearch.Controls.Add(Me.Label1)
        Me.PanelSearch.Controls.Add(Me.lblAllotedLimit)
        Me.PanelSearch.Controls.Add(Me.txtAmountDr)
        Me.PanelSearch.Controls.Add(Me.dgCreditEnquiry)
        Me.PanelSearch.Controls.Add(Me.Panel4)
        Me.PanelSearch.Controls.Add(Me.Label5)
        Me.PanelSearch.Controls.Add(Me.lblopeningDr)
        Me.PanelSearch.Controls.Add(Me.txtAmountCr)
        Me.PanelSearch.Controls.Add(Me.lblOpeningCr)
        Me.PanelSearch.Location = New System.Drawing.Point(7, 41)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(1005, 593)
        Me.PanelSearch.TabIndex = 1
        '
        'PanelDisplay
        '
        Me.PanelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.PanelDisplay.Controls.Add(Me.CrystalReportViewer2)
        Me.PanelDisplay.Controls.Add(Me.btnPrint)
        Me.PanelDisplay.Controls.Add(Me.btnCloseDisplay)
        Me.PanelDisplay.Location = New System.Drawing.Point(626, -1)
        Me.PanelDisplay.Name = "PanelDisplay"
        Me.PanelDisplay.Size = New System.Drawing.Size(378, 593)
        Me.PanelDisplay.TabIndex = 271
        '
        'CrystalReportViewer2
        '
        'Me.CrystalReportViewer2.ActiveViewIndex = -1
        'Me.CrystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CrystalReportViewer2.DisplayBackgroundEdge = False
        'Me.CrystalReportViewer2.DisplayGroupTree = False
        'Me.CrystalReportViewer2.Location = New System.Drawing.Point(5, 32)
        'Me.CrystalReportViewer2.Name = "CrystalReportViewer2"
        'Me.CrystalReportViewer2.SelectionFormula = ""
        'Me.CrystalReportViewer2.Size = New System.Drawing.Size(366, 554)
        'Me.CrystalReportViewer2.TabIndex = 7
        'Me.CrystalReportViewer2.ViewTimeSelectionFormula = ""
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = Global.FNBManagement.My.Resources.Resources.printer
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPrint.Location = New System.Drawing.Point(298, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(36, 27)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ToolTip1.SetToolTip(Me.btnPrint, "Print Document")
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCloseDisplay
        '
        Me.btnCloseDisplay.BackgroundImage = Global.FNBManagement.My.Resources.Resources.delete1
        Me.btnCloseDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCloseDisplay.Location = New System.Drawing.Point(334, 2)
        Me.btnCloseDisplay.Name = "btnCloseDisplay"
        Me.btnCloseDisplay.Size = New System.Drawing.Size(36, 27)
        Me.btnCloseDisplay.TabIndex = 2
        Me.btnCloseDisplay.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ToolTip1.SetToolTip(Me.btnCloseDisplay, "Close Display")
        Me.btnCloseDisplay.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(250, 568)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 20)
        Me.Label4.TabIndex = 279
        Me.Label4.Text = "Available Credit Limit"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAvailableLimit
        '
        Me.lblAvailableLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAvailableLimit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAvailableLimit.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAvailableLimit.Location = New System.Drawing.Point(403, 568)
        Me.lblAvailableLimit.Name = "lblAvailableLimit"
        Me.lblAvailableLimit.Size = New System.Drawing.Size(85, 20)
        Me.lblAvailableLimit.TabIndex = 280
        Me.lblAvailableLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblAvailableLimit, "Debit Opening Balance")
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 568)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 20)
        Me.Label1.TabIndex = 277
        Me.Label1.Text = "Allotted Credit Limit"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAllotedLimit
        '
        Me.lblAllotedLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAllotedLimit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAllotedLimit.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAllotedLimit.Location = New System.Drawing.Point(159, 568)
        Me.lblAllotedLimit.Name = "lblAllotedLimit"
        Me.lblAllotedLimit.Size = New System.Drawing.Size(85, 20)
        Me.lblAllotedLimit.TabIndex = 278
        Me.lblAllotedLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblAllotedLimit, "Debit Opening Balance")
        '
        'txtAmountDr
        '
        Me.txtAmountDr.BackColor = System.Drawing.Color.Black
        Me.txtAmountDr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtAmountDr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtAmountDr.ForeColor = System.Drawing.Color.White
        Me.txtAmountDr.Location = New System.Drawing.Point(833, 568)
        Me.txtAmountDr.Name = "txtAmountDr"
        Me.txtAmountDr.Size = New System.Drawing.Size(80, 20)
        Me.txtAmountDr.TabIndex = 7
        Me.txtAmountDr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.txtAmountDr, "Total Of Debit Transactions")
        '
        'dgCreditEnquiry
        '
        Me.dgCreditEnquiry.AllowUserToAddRows = False
        Me.dgCreditEnquiry.AllowUserToDeleteRows = False
        Me.dgCreditEnquiry.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgCreditEnquiry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgbtnViewBill})
        Me.dgCreditEnquiry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgCreditEnquiry.GridColor = System.Drawing.Color.Coral
        Me.dgCreditEnquiry.Location = New System.Drawing.Point(4, 94)
        Me.dgCreditEnquiry.Name = "dgCreditEnquiry"
        Me.dgCreditEnquiry.RowHeadersWidth = 20
        Me.dgCreditEnquiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCreditEnquiry.Size = New System.Drawing.Size(994, 471)
        Me.dgCreditEnquiry.TabIndex = 1
        '
        'dgbtnViewBill
        '
        Me.dgbtnViewBill.Frozen = True
        Me.dgbtnViewBill.HeaderText = ""
        Me.dgbtnViewBill.Image = Global.FNBManagement.My.Resources.Resources.view
        Me.dgbtnViewBill.Name = "dgbtnViewBill"
        Me.dgbtnViewBill.Width = 30
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.chbDateFrom)
        Me.Panel4.Controls.Add(Me.M_ID)
        Me.Panel4.Controls.Add(Me.lblMemID)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.lblStatus)
        Me.Panel4.Controls.Add(Me.lblCategory)
        Me.Panel4.Controls.Add(Me.lblName)
        Me.Panel4.Controls.Add(Me.txtC_ID)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.cmbLocation)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.dtpDateFrom)
        Me.Panel4.Controls.Add(Me.dtpDateTo)
        Me.Panel4.Controls.Add(Me.LblNameSearch)
        Me.Panel4.Location = New System.Drawing.Point(5, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(994, 61)
        Me.Panel4.TabIndex = 0
        '
        'chbDateFrom
        '
        Me.chbDateFrom.AutoSize = True
        Me.chbDateFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.chbDateFrom.Location = New System.Drawing.Point(618, 6)
        Me.chbDateFrom.Name = "chbDateFrom"
        Me.chbDateFrom.Size = New System.Drawing.Size(94, 20)
        Me.chbDateFrom.TabIndex = 16
        Me.chbDateFrom.Text = "Date From"
        Me.ToolTip1.SetToolTip(Me.chbDateFrom, "Check to view details from the start of time")
        Me.chbDateFrom.UseVisualStyleBackColor = True
        Me.chbDateFrom.Visible = False
        '
        'M_ID
        '
        Me.M_ID.BackColor = System.Drawing.Color.Transparent
        Me.M_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.M_ID.Location = New System.Drawing.Point(93, 8)
        Me.M_ID.Name = "M_ID"
        Me.M_ID.Size = New System.Drawing.Size(63, 16)
        Me.M_ID.TabIndex = 2
        Me.M_ID.Text = "M_ID"
        Me.M_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMemID
        '
        Me.lblMemID.BackColor = System.Drawing.Color.Black
        Me.lblMemID.Font = New System.Drawing.Font("Lucida Fax", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblMemID.ForeColor = System.Drawing.Color.White
        Me.lblMemID.Location = New System.Drawing.Point(90, 31)
        Me.lblMemID.Name = "lblMemID"
        Me.lblMemID.Size = New System.Drawing.Size(69, 23)
        Me.lblMemID.TabIndex = 3
        Me.lblMemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(892, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 14)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Status"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(400, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 16)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Category"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(167, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(206, 16)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Name"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Black
        Me.lblStatus.Font = New System.Drawing.Font("Lucida Fax", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(890, 31)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(96, 23)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCategory
        '
        Me.lblCategory.BackColor = System.Drawing.Color.Black
        Me.lblCategory.Font = New System.Drawing.Font("Lucida Fax", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCategory.ForeColor = System.Drawing.Color.White
        Me.lblCategory.Location = New System.Drawing.Point(396, 31)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(91, 23)
        Me.lblCategory.TabIndex = 7
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Black
        Me.lblName.Font = New System.Drawing.Font("Lucida Fax", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(164, 31)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(227, 23)
        Me.lblName.TabIndex = 5
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtC_ID
        '
        Me.txtC_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtC_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtC_ID.Location = New System.Drawing.Point(7, 31)
        Me.txtC_ID.Name = "txtC_ID"
        Me.txtC_ID.Size = New System.Drawing.Size(78, 23)
        Me.txtC_ID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(751, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Date To"
        '
        'cmbLocation
        '
        Me.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocation.BackColor = System.Drawing.Color.White
        Me.cmbLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocation.DropDownWidth = 116
        Me.cmbLocation.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmbLocation.ForeColor = System.Drawing.Color.Black
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(493, 31)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(116, 23)
        Me.cmbLocation.Sorted = True
        Me.cmbLocation.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(492, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Location"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(615, 31)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(133, 23)
        Me.dtpDateFrom.TabIndex = 13
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(752, 31)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(133, 23)
        Me.dtpDateTo.TabIndex = 15
        '
        'LblNameSearch
        '
        Me.LblNameSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.LblNameSearch.Location = New System.Drawing.Point(10, 8)
        Me.LblNameSearch.Name = "LblNameSearch"
        Me.LblNameSearch.Size = New System.Drawing.Size(72, 16)
        Me.LblNameSearch.TabIndex = 0
        Me.LblNameSearch.Text = "C_ID"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(664, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 18)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Opening"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblopeningDr
        '
        Me.lblopeningDr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblopeningDr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopeningDr.Location = New System.Drawing.Point(779, 72)
        Me.lblopeningDr.Name = "lblopeningDr"
        Me.lblopeningDr.Size = New System.Drawing.Size(85, 18)
        Me.lblopeningDr.TabIndex = 275
        Me.lblopeningDr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblopeningDr, "Debit Opening Balance")
        '
        'txtAmountCr
        '
        Me.txtAmountCr.BackColor = System.Drawing.Color.Black
        Me.txtAmountCr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtAmountCr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtAmountCr.ForeColor = System.Drawing.Color.White
        Me.txtAmountCr.Location = New System.Drawing.Point(917, 568)
        Me.txtAmountCr.Name = "txtAmountCr"
        Me.txtAmountCr.Size = New System.Drawing.Size(80, 20)
        Me.txtAmountCr.TabIndex = 273
        Me.txtAmountCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.txtAmountCr, "Total Of Credit Transactions")
        '
        'lblOpeningCr
        '
        Me.lblOpeningCr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOpeningCr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpeningCr.Location = New System.Drawing.Point(868, 72)
        Me.lblOpeningCr.Name = "lblOpeningCr"
        Me.lblOpeningCr.Size = New System.Drawing.Size(85, 18)
        Me.lblOpeningCr.TabIndex = 276
        Me.lblOpeningCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblOpeningCr, "Credit Opening Balance")
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageKey = "(none)"
        Me.btnClose.Location = New System.Drawing.Point(549, 640)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 30)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImageKey = "(none)"
        Me.btnSearch.Location = New System.Drawing.Point(389, 640)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 30)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 40
        '
        'frmCreditTransactionEnquiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1019, 680)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreditTransactionEnquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Credit Transaction Enquiry"
        Me.TopMost = True
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PanelSearch.ResumeLayout(False)
        Me.PanelDisplay.ResumeLayout(False)
        CType(Me.dgCreditEnquiry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents dgCreditEnquiry As System.Windows.Forms.DataGridView
    Friend WithEvents LblNameSearch As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents txtC_ID As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIssueNo As System.Windows.Forms.TextBox
    Friend WithEvents txtOpening As System.Windows.Forms.TextBox
    Friend WithEvents txtAmountDr As System.Windows.Forms.Label
    Friend WithEvents M_ID As System.Windows.Forms.Label
    Friend WithEvents lblMemID As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnPrintReport As System.Windows.Forms.Button
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PanelDisplay As System.Windows.Forms.Panel
    'Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCloseDisplay As System.Windows.Forms.Button
    Friend WithEvents txtAmountCr As System.Windows.Forms.Label
    Friend WithEvents lblTotalCrAmount As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblOpeningCr As System.Windows.Forms.Label
    Friend WithEvents lblopeningDr As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblTotalDrAmount As System.Windows.Forms.Label
    Friend WithEvents chbDateFrom As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAvailableLimit As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAllotedLimit As System.Windows.Forms.Label
    Friend WithEvents dgbtnViewBill As System.Windows.Forms.DataGridViewImageColumn
End Class
