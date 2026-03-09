<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpouseEnquiry
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
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.PanelSearch = New System.Windows.Forms.Panel()
        Me.dgSearch = New System.Windows.Forms.DataGridView()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.PanelFilterControls = New System.Windows.Forms.Panel()
        Me.chbDoBFrom = New System.Windows.Forms.CheckBox()
        Me.dtpDoBTo = New System.Windows.Forms.DateTimePicker()
        Me.chbDateOfBirthTo = New System.Windows.Forms.CheckBox()
        Me.dtpDoBFrom = New System.Windows.Forms.DateTimePicker()
        Me.chbAnniversaryDateFrom = New System.Windows.Forms.CheckBox()
        Me.dtpAnniversaryDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpAnniversaryDateTo = New System.Windows.Forms.DateTimePicker()
        Me.chbAnniversaryDateTo = New System.Windows.Forms.CheckBox()
        Me.LblNameSearch = New System.Windows.Forms.Label()
        Me.txtMemberName = New System.Windows.Forms.TextBox()
        Me.txtM_ID = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSpouseName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtC_ID = New System.Windows.Forms.TextBox()
        Me.PanelFooter = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PanelLine = New System.Windows.Forms.Panel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelContainer.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelFilterControls.SuspendLayout()
        Me.PanelFooter.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.LabelHeader.TabIndex = 0
        Me.LabelHeader.Text = "SPOUSE ENQUIRY"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.PanelSearch.Controls.Add(Me.dgSearch)
        Me.PanelSearch.Controls.Add(Me.lblRecordCount)
        Me.PanelSearch.Controls.Add(Me.PanelFilterControls)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSearch.Location = New System.Drawing.Point(10, 52)
        Me.PanelSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelSearch.Size = New System.Drawing.Size(1180, 588)
        Me.PanelSearch.TabIndex = 0
        '
        'dgSearch
        '
        Me.dgSearch.AllowUserToAddRows = False
        Me.dgSearch.AllowUserToDeleteRows = False
        Me.dgSearch.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgSearch.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSearch.GridColor = System.Drawing.Color.Coral
        Me.dgSearch.Location = New System.Drawing.Point(10, 150)
        Me.dgSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSearch.Size = New System.Drawing.Size(1158, 401)
        Me.dgSearch.TabIndex = 1
        '
        'lblRecordCount
        '
        Me.lblRecordCount.BackColor = System.Drawing.Color.Transparent
        Me.lblRecordCount.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblRecordCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCount.Location = New System.Drawing.Point(10, 551)
        Me.lblRecordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(1158, 25)
        Me.lblRecordCount.TabIndex = 17
        '
        'PanelFilterControls
        '
        Me.PanelFilterControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelFilterControls.Controls.Add(Me.chbDoBFrom)
        Me.PanelFilterControls.Controls.Add(Me.dtpDoBTo)
        Me.PanelFilterControls.Controls.Add(Me.chbDateOfBirthTo)
        Me.PanelFilterControls.Controls.Add(Me.dtpDoBFrom)
        Me.PanelFilterControls.Controls.Add(Me.chbAnniversaryDateFrom)
        Me.PanelFilterControls.Controls.Add(Me.dtpAnniversaryDateFrom)
        Me.PanelFilterControls.Controls.Add(Me.dtpAnniversaryDateTo)
        Me.PanelFilterControls.Controls.Add(Me.chbAnniversaryDateTo)
        Me.PanelFilterControls.Controls.Add(Me.LblNameSearch)
        Me.PanelFilterControls.Controls.Add(Me.txtMemberName)
        Me.PanelFilterControls.Controls.Add(Me.txtM_ID)
        Me.PanelFilterControls.Controls.Add(Me.Label14)
        Me.PanelFilterControls.Controls.Add(Me.txtMobile)
        Me.PanelFilterControls.Controls.Add(Me.Label2)
        Me.PanelFilterControls.Controls.Add(Me.txtEmail)
        Me.PanelFilterControls.Controls.Add(Me.Label16)
        Me.PanelFilterControls.Controls.Add(Me.Label17)
        Me.PanelFilterControls.Controls.Add(Me.txtSpouseName)
        Me.PanelFilterControls.Controls.Add(Me.Label6)
        Me.PanelFilterControls.Controls.Add(Me.txtC_ID)
        Me.PanelFilterControls.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelFilterControls.Location = New System.Drawing.Point(10, 10)
        Me.PanelFilterControls.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelFilterControls.Name = "PanelFilterControls"
        Me.PanelFilterControls.Size = New System.Drawing.Size(1158, 140)
        Me.PanelFilterControls.TabIndex = 0
        '
        'chbDoBFrom
        '
        Me.chbDoBFrom.AutoSize = True
        Me.chbDoBFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbDoBFrom.Location = New System.Drawing.Point(347, 70)
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
        Me.dtpDoBTo.Location = New System.Drawing.Point(512, 96)
        Me.dtpDoBTo.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDoBTo.Name = "dtpDoBTo"
        Me.dtpDoBTo.Size = New System.Drawing.Size(159, 27)
        Me.dtpDoBTo.TabIndex = 19
        '
        'chbDateOfBirthTo
        '
        Me.chbDateOfBirthTo.AutoSize = True
        Me.chbDateOfBirthTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbDateOfBirthTo.Location = New System.Drawing.Point(516, 70)
        Me.chbDateOfBirthTo.Margin = New System.Windows.Forms.Padding(4)
        Me.chbDateOfBirthTo.Name = "chbDateOfBirthTo"
        Me.chbDateOfBirthTo.Size = New System.Drawing.Size(105, 24)
        Me.chbDateOfBirthTo.TabIndex = 18
        Me.chbDateOfBirthTo.Text = "Between"
        Me.chbDateOfBirthTo.UseVisualStyleBackColor = True
        '
        'dtpDoBFrom
        '
        Me.dtpDoBFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDoBFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDoBFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDoBFrom.Location = New System.Drawing.Point(343, 96)
        Me.dtpDoBFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDoBFrom.Name = "dtpDoBFrom"
        Me.dtpDoBFrom.Size = New System.Drawing.Size(159, 27)
        Me.dtpDoBFrom.TabIndex = 17
        '
        'chbAnniversaryDateFrom
        '
        Me.chbAnniversaryDateFrom.AutoSize = True
        Me.chbAnniversaryDateFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbAnniversaryDateFrom.Location = New System.Drawing.Point(11, 70)
        Me.chbAnniversaryDateFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.chbAnniversaryDateFrom.Name = "chbAnniversaryDateFrom"
        Me.chbAnniversaryDateFrom.Size = New System.Drawing.Size(136, 24)
        Me.chbAnniversaryDateFrom.TabIndex = 12
        Me.chbAnniversaryDateFrom.Text = "Anniversary"
        Me.chbAnniversaryDateFrom.UseVisualStyleBackColor = True
        '
        'dtpAnniversaryDateFrom
        '
        Me.dtpAnniversaryDateFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpAnniversaryDateFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAnniversaryDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAnniversaryDateFrom.Location = New System.Drawing.Point(8, 96)
        Me.dtpAnniversaryDateFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpAnniversaryDateFrom.Name = "dtpAnniversaryDateFrom"
        Me.dtpAnniversaryDateFrom.Size = New System.Drawing.Size(159, 27)
        Me.dtpAnniversaryDateFrom.TabIndex = 13
        '
        'dtpAnniversaryDateTo
        '
        Me.dtpAnniversaryDateTo.CustomFormat = "dd/MMM/yyyy"
        Me.dtpAnniversaryDateTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAnniversaryDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAnniversaryDateTo.Location = New System.Drawing.Point(175, 96)
        Me.dtpAnniversaryDateTo.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpAnniversaryDateTo.Name = "dtpAnniversaryDateTo"
        Me.dtpAnniversaryDateTo.Size = New System.Drawing.Size(159, 27)
        Me.dtpAnniversaryDateTo.TabIndex = 15
        '
        'chbAnniversaryDateTo
        '
        Me.chbAnniversaryDateTo.AutoSize = True
        Me.chbAnniversaryDateTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbAnniversaryDateTo.Location = New System.Drawing.Point(179, 70)
        Me.chbAnniversaryDateTo.Margin = New System.Windows.Forms.Padding(4)
        Me.chbAnniversaryDateTo.Name = "chbAnniversaryDateTo"
        Me.chbAnniversaryDateTo.Size = New System.Drawing.Size(105, 24)
        Me.chbAnniversaryDateTo.TabIndex = 14
        Me.chbAnniversaryDateTo.Text = "Between"
        Me.chbAnniversaryDateTo.UseVisualStyleBackColor = True
        '
        'LblNameSearch
        '
        Me.LblNameSearch.AutoSize = True
        Me.LblNameSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNameSearch.Location = New System.Drawing.Point(4, 11)
        Me.LblNameSearch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNameSearch.Name = "LblNameSearch"
        Me.LblNameSearch.Size = New System.Drawing.Size(49, 20)
        Me.LblNameSearch.TabIndex = 0
        Me.LblNameSearch.Text = "C_ID"
        '
        'txtMemberName
        '
        Me.txtMemberName.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(240, 34)
        Me.txtMemberName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(236, 27)
        Me.txtMemberName.TabIndex = 5
        '
        'txtM_ID
        '
        Me.txtM_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtM_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtM_ID.Location = New System.Drawing.Point(124, 34)
        Me.txtM_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtM_ID.Name = "txtM_ID"
        Me.txtM_ID.Size = New System.Drawing.Size(109, 27)
        Me.txtM_ID.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(120, 11)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 20)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "M_ID"
        '
        'txtMobile
        '
        Me.txtMobile.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobile.Location = New System.Drawing.Point(959, 34)
        Me.txtMobile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(195, 27)
        Me.txtMobile.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(236, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Member Name"
        '
        'txtEmail
        '
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(736, 34)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(215, 27)
        Me.txtEmail.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(960, 11)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 20)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Mobile#"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(732, 11)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 20)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Email ID"
        '
        'txtSpouseName
        '
        Me.txtSpouseName.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpouseName.Location = New System.Drawing.Point(484, 34)
        Me.txtSpouseName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSpouseName.Name = "txtSpouseName"
        Me.txtSpouseName.Size = New System.Drawing.Size(244, 27)
        Me.txtSpouseName.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(480, 11)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Spouse Name"
        '
        'txtC_ID
        '
        Me.txtC_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtC_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtC_ID.Location = New System.Drawing.Point(8, 34)
        Me.txtC_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtC_ID.Name = "txtC_ID"
        Me.txtC_ID.Size = New System.Drawing.Size(109, 27)
        Me.txtC_ID.TabIndex = 1
        '
        'PanelFooter
        '
        Me.PanelFooter.Controls.Add(Me.btnClose)
        Me.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFooter.Location = New System.Drawing.Point(10, 640)
        Me.PanelFooter.Name = "PanelFooter"
        Me.PanelFooter.Size = New System.Drawing.Size(1180, 50)
        Me.PanelFooter.TabIndex = 48
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageKey = "(none)"
        Me.btnClose.Location = New System.Drawing.Point(535, 4)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(107, 40)
        Me.btnClose.TabIndex = 2
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
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmSpouseEnquiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.PanelContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSpouseEnquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Spouse Enquiry"
        Me.TopMost = True
        Me.PanelContainer.ResumeLayout(False)
        Me.PanelSearch.ResumeLayout(False)
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelFilterControls.ResumeLayout(False)
        Me.PanelFilterControls.PerformLayout()
        Me.PanelFooter.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents PanelContainer As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtM_ID As System.Windows.Forms.TextBox
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtC_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LblNameSearch As System.Windows.Forms.Label
    Friend WithEvents txtSpouseName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgSearch As System.Windows.Forms.DataGridView
    Friend WithEvents PanelLine As System.Windows.Forms.Panel
    Friend WithEvents PanelFilterControls As System.Windows.Forms.Panel
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents chbAnniversaryDateFrom As System.Windows.Forms.CheckBox
    Friend WithEvents dtpAnniversaryDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAnniversaryDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents chbAnniversaryDateTo As System.Windows.Forms.CheckBox
    Friend WithEvents chbDoBFrom As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDoBTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents chbDateOfBirthTo As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDoBFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
