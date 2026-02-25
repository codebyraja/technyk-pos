Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Net

Public Class FrmFNBManagement

    Private Sub FrmMainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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



        ' Make sure no border
        Me.FormBorderStyle = FormBorderStyle.None

        ' Get working area (excluding taskbar)
        Dim wa As Rectangle = Screen.PrimaryScreen.WorkingArea

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = wa.Location
        Me.Size = wa.Size

        SetupDashboardGrid()

    End Sub

    Private Sub SetupDashboardGrid()

        Dim tlp As New TableLayoutPanel
        tlp.Dock = DockStyle.Fill
        tlp.ColumnCount = 6
        tlp.RowCount = 4

        For i = 1 To 6
            tlp.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.66F))
        Next

        For i = 1 To 4
            tlp.RowStyles.Add(New RowStyle(SizeType.Percent, 25))
        Next

        PanelPOSTransactions.Controls.Clear()
        PanelPOSTransactions.Controls.Add(tlp)

        tlp.Controls.Add(btnFrmPOSBilling, 0, 0)
        tlp.Controls.Add(btnFrmPOSRoomPosting, 1, 0)
        tlp.Controls.Add(btnfrmCardRefund, 2, 0)
        tlp.Controls.Add(btnFrmKOTRemarks, 3, 0)
        tlp.Controls.Add(btnfrmChangeBusinessDate, 4, 0)
        tlp.Controls.Add(btnFrmModifierMaster, 5, 0)

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

    Private Sub btnMinimise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimise.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnExitApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExitApplication.Click
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


    Private Sub btnAnydeskSupport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnydeskSupport.Click
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


    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        PanelButtons.Visible = True
        BackToMainScreen = True
        DefineTooTipAndFormAccess()
    End Sub

    Private Sub PBTechnyk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBTechnyk.Click
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

    Private Sub btnCreditTransactionEqnquirySC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmCreditTransactionEnquiry.Click, btnfrmCreditTransactionEnquirySC.Click
        Dim frm As New frmCreditTransactionEnquiry
        CheckUserFormAccess(btnfrmCreditTransactionEnquiry)
        If (AddRight = 1 Or EditRight = 1 Or SearchRight = 1 Or DeleteRight = 1) Then
            DisplayForm(frm)
        Else
            lblFormAccess.Text = "Access denied for 'Form: Credit Transaction Enquiry'"
            Exit Sub
        End If
    End Sub

    Private Sub btnCardTransactionEnquirySC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmSmartCardTransactionEnquirySC.Click, btnfrmSmartCardTransactionEnquiry.Click
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

    
    Private Sub lblWelcomeUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblWelcomeUser.Click
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
        Reset()
        frm.ControlBox = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.TopLevel = False
        frm.Dock = DockStyle.Fill

        'frm.Location = New System.Drawing.Point(0, 0)
        'frm.MinimumSize = New System.Drawing.Size(1020, 682)
        'frm.MaximumSize = New System.Drawing.Size(1020, 682)
        'frm.Size = New System.Drawing.Size(1020, 682)

        frm.StartPosition = FormStartPosition.Manual
        BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(167, Byte), Integer)) 'RGB(173, 216, 230)
        ControlBackColor(frm)
        frm.BackColor = BackGroundColor

        frm.MdiParent = Me
        frm.Visible = True

        PanelButtons.Visible = False
        frm.Show()
        frm.Activate()
        frm.BringToFront()
        frm.Focus()
        BackToMainScreen = False
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
                ToolTip.SetToolTip(btnfrmCreditTransactionEnquirySC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmCreditTransactionEnquirySC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                btnfrmCreditTransactionEnquirySC.Enabled = True
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
                ToolTip.SetToolTip(btnFrmPOSBillingSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmPOSBillingSC.Enabled = True
                btnFrmPOSBillingSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2011 Then
                'ToolTip.SetToolTip(btnFrmPOSCreditBilling, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                'btnFrmPOSCreditBilling.Enabled = True
                'btnFrmPOSCreditBilling.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2012 Then
                ToolTip.SetToolTip(btnFrmPOSDuplicate, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmPOSDuplicate.Enabled = True
                btnFrmPOSDuplicate.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                ToolTip.SetToolTip(btnDuplicateKOTBillSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnDuplicateKOTBillSC.Enabled = True
                btnDuplicateKOTBillSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
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
                ToolTip.SetToolTip(btnfrmSmartCardTransactionEnquirySC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmSmartCardTransactionEnquiry.Enabled = True
                btnfrmSmartCardTransactionEnquirySC.Enabled = True
                btnfrmSmartCardTransactionEnquiry.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                btnfrmSmartCardTransactionEnquirySC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2017 Then
                ToolTip.SetToolTip(btnfrmSpouseEnquiry, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnfrmSpouseEnquiry.Enabled = True
                btnfrmSpouseEnquiry.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
            ElseIf Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode")) = 2018 Then
                ToolTip.SetToolTip(btnFrmStockAdjustment, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmStockAdjustment.Enabled = True
                btnFrmStockAdjustment.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
                ToolTip.SetToolTip(btnStockAdjustmentSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnStockAdjustmentSC.Enabled = True
                btnStockAdjustmentSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
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
                ToolTip.SetToolTip(btnRptPOSReportsSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnRptPOSReportsSC.Enabled = True
                btnRptPOSReportsSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
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
                ToolTip.SetToolTip(btnFrmPOSBillingSC, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnFrmPOSBillingSC.Enabled = True
                btnFrmPOSBillingSC.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
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
                ToolTip.SetToolTip(btnRequisition, dsModuleRight.Tables("ToolTip").Rows(i)("Description"))
                btnRequisition.Enabled = True
                btnRequisition.Tag = Val(dsModuleRight.Tables("ToolTip").Rows(i)("FormCode"))
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
        btnfrmSmartCardTransactionEnquirySC.Enabled = Flag
        btnDuplicateKOTBillSC.Enabled = Flag
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
        btnFrmPOSBillingSC.Enabled = Flag
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

    Private Sub LabelOrgName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelOrgName.Click
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
