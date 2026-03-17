<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditTransactionEnquiry
    Inherits FNBManagement.BasePOSForm
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtAmountDr = New System.Windows.Forms.Label()
        Me.txtAmountCr = New System.Windows.Forms.Label()
        Me.lblTotalDrAmount = New System.Windows.Forms.Label()
        Me.lblTotalCrAmount = New System.Windows.Forms.Label()
        Me.lblAvailableLimit = New System.Windows.Forms.Label()
        Me.lblAllotedLimit = New System.Windows.Forms.Label()
        Me.lblOpeningCr = New System.Windows.Forms.Label()
        Me.lblopeningDr = New System.Windows.Forms.Label()
        Me.chbDateFrom = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnCloseDisplay = New System.Windows.Forms.Button()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.PanelSearch = New System.Windows.Forms.Panel()
        Me.dgCreditEnquiry = New System.Windows.Forms.DataGridView()
        Me.dgbtnViewBill = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PanelSearchFooter = New System.Windows.Forms.Panel()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelGridTop = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PanelSearchTop = New System.Windows.Forms.Panel()
        Me.M_ID = New System.Windows.Forms.Label()
        Me.lblMemID = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtC_ID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbLocation = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.LblNameSearch = New System.Windows.Forms.Label()
        Me.PanelDisplay = New System.Windows.Forms.Panel()
        Me.PanelFooter = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrintReport = New System.Windows.Forms.Button()
        Me.PanelLine = New System.Windows.Forms.Panel()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.txtOpening = New System.Windows.Forms.TextBox()
        Me.txtIssueNo = New System.Windows.Forms.TextBox()
        Me.PanelContainer.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        CType(Me.dgCreditEnquiry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSearchFooter.SuspendLayout()
        Me.PanelGridTop.SuspendLayout()
        Me.PanelSearchTop.SuspendLayout()
        Me.PanelDisplay.SuspendLayout()
        Me.PanelFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAmountDr
        '
        Me.txtAmountDr.BackColor = System.Drawing.Color.Gray
        Me.txtAmountDr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtAmountDr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtAmountDr.ForeColor = System.Drawing.Color.White
        Me.txtAmountDr.Location = New System.Drawing.Point(995, 10)
        Me.txtAmountDr.Name = "txtAmountDr"
        Me.txtAmountDr.Size = New System.Drawing.Size(80, 20)
        Me.txtAmountDr.TabIndex = 295
        Me.txtAmountDr.Text = "0.00"
        Me.txtAmountDr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.txtAmountDr, "Total Of Debit Transactions")
        '
        'txtAmountCr
        '
        Me.txtAmountCr.BackColor = System.Drawing.Color.Gray
        Me.txtAmountCr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtAmountCr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtAmountCr.ForeColor = System.Drawing.Color.White
        Me.txtAmountCr.Location = New System.Drawing.Point(1079, 10)
        Me.txtAmountCr.Name = "txtAmountCr"
        Me.txtAmountCr.Size = New System.Drawing.Size(80, 20)
        Me.txtAmountCr.TabIndex = 296
        Me.txtAmountCr.Text = "0.00"
        Me.txtAmountCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.txtAmountCr, "Total Of Credit Transactions")
        '
        'lblTotalDrAmount
        '
        Me.lblTotalDrAmount.BackColor = System.Drawing.Color.Gray
        Me.lblTotalDrAmount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTotalDrAmount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDrAmount.ForeColor = System.Drawing.Color.White
        Me.lblTotalDrAmount.Location = New System.Drawing.Point(994, 41)
        Me.lblTotalDrAmount.Name = "lblTotalDrAmount"
        Me.lblTotalDrAmount.Size = New System.Drawing.Size(80, 20)
        Me.lblTotalDrAmount.TabIndex = 294
        Me.lblTotalDrAmount.Text = "0.00"
        Me.lblTotalDrAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblTotalDrAmount, "Debit Balance")
        '
        'lblTotalCrAmount
        '
        Me.lblTotalCrAmount.BackColor = System.Drawing.Color.Gray
        Me.lblTotalCrAmount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTotalCrAmount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCrAmount.ForeColor = System.Drawing.Color.White
        Me.lblTotalCrAmount.Location = New System.Drawing.Point(1078, 41)
        Me.lblTotalCrAmount.Name = "lblTotalCrAmount"
        Me.lblTotalCrAmount.Size = New System.Drawing.Size(80, 20)
        Me.lblTotalCrAmount.TabIndex = 293
        Me.lblTotalCrAmount.Text = "0.00"
        Me.lblTotalCrAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblTotalCrAmount, "Credit Balance")
        '
        'lblAvailableLimit
        '
        Me.lblAvailableLimit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAvailableLimit.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAvailableLimit.Location = New System.Drawing.Point(562, 10)
        Me.lblAvailableLimit.Name = "lblAvailableLimit"
        Me.lblAvailableLimit.Size = New System.Drawing.Size(85, 20)
        Me.lblAvailableLimit.TabIndex = 291
        Me.lblAvailableLimit.Text = "0.00"
        Me.lblAvailableLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblAvailableLimit, "Debit Opening Balance")
        '
        'lblAllotedLimit
        '
        Me.lblAllotedLimit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAllotedLimit.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAllotedLimit.Location = New System.Drawing.Point(201, 10)
        Me.lblAllotedLimit.Name = "lblAllotedLimit"
        Me.lblAllotedLimit.Size = New System.Drawing.Size(85, 20)
        Me.lblAllotedLimit.TabIndex = 289
        Me.lblAllotedLimit.Text = "0.00"
        Me.lblAllotedLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblAllotedLimit, "Debit Opening Balance")
        '
        'lblOpeningCr
        '
        Me.lblOpeningCr.BackColor = System.Drawing.Color.Gainsboro
        Me.lblOpeningCr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOpeningCr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpeningCr.Location = New System.Drawing.Point(1023, 5)
        Me.lblOpeningCr.Name = "lblOpeningCr"
        Me.lblOpeningCr.Size = New System.Drawing.Size(132, 19)
        Me.lblOpeningCr.TabIndex = 279
        Me.lblOpeningCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblOpeningCr, "Credit Opening Balance")
        '
        'lblopeningDr
        '
        Me.lblopeningDr.BackColor = System.Drawing.Color.Gainsboro
        Me.lblopeningDr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblopeningDr.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopeningDr.Location = New System.Drawing.Point(882, 5)
        Me.lblopeningDr.Name = "lblopeningDr"
        Me.lblopeningDr.Size = New System.Drawing.Size(132, 18)
        Me.lblopeningDr.TabIndex = 278
        Me.lblopeningDr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblopeningDr, "Debit Opening Balance")
        '
        'chbDateFrom
        '
        Me.chbDateFrom.AutoSize = True
        Me.chbDateFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.chbDateFrom.Location = New System.Drawing.Point(748, 3)
        Me.chbDateFrom.Name = "chbDateFrom"
        Me.chbDateFrom.Size = New System.Drawing.Size(121, 24)
        Me.chbDateFrom.TabIndex = 16
        Me.chbDateFrom.Text = "Date From"
        Me.ToolTip1.SetToolTip(Me.chbDateFrom, "Check to view details from the start of time")
        Me.chbDateFrom.UseVisualStyleBackColor = True
        Me.chbDateFrom.Visible = False
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
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 40
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.PanelContainer.Controls.Add(Me.PanelSearch)
        Me.PanelContainer.Controls.Add(Me.PanelDisplay)
        Me.PanelContainer.Controls.Add(Me.PanelFooter)
        Me.PanelContainer.Controls.Add(Me.PanelLine)
        Me.PanelContainer.Controls.Add(Me.LabelHeader)
        Me.PanelContainer.Controls.Add(Me.txtOpening)
        Me.PanelContainer.Controls.Add(Me.txtIssueNo)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelContainer.Size = New System.Drawing.Size(1200, 700)
        Me.PanelContainer.TabIndex = 1
        '
        'PanelSearch
        '
        Me.PanelSearch.BackColor = System.Drawing.Color.Transparent
        Me.PanelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearch.Controls.Add(Me.dgCreditEnquiry)
        Me.PanelSearch.Controls.Add(Me.PanelSearchFooter)
        Me.PanelSearch.Controls.Add(Me.PanelGridTop)
        Me.PanelSearch.Controls.Add(Me.PanelSearchTop)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSearch.Location = New System.Drawing.Point(10, 52)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Padding = New System.Windows.Forms.Padding(5)
        Me.PanelSearch.Size = New System.Drawing.Size(1180, 588)
        Me.PanelSearch.TabIndex = 1
        '
        'dgCreditEnquiry
        '
        Me.dgCreditEnquiry.AllowUserToAddRows = False
        Me.dgCreditEnquiry.AllowUserToDeleteRows = False
        Me.dgCreditEnquiry.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgCreditEnquiry.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgCreditEnquiry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgbtnViewBill})
        Me.dgCreditEnquiry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgCreditEnquiry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCreditEnquiry.GridColor = System.Drawing.Color.Coral
        Me.dgCreditEnquiry.Location = New System.Drawing.Point(5, 98)
        Me.dgCreditEnquiry.Name = "dgCreditEnquiry"
        Me.dgCreditEnquiry.RowHeadersWidth = 20
        Me.dgCreditEnquiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCreditEnquiry.Size = New System.Drawing.Size(1168, 413)
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
        'PanelSearchFooter
        '
        Me.PanelSearchFooter.BackColor = System.Drawing.Color.Transparent
        Me.PanelSearchFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearchFooter.Controls.Add(Me.txtAmountDr)
        Me.PanelSearchFooter.Controls.Add(Me.txtAmountCr)
        Me.PanelSearchFooter.Controls.Add(Me.lblTotalDrAmount)
        Me.PanelSearchFooter.Controls.Add(Me.lblTotalCrAmount)
        Me.PanelSearchFooter.Controls.Add(Me.lblCount)
        Me.PanelSearchFooter.Controls.Add(Me.Label4)
        Me.PanelSearchFooter.Controls.Add(Me.lblAvailableLimit)
        Me.PanelSearchFooter.Controls.Add(Me.Label1)
        Me.PanelSearchFooter.Controls.Add(Me.lblAllotedLimit)
        Me.PanelSearchFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelSearchFooter.Location = New System.Drawing.Point(5, 511)
        Me.PanelSearchFooter.Name = "PanelSearchFooter"
        Me.PanelSearchFooter.Size = New System.Drawing.Size(1168, 70)
        Me.PanelSearchFooter.TabIndex = 278
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.lblCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCount.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.Location = New System.Drawing.Point(10, 42)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(185, 20)
        Me.lblCount.TabIndex = 292
        Me.lblCount.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(357, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(199, 20)
        Me.Label4.TabIndex = 290
        Me.Label4.Text = "Available Credit Limit"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 20)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Allotted Credit Limit"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelGridTop
        '
        Me.PanelGridTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelGridTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelGridTop.Controls.Add(Me.lblOpeningCr)
        Me.PanelGridTop.Controls.Add(Me.lblopeningDr)
        Me.PanelGridTop.Controls.Add(Me.Label5)
        Me.PanelGridTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelGridTop.Location = New System.Drawing.Point(5, 70)
        Me.PanelGridTop.Name = "PanelGridTop"
        Me.PanelGridTop.Size = New System.Drawing.Size(1168, 28)
        Me.PanelGridTop.TabIndex = 279
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(795, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 20)
        Me.Label5.TabIndex = 277
        Me.Label5.Text = "Opening"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelSearchTop
        '
        Me.PanelSearchTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearchTop.Controls.Add(Me.chbDateFrom)
        Me.PanelSearchTop.Controls.Add(Me.M_ID)
        Me.PanelSearchTop.Controls.Add(Me.lblMemID)
        Me.PanelSearchTop.Controls.Add(Me.Label8)
        Me.PanelSearchTop.Controls.Add(Me.Label9)
        Me.PanelSearchTop.Controls.Add(Me.Label11)
        Me.PanelSearchTop.Controls.Add(Me.lblStatus)
        Me.PanelSearchTop.Controls.Add(Me.lblCategory)
        Me.PanelSearchTop.Controls.Add(Me.lblName)
        Me.PanelSearchTop.Controls.Add(Me.txtC_ID)
        Me.PanelSearchTop.Controls.Add(Me.Label2)
        Me.PanelSearchTop.Controls.Add(Me.cmbLocation)
        Me.PanelSearchTop.Controls.Add(Me.Label6)
        Me.PanelSearchTop.Controls.Add(Me.dtpDateFrom)
        Me.PanelSearchTop.Controls.Add(Me.dtpDateTo)
        Me.PanelSearchTop.Controls.Add(Me.LblNameSearch)
        Me.PanelSearchTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSearchTop.Location = New System.Drawing.Point(5, 5)
        Me.PanelSearchTop.Name = "PanelSearchTop"
        Me.PanelSearchTop.Size = New System.Drawing.Size(1168, 65)
        Me.PanelSearchTop.TabIndex = 0
        '
        'M_ID
        '
        Me.M_ID.AutoSize = True
        Me.M_ID.BackColor = System.Drawing.Color.Transparent
        Me.M_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.M_ID.Location = New System.Drawing.Point(87, 6)
        Me.M_ID.Name = "M_ID"
        Me.M_ID.Size = New System.Drawing.Size(52, 20)
        Me.M_ID.TabIndex = 2
        Me.M_ID.Text = "M_ID"
        Me.M_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMemID
        '
        Me.lblMemID.BackColor = System.Drawing.Color.Black
        Me.lblMemID.Font = New System.Drawing.Font("Lucida Fax", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblMemID.ForeColor = System.Drawing.Color.White
        Me.lblMemID.Location = New System.Drawing.Point(90, 30)
        Me.lblMemID.Name = "lblMemID"
        Me.lblMemID.Size = New System.Drawing.Size(69, 23)
        Me.lblMemID.TabIndex = 3
        Me.lblMemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(1016, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 20)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Status"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(395, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 20)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Category"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(163, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 20)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Name"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Black
        Me.lblStatus.Font = New System.Drawing.Font("Lucida Fax", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(1021, 30)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(133, 23)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCategory
        '
        Me.lblCategory.BackColor = System.Drawing.Color.Black
        Me.lblCategory.Font = New System.Drawing.Font("Lucida Fax", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCategory.ForeColor = System.Drawing.Color.White
        Me.lblCategory.Location = New System.Drawing.Point(396, 30)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(170, 23)
        Me.lblCategory.TabIndex = 7
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Black
        Me.lblName.Font = New System.Drawing.Font("Lucida Fax", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(164, 30)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(227, 23)
        Me.lblName.TabIndex = 5
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtC_ID
        '
        Me.txtC_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtC_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtC_ID.Location = New System.Drawing.Point(7, 27)
        Me.txtC_ID.Name = "txtC_ID"
        Me.txtC_ID.Size = New System.Drawing.Size(78, 27)
        Me.txtC_ID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(881, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 20)
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
        Me.cmbLocation.Location = New System.Drawing.Point(572, 28)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(167, 26)
        Me.cmbLocation.Sorted = True
        Me.cmbLocation.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(568, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Location"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(745, 27)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(133, 27)
        Me.dtpDateFrom.TabIndex = 13
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(882, 27)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(133, 27)
        Me.dtpDateTo.TabIndex = 15
        '
        'LblNameSearch
        '
        Me.LblNameSearch.AutoSize = True
        Me.LblNameSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.LblNameSearch.Location = New System.Drawing.Point(3, 6)
        Me.LblNameSearch.Name = "LblNameSearch"
        Me.LblNameSearch.Size = New System.Drawing.Size(49, 20)
        Me.LblNameSearch.TabIndex = 0
        Me.LblNameSearch.Text = "C_ID"
        '
        'PanelDisplay
        '
        Me.PanelDisplay.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PanelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDisplay.Controls.Add(Me.btnPrint)
        Me.PanelDisplay.Controls.Add(Me.btnCloseDisplay)
        Me.PanelDisplay.Location = New System.Drawing.Point(729, 5)
        Me.PanelDisplay.Name = "PanelDisplay"
        Me.PanelDisplay.Size = New System.Drawing.Size(460, 570)
        Me.PanelDisplay.TabIndex = 271
        Me.PanelDisplay.Visible = False
        '
        'PanelFooter
        '
        Me.PanelFooter.BackColor = System.Drawing.Color.Transparent
        Me.PanelFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelFooter.Controls.Add(Me.btnSearch)
        Me.PanelFooter.Controls.Add(Me.btnClose)
        Me.PanelFooter.Controls.Add(Me.btnPrintReport)
        Me.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFooter.Location = New System.Drawing.Point(10, 640)
        Me.PanelFooter.Name = "PanelFooter"
        Me.PanelFooter.Size = New System.Drawing.Size(1180, 50)
        Me.PanelFooter.TabIndex = 100
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
        Me.btnSearch.Location = New System.Drawing.Point(495, 6)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 40)
        Me.btnSearch.TabIndex = 276
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
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
        Me.btnClose.Location = New System.Drawing.Point(655, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 40)
        Me.btnClose.TabIndex = 278
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
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
        Me.btnPrintReport.Location = New System.Drawing.Point(575, 6)
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(80, 40)
        Me.btnPrintReport.TabIndex = 277
        Me.btnPrintReport.Text = "Print"
        Me.btnPrintReport.UseVisualStyleBackColor = False
        '
        'PanelLine
        '
        Me.PanelLine.BackColor = System.Drawing.Color.Transparent
        Me.PanelLine.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelLine.ForeColor = System.Drawing.Color.Black
        Me.PanelLine.Location = New System.Drawing.Point(10, 50)
        Me.PanelLine.Name = "PanelLine"
        Me.PanelLine.Size = New System.Drawing.Size(1180, 2)
        Me.PanelLine.TabIndex = 0
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelHeader.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHeader.ForeColor = System.Drawing.Color.Silver
        Me.LabelHeader.Location = New System.Drawing.Point(10, 10)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(1180, 40)
        Me.LabelHeader.TabIndex = 0
        Me.LabelHeader.Text = "CREDIT TRANSACTION ENQUIRY"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtOpening
        '
        Me.txtOpening.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOpening.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOpening.Location = New System.Drawing.Point(1030, 655)
        Me.txtOpening.Name = "txtOpening"
        Me.txtOpening.Size = New System.Drawing.Size(83, 26)
        Me.txtOpening.TabIndex = 99
        Me.txtOpening.Visible = False
        '
        'txtIssueNo
        '
        Me.txtIssueNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIssueNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIssueNo.Location = New System.Drawing.Point(1051, 655)
        Me.txtIssueNo.Name = "txtIssueNo"
        Me.txtIssueNo.Size = New System.Drawing.Size(83, 26)
        Me.txtIssueNo.TabIndex = 98
        Me.txtIssueNo.Visible = False
        '
        'frmCreditTransactionEnquiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.PanelContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreditTransactionEnquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Credit Transaction Enquiry"
        Me.TopMost = True
        Me.PanelContainer.ResumeLayout(False)
        Me.PanelContainer.PerformLayout()
        Me.PanelSearch.ResumeLayout(False)
        CType(Me.dgCreditEnquiry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSearchFooter.ResumeLayout(False)
        Me.PanelSearchFooter.PerformLayout()
        Me.PanelGridTop.ResumeLayout(False)
        Me.PanelGridTop.PerformLayout()
        Me.PanelSearchTop.ResumeLayout(False)
        Me.PanelSearchTop.PerformLayout()
        Me.PanelDisplay.ResumeLayout(False)
        Me.PanelFooter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtIssueNo As System.Windows.Forms.TextBox
    Friend WithEvents PanelDisplay As System.Windows.Forms.Panel
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCloseDisplay As System.Windows.Forms.Button
    Friend WithEvents dgCreditEnquiry As System.Windows.Forms.DataGridView
    Friend WithEvents dgbtnViewBill As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PanelSearchTop As System.Windows.Forms.Panel
    Friend WithEvents chbDateFrom As System.Windows.Forms.CheckBox
    Friend WithEvents M_ID As System.Windows.Forms.Label
    Friend WithEvents lblMemID As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtC_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblNameSearch As System.Windows.Forms.Label
    Friend WithEvents PanelLine As System.Windows.Forms.Panel
    Friend WithEvents txtOpening As System.Windows.Forms.TextBox
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents PanelContainer As System.Windows.Forms.Panel
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrintReport As System.Windows.Forms.Button
    Friend WithEvents PanelSearchFooter As System.Windows.Forms.Panel
    Friend WithEvents txtAmountDr As System.Windows.Forms.Label
    Friend WithEvents txtAmountCr As System.Windows.Forms.Label
    Friend WithEvents lblTotalDrAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalCrAmount As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAvailableLimit As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAllotedLimit As System.Windows.Forms.Label
    Friend WithEvents PanelGridTop As System.Windows.Forms.Panel
    Friend WithEvents lblOpeningCr As System.Windows.Forms.Label
    Friend WithEvents lblopeningDr As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    'Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
