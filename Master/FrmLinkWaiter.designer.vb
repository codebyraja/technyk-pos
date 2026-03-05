<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLinkWaiter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLinkWaiter))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.PanelEntry = New System.Windows.Forms.Panel()
        Me.dgLinkLocationWaiter = New System.Windows.Forms.DataGridView()
        Me.dgbtnEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgbtnDel = New System.Windows.Forms.DataGridViewImageColumn()
        Me.labelRecordCount = New System.Windows.Forms.Label()
        Me.PanelWaiter = New System.Windows.Forms.Panel()
        Me.cmbWaiter = New System.Windows.Forms.ComboBox()
        Me.cmbLocation = New System.Windows.Forms.ComboBox()
        Me.btnAddWaiter = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelFooter = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContainer.SuspendLayout()
        Me.PanelEntry.SuspendLayout()
        CType(Me.dgLinkLocationWaiter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelWaiter.SuspendLayout()
        Me.PanelFooter.SuspendLayout()
        Me.PanelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelContainer.Controls.Add(Me.PanelEntry)
        Me.PanelContainer.Controls.Add(Me.PanelFooter)
        Me.PanelContainer.Controls.Add(Me.Panel1)
        Me.PanelContainer.Controls.Add(Me.PanelHeader)
        Me.PanelContainer.Controls.Add(Me.btnDelete)
        Me.PanelContainer.Controls.Add(Me.btnSearch)
        Me.PanelContainer.Controls.Add(Me.btnEdit)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.ForeColor = System.Drawing.Color.Black
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(1200, 700)
        Me.PanelContainer.TabIndex = 0
        '
        'PanelEntry
        '
        Me.PanelEntry.BackColor = System.Drawing.Color.Transparent
        Me.PanelEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEntry.Controls.Add(Me.dgLinkLocationWaiter)
        Me.PanelEntry.Controls.Add(Me.labelRecordCount)
        Me.PanelEntry.Controls.Add(Me.PanelWaiter)
        Me.PanelEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEntry.Location = New System.Drawing.Point(0, 42)
        Me.PanelEntry.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelEntry.Name = "PanelEntry"
        Me.PanelEntry.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelEntry.Size = New System.Drawing.Size(1200, 608)
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
        Me.dgLinkLocationWaiter.Location = New System.Drawing.Point(10, 110)
        Me.dgLinkLocationWaiter.Margin = New System.Windows.Forms.Padding(4)
        Me.dgLinkLocationWaiter.MultiSelect = False
        Me.dgLinkLocationWaiter.Name = "dgLinkLocationWaiter"
        Me.dgLinkLocationWaiter.ReadOnly = True
        Me.dgLinkLocationWaiter.RowHeadersVisible = False
        Me.dgLinkLocationWaiter.RowHeadersWidth = 20
        Me.dgLinkLocationWaiter.Size = New System.Drawing.Size(1178, 461)
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
        'labelRecordCount
        '
        Me.labelRecordCount.BackColor = System.Drawing.Color.Transparent
        Me.labelRecordCount.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.labelRecordCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.labelRecordCount.Location = New System.Drawing.Point(10, 571)
        Me.labelRecordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelRecordCount.Name = "labelRecordCount"
        Me.labelRecordCount.Size = New System.Drawing.Size(1178, 25)
        Me.labelRecordCount.TabIndex = 6
        '
        'PanelWaiter
        '
        Me.PanelWaiter.Controls.Add(Me.cmbWaiter)
        Me.PanelWaiter.Controls.Add(Me.cmbLocation)
        Me.PanelWaiter.Controls.Add(Me.btnAddWaiter)
        Me.PanelWaiter.Controls.Add(Me.Label2)
        Me.PanelWaiter.Controls.Add(Me.Label3)
        Me.PanelWaiter.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelWaiter.Location = New System.Drawing.Point(10, 10)
        Me.PanelWaiter.Name = "PanelWaiter"
        Me.PanelWaiter.Size = New System.Drawing.Size(1178, 100)
        Me.PanelWaiter.TabIndex = 10
        '
        'cmbWaiter
        '
        Me.cmbWaiter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbWaiter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbWaiter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbWaiter.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.cmbWaiter.FormattingEnabled = True
        Me.cmbWaiter.Location = New System.Drawing.Point(96, 52)
        Me.cmbWaiter.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbWaiter.Name = "cmbWaiter"
        Me.cmbWaiter.Size = New System.Drawing.Size(281, 26)
        Me.cmbWaiter.TabIndex = 8
        '
        'cmbLocation
        '
        Me.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbLocation.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(96, 17)
        Me.cmbLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(280, 26)
        Me.cmbLocation.TabIndex = 6
        '
        'btnAddWaiter
        '
        Me.btnAddWaiter.BackColor = System.Drawing.Color.Transparent
        Me.btnAddWaiter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddWaiter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddWaiter.Font = New System.Drawing.Font("Mongolian Baiti", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddWaiter.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddWaiter.Location = New System.Drawing.Point(477, 17)
        Me.btnAddWaiter.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddWaiter.Name = "btnAddWaiter"
        Me.btnAddWaiter.Size = New System.Drawing.Size(133, 65)
        Me.btnAddWaiter.TabIndex = 9
        Me.btnAddWaiter.Text = "Add Waiter"
        Me.btnAddWaiter.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(4, 21)
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
        Me.Label3.Location = New System.Drawing.Point(4, 56)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Waiter"
        '
        'PanelFooter
        '
        Me.PanelFooter.Controls.Add(Me.btnClose)
        Me.PanelFooter.Controls.Add(Me.btnCancel)
        Me.PanelFooter.Controls.Add(Me.btnAdd)
        Me.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFooter.Location = New System.Drawing.Point(0, 650)
        Me.PanelFooter.Name = "PanelFooter"
        Me.PanelFooter.Size = New System.Drawing.Size(1200, 50)
        Me.PanelFooter.TabIndex = 46
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
        Me.btnClose.Location = New System.Drawing.Point(640, 6)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 40)
        Me.btnClose.TabIndex = 12
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
        Me.btnCancel.Location = New System.Drawing.Point(536, 6)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 40)
        Me.btnCancel.TabIndex = 11
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
        Me.btnAdd.Location = New System.Drawing.Point(432, 6)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 40)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1200, 2)
        Me.Panel1.TabIndex = 45
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelHeader.Controls.Add(Me.LabelHeader)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(1200, 40)
        Me.PanelHeader.TabIndex = 47
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelHeader.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHeader.ForeColor = System.Drawing.Color.Silver
        Me.LabelHeader.Location = New System.Drawing.Point(0, 0)
        Me.LabelHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(1200, 40)
        Me.LabelHeader.TabIndex = 0
        Me.LabelHeader.Text = "LINK WAITER TO LOCATION"
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
        'DataGridViewImageColumn1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.NullValue = CType(resources.GetObject("DataGridViewCellStyle5.NullValue"), Object)
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Control
        Me.DataGridViewImageColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewImageColumn1.FillWeight = 25.0!
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.FNBManagement.My.Resources.Resources.data_edit1
        Me.DataGridViewImageColumn1.MinimumWidth = 25
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.ToolTipText = "Click to edit the Row"
        Me.DataGridViewImageColumn1.Width = 25
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.FillWeight = 25.0!
        Me.DataGridViewImageColumn2.Frozen = True
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Image = Global.FNBManagement.My.Resources.Resources.data_delete2
        Me.DataGridViewImageColumn2.MinimumWidth = 25
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.Width = 25
        '
        'FrmLinkWaiter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.PanelContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = true
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmLinkWaiter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Link Waiter to Location"
        Me.TopMost = true
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelContainer.ResumeLayout(false)
        Me.PanelEntry.ResumeLayout(false)
        CType(Me.dgLinkLocationWaiter,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelWaiter.ResumeLayout(false)
        Me.PanelWaiter.PerformLayout
        Me.PanelFooter.ResumeLayout(false)
        Me.PanelHeader.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents PanelContainer As System.Windows.Forms.Panel
    Friend WithEvents PanelEntry As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgLinkLocationWaiter As System.Windows.Forms.DataGridView
    Friend WithEvents labelRecordCount As System.Windows.Forms.Label
    Friend WithEvents dgbtnEdit As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents dgbtnDel As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PanelWaiter As System.Windows.Forms.Panel
    Friend WithEvents cmbWaiter As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddWaiter As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn


End Class
