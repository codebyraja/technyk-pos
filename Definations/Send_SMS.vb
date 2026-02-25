Module Send_SMS

    Public Sub SEND_SMS_ALERT_RECEIPT_VOUCHER(ByVal MemberID As String, ByVal TRCVNo As Integer, ByVal TYearCode As Integer)
        If SMSForPaymentReceipt = "" Then Exit Sub
        Dim strMemNo As String = ""
        Dim Mem_No As String = ""
        Dim MobileNo As String = ""
        Dim SC_BALANCE As String = ""
        Dim TxnAmt As Double = 0
        Dim tempSMSTExt As String = ""
        Dim ModeOfPayment As String = ""
        Dim SMSCountPerSMS As Integer = 0
        Dim CharacterCount As Integer = 0
        Dim LocationCode As Integer = 1
        Dim TempBillHead As String = ""
        Dim TBillHead, THeadAmt As String
        ObjDatabase.ConnectDatabse()
        ObjDatabase.OpenDatabaseConnection()
        TempBillHead = ""
        MemberID = ObjDatabase.ExecuteScalarS("SELECT MemberID from CM_RVHead where RCVNo=" & TRCVNo & " and YearCode=" & YearCode & " and LocationCode=" & LocationCode)
        MobileNo = ObjDatabase.ExecuteScalarS("SELECT Mobile1 from MM_MemberProfile WHERE MemberID='" & MemberID & "'")
        Mem_No = ObjDatabase.ExecuteScalarS("SELECT isnull(OldMemNo,'') from MM_MemberProfile WHERE MemberID='" & MemberID & "'")
        If MemberID <> Mem_No And Mem_No <> "" Then
            strMemNo = Mem_No & "/" & MemberID
        Else
            strMemNo = MemberID
        End If
        If Len(MobileNo) = 10 Then
            TxnAmt = ObjDatabase.ExecuteScalarN("SELECT PaidAmount from CM_RVHead where RCVNo=" & TRCVNo & " and YearCode=" & YearCode & " and LocationCode=" & LocationCode)
            ModeOfPayment = ObjDatabase.ExecuteScalarS("SELECT ModeOfPayment from CM_RVHead where RCVNo=" & TRCVNo & " and YearCode=" & YearCode & " and LocationCode=" & LocationCode)
            Dim RVHeads As DataSet = ObjDatabase.BindDataSet("select BH.HeadName,RB.Amount from CM_RVBody RB, AC_Billhead BH where RB.BillHead=BH.Code and RB.RCVNo=" & TRCVNo & " and RB.YearCode=" & TYearCode & " and RB.LocationCode=" & LocationCode, "BillHead")
            If RVHeads.Tables("BillHead").Rows.Count > 1 Then
                For i As Integer = 0 To RVHeads.Tables("BillHead").Rows.Count - 1
                    TBillHead = RVHeads.Tables("BillHead").Rows(i)("HeadName")
                    THeadAmt = RVHeads.Tables("BillHead").Rows(i)("Amount")
                    If TempBillHead = "" Then
                        TempBillHead = TBillHead & " - " & CDbl(THeadAmt).ToString("###0.00")
                    Else
                        TempBillHead = TempBillHead & ", " & TBillHead & " - " & CDbl(THeadAmt).ToString("###0.00")
                    End If
                Next
            Else
                TempBillHead = RVHeads.Tables("BillHead").Rows(0)("HeadName")
            End If
            tempSMSTExt = SMSForPaymentReceipt
            tempSMSTExt = tempSMSTExt.Replace("#C", strMemNo)
            tempSMSTExt = tempSMSTExt.Replace("#A", TxnAmt)
            tempSMSTExt = tempSMSTExt.Replace("#P", ModeOfPayment)
            tempSMSTExt = tempSMSTExt.Replace("#H", TempBillHead)
            tempSMSTExt = tempSMSTExt.Replace("#V", TRCVNo)
            StrSql = "INSERT INTO [MC_TransactionSMS]([MemberID],[MobileNo],[SMSType],[SMSText],[TemplateID],[CreationDate],[ModificationDate],[UserCode],SentStatus)" & vbCrLf & _
            "VALUES('" & MemberID & "','" & MobileNo & "','" & "Receipt Voucher" & "','" & tempSMSTExt.ToUpper() & "','" & Temp_IDForPaymentReceipt & "',getdate(),getdate()," & UserCode & ",0)"
            ObjDatabase.ExecuteNonQuery(StrSql)
        End If
    End Sub

    Public Sub SEND_SMS_ALERT_CHARGE(ByVal MemberID As String, ByVal TxnAmt As Double, ByVal ClosingBalance As Double, ByVal VchNo As Integer)
        If SMSForCardCharge = "" Then Exit Sub
        Dim MobileNo As String = ""
        Dim Mem_No As String = ""
        Dim strMemNo As String = ""
        Dim tempSMSTExt As String = ""
        ObjDatabase.ConnectDatabse()
        ObjDatabase.OpenDatabaseConnection()
        MobileNo = ObjDatabase.ExecuteScalarS("SELECT MobileNo from [View_MobileNo] WHERE MemberID='" & MemberID & "'")
        Mem_No = ObjDatabase.ExecuteScalarS("SELECT isnull(OldMemNo,'') from MM_MemberProfile WHERE MemberID='" & MemberID & "'")

        If MemberID <> Mem_No And Mem_No <> "" Then
            strMemNo = Mem_No & "/" & MemberID
        Else
            strMemNo = MemberID
        End If

        If Len(MobileNo) = 10 Then
            tempSMSTExt = [SMSForCardCharge]
            tempSMSTExt = tempSMSTExt.Replace("#C", Trim(strMemNo))
            tempSMSTExt = tempSMSTExt.Replace("#A", TxnAmt)
            tempSMSTExt = tempSMSTExt.Replace("#B", ClosingBalance)
            tempSMSTExt = tempSMSTExt.Replace("#V", VchNo)
            Dim strSql As String = "INSERT INTO [MC_TransactionSMS]([MemberID],[MobileNo],[SMSType],[SMSText],[TemplateID],[CreationDate],[ModificationDate],[UserCode],SentStatus)" & vbCrLf & _
            "VALUES('" & MemberID & "','" & MobileNo & "','" & "Card Charge" & "','" & tempSMSTExt & "','" & Temp_IDForCardCharge & "',getdate(),getdate()," & UserCode & ",0)"
            ObjDatabase.ExecuteNonQuery(strSql)
        End If
    End Sub

    Public Sub SEND_SMS_ALERT_MISC_BILLING(ByVal MemberID As String, ByVal TxnAmt As Double, ByVal PayMode As String, ByVal VchNo As Integer)
        Dim SMSText As String = ""
        Dim TemplateID As String = ""
        Dim SMSType As String = ""
        Dim MobileNo As String = ""
        Dim ClosingBalance As Double = 0
        Dim tempSMSText As String = ""

        If PayMode.ToUpper = "SMARTCARD" Then
            SMSText = SMSForMiscBillSmartCard
            TemplateID = Temp_IDForMiscBillSmartCard
            ClosingBalance = GetSmartCardClosingBalance(MemberID)
        ElseIf PayMode.ToUpper = "MEMBER A/C" Then
            SMSText = SMSForMiscBillMemberAc
            TemplateID = Temp_IDForMiscBillMemberAc
            ClosingBalance = GetAvailableCreditLimit(MemberID)
        Else
            SMSText = SMSForMiscBillOther
            TemplateID = Temp_IDForMiscBillOther
            ClosingBalance = 0
        End If

        If SMSText = "" Then Exit Sub
        MobileNo = ObjDatabase.ExecuteScalarS("SELECT Mobile1 from MM_MemberProfile WHERE MemberID='" & MemberID & "'")

        Dim Mem_No, strMemNo As String
        Mem_No = ObjDatabase.ExecuteScalarS("SELECT isnull(OldMemNo,'') from MM_MemberProfile WHERE MemberID='" & MemberID & "'")
        If MemberID <> Mem_No And Mem_No <> "" Then
            strMemNo = Mem_No & "/" & MemberID
        Else
            strMemNo = MemberID
        End If

        If Len(MobileNo) = 10 Then
            '#A = AMOUNT DEBITED; #C = CARD ID; #L = LOCATION; #B = AVAILABLE BALANCE; #P = Pay Mode

            tempSMSText = SMSText
            tempSMSText = tempSMSText.Replace("#A", TxnAmt)
            tempSMSText = tempSMSText.Replace("#C", strMemNo.Trim())
            tempSMSText = tempSMSText.Replace("#L", "Reception")
            tempSMSText = tempSMSText.Replace("#B", ClosingBalance)
            tempSMSText = tempSMSText.Replace("#V", VchNo)
            Dim strSql As String = "INSERT INTO [MC_TransactionSMS]([MemberID],[MobileNo],[SMSType],[SMSText],[TemplateID],[CreationDate],[ModificationDate],[UserCode])" & vbCrLf & _
            "VALUES('" & MemberID & "','" & MobileNo & "','" & "Card Charge" & "','" & tempSMSText & "','" & TemplateID & "',getdate(),getdate()," & UserCode & ")"
            ObjDatabase.ExecuteNonQuery(strSql)
        End If
    End Sub

    Public Sub SEND_SMS_ALERT_FNB(ByVal MemberID As String, ByVal TxnAmt As Double, ByVal PayMode As String, ByVal VchNo As Integer)
        Dim SMSText As String = ""
        Dim TemplateID As String = ""
        Dim SMSType As String = ""
        Dim MobileNo As String = ""
        Dim ClosingBalance As Double = 0
        Dim tempSMSText As String = ""

        If PayMode.ToUpper = "SMARTCARD" Then
            SMSText = SMSForPOSBillingSmartCard
            TemplateID = Temp_IDForPOSBillingSmartCard
            ClosingBalance = GetSmartCardClosingBalance(MemberID)
        ElseIf PayMode.ToUpper = "MEMBER A/C" Then
            SMSText = SMSForPOSBillingMemberAc
            TemplateID = Temp_IDForPOSBillingMemberAc
            ClosingBalance = GetAvailableCreditLimit(MemberID)
        Else
            SMSText = SMSForPOSBillingOther
            TemplateID = Temp_IDForPOSBillingOther
            ClosingBalance = 0
        End If
        If SMSText = "" Then Exit Sub
        ObjDatabase.ConnectDatabse()
        ObjDatabase.OpenDatabaseConnection()
        StrSql = "SELECT count(*) from CM_GuestCardValidity where CardID='" & MemberID & "' AND Extendvalidity='Y'"
        RecCount = ObjDatabase.ExecuteScalarN(StrSql)
        If RecCount > 0 Then
            StrSql = "SELECT AlertOn from CM_GuestCardValidity where CardID='" & MemberID & "' AND Extendvalidity='Y'"
            MobileNo = ObjDatabase.ExecuteScalarS(StrSql)
        Else
            MobileNo = ObjDatabase.ExecuteScalarS("SELECT MobileNo from [View_MobileNo] WHERE MemberID='" & MemberID & "'")
        End If
        Dim Mem_No, strMemNo As String
        Mem_No = ObjDatabase.ExecuteScalarS("SELECT isnull(OldMemNo,'') from MM_MemberProfile WHERE MemberID='" & MemberID & "'")
        If MemberID <> Mem_No And Mem_No <> "" Then
            strMemNo = Mem_No & "/" & MemberID
        Else
            strMemNo = MemberID
        End If

        If Len(MobileNo) = 10 Then
            'RS. #A HAS BEEN DEBITED FROM YOUR SMARTCARD ACCOUNT (#C) FOR TXN DONE AT #L ON #D VIA TXN NO. #V. AVAILABLE BALANCE IS RS. #B 
            'SPORTS AND CULTURAL CLUB

            tempSMSText = SMSText
            tempSMSText = tempSMSText.Replace("#A", TxnAmt)
            tempSMSText = tempSMSText.Replace("#C", Trim(strMemNo))
            tempSMSText = tempSMSText.Replace("#L", LOCATION_NAME)
            tempSMSText = tempSMSText.Replace("#D", CurrentServerDate.ToString(DateFormat))
            tempSMSText = tempSMSText.Replace("#V", VchNo)
            tempSMSText = tempSMSText.Replace("#B", ClosingBalance)
            tempSMSText = tempSMSText.Replace("#P", PayMode)

            If PayMode.ToUpper = "SMARTCARD" Then
                SMSType = "FNB Bill"
            ElseIf PayMode.ToUpper = "MEMBER A/C" Then
                SMSType = "FNB Bill Credit"
            Else
                SMSType = "FNB Bill Other"
            End If

            StrSql = "INSERT INTO [MC_TransactionSMS]([MemberID],[MobileNo],[SMSType],[SMSText],[TemplateID],[CreationDate],[ModificationDate],[UserCode],SentStatus)" & vbCrLf & _
            "VALUES('" & MemberID & "','" & MobileNo & "','" & SMSType & "','" & tempSMSText & "','" & TemplateID & "',getdate(),getdate()," & UserCode & ",0)"
            ObjDatabase.ExecuteNonQuery(StrSql)
        End If
    End Sub

    Public Sub SEND_SMS_ALERT_MODIFY_BILL(ByVal MemberID As String, ByVal TxnAmt As Double, ByVal PayMode As String, ByVal VchNo As Integer)
        Dim SMSText As String = ""
        Dim TemplateID As String = ""
        Dim MobileNo As String = ""
        Dim ClosingBalance As Double = 0
        Dim tempSMSText As String = ""
        Dim SMSType As String = ""
        PayMode = ObjDatabase.ExecuteScalar("Select ModeOfPayment from FB_BillHead where BillNo=" & VchNo & " and YearCode=" & YearCode & " and LocationCode=" & LOCATION_Code)
        If PayMode.ToUpper = "SMARTCARD" Then
            SMSText = SMSForPOSBillCancellationSmartCard
            TemplateID = Temp_IDForPOSBillCancellationSmartCard
            ClosingBalance = GetSmartCardClosingBalance(MemberID)
        ElseIf PayMode.ToUpper = "MEMBER A/C" Then
            SMSText = SMSForPOSBillCancellationMemberAc
            TemplateID = Temp_IDForPOSBillCancellationMemberAc
            ClosingBalance = GetMemberAccountClosingBalance(MemberID)
        Else
            SMSText = SMSForPOSBillCancellationOther
            TemplateID = Temp_IDForPOSBillCancellationOther
            ClosingBalance = 0
        End If
        SMSType = "Bill Modify"

        Dim Mem_No, strMemNo As String
        Mem_No = ObjDatabase.ExecuteScalarS("SELECT isnull(OldMemNo,'') from MM_MemberProfile WHERE MemberID='" & MemberID & "'")
        If MemberID <> Mem_No And Mem_No <> "" Then
            strMemNo = Mem_No & "/" & MemberID
        Else
            strMemNo = MemberID
        End If

        If SMSText = "" Then Exit Sub
        ObjDatabase.ConnectDatabse()
        ObjDatabase.OpenDatabaseConnection()
        MobileNo = ObjDatabase.ExecuteScalarS("SELECT MobileNo from [View_MobileNo] WHERE MemberID='" & MemberID & "'")
        If Len(MobileNo) = 10 Then 'DEAR MEMBER RS. #A HAS BEEN CREDITED TO YOUR SMARTCARD AGAINST CANCELLATION OF BILL NO. #V. 
            '"RS. #A HAS BEEN CREDITED TO YOUR #P (#C) AGAINST BILL MODIFICATION DONE AT #L. CURRENT OUTSTANDING IS #B. 
            'PANCHSHILA CLUB
            'POWERED BY TECHNYK"

            tempSMSText = SMSText
            tempSMSText = tempSMSText.Replace("#A", TxnAmt)
            tempSMSText = tempSMSText.Replace("#P", Trim(PayMode))
            tempSMSText = tempSMSText.Replace("#C", Trim(strMemNo))
            tempSMSText = tempSMSText.Replace("#L", LOCATION_NAME)
            tempSMSText = tempSMSText.Replace("#B", ClosingBalance)
            tempSMSText = tempSMSText.Replace("#V", VchNo)
            Dim strSql As String = "INSERT INTO [MC_TransactionSMS]([MemberID],[MobileNo],[SMSType],[SMSText],[TemplateID],[CreationDate],[ModificationDate],[UserCode],SentStatus)" & vbCrLf & _
            "VALUES('" & MemberID & "','" & MobileNo & "','" & SMSType & "','" & tempSMSText & "','" & TemplateID & "',getdate(),getdate()," & UserCode & ",0)"
            ObjDatabase.ExecuteNonQuery(strSql)
        End If
    End Sub

End Module
