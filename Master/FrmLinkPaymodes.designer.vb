<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLinkPaymodes
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLinkPaymodes))
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.PanelEntry = New System.Windows.Forms.Panel()
        Me.dgLinkLocationWaiter = New System.Windows.Forms.DataGridView()
        Me.dgbtnEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgbtnDel = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PanelEntryTop = New System.Windows.Forms.Panel()
        Me.cmbPaymentMode = New System.Windows.Forms.ComboBox()
        Me.cmbLocation = New System.Windows.Forms.ComboBox()
        Me.btnAddWaiter = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.labelRecordCount = New System.Windows.Forms.Label()
        Me.PanelFooter = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.PanelLine = New System.Windows.Forms.Panel()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContainer.SuspendLayout()
        Me.PanelEntry.SuspendLayout()
        CType(Me.dgLinkLocationWaiter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEntryTop.SuspendLayout()
        Me.PanelFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.PanelContainer.Controls.Add(Me.PanelEntry)
        Me.PanelContainer.Controls.Add(Me.PanelFooter)
        Me.PanelContainer.Controls.Add(Me.PanelLine)
        Me.PanelContainer.Controls.Add(Me.LabelHeader)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.ForeColor = System.Drawing.Color.Black
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelContainer.Size = New System.Drawing.Size(1200, 700)
        Me.PanelContainer.TabIndex = 0
        '
        'PanelEntry
        '
        Me.PanelEntry.BackColor = System.Drawing.Color.Transparent
        Me.PanelEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEntry.Controls.Add(Me.dgLinkLocationWaiter)
        Me.PanelEntry.Controls.Add(Me.PanelEntryTop)
        Me.PanelEntry.Controls.Add(Me.labelRecordCount)
        Me.PanelEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEntry.Location = New System.Drawing.Point(10, 52)
        Me.PanelEntry.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelEntry.Name = "PanelEntry"
        Me.PanelEntry.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelEntry.Size = New System.Drawing.Size(1180, 588)
        Me.PanelEntry.TabIndex = 0
        '
        'dgLinkLocationWaiter
        '
        Me.dgLinkLocationWaiter.AllowUserToAddRows = False
        Me.dgLinkLocationWaiter.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(250, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLinkLocationWaiter.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLinkLocationWaiter.BackgroundColor = System.Drawing.Color.White
        Me.dgLinkLocationWaiter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLinkLocationWaiter.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgLinkLocationWaiter.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLinkLocationWaiter.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgLinkLocationWaiter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLinkLocationWaiter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgbtnEdit, Me.dgbtnDel})
        Me.dgLinkLocationWaiter.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLinkLocationWaiter.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgLinkLocationWaiter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgLinkLocationWaiter.GridColor = System.Drawing.Color.Chocolate
        Me.dgLinkLocationWaiter.Location = New System.Drawing.Point(10, 60)
        Me.dgLinkLocationWaiter.Margin = New System.Windows.Forms.Padding(4)
        Me.dgLinkLocationWaiter.MultiSelect = False
        Me.dgLinkLocationWaiter.Name = "dgLinkLocationWaiter"
        Me.dgLinkLocationWaiter.ReadOnly = True
        Me.dgLinkLocationWaiter.RowHeadersVisible = False
        Me.dgLinkLocationWaiter.RowHeadersWidth = 20
        Me.dgLinkLocationWaiter.Size = New System.Drawing.Size(1158, 491)
        Me.dgLinkLocationWaiter.TabIndex = 5
        Me.dgLinkLocationWaiter.TabStop = False
        '
        'dgbtnEdit
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.NullValue = CType(resources.GetObject("DataGridViewCellStyle3.NullValue"), Object)
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control
        Me.dgbtnEdit.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgbtnEdit.FillWeight = 25.0!
        Me.dgbtnEdit.Frozen = True
        Me.dgbtnEdit.HeaderText = ""
        Me.dgbtnEdit.Image = Global.FNBManagement.My.Resources.Resources.data_edit1
        Me.dgbtnEdit.MinimumWidth = 25
        Me.dgbtnEdit.Name = "dgbtnEdit"
        Me.dgbtnEdit.ReadOnly = True
        Me.dgbtnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgbtnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgbtnEdit.ToolTipText = "Click to edit the Row"
        Me.dgbtnEdit.Width = 25
        '
        'dgbtnDel
        '
        Me.dgbtnDel.FillWeight = 25.0!
        Me.dgbtnDel.Frozen = True
        Me.dgbtnDel.HeaderText = ""
        Me.dgbtnDel.Image = Global.FNBManagement.My.Resources.Resources.data_delete2
        Me.dgbtnDel.MinimumWidth = 25
        Me.dgbtnDel.Name = "dgbtnDel"
        Me.dgbtnDel.ReadOnly = True
        Me.dgbtnDel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgbtnDel.Width = 25
        '
        'PanelEntryTop
        '
        Me.PanelEntryTop.Controls.Add(Me.cmbPaymentMode)
        Me.PanelEntryTop.Controls.Add(Me.cmbLocation)
        Me.PanelEntryTop.Controls.Add(Me.btnAddWaiter)
        Me.PanelEntryTop.Controls.Add(Me.Label2)
        Me.PanelEntryTop.Controls.Add(Me.Label3)
        Me.PanelEntryTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEntryTop.Location = New System.Drawing.Point(10, 10)
        Me.PanelEntryTop.Name = "PanelEntryTop"
        Me.PanelEntryTop.Size = New System.Drawing.Size(1158, 50)
        Me.PanelEntryTop.TabIndex = 7
        '
        'cmbPaymentMode
        '
        Me.cmbPaymentMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPaymentMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPaymentMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbPaymentMode.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.cmbPaymentMode.FormattingEnabled = True
        Me.cmbPaymentMode.Location = New System.Drawing.Point(600, 10)
        Me.cmbPaymentMode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPaymentMode.Name = "cmbPaymentMode"
        Me.cmbPaymentMode.Size = New System.Drawing.Size(397, 26)
        Me.cmbPaymentMode.TabIndex = 8
        '
        'cmbLocation
        '
        Me.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbLocation.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(96, 10)
        Me.cmbLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(397, 26)
        Me.cmbLocation.TabIndex = 6
        '
        'btnAddWaiter
        '
        Me.btnAddWaiter.BackColor = System.Drawing.Color.Transparent
        Me.btnAddWaiter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddWaiter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddWaiter.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.btnAddWaiter.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddWaiter.Location = New System.Drawing.Point(1005, 4)
        Me.btnAddWaiter.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddWaiter.Name = "btnAddWaiter"
        Me.btnAddWaiter.Size = New System.Drawing.Size(148, 38)
        Me.btnAddWaiter.TabIndex = 9
        Me.btnAddWaiter.Text = "Add Pay Mode"
        Me.btnAddWaiter.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(4, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Location"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(501, 13)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Pay Modes"
        '
        'labelRecordCount
        '
        Me.labelRecordCount.BackColor = System.Drawing.Color.Transparent
        Me.labelRecordCount.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.labelRecordCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.labelRecordCount.Location = New System.Drawing.Point(10, 551)
        Me.labelRecordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelRecordCount.Name = "labelRecordCount"
        Me.labelRecordCount.Size = New System.Drawing.Size(1158, 25)
        Me.labelRecordCount.TabIndex = 6
        '
        'PanelFooter
        '
        Me.PanelFooter.Controls.Add(Me.btnClose)
        Me.PanelFooter.Controls.Add(Me.btnCancel)
        Me.PanelFooter.Controls.Add(Me.btnAdd)
        Me.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFooter.Location = New System.Drawing.Point(10, 640)
        Me.PanelFooter.Name = "PanelFooter"
        Me.PanelFooter.Size = New System.Drawing.Size(1180, 50)
        Me.PanelFooter.TabIndex = 49
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Lucida Fax", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.Transparent
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageKey = "(none)"
        Me.btnClose.Location = New System.Drawing.Point(640, 4)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 40)
        Me.btnClose.TabIndex = 51
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Lucida Fax", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageKey = "(none)"
        Me.btnCancel.Location = New System.Drawing.Point(536, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 40)
        Me.btnCancel.TabIndex = 50
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAdd.Font = New System.Drawing.Font("Lucida Fax", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.Transparent
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.ImageKey = "(none)"
        Me.btnAdd.Location = New System.Drawing.Point(432, 4)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(104, 40)
        Me.btnAdd.TabIndex = 49
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'PanelLine
        '
        Me.PanelLine.BackColor = System.Drawing.Color.Gray
        Me.PanelLine.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelLine.ForeColor = System.Drawing.Color.Black
        Me.PanelLine.Location = New System.Drawing.Point(10, 50)
        Me.PanelLine.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelLine.Name = "PanelLine"
        Me.PanelLine.Size = New System.Drawing.Size(1180, 2)
        Me.PanelLine.TabIndex = 45
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelHeader.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHeader.ForeColor = System.Drawing.Color.Silver
        Me.LabelHeader.Location = New System.Drawing.Point(10, 10)
        Me.LabelHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(1180, 40)
        Me.LabelHeader.TabIndex = 0
        Me.LabelHeader.Text = "LINK PAYMENT MODES"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.Transparent
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 2
        Me.btnDelete.Location = New System.Drawing.Point(1361, 794)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(104, 28)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Transparent
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImageKey = "find.ico"
        Me.btnSearch.Location = New System.Drawing.Point(1361, 772)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(104, 28)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = " Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        Me.btnSearch.Visible = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.Transparent
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnEdit.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.Transparent
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageKey = "(none)"
        Me.btnEdit.Location = New System.Drawing.Point(1473, 772)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(104, 28)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        Me.btnEdit.Visible = False
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.[Error]
        Me.ToolTip1.ToolTipTitle = "Banquet Mgmt"
        '
        'FrmLinkPaymodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.PanelContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLinkPaymodes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Link Waiter to Location"
        Me.TopMost = True
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContainer.ResumeLayout(False)
        Me.PanelEntry.ResumeLayout(False)
        CType(Me.dgLinkLocationWaiter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEntryTop.ResumeLayout(False)
        Me.PanelEntryTop.PerformLayout()
        Me.PanelFooter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents PanelContainer As System.Windows.Forms.Panel
    Friend WithEvents PanelEntry As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PanelLine As System.Windows.Forms.Panel
    Friend WithEvents dgLinkLocationWaiter As System.Windows.Forms.DataGridView
    Friend WithEvents labelRecordCount As System.Windows.Forms.Label
    Friend WithEvents dgbtnEdit As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents dgbtnDel As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents PanelEntryTop As System.Windows.Forms.Panel
    Friend WithEvents cmbPaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddWaiter As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label


End Class
