Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class FrmChangeBusinessDate
    Dim ds As DataSet

    Protected Overloads Overrides Function _
          ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If TypeOf ActiveControl Is Button = False Then
            Select Case keyData
                Case Keys.Enter
                    Return MyBase.ProcessDialogKey(Keys.Tab)
                Case Keys.Escape
                    Return MyBase.ProcessDialogKey(Keys.Shift Or _
                        Keys.Tab)
            End Select
        Else
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Private Sub FrmChangeBusinessDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ObjDatabase.ConnectDatabse()
        DisableControl(Me)
        EnableButton("Cancel", Me)
        dtpBusinessDate.Enabled = False
        btnChangeDate.Enabled = False
        Dim BD As Date = GetCurrentBusinessDate()
        dtpBusinessDate.Value = BD
        dtpBusinessDate.Tag = dtpBusinessDate.Value
        BindOpenBills()
        StrSql = "select count(*) from FB_Billhead where BillStatus=0 and Amount>0 and BillDate='" & BD.ToString(DateFormat) & "'"
        Dim BillCount As Integer = ObjDatabase.ExecuteScalar(StrSql)
        If BillCount > 0 Then
            MsgBox("Day end not allowed as there are some open bill(s).", MsgBoxStyle.Information)
            btnChangeDate.Enabled = False
        End If
        dtpBusinessDate.MaxDate = BD.AddDays(1)
    End Sub

    Private Sub BindOpenBills()
        Dim dsOpenBills As New DataSet
        StrSql = "SELECT BH.[BillNo],BH.[BillDate],bh.MemberName,LM.LocationName,BH.[Amount]" & _
        " FROM [FB_BillHead] BH,IM_LocationMaster LM " & _
        " where BH.[BillDate]='" & dtpBusinessDate.Value.ToString("dd/MMM/yyyy") & "'" & _
        " and (BillStatus=0 or ModeOfPayment='') and BH.Amount>0 and BH.YearCode=" & YearCode & _
        " and BH.LocationCode=LM.Code order by BH.[BillNo] desc"
        dsOpenBills = ObjDatabase.BindDataSet(StrSql, "Bills")
        dgOpenBills.DataSource = dsOpenBills.Tables("Bills")
        FormatDataGridView(dgOpenBills)
        dgOpenBills.Columns("BillDate").Visible = True
        dgOpenBills.Columns("LocationName").Width = 120
        dgOpenBills.Columns("BillNo").Width = 80
        dgOpenBills.Columns("BillDate").Width = 120
        dgOpenBills.Columns("BillNo").HeaderText = "Bill No"
        dgOpenBills.Columns("Amount").HeaderText = "Amount"
        dgOpenBills.Columns("Amount").DefaultCellStyle.Format = "###0.00"
        dgOpenBills.Columns("Amount").Width = 60
        dgOpenBills.Columns("Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgOpenBills.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgOpenBills.Columns("BillNo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgOpenBills.Columns("BillNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgOpenBills.Columns("LocationName").HeaderText = "Location"
        dgOpenBills.Columns("LocationName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgOpenBills.Columns("LocationName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgOpenBills.Columns("LocationName").Width = 150
        dgOpenBills.Columns("MemberName").HeaderText = "MemberName"
        dgOpenBills.Columns("MemberName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgOpenBills.Columns("MemberName").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgOpenBills.Columns("MemberName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgOpenBills.RowHeadersVisible = True
        dgOpenBills.RowHeadersWidth = 25
        dgOpenBills.RowTemplate.Height = 26
        If dgOpenBills.RowCount > 0 Then
            dtpBusinessDate.Enabled = False
            btnChangeDate.Enabled = False
        Else
            dtpBusinessDate.Enabled = True
            btnChangeDate.Enabled = True
        End If
    End Sub

    Private Sub btnChangeDate_Click(sender As Object, e As EventArgs) Handles btnChangeDate.Click
        If dtpBusinessDate.Value <= dtpBusinessDate.Tag Then
            MsgBox("Next Business date cannot be less than or equal to the Current Business date", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If CDate(dtpBusinessDate.Value.ToString(DateFormat)) > CDate(CurrentServerDate.ToString(DateFormat)) Then
            MsgBox("Next Business date cannot be more than the Current Business date", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Are you sure to Change the Business Date?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            Try
                StrSql = "UPDATE [FB_BusinessDate] SET [CurentStatus]=1,[ModificationDate]=Getdate(),[UserCode]=" & UserCode & " WHERE [BusinessDate]='" & CDate(dtpBusinessDate.Tag).ToString("dd/MMM/yyyy") & "'"
                ObjDatabase.ExecuteNonQuery(StrSql)

                StrSql = "INSERT INTO [FB_BusinessDate] ([BusinessDate] ,[CreationDate],[ModificationDate],[CurentStatus],[UserCode])" & vbCrLf & _
                " VALUES('" & dtpBusinessDate.Value.ToString("dd/MMM/yyyy") & "',Getdate(), Getdate(),0," & UserCode & ")"
                ObjDatabase.ExecuteNonQuery(StrSql)

                MsgBox("Business date has been changed Successfully", MsgBoxStyle.Information)
                ObjDatabase.CloseDatabaseConnection()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Me.Dispose()
        'BackToMainScreen = True
        General.Close(Me)
    End Sub
End Class