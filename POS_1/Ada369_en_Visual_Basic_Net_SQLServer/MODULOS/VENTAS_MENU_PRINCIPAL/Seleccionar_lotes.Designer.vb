<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seleccionar_lotes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seleccionar_lotes))
        Me.PanelVerLotes = New System.Windows.Forms.Panel()
        Me.datalistadoLOTES = New System.Windows.Forms.DataGridView()
        Me.Panel28 = New System.Windows.Forms.Panel()
        Me.btnHoy = New System.Windows.Forms.Button()
        Me.Panel36 = New System.Windows.Forms.Panel()
        Me.EditarLote = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PanelVerLotes.SuspendLayout()
        CType(Me.datalistadoLOTES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel28.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelVerLotes
        '
        Me.PanelVerLotes.Controls.Add(Me.datalistadoLOTES)
        Me.PanelVerLotes.Controls.Add(Me.Panel28)
        Me.PanelVerLotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelVerLotes.Location = New System.Drawing.Point(0, 0)
        Me.PanelVerLotes.Name = "PanelVerLotes"
        Me.PanelVerLotes.Size = New System.Drawing.Size(701, 273)
        Me.PanelVerLotes.TabIndex = 631
        '
        'datalistadoLOTES
        '
        Me.datalistadoLOTES.AllowUserToAddRows = False
        Me.datalistadoLOTES.AllowUserToDeleteRows = False
        Me.datalistadoLOTES.AllowUserToResizeRows = False
        Me.datalistadoLOTES.BackgroundColor = System.Drawing.Color.White
        Me.datalistadoLOTES.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datalistadoLOTES.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.datalistadoLOTES.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.datalistadoLOTES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datalistadoLOTES.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EditarLote})
        Me.datalistadoLOTES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datalistadoLOTES.EnableHeadersVisualStyles = False
        Me.datalistadoLOTES.Location = New System.Drawing.Point(27, 0)
        Me.datalistadoLOTES.Name = "datalistadoLOTES"
        Me.datalistadoLOTES.ReadOnly = True
        Me.datalistadoLOTES.RowHeadersVisible = False
        Me.datalistadoLOTES.RowHeadersWidth = 9
        Me.datalistadoLOTES.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.datalistadoLOTES.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.datalistadoLOTES.RowTemplate.Height = 40
        Me.datalistadoLOTES.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datalistadoLOTES.Size = New System.Drawing.Size(674, 273)
        Me.datalistadoLOTES.TabIndex = 618
        '
        'Panel28
        '
        Me.Panel28.Controls.Add(Me.btnHoy)
        Me.Panel28.Controls.Add(Me.Panel36)
        Me.Panel28.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Panel28.Location = New System.Drawing.Point(0, 0)
        Me.Panel28.Name = "Panel28"
        Me.Panel28.Size = New System.Drawing.Size(27, 273)
        Me.Panel28.TabIndex = 617
        '
        'btnHoy
        '
        Me.btnHoy.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnHoy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHoy.FlatAppearance.BorderSize = 0
        Me.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHoy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnHoy.ForeColor = System.Drawing.Color.White
        Me.btnHoy.Location = New System.Drawing.Point(2, 0)
        Me.btnHoy.Name = "btnHoy"
        Me.btnHoy.Size = New System.Drawing.Size(25, 273)
        Me.btnHoy.TabIndex = 616
        Me.btnHoy.Text = "LOTES"
        Me.btnHoy.UseVisualStyleBackColor = False
        '
        'Panel36
        '
        Me.Panel36.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Panel36.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel36.Location = New System.Drawing.Point(0, 0)
        Me.Panel36.Name = "Panel36"
        Me.Panel36.Size = New System.Drawing.Size(2, 273)
        Me.Panel36.TabIndex = 619
        '
        'EditarLote
        '
        Me.EditarLote.DataPropertyName = "Marcar"
        Me.EditarLote.HeaderText = "Editar"
        Me.EditarLote.Name = "EditarLote"
        Me.EditarLote.ReadOnly = True
        Me.EditarLote.Text = "Editar Lote"
        Me.EditarLote.ToolTipText = "Editar Lote"
        Me.EditarLote.UseColumnTextForButtonValue = True
        Me.EditarLote.Visible = False
        '
        'Seleccionar_lotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 273)
        Me.Controls.Add(Me.PanelVerLotes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Seleccionar_lotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar lote"
        Me.PanelVerLotes.ResumeLayout(False)
        CType(Me.datalistadoLOTES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel28.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelVerLotes As Panel
    Friend WithEvents datalistadoLOTES As DataGridView
    Friend WithEvents Panel28 As Panel
    Friend WithEvents btnHoy As Button
    Friend WithEvents Panel36 As Panel
    Friend WithEvents EditarLote As DataGridViewButtonColumn
End Class
