<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSmartCardBalanceEnquiry
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
        Me.PanelEntry = New System.Windows.Forms.Panel
        Me.btnShowBalance = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblMemID = New System.Windows.Forms.Label
        Me.lblUsableBalance = New System.Windows.Forms.Label
        Me.txtIssueNo = New System.Windows.Forms.Label
        Me.M_ID = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Label333 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtMemberid = New System.Windows.Forms.TextBox
        Me.Label2222 = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblCategory = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel3.SuspendLayout()
        Me.PanelEntry.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(1, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1015, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SMART CARD BALANCE ENQUIRY "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnClose.ImageKey = "(none)"
        Me.btnClose.Location = New System.Drawing.Point(273, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(78, 25)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.Panel3.Controls.Add(Me.PanelEntry)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1019, 680)
        Me.Panel3.TabIndex = 0
        '
        'PanelEntry
        '
        Me.PanelEntry.BackColor = System.Drawing.Color.Transparent
        Me.PanelEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEntry.Controls.Add(Me.btnShowBalance)
        Me.PanelEntry.Controls.Add(Me.Label2)
        Me.PanelEntry.Controls.Add(Me.Label4)
        Me.PanelEntry.Controls.Add(Me.btnClose)
        Me.PanelEntry.Controls.Add(Me.Label6)
        Me.PanelEntry.Controls.Add(Me.lblMemID)
        Me.PanelEntry.Controls.Add(Me.lblUsableBalance)
        Me.PanelEntry.Controls.Add(Me.txtIssueNo)
        Me.PanelEntry.Controls.Add(Me.M_ID)
        Me.PanelEntry.Controls.Add(Me.lblStatus)
        Me.PanelEntry.Controls.Add(Me.Label333)
        Me.PanelEntry.Controls.Add(Me.Label5)
        Me.PanelEntry.Controls.Add(Me.txtMemberid)
        Me.PanelEntry.Controls.Add(Me.Label2222)
        Me.PanelEntry.Controls.Add(Me.lblName)
        Me.PanelEntry.Controls.Add(Me.lblCategory)
        Me.PanelEntry.Location = New System.Drawing.Point(317, 50)
        Me.PanelEntry.Name = "PanelEntry"
        Me.PanelEntry.Size = New System.Drawing.Size(385, 186)
        Me.PanelEntry.TabIndex = 0
        '
        'btnShowBalance
        '
        Me.btnShowBalance.BackColor = System.Drawing.Color.Transparent
        Me.btnShowBalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowBalance.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnShowBalance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnShowBalance.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnShowBalance.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnShowBalance.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowBalance.ForeColor = System.Drawing.Color.Black
        Me.btnShowBalance.ImageKey = "(none)"
        Me.btnShowBalance.Location = New System.Drawing.Point(194, 11)
        Me.btnShowBalance.Name = "btnShowBalance"
        Me.btnShowBalance.Size = New System.Drawing.Size(78, 25)
        Me.btnShowBalance.TabIndex = 15
        Me.btnShowBalance.Text = "Show"
        Me.btnShowBalance.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(196, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "(Usable Amount)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Status"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMemID
        '
        Me.lblMemID.BackColor = System.Drawing.Color.Black
        Me.lblMemID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemID.ForeColor = System.Drawing.Color.White
        Me.lblMemID.Location = New System.Drawing.Point(103, 41)
        Me.lblMemID.Name = "lblMemID"
        Me.lblMemID.Size = New System.Drawing.Size(90, 22)
        Me.lblMemID.TabIndex = 3
        Me.lblMemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsableBalance
        '
        Me.lblUsableBalance.BackColor = System.Drawing.Color.Black
        Me.lblUsableBalance.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsableBalance.ForeColor = System.Drawing.Color.White
        Me.lblUsableBalance.Location = New System.Drawing.Point(103, 151)
        Me.lblUsableBalance.Name = "lblUsableBalance"
        Me.lblUsableBalance.Size = New System.Drawing.Size(90, 23)
        Me.lblUsableBalance.TabIndex = 13
        Me.lblUsableBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblUsableBalance, "Usable balance available in card after taking in to account all the transactions")
        '
        'txtIssueNo
        '
        Me.txtIssueNo.BackColor = System.Drawing.Color.Transparent
        Me.txtIssueNo.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIssueNo.Location = New System.Drawing.Point(197, 42)
        Me.txtIssueNo.Name = "txtIssueNo"
        Me.txtIssueNo.Size = New System.Drawing.Size(176, 20)
        Me.txtIssueNo.TabIndex = 2
        Me.txtIssueNo.Text = "M_ID"
        Me.txtIssueNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtIssueNo.Visible = False
        '
        'M_ID
        '
        Me.M_ID.AutoSize = True
        Me.M_ID.BackColor = System.Drawing.Color.Transparent
        Me.M_ID.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.M_ID.Location = New System.Drawing.Point(3, 44)
        Me.M_ID.Name = "M_ID"
        Me.M_ID.Size = New System.Drawing.Size(40, 16)
        Me.M_ID.TabIndex = 2
        Me.M_ID.Text = "M_ID"
        Me.M_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Black
        Me.lblStatus.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(103, 124)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(270, 22)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label333
        '
        Me.Label333.AutoSize = True
        Me.Label333.BackColor = System.Drawing.Color.Transparent
        Me.Label333.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label333.Location = New System.Drawing.Point(3, 154)
        Me.Label333.Name = "Label333"
        Me.Label333.Size = New System.Drawing.Size(92, 16)
        Me.Label333.TabIndex = 12
        Me.Label333.Text = "Card Balance"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Category"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMemberid
        '
        Me.txtMemberid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberid.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberid.Location = New System.Drawing.Point(103, 12)
        Me.txtMemberid.Name = "txtMemberid"
        Me.txtMemberid.Size = New System.Drawing.Size(90, 23)
        Me.txtMemberid.TabIndex = 1
        '
        'Label2222
        '
        Me.Label2222.AutoSize = True
        Me.Label2222.BackColor = System.Drawing.Color.Transparent
        Me.Label2222.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2222.Location = New System.Drawing.Point(3, 15)
        Me.Label2222.Name = "Label2222"
        Me.Label2222.Size = New System.Drawing.Size(77, 16)
        Me.Label2222.TabIndex = 0
        Me.Label2222.Text = "M_ID/C_ID"
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Black
        Me.lblName.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(103, 68)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(270, 23)
        Me.lblName.TabIndex = 5
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCategory
        '
        Me.lblCategory.BackColor = System.Drawing.Color.Black
        Me.lblCategory.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.Color.White
        Me.lblCategory.Location = New System.Drawing.Point(103, 96)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(270, 23)
        Me.lblCategory.TabIndex = 7
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(-4, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 2)
        Me.Panel1.TabIndex = 46
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(260, 339)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 15)
        Me.Label9.TabIndex = 27
        Me.Label9.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmSmartCardBalanceEnquiry
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
        Me.Name = "FrmSmartCardBalanceEnquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SmartCard Balance Enquiry"
        Me.TopMost = True
        Me.Panel3.ResumeLayout(False)
        Me.PanelEntry.ResumeLayout(False)
        Me.PanelEntry.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelEntry As System.Windows.Forms.Panel
    Friend WithEvents Label333 As System.Windows.Forms.Label
    Friend WithEvents Label2222 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblUsableBalance As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMemberid As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMemID As System.Windows.Forms.Label
    Friend WithEvents M_ID As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnShowBalance As System.Windows.Forms.Button
    Friend WithEvents txtIssueNo As System.Windows.Forms.Label
End Class
