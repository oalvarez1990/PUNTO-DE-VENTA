<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Flujo_caja
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Flujo_caja))
        Me.datalistadoVentasReport = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblfechaHoy = New System.Windows.Forms.Label()
        Me.datalistadoGastos = New System.Windows.Forms.DataGridView()
        Me.ReportViewer1 = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.R = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.datalistadoVentasReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datalistadoGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'datalistadoVentasReport
        '
        Me.datalistadoVentasReport.AllowUserToAddRows = False
        Me.datalistadoVentasReport.AllowUserToDeleteRows = False
        Me.datalistadoVentasReport.AllowUserToResizeRows = False
        Me.datalistadoVentasReport.BackgroundColor = System.Drawing.Color.White
        Me.datalistadoVentasReport.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datalistadoVentasReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.datalistadoVentasReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datalistadoVentasReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.datalistadoVentasReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datalistadoVentasReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.R})
        Me.datalistadoVentasReport.EnableHeadersVisualStyles = False
        Me.datalistadoVentasReport.GridColor = System.Drawing.Color.Gainsboro
        Me.datalistadoVentasReport.Location = New System.Drawing.Point(27, 76)
        Me.datalistadoVentasReport.Name = "datalistadoVentasReport"
        Me.datalistadoVentasReport.ReadOnly = True
        Me.datalistadoVentasReport.RowHeadersVisible = False
        Me.datalistadoVentasReport.RowHeadersWidth = 9
        Me.datalistadoVentasReport.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.datalistadoVentasReport.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datalistadoVentasReport.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.datalistadoVentasReport.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gainsboro
        Me.datalistadoVentasReport.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.datalistadoVentasReport.RowTemplate.Height = 36
        Me.datalistadoVentasReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datalistadoVentasReport.Size = New System.Drawing.Size(258, 244)
        Me.datalistadoVentasReport.TabIndex = 393
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(409, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 52)
        Me.Button1.TabIndex = 394
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblfechaHoy
        '
        Me.lblfechaHoy.AutoSize = True
        Me.lblfechaHoy.Location = New System.Drawing.Point(24, 15)
        Me.lblfechaHoy.Name = "lblfechaHoy"
        Me.lblfechaHoy.Size = New System.Drawing.Size(63, 13)
        Me.lblfechaHoy.TabIndex = 395
        Me.lblfechaHoy.Text = "lblfechaHoy"
        '
        'datalistadoGastos
        '
        Me.datalistadoGastos.AllowUserToAddRows = False
        Me.datalistadoGastos.AllowUserToDeleteRows = False
        Me.datalistadoGastos.AllowUserToResizeRows = False
        Me.datalistadoGastos.BackgroundColor = System.Drawing.Color.White
        Me.datalistadoGastos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datalistadoGastos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.datalistadoGastos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datalistadoGastos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.datalistadoGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datalistadoGastos.EnableHeadersVisualStyles = False
        Me.datalistadoGastos.GridColor = System.Drawing.Color.Gainsboro
        Me.datalistadoGastos.Location = New System.Drawing.Point(308, 76)
        Me.datalistadoGastos.Name = "datalistadoGastos"
        Me.datalistadoGastos.ReadOnly = True
        Me.datalistadoGastos.RowHeadersVisible = False
        Me.datalistadoGastos.RowHeadersWidth = 9
        Me.datalistadoGastos.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.datalistadoGastos.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datalistadoGastos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.datalistadoGastos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gainsboro
        Me.datalistadoGastos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.datalistadoGastos.RowTemplate.Height = 36
        Me.datalistadoGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datalistadoGastos.Size = New System.Drawing.Size(258, 244)
        Me.datalistadoGastos.TabIndex = 396
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(832, 683)
        Me.ReportViewer1.TabIndex = 397
        Me.ReportViewer1.ViewMode = Telerik.ReportViewer.WinForms.ViewMode.PrintPreview
        '
        'DataGridViewButtonColumn1
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewButtonColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DataGridViewButtonColumn1.HeaderText = ""
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.ReadOnly = True
        Me.DataGridViewButtonColumn1.Text = "-"
        Me.DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonColumn1.Visible = False
        '
        'R
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.R.DefaultCellStyle = DataGridViewCellStyle2
        Me.R.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.R.HeaderText = ""
        Me.R.Name = "R"
        Me.R.ReadOnly = True
        Me.R.Text = "-"
        Me.R.UseColumnTextForButtonValue = True
        Me.R.Visible = False
        '
        'DataGridViewButtonColumn2
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewButtonColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DataGridViewButtonColumn2.HeaderText = ""
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.Text = "-"
        Me.DataGridViewButtonColumn2.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonColumn2.Visible = False
        '
        'Flujo_caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 683)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.datalistadoGastos)
        Me.Controls.Add(Me.lblfechaHoy)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.datalistadoVentasReport)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Flujo_caja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Flujo de caja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.datalistadoVentasReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datalistadoGastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents datalistadoVentasReport As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents lblfechaHoy As Label
    Friend WithEvents R As DataGridViewButtonColumn
    Friend WithEvents datalistadoGastos As DataGridView
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
    Friend WithEvents ReportViewer1 As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents DataGridViewButtonColumn2 As DataGridViewButtonColumn
End Class
