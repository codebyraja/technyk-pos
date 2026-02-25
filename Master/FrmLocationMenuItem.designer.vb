<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLocationMenuItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLocationMenuItem))
        Me.LabelHeader = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelEntry = New System.Windows.Forms.Panel
        Me.labelRecordCount = New System.Windows.Forms.Label
        Me.dgLocationMenu = New System.Windows.Forms.DataGridView
        Me.dgbtnEdit = New System.Windows.Forms.DataGridViewImageColumn
        Me.dgbtnDelete = New System.Windows.Forms.DataGridViewImageColumn
        Me.btnAddGroup = New System.Windows.Forms.Button
        Me.cmbMainGroup = New System.Windows.Forms.ComboBox
        Me.cmbLocation = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbItem = New System.Windows.Forms.ComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel3.SuspendLayout()
        Me.PanelEntry.SuspendLayout()
        CType(Me.dgLocationMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.LabelHeader.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHeader.ForeColor = System.Drawing.Color.Black
        Me.LabelHeader.Location = New System.Drawing.Point(1, 1)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(1018, 29)
        Me.LabelHeader.TabIndex = 0
        Me.LabelHeader.Text = "LOCATION MENU"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnClose.Location = New System.Drawing.Point(549, 639)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(78, 26)
        Me.btnClose.TabIndex = 3
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
        Me.btnCancel.Location = New System.Drawing.Point(471, 639)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 26)
        Me.btnCancel.TabIndex = 2
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
        Me.btnAdd.Location = New System.Drawing.Point(393, 639)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(78, 26)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.LabelHeader)
        Me.Panel3.Controls.Add(Me.btnClose)
        Me.Panel3.Controls.Add(Me.PanelEntry)
        Me.Panel3.Controls.Add(Me.btnCancel)
        Me.Panel3.Controls.Add(Me.btnAdd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.ForeColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1020, 680)
        Me.Panel3.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 2)
        Me.Panel1.TabIndex = 45
        '
        'PanelEntry
        '
        Me.PanelEntry.BackColor = System.Drawing.Color.Transparent
        Me.PanelEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEntry.Controls.Add(Me.labelRecordCount)
        Me.PanelEntry.Controls.Add(Me.dgLocationMenu)
        Me.PanelEntry.Controls.Add(Me.btnAddGroup)
        Me.PanelEntry.Controls.Add(Me.cmbMainGroup)
        Me.PanelEntry.Controls.Add(Me.cmbLocation)
        Me.PanelEntry.Controls.Add(Me.Label27)
        Me.PanelEntry.Controls.Add(Me.Label2)
        Me.PanelEntry.Controls.Add(Me.Label3)
        Me.PanelEntry.Controls.Add(Me.cmbItem)
        Me.PanelEntry.Location = New System.Drawing.Point(156, 81)
        Me.PanelEntry.Name = "PanelEntry"
        Me.PanelEntry.Size = New System.Drawing.Size(709, 519)
        Me.PanelEntry.TabIndex = 0
        '
        'labelRecordCount
        '
        Me.labelRecordCount.BackColor = System.Drawing.Color.Transparent
        Me.labelRecordCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.labelRecordCount.Location = New System.Drawing.Point(3, 496)
        Me.labelRecordCount.Name = "labelRecordCount"
        Me.labelRecordCount.Size = New System.Drawing.Size(703, 19)
        Me.labelRecordCount.TabIndex = 8
        '
        'dgLocationMenu
        '
        Me.dgLocationMenu.AllowUserToAddRows = False
        Me.dgLocationMenu.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(250, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLocationMenu.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLocationMenu.BackgroundColor = System.Drawing.Color.White
        Me.dgLocationMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLocationMenu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgLocationMenu.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLocationMenu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgLocationMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLocationMenu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgbtnEdit, Me.dgbtnDelete})
        Me.dgLocationMenu.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLocationMenu.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgLocationMenu.GridColor = System.Drawing.Color.Chocolate
        Me.dgLocationMenu.Location = New System.Drawing.Point(5, 103)
        Me.dgLocationMenu.MultiSelect = False
        Me.dgLocationMenu.Name = "dgLocationMenu"
        Me.dgLocationMenu.ReadOnly = True
        Me.dgLocationMenu.RowHeadersVisible = False
        Me.dgLocationMenu.RowHeadersWidth = 20
        Me.dgLocationMenu.Size = New System.Drawing.Size(697, 391)
        Me.dgLocationMenu.TabIndex = 7
        Me.dgLocationMenu.TabStop = False
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
        'dgbtnDelete
        '
        Me.dgbtnDelete.FillWeight = 25.0!
        Me.dgbtnDelete.HeaderText = ""
        Me.dgbtnDelete.Image = Global.FNBManagement.My.Resources.Resources.data_delete1
        Me.dgbtnDelete.MinimumWidth = 25
        Me.dgbtnDelete.Name = "dgbtnDelete"
        Me.dgbtnDelete.ReadOnly = True
        Me.dgbtnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgbtnDelete.Width = 25
        '
        'btnAddGroup
        '
        Me.btnAddGroup.BackColor = System.Drawing.Color.Transparent
        Me.btnAddGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddGroup.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.btnAddGroup.ForeColor = System.Drawing.Color.Black
        Me.btnAddGroup.Location = New System.Drawing.Point(362, 70)
        Me.btnAddGroup.Name = "btnAddGroup"
        Me.btnAddGroup.Size = New System.Drawing.Size(95, 25)
        Me.btnAddGroup.TabIndex = 6
        Me.btnAddGroup.Text = "Add Item"
        Me.btnAddGroup.UseVisualStyleBackColor = False
        '
        'cmbMainGroup
        '
        Me.cmbMainGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMainGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMainGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbMainGroup.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMainGroup.FormattingEnabled = True
        Me.cmbMainGroup.Location = New System.Drawing.Point(92, 39)
        Me.cmbMainGroup.Name = "cmbMainGroup"
        Me.cmbMainGroup.Size = New System.Drawing.Size(266, 23)
        Me.cmbMainGroup.TabIndex = 3
        '
        'cmbLocation
        '
        Me.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbLocation.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(92, 8)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(266, 23)
        Me.cmbLocation.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label27.Location = New System.Drawing.Point(2, 43)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(85, 16)
        Me.Label27.TabIndex = 2
        Me.Label27.Text = "Main Group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(2, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Item Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lucida Fax", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(2, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Location"
        '
        'cmbItem
        '
        Me.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbItem.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItem.FormattingEnabled = True
        Me.cmbItem.Location = New System.Drawing.Point(92, 70)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(266, 23)
        Me.cmbItem.TabIndex = 5
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.[Error]
        Me.ToolTip1.ToolTipTitle = "Banquet Mgmt"
        '
        'FrmLocationMenuItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1020, 680)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLocationMenuItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Group"
        Me.TopMost = True
        Me.Panel3.ResumeLayout(False)
        Me.PanelEntry.ResumeLayout(False)
        Me.PanelEntry.PerformLayout()
        CType(Me.dgLocationMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelEntry As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbMainGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dgLocationMenu As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddGroup As System.Windows.Forms.Button
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents labelRecordCount As System.Windows.Forms.Label
    Friend WithEvents dgbtnEdit As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents dgbtnDelete As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip


End Class
