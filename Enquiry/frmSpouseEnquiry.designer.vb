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
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblRecordCount = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelSearch = New System.Windows.Forms.Panel
        Me.PanelFilterControls = New System.Windows.Forms.Panel
        Me.chbDoBFrom = New System.Windows.Forms.CheckBox
        Me.dtpDoBTo = New System.Windows.Forms.DateTimePicker
        Me.chbDateOfBirthTo = New System.Windows.Forms.CheckBox
        Me.dtpDoBFrom = New System.Windows.Forms.DateTimePicker
        Me.chbAnniversaryDateFrom = New System.Windows.Forms.CheckBox
        Me.dtpAnniversaryDateFrom = New System.Windows.Forms.DateTimePicker
        Me.dtpAnniversaryDateTo = New System.Windows.Forms.DateTimePicker
        Me.chbAnniversaryDateTo = New System.Windows.Forms.CheckBox
        Me.LblNameSearch = New System.Windows.Forms.Label
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.txtM_ID = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtMobile = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtSpouseName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtC_ID = New System.Windows.Forms.TextBox
        Me.dgSearch = New System.Windows.Forms.DataGridView
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel3.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        Me.PanelFilterControls.SuspendLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1015, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SPOUSE ENQUIRY"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnClose.Location = New System.Drawing.Point(469, 637)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 26)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.lblRecordCount)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.btnClose)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.PanelSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1019, 680)
        Me.Panel3.TabIndex = 0
        '
        'lblRecordCount
        '
        Me.lblRecordCount.BackColor = System.Drawing.Color.Transparent
        Me.lblRecordCount.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCount.Location = New System.Drawing.Point(18, 638)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(387, 18)
        Me.lblRecordCount.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(-4, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 2)
        Me.Panel1.TabIndex = 47
        '
        'PanelSearch
        '
        Me.PanelSearch.BackColor = System.Drawing.Color.Transparent
        Me.PanelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSearch.Controls.Add(Me.PanelFilterControls)
        Me.PanelSearch.Controls.Add(Me.dgSearch)
        Me.PanelSearch.Location = New System.Drawing.Point(15, 39)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(989, 587)
        Me.PanelSearch.TabIndex = 0
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
        Me.PanelFilterControls.Location = New System.Drawing.Point(6, 8)
        Me.PanelFilterControls.Name = "PanelFilterControls"
        Me.PanelFilterControls.Size = New System.Drawing.Size(975, 110)
        Me.PanelFilterControls.TabIndex = 0
        '
        'chbDoBFrom
        '
        Me.chbDoBFrom.AutoSize = True
        Me.chbDoBFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbDoBFrom.Location = New System.Drawing.Point(260, 57)
        Me.chbDoBFrom.Name = "chbDoBFrom"
        Me.chbDoBFrom.Size = New System.Drawing.Size(111, 20)
        Me.chbDoBFrom.TabIndex = 16
        Me.chbDoBFrom.Text = "Date Of Birth"
        Me.chbDoBFrom.UseVisualStyleBackColor = True
        '
        'dtpDoBTo
        '
        Me.dtpDoBTo.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDoBTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDoBTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDoBTo.Location = New System.Drawing.Point(384, 78)
        Me.dtpDoBTo.Name = "dtpDoBTo"
        Me.dtpDoBTo.Size = New System.Drawing.Size(120, 23)
        Me.dtpDoBTo.TabIndex = 19
        '
        'chbDateOfBirthTo
        '
        Me.chbDateOfBirthTo.AutoSize = True
        Me.chbDateOfBirthTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbDateOfBirthTo.Location = New System.Drawing.Point(387, 57)
        Me.chbDateOfBirthTo.Name = "chbDateOfBirthTo"
        Me.chbDateOfBirthTo.Size = New System.Drawing.Size(79, 20)
        Me.chbDateOfBirthTo.TabIndex = 18
        Me.chbDateOfBirthTo.Text = "Between"
        Me.chbDateOfBirthTo.UseVisualStyleBackColor = True
        '
        'dtpDoBFrom
        '
        Me.dtpDoBFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDoBFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDoBFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDoBFrom.Location = New System.Drawing.Point(257, 78)
        Me.dtpDoBFrom.Name = "dtpDoBFrom"
        Me.dtpDoBFrom.Size = New System.Drawing.Size(120, 23)
        Me.dtpDoBFrom.TabIndex = 17
        '
        'chbAnniversaryDateFrom
        '
        Me.chbAnniversaryDateFrom.AutoSize = True
        Me.chbAnniversaryDateFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbAnniversaryDateFrom.Location = New System.Drawing.Point(8, 57)
        Me.chbAnniversaryDateFrom.Name = "chbAnniversaryDateFrom"
        Me.chbAnniversaryDateFrom.Size = New System.Drawing.Size(107, 20)
        Me.chbAnniversaryDateFrom.TabIndex = 12
        Me.chbAnniversaryDateFrom.Text = "Anniversary"
        Me.chbAnniversaryDateFrom.UseVisualStyleBackColor = True
        '
        'dtpAnniversaryDateFrom
        '
        Me.dtpAnniversaryDateFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpAnniversaryDateFrom.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAnniversaryDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAnniversaryDateFrom.Location = New System.Drawing.Point(6, 78)
        Me.dtpAnniversaryDateFrom.Name = "dtpAnniversaryDateFrom"
        Me.dtpAnniversaryDateFrom.Size = New System.Drawing.Size(120, 23)
        Me.dtpAnniversaryDateFrom.TabIndex = 13
        '
        'dtpAnniversaryDateTo
        '
        Me.dtpAnniversaryDateTo.CustomFormat = "dd/MMM/yyyy"
        Me.dtpAnniversaryDateTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAnniversaryDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAnniversaryDateTo.Location = New System.Drawing.Point(131, 78)
        Me.dtpAnniversaryDateTo.Name = "dtpAnniversaryDateTo"
        Me.dtpAnniversaryDateTo.Size = New System.Drawing.Size(120, 23)
        Me.dtpAnniversaryDateTo.TabIndex = 15
        '
        'chbAnniversaryDateTo
        '
        Me.chbAnniversaryDateTo.AutoSize = True
        Me.chbAnniversaryDateTo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbAnniversaryDateTo.Location = New System.Drawing.Point(134, 57)
        Me.chbAnniversaryDateTo.Name = "chbAnniversaryDateTo"
        Me.chbAnniversaryDateTo.Size = New System.Drawing.Size(79, 20)
        Me.chbAnniversaryDateTo.TabIndex = 14
        Me.chbAnniversaryDateTo.Text = "Between"
        Me.chbAnniversaryDateTo.UseVisualStyleBackColor = True
        '
        'LblNameSearch
        '
        Me.LblNameSearch.AutoSize = True
        Me.LblNameSearch.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNameSearch.Location = New System.Drawing.Point(6, 9)
        Me.LblNameSearch.Name = "LblNameSearch"
        Me.LblNameSearch.Size = New System.Drawing.Size(38, 16)
        Me.LblNameSearch.TabIndex = 0
        Me.LblNameSearch.Text = "C_ID"
        '
        'txtMemberName
        '
        Me.txtMemberName.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(180, 28)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(201, 23)
        Me.txtMemberName.TabIndex = 5
        '
        'txtM_ID
        '
        Me.txtM_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtM_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtM_ID.Location = New System.Drawing.Point(93, 28)
        Me.txtM_ID.Name = "txtM_ID"
        Me.txtM_ID.Size = New System.Drawing.Size(83, 23)
        Me.txtM_ID.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(97, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "M_ID"
        '
        'txtMobile
        '
        Me.txtMobile.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobile.Location = New System.Drawing.Point(816, 28)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(147, 23)
        Me.txtMobile.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(184, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Member Name"
        '
        'txtEmail
        '
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(591, 28)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(219, 23)
        Me.txtEmail.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(820, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 16)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Mobile#"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(594, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 16)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Email ID"
        '
        'txtSpouseName
        '
        Me.txtSpouseName.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpouseName.Location = New System.Drawing.Point(385, 28)
        Me.txtSpouseName.Name = "txtSpouseName"
        Me.txtSpouseName.Size = New System.Drawing.Size(201, 23)
        Me.txtSpouseName.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(389, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Spouse Name"
        '
        'txtC_ID
        '
        Me.txtC_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtC_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtC_ID.Location = New System.Drawing.Point(6, 28)
        Me.txtC_ID.Name = "txtC_ID"
        Me.txtC_ID.Size = New System.Drawing.Size(83, 23)
        Me.txtC_ID.TabIndex = 1
        '
        'dgSearch
        '
        Me.dgSearch.AllowUserToAddRows = False
        Me.dgSearch.AllowUserToDeleteRows = False
        Me.dgSearch.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgSearch.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgSearch.GridColor = System.Drawing.Color.Coral
        Me.dgSearch.Location = New System.Drawing.Point(6, 126)
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSearch.Size = New System.Drawing.Size(975, 453)
        Me.dgSearch.TabIndex = 1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmSpouseEnquiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1019, 680)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSpouseEnquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Spouse Enquiry"
        Me.TopMost = True
        Me.Panel3.ResumeLayout(False)
        Me.PanelSearch.ResumeLayout(False)
        Me.PanelFilterControls.ResumeLayout(False)
        Me.PanelFilterControls.PerformLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
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
End Class
