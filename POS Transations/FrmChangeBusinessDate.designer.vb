<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangeBusinessDate
    Inherits System.Windows.Forms.Form
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel

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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.PanelTable = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgOpenBills = New System.Windows.Forms.DataGridView()
        Me.PanelDate = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnChangeDate = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpBusinessDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelHeader.SuspendLayout()
        Me.PanelContainer.SuspendLayout()
        Me.PanelTable.SuspendLayout()
        CType(Me.dgOpenBills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDate.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelHeader.Controls.Add(Me.LabelHeader)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(10, 10)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(1180, 40)
        Me.PanelHeader.TabIndex = 55
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
        Me.LabelHeader.Size = New System.Drawing.Size(1180, 37)
        Me.LabelHeader.TabIndex = 53
        Me.LabelHeader.Text = "CHANGE BUSINESS DATE"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelContainer
        '
        Me.PanelContainer.Controls.Add(Me.PanelTable)
        Me.PanelContainer.Controls.Add(Me.PanelDate)
        Me.PanelContainer.Controls.Add(Me.Panel1)
        Me.PanelContainer.Controls.Add(Me.PanelHeader)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelContainer.Size = New System.Drawing.Size(1200, 700)
        Me.PanelContainer.TabIndex = 0
        '
        'PanelTable
        '
        Me.PanelTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelTable.Controls.Add(Me.Label2)
        Me.PanelTable.Controls.Add(Me.dgOpenBills)
        Me.PanelTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTable.Location = New System.Drawing.Point(10, 52)
        Me.PanelTable.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelTable.Name = "PanelTable"
        Me.PanelTable.Padding = New System.Windows.Forms.Padding(8)
        Me.PanelTable.Size = New System.Drawing.Size(910, 638)
        Me.PanelTable.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(892, 35)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "LIST OF OPEN BILLS / TABLES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgOpenBills
        '
        Me.dgOpenBills.AllowUserToAddRows = False
        Me.dgOpenBills.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(250, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOpenBills.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgOpenBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgOpenBills.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgOpenBills.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgOpenBills.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgOpenBills.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOpenBills.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgOpenBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOpenBills.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 7.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOpenBills.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgOpenBills.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgOpenBills.EnableHeadersVisualStyles = False
        Me.dgOpenBills.GridColor = System.Drawing.Color.Chocolate
        Me.dgOpenBills.Location = New System.Drawing.Point(8, 8)
        Me.dgOpenBills.Margin = New System.Windows.Forms.Padding(4)
        Me.dgOpenBills.MultiSelect = False
        Me.dgOpenBills.Name = "dgOpenBills"
        Me.dgOpenBills.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOpenBills.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgOpenBills.RowHeadersVisible = False
        Me.dgOpenBills.RowTemplate.Height = 28
        Me.dgOpenBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOpenBills.Size = New System.Drawing.Size(892, 620)
        Me.dgOpenBills.TabIndex = 1
        Me.dgOpenBills.TabStop = False
        '
        'PanelDate
        '
        Me.PanelDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDate.Controls.Add(Me.btnClose)
        Me.PanelDate.Controls.Add(Me.btnChangeDate)
        Me.PanelDate.Controls.Add(Me.Label3)
        Me.PanelDate.Controls.Add(Me.dtpBusinessDate)
        Me.PanelDate.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelDate.Location = New System.Drawing.Point(920, 52)
        Me.PanelDate.Name = "PanelDate"
        Me.PanelDate.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelDate.Size = New System.Drawing.Size(270, 638)
        Me.PanelDate.TabIndex = 54
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageKey = "(none)"
        Me.btnClose.Location = New System.Drawing.Point(160, 84)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(103, 50)
        Me.btnClose.TabIndex = 55
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnChangeDate
        '
        Me.btnChangeDate.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeDate.Location = New System.Drawing.Point(10, 84)
        Me.btnChangeDate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeDate.Name = "btnChangeDate"
        Me.btnChangeDate.Size = New System.Drawing.Size(146, 50)
        Me.btnChangeDate.TabIndex = 54
        Me.btnChangeDate.Text = "Change Date"
        Me.btnChangeDate.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(248, 35)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "CURRENT BUSINESS DATE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpBusinessDate
        '
        Me.dtpBusinessDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpBusinessDate.Font = New System.Drawing.Font("Lucida Fax", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBusinessDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBusinessDate.Location = New System.Drawing.Point(10, 49)
        Me.dtpBusinessDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpBusinessDate.Name = "dtpBusinessDate"
        Me.dtpBusinessDate.Size = New System.Drawing.Size(250, 27)
        Me.dtpBusinessDate.TabIndex = 53
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(10, 50)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1180, 2)
        Me.Panel1.TabIndex = 52
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmChangeBusinessDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.PanelContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmChangeBusinessDate"
        Me.Text = "Day End"
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelContainer.ResumeLayout(False)
        Me.PanelTable.ResumeLayout(False)
        CType(Me.dgOpenBills, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDate.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelContainer As System.Windows.Forms.Panel
    Friend WithEvents PanelTable As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgOpenBills As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PanelDate As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnChangeDate As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpBusinessDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
End Class
