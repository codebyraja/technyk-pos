<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberEnquiry
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
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.PanelSearch = New System.Windows.Forms.Panel()
        Me.dgsearch = New System.Windows.Forms.DataGridView()
        Me.PanelSpace = New System.Windows.Forms.Panel()
        Me.labelRecordCount = New System.Windows.Forms.Label()
        Me.PanelSearchTop2 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbCategoryTypeSub = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbCategoryType = New System.Windows.Forms.ComboBox()
        Me.chbDoBFrom = New System.Windows.Forms.CheckBox()
        Me.dtpDoBTo = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chbDateOfBirthTo = New System.Windows.Forms.CheckBox()
        Me.cmbCitizenType = New System.Windows.Forms.ComboBox()
        Me.dtpDoBFrom = New System.Windows.Forms.DateTimePicker()
        Me.PanelSearchTop1 = New System.Windows.Forms.Panel()
        Me.txtServiceNo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtMobile2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblNameSearch = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.dtpValidUpTo = New System.Windows.Forms.DateTimePicker()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtMobile1 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtC_ID = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtM_ID = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelFooter = New System.Windows.Forms.Panel()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PanelLine = New System.Windows.Forms.Panel()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PanelContainer.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        CType(Me.dgsearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSearchTop2.SuspendLayout()
        Me.PanelSearchTop1.SuspendLayout()
        Me.PanelFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.Transparent
        Me.PanelContainer.Controls.Add(Me.PanelSearch)
        Me.PanelContainer.Controls.Add(Me.PanelFooter)
        Me.PanelContainer.Controls.Add(Me.PanelLine)
        Me.PanelContainer.Controls.Add(Me.LabelHeader)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelContainer.Size = New System.Drawing.Size(1200, 700)
        Me.PanelContainer.TabIndex = 0
        '
        'PanelSearch
        '
        Me.PanelSearch.BackColor = System.Drawing.Color.Transparent
        Me.PanelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearch.Controls.Add(Me.dgsearch)
        Me.PanelSearch.Controls.Add(Me.PanelSpace)
        Me.PanelSearch.Controls.Add(Me.labelRecordCount)
        Me.PanelSearch.Controls.Add(Me.PanelSearchTop2)
        Me.PanelSearch.Controls.Add(Me.PanelSearchTop1)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSearch.Location = New System.Drawing.Point(10, 52)
        Me.PanelSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelSearch.Size = New System.Drawing.Size(1180, 588)
        Me.PanelSearch.TabIndex = 0
        '
        'dgsearch
        '
        Me.dgsearch.AllowUserToAddRows = False
        Me.dgsearch.AllowUserToDeleteRows = False
        Me.dgsearch.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgsearch.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgsearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsearch.GridColor = System.Drawing.Color.Coral
        Me.dgsearch.Location = New System.Drawing.Point(10, 201)
        Me.dgsearch.Margin = New System.Windows.Forms.Padding(4)
        Me.dgsearch.Name = "dgsearch"
        Me.dgsearch.RowHeadersWidth = 20
        Me.dgsearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgsearch.Size = New System.Drawing.Size(1158, 350)
        Me.dgsearch.TabIndex = 2
        '
        'PanelSpace
        '
        Me.PanelSpace.BackColor = System.Drawing.Color.Transparent
        Me.PanelSpace.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSpace.Location = New System.Drawing.Point(10, 191)
        Me.PanelSpace.Name = "PanelSpace"
        Me.PanelSpace.Size = New System.Drawing.Size(1158, 10)
        Me.PanelSpace.TabIndex = 3
        '
        'labelRecordCount
        '
        Me.labelRecordCount.BackColor = System.Drawing.Color.Transparent
        Me.labelRecordCount.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.labelRecordCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelRecordCount.Location = New System.Drawing.Point(10, 551)
        Me.labelRecordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelRecordCount.Name = "labelRecordCount"
        Me.labelRecordCount.Size = New System.Drawing.Size(1158, 25)
        Me.labelRecordCount.TabIndex = 16
        Me.labelRecordCount.Text = "Record"
        '
        'PanelSearchTop2
        '
        Me.PanelSearchTop2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearchTop2.Controls.Add(Me.Label15)
        Me.PanelSearchTop2.Controls.Add(Me.cmbCategoryTypeSub)
        Me.PanelSearchTop2.Controls.Add(Me.Label10)
        Me.PanelSearchTop2.Controls.Add(Me.cmbCategoryType)
        Me.PanelSearchTop2.Controls.Add(Me.chbDoBFrom)
        Me.PanelSearchTop2.Controls.Add(Me.dtpDoBTo)
        Me.PanelSearchTop2.Controls.Add(Me.Label11)
        Me.PanelSearchTop2.Controls.Add(Me.chbDateOfBirthTo)
        Me.PanelSearchTop2.Controls.Add(Me.cmbCitizenType)
        Me.PanelSearchTop2.Controls.Add(Me.dtpDoBFrom)
        Me.PanelSearchTop2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSearchTop2.Location = New System.Drawing.Point(10, 127)
        Me.PanelSearchTop2.Name = "PanelSearchTop2"
        Me.PanelSearchTop2.Size = New System.Drawing.Size(1158, 64)
        Me.PanelSearchTop2.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(545, 3)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(127, 20)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Cat. Type Sub"
        '
        'cmbCategoryTypeSub
        '
        Me.cmbCategoryTypeSub.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCategoryTypeSub.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCategoryTypeSub.BackColor = System.Drawing.Color.White
        Me.cmbCategoryTypeSub.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCategoryTypeSub.DropDownWidth = 200
        Me.cmbCategoryTypeSub.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoryTypeSub.ForeColor = System.Drawing.Color.Black
        Me.cmbCategoryTypeSub.FormattingEnabled = True
        Me.cmbCategoryTypeSub.Location = New System.Drawing.Point(549, 28)
        Me.cmbCategoryTypeSub.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCategoryTypeSub.Name = "cmbCategoryTypeSub"
        Me.cmbCategoryTypeSub.Size = New System.Drawing.Size(262, 26)
        Me.cmbCategoryTypeSub.Sorted = True
        Me.cmbCategoryTypeSub.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(282, 3)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 20)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Cat. Type"
        '
        'cmbCategoryType
        '
        Me.cmbCategoryType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCategoryType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCategoryType.BackColor = System.Drawing.Color.White
        Me.cmbCategoryType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCategoryType.DropDownWidth = 200
        Me.cmbCategoryType.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoryType.ForeColor = System.Drawing.Color.Black
        Me.cmbCategoryType.FormattingEnabled = True
        Me.cmbCategoryType.Location = New System.Drawing.Point(286, 28)
        Me.cmbCategoryType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCategoryType.Name = "cmbCategoryType"
        Me.cmbCategoryType.Size = New System.Drawing.Size(255, 26)
        Me.cmbCategoryType.Sorted = True
        Me.cmbCategoryType.TabIndex = 13
        '
        'chbDoBFrom
        '
        Me.chbDoBFrom.AutoSize = True
        Me.chbDoBFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbDoBFrom.Location = New System.Drawing.Point(822, 3)
        Me.chbDoBFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.chbDoBFrom.Name = "chbDoBFrom"
        Me.chbDoBFrom.Size = New System.Drawing.Size(144, 24)
        Me.chbDoBFrom.TabIndex = 16
        Me.chbDoBFrom.Text = "Date Of Birth"
        Me.chbDoBFrom.UseVisualStyleBackColor = True
        '
        'dtpDoBTo
        '
        Me.dtpDoBTo.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDoBTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDoBTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDoBTo.Location = New System.Drawing.Point(989, 28)
        Me.dtpDoBTo.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDoBTo.Name = "dtpDoBTo"
        Me.dtpDoBTo.Size = New System.Drawing.Size(159, 27)
        Me.dtpDoBTo.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 3)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Citizen Type"
        '
        'chbDateOfBirthTo
        '
        Me.chbDateOfBirthTo.AutoSize = True
        Me.chbDateOfBirthTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbDateOfBirthTo.Location = New System.Drawing.Point(989, 1)
        Me.chbDateOfBirthTo.Margin = New System.Windows.Forms.Padding(4)
        Me.chbDateOfBirthTo.Name = "chbDateOfBirthTo"
        Me.chbDateOfBirthTo.Size = New System.Drawing.Size(105, 24)
        Me.chbDateOfBirthTo.TabIndex = 18
        Me.chbDateOfBirthTo.Text = "Between"
        Me.chbDateOfBirthTo.UseVisualStyleBackColor = True
        '
        'cmbCitizenType
        '
        Me.cmbCitizenType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCitizenType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCitizenType.BackColor = System.Drawing.Color.White
        Me.cmbCitizenType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCitizenType.DropDownWidth = 200
        Me.cmbCitizenType.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCitizenType.ForeColor = System.Drawing.Color.Black
        Me.cmbCitizenType.FormattingEnabled = True
        Me.cmbCitizenType.Location = New System.Drawing.Point(15, 28)
        Me.cmbCitizenType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCitizenType.Name = "cmbCitizenType"
        Me.cmbCitizenType.Size = New System.Drawing.Size(260, 26)
        Me.cmbCitizenType.Sorted = True
        Me.cmbCitizenType.TabIndex = 11
        '
        'dtpDoBFrom
        '
        Me.dtpDoBFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDoBFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDoBFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDoBFrom.Location = New System.Drawing.Point(822, 28)
        Me.dtpDoBFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDoBFrom.Name = "dtpDoBFrom"
        Me.dtpDoBFrom.Size = New System.Drawing.Size(159, 27)
        Me.dtpDoBFrom.TabIndex = 17
        '
        'PanelSearchTop1
        '
        Me.PanelSearchTop1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearchTop1.Controls.Add(Me.txtServiceNo)
        Me.PanelSearchTop1.Controls.Add(Me.Label19)
        Me.PanelSearchTop1.Controls.Add(Me.txtMobile2)
        Me.PanelSearchTop1.Controls.Add(Me.Label6)
        Me.PanelSearchTop1.Controls.Add(Me.LblNameSearch)
        Me.PanelSearchTop1.Controls.Add(Me.txtAddress)
        Me.PanelSearchTop1.Controls.Add(Me.Label18)
        Me.PanelSearchTop1.Controls.Add(Me.txtCity)
        Me.PanelSearchTop1.Controls.Add(Me.Label7)
        Me.PanelSearchTop1.Controls.Add(Me.txtState)
        Me.PanelSearchTop1.Controls.Add(Me.txtTitle)
        Me.PanelSearchTop1.Controls.Add(Me.dtpValidUpTo)
        Me.PanelSearchTop1.Controls.Add(Me.txtEmail)
        Me.PanelSearchTop1.Controls.Add(Me.txtLName)
        Me.PanelSearchTop1.Controls.Add(Me.cmbStatus)
        Me.PanelSearchTop1.Controls.Add(Me.txtMobile1)
        Me.PanelSearchTop1.Controls.Add(Me.Label14)
        Me.PanelSearchTop1.Controls.Add(Me.txtMName)
        Me.PanelSearchTop1.Controls.Add(Me.Label13)
        Me.PanelSearchTop1.Controls.Add(Me.Label17)
        Me.PanelSearchTop1.Controls.Add(Me.Label9)
        Me.PanelSearchTop1.Controls.Add(Me.Label2)
        Me.PanelSearchTop1.Controls.Add(Me.Label8)
        Me.PanelSearchTop1.Controls.Add(Me.Label16)
        Me.PanelSearchTop1.Controls.Add(Me.txtC_ID)
        Me.PanelSearchTop1.Controls.Add(Me.Label12)
        Me.PanelSearchTop1.Controls.Add(Me.Label4)
        Me.PanelSearchTop1.Controls.Add(Me.txtM_ID)
        Me.PanelSearchTop1.Controls.Add(Me.txtFName)
        Me.PanelSearchTop1.Controls.Add(Me.Label3)
        Me.PanelSearchTop1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSearchTop1.Location = New System.Drawing.Point(10, 10)
        Me.PanelSearchTop1.Name = "PanelSearchTop1"
        Me.PanelSearchTop1.Size = New System.Drawing.Size(1158, 117)
        Me.PanelSearchTop1.TabIndex = 17
        '
        'txtServiceNo
        '
        Me.txtServiceNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtServiceNo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceNo.Location = New System.Drawing.Point(1047, 28)
        Me.txtServiceNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtServiceNo.MaxLength = 50
        Me.txtServiceNo.Name = "txtServiceNo"
        Me.txtServiceNo.Size = New System.Drawing.Size(100, 27)
        Me.txtServiceNo.TabIndex = 45
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(1042, 4)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 20)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "Service No."
        '
        'txtMobile2
        '
        Me.txtMobile2.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobile2.Location = New System.Drawing.Point(150, 83)
        Me.txtMobile2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMobile2.Name = "txtMobile2"
        Me.txtMobile2.Size = New System.Drawing.Size(125, 27)
        Me.txtMobile2.TabIndex = 49
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(967, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 20)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Status"
        '
        'LblNameSearch
        '
        Me.LblNameSearch.AutoSize = True
        Me.LblNameSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNameSearch.Location = New System.Drawing.Point(11, 4)
        Me.LblNameSearch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNameSearch.Name = "LblNameSearch"
        Me.LblNameSearch.Size = New System.Drawing.Size(49, 20)
        Me.LblNameSearch.TabIndex = 30
        Me.LblNameSearch.Text = "C_ID"
        '
        'txtAddress
        '
        Me.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtAddress.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(893, 28)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddress.MaxLength = 50
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(142, 27)
        Me.txtAddress.TabIndex = 43
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(146, 59)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 20)
        Me.Label18.TabIndex = 48
        Me.Label18.Text = "Mobile2"
        '
        'txtCity
        '
        Me.txtCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtCity.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Location = New System.Drawing.Point(452, 83)
        Me.txtCity.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCity.MaxLength = 50
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(139, 27)
        Me.txtCity.TabIndex = 53
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(282, 4)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 20)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Title/Rank"
        '
        'txtState
        '
        Me.txtState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtState.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtState.Location = New System.Drawing.Point(602, 83)
        Me.txtState.Margin = New System.Windows.Forms.Padding(4)
        Me.txtState.MaxLength = 50
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(137, 27)
        Me.txtState.TabIndex = 55
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(286, 28)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(157, 27)
        Me.txtTitle.TabIndex = 35
        '
        'dtpValidUpTo
        '
        Me.dtpValidUpTo.CustomFormat = "dd/MMM/yyyy"
        Me.dtpValidUpTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpValidUpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpValidUpTo.Location = New System.Drawing.Point(286, 83)
        Me.dtpValidUpTo.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpValidUpTo.Name = "dtpValidUpTo"
        Me.dtpValidUpTo.Size = New System.Drawing.Size(157, 27)
        Me.dtpValidUpTo.TabIndex = 51
        '
        'txtEmail
        '
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(748, 83)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(211, 27)
        Me.txtEmail.TabIndex = 57
        '
        'txtLName
        '
        Me.txtLName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtLName.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLName.Location = New System.Drawing.Point(748, 28)
        Me.txtLName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLName.MaxLength = 50
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(137, 27)
        Me.txtLName.TabIndex = 41
        '
        'cmbStatus
        '
        Me.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStatus.BackColor = System.Drawing.Color.White
        Me.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbStatus.DropDownWidth = 200
        Me.cmbStatus.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatus.ForeColor = System.Drawing.Color.Black
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(971, 83)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(177, 26)
        Me.cmbStatus.Sorted = True
        Me.cmbStatus.TabIndex = 59
        '
        'txtMobile1
        '
        Me.txtMobile1.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobile1.Location = New System.Drawing.Point(17, 82)
        Me.txtMobile1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMobile1.Name = "txtMobile1"
        Me.txtMobile1.Size = New System.Drawing.Size(125, 27)
        Me.txtMobile1.TabIndex = 47
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(146, 4)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 20)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "M_ID"
        '
        'txtMName
        '
        Me.txtMName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtMName.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMName.Location = New System.Drawing.Point(602, 28)
        Me.txtMName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMName.MaxLength = 50
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(137, 27)
        Me.txtMName.TabIndex = 39
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(598, 59)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 20)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "State"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(744, 59)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 20)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "Email"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(448, 59)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 20)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "City"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(448, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "First Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(889, 4)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 20)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Address"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(11, 59)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 20)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "Mobile1"
        '
        'txtC_ID
        '
        Me.txtC_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtC_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtC_ID.Location = New System.Drawing.Point(15, 28)
        Me.txtC_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtC_ID.Name = "txtC_ID"
        Me.txtC_ID.Size = New System.Drawing.Size(125, 27)
        Me.txtC_ID.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(282, 59)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Valid Upto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(744, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 20)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Last Name"
        '
        'txtM_ID
        '
        Me.txtM_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtM_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtM_ID.Location = New System.Drawing.Point(150, 28)
        Me.txtM_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtM_ID.Name = "txtM_ID"
        Me.txtM_ID.Size = New System.Drawing.Size(125, 27)
        Me.txtM_ID.TabIndex = 33
        '
        'txtFName
        '
        Me.txtFName.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFName.Location = New System.Drawing.Point(452, 28)
        Me.txtFName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(139, 27)
        Me.txtFName.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(598, 4)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 20)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Middle Name"
        '
        'PanelFooter
        '
        Me.PanelFooter.Controls.Add(Me.btnExportToExcel)
        Me.PanelFooter.Controls.Add(Me.btnSearch)
        Me.PanelFooter.Controls.Add(Me.btnClose)
        Me.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFooter.Location = New System.Drawing.Point(10, 640)
        Me.PanelFooter.Name = "PanelFooter"
        Me.PanelFooter.Size = New System.Drawing.Size(1180, 50)
        Me.PanelFooter.TabIndex = 48
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.AutoSize = True
        Me.btnExportToExcel.BackColor = System.Drawing.Color.Transparent
        Me.btnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportToExcel.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btnExportToExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Beige
        Me.btnExportToExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnExportToExcel.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnExportToExcel.ForeColor = System.Drawing.Color.Black
        Me.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportToExcel.ImageKey = "find.ico"
        Me.btnExportToExcel.Location = New System.Drawing.Point(547, 7)
        Me.btnExportToExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(160, 40)
        Me.btnExportToExcel.TabIndex = 54
        Me.btnExportToExcel.Text = "Export to Excel"
        Me.btnExportToExcel.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.AutoSize = True
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Beige
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImageKey = "(none)"
        Me.btnSearch.Location = New System.Drawing.Point(428, 7)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(111, 40)
        Me.btnSearch.TabIndex = 52
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageKey = "(none)"
        Me.btnClose.Location = New System.Drawing.Point(715, 7)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 40)
        Me.btnClose.TabIndex = 53
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
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
        Me.PanelLine.TabIndex = 47
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelHeader.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader.ForeColor = System.Drawing.Color.Silver
        Me.LabelHeader.Location = New System.Drawing.Point(10, 10)
        Me.LabelHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(1180, 40)
        Me.LabelHeader.TabIndex = 1
        Me.LabelHeader.Text = "MEMBER ENQUIRY"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMemberEnquiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.PanelContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMemberEnquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Member Enquiry"
        Me.TopMost = True
        Me.PanelContainer.ResumeLayout(False)
        Me.PanelSearch.ResumeLayout(False)
        CType(Me.dgsearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSearchTop2.ResumeLayout(False)
        Me.PanelSearchTop2.PerformLayout()
        Me.PanelSearchTop1.ResumeLayout(False)
        Me.PanelSearchTop1.PerformLayout()
        Me.PanelFooter.ResumeLayout(False)
        Me.PanelFooter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelSpace As System.Windows.Forms.Panel
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents PanelContainer As System.Windows.Forms.Panel
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents dgsearch As System.Windows.Forms.DataGridView
    Friend WithEvents labelRecordCount As System.Windows.Forms.Label
    Friend WithEvents PanelLine As System.Windows.Forms.Panel
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents btnExportToExcel As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PanelSearchTop1 As System.Windows.Forms.Panel
    Friend WithEvents txtServiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtMobile2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblNameSearch As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents dtpValidUpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtMobile1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtC_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtM_ID As System.Windows.Forms.TextBox
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PanelSearchTop2 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbCategoryTypeSub As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbCategoryType As System.Windows.Forms.ComboBox
    Friend WithEvents chbDoBFrom As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDoBTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chbDateOfBirthTo As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCitizenType As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDoBFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
