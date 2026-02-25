<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmartCardTransactionEnquiry
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtOpening = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.LabelHeader = New System.Windows.Forms.Label
        Me.lblCount = New System.Windows.Forms.Label
        Me.PanelSearch = New System.Windows.Forms.Panel
        Me.PanelDisplay = New System.Windows.Forms.Panel
        Me.lblIssueNo = New System.Windows.Forms.Label
        'Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnCloseDisplay = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblOpeningBalanceCr = New System.Windows.Forms.Label
        Me.lblOpeningBalanceDr = New System.Windows.Forms.Label
        Me.txtClosingBalance = New System.Windows.Forms.Label
        Me.txtSale = New System.Windows.Forms.Label
        Me.txtCharge = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblOpeningBalance = New System.Windows.Forms.Label
        Me.dgSearch = New System.Windows.Forms.DataGridView
        Me.dgbtnView = New System.Windows.Forms.DataGridViewImageColumn
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chbActiveCard = New System.Windows.Forms.CheckBox
        Me.M_ID = New System.Windows.Forms.Label
        Me.lblMemID = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblCategory = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.txtMainID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker
        Me.lblStatus = New System.Windows.Forms.Label
        Me.btnPrintReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel3.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        Me.PanelDisplay.SuspendLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnCancel)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.txtOpening)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.LabelHeader)
        Me.Panel3.Controls.Add(Me.lblCount)
        Me.Panel3.Controls.Add(Me.PanelSearch)
        Me.Panel3.Controls.Add(Me.lblStatus)
        Me.Panel3.Controls.Add(Me.btnPrintReport)
        Me.Panel3.Controls.Add(Me.btnClose)
        Me.Panel3.Controls.Add(Me.btnSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1019, 680)
        Me.Panel3.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageKey = "(none)"
        Me.btnCancel.Location = New System.Drawing.Point(429, 645)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 30)
        Me.btnCancel.TabIndex = 101
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(-4, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 2)
        Me.Panel1.TabIndex = 100
        '
        'txtOpening
        '
        Me.txtOpening.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOpening.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOpening.Location = New System.Drawing.Point(1027, 617)
        Me.txtOpening.Name = "txtOpening"
        Me.txtOpening.Size = New System.Drawing.Size(83, 22)
        Me.txtOpening.TabIndex = 99
        Me.txtOpening.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1027, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Status"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Visible = False
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.LabelHeader.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHeader.ForeColor = System.Drawing.Color.Black
        Me.LabelHeader.Location = New System.Drawing.Point(1, 1)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(1018, 25)
        Me.LabelHeader.TabIndex = 0
        Me.LabelHeader.Text = "SMARTCARD TRANSACTION ENQUIRY"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.lblCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCount.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.Location = New System.Drawing.Point(18, 649)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(328, 23)
        Me.lblCount.TabIndex = 16
        '
        'PanelSearch
        '
        Me.PanelSearch.BackColor = System.Drawing.Color.Transparent
        Me.PanelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearch.Controls.Add(Me.PanelDisplay)
        Me.PanelSearch.Controls.Add(Me.Label3)
        Me.PanelSearch.Controls.Add(Me.lblOpeningBalanceCr)
        Me.PanelSearch.Controls.Add(Me.lblOpeningBalanceDr)
        Me.PanelSearch.Controls.Add(Me.txtClosingBalance)
        Me.PanelSearch.Controls.Add(Me.txtSale)
        Me.PanelSearch.Controls.Add(Me.txtCharge)
        Me.PanelSearch.Controls.Add(Me.Label7)
        Me.PanelSearch.Controls.Add(Me.lblOpeningBalance)
        Me.PanelSearch.Controls.Add(Me.dgSearch)
        Me.PanelSearch.Controls.Add(Me.Panel4)
        Me.PanelSearch.Location = New System.Drawing.Point(8, 39)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(1003, 598)
        Me.PanelSearch.TabIndex = 0
        '
        'PanelDisplay
        '
        Me.PanelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDisplay.Controls.Add(Me.lblIssueNo)
        'Me.PanelDisplay.Controls.Add(Me.CrystalReportViewer2)
        Me.PanelDisplay.Controls.Add(Me.btnPrint)
        Me.PanelDisplay.Controls.Add(Me.btnCloseDisplay)
        Me.PanelDisplay.Location = New System.Drawing.Point(627, -1)
        Me.PanelDisplay.Name = "PanelDisplay"
        Me.PanelDisplay.Size = New System.Drawing.Size(375, 598)
        Me.PanelDisplay.TabIndex = 2
        '
        'lblIssueNo
        '
        Me.lblIssueNo.AutoSize = True
        Me.lblIssueNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblIssueNo.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.lblIssueNo.Location = New System.Drawing.Point(174, 80)
        Me.lblIssueNo.Name = "lblIssueNo"
        Me.lblIssueNo.Size = New System.Drawing.Size(76, 16)
        Me.lblIssueNo.TabIndex = 14
        Me.lblIssueNo.Text = "lblIssueNo"
        Me.lblIssueNo.Visible = False
        '
        'CrystalReportViewer2
        '
        'Me.CrystalReportViewer2.ActiveViewIndex = -1
        'Me.CrystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CrystalReportViewer2.DisplayBackgroundEdge = False
        'Me.CrystalReportViewer2.DisplayGroupTree = False
        'Me.CrystalReportViewer2.Location = New System.Drawing.Point(4, 32)
        'Me.CrystalReportViewer2.Name = "CrystalReportViewer2"
        'Me.CrystalReportViewer2.SelectionFormula = ""
        'Me.CrystalReportViewer2.Size = New System.Drawing.Size(364, 558)
        'Me.CrystalReportViewer2.TabIndex = 0
        'Me.CrystalReportViewer2.ViewTimeSelectionFormula = ""
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = Global.FNBManagement.My.Resources.Resources.printer
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPrint.Location = New System.Drawing.Point(289, 1)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(39, 29)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCloseDisplay
        '
        Me.btnCloseDisplay.BackgroundImage = Global.FNBManagement.My.Resources.Resources.delete1
        Me.btnCloseDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCloseDisplay.Location = New System.Drawing.Point(328, 1)
        Me.btnCloseDisplay.Name = "btnCloseDisplay"
        Me.btnCloseDisplay.Size = New System.Drawing.Size(39, 29)
        Me.btnCloseDisplay.TabIndex = 2
        Me.btnCloseDisplay.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(230, 574)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Total"
        '
        'lblOpeningBalanceCr
        '
        Me.lblOpeningBalanceCr.BackColor = System.Drawing.Color.Black
        Me.lblOpeningBalanceCr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOpeningBalanceCr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblOpeningBalanceCr.ForeColor = System.Drawing.Color.White
        Me.lblOpeningBalanceCr.Location = New System.Drawing.Point(299, 77)
        Me.lblOpeningBalanceCr.Name = "lblOpeningBalanceCr"
        Me.lblOpeningBalanceCr.Size = New System.Drawing.Size(79, 21)
        Me.lblOpeningBalanceCr.TabIndex = 8
        Me.lblOpeningBalanceCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblOpeningBalanceCr, "Opening Balance")
        '
        'lblOpeningBalanceDr
        '
        Me.lblOpeningBalanceDr.BackColor = System.Drawing.Color.Black
        Me.lblOpeningBalanceDr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOpeningBalanceDr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblOpeningBalanceDr.ForeColor = System.Drawing.Color.White
        Me.lblOpeningBalanceDr.Location = New System.Drawing.Point(379, 77)
        Me.lblOpeningBalanceDr.Name = "lblOpeningBalanceDr"
        Me.lblOpeningBalanceDr.Size = New System.Drawing.Size(77, 21)
        Me.lblOpeningBalanceDr.TabIndex = 1
        Me.lblOpeningBalanceDr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblOpeningBalanceDr, "Opening Balance")
        '
        'txtClosingBalance
        '
        Me.txtClosingBalance.BackColor = System.Drawing.Color.Black
        Me.txtClosingBalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtClosingBalance.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtClosingBalance.ForeColor = System.Drawing.Color.White
        Me.txtClosingBalance.Location = New System.Drawing.Point(873, 571)
        Me.txtClosingBalance.Name = "txtClosingBalance"
        Me.txtClosingBalance.Size = New System.Drawing.Size(102, 21)
        Me.txtClosingBalance.TabIndex = 7
        Me.txtClosingBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.txtClosingBalance, "Closing Balance")
        '
        'txtSale
        '
        Me.txtSale.BackColor = System.Drawing.Color.Black
        Me.txtSale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSale.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtSale.ForeColor = System.Drawing.Color.White
        Me.txtSale.Location = New System.Drawing.Point(379, 571)
        Me.txtSale.Name = "txtSale"
        Me.txtSale.Size = New System.Drawing.Size(79, 21)
        Me.txtSale.TabIndex = 5
        Me.txtSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.txtSale, "Total Of Debit Amount")
        '
        'txtCharge
        '
        Me.txtCharge.BackColor = System.Drawing.Color.Black
        Me.txtCharge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCharge.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtCharge.ForeColor = System.Drawing.Color.White
        Me.txtCharge.Location = New System.Drawing.Point(299, 571)
        Me.txtCharge.Name = "txtCharge"
        Me.txtCharge.Size = New System.Drawing.Size(77, 21)
        Me.txtCharge.TabIndex = 3
        Me.txtCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.txtCharge, "Total Of Credit Amount")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(759, 574)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Closing Balance"
        '
        'lblOpeningBalance
        '
        Me.lblOpeningBalance.AutoSize = True
        Me.lblOpeningBalance.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.lblOpeningBalance.Location = New System.Drawing.Point(230, 79)
        Me.lblOpeningBalance.Name = "lblOpeningBalance"
        Me.lblOpeningBalance.Size = New System.Drawing.Size(64, 16)
        Me.lblOpeningBalance.TabIndex = 1
        Me.lblOpeningBalance.Text = "Opening"
        '
        'dgSearch
        '
        Me.dgSearch.AllowUserToAddRows = False
        Me.dgSearch.AllowUserToDeleteRows = False
        Me.dgSearch.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgbtnView})
        Me.dgSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgSearch.GridColor = System.Drawing.Color.Coral
        Me.dgSearch.Location = New System.Drawing.Point(8, 100)
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.RowHeadersWidth = 20
        Me.dgSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSearch.Size = New System.Drawing.Size(967, 468)
        Me.dgSearch.TabIndex = 1
        '
        'dgbtnView
        '
        Me.dgbtnView.FillWeight = 25.0!
        Me.dgbtnView.HeaderText = ""
        Me.dgbtnView.Image = Global.FNBManagement.My.Resources.Resources.view
        Me.dgbtnView.MinimumWidth = 25
        Me.dgbtnView.Name = "dgbtnView"
        Me.dgbtnView.Width = 25
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.chbActiveCard)
        Me.Panel4.Controls.Add(Me.M_ID)
        Me.Panel4.Controls.Add(Me.lblMemID)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.lblCategory)
        Me.Panel4.Controls.Add(Me.lblName)
        Me.Panel4.Controls.Add(Me.txtMainID)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.dtpDateFrom)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.dtpDateTo)
        Me.Panel4.Location = New System.Drawing.Point(7, 7)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(989, 68)
        Me.Panel4.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(858, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Status"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(855, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 22)
        Me.Label5.TabIndex = 19
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(284, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Main ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbActiveCard
        '
        Me.chbActiveCard.AutoSize = True
        Me.chbActiveCard.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.chbActiveCard.Location = New System.Drawing.Point(580, 8)
        Me.chbActiveCard.Name = "chbActiveCard"
        Me.chbActiveCard.Size = New System.Drawing.Size(102, 20)
        Me.chbActiveCard.TabIndex = 16
        Me.chbActiveCard.Text = "Active Card"
        Me.chbActiveCard.UseVisualStyleBackColor = True
        '
        'M_ID
        '
        Me.M_ID.AutoSize = True
        Me.M_ID.BackColor = System.Drawing.Color.Transparent
        Me.M_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.M_ID.Location = New System.Drawing.Point(367, 11)
        Me.M_ID.Name = "M_ID"
        Me.M_ID.Size = New System.Drawing.Size(40, 16)
        Me.M_ID.TabIndex = 8
        Me.M_ID.Text = "M_ID"
        Me.M_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMemID
        '
        Me.lblMemID.BackColor = System.Drawing.Color.Black
        Me.lblMemID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblMemID.ForeColor = System.Drawing.Color.White
        Me.lblMemID.Location = New System.Drawing.Point(363, 31)
        Me.lblMemID.Name = "lblMemID"
        Me.lblMemID.Size = New System.Drawing.Size(80, 22)
        Me.lblMemID.TabIndex = 9
        Me.lblMemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(694, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Category"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(457, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 16)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Member Name"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCategory
        '
        Me.lblCategory.BackColor = System.Drawing.Color.Black
        Me.lblCategory.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCategory.ForeColor = System.Drawing.Color.White
        Me.lblCategory.Location = New System.Drawing.Point(690, 31)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(161, 22)
        Me.lblCategory.TabIndex = 13
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Black
        Me.lblName.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(449, 31)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(236, 22)
        Me.lblName.TabIndex = 11
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMainID
        '
        Me.txtMainID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMainID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtMainID.Location = New System.Drawing.Point(281, 31)
        Me.txtMainID.Name = "txtMainID"
        Me.txtMainID.Size = New System.Drawing.Size(77, 23)
        Me.txtMainID.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(147, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(7, 31)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(133, 23)
        Me.dtpDateFrom.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label10.Location = New System.Drawing.Point(10, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Date From"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(143, 31)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(133, 23)
        Me.dtpDateTo.TabIndex = 3
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Black
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(1082, 24)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(84, 22)
        Me.lblStatus.TabIndex = 15
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStatus.Visible = False
        '
        'btnPrintReport
        '
        Me.btnPrintReport.BackColor = System.Drawing.Color.Transparent
        Me.btnPrintReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrintReport.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPrintReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnPrintReport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPrintReport.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnPrintReport.ForeColor = System.Drawing.Color.Black
        Me.btnPrintReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintReport.Location = New System.Drawing.Point(509, 645)
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(80, 30)
        Me.btnPrintReport.TabIndex = 2
        Me.btnPrintReport.Text = "Print"
        Me.btnPrintReport.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageKey = "(none)"
        Me.btnClose.Location = New System.Drawing.Point(589, 645)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 30)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImageKey = "(none)"
        Me.btnSearch.Location = New System.Drawing.Point(349, 645)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 30)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmSmartCardTransactionEnquiry
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
        Me.Name = "frmSmartCardTransactionEnquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Smart Card Transaction Enquiry"
        Me.TopMost = True
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PanelSearch.ResumeLayout(False)
        Me.PanelSearch.PerformLayout()
        Me.PanelDisplay.ResumeLayout(False)
        Me.PanelDisplay.PerformLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrintReport As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents dgSearch As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents txtMainID As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblOpeningBalance As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOpening As System.Windows.Forms.TextBox
    Friend WithEvents lblOpeningBalanceDr As System.Windows.Forms.Label
    Friend WithEvents txtClosingBalance As System.Windows.Forms.Label
    Friend WithEvents txtSale As System.Windows.Forms.Label
    Friend WithEvents txtCharge As System.Windows.Forms.Label
    Friend WithEvents M_ID As System.Windows.Forms.Label
    Friend WithEvents lblMemID As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanelDisplay As System.Windows.Forms.Panel
    'Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCloseDisplay As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblOpeningBalanceCr As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chbActiveCard As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblIssueNo As System.Windows.Forms.Label
    Friend WithEvents dgbtnView As System.Windows.Forms.DataGridViewImageColumn
End Class
