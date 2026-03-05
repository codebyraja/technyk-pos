<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWaiterMaster
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
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.PanelSearch = New System.Windows.Forms.Panel()
        Me.dgSearch = New System.Windows.Forms.DataGridView()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.labelRecordCount = New System.Windows.Forms.Label()
        Me.PanelSearchTop = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDisplayAsSearch = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbStatusSearch = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtWaiterSearch = New System.Windows.Forms.TextBox()
        Me.PanelEntry = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtWaiter = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDisplayAs = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PanelFooter = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.PanelSubHeader = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSearchTop.SuspendLayout()
        Me.PanelEntry.SuspendLayout()
        Me.PanelFooter.SuspendLayout()
        Me.PanelSubHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.[Error]
        Me.ToolTip1.ToolTipTitle = "Banquet Mgmt"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 37)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1200, 2)
        Me.Panel1.TabIndex = 60
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelHeader.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHeader.ForeColor = System.Drawing.Color.Silver
        Me.LabelHeader.Location = New System.Drawing.Point(0, 0)
        Me.LabelHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(1200, 37)
        Me.LabelHeader.TabIndex = 53
        Me.LabelHeader.Text = "WAITER MASTER"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelMain.Controls.Add(Me.PanelSearch)
        Me.PanelMain.Controls.Add(Me.PanelEntry)
        Me.PanelMain.Controls.Add(Me.PanelFooter)
        Me.PanelMain.Controls.Add(Me.PanelSubHeader)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 39)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1200, 661)
        Me.PanelMain.TabIndex = 61
        '
        'PanelSearch
        '
        Me.PanelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearch.Controls.Add(Me.dgSearch)
        Me.PanelSearch.Controls.Add(Me.labelRecordCount)
        Me.PanelSearch.Controls.Add(Me.PanelSearchTop)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSearch.Location = New System.Drawing.Point(296, 25)
        Me.PanelSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.PanelSearch.Size = New System.Drawing.Size(904, 586)
        Me.PanelSearch.TabIndex = 69
        '
        'dgSearch
        '
        Me.dgSearch.AllowUserToAddRows = False
        Me.dgSearch.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(250, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSearch.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSearch.BackgroundColor = System.Drawing.Color.White
        Me.dgSearch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgSearch.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Edit})
        Me.dgSearch.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSearch.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSearch.GridColor = System.Drawing.Color.Chocolate
        Me.dgSearch.Location = New System.Drawing.Point(10, 75)
        Me.dgSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.dgSearch.MultiSelect = False
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.ReadOnly = True
        Me.dgSearch.RowHeadersVisible = False
        Me.dgSearch.Size = New System.Drawing.Size(882, 499)
        Me.dgSearch.TabIndex = 6
        Me.dgSearch.TabStop = False
        '
        'Edit
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control
        Me.Edit.DefaultCellStyle = DataGridViewCellStyle3
        Me.Edit.FillWeight = 25.0!
        Me.Edit.Frozen = True
        Me.Edit.HeaderText = ""
        Me.Edit.Image = Global.FNBManagement.My.Resources.Resources.data_edit1
        Me.Edit.MinimumWidth = 25
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = True
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Edit.ToolTipText = "Click to edit the Row"
        Me.Edit.Width = 25
        '
        'labelRecordCount
        '
        Me.labelRecordCount.BackColor = System.Drawing.Color.Transparent
        Me.labelRecordCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.labelRecordCount.Location = New System.Drawing.Point(3, 721)
        Me.labelRecordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelRecordCount.Name = "labelRecordCount"
        Me.labelRecordCount.Size = New System.Drawing.Size(689, 22)
        Me.labelRecordCount.TabIndex = 7
        '
        'PanelSearchTop
        '
        Me.PanelSearchTop.Controls.Add(Me.Label9)
        Me.PanelSearchTop.Controls.Add(Me.txtDisplayAsSearch)
        Me.PanelSearchTop.Controls.Add(Me.Label5)
        Me.PanelSearchTop.Controls.Add(Me.cmbStatusSearch)
        Me.PanelSearchTop.Controls.Add(Me.Label6)
        Me.PanelSearchTop.Controls.Add(Me.txtWaiterSearch)
        Me.PanelSearchTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSearchTop.Location = New System.Drawing.Point(10, 0)
        Me.PanelSearchTop.Name = "PanelSearchTop"
        Me.PanelSearchTop.Size = New System.Drawing.Size(882, 75)
        Me.PanelSearchTop.TabIndex = 74
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(292, 7)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Display As"
        '
        'txtDisplayAsSearch
        '
        Me.txtDisplayAsSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtDisplayAsSearch.Location = New System.Drawing.Point(296, 33)
        Me.txtDisplayAsSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDisplayAsSearch.MaxLength = 50
        Me.txtDisplayAsSearch.Name = "txtDisplayAsSearch"
        Me.txtDisplayAsSearch.Size = New System.Drawing.Size(294, 27)
        Me.txtDisplayAsSearch.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(0, 7)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Waiter"
        '
        'cmbStatusSearch
        '
        Me.cmbStatusSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmbStatusSearch.FormattingEnabled = True
        Me.cmbStatusSearch.Items.AddRange(New Object() {"[Select All]", "Active", "Inactive"})
        Me.cmbStatusSearch.Location = New System.Drawing.Point(598, 35)
        Me.cmbStatusSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbStatusSearch.Name = "cmbStatusSearch"
        Me.cmbStatusSearch.Size = New System.Drawing.Size(284, 26)
        Me.cmbStatusSearch.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(605, 7)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Status"
        '
        'txtWaiterSearch
        '
        Me.txtWaiterSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtWaiterSearch.Location = New System.Drawing.Point(4, 33)
        Me.txtWaiterSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWaiterSearch.MaxLength = 50
        Me.txtWaiterSearch.Name = "txtWaiterSearch"
        Me.txtWaiterSearch.Size = New System.Drawing.Size(284, 27)
        Me.txtWaiterSearch.TabIndex = 7
        '
        'PanelEntry
        '
        Me.PanelEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEntry.Controls.Add(Me.Label8)
        Me.PanelEntry.Controls.Add(Me.txtCode)
        Me.PanelEntry.Controls.Add(Me.Label10)
        Me.PanelEntry.Controls.Add(Me.Label2)
        Me.PanelEntry.Controls.Add(Me.cmbStatus)
        Me.PanelEntry.Controls.Add(Me.txtWaiter)
        Me.PanelEntry.Controls.Add(Me.Label4)
        Me.PanelEntry.Controls.Add(Me.txtDisplayAs)
        Me.PanelEntry.Controls.Add(Me.Label3)
        Me.PanelEntry.Controls.Add(Me.Label7)
        Me.PanelEntry.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEntry.Location = New System.Drawing.Point(0, 25)
        Me.PanelEntry.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelEntry.Name = "PanelEntry"
        Me.PanelEntry.Size = New System.Drawing.Size(296, 586)
        Me.PanelEntry.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Lucida Fax", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(73, 135)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "*"
        '
        'txtCode
        '
        Me.txtCode.Enabled = False
        Me.txtCode.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Location = New System.Drawing.Point(112, 18)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(170, 27)
        Me.txtCode.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Lucida Fax", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(73, 63)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 17)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(4, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Waiter"
        '
        'cmbStatus
        '
        Me.cmbStatus.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"[Select One]", "Active", "Inactive"})
        Me.cmbStatus.Location = New System.Drawing.Point(112, 132)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(170, 26)
        Me.cmbStatus.TabIndex = 9
        '
        'txtWaiter
        '
        Me.txtWaiter.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtWaiter.Location = New System.Drawing.Point(112, 55)
        Me.txtWaiter.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWaiter.MaxLength = 50
        Me.txtWaiter.Name = "txtWaiter"
        Me.txtWaiter.Size = New System.Drawing.Size(170, 27)
        Me.txtWaiter.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(4, 134)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Status"
        '
        'txtDisplayAs
        '
        Me.txtDisplayAs.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtDisplayAs.Location = New System.Drawing.Point(112, 94)
        Me.txtDisplayAs.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDisplayAs.MaxLength = 100
        Me.txtDisplayAs.Name = "txtDisplayAs"
        Me.txtDisplayAs.Size = New System.Drawing.Size(170, 27)
        Me.txtDisplayAs.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(4, 98)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Display As"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(4, 23)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Code"
        '
        'PanelFooter
        '
        Me.PanelFooter.Controls.Add(Me.btnDelete)
        Me.PanelFooter.Controls.Add(Me.btnClose)
        Me.PanelFooter.Controls.Add(Me.btnAdd)
        Me.PanelFooter.Controls.Add(Me.btnCancel)
        Me.PanelFooter.Controls.Add(Me.btnEdit)
        Me.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFooter.Location = New System.Drawing.Point(0, 611)
        Me.PanelFooter.Name = "PanelFooter"
        Me.PanelFooter.Size = New System.Drawing.Size(1200, 50)
        Me.PanelFooter.TabIndex = 71
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDelete.Font = New System.Drawing.Font("Lucida Fax", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 2
        Me.btnDelete.Location = New System.Drawing.Point(576, 4)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 40)
        Me.btnDelete.TabIndex = 71
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Lucida Fax", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageKey = "(none)"
        Me.btnClose.Location = New System.Drawing.Point(784, 4)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 40)
        Me.btnClose.TabIndex = 73
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAdd.Font = New System.Drawing.Font("Lucida Fax", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.ImageKey = "(none)"
        Me.btnAdd.Location = New System.Drawing.Point(364, 4)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(101, 40)
        Me.btnAdd.TabIndex = 69
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Lucida Fax", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageKey = "(none)"
        Me.btnCancel.Location = New System.Drawing.Point(680, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 40)
        Me.btnCancel.TabIndex = 72
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnEdit.Font = New System.Drawing.Font("Lucida Fax", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageKey = "(none)"
        Me.btnEdit.Location = New System.Drawing.Point(472, 4)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 40)
        Me.btnEdit.TabIndex = 70
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'PanelSubHeader
        '
        Me.PanelSubHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelSubHeader.Controls.Add(Me.Label11)
        Me.PanelSubHeader.Controls.Add(Me.Label1)
        Me.PanelSubHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSubHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelSubHeader.Name = "PanelSubHeader"
        Me.PanelSubHeader.Size = New System.Drawing.Size(1200, 25)
        Me.PanelSubHeader.TabIndex = 73
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(293, 0)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(157, 20)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "SEARCH WAITER"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 20)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "ADD /EDIT WAITER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewImageColumn1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Control
        Me.DataGridViewImageColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewImageColumn1.FillWeight = 40.0!
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.FNBManagement.My.Resources.Resources.data_edit
        Me.DataGridViewImageColumn1.MinimumWidth = 40
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.ToolTipText = "Click to edit the Row"
        Me.DataGridViewImageColumn1.Width = 40
        '
        'FrmWaiterMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LabelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmWaiterMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmWaiterMaster"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelSearch.ResumeLayout(False)
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSearchTop.ResumeLayout(False)
        Me.PanelSearchTop.PerformLayout()
        Me.PanelEntry.ResumeLayout(False)
        Me.PanelEntry.PerformLayout()
        Me.PanelFooter.ResumeLayout(False)
        Me.PanelSubHeader.ResumeLayout(False)
        Me.PanelSubHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents labelRecordCount As System.Windows.Forms.Label
    Friend WithEvents dgSearch As System.Windows.Forms.DataGridView
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PanelEntry As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtWaiter As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDisplayAs As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelSubHeader As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents PanelSearchTop As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDisplayAsSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbStatusSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtWaiterSearch As System.Windows.Forms.TextBox
End Class
