<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_de_IMPRESORAS
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_de_IMPRESORAS))
        Me.cbxTiket = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblIDSERIAL = New System.Windows.Forms.Label()
        Me.datalistado_empresas_nuevas = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DATALISTADOcajas = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxA4 = New System.Windows.Forms.ComboBox()
        Me.MenuStrip4 = New System.Windows.Forms.MenuStrip()
        Me.guardarBTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.datalistado_empresas_nuevas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DATALISTADOcajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbxTiket
        '
        Me.cbxTiket.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxTiket.FormattingEnabled = True
        Me.cbxTiket.Location = New System.Drawing.Point(275, 50)
        Me.cbxTiket.Name = "cbxTiket"
        Me.cbxTiket.Size = New System.Drawing.Size(359, 28)
        Me.cbxTiket.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cbxA4)
        Me.Panel2.Controls.Add(Me.cbxTiket)
        Me.Panel2.Controls.Add(Me.MenuStrip4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(168, 105)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(666, 449)
        Me.Panel2.TabIndex = 599
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblIDSERIAL)
        Me.Panel1.Controls.Add(Me.datalistado_empresas_nuevas)
        Me.Panel1.Controls.Add(Me.DATALISTADOcajas)
        Me.Panel1.Location = New System.Drawing.Point(118, 305)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 10)
        Me.Panel1.TabIndex = 597
        '
        'lblIDSERIAL
        '
        Me.lblIDSERIAL.AutoSize = True
        Me.lblIDSERIAL.Location = New System.Drawing.Point(169, 12)
        Me.lblIDSERIAL.Name = "lblIDSERIAL"
        Me.lblIDSERIAL.Size = New System.Drawing.Size(39, 13)
        Me.lblIDSERIAL.TabIndex = 596
        Me.lblIDSERIAL.Text = "Label4"
        '
        'datalistado_empresas_nuevas
        '
        Me.datalistado_empresas_nuevas.AllowUserToAddRows = False
        Me.datalistado_empresas_nuevas.AllowUserToDeleteRows = False
        Me.datalistado_empresas_nuevas.BackgroundColor = System.Drawing.Color.White
        Me.datalistado_empresas_nuevas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datalistado_empresas_nuevas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datalistado_empresas_nuevas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.datalistado_empresas_nuevas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datalistado_empresas_nuevas.ColumnHeadersVisible = False
        Me.datalistado_empresas_nuevas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datalistado_empresas_nuevas.DefaultCellStyle = DataGridViewCellStyle8
        Me.datalistado_empresas_nuevas.EnableHeadersVisualStyles = False
        Me.datalistado_empresas_nuevas.Location = New System.Drawing.Point(99, 60)
        Me.datalistado_empresas_nuevas.Name = "datalistado_empresas_nuevas"
        Me.datalistado_empresas_nuevas.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datalistado_empresas_nuevas.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.datalistado_empresas_nuevas.RowHeadersWidth = 5
        Me.datalistado_empresas_nuevas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datalistado_empresas_nuevas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.datalistado_empresas_nuevas.RowTemplate.Height = 40
        Me.datalistado_empresas_nuevas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datalistado_empresas_nuevas.Size = New System.Drawing.Size(109, 79)
        Me.datalistado_empresas_nuevas.TabIndex = 594
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Eliminar"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Visible = False
        '
        'DATALISTADOcajas
        '
        Me.DATALISTADOcajas.AllowUserToAddRows = False
        Me.DATALISTADOcajas.AllowUserToDeleteRows = False
        Me.DATALISTADOcajas.AllowUserToResizeRows = False
        Me.DATALISTADOcajas.BackgroundColor = System.Drawing.Color.White
        Me.DATALISTADOcajas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATALISTADOcajas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DATALISTADOcajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DATALISTADOcajas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn3})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DATALISTADOcajas.DefaultCellStyle = DataGridViewCellStyle11
        Me.DATALISTADOcajas.Location = New System.Drawing.Point(43, 84)
        Me.DATALISTADOcajas.Name = "DATALISTADOcajas"
        Me.DATALISTADOcajas.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATALISTADOcajas.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DATALISTADOcajas.RowHeadersVisible = False
        Me.DATALISTADOcajas.RowHeadersWidth = 5
        Me.DATALISTADOcajas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.ForestGreen
        Me.DATALISTADOcajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATALISTADOcajas.Size = New System.Drawing.Size(88, 75)
        Me.DATALISTADOcajas.TabIndex = 595
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "Activo"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Activo"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.ReadOnly = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(34, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(235, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Impresora para Formato A4:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(9, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(261, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Impresora para Formato Ticket:"
        '
        'cbxA4
        '
        Me.cbxA4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxA4.FormattingEnabled = True
        Me.cbxA4.Location = New System.Drawing.Point(275, 100)
        Me.cbxA4.Name = "cbxA4"
        Me.cbxA4.Size = New System.Drawing.Size(359, 28)
        Me.cbxA4.TabIndex = 4
        '
        'MenuStrip4
        '
        Me.MenuStrip4.AutoSize = False
        Me.MenuStrip4.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip4.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.guardarBTN})
        Me.MenuStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip4.Location = New System.Drawing.Point(275, 199)
        Me.MenuStrip4.Name = "MenuStrip4"
        Me.MenuStrip4.ShowItemToolTips = True
        Me.MenuStrip4.Size = New System.Drawing.Size(233, 32)
        Me.MenuStrip4.TabIndex = 587
        Me.MenuStrip4.Text = "MenuStrip4"
        '
        'guardarBTN
        '
        Me.guardarBTN.BackColor = System.Drawing.Color.Gainsboro
        Me.guardarBTN.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.guardarBTN.ForeColor = System.Drawing.Color.Black
        Me.guardarBTN.Image = CType(resources.GetObject("guardarBTN.Image"), System.Drawing.Image)
        Me.guardarBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.guardarBTN.Name = "guardarBTN"
        Me.guardarBTN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.guardarBTN.Size = New System.Drawing.Size(92, 28)
        Me.guardarBTN.Text = "Guardar"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label6.Location = New System.Drawing.Point(10, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(631, 29)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Los Reportes se Imprimen en Formato A4 y los Comprobantes en Formato Ticket"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(5, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(315, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Selecciona Impresora Predeterminada"
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(1144, 233)
        Me.Panel12.TabIndex = 606
        '
        'Admin_de_IMPRESORAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 596)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel12)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Admin_de_IMPRESORAS"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin Impresoras"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.datalistado_empresas_nuevas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DATALISTADOcajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip4.ResumeLayout(False)
        Me.MenuStrip4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbxTiket As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip4 As MenuStrip
    Friend WithEvents guardarBTN As ToolStripMenuItem
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents datalistado_empresas_nuevas As DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Public WithEvents DATALISTADOcajas As DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn3 As DataGridViewCheckBoxColumn
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents cbxA4 As ComboBox
    Friend WithEvents lblIDSERIAL As Label
    Friend WithEvents Panel1 As Panel
End Class
