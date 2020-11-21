<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MENU_dE_REPORTES_OI
    Inherits System.Windows.Forms.Form

    'Form reemplaza a hide para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MENU_dE_REPORTES_OI))
        Me.tmMOSTRAR = New System.Windows.Forms.Timer(Me.components)
        Me.tmOCULTAR = New System.Windows.Forms.Timer(Me.components)
        Me.Panel72 = New System.Windows.Forms.Panel()
        Me.BtnProductos = New System.Windows.Forms.Button()
        Me.BtnPagar = New System.Windows.Forms.Button()
        Me.btnCobrar = New System.Windows.Forms.Button()
        Me.btnVentas = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PanelBienvenida = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelVENTAS = New System.Windows.Forms.Panel()
        Me.ReportViewer1 = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PanelEmpleado = New System.Windows.Forms.Panel()
        Me.txtEmpleado = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnHoy = New System.Windows.Forms.Button()
        Me.chekFiltros = New System.Windows.Forms.CheckBox()
        Me.PanelFiltros = New System.Windows.Forms.Panel()
        Me.TXTFF = New System.Windows.Forms.DateTimePicker()
        Me.TXTFI = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuStrip6 = New System.Windows.Forms.MenuStrip()
        Me.TFILTROS = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnResumenVentas = New System.Windows.Forms.Button()
        Me.PResumenVentas = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.PVentasPorempleado = New System.Windows.Forms.Panel()
        Me.PanelPorCobrarPagar = New System.Windows.Forms.Panel()
        Me.ReportViewer2 = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.PanelProductos = New System.Windows.Forms.Panel()
        Me.ReportViewer3 = New Telerik.ReportViewer.WinForms.ReportViewer()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PInventarios = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Pvencidos = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.PStockBajo = New System.Windows.Forms.Panel()
        Me.Panel72.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBienvenida.SuspendLayout()
        Me.PanelVENTAS.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.PanelEmpleado.SuspendLayout()
        Me.PanelFiltros.SuspendLayout()
        Me.MenuStrip6.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PanelPorCobrarPagar.SuspendLayout()
        Me.PanelProductos.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmMOSTRAR
        '
        Me.tmMOSTRAR.Interval = 2
        '
        'tmOCULTAR
        '
        Me.tmOCULTAR.Interval = 2
        '
        'Panel72
        '
        Me.Panel72.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Panel72.Controls.Add(Me.BtnProductos)
        Me.Panel72.Controls.Add(Me.BtnPagar)
        Me.Panel72.Controls.Add(Me.btnCobrar)
        Me.Panel72.Controls.Add(Me.btnVentas)
        Me.Panel72.Controls.Add(Me.Panel1)
        Me.Panel72.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel72.Location = New System.Drawing.Point(0, 0)
        Me.Panel72.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel72.Name = "Panel72"
        Me.Panel72.Size = New System.Drawing.Size(252, 542)
        Me.Panel72.TabIndex = 402
        '
        'BtnProductos
        '
        Me.BtnProductos.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnProductos.FlatAppearance.BorderSize = 0
        Me.BtnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProductos.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnProductos.Location = New System.Drawing.Point(0, 232)
        Me.BtnProductos.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProductos.Name = "BtnProductos"
        Me.BtnProductos.Size = New System.Drawing.Size(252, 60)
        Me.BtnProductos.TabIndex = 616
        Me.BtnProductos.Text = "Productos"
        Me.BtnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProductos.UseVisualStyleBackColor = True
        '
        'BtnPagar
        '
        Me.BtnPagar.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnPagar.FlatAppearance.BorderSize = 0
        Me.BtnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPagar.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPagar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnPagar.Location = New System.Drawing.Point(0, 172)
        Me.BtnPagar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnPagar.Name = "BtnPagar"
        Me.BtnPagar.Size = New System.Drawing.Size(252, 60)
        Me.BtnPagar.TabIndex = 615
        Me.BtnPagar.Text = "Cuentas por Pagar"
        Me.BtnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPagar.UseVisualStyleBackColor = True
        '
        'btnCobrar
        '
        Me.btnCobrar.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCobrar.FlatAppearance.BorderSize = 0
        Me.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCobrar.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCobrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCobrar.Location = New System.Drawing.Point(0, 112)
        Me.btnCobrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(252, 60)
        Me.btnCobrar.TabIndex = 614
        Me.btnCobrar.Text = "Cuentas por Cobrar"
        Me.btnCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCobrar.UseVisualStyleBackColor = True
        '
        'btnVentas
        '
        Me.btnVentas.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnVentas.FlatAppearance.BorderSize = 0
        Me.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVentas.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVentas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnVentas.Location = New System.Drawing.Point(0, 52)
        Me.btnVentas.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Size = New System.Drawing.Size(252, 60)
        Me.btnVentas.TabIndex = 613
        Me.btnVentas.Text = "Ventas"
        Me.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVentas.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.Label66)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(252, 52)
        Me.Panel1.TabIndex = 593
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(1, 4)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(53, 43)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 610
        Me.PictureBox4.TabStop = False
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Font = New System.Drawing.Font("Consolas", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label66.ForeColor = System.Drawing.Color.DimGray
        Me.Label66.Location = New System.Drawing.Point(59, 14)
        Me.Label66.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(87, 23)
        Me.Label66.TabIndex = 609
        Me.Label66.Text = "Ada 369"
        '
        'PanelBienvenida
        '
        Me.PanelBienvenida.Controls.Add(Me.Label1)
        Me.PanelBienvenida.Location = New System.Drawing.Point(383, 52)
        Me.PanelBienvenida.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelBienvenida.Name = "PanelBienvenida"
        Me.PanelBienvenida.Size = New System.Drawing.Size(256, 407)
        Me.PanelBienvenida.TabIndex = 403
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Consolas", 40.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 407)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione un Grupo de Reportes para Empezar"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelVENTAS
        '
        Me.PanelVENTAS.Controls.Add(Me.ReportViewer1)
        Me.PanelVENTAS.Controls.Add(Me.Panel4)
        Me.PanelVENTAS.Controls.Add(Me.FlowLayoutPanel1)
        Me.PanelVENTAS.Location = New System.Drawing.Point(813, 43)
        Me.PanelVENTAS.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelVENTAS.Name = "PanelVENTAS"
        Me.PanelVENTAS.Size = New System.Drawing.Size(921, 492)
        Me.PanelVENTAS.TabIndex = 404
        '
        'ReportViewer1
        '
        Me.ReportViewer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 187)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(921, 305)
        Me.ReportViewer1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PanelEmpleado)
        Me.Panel4.Controls.Add(Me.btnHoy)
        Me.Panel4.Controls.Add(Me.chekFiltros)
        Me.Panel4.Controls.Add(Me.PanelFiltros)
        Me.Panel4.Controls.Add(Me.MenuStrip6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(0, 53)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(921, 134)
        Me.Panel4.TabIndex = 1
        '
        'PanelEmpleado
        '
        Me.PanelEmpleado.Controls.Add(Me.txtEmpleado)
        Me.PanelEmpleado.Controls.Add(Me.Label4)
        Me.PanelEmpleado.Location = New System.Drawing.Point(6, 72)
        Me.PanelEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelEmpleado.Name = "PanelEmpleado"
        Me.PanelEmpleado.Size = New System.Drawing.Size(491, 51)
        Me.PanelEmpleado.TabIndex = 616
        Me.PanelEmpleado.Visible = False
        '
        'txtEmpleado
        '
        Me.txtEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.txtEmpleado.Font = New System.Drawing.Font("Consolas", 14.0!)
        Me.txtEmpleado.FormattingEnabled = True
        Me.txtEmpleado.Location = New System.Drawing.Point(112, 9)
        Me.txtEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(376, 30)
        Me.txtEmpleado.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 14.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(4, 13)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 22)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Empleado:"
        '
        'btnHoy
        '
        Me.btnHoy.BackColor = System.Drawing.Color.Transparent
        Me.btnHoy.FlatAppearance.BorderSize = 0
        Me.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHoy.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHoy.ForeColor = System.Drawing.Color.DimGray
        Me.btnHoy.Location = New System.Drawing.Point(0, 20)
        Me.btnHoy.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHoy.Name = "btnHoy"
        Me.btnHoy.Size = New System.Drawing.Size(155, 41)
        Me.btnHoy.TabIndex = 615
        Me.btnHoy.Text = "Hasta HOY"
        Me.btnHoy.UseVisualStyleBackColor = False
        '
        'chekFiltros
        '
        Me.chekFiltros.AutoSize = True
        Me.chekFiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.chekFiltros.Location = New System.Drawing.Point(183, 36)
        Me.chekFiltros.Margin = New System.Windows.Forms.Padding(4)
        Me.chekFiltros.Name = "chekFiltros"
        Me.chekFiltros.Size = New System.Drawing.Size(15, 14)
        Me.chekFiltros.TabIndex = 613
        Me.chekFiltros.UseVisualStyleBackColor = True
        '
        'PanelFiltros
        '
        Me.PanelFiltros.BackColor = System.Drawing.Color.White
        Me.PanelFiltros.Controls.Add(Me.TXTFF)
        Me.PanelFiltros.Controls.Add(Me.TXTFI)
        Me.PanelFiltros.Controls.Add(Me.Label2)
        Me.PanelFiltros.Controls.Add(Me.Label3)
        Me.PanelFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.PanelFiltros.Location = New System.Drawing.Point(313, 15)
        Me.PanelFiltros.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelFiltros.Name = "PanelFiltros"
        Me.PanelFiltros.Size = New System.Drawing.Size(469, 51)
        Me.PanelFiltros.TabIndex = 611
        Me.PanelFiltros.Visible = False
        '
        'TXTFF
        '
        Me.TXTFF.Font = New System.Drawing.Font("Consolas", 14.0!)
        Me.TXTFF.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TXTFF.Location = New System.Drawing.Point(288, 11)
        Me.TXTFF.Margin = New System.Windows.Forms.Padding(4)
        Me.TXTFF.Name = "TXTFF"
        Me.TXTFF.Size = New System.Drawing.Size(141, 29)
        Me.TXTFF.TabIndex = 2
        Me.TXTFF.Value = New Date(2020, 6, 2, 0, 0, 0, 0)
        '
        'TXTFI
        '
        Me.TXTFI.Font = New System.Drawing.Font("Consolas", 14.0!)
        Me.TXTFI.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TXTFI.Location = New System.Drawing.Point(68, 10)
        Me.TXTFI.Margin = New System.Windows.Forms.Padding(4)
        Me.TXTFI.Name = "TXTFI"
        Me.TXTFI.Size = New System.Drawing.Size(137, 29)
        Me.TXTFI.TabIndex = 2
        Me.TXTFI.Value = New Date(2020, 6, 2, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label2.Location = New System.Drawing.Point(213, 14)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label3.Location = New System.Drawing.Point(4, 14)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 22)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Desde:"
        '
        'MenuStrip6
        '
        Me.MenuStrip6.AutoSize = False
        Me.MenuStrip6.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip6.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TFILTROS})
        Me.MenuStrip6.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip6.Location = New System.Drawing.Point(192, 25)
        Me.MenuStrip6.Name = "MenuStrip6"
        Me.MenuStrip6.ShowItemToolTips = True
        Me.MenuStrip6.Size = New System.Drawing.Size(121, 32)
        Me.MenuStrip6.TabIndex = 612
        Me.MenuStrip6.Text = "MenuStrip6"
        '
        'TFILTROS
        '
        Me.TFILTROS.BackColor = System.Drawing.Color.Transparent
        Me.TFILTROS.Checked = True
        Me.TFILTROS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TFILTROS.Font = New System.Drawing.Font("Consolas", 14.0!, System.Drawing.FontStyle.Bold)
        Me.TFILTROS.ForeColor = System.Drawing.Color.DimGray
        Me.TFILTROS.Image = CType(resources.GetObject("TFILTROS.Image"), System.Drawing.Image)
        Me.TFILTROS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TFILTROS.Name = "TFILTROS"
        Me.TFILTROS.Size = New System.Drawing.Size(108, 28)
        Me.TFILTROS.Text = "Filtros"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(921, 53)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnResumenVentas)
        Me.Panel2.Controls.Add(Me.PResumenVentas)
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(240, 48)
        Me.Panel2.TabIndex = 405
        '
        'btnResumenVentas
        '
        Me.btnResumenVentas.BackColor = System.Drawing.Color.Transparent
        Me.btnResumenVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnResumenVentas.FlatAppearance.BorderSize = 0
        Me.btnResumenVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResumenVentas.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResumenVentas.ForeColor = System.Drawing.Color.DimGray
        Me.btnResumenVentas.Location = New System.Drawing.Point(0, 0)
        Me.btnResumenVentas.Margin = New System.Windows.Forms.Padding(4)
        Me.btnResumenVentas.Name = "btnResumenVentas"
        Me.btnResumenVentas.Size = New System.Drawing.Size(240, 44)
        Me.btnResumenVentas.TabIndex = 614
        Me.btnResumenVentas.Text = "Resumen de Ventas"
        Me.btnResumenVentas.UseVisualStyleBackColor = False
        '
        'PResumenVentas
        '
        Me.PResumenVentas.BackColor = System.Drawing.Color.OrangeRed
        Me.PResumenVentas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PResumenVentas.ForeColor = System.Drawing.Color.OrangeRed
        Me.PResumenVentas.Location = New System.Drawing.Point(0, 44)
        Me.PResumenVentas.Margin = New System.Windows.Forms.Padding(4)
        Me.PResumenVentas.Name = "PResumenVentas"
        Me.PResumenVentas.Size = New System.Drawing.Size(240, 4)
        Me.PResumenVentas.TabIndex = 0
        Me.PResumenVentas.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnEmpleado)
        Me.Panel3.Controls.Add(Me.PVentasPorempleado)
        Me.Panel3.Location = New System.Drawing.Point(252, 4)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(287, 48)
        Me.Panel3.TabIndex = 618
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.Color.Transparent
        Me.btnEmpleado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEmpleado.FlatAppearance.BorderSize = 0
        Me.btnEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmpleado.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.Color.DimGray
        Me.btnEmpleado.Location = New System.Drawing.Point(0, 0)
        Me.btnEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(287, 44)
        Me.btnEmpleado.TabIndex = 615
        Me.btnEmpleado.Text = "Ventas por Empleado"
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'PVentasPorempleado
        '
        Me.PVentasPorempleado.BackColor = System.Drawing.Color.OrangeRed
        Me.PVentasPorempleado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PVentasPorempleado.Location = New System.Drawing.Point(0, 44)
        Me.PVentasPorempleado.Margin = New System.Windows.Forms.Padding(4)
        Me.PVentasPorempleado.Name = "PVentasPorempleado"
        Me.PVentasPorempleado.Size = New System.Drawing.Size(287, 4)
        Me.PVentasPorempleado.TabIndex = 0
        Me.PVentasPorempleado.Visible = False
        '
        'PanelPorCobrarPagar
        '
        Me.PanelPorCobrarPagar.Controls.Add(Me.ReportViewer2)
        Me.PanelPorCobrarPagar.Location = New System.Drawing.Point(307, 32)
        Me.PanelPorCobrarPagar.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelPorCobrarPagar.Name = "PanelPorCobrarPagar"
        Me.PanelPorCobrarPagar.Size = New System.Drawing.Size(379, 41)
        Me.PanelPorCobrarPagar.TabIndex = 405
        Me.PanelPorCobrarPagar.Visible = False
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(379, 41)
        Me.ReportViewer2.TabIndex = 0
        '
        'PanelProductos
        '
        Me.PanelProductos.Controls.Add(Me.ReportViewer3)
        Me.PanelProductos.Controls.Add(Me.FlowLayoutPanel2)
        Me.PanelProductos.Location = New System.Drawing.Point(265, 119)
        Me.PanelProductos.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelProductos.Name = "PanelProductos"
        Me.PanelProductos.Size = New System.Drawing.Size(809, 292)
        Me.PanelProductos.TabIndex = 405
        Me.PanelProductos.Visible = False
        '
        'ReportViewer3
        '
        Me.ReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer3.Location = New System.Drawing.Point(0, 53)
        Me.ReportViewer3.Name = "ReportViewer3"
        Me.ReportViewer3.Size = New System.Drawing.Size(809, 239)
        Me.ReportViewer3.TabIndex = 2
        Me.ReportViewer3.Visible = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel5)
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel7)
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel9)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(809, 53)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Button4)
        Me.Panel5.Controls.Add(Me.PInventarios)
        Me.Panel5.Location = New System.Drawing.Point(4, 4)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(240, 48)
        Me.Panel5.TabIndex = 405
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(0, 0)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(240, 44)
        Me.Button4.TabIndex = 614
        Me.Button4.Text = "Inventario"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'PInventarios
        '
        Me.PInventarios.BackColor = System.Drawing.Color.OrangeRed
        Me.PInventarios.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PInventarios.Location = New System.Drawing.Point(0, 44)
        Me.PInventarios.Margin = New System.Windows.Forms.Padding(4)
        Me.PInventarios.Name = "PInventarios"
        Me.PInventarios.Size = New System.Drawing.Size(240, 4)
        Me.PInventarios.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Button6)
        Me.Panel7.Controls.Add(Me.Pvencidos)
        Me.Panel7.Location = New System.Drawing.Point(252, 4)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(240, 48)
        Me.Panel7.TabIndex = 618
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Transparent
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Black
        Me.Button6.Location = New System.Drawing.Point(0, 0)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(240, 44)
        Me.Button6.TabIndex = 615
        Me.Button6.Text = "Productos Vencidos"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Pvencidos
        '
        Me.Pvencidos.BackColor = System.Drawing.Color.OrangeRed
        Me.Pvencidos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pvencidos.Location = New System.Drawing.Point(0, 44)
        Me.Pvencidos.Margin = New System.Windows.Forms.Padding(4)
        Me.Pvencidos.Name = "Pvencidos"
        Me.Pvencidos.Size = New System.Drawing.Size(240, 4)
        Me.Pvencidos.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Button7)
        Me.Panel9.Controls.Add(Me.PStockBajo)
        Me.Panel9.Location = New System.Drawing.Point(500, 4)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(240, 48)
        Me.Panel9.TabIndex = 619
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Black
        Me.Button7.Location = New System.Drawing.Point(0, 0)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(240, 44)
        Me.Button7.TabIndex = 615
        Me.Button7.Text = "Stock Bajo"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'PStockBajo
        '
        Me.PStockBajo.BackColor = System.Drawing.Color.OrangeRed
        Me.PStockBajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PStockBajo.Location = New System.Drawing.Point(0, 44)
        Me.PStockBajo.Margin = New System.Windows.Forms.Padding(4)
        Me.PStockBajo.Name = "PStockBajo"
        Me.PStockBajo.Size = New System.Drawing.Size(240, 4)
        Me.PStockBajo.TabIndex = 0
        '
        'MENU_dE_REPORTES_OI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1567, 559)
        Me.Controls.Add(Me.PanelVENTAS)
        Me.Controls.Add(Me.PanelProductos)
        Me.Controls.Add(Me.PanelPorCobrarPagar)
        Me.Controls.Add(Me.PanelBienvenida)
        Me.Controls.Add(Me.Panel72)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MENU_dE_REPORTES_OI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel72.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBienvenida.ResumeLayout(False)
        Me.PanelVENTAS.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.PanelEmpleado.ResumeLayout(False)
        Me.PanelEmpleado.PerformLayout()
        Me.PanelFiltros.ResumeLayout(False)
        Me.PanelFiltros.PerformLayout()
        Me.MenuStrip6.ResumeLayout(False)
        Me.MenuStrip6.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.PanelPorCobrarPagar.ResumeLayout(False)
        Me.PanelProductos.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmMOSTRAR As System.Windows.Forms.Timer
    Friend WithEvents tmOCULTAR As System.Windows.Forms.Timer
    Friend WithEvents Panel72 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label66 As Label
    Friend WithEvents PanelBienvenida As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnVentas As Button
    Friend WithEvents PanelVENTAS As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnResumenVentas As Button
    Friend WithEvents btnEmpleado As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents chekFiltros As CheckBox
    Friend WithEvents PanelFiltros As Panel
    Friend WithEvents TXTFF As DateTimePicker
    Friend WithEvents TXTFI As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents MenuStrip6 As MenuStrip
    Friend WithEvents TFILTROS As ToolStripMenuItem
    Friend WithEvents btnHoy As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PResumenVentas As Panel
    Friend WithEvents PanelEmpleado As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEmpleado As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PVentasPorempleado As Panel
    Friend WithEvents BtnPagar As Button
    Friend WithEvents btnCobrar As Button
    Friend WithEvents BtnProductos As Button
    Friend WithEvents PanelPorCobrarPagar As Panel
    Friend WithEvents PanelProductos As Panel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents PInventarios As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Button6 As Button
    Friend WithEvents Pvencidos As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Button7 As Button
    Friend WithEvents PStockBajo As Panel
    Friend WithEvents ReportViewer1 As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents ReportViewer2 As Telerik.ReportViewer.WinForms.ReportViewer
    Friend WithEvents ReportViewer3 As Telerik.ReportViewer.WinForms.ReportViewer
End Class
