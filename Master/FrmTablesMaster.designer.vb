<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTableMaster
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTableMaster))
        Me.LabelHeader = New System.Windows.Forms.Label
        Me.dgsearch = New System.Windows.Forms.DataGridView
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbLocation = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtTableNo = New System.Windows.Forms.TextBox
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmbLocationSearch = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDescriptionSearch = New System.Windows.Forms.TextBox
        Me.txtTableNoSearch = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelEntry = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelSearch = New System.Windows.Forms.Panel
        Me.LabelRecordCount = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgsearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEntry.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.LabelHeader.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHeader.ForeColor = System.Drawing.Color.Black
        Me.LabelHeader.Location = New System.Drawing.Point(-1, 0)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(1020, 30)
        Me.LabelHeader.TabIndex = 0
        Me.LabelHeader.Text = "POS TABLE MASTER"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgsearch
        '
        Me.dgsearch.AllowUserToAddRows = False
        Me.dgsearch.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(250, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgsearch.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgsearch.BackgroundColor = System.Drawing.Color.White
        Me.dgsearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgsearch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgsearch.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgsearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgsearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgsearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Edit})
        Me.dgsearch.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgsearch.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgsearch.GridColor = System.Drawing.Color.Chocolate
        Me.dgsearch.Location = New System.Drawing.Point(5, 65)
        Me.dgsearch.MultiSelect = False
        Me.dgsearch.Name = "dgsearch"
        Me.dgsearch.ReadOnly = True
        Me.dgsearch.RowHeadersVisible = False
        Me.dgsearch.Size = New System.Drawing.Size(510, 517)
        Me.dgsearch.TabIndex = 6
        Me.dgsearch.TabStop = False
        '
        'Edit
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.NullValue = CType(resources.GetObject("DataGridViewCellStyle3.NullValue"), Object)
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Lucida Fax", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(66, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 15)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "*"
        '
        'cmbLocation
        '
        Me.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbLocation.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(115, 106)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(229, 23)
        Me.cmbLocation.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(3, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Location"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Lucida Fax", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(66, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 15)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(3, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(3, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Code"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(115, 76)
        Me.txtDescription.MaxLength = 100
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(229, 23)
        Me.txtDescription.TabIndex = 6
        '
        'txtTableNo
        '
        Me.txtTableNo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableNo.Location = New System.Drawing.Point(115, 47)
        Me.txtTableNo.MaxLength = 50
        Me.txtTableNo.Name = "txtTableNo"
        Me.txtTableNo.Size = New System.Drawing.Size(100, 23)
        Me.txtTableNo.TabIndex = 4
        '
        'txtCode
        '
        Me.txtCode.Enabled = False
        Me.txtCode.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(115, 17)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 23)
        Me.txtCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(3, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Table No"
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
        Me.btnDelete.Location = New System.Drawing.Point(171, 639)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(78, 26)
        Me.btnDelete.TabIndex = 3
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
        Me.btnClose.Location = New System.Drawing.Point(327, 639)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(78, 26)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
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
        Me.btnCancel.Location = New System.Drawing.Point(249, 639)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 26)
        Me.btnCancel.TabIndex = 4
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
        Me.btnEdit.Location = New System.Drawing.Point(93, 639)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(78, 26)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
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
        Me.btnAdd.Location = New System.Drawing.Point(15, 639)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(78, 26)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmbLocationSearch
        '
        Me.cmbLocationSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLocationSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocationSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbLocationSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLocationSearch.FormattingEnabled = True
        Me.cmbLocationSearch.Location = New System.Drawing.Point(338, 34)
        Me.cmbLocationSearch.Name = "cmbLocationSearch"
        Me.cmbLocationSearch.Size = New System.Drawing.Size(176, 23)
        Me.cmbLocationSearch.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(342, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Location"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(119, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Description"
        '
        'txtDescriptionSearch
        '
        Me.txtDescriptionSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescriptionSearch.Location = New System.Drawing.Point(116, 35)
        Me.txtDescriptionSearch.MaxLength = 100
        Me.txtDescriptionSearch.Name = "txtDescriptionSearch"
        Me.txtDescriptionSearch.Size = New System.Drawing.Size(217, 23)
        Me.txtDescriptionSearch.TabIndex = 3
        '
        'txtTableNoSearch
        '
        Me.txtTableNoSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableNoSearch.Location = New System.Drawing.Point(5, 35)
        Me.txtTableNoSearch.MaxLength = 50
        Me.txtTableNoSearch.Name = "txtTableNoSearch"
        Me.txtTableNoSearch.Size = New System.Drawing.Size(105, 23)
        Me.txtTableNoSearch.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(8, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Table No"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 2)
        Me.Panel1.TabIndex = 45
        '
        'PanelEntry
        '
        Me.PanelEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEntry.Controls.Add(Me.Label8)
        Me.PanelEntry.Controls.Add(Me.txtCode)
        Me.PanelEntry.Controls.Add(Me.cmbLocation)
        Me.PanelEntry.Controls.Add(Me.Label2)
        Me.PanelEntry.Controls.Add(Me.Label6)
        Me.PanelEntry.Controls.Add(Me.txtTableNo)
        Me.PanelEntry.Controls.Add(Me.Label10)
        Me.PanelEntry.Controls.Add(Me.txtDescription)
        Me.PanelEntry.Controls.Add(Me.Label3)
        Me.PanelEntry.Controls.Add(Me.Label7)
        Me.PanelEntry.Location = New System.Drawing.Point(12, 52)
        Me.PanelEntry.Name = "PanelEntry"
        Me.PanelEntry.Size = New System.Drawing.Size(355, 139)
        Me.PanelEntry.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "ADD /EDIT TABLE NO"
        '
        'PanelSearch
        '
        Me.PanelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearch.Controls.Add(Me.LabelRecordCount)
        Me.PanelSearch.Controls.Add(Me.Label5)
        Me.PanelSearch.Controls.Add(Me.cmbLocationSearch)
        Me.PanelSearch.Controls.Add(Me.dgsearch)
        Me.PanelSearch.Controls.Add(Me.Label9)
        Me.PanelSearch.Controls.Add(Me.txtTableNoSearch)
        Me.PanelSearch.Controls.Add(Me.Label4)
        Me.PanelSearch.Controls.Add(Me.txtDescriptionSearch)
        Me.PanelSearch.Location = New System.Drawing.Point(485, 52)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(522, 609)
        Me.PanelSearch.TabIndex = 6
        '
        'LabelRecordCount
        '
        Me.LabelRecordCount.BackColor = System.Drawing.Color.Transparent
        Me.LabelRecordCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelRecordCount.Location = New System.Drawing.Point(2, 586)
        Me.LabelRecordCount.Name = "LabelRecordCount"
        Me.LabelRecordCount.Size = New System.Drawing.Size(516, 18)
        Me.LabelRecordCount.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(489, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(133, 15)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "SEARCH TABLE NO"
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.[Error]
        Me.ToolTip1.ToolTipTitle = "Banquet Mgmt"
        '
        'FrmTableMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1020, 680)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PanelSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PanelEntry)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.LabelHeader)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTableMaster"
        Me.Text = "POS Table Master"
        CType(Me.dgsearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEntry.ResumeLayout(False)
        Me.PanelEntry.PerformLayout()
        Me.PanelSearch.ResumeLayout(False)
        Me.PanelSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents dgsearch As System.Windows.Forms.DataGridView
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTableNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescriptionSearch As System.Windows.Forms.TextBox
    Friend WithEvents txtTableNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbLocationSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelEntry As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LabelRecordCount As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
