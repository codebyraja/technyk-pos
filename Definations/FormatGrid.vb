Imports System.Data.SqlClient

Module FormatGrid

    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle

    Public Function FormatDataGridView(ByVal GridView As DataGridView)
        Try
            GridView.AlternatingRowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(3)
            GridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            GridView.DefaultCellStyle.ForeColor = Color.Black
            GridView.RowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
            GridView.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            GridView.GridColor = Color.Black
            GridView.BorderStyle = BorderStyle.Fixed3D

            GridView.RowsDefaultCellStyle.SelectionBackColor = Color.Tomato
            GridView.RowsDefaultCellStyle.SelectionForeColor = Color.White
            GridView.RowHeadersVisible = True
            GridView.AutoResizeColumns()
            GridView.AutoResizeRows()
            GridView.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            GridView.RowsDefaultCellStyle.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            GridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon
            GridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat
            GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            GridView.RowTemplate.Height = 30
            GridView.Cursor = Cursors.Hand
            GridView.RowHeadersVisible = True
            Return GridView
        Catch es As SqlException
            Return ""
            MsgBox(es.Message, MsgBoxStyle.OkOnly, "INFORMATION")
        Catch ee As System.Exception
            Return ""
            MsgBox(ee.Message, MsgBoxStyle.OkOnly, "INFORMATION")
        Finally
        End Try
    End Function

    Public Function FormatDataGridViewBooking(ByVal GridView As DataGridView)
        Try
            GridView.AlternatingRowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(3)
            GridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            GridView.DefaultCellStyle.ForeColor = Color.Black
            GridView.RowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
            GridView.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            GridView.GridColor = Color.Black
            GridView.BorderStyle = BorderStyle.Fixed3D

            GridView.RowsDefaultCellStyle.SelectionBackColor = Color.Tomato
            GridView.RowsDefaultCellStyle.SelectionForeColor = Color.White
            GridView.RowHeadersVisible = True
            GridView.AutoResizeColumns()
            GridView.AutoResizeRows()
            GridView.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            GridView.RowsDefaultCellStyle.Font = New System.Drawing.Font("arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            GridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon
            GridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat
            GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            GridView.RowTemplate.Height = 30
            GridView.Cursor = Cursors.Hand
            GridView.RowHeadersVisible = True
            Return GridView
        Catch es As SqlException
            Return ""
            MsgBox(es.Message, MsgBoxStyle.OkOnly, "INFORMATION")
        Catch ee As System.Exception
            Return ""
            MsgBox(ee.Message, MsgBoxStyle.OkOnly, "INFORMATION")
        Finally
        End Try
    End Function

    Public Function dgvFormatCustomColumnCustomColumnOpenKOT(ByVal GridView As DataGridView)
        Try
            GridView.AlternatingRowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(3)
            GridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            GridView.DefaultCellStyle.ForeColor = Color.Black
            GridView.RowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
            GridView.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
            GridView.GridColor = Color.Maroon
            GridView.BorderStyle = BorderStyle.Fixed3D
            GridView.RowsDefaultCellStyle.SelectionBackColor = Color.Tomato
            GridView.RowsDefaultCellStyle.SelectionForeColor = Color.White
            GridView.RowHeadersVisible = False
            GridView.AutoResizeColumns()
            GridView.AutoResizeRows()
            GridView.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            GridView.RowsDefaultCellStyle.Font = New System.Drawing.Font("arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            GridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon
            GridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat
            Return GridView
        Catch es As SqlException
            Return ""
            MsgBox(es.Message, MsgBoxStyle.OkOnly, "INFORMATION")
        Catch ee As System.Exception
            Return ""
            MsgBox(ee.Message, MsgBoxStyle.OkOnly, "INFORMATION")
        Finally
        End Try
    End Function

    Public Function FormatGridWithRowHeaderSNo(ByVal GridView As DataGridView)
        Try
            GridView.AlternatingRowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(3)
            GridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(159, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(159, Byte), Integer))
            GridView.DefaultCellStyle.ForeColor = Color.Black
            GridView.RowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
            GridView.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(205, Byte), Integer))
            GridView.GridColor = Color.Black
            GridView.BorderStyle = BorderStyle.FixedSingle
            GridView.ReadOnly = True
            GridView.RowsDefaultCellStyle.SelectionBackColor = Color.Tomato
            GridView.RowsDefaultCellStyle.SelectionForeColor = Color.White
            GridView.RowHeadersVisible = True
            GridView.RowHeadersWidth = 48
            GridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.Format = "###"
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            GridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
            GridView.Cursor = Cursors.Hand
            GridView.Columns(0).HeaderText = ""
            GridView.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            GridView.RowsDefaultCellStyle.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            GridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
            GridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat
            GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            GridView.BackgroundColor = Color.LightGray
            GridView.RowTemplate.Height = 25
            Return GridView
        Catch es As SqlException
            Return ""
            MsgBox(es.Message, MsgBoxStyle.OkOnly, "")
        Catch ee As System.Exception
            Return ""
            MsgBox(ee.Message, MsgBoxStyle.OkOnly, "")
        Finally
        End Try
    End Function

End Module
