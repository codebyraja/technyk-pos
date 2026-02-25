Imports System.Data.SqlClient

Module BindCombo
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    
    Public Function BindComboboxForSingleColumnNumeric(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        Dim sql As String
        sql = " Union All " & "select 0 ORDER BY 1"
        strSql = strSql & sql
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
        Return objcmb
    End Function

    Public Function BindComboboxForSingleColumnString(ByVal strSql As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        Dim sql As String
        sql = " Union All " & "select '[Select One]' ORDER BY 1"
        strSql = strSql & sql
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = DisplayMember
        Return objcmb
    End Function

    Public Sub BindComboboxBothStringSelectOne(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        Dim sql As String
        ds = New DataSet
        sql = strSql & " Union All " & "select '','[Select One]' ORDER BY 1"
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
    End Sub

    Public Sub BindComboboxBothStringSelectAll(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        Dim sql As String
        ds = New DataSet
        sql = " Union All " & "select '','[Select All]' ORDER BY 1"
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
    End Sub

    Public Sub BindComboboxWithSelectOneString(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        ds = New DataSet
        strSql = strSql & " UNION ALL SELECT '','[Select One]' ORDER BY " & DisplayMember
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
    End Sub

    Public Function BindComboboxWithSelectAllOnly(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        Dim sql As String
        sql = " Union All " & "Select '[Select All]' "
        strSql = strSql & sql
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
        Return objcmb
    End Function

    Public Sub BindComboBoxWithSingleStringSelectAll(ByVal strSql As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        ds = New DataSet
        strSql = strSql & " UNION ALL Select '[Select All]' Order by " & DisplayMember
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = DisplayMember
    End Sub

    Public Sub BindComboboxWithoutSelectOneNumeric(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        ds = New DataSet
        strSql = strSql & " ORDER BY " & DisplayMember
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
    End Sub

    Public Sub BindComboboxWithCustomSelectOne(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox, ByVal SelectOneText As String)
        ds = New DataSet
        strSql = strSql & " UNION ALL SELECT 0,'[" & SelectOneText & "]' ORDER BY " & DisplayMember
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
    End Sub

    Public Function BindComboForStringStringColumn(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        Dim sql As String
        sql = " Union All " & "select '0' ,'[Select One]' ORDER BY 2"
        strSql = strSql & sql
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
        Return objcmb
    End Function

    Public Sub BindComboboxWithSelectOneNumeric(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        ds = New DataSet
        strSql = strSql & " UNION ALL SELECT 0,'[Select One]' ORDER BY " & DisplayMember
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
    End Sub

    Public Sub BindComboWithoutSelectOneNumeric(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        ds = New DataSet
        strSql = strSql & " ORDER BY " & DisplayMember
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
    End Sub

    Public Sub BindComboboxWithSelectAllNumeric(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        ds = New DataSet
        strSql = strSql & " UNION ALL SELECT 0,'[Select All]' ORDER BY " & DisplayMember
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
    End Sub

    Public Function BindListWithCheckBoxes(ByVal strSql As String, ByVal valMember As String, ByVal dispMember As String, ByVal objList As CheckedListBox) As CheckedListBox
        Dim sql As String = ""
        strSql = strSql & sql & " Order by " & dispMember
        ds = New DataSet
        ds = ObjDatabase.BindDataSet(strSql, "ItemRelated")
        objList.DataSource = ds.Tables("ItemRelated")
        objList.DisplayMember = dispMember
        objList.ValueMember = valMember
        BindListWithCheckBoxes = objList
    End Function

    Public Sub BindComboboxWithSelectOneSingleStringColumn(ByVal strSql As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByVal objcmb As ComboBox)
        ds = New DataSet
        strSql = strSql & " UNION ALL SELECT '[Select One]' ORDER BY " & DisplayMember
        ds = ObjDatabase.BindDataSet(strSql, "BindData")
        objcmb.DataSource = ds.Tables("BindData")
        objcmb.DisplayMember = DisplayMember
        objcmb.ValueMember = ValueMember
    End Sub

    Public Function BindComboboxWithSelectAllSingleStringColumn(ByVal strSql As String, ByVal valMember As String, ByVal dispMember As String, ByVal objcmb As ComboBox)
        Dim sql As String
        sql = " Union All " & "select '[Select All]' "
        strSql = strSql & sql
        ds = New DataSet
        ds = BindDataSet(strSql, "ItemRelated")
        objcmb.DataSource = ds.Tables("ItemRelated")
        objcmb.DisplayMember = dispMember
        objcmb.ValueMember = valMember
        Return objcmb
    End Function

    Public Sub comboBindingSelectAllOnly(ByVal strSql As String, ByVal valMember As String, ByVal dispMember As String, ByVal objcmb As ComboBox)
        Dim sql As String
        sql = " Union All " & "select '[Select All]' "
        strSql = strSql & sql
        ds = New DataSet
        ds = objDatabase.BindDataSet(strSql, "Data")
        objcmb.DataSource = ds.Tables("Data")
        objcmb.DisplayMember = dispMember
        objcmb.ValueMember = valMember
    End Sub

End Module
