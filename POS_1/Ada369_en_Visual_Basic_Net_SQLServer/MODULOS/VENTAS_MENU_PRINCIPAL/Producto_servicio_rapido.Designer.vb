<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Producto_servicio_rapido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Producto_servicio_rapido))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.datalistadoventas_nuevasok = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcosto = New System.Windows.Forms.TextBox()
        Me.txtidventa = New System.Windows.Forms.Label()
        Me.txtventagenerada = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btnborrarderecha = New System.Windows.Forms.Button()
        Me.btnborrartodo = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.lblIdSerial = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.datalistadoventas_nuevasok, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(488, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Producto/ Servicio  RAPIDO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripcion:"
        '
        'txtdescripcion
        '
        Me.txtdescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtdescripcion.Location = New System.Drawing.Point(12, 74)
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(468, 26)
        Me.txtdescripcion.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(235, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Cantidad:"
        '
        'txtcantidad
        '
        Me.txtcantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtcantidad.Location = New System.Drawing.Point(235, 132)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(119, 26)
        Me.txtcantidad.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(235, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Precio de venta:"
        '
        'txtprecio
        '
        Me.txtprecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtprecio.Location = New System.Drawing.Point(235, 184)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(119, 26)
        Me.txtprecio.TabIndex = 3
        '
        'datalistadoventas_nuevasok
        '
        Me.datalistadoventas_nuevasok.AllowUserToAddRows = False
        Me.datalistadoventas_nuevasok.AllowUserToDeleteRows = False
        Me.datalistadoventas_nuevasok.AllowUserToResizeRows = False
        Me.datalistadoventas_nuevasok.BackgroundColor = System.Drawing.Color.White
        Me.datalistadoventas_nuevasok.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.datalistadoventas_nuevasok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datalistadoventas_nuevasok.ColumnHeadersVisible = False
        Me.datalistadoventas_nuevasok.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn4})
        Me.datalistadoventas_nuevasok.EnableHeadersVisualStyles = False
        Me.datalistadoventas_nuevasok.Location = New System.Drawing.Point(653, 239)
        Me.datalistadoventas_nuevasok.Name = "datalistadoventas_nuevasok"
        Me.datalistadoventas_nuevasok.ReadOnly = True
        Me.datalistadoventas_nuevasok.RowHeadersVisible = False
        Me.datalistadoventas_nuevasok.RowHeadersWidth = 9
        Me.datalistadoventas_nuevasok.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datalistadoventas_nuevasok.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.datalistadoventas_nuevasok.RowTemplate.Height = 40
        Me.datalistadoventas_nuevasok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datalistadoventas_nuevasok.Size = New System.Drawing.Size(390, 98)
        Me.datalistadoventas_nuevasok.TabIndex = 551
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "Marcar"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "Marcar"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.ReadOnly = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(235, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Costo:"
        '
        'txtcosto
        '
        Me.txtcosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtcosto.Location = New System.Drawing.Point(235, 236)
        Me.txtcosto.Name = "txtcosto"
        Me.txtcosto.Size = New System.Drawing.Size(119, 26)
        Me.txtcosto.TabIndex = 4
        '
        'txtidventa
        '
        Me.txtidventa.AutoSize = True
        Me.txtidventa.Location = New System.Drawing.Point(13, 14)
        Me.txtidventa.Name = "txtidventa"
        Me.txtidventa.Size = New System.Drawing.Size(77, 20)
        Me.txtidventa.TabIndex = 1
        Me.txtidventa.Text = "Cantidad:"
        '
        'txtventagenerada
        '
        Me.txtventagenerada.AutoSize = True
        Me.txtventagenerada.Location = New System.Drawing.Point(27, 16)
        Me.txtventagenerada.Name = "txtventagenerada"
        Me.txtventagenerada.Size = New System.Drawing.Size(77, 20)
        Me.txtventagenerada.TabIndex = 1
        Me.txtventagenerada.Text = "Cantidad:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtventagenerada)
        Me.Panel1.Controls.Add(Me.txtidventa)
        Me.Panel1.Location = New System.Drawing.Point(633, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(17, 10)
        Me.Panel1.TabIndex = 552
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.Transparent
        Me.btn0.BackgroundImage = CType(resources.GetObject("btn0.BackgroundImage"), System.Drawing.Image)
        Me.btn0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn0.FlatAppearance.BorderSize = 0
        Me.btn0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn0.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn0.ForeColor = System.Drawing.Color.White
        Me.btn0.Location = New System.Drawing.Point(15, 322)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(65, 66)
        Me.btn0.TabIndex = 609
        Me.btn0.Text = "0"
        Me.btn0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btnborrarderecha
        '
        Me.btnborrarderecha.BackColor = System.Drawing.Color.Transparent
        Me.btnborrarderecha.BackgroundImage = CType(resources.GetObject("btnborrarderecha.BackgroundImage"), System.Drawing.Image)
        Me.btnborrarderecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnborrarderecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnborrarderecha.FlatAppearance.BorderSize = 0
        Me.btnborrarderecha.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnborrarderecha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnborrarderecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnborrarderecha.Font = New System.Drawing.Font("Calibri", 21.0!, System.Drawing.FontStyle.Bold)
        Me.btnborrarderecha.ForeColor = System.Drawing.Color.White
        Me.btnborrarderecha.Location = New System.Drawing.Point(86, 322)
        Me.btnborrarderecha.Name = "btnborrarderecha"
        Me.btnborrarderecha.Size = New System.Drawing.Size(65, 66)
        Me.btnborrarderecha.TabIndex = 608
        Me.btnborrarderecha.Text = ","
        Me.btnborrarderecha.UseVisualStyleBackColor = False
        '
        'btnborrartodo
        '
        Me.btnborrartodo.BackColor = System.Drawing.Color.Transparent
        Me.btnborrartodo.BackgroundImage = CType(resources.GetObject("btnborrartodo.BackgroundImage"), System.Drawing.Image)
        Me.btnborrartodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnborrartodo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnborrartodo.FlatAppearance.BorderSize = 0
        Me.btnborrartodo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnborrartodo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnborrartodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnborrartodo.Font = New System.Drawing.Font("Calibri", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnborrartodo.ForeColor = System.Drawing.Color.White
        Me.btnborrartodo.Location = New System.Drawing.Point(157, 322)
        Me.btnborrartodo.Name = "btnborrartodo"
        Me.btnborrartodo.Size = New System.Drawing.Size(65, 66)
        Me.btnborrartodo.TabIndex = 607
        Me.btnborrartodo.Text = "Borrar"
        Me.btnborrartodo.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn1)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn2)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn3)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn4)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn5)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn6)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn7)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn8)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn9)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(12, 106)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(217, 214)
        Me.FlowLayoutPanel2.TabIndex = 606
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.Transparent
        Me.btn1.BackgroundImage = CType(resources.GetObject("btn1.BackgroundImage"), System.Drawing.Image)
        Me.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn1.FlatAppearance.BorderSize = 0
        Me.btn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn1.ForeColor = System.Drawing.Color.White
        Me.btn1.Location = New System.Drawing.Point(3, 3)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(65, 65)
        Me.btn1.TabIndex = 40
        Me.btn1.TabStop = False
        Me.btn1.Text = "1"
        Me.btn1.UseCompatibleTextRendering = True
        Me.btn1.UseMnemonic = False
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.Transparent
        Me.btn2.BackgroundImage = CType(resources.GetObject("btn2.BackgroundImage"), System.Drawing.Image)
        Me.btn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn2.FlatAppearance.BorderSize = 0
        Me.btn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn2.ForeColor = System.Drawing.Color.White
        Me.btn2.Location = New System.Drawing.Point(74, 3)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(65, 65)
        Me.btn2.TabIndex = 41
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.Transparent
        Me.btn3.BackgroundImage = CType(resources.GetObject("btn3.BackgroundImage"), System.Drawing.Image)
        Me.btn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn3.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn3.FlatAppearance.BorderSize = 0
        Me.btn3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn3.ForeColor = System.Drawing.Color.White
        Me.btn3.Location = New System.Drawing.Point(145, 3)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(65, 65)
        Me.btn3.TabIndex = 42
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.Transparent
        Me.btn4.BackgroundImage = CType(resources.GetObject("btn4.BackgroundImage"), System.Drawing.Image)
        Me.btn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn4.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn4.FlatAppearance.BorderSize = 0
        Me.btn4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn4.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn4.ForeColor = System.Drawing.Color.White
        Me.btn4.Location = New System.Drawing.Point(3, 74)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(65, 65)
        Me.btn4.TabIndex = 35
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.Transparent
        Me.btn5.BackgroundImage = CType(resources.GetObject("btn5.BackgroundImage"), System.Drawing.Image)
        Me.btn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn5.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn5.FlatAppearance.BorderSize = 0
        Me.btn5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn5.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn5.ForeColor = System.Drawing.Color.White
        Me.btn5.Location = New System.Drawing.Point(74, 74)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(65, 65)
        Me.btn5.TabIndex = 36
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.Transparent
        Me.btn6.BackgroundImage = CType(resources.GetObject("btn6.BackgroundImage"), System.Drawing.Image)
        Me.btn6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn6.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn6.FlatAppearance.BorderSize = 0
        Me.btn6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn6.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn6.ForeColor = System.Drawing.Color.White
        Me.btn6.Location = New System.Drawing.Point(145, 74)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(65, 65)
        Me.btn6.TabIndex = 37
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.Transparent
        Me.btn7.BackgroundImage = CType(resources.GetObject("btn7.BackgroundImage"), System.Drawing.Image)
        Me.btn7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn7.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn7.FlatAppearance.BorderSize = 0
        Me.btn7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn7.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn7.ForeColor = System.Drawing.Color.White
        Me.btn7.Location = New System.Drawing.Point(3, 145)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(65, 65)
        Me.btn7.TabIndex = 30
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.Transparent
        Me.btn8.BackgroundImage = CType(resources.GetObject("btn8.BackgroundImage"), System.Drawing.Image)
        Me.btn8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn8.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn8.FlatAppearance.BorderSize = 0
        Me.btn8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn8.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn8.ForeColor = System.Drawing.Color.White
        Me.btn8.Location = New System.Drawing.Point(74, 145)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(65, 65)
        Me.btn8.TabIndex = 31
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.Transparent
        Me.btn9.BackgroundImage = CType(resources.GetObject("btn9.BackgroundImage"), System.Drawing.Image)
        Me.btn9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn9.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn9.FlatAppearance.BorderSize = 0
        Me.btn9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn9.Font = New System.Drawing.Font("Calibri", 35.0!, System.Drawing.FontStyle.Bold)
        Me.btn9.ForeColor = System.Drawing.Color.White
        Me.btn9.Location = New System.Drawing.Point(145, 145)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(65, 65)
        Me.btn9.TabIndex = 32
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'lblIdSerial
        '
        Me.lblIdSerial.AutoSize = True
        Me.lblIdSerial.Location = New System.Drawing.Point(660, 141)
        Me.lblIdSerial.Name = "lblIdSerial"
        Me.lblIdSerial.Size = New System.Drawing.Size(96, 20)
        Me.lblIdSerial.TabIndex = 1
        Me.lblIdSerial.Text = "Descripcion:"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Ada369_en_Visual_Basic_Net_SQLServer.My.Resources.Resources.verde
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(232, 268)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 52)
        Me.Button2.TabIndex = 612
        Me.Button2.Text = "Aceptar (Enter)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Ada369_en_Visual_Basic_Net_SQLServer.My.Resources.Resources.negro
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(232, 326)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 51)
        Me.Button1.TabIndex = 613
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Producto_servicio_rapido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 400)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn0)
        Me.Controls.Add(Me.btnborrarderecha)
        Me.Controls.Add(Me.btnborrartodo)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.datalistadoventas_nuevasok)
        Me.Controls.Add(Me.txtcosto)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtdescripcion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblIdSerial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Producto_servicio_rapido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.datalistadoventas_nuevasok, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents datalistadoventas_nuevasok As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcosto As System.Windows.Forms.TextBox
    Friend WithEvents txtidventa As System.Windows.Forms.Label
    Friend WithEvents txtventagenerada As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn0 As Button
    Friend WithEvents btnborrarderecha As Button
    Friend WithEvents btnborrartodo As Button
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents btn1 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents lblIdSerial As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
