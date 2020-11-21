<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Comprobante_de_cobro_Form
    Inherits System.Windows.Forms.Form

    'Form reemplaza a hide para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Comprobante_de_cobro_Form))
        Me.ReportViewer1 = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.lblIdSerial = New System.Windows.Forms.Label()
        Me.datalistado_caja = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.datalistado_caja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(599, 369)
        Me.ReportViewer1.TabIndex = 0
        '
        'lblIdSerial
        '
        Me.lblIdSerial.AutoSize = True
        Me.lblIdSerial.Location = New System.Drawing.Point(280, 178)
        Me.lblIdSerial.Name = "lblIdSerial"
        Me.lblIdSerial.Size = New System.Drawing.Size(39, 13)
        Me.lblIdSerial.TabIndex = 624
        Me.lblIdSerial.Text = "Label2"
        '
        'datalistado_caja
        '
        Me.datalistado_caja.AllowUserToAddRows = False
        Me.datalistado_caja.AllowUserToDeleteRows = False
        Me.datalistado_caja.AllowUserToResizeRows = False
        Me.datalistado_caja.BackgroundColor = System.Drawing.Color.DarkGray
        Me.datalistado_caja.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datalistado_caja.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.datalistado_caja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datalistado_caja.ColumnHeadersVisible = False
        Me.datalistado_caja.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn4})
        Me.datalistado_caja.EnableHeadersVisualStyles = False
        Me.datalistado_caja.Location = New System.Drawing.Point(231, 79)
        Me.datalistado_caja.Name = "datalistado_caja"
        Me.datalistado_caja.ReadOnly = True
        Me.datalistado_caja.RowHeadersVisible = False
        Me.datalistado_caja.RowHeadersWidth = 9
        Me.datalistado_caja.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datalistado_caja.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.datalistado_caja.RowTemplate.Height = 40
        Me.datalistado_caja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datalistado_caja.Size = New System.Drawing.Size(137, 210)
        Me.datalistado_caja.TabIndex = 625
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "Marcar"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "Marcar"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.ReadOnly = True
        '
        'Comprobante_de_cobro_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 369)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.lblIdSerial)
        Me.Controls.Add(Me.datalistado_caja)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Comprobante_de_cobro_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.datalistado_caja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents lblIdSerial As Label
    Friend WithEvents datalistado_caja As DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn4 As DataGridViewCheckBoxColumn
End Class
