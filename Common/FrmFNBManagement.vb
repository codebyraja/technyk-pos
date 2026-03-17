Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Net

Public Class FrmFNBManagement

    Private Sub FrmMainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'form Design
        InitializeProductionLayout()

        ObjDatabase.ConnectDatabse()
        LoadConfigurations()
        DisplayInfo()
        FormBackColor = System.Drawing.Color.FromArgb(255, 255, 192)
        LabelOrgName.Text = CompanyInfoName & " [" & LOCATION_NAME & "]"
        CurrentBusinessDate = GetCurrentBusinessDate()

        lblBusinessDate.Text = "Business Date: " & CurrentServerDate.ToString("dd/MMM/yyyy")
        Me.Text = "Point of Sale - " & CompanyInfoName
        GetUpperAndLowerBoundsOfFinancialYear(YearCode)
        Me.Text = "[" & LOCATION_NAME & "]"
        btnRptPOSReports.Enabled = True

        If LOCATION_TYPE.ToUpper = "POS BAR" Then
            btnFrmConsumption.Enabled = True
            btnFrmStockAdjustment.Enabled = True
            btnRptStockAsOnDate.Enabled = True
            btnFrmInterLocationStockTransfer.Enabled = True
        Else
            btnFrmConsumption.Enabled = False
            btnFrmStockAdjustment.Enabled = False
            btnRptStockAsOnDate.Enabled = False
            btnFrmInterLocationStockTransfer.Enabled = False
        End If

        DisableControls(False)
        DefineTooTipAndFormAccess()
        LOCATION_TYPE = "'POS Bar','POS Rest'"
    End Sub
    Public Sub ShowDashboard()
        'PanelButtons.Controls.Clear()
        'SetupResponsiveGrid()
        'PanelButtons.Visible = True

        PanelPOSTransactions.Controls.Clear()
        If PanelPOSTransactions.Controls.Count = 0 Then
            SetupResponsiveGrid()
        End If
    End Sub

    Private Sub InitializeProductionLayout()

        ' Remove border
        Me.FormBorderStyle = FormBorderStyle.None

        ' Full screen working area
        Dim wa As Rectangle = Screen.PrimaryScreen.WorkingArea
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = wa.Location
        Me.Size = wa.Size

        ' Backgrounds
        Me.BackColor = Color.White
        PanelButtons.BackColor = Color.White
        PanelPOSTransactions.BackColor = Color.White

        ' Build Header (only once)
        SetupHeaderLayout()

        ' Scale Header
        UIHelper.AdjustHeaderDynamic(
            Me,
            Panel1,
            PBTechnyk,
            New List(Of Button) From {btnHome, btnAnydeskSupport, btnMinimise, btnExitApplication},
            New List(Of Button) From {Button7, Button6, Button5, Button4},
            LabelOrgName,
            lblWelcomeUser
        )

        ' Build Grid
        PanelPOSTransactions.SuspendLayout()
        SetupResponsiveGrid()
        PanelPOSTransactions.ResumeLayout()

        ' Status Strip Icons
        TSFinancialYear.Image = My.Resources.contract2
        TSInformation.Image = My.Resources.mail
        TSCurrentDate.Image = My.Resources.calendar
        TSCurrentTime.Image = My.Resources.clock

        'SetupDashboardGrid()

        ' ================= TOP PANEL =================
        'PanelTop = New Panel()
        'PanelTop.Dock = DockStyle.Top
        'PanelTop.Height = 40
        'PanelTop.BackColor = Color.SteelBlue

        'Dim lblTitle As New Label()
        'lblTitle.Text = "Resize Testing Dashboard 2"
        'lblTitle.Dock = DockStyle.Fill
        'lblTitle.TextAlign = ContentAlignment.MiddleCenter
        'lblTitle.ForeColor = Color.White
        'lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)

        'PanelTop.Controls.Add(lblTitle)
        'Me.Controls.Add(PanelTop)

    End Sub

    Private Sub SetupHeaderLayout()

        If Me.DesignMode Then Exit Sub
        Panel1.Controls.Clear()

        Dim headerTbl As New TableLayoutPanel
        headerTbl.Dock = DockStyle.Fill
        headerTbl.ColumnCount = 3
        headerTbl.RowCount = 1
        headerTbl.BackColor = Panel1.BackColor

        btnHome.FlatStyle = FlatStyle.Flat
        btnHome.FlatAppearance.BorderSize = 0
        btnHome.BackColor = Color.FromArgb(30, 41, 59)

        btnAnydeskSupport.FlatAppearance.BorderSize = 0

        btnMinimise.FlatStyle = FlatStyle.Flat
        btnMinimise.FlatAppearance.BorderSize = 0
        btnMinimise.BackColor = Color.FromArgb(30, 41, 59)

        btnExitApplication.FlatStyle = FlatStyle.Flat
        btnExitApplication.FlatAppearance.BorderSize = 0
        btnExitApplication.BackColor = Color.FromArgb(220, 38, 38) ' red only for exit

        ' Left - Center - Right
        headerTbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33))
        headerTbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34))
        headerTbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33))

        ' -------- LEFT PANEL --------
        Dim leftPanel As New FlowLayoutPanel
        leftPanel.Dock = DockStyle.Fill
        leftPanel.FlowDirection = FlowDirection.LeftToRight
        leftPanel.WrapContents = False
        leftPanel.AutoSize = False
        leftPanel.Padding = New Padding(15, 0, 0, 0)

        PBTechnyk.SizeMode = PictureBoxSizeMode.StretchImage
        PBTechnyk.Width = 60
        PBTechnyk.Height = 60

        leftPanel.Controls.Add(PBTechnyk)
        leftPanel.Controls.Add(Button7)
        leftPanel.Controls.Add(Button6)
        leftPanel.Controls.Add(Button5)
        leftPanel.Controls.Add(Button4)

        ' -------- CENTER PANEL --------
        Dim centerPanel As New Panel
        centerPanel.Dock = DockStyle.Fill

        LabelOrgName.Dock = DockStyle.Top
        LabelOrgName.TextAlign = ContentAlignment.MiddleCenter

        lblWelcomeUser.Dock = DockStyle.Bottom
        lblWelcomeUser.TextAlign = ContentAlignment.MiddleCenter

        centerPanel.Controls.Add(LabelOrgName)
        centerPanel.Controls.Add(lblWelcomeUser)

        ' -------- RIGHT PANEL --------
        Dim rightPanel As New FlowLayoutPanel
        rightPanel.Dock = DockStyle.Fill
        'rightPanel.AutoSize = False
        'rightPanel.Height = Panel1.Height
        'rightPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        rightPanel.FlowDirection = FlowDirection.RightToLeft
        rightPanel.WrapContents = False
        rightPanel.Padding = New Padding(0, 0, 15, 0)


        rightPanel.Controls.Add(btnExitApplication)
        rightPanel.Controls.Add(btnMinimise)
        rightPanel.Controls.Add(btnAnydeskSupport)
        rightPanel.Controls.Add(btnHome)

        'btnExitApplication.Width = 60
        'btnMinimise.Width = 60
        'btnAnydeskSupport.Width = 60
        'btnHome.Width = 60

        btnHome.Margin = New Padding(5)
        btnMinimise.Margin = New Padding(5)
        btnExitApplication.Margin = New Padding(5)
        btnAnydeskSupport.Margin = New Padding(5)


        ' Add to table
        headerTbl.Controls.Add(leftPanel, 0, 0)
        headerTbl.Controls.Add(centerPanel, 1, 0)
        headerTbl.Controls.Add(rightPanel, 2, 0)

        Panel1.Controls.Add(headerTbl)

        UIHelper.ApplyVerticalCentering(leftPanel, Panel1)
        UIHelper.ApplyVerticalCentering(rightPanel, Panel1)

        AddHandler btnMinimise.Click, AddressOf btnMinimise_Click
        AddHandler btnExitApplication.Click, AddressOf btnExitApplication_Click
        AddHandler btnAnydeskSupport.Click, AddressOf btnAnydeskSupport_Click
        AddHandler btnHome.Click, AddressOf btnHome_Click
        AddHandler PBTechnyk.Click, AddressOf PBTechnyk_Click
        AddHandler lblWelcomeUser.Click, AddressOf lblWelcomeUser_Click
        AddHandler LabelOrgName.Click, AddressOf LabelOrgName_Click

    End Sub

    Private Sub SetupResponsiveGrid()
        Dim tbl As New TableLayoutPanel

        If Me.DesignMode Then Exit Sub
        PanelPOSTransactions.Controls.Clear()

        tbl.Dock = DockStyle.Fill
        'tbl.RowCount = 4
        'tbl.ColumnCount = 6
        'tbl.BackColor = Color.Transparent

        'For i As Integer = 0 To 5
        '    tbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.66F))
        'Next

        'For i As Integer = 0 To 3
        '    tbl.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        'Next

        tbl.RowCount = 4
        tbl.ColumnCount = 6

        tbl.BackColor = Color.White
        PanelPOSTransactions.BackColor = Color.White

        For i As Integer = 0 To 5
            'tbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20.0F))
            tbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.66F))
        Next

        For i As Integer = 0 To 3
            'tbl.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33F))
            tbl.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        Next

        ' IMPORTANT
        tbl.BringToFront()

        Dim buttons As Button() = {
            btnFrmPOSBilling,
            btnFrmPOSRoomPosting,
            btnfrmCardRefund,
            btnFrmKOTRemarks,
            btnfrmChangeBusinessDate,
            btnFrmModifierMaster,
            btnFrmWaiterMaster,
            btnFrmLinkWaiter,
            btnFrmTableMaster,
            btnFrmLinkTable,
            btnFrmLocationMenu,
            btnFrmConsumption,
            btnfrmMemberEnquiry,
            btnfrmSpouseEnquiry,
            btnfrmDependantEnquiry,
            btnfrmSmartCardTransactionEnquiry,
            btnfrmCreditTransactionEnquiry,
            btnFrmPOSDuplicate,
            btnRptPOSReports,
            btnfrmConfigurations,
            btnFrmStockAdjustment,
            btnFrmInterLocationStockTransfer,
            btnFrmInventoryReports,
            btnRptStockAsOnDate
        }

        Dim index As Integer = 0

        For r As Integer = 0 To 3
            For c As Integer = 0 To 5
                If index < buttons.Length Then

                    ' Reset designer layout
                    buttons(index).Location = Point.Empty
                    buttons(index).Size = Size.Empty
                    buttons(index).Anchor = AnchorStyles.None

                    ' Runtime layout
                    buttons(index).Dock = DockStyle.Fill
                    'buttons(index).Margin = New Padding(15)
                    buttons(index).Margin = New Padding(5)

                    buttons(index).FlatStyle = FlatStyle.Flat
                    'buttons(index).FlatAppearance.BorderColor = Color.LightGray
                    'buttons(index).FlatAppearance.BorderSize = 1
                    buttons(index).FlatAppearance.BorderColor = Color.Gainsboro
                    buttons(index).FlatAppearance.BorderSize = 1

                    buttons(index).BackColor = Color.White
                    buttons(index).Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    buttons(index).TextAlign = ContentAlignment.BottomCenter
                    'buttons(index).Padding = New Padding(5)

                    'buttons(index).BackgroundImageLayout = ImageLayout.Zoom
                    'buttons(index).TextImageRelation = TextImageRelation.ImageAboveText
                    buttons(index).Padding = New Padding(10, 10, 10, 25)
                    tbl.Controls.Add(buttons(index), c, r)

                    index += 1
                End If
            Next
        Next

        Me.PanelPOSTransactions.Controls.Add(tbl)
    End Sub

    Private Sub FrmMainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure to Exit the application?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            StrSql = "update AC_UserLoginDetail set logouttime=GetDate() where userCode=" & UserCode & " and ModuleCode=" & ModuleCode & " And sessionid=" & SESSION_ID
            ObjDatabase.ExecuteNonQuery(StrSql)
            Me.Dispose()
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmMainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Function DisplayInfo() As String
        TSCurrentDate.Text = Format(Now(), "dd/MMM/yyyy")
        TSInformation.Text = "     Information: " & Message
        TSCurrentTime.Text = Format(Now(), "HH:mm:ss")
        lblWelcomeUser.Text = "Welcome: " & UserName
        TSFinancialYear.Text = FinancialYearString
        lblLocationName.Text = LOCATION_NAME
        lblBusinessDate.Text = CurrentServerDate.ToString("dd/MMM/yyyy")

        If BackToMainScreen = True Then
            PanelButtons.Visible = True
        Else
            PanelButtons.Visible = False
        End If

        Dim Localtime As Date = Format(Now(), "HH:mm")

        If CDate(Localtime.ToString("HH:mm")) < CDate("12:00") Then
            lblWelcomeUser.Text = "Good Morning " & UserName & " !!"
        ElseIf CDate(Localtime.ToString("HH:mm")) > CDate("12:00") And CDate(Localtime.ToString("HH:mm")) <= CDate("18:00") Then
            lblWelcomeUser.Text = "Good Afternoon " & UserName & " !!"
        ElseIf CDate(Localtime.ToString("HH:mm")) > CDate("18:00") Then
            lblWelcomeUser.Text = "Good Evening " & UserName & " !!"
        End If
        StatusStrip1.Visible = True
        Return ""


    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        DisplayInfo()
    End Sub

    Private Sub btnMinimise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnExitApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (MsgBox("Are you sure to Logout?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "QUESTION")) = MsgBoxResult.Yes Then
            StrSql = "update AC_UserLoginDetail set logouttime=GetDate() where userCode=" & UserCode & " and ModuleCode=" & ModuleCode & " And sessionid=" & SESSION_ID
            ObjDatabase.ExecuteNonQuery(StrSql)
            Me.Dispose()
            End
        End If
    End Sub


    Private Sub btnDefineWaiter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmWaiterMaster.Click
        Dim frm As New FrmWaiterMaster
        CheckUserFormAccess(btnFrmWaiterMaster)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Waiter Master'"
        End If
    End Sub

    Private Sub btnLinkWaiter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmLinkWaiter.Click
        Dim frm As New FrmLinkWaiter
        CheckUserFormAccess(btnFrmLinkWaiter)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Link Waiter'"
        End If
    End Sub

    Private Sub btnDefineTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmTableMaster.Click
        Dim frm As New FrmTableMaster
        CheckUserFormAccess(btnFrmTableMaster)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Table Master'"
        End If
    End Sub

    Private Sub btnLinkTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmLinkTable.Click
        Dim frm As New FrmLinkTable
        CheckUserFormAccess(btnFrmLinkTable)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Link Table'"
        End If
    End Sub


    Private Sub btnMemberEnquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmMemberEnquiry.Click
        Dim frm As New frmMemberEnquiry
        CheckUserFormAccess(btnfrmMemberEnquiry)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Member Enquiry'"
        End If
    End Sub


    Private Sub btnAnydeskSupport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim path As String = ApplicationStartupPath & "\anydesk.exe"
            Process.Start(path)
        Catch ex As Exception
            Process.Start("www.anydesk.com")
        End Try
    End Sub

    Private Sub btnSpouseEnquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmSpouseEnquiry.Click
        Dim frm As New frmSpouseEnquiry
        CheckUserFormAccess(btnfrmSpouseEnquiry)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: SpouseEnquiry'"
        End If
    End Sub


    Private Sub btnDependantEnquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmDependantEnquiry.Click
        Dim frm As New frmDependantEnquiry
        CheckUserFormAccess(btnfrmDependantEnquiry)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Dependant Enquiry'"
        End If
    End Sub


    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowDashboard()
        'PanelButtons.Visible = True
        BackToMainScreen = True
        DefineTooTipAndFormAccess()
    End Sub

    Private Sub PBTechnyk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start("www.technyk.com")
    End Sub

    Private Sub btnFrmConsumption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmConsumption.Click
        Dim frm As New FrmLinkPaymodes
        CheckUserFormAccess(btnFrmConsumption)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Link Payment Modes'"
        End If
    End Sub

    Private Sub btnCreditTransactionEqnquirySC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmCreditTransactionEnquiry.Click
        Dim frm As New frmCreditTransactionEnquiry
        CheckUserFormAccess(btnfrmCreditTransactionEnquiry)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Credit Transaction Enquiry'"
            Exit Sub
        End If
    End Sub

    Private Sub btnCardTransactionEnquirySC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmSmartCardTransactionEnquiry.Click
        Dim frm As New frmSmartCardTransactionEnquiry
        CheckUserFormAccess(btnfrmSmartCardTransactionEnquiry)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: SmartCard Transaction Enquiry'"
            Exit Sub
        End If
    End Sub

    Private Sub btnFrmLocationMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmLocationMenu.Click
        Dim frm As New FrmLocationMenu
        CheckUserFormAccess(btnFrmLocationMenu)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Link Group'"
            Exit Sub
        End If
    End Sub


    Private Sub lblWelcomeUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New FrmChangePassword
        DisplayForm(frm)
    End Sub

    Private Sub lblLocationName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLocationName.Click
        Dim frm As New FrmConfigurations
        CheckUserFormAccess(btnfrmConfigurations)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            frm.ShowDialog()
        Else
            lblFormAccess.Text = "Access denied for 'Form: Location Configurations'"
            Exit Sub
        End If
    End Sub

    Private Sub CheckUserFormAccess(ByVal frmBtn As Button)
        Dim dsRight As New DataSet
        AddRight = 0 : EditRight = 0 : SearchRight = 0 : DeleteRight = 0
        If UserCode = 1 Then
            AddRight = 1 : EditRight = 1 : SearchRight = 1 : DeleteRight = 1
        Else
            StrSql = "select AddRight, EditRight,DeleteRight,SearchRight FROM AC_UserRights where FormCode=" & Val(frmBtn.Tag) & " and AUserCode=" & UserCode
            ObjDatabase.ConnectDatabse()
            dsRight = ObjDatabase.BindDataSet(StrSql, "Rights")
            If dsRight.Tables("Rights").Rows.Count > 0 Then
                If dsRight.Tables("Rights").Rows(0)("AddRight").ToString.ToUpper() = "Y" Then AddRight = 1 Else AddRight = 0
                If dsRight.Tables("Rights").Rows(0)("EditRight").ToString.ToUpper() = "Y" Then EditRight = 1 Else EditRight = 0
                If dsRight.Tables("Rights").Rows(0)("DeleteRight").ToString.ToUpper() = "Y" Then DeleteRight = 1 Else DeleteRight = 0
                If dsRight.Tables("Rights").Rows(0)("SearchRight").ToString.ToUpper() = "Y" Then SearchRight = 1 Else SearchRight = 0
            End If
        End If
    End Sub

    Public Sub DisplayForm(ByVal frm As Form)

        PanelPOSTransactions.Controls.Clear()

        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill

        PanelPOSTransactions.Controls.Add(frm)

        AddHandler frm.FormClosed, AddressOf ChildFormClosed

        frm.Show()
        frm.BringToFront()

        'Reset()

        'PanelButtons.Controls.Clear()

        'frm.TopLevel = False
        'frm.FormBorderStyle = FormBorderStyle.None
        'frm.Dock = DockStyle.Fill

        'PanelButtons.Controls.Add(frm)
        'AddHandler frm.FormClosed, AddressOf ChildFormClosed

        'frm.Show()
        'frm.BringToFront()

        'Reset()

        '' Close previous child
        'For Each f As Form In Me.MdiChildren
        '    f.Close()
        'Next

        'frm.ControlBox = False
        'frm.FormBorderStyle = FormBorderStyle.None
        'frm.Dock = DockStyle.Fill
        ''frm.TopLevel = False

        ''frm.Location = New System.Drawing.Point(0, 0)
        ''frm.MinimumSize = New System.Drawing.Size(1020, 682)
        ''frm.MaximumSize = New System.Drawing.Size(1020, 682)
        ''frm.Size = New System.Drawing.Size(1020, 682)

        'frm.StartPosition = FormStartPosition.Manual
        'BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer)) 'RGB(173, 216, 230)
        'ControlBackColor(frm)
        'frm.BackColor = BackGroundColor

        'frm.MdiParent = Me
        ''frm.Visible = True

        'PanelButtons.Visible = False
        'frm.Show()
        'frm.Activate()
        'frm.BringToFront()
        'frm.Focus()
        'BackToMainScreen = False
    End Sub
    Private Sub ChildFormClosed(sender As Object, e As FormClosedEventArgs)

        ShowDashboard()

    End Sub

    Private Sub DefineTooTipAndFormAccess()
        Dim dsModuleRight As DataSet
        If UserCode = 1 Then
            dsModuleRight = ObjDatabase.BindDataSet("SELECT distinct F.FormCode as FormCode,F.Description FROM AC_ModuleMaster M,AC_FormMaster F where F.FormStatus='Active' AND F.ModuleCode=M.ModuleCode and M.ModuleCode=" & ModuleCode, "ToolTip")
        Else
            dsModuleRight = ObjDatabase.BindDataSet("SELECT distinct R.FormCode as FormCode,F.Description FROM AC_UserRights R, AC_ModuleMaster M,AC_FormMaster F where F.FormStatus='Active' AND (AddRight='Y' or EditRight='Y' or SearchRight='Y' or DeleteRight='Y') and auserCode=" & UserCode & " and F.FormCode=R.FormCode and R.ModuleCode=M.ModuleCode and R.ModuleCode=" & ModuleCode, "ToolTip")
        End If
        For i As Integer = 0 To dsModuleRight.Tables("ToolTip").Rows.Count - 1
            If Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2001 Then
                ToolTip.SetToolTip(btnfrmChangeBusinessDate, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmChangeBusinessDate.Enabled = True
                btnfrmChangeBusinessDate.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2002 Then
                ToolTip.SetToolTip(btnfrmCreditTransactionEnquiry, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmCreditTransactionEnquiry.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                btnfrmCreditTransactionEnquiry.Enabled = True
                'ToolTip.SetToolTip(btnfrmCreditTransactionEnquirySC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnfrmCreditTransactionEnquirySC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                'btnfrmCreditTransactionEnquirySC.Enabled = True
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2003 Then
                ToolTip.SetToolTip(btnfrmDependantEnquiry, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmDependantEnquiry.Enabled = True
                btnfrmDependantEnquiry.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2004 Then
                ToolTip.SetToolTip(btnFrmInterLocationStockTransfer, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmInterLocationStockTransfer.Enabled = True
                btnFrmInterLocationStockTransfer.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2005 Then
                ToolTip.SetToolTip(btnFrmLinkTable, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmLinkTable.Enabled = True
                btnFrmLinkTable.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2006 Then
                ToolTip.SetToolTip(btnFrmLinkWaiter, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmLinkWaiter.Enabled = True
                btnFrmLinkWaiter.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2007 Then
                ToolTip.SetToolTip(btnFrmLocationMenu, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmLocationMenu.Enabled = True
                btnFrmLocationMenu.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2008 Then
                ToolTip.SetToolTip(btnfrmMemberEnquiry, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmMemberEnquiry.Enabled = True
                btnfrmMemberEnquiry.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2009 Then
                ToolTip.SetToolTip(btnFrmConsumption, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmConsumption.Enabled = True
                btnFrmConsumption.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2010 Then
                ToolTip.SetToolTip(btnFrmPOSBilling, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmPOSBilling.Enabled = True
                btnFrmPOSBilling.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                'ToolTip.SetToolTip(btnFrmPOSBillingSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnFrmPOSBillingSC.Enabled = True
                'btnFrmPOSBillingSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2011 Then
                'ToolTip.SetToolTip(btnFrmPOSCreditBilling, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnFrmPOSCreditBilling.Enabled = True
                'btnFrmPOSCreditBilling.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2012 Then
                ToolTip.SetToolTip(btnFrmPOSDuplicate, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmPOSDuplicate.Enabled = True
                btnFrmPOSDuplicate.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                'ToolTip.SetToolTip(btnDuplicateKOTBillSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnDuplicateKOTBillSC.Enabled = True
                'btnDuplicateKOTBillSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2013 Then
                'ToolTip.SetToolTip(btnFrmPOSHomeDelivery, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnFrmPOSHomeDelivery.Enabled = True
                'btnFrmPOSHomeDelivery.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                'ToolTip.SetToolTip(btnFrmPOSBillingRoomPostingSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnFrmPOSBillingRoomPostingSC.Enabled = True
                'btnFrmPOSBillingRoomPostingSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2014 Then
                ToolTip.SetToolTip(btnfrmConfigurations, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmConfigurations.Enabled = True
                btnfrmConfigurations.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2015 Then
                ToolTip.SetToolTip(btnFrmModifierMaster, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmModifierMaster.Enabled = True
                btnFrmModifierMaster.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2016 Then
                ToolTip.SetToolTip(btnfrmSmartCardTransactionEnquiry, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'ToolTip.SetToolTip(btnfrmSmartCardTransactionEnquirySC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnfrmSmartCardTransactionEnquiry.Enabled = True
                'btnfrmSmartCardTransactionEnquirySC.Enabled = True
                'btnfrmSmartCardTransactionEnquiry.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                'btnfrmSmartCardTransactionEnquirySC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2017 Then
                ToolTip.SetToolTip(btnfrmSpouseEnquiry, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmSpouseEnquiry.Enabled = True
                btnfrmSpouseEnquiry.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2018 Then
                ToolTip.SetToolTip(btnFrmStockAdjustment, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmStockAdjustment.Enabled = True
                btnFrmStockAdjustment.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                'ToolTip.SetToolTip(btnStockAdjustmentSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnStockAdjustmentSC.Enabled = True
                'btnStockAdjustmentSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2019 Then
                ToolTip.SetToolTip(btnFrmTableMaster, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmTableMaster.Enabled = True
                btnFrmTableMaster.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2020 Then
                ToolTip.SetToolTip(btnFrmWaiterMaster, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmWaiterMaster.Enabled = True
                btnFrmWaiterMaster.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2021 Then
                ToolTip.SetToolTip(btnRptPOSReports, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnRptPOSReports.Enabled = True
                btnRptPOSReports.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                'ToolTip.SetToolTip(btnRptPOSReportsSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnRptPOSReportsSC.Enabled = True
                'btnRptPOSReportsSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2022 Then
                'ToolTip.SetToolTip(btnRptSlipReports, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnRptSlipReports.Enabled = True
                'btnRptSlipReports.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2023 Then
                ToolTip.SetToolTip(btnRptStockAsOnDate, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnRptStockAsOnDate.Enabled = True
                btnRptStockAsOnDate.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2024 Then
                ToolTip.SetToolTip(btnFrmPOSRoomPosting, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmPOSRoomPosting.Enabled = True
                btnFrmPOSRoomPosting.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2025 Then
                ToolTip.SetToolTip(btnfrmCardRefund, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmCardRefund.Enabled = True
                btnfrmCardRefund.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2026 Then
                ToolTip.SetToolTip(btnFrmKOTRemarks, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmKOTRemarks.Enabled = True
                btnFrmKOTRemarks.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2027 Then
                'ToolTip.SetToolTip(btnfrmSmartCardBlock, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnfrmSmartCardBlock.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                'btnfrmSmartCardBlock.Enabled = True
                'btnfrmSmartCardBlock.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2028 Then
                'ToolTip.SetToolTip(btnFrmPOSHutBilling, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnFrmPOSHutBilling.Enabled = True
                'btnFrmPOSHutBilling.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2029 Then
                ToolTip.SetToolTip(btnFrmPOSBilling, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmPOSBilling.Enabled = True
                btnFrmPOSBilling.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                'ToolTip.SetToolTip(btnFrmPOSBillingSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnFrmPOSBillingSC.Enabled = True
                'btnFrmPOSBillingSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2030 Then
                ToolTip.SetToolTip(btnFrmInventoryReports, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmInventoryReports.Enabled = True
                btnFrmInventoryReports.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2031 Then
                'ToolTip.SetToolTip(btnfrmReceiptVoucher, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnfrmReceiptVoucher.Enabled = True
                'btnfrmReceiptVoucher.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2032 Then
                ToolTip.SetToolTip(btnFrmConsumption, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmConsumption.Enabled = True
                btnFrmConsumption.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2033 Then
                'ToolTip.SetToolTip(btnFrmFundTransfer, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnFrmFundTransfer.Enabled = True
                'btnFrmFundTransfer.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2034 Then
                'ToolTip.SetToolTip(btnRequisition, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnRequisition.Enabled = True
                'btnRequisition.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2035 Then

            End If
        Next
    End Sub

    Private Sub FormButtons()
        Dim btnString As String = ""
        Dim ctrl As Control = Me.GetNextControl(Me, True)
        Do Until ctrl Is Nothing
            If TypeOf ctrl Is Button Then
                btnString = btnString & ctrl.Name & vbCrLf
            End If
            ctrl = Me.GetNextControl(ctrl, True)
        Loop
    End Sub

    Private Sub ModuleForms()
        Dim FormList As New ArrayList
        Dim FormCode As Integer = 1000 * ModuleCode
        Dim AppForms As String = ""
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim types As Type() = myAssembly.GetTypes()
        For Each myType In types
            If myType.BaseType.FullName = "System.Windows.Forms.Form" Then
                If myType.Name.ToLower <> "FrmChangePassword".ToLower() And myType.Name.ToLower <> "FrmFNBManagement".ToLower() And myType.Name.ToLower <> "FrmReportView".ToLower() And myType.Name.ToLower <> "frmLogin".ToLower() And myType.Name.ToLower <> "FrmCompanyInfo".ToLower() Then
                    FormList.Add(myType.Name)
                End If
            End If
        Next
        FormList.Sort()
        If MsgBox("Are you sure to Update the form name?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            StrSql = "DELETE FROM AC_FormMaster WHERE ModuleCode=" & ModuleCode
            ObjDatabase.ExecuteNonQuery(StrSql)
            For i As Integer = 0 To FormList.Count - 1
                StrSql = "INSERT INTO AC_FormMaster(FormCode, ModuleCode, FormName, FormDisplayAs, Description, FormStatus,CreationDate, ModificationDate, UserCode)" & _
                " VALUES(" & FormCode + i + 1 & "," & ModuleCode & ",'" & FormList(i) & "','" & FormList(i) & "','" & FormList(i) & "','Active',getdate(),getdate()," & UserCode & ")"
                ObjDatabase.ExecuteNonQuery(StrSql)
            Next
            MsgBox("Form Master Updated", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub DisableControls(ByVal Flag As Boolean)
        btnfrmChangeBusinessDate.Enabled = Flag
        'btnfrmSmartCardTransactionEnquirySC.Enabled = Flag
        'btnDuplicateKOTBillSC.Enabled = Flag
        btnFrmPOSRoomPosting.Enabled = Flag
        btnfrmCardRefund.Enabled = Flag
        btnfrmCreditTransactionEnquiry.Enabled = Flag
        btnfrmDependantEnquiry.Enabled = Flag
        btnFrmInterLocationStockTransfer.Enabled = Flag
        btnFrmLinkTable.Enabled = Flag
        btnFrmLinkWaiter.Enabled = Flag
        btnFrmLocationMenu.Enabled = Flag
        btnfrmMemberEnquiry.Enabled = Flag
        btnFrmKOTRemarks.Enabled = Flag
        btnFrmConsumption.Enabled = Flag
        btnFrmPOSBilling.Enabled = Flag
        'btnFrmPOSBillingSC.Enabled = Flag
        btnFrmPOSDuplicate.Enabled = Flag
        btnfrmChangeBusinessDate.Enabled = Flag
        btnFrmModifierMaster.Enabled = Flag
        btnfrmSmartCardTransactionEnquiry.Enabled = Flag
        btnfrmSpouseEnquiry.Enabled = Flag
        btnFrmStockAdjustment.Enabled = Flag
        btnFrmTableMaster.Enabled = Flag
        btnFrmWaiterMaster.Enabled = Flag
        btnRptPOSReports.Enabled = Flag
        btnRptStockAsOnDate.Enabled = Flag
        btnFrmInventoryReports.Enabled = Flag
        btnfrmConfigurations.Enabled = Flag
    End Sub

    Private Sub btnFrmMiscBilling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmKOTRemarks.Click
        Dim frm As New FrmKOTRemarks
        CheckUserFormAccess(btnFrmKOTRemarks)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: " & frm.Text & "'"
        End If
    End Sub

    Private Sub btnfrmSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmChangeBusinessDate.Click
        Dim frm As New FrmChangeBusinessDate
        CheckUserFormAccess(btnfrmChangeBusinessDate)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Change Business Date'"
            Exit Sub
        End If
    End Sub

    Private Sub LabelOrgName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New FrmConfigurations
        CheckUserFormAccess(btnfrmConfigurations)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: " & frm.Text & "'"
        End If
    End Sub

    Private Sub btnFrmModifierMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmModifierMaster.Click
        Dim frm As New FrmModifierMaster
        CheckUserFormAccess(btnFrmModifierMaster)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: " & frm.Text & "'"
        End If
    End Sub

    Private Sub btnfrmConfigurations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmConfigurations.Click
        Dim frm As New FrmConfigurations
        CheckUserFormAccess(btnfrmConfigurations)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: " & frm.Text & "'"
        End If
    End Sub

    Private Sub btnFrmPOSBilling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrmPOSBilling.Click
        Dim frm As New FrmPOSBilling1N
        CheckUserFormAccess(btnFrmPOSBilling)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: " & frm.Text & "'"
        End If
    End Sub
End Class
