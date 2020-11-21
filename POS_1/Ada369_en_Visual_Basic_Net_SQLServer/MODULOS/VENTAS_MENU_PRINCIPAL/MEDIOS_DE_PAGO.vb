

Imports System.Data.SqlClient

Imports System.Drawing.Printing

Imports Telerik.Reporting.Processing

Imports System.Management
Imports Telerik.Reporting.Drawing

Public Class MEDIOS_DE_PAGO
    Dim DOCUMENTO As PrintDocument
    Private MisDiscos As New ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard")
    Private DiscInfo As New ManagementObject
    Dim indicador_de_tipo_de_pago_string As String
    Dim vuelto As Double = 0
    Dim moneda As String
    Dim SECUENCIA1 As Boolean = True
    Dim SECUENCIA2 As Boolean = True
    Dim SECUENCIA3 As Boolean = True
    Dim indicador As String
    Dim Id_otros_medios_De_pago As Integer
    Dim INDICAR_DE_FOCO As Integer
    Dim total As Double
    Dim contador_de_items_ventas As Double
    Dim idcaja As Integer
    'Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)

    '    mpanel.Visible = False

    'End Sub

    'Private Sub MEDIOS_DE_PAGO_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0
    '        If txtcredito2.Text = "" Then txtcredito2.Text = 0
    '        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0
    '        If TXTVUELTO.Text = "" Then TXTVUELTO.Text = 0

    '        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0
    '        If txtcredito2.Text = "" Then txtcredito2.Text = 0
    '        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0
    '        If TXTVUELTO.Text = "" Then TXTVUELTO.Text = 0

    '        actualizar_serie_mas_uno()
    '        If txttipo.Text = "EFECTIVO" And TXTVUELTO.Text >= 0 Then

    '            ''CONFIRMAR_VENTA()

    '            MASCARA1.Hide()
    '            VENTAS_MENU_PRINCIPAL.Timer3.Start()

    '            Close()
    '        ElseIf txttipo.Text = "EFECTIVO" And TXTVUELTO.Text < 0 Then
    '            Dim result As DialogResult
    '            result = MessageBox.Show("El vuelto no puede ser menor a el Total pagado ", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If

    '        If txttipo.Text = "CREDITO" And datalistadoclientes.Visible = False Then
    '            ''CONFIRMAR_VENTA()
    '            MASCARA1.Hide()
    '            VENTAS_MENU_PRINCIPAL.Timer3.Start()

    '            Close()
    '        ElseIf txttipo.Text = "CREDITO" And datalistadoclientes.Visible = True Then
    '            Dim result As DialogResult
    '            result = MessageBox.Show("Seleccione un Cliente para Activar Pago a Credito", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '        End If

    '        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0
    '        If txtcredito2.Text = "" Then txtcredito2.Text = 0
    '        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0

    '        If txttipo.Text = "MIXTO" And txtrestante.Text = 0 Then

    '            If txtcredito2.Text * 1 >= 0 And datalistadoclientes2.Visible = True Then

    '                'CONFIRMAR_VENTA()
    '                MASCARA1.Hide()
    '                VENTAS_MENU_PRINCIPAL.Timer3.Start()

    '                Close()
    '            Else
    '                Dim result As DialogResult
    '                result = MessageBox.Show("Seleccione un Cliente para Activar Pago a Credito", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '            End If

    '        ElseIf txttipo.Text = "MIXTO" And txtrestante.Text <> 0 Then
    '            Dim result As DialogResult
    '            result = MessageBox.Show("La cantidad Restante tiene que ser 0 ", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '        End If

    '    End If
    'End Sub


    Sub MOSTRAR_cajas_por_serial()

        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("MOSTRAR_cajas_por_serial", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@serial", lblIDSERIAL.Text)

            da.Fill(dt)
            DATALISTADOcajas.DataSource = dt
            Cerrar()

        Catch ex As Exception ': MessageBox.Show(ex.Message)
        End Try


    End Sub
    Sub validar_tipos_de_comprobantes()
        buscar_Tipo_de_documentos_para_insertar_en_ventas()
        Try
            txtserie.Text = dtComprobantes.SelectedCells.Item(3).Value
            txtnumerofin.Text = dtComprobantes.SelectedCells.Item(5).Value + 1
            lblCantidad_de_numeros.Text = dtComprobantes.SelectedCells.Item(4).Value
            lblCorrelativoconCeros.Text = ceros(txtnumerofin.Text, lblCantidad_de_numeros.Text)
        Catch ex As Exception

        End Try
    End Sub
    'Sub fechasprueba()
    '    Dim fecha As String
    '    Dim fecha1 As String
    '    Dim dia As String
    '    Dim count As Integer
    '    fecha = "01/06/2019"
    '    fecha1 = "30/06/2019"
    '    'fecha1 = DateAdd("D", 1, fecha1)
    '    While Format(fecha, "short date") <> Format(fecha1, "short date")
    '        dia = Weekday(fecha)
    '        If dia <> "6" Then
    '            count = count + 1
    '        End If
    '        'fecha = DateAdd("D", 1, fecha)
    '    End While
    '    Label1.Text = count
    'End Sub

    Sub mostrar_moneda_de_empresa()


        Dim com As New SqlCommand("Select Moneda From Empresa", conexion)

        Try
            abrir()
            moneda = (com.ExecuteScalar())
            Cerrar()


        Catch ex As Exception
            moneda = ""
        End Try


    End Sub

    Private Sub MEDIOS_DE_PAGO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        MOSTRAR_comprobante_serializado_POR_DEFECTO()
        mostrar_moneda_de_empresa()
        validar_tipos_de_comprobantes()
        txtnumerofin.BackColor = Color.White
        LBLidVenta.Text = VENTAS_MENU_PRINCIPAL.txtidventa.Text
        TXTVUELTO.Text = 0
        txtrestante.Text = 0
        TXTTOTAL.Text = moneda & " " & VENTAS_MENU_PRINCIPAL.txt_total_suma.Text
        txt_total_suma.Text = VENTAS_MENU_PRINCIPAL.txt_total_suma.Text
        total = VENTAS_MENU_PRINCIPAL.txt_total_suma.Text
        txtclientesolicitabnte3.Text = ""
        lblidcliente.Text = 0
        PANEL_CLIENTE_FACTURA.Visible = True
        datalistadoclientes3.Visible = True
        PanelImpresionvistaprevia.Visible = False
        TXTVUELTO.Text = 0.0
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())
        MOSTRAR_cajas_por_serial()
        Try
            txtImpresora.Text = DATALISTADOcajas.SelectedCells.Item(6).Value
        Catch ex As Exception
        End Try
        obtener_id_caja()
        cargar_impresoras_del_equipo()
        validar_tipos_de_comprobantes()
        calcular_restante()
        contador_de_items_ventas = VENTAS_MENU_PRINCIPAL.datalistadoDetalleVenta.RowCount
        Panel31.Location = New Point((Width - Panel31.Width) / 2, (Height - Panel31.Height) / 2)
        txtefectivo2.Focus()
    End Sub
    Sub obtener_id_caja()
        Try
            abrir()
            Dim da = New SqlCommand("mostrar_cajas_por_Serial_de_DiscoDuro", conexion)
            da.CommandType = 4
            da.Parameters.AddWithValue("@Serial", lblIDSERIAL.Text)
            idcaja = da.ExecuteScalar()
            Cerrar()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        PanelMedio_de_pago.Visible = True
        txtMedio_de_pago_config.Clear()
        GuardarRegistro.Visible = True
        Modificarregistro.Visible = False
        indicador = "INSERTAR"

    End Sub

    Sub insertar_editar_ELIMINAR_Otros_medios_De_pago()
        Try
            Id_otros_medios_De_pago = datalistadoOTROS_MEDIOS_DE_PAGO.SelectedCells.Item(1).Value
        Catch ex As Exception
            Id_otros_medios_De_pago = 0
        End Try
        Dim CMD As SqlCommand
        Try
            abrir()

            CMD = New SqlCommand("insertar_editar_ELIMINAR_buscar_Otros_medios_De_pago", conexion)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.AddWithValue("@Medio_de_pago", txtMedio_de_pago_config.Text)
            CMD.Parameters.AddWithValue("@Indicador", indicador)
            CMD.Parameters.AddWithValue("@Id_otro_medio_de_pago", Id_otros_medios_De_pago)
            CMD.ExecuteNonQuery()

            Cerrar()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GuardarRegistro_Click(sender As Object, e As EventArgs)

    End Sub
    Sub buscar_medio_De_pago()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("insertar_editar_ELIMINAR_buscar_Otros_medios_De_pago", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Medio_de_pago", txtMedio_de_pago_config.Text)

            da.SelectCommand.Parameters.AddWithValue("@Indicador", indicador)
            da.SelectCommand.Parameters.AddWithValue("@Id_otro_medio_de_pago", Id_otros_medios_De_pago)

            da.Fill(dt)
            datalistadoOTROS_MEDIOS_DE_PAGO.DataSource = dt
            datalistadoOTROS_MEDIOS_DE_PAGO.Columns(2).Visible = False
            datalistadoOTROS_MEDIOS_DE_PAGO.Columns(3).Width = 320

            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Multilinea(datalistadoOTROS_MEDIOS_DE_PAGO)


    End Sub
    Private Sub txtbuscador_de_otros_mediosdepago_TextChanged(sender As Object, e As EventArgs)
        If PanelMedio_de_pago.Visible = False Then
            indicador = "BUSCAR"

            buscar_medio_De_pago()
        End If
    End Sub

    Private Sub GuardarRegistro_Click_1(sender As Object, e As EventArgs) Handles GuardarRegistro.Click
        insertar_editar_ELIMINAR_Otros_medios_De_pago()
        PanelMedio_de_pago.Visible = False
        lblOtro_medio_De_pago.Text = txtMedio_de_pago_config.Text
        datalistadoOTROS_MEDIOS_DE_PAGO.Visible = False
        BtnCambiar_medio_de_pago.Visible = True
    End Sub

    Private Sub Panel19_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub datalistadoOTROS_MEDIOS_DE_PAGO_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoOTROS_MEDIOS_DE_PAGO.CellContentClick

    End Sub

    Private Sub datalistadoOTROS_MEDIOS_DE_PAGO_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoOTROS_MEDIOS_DE_PAGO.CellClick
        Try
            lblOtro_medio_De_pago.Text = datalistadoOTROS_MEDIOS_DE_PAGO.SelectedCells.Item(3).Value
            datalistadoOTROS_MEDIOS_DE_PAGO.Visible = False
            BtnCambiar_medio_de_pago.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tver_Click(sender As Object, e As EventArgs) Handles tver.Click
        indicador = "BUSCAR"

        datalistadoOTROS_MEDIOS_DE_PAGO.Visible = True

        buscar_medio_De_pago()

    End Sub


    Sub MOSTRAR_comprobante_serializado_POR_DEFECTO()

        Dim importe As String
        Dim com As New SqlCommand("select Id_tipodoc  from Serializacion WHERE Por_defecto='SI'", conexion)
        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
            lblComprobante.Text = importe

        Catch ex As Exception
            lblComprobante.Text = 0
        End Try
        FlowLayoutPanel3.Controls.Clear()
        dibujarCOMPROBANTES()
    End Sub
    Sub dibujarCOMPROBANTES()
        FlowLayoutPanel3.Controls.Clear()

        Try
            abrir()
            Dim query As String = "select Id_tipodoc  from Serializacion where destino='VENTAS'"
            Dim cmd As New SqlCommand(query, conexion)
            Dim rdr As SqlDataReader = cmd.ExecuteReader()
            While rdr.Read()
                Dim b As New Button()
                b.Text = rdr("Id_tipodoc").ToString()
                b.Name = rdr("Id_tipodoc").ToString()
                b.Size = New System.Drawing.Size(191, 60)
                b.BackColor = Color.FromArgb(75, 70, 71)
                b.Font = New System.Drawing.Font(10, 13)
                b.FlatStyle = FlatStyle.Flat
                b.ForeColor = Color.WhiteSmoke
                FlowLayoutPanel3.Controls.Add(b)
                If b.Text = lblComprobante.Text Then
                    b.Visible = False


                End If

                AddHandler b.Click, AddressOf miEvento

            End While
            Cerrar()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub miEvento(ByVal sender As System.Object, ByVal e As EventArgs)
        lblComprobante.Text = DirectCast(sender, Button).Text
        dibujarCOMPROBANTES()
        validar_tipos_de_comprobantes()
        identificar_el_tipo_de_pago()

        If lblComprobante.Text = "FACTURA" And txttipo.Text = "CREDITO" Then
            'lblindicador_de_factura_1.Text = "Cliente: (Obligatorio)"
            'lblindicador_de_factura_1.ForeColor = Color.Red
            PANEL_CLIENTE_FACTURA.Visible = False

        End If



        If lblComprobante.Text = "FACTURA" And txttipo.Text = "EFECTIVO" Then
            PANEL_CLIENTE_FACTURA.Visible = True
            lblindicador_de_factura_1.Text = "Cliente: (Obligatorio)"
            lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192)

        ElseIf lblComprobante.Text <> "FACTURA" And txttipo.Text = "EFECTIVO" Then
            PANEL_CLIENTE_FACTURA.Visible = True
            lblindicador_de_factura_1.Text = "Cliente: (Opcional)"
            lblindicador_de_factura_1.ForeColor = Color.DimGray
        End If



        If lblComprobante.Text = "FACTURA" And txttipo.Text = "TARJETA" Then
            PANEL_CLIENTE_FACTURA.Visible = True
            lblindicador_de_factura_1.Text = "Cliente: (Obligatorio)"
            lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192)

        ElseIf lblComprobante.Text <> "FACTURA" And txttipo.Text = "TARJETA" Then
            PANEL_CLIENTE_FACTURA.Visible = True
            lblindicador_de_factura_1.Text = "Cliente: (Opcional)"
            lblindicador_de_factura_1.ForeColor = Color.DimGray
        End If

        'If lblComprobante.Text = "FACTURA" And txttipo.Text = "MIXTO" And datalistadoclientes2.Visible = True Then
        '    PANEL_CLIENTE_FACTURA.Visible = True
        '    lblindicador_de_factura_1.Text = "Cliente: (Obligatorio)"
        '    lblindicador_de_factura_1.ForeColor = Color.Red
        'ElseIf lblComprobante.Text = "FACTURA" And txttipo.Text = "MIXTO" And datalistadoclientes2.Visible = False Then
        '    PANEL_CLIENTE_FACTURA.Visible = False
        'ElseIf lblComprobante.Text <> "FACTURA" And txttipo.Text = "MIXTO" And datalistadoclientes2.Visible = True Then
        '    PANEL_CLIENTE_FACTURA.Visible = True
        '    lblindicador_de_factura_1.Text = "Cliente: (Opcional)"
        '    lblindicador_de_factura_1.ForeColor = Color.DimGray
        'ElseIf lblComprobante.Text <> "FACTURA" And txttipo.Text = "MIXTO" And datalistadoclientes2.Visible = False Then
        '    PANEL_CLIENTE_FACTURA.Visible = False
        'End If

    End Sub

    Sub cargar_impresoras_del_equipo()
        txtImpresora.Items.Clear()
        For I = 0 To PrinterSettings.InstalledPrinters.Count - 1
            txtImpresora.Items.Add(PrinterSettings.InstalledPrinters.Item(I))
        Next
        txtImpresora.Items.Add("Ninguna")
    End Sub


    Public Sub NumerosyDecimal(ByVal CajaTexto As System.Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        ElseIf e.KeyChar = "," Then
            e.Handled = False

        Else
            e.Handled = True

        End If


    End Sub
    'Private Sub TXTPAGOCON_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then

    '        e.KeyChar =
    '            Threading.Thread.CurrentThread.
    '            CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

    '    End If
    '    NumerosyDecimal(TXTPAGOCON, e)
    'End Sub

    'Private Sub TXTPAGOCON_TextChanged(sender As Object, e As EventArgs)
    '    Try

    '        TXTVUELTO.Text = TXTPAGOCON.Text * 1 - VENTAS_MENU_PRINCIPAL.txt_total_suma.Text * 1
    '        If TXTVUELTO.Text < 0 Then
    '            PADVER.Visible = True
    '            TXTADVER.Visible = True

    '        End If
    '        If TXTVUELTO.Text >= 0 Then
    '            PADVER.Visible = False
    '            TXTADVER.Visible = False

    '        End If
    '        If TXTVUELTO.Text = "" Then
    '            TXTVUELTO.Text = 0.0
    '        End If
    '    Catch ex As Exception
    '        TXTVUELTO.Text = 0.0
    '    End Try
    'End Sub

    'Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
    '    txtmonto_tarjeta.Text = VENTAS_MENU_PRINCIPAL.txt_total_suma.Text
    '    pefectivo.Visible = False
    '    ptarjeta.Visible = True
    '    pcredito.Visible = False
    '    mpanel.Visible = False
    '    befectivo.BackColor = Color.White
    '    btarjeta.BackColor = Color.PaleGreen
    '    bcredito.BackColor = Color.White
    '    bmixto.BackColor = Color.White

    'End Sub
    Sub buscar_clientes3()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("buscar_cliente_POR_nombre_PARA_VENTAS_todos", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@letra", txtclientesolicitabnte3.Text)
            da.Fill(dt)
            datalistadoclientes3.DataSource = dt
            datalistadoclientes3.Columns(2).Visible = False
            datalistadoclientes3.Columns(3).Visible = False
            datalistadoclientes3.Columns(4).Visible = False
            datalistadoclientes3.Columns(5).Visible = False
            datalistadoclientes3.Columns(1).Width = 420
            Cerrar()
        Catch ex As Exception
            '
        End Try


    End Sub
    'Sub buscar_clientes()
    '    Dim dt As New DataTable
    '    Dim da As SqlDataAdapter
    '    Try
    '        abrir()
    '        da = New SqlDataAdapter("buscar_cliente_POR_nombre_PARA_VENTAS_todos", conexion)
    '        da.SelectCommand.CommandType = 4
    '        da.SelectCommand.Parameters.AddWithValue("@letra", txtclientesolicitabnte.Text)
    '        da.Fill(dt)
    '        datalistadoclientes.DataSource = dt
    '        datalistadoclientes.Columns(2).Visible = False
    '        datalistadoclientes.Columns(3).Visible = False
    '        datalistadoclientes.Columns(4).Visible = False
    '        datalistadoclientes.Columns(5).Visible = False
    '        datalistadoclientes.Columns(1).Width = 420
    '        Cerrar()
    '    Catch ex As Exception
    '        '
    '    End Try


    'End Sub
    Sub buscarclientes2()
        Dim dt2 As New DataTable
        Dim da2 As SqlDataAdapter
        Try
            abrir()
            da2 = New SqlDataAdapter("buscar_cliente_POR_nombre_PARA_VENTAS_todos", conexion)
            da2.SelectCommand.CommandType = 4
            da2.SelectCommand.Parameters.AddWithValue("@letra", txtclientesolicitabnte2.Text)
            da2.Fill(dt2)
            datalistadoclientes2.DataSource = dt2
            datalistadoclientes2.Columns(2).Visible = False
            datalistadoclientes2.Columns(3).Visible = False
            datalistadoclientes2.Columns(4).Visible = False
            datalistadoclientes2.Columns(5).Visible = False
            datalistadoclientes2.Columns(1).Width = 420
            Cerrar()
        Catch ex As Exception
            '
        End Try


    End Sub
    'Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs)

    '    pefectivo.Visible = False
    '    ptarjeta.Visible = False
    '    pcredito.Visible = True
    '    mpanel.Visible = False
    '    befectivo.BackColor = Color.White
    '    btarjeta.BackColor = Color.White
    '    bcredito.BackColor = Color.PaleGreen
    '    bmixto.BackColor = Color.White

    'End Sub

    'Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs)
    '    MASCARA1.Show()
    '    Registro_clientes.ShowDialog()

    'End Sub

    'Private Sub txtclientesolicitabnte_Click(sender As Object, e As EventArgs)
    '    datalistadoclientes.Visible = True
    '    txtclientesolicitabnte.Text = ""
    'End Sub

    'Private Sub txtclientesolicitabnte_TextChanged(sender As Object, e As EventArgs)
    '    buscar_clientes()
    '    If txtclientesolicitabnte.Text = "" Then
    '        datalistadoclientes.Visible = True

    '    End If
    'End Sub

    'Private Sub datalistadoclientes_CellClick(sender As Object, e As DataGridViewCellEventArgs)
    '    Try



    '        txtclientesolicitabnte.Text = datalistadoclientes.SelectedCells.Item(1).Value
    '        datalistadoclientes.Visible = False
    '        LBL_DIRECCION.Text = datalistadoclientes.SelectedCells.Item(3).Value
    '        LBL_CELULAR.Text = datalistadoclientes.SelectedCells.Item(4).Value
    '        txtruc.Text = datalistadoclientes.SelectedCells.Item(5).Value
    '        lblidcliente_creditos.Text = datalistadoclientes.SelectedCells.Item(2).Value

    '    Catch ex As Exception

    '    End Try

    'End Sub


    Private Sub txtclientesolicitabnte2_Click(sender As Object, e As EventArgs) Handles txtclientesolicitabnte2.Click
        datalistadoclientes2.Visible = True
        txtclientesolicitabnte2.Text = ""
    End Sub

    Private Sub txtclientesolicitabnte2_TextChanged(sender As Object, e As EventArgs) Handles txtclientesolicitabnte2.TextChanged



        buscarclientes2()
        datalistadoclientes2.Visible = True

    End Sub

    Private Sub datalistadoclientes2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoclientes2.CellClick
        Try



            txtclientesolicitabnte2.Text = datalistadoclientes2.SelectedCells.Item(1).Value
            datalistadoclientes2.Visible = False

            lblidcliente.Text = datalistadoclientes2.SelectedCells.Item(2).Value
            If txtcredito2.Text = "" Then txtcredito2.Text = 0
            If txtcredito2.Text = 0 Then
                txtfecha_de_pago.Visible = False
                Label21.Visible = False
            Else
                txtfecha_de_pago.Visible = True
                Label21.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub


    'Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs)
    '    txtrestante.Text = VENTAS_MENU_PRINCIPAL.txt_total_suma.Text
    '    pefectivo.Visible = False
    '    ptarjeta.Visible = False
    '    pcredito.Visible = False
    '    mpanel.Visible = True
    '    txtefectivo2.Text = 0
    '    txtcredito2.Text = 0
    '    txttarjeta2.Text = 0
    '    befectivo.BackColor = Color.White
    '    btarjeta.BackColor = Color.White
    '    bcredito.BackColor = Color.White
    '    bmixto.BackColor = Color.PaleGreen
    'End Sub

    Private Sub txtefectivo2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtefectivo2.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then

            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(txtefectivo2, e)
    End Sub
    Sub calcular_restante()
        Try
            Dim efectivo As Double
            Dim tarjeta As Double
            Dim credito As Double


            If txtefectivo2.Text = "" Then efectivo = 0 Else efectivo = txtefectivo2.Text
            If txtcredito2.Text = "" Then credito = 0 Else credito = txtcredito2.Text
            If txttarjeta2.Text = "" Then tarjeta = 0 Else tarjeta = txttarjeta2.Text

            If txtefectivo2.Text = "0.00" Then efectivo = 0
            If txtcredito2.Text = "0.00" Then credito = 0
            If txttarjeta2.Text = "0.00" Then tarjeta = 0

            If txtefectivo2.Text = "." Then efectivo = 0
            If txtcredito2.Text = "." Then tarjeta = 0
            If txttarjeta2.Text = "." Then credito = 0

            Try
                If (efectivo > total) Then
                    If (tarjeta = 0) And (credito = 0) Then
                        efectivo_calculado.Text = total
                        vuelto = efectivo - (total)
                        TXTVUELTO.Text = (vuelto)
                        txtrestante.Text = 0
                        efectivo_calculado.Text = efectivo - total

                    End If

                End If
                If (efectivo > total) Or (tarjeta > 0) Or (credito > 0) Then
                    efectivo_calculado.Text = total - (tarjeta + credito)
                    vuelto = efectivo - efectivo_calculado.Text * 1
                    TXTVUELTO.Text = (vuelto)
                    txtrestante.Text = total - (efectivo_calculado.Text + tarjeta + credito)
                End If
                If (efectivo <= total) Then
                    If ((tarjeta >= 0) Or (credito >= 0)) Then
                        vuelto = 0
                        txtrestante.Text = total - efectivo - tarjeta - credito
                        efectivo_calculado.Text = efectivo

                    End If

                End If

                If (efectivo = 0) Then
                    If (tarjeta = 0) And (credito = 0) Then
                        txtrestante.Text = total
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try



        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try


    End Sub
    Sub calcular_vuelto()
        Try

            vuelto = txtefectivo2.Text * 1 - txt_total_suma.Text * 1
            TXTVUELTO.Text = vuelto
            TXTVUELTO.Text = Format(CType(TXTVUELTO.Text, Decimal), "##0.00")
        Catch ex As Exception
            vuelto = 0
            TXTVUELTO.Text = 0
        End Try
    End Sub
    Private Sub txtefectivo2_TextChanged(sender As Object, e As EventArgs) Handles txtefectivo2.TextChanged

        calcular_restante()
        'calcular_vuelto()
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        PanelRegistroCliente1.Visible = True
        PanelRegistroCliente1.Dock = DockStyle.Fill
        PanelRegistroCliente1.BringToFront()
        PanelGuardado_de_datos.Visible = False
        PanelRegistroCliente2.Location = New Point((Width - PanelRegistroCliente2.Width) / 2, (Height - PanelRegistroCliente2.Height) / 2)

        txtnombrecliente.Text = ""
        txtdirecciondefactura.Text = ""
        txtrucdefactura.Text = ""
        txtcelular.Text = ""
        txtnombrecliente.Focus()

    End Sub

    Private Sub txtcredito2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcredito2.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then

            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(txtcredito2, e)
    End Sub

    Private Sub txtcredito2_TextChanged(sender As Object, e As EventArgs) Handles txtcredito2.TextChanged


        'Try
        '    txtrestante.Text = VENTAS_MENU_PRINCIPAL.txt_total_suma.Text * 1 - txtefectivo2.Text * 1 - txtcredito2.Text * 1 - txttarjeta2.Text * 1
        '    txtrestante.Text = Format(CType(txtrestante.Text, Decimal), "##0.0")
        'Catch ex As Exception

        'End Try
        calcular_restante()
        hacer_visible_panel_de_clientes_a_credito()

    End Sub
    Sub hacer_visible_panel_de_clientes_a_credito()
        Try
            Dim textocredito As Double
            If txtcredito2.Text = "." Then textocredito = 0
            If txtcredito2.Text = "" Then
                textocredito = 0
            Else
                textocredito = txtcredito2.Text
            End If

            If textocredito > 0 Then
                pmixtocredito.Visible = True
                txtclientesolicitabnte2.Clear()
                buscarclientes2()
                datalistadoclientes2.Visible = True
            Else
                pmixtocredito.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub txttarjeta2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttarjeta2.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then

            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(txttarjeta2, e)
    End Sub

    Private Sub txttarjeta2_TextChanged(sender As Object, e As EventArgs) Handles txttarjeta2.TextChanged

        calcular_restante()

    End Sub

    'Private Sub TXTCOMPROBANTE_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    buscar_Tipo_de_documentos_para_insertar_en_ventas()

    '    Try
    '        txtserie.Text = dtComprobantes.SelectedCells.Item(3).Value
    '        txtnumerofin.Text = dtComprobantes.SelectedCells.Item(5).Value
    '        lblCorrelativoconCeros.Text = ceros(txtnumerofin.Text, txtnumerofin.Text)
    '    Catch ex As Exception

    '    End Try

    'End Sub
    Sub buscar_Tipo_de_documentos_para_insertar_en_ventas()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("buscar_Tipo_de_documentos_para_insertar_en_ventas", conexion)
            da.SelectCommand.CommandType = 4


            da.SelectCommand.Parameters.AddWithValue("@letra", lblComprobante.Text)

            da.Fill(dt)
            dtComprobantes.DataSource = dt
            Cerrar()


        Catch ex As Exception
        End Try

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtefectivo2_Click(sender As Object, e As EventArgs) Handles txtefectivo2.Click
        calcular_restante()
        INDICAR_DE_FOCO = 1
        If txtrestante.Text = 0 Then
            txtefectivo2.Text = ""
        Else
            txtefectivo2.Text = txtrestante.Text

        End If


    End Sub

    Private Sub txttarjeta2_Click(sender As Object, e As EventArgs) Handles txttarjeta2.Click
        calcular_restante()
        INDICAR_DE_FOCO = 2
        If txtrestante.Text = 0 Then
            txttarjeta2.Text = ""
        Else
            txttarjeta2.Text = txtrestante.Text
        End If
    End Sub

    Private Sub txtcredito2_Click(sender As Object, e As EventArgs) Handles txtcredito2.Click
        calcular_restante()
        INDICAR_DE_FOCO = 3
        If txtrestante.Text = 0 Then

            txtcredito2.Text = ""

        Else

            txtcredito2.Text = txtrestante.Text
            hacer_visible_panel_de_clientes_a_credito()
        End If

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "1"

        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "1"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "1"
        End If




    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "2"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "2"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "2"
        End If
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "3"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "3"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "3"
        End If
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "4"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "4"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "4"
        End If
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "5"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "5"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "5"
        End If
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "6"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "6"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "6"
        End If
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "7"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "7"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "7"
        End If
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "8"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "8"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "8"
        End If
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "9"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "9"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "9"
        End If
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "0"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "0"
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Text = txtcredito2.Text & "0"
        End If
    End Sub

    Private Sub btnborrarderecha_Click(sender As Object, e As EventArgs) Handles btnborrarderecha.Click
        If INDICAR_DE_FOCO = 1 Then
            If SECUENCIA1 = True Then
                txtefectivo2.Text = txtefectivo2.Text & "."
                SECUENCIA1 = False
            Else
                Return

            End If

        ElseIf INDICAR_DE_FOCO = 2 Then

            If SECUENCIA2 = True Then
                txttarjeta2.Text = txttarjeta2.Text & "."
                SECUENCIA2 = False
            Else
                Return

            End If

        ElseIf INDICAR_DE_FOCO = 3 Then

            If SECUENCIA3 = True Then
                txtcredito2.Text = txtcredito2.Text & "."
                SECUENCIA3 = False
            Else
                Return

            End If

        End If

    End Sub

    Private Sub btnborrartodo_Click(sender As Object, e As EventArgs) Handles btnborrartodo.Click
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Clear()
            SECUENCIA1 = True
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Clear()
            SECUENCIA2 = True
        ElseIf INDICAR_DE_FOCO = 3 Then
            txtcredito2.Clear()
            SECUENCIA3 = True
        End If
    End Sub





    Private Sub txtclientesolicitabnte3_TextChanged(sender As Object, e As EventArgs) Handles txtclientesolicitabnte3.TextChanged

        If txtclientesolicitabnte3.Text <> "" Then
            buscar_clientes3()
            datalistadoclientes3.Visible = True
        Else
            datalistadoclientes3.Visible = True

        End If
    End Sub

    Private Sub datalistadoclientes3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoclientes3.CellClick
        Try


            txtclientesolicitabnte3.Text = datalistadoclientes3.SelectedCells.Item(1).Value
            datalistadoclientes3.Visible = False
            lbldireccion.Text = datalistadoclientes3.SelectedCells.Item(3).Value
            lblcelular.Text = datalistadoclientes3.SelectedCells.Item(4).Value
            lblruc.Text = datalistadoclientes3.SelectedCells.Item(5).Value
            lblidcliente.Text = datalistadoclientes3.SelectedCells.Item(2).Value

        Catch ex As Exception

        End Try
    End Sub
    Sub MOSTRAR_cliente_standar()

        Dim importe As String
        Dim com As New SqlCommand("select*from clientes where Cliente='NEUTRO'", conexion)
        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
            lblidcliente.Text = importe

        Catch ex As Exception
            lblidcliente.Text = 0
        End Try
    End Sub
    Sub CONVERTIR_TOTAL_A_LETRAS()
        Dim numero As Integer
        numero = Int(txt_total_suma.Text)
        TXTTOTAL_STRING.Text = Num2Text(numero)
        Dim a() As String
        a = Split(txt_total_suma.Text, ".")
        txttotaldecimal.Text = a(1)
        txtnumeroconvertidoenletra.Text = TXTTOTAL_STRING.Text & " CON " & txttotaldecimal.Text & "/100 "

    End Sub

    Sub CONFIRMAR_VENTA_FECTIVO()


        Try
            abrir()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Confirmar_venta", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idventa", VENTAS_MENU_PRINCIPAL.txtidventa.Text)
            cmd.Parameters.AddWithValue("@montototal", total)
            cmd.Parameters.AddWithValue("@IGV", VENTAS_MENU_PRINCIPAL.lbligv.Text)
            cmd.Parameters.AddWithValue("@Saldo", TXTVUELTO.Text)

            cmd.Parameters.AddWithValue("@Tipo_de_pago", txttipo.Text)

            cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO")
            cmd.Parameters.AddWithValue("@idcliente ", lblidcliente.Text)


            cmd.Parameters.AddWithValue("@Id_series", lblComprobante.Text)
            cmd.Parameters.AddWithValue("@Numero_de_doc", (txtserie.Text & "-" & lblCorrelativoconCeros.Text))
            cmd.Parameters.AddWithValue("@fecha_venta", Now())
            cmd.Parameters.AddWithValue("@ACCION", "VENTA")

            cmd.Parameters.AddWithValue("@Fecha_de_pago", "PAGO AL CONTADO")
            cmd.Parameters.AddWithValue("@Pago_con", txtefectivo2.Text)
            cmd.Parameters.AddWithValue("@Referencia_tarjeta", "NULO")
            cmd.Parameters.AddWithValue("@Vuelto", TXTVUELTO.Text)
            cmd.Parameters.AddWithValue("@Efectivo", efectivo_calculado.Text)
            cmd.Parameters.AddWithValue("@Credito", txtcredito2.Text)
            cmd.Parameters.AddWithValue("@Tarjeta", txttarjeta2.Text)
            cmd.ExecuteNonQuery()
            Cerrar()
            lblProcede.Text = "PROCEDE"
            aumentar_monto_a_cliente()

        Catch ex As Exception : MessageBox.Show(ex.Message)
            lblProcede.Text = "NO PROCEDE"
        End Try



    End Sub
    'Sub CONFIRMAR_VENTA_TARJETA()


    '    Try
    '        Dim cmd As New SqlCommand
    '        abrir()
    '        cmd = New SqlCommand("actualizartotal_venta", conexion)
    '        cmd.CommandType = 4
    '        cmd.Parameters.AddWithValue("@idventa", VENTAS_MENU_PRINCIPAL.txtidventa.Text)
    '        cmd.Parameters.AddWithValue("@montototal", VENTAS_MENU_PRINCIPAL.txt_total_suma.Text)
    '        cmd.Parameters.AddWithValue("@IGV", VENTAS_MENU_PRINCIPAL.lbligv.Text)
    '        cmd.Parameters.AddWithValue("@Saldo", 0)

    '        cmd.Parameters.AddWithValue("@Tipo_de_pago", txttipo.Text)

    '        cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO")
    '        cmd.Parameters.AddWithValue("@idcliente ", lblidcliente.Text)


    '        cmd.Parameters.AddWithValue("@Id_series", lblComprobante.Text)
    '        cmd.Parameters.AddWithValue("@Numero_de_doc", (txtserie.Text & "-" & lblCorrelativoconCeros.Text))
    '        cmd.Parameters.AddWithValue("@fecha_venta", Now())
    '        cmd.Parameters.AddWithValue("@ACCION", "VENTA")

    '        cmd.Parameters.AddWithValue("@Fecha_de_pago", "PAGO CON TARJETA")
    '        cmd.Parameters.AddWithValue("@Pago_con", 0)
    '        cmd.Parameters.AddWithValue("@Referencia_tarjeta", txtReferencia.Text)

    '        cmd.ExecuteNonQuery()
    '        Cerrar()
    '        lblProcede.Text = "PROCEDE"


    '    Catch ex As Exception : MessageBox.Show(ex.Message)
    '        lblProcede.Text = "NO PROCEDE"
    '    End Try



    'End Sub
    'Sub CONFIRMAR_VENTA_MIXTO()



    '    Try
    '        Dim cmd As New SqlCommand
    '        abrir()
    '        cmd = New SqlCommand("actualizartotal_venta", conexion)
    '        cmd.CommandType = 4
    '        cmd.Parameters.AddWithValue("@idventa", VENTAS_MENU_PRINCIPAL.txtidventa.Text)
    '        cmd.Parameters.AddWithValue("@montototal", VENTAS_MENU_PRINCIPAL.txt_total_suma.Text)
    '        cmd.Parameters.AddWithValue("@IGV", VENTAS_MENU_PRINCIPAL.lbligv.Text)
    '        cmd.Parameters.AddWithValue("@Saldo", txtcredito2.Text)

    '        cmd.Parameters.AddWithValue("@Tipo_de_pago", txttipo.Text)

    '        cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO")


    '        cmd.Parameters.AddWithValue("@idcliente ", lblidcliente.Text)


    '        cmd.Parameters.AddWithValue("@Id_series", lblComprobante.Text)
    '        cmd.Parameters.AddWithValue("@Numero_de_doc", (txtserie.Text & "-" & lblCorrelativoconCeros.Text))
    '        cmd.Parameters.AddWithValue("@fecha_venta", Now())
    '        cmd.Parameters.AddWithValue("@ACCION", "VENTA")

    '        cmd.Parameters.AddWithValue("@Fecha_de_pago", "PAGO MIXTO")
    '        cmd.Parameters.AddWithValue("@Pago_con", txtefectivo2.Text)
    '        cmd.Parameters.AddWithValue("@Referencia_tarjeta", "NULO")

    '        cmd.ExecuteNonQuery()
    '        Cerrar()
    '        lblProcede.Text = "PROCEDE"


    '    Catch ex As Exception : MessageBox.Show(ex.Message)
    '        lblProcede.Text = "NO PROCEDE"
    '    End Try



    'End Sub
    'Sub CONFIRMAR_VENTA_CREDITO()


    '    Try
    '        Dim cmd As New SqlCommand
    '        abrir()
    '        cmd = New SqlCommand("actualizartotal_venta", conexion)
    '        cmd.CommandType = 4
    '        cmd.Parameters.AddWithValue("@idventa", VENTAS_MENU_PRINCIPAL.txtidventa.Text)
    '        cmd.Parameters.AddWithValue("@montototal", VENTAS_MENU_PRINCIPAL.txt_total_suma.Text)
    '        cmd.Parameters.AddWithValue("@IGV", VENTAS_MENU_PRINCIPAL.lbligv.Text)
    '        cmd.Parameters.AddWithValue("@Saldo", TXTVUELTO.Text)

    '        cmd.Parameters.AddWithValue("@Tipo_de_pago", txttipo.Text)

    '        cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO")
    '        cmd.Parameters.AddWithValue("@idcliente ", lblidcliente_creditos.Text)


    '        cmd.Parameters.AddWithValue("@Id_series", lblComprobante.Text)
    '        cmd.Parameters.AddWithValue("@Numero_de_doc", (txtserie.Text & "-" & lblCorrelativoconCeros.Text))
    '        cmd.Parameters.AddWithValue("@fecha_venta", Now())
    '        cmd.Parameters.AddWithValue("@ACCION", "VENTA")

    '        cmd.Parameters.AddWithValue("@Fecha_de_pago", "CREDITO")
    '        cmd.Parameters.AddWithValue("@Pago_con", 0)
    '        cmd.Parameters.AddWithValue("@Referencia_tarjeta", "NULO")

    '        cmd.ExecuteNonQuery()
    '        Cerrar()
    '        lblProcede.Text = "PROCEDE"


    '    Catch ex As Exception : MessageBox.Show(ex.Message)
    '        lblProcede.Text = "NO PROCEDE"
    '    End Try



    'End Sub
    Sub aumentar_monto_a_cliente()
        If txtcredito2.Text > 0 Then
            Try
                Dim cmd As New SqlCommand

                abrir()
                cmd = New SqlCommand("aumentar_saldo_a_cliente", conexion)
                cmd.CommandType = 4


                cmd.Parameters.AddWithValue("@Saldo", txtcredito2.Text)
                cmd.Parameters.AddWithValue("@idcliente", lblidcliente.Text)
                'ElseIf txttipo.Text = "MIXTO" Then
                '    cmd.Parameters.AddWithValue("@Saldo", txtcredito2.Text)
                '    cmd.Parameters.AddWithValue("@idcliente", datalistadoclientes2.SelectedCells.Item(2).Value)




                cmd.ExecuteNonQuery()
                Cerrar()

            Catch ex As Exception : MessageBox.Show(ex.Message)
                '
            End Try
        End If
    End Sub
    Sub actualizar_serie_mas_uno()
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("actualizar_serializacion_mas_uno", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idserie", dtComprobantes.SelectedCells.Item(6).Value)
            cmd.Parameters.AddWithValue("@numerofin", txtnumerofin.Text)
            cmd.ExecuteNonQuery()
            Cerrar()
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub disminuir_stock_productos()
        Dim cmdaumentarstock As SqlCommand
        Try
            For Each row As DataGridViewRow In VENTAS_MENU_PRINCIPAL.datalistadoDetalleVenta.Rows

                Dim idproducto As Integer = Convert.ToInt32(row.Cells("Id_producto").Value)
                Dim cantidad As Decimal = Convert.ToDouble(row.Cells("Cant").Value)
                Try
                    abrir()

                    cmdaumentarstock = New SqlCommand("disminuir_stock", conexion)
                    cmdaumentarstock.CommandType = 4
                    cmdaumentarstock.Parameters.AddWithValue("@Id_presentacionfraccionada", idproducto)
                    cmdaumentarstock.Parameters.AddWithValue("@cantidad", cantidad)
                    cmdaumentarstock.ExecuteNonQuery()
                    Cerrar()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Sub mostrar_Ticket_lleno()
        Dim rptFREPORT2 As New Ticket_report()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        'If txtclientesolicitabnte3.Text = "" Then txtclientesolicitabnte3.Text = "Generico"
        Try
            abrir()
            daMA = New SqlDataAdapter("mostrar_ticket_impreso", conexion)
            daMA.SelectCommand.CommandType = 4
            daMA.SelectCommand.Parameters.AddWithValue("@idventa", LBLidVenta.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@total_en_letras", txtnumeroconvertidoenletra.Text)

            daMA.Fill(dtMA)
            Cerrar()
            rptFREPORT2 = New Ticket_report
            rptFREPORT2.Table1.DataSource = dtMA
            rptFREPORT2.DataSource = dtMA

            ReportViewer1.Report = rptFREPORT2
            Dim ancho As Unit = rptFREPORT2.PageSettings.PaperSize.Width
            Dim alto As Unit = rptFREPORT2.Table1.Size.Height
            rptFREPORT2.PageSettings.PaperSize = New SizeU(ancho, Unit.Cm(20) + Unit.Cm(0.6 * contador_de_items_ventas))
            ReportViewer1.RefreshReport()
            VENTAS_MENU_PRINCIPAL.lblEfectivo.Text = txtefectivo2.Text
            VENTAS_MENU_PRINCIPAL.lblVuelto.Text = TXTVUELTO.Text


        Catch ex As Exception
            '
        End Try
    End Sub

    Sub imprimir_directo()
        mostrar_Ticket_lleno()
        Try
            DOCUMENTO = New PrintDocument
            DOCUMENTO.PrinterSettings.PrinterName = txtImpresora.Text
            'DOCUMENTO.PrinterSettings.Copies = CInt(TextBoxCOPIAS.Text)
            If DOCUMENTO.PrinterSettings.IsValid Then
                Dim printerSettings As PrinterSettings = New PrinterSettings()
                printerSettings.PrinterName = txtImpresora.Text
                Dim reportProcessor As New ReportProcessor()
                reportProcessor.PrintReport(ReportViewer1.ReportSource, printerSettings)
            End If

            Dispose()
            VENTAS_MENU_PRINCIPAL.TimerLimpiar_para_venta_nueva.Start()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub editar_eleccion_de_impresora()

        Try
            Dim cmd As New SqlCommand

            abrir()
            cmd = New SqlCommand("editar_eleccion_impresoras", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idcaja", idcaja)
            cmd.Parameters.AddWithValue("@Impresora_Ticket", txtImpresora.Text)
            cmd.ExecuteNonQuery()
            Cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)



    End Sub
    Sub INSERTAR_KARDEX_SALIDA()
        Try
            Dim cmd As New SqlCommand
            For Each row As DataGridViewRow In VENTAS_MENU_PRINCIPAL.datalistadoDetalleVenta.Rows

                Dim Id_producto As Integer = Convert.ToInt32(row.Cells("Id_producto").Value)
                Dim cantidad As Decimal = Convert.ToDouble(row.Cells("Cant").Value)
                Dim STOCK As String = Convert.ToString(row.Cells("Stock").Value)
                If STOCK <> "Ilimitado" Then
                    abrir()

                    cmd = New SqlCommand("insertar_KARDEX_SALIDA", conexion)
                    cmd.CommandType = 4
                    cmd.Parameters.AddWithValue("@Fecha", Now())
                    cmd.Parameters.AddWithValue("@Motivo", "Venta #" & lblComprobante.Text & " " & lblCorrelativoconCeros.Text)
                    cmd.Parameters.AddWithValue("@Cantidad ", cantidad)

                    cmd.Parameters.AddWithValue("@Id_producto", Id_producto)
                    cmd.Parameters.AddWithValue("@Id_usuario", VENTAS_MENU_PRINCIPAL.id_usuario)
                    cmd.Parameters.AddWithValue("@Tipo", "SALIDA")
                    cmd.Parameters.AddWithValue("@Estado", "DESPACHO CONFIRMADO")
                    cmd.Parameters.AddWithValue("@Id_caja", VENTAS_MENU_PRINCIPAL.idcaja)
                    cmd.ExecuteNonQuery()

                    Cerrar()
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message + " " + ex.StackTrace)
        End Try
    End Sub
    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        MASCARA1.Show()
        MASCARA1.FormBorderStyle = FormBorderStyle.None
        Registro_clientes.ShowDialog()


    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If txtcredito2.Text = "" Then txtcredito2.Text = 0
        If txtcredito2.Text = "." Then txtcredito2.Text = 0

        If txtcredito2.Text > 0 Then
            txtclientesolicitabnte2.Clear()
            buscarclientes2()
        End If
        If lblComprobante.Text = "FACTURA" Then
            buscar_clientes3()
        End If

        Timer2.Stop()

    End Sub
    Sub completar_con_ceros_los_texbox_de_otros_medios_de_pago()
        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0
        If txtcredito2.Text = "" Then txtcredito2.Text = 0
        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0
        If TXTVUELTO.Text = "" Then TXTVUELTO.Text = 0
        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0
        If txtcredito2.Text = "" Then txtcredito2.Text = 0
        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0
        If TXTVUELTO.Text = "" Then TXTVUELTO.Text = 0

        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0
        If txtcredito2.Text = "" Then txtcredito2.Text = 0
        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0
    End Sub
    Sub procesar_venta_efectivo()
        actualizar_serie_mas_uno()
        validar_tipos_de_comprobantes()
        CONFIRMAR_VENTA_FECTIVO()

        If lblProcede.Text = "PROCEDE" Then
            disminuir_stock_productos()
            INSERTAR_KARDEX_SALIDA()
            validar_tipo_de_impresion()



        ElseIf lblProcede.Text = "NO PROCEDE" Then

        End If
    End Sub
    Sub vender_en_efectivo()
        If lblidcliente.Text = 0 Then
            MOSTRAR_cliente_standar()
        End If

        If lblComprobante.Text = "FACTURA" And lblidcliente.Text = 0 And txttipo.Text <> "CREDITO" Then
            MessageBox.Show("Seleccione un Cliente, para Facturas es Obligatorio", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf lblComprobante.Text = "FACTURA" And lblidcliente.Text <> 0 Then
            procesar_venta_efectivo()
        ElseIf lblComprobante.Text <> "FACTURA" And txttipo.Text <> "CREDITO" Then
            procesar_venta_efectivo()
        ElseIf lblComprobante.Text <> "FACTURA" And txttipo.Text = "CREDITO" Then
            procesar_venta_efectivo()
        End If



    End Sub
    'Sub vender_a_credito()
    '    lblrestante.Text = 0
    '    lblpagocon.Text = 0
    '    If datalistadoclientes3.Visible = True Then
    '        MessageBox.Show("Seleccione un Cliente, para Creditos es Obligatorio", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    ElseIf datalistadoclientes3.Visible = False
    '        CONFIRMAR_VENTA_CREDITO()
    '        If lblProcede.Text = "PROCEDE" Then
    '            actualizar_serie_mas_uno()
    '            disminuir_stock_productos()
    '            INSERTAR_KARDEX_SALIDA()
    '            aumentar_monto_a_cliente()

    '            VENTAS_MENU_PRINCIPAL.Timer3.Start()
    '            validar_tipo_de_impresion()
    '            Close()
    '        ElseIf lblProcede.Text = "NO PROCEDE" Then
    '            txtnumerofin.Focus()
    '            txtnumerofin.BackColor = Color.NavajoWhite
    '        End If

    '    End If

    'End Sub
    'Sub procesar_venta_mixto()
    '    If datalistadoclientes2.Visible = True Then
    '        MOSTRAR_cliente_standar()
    '    End If
    '    lblrestante.Text = txtefectivo2.Text
    '    lblpagocon.Text = 0
    '    CONFIRMAR_VENTA_MIXTO()
    '    If lblProcede.Text = "PROCEDE" Then
    '        actualizar_serie_mas_uno()
    '        disminuir_stock_productos()
    '        INSERTAR_KARDEX_SALIDA()
    '        If (txtcredito2.Text > 0) Then
    '            aumentar_monto_a_cliente()
    '        End If
    '        VENTAS_MENU_PRINCIPAL.Timer3.Start()
    '        validar_tipo_de_impresion()
    '        Close()
    '    ElseIf lblProcede.Text = "NO PROCEDE" Then
    '        txtnumerofin.Focus()
    '        txtnumerofin.BackColor = Color.NavajoWhite
    '    End If
    'End Sub
    'Sub venta_mixto()
    '    If txtcredito2.Text = "" Then txtcredito2.Text = 0
    '    If txtcredito2.Text > 0 Then

    '    End If

    '    If lblComprobante.Text = "FACTURA" And datalistadoclientes2.Visible = True Then
    '        MessageBox.Show("Seleccione un Cliente, para Facturas es Obligatorio", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    ElseIf lblComprobante.Text = "FACTURA" And datalistadoclientes2.Visible = False
    '        procesar_venta_mixto()
    '    ElseIf lblComprobante.Text <> "FACTURA" And txtcredito2.Text * 1 > 0 And datalistadoclientes2.Visible = True
    '        MessageBox.Show("Seleccione un Cliente, para Creditos es Obligatorio***", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '    ElseIf lblComprobante.Text <> "FACTURA" And txtcredito2.Text = 0
    '        procesar_venta_mixto()
    '    ElseIf lblComprobante.Text <> "FACTURA" And txtcredito2.Text * 1 > 0 And datalistadoclientes2.Visible = False
    '        procesar_venta_mixto()
    '    End If



    '    'If lblComprobante.Text = "FACTURA" And datalistadoclientes3.Visible = True Then
    '    '    MessageBox.Show("Seleccione un Cliente, para Facturas es Obligatorio", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    'ElseIf lblComprobante.Text = "FACTURA" And datalistadoclientes3.Visible = False
    '    '    procesar_venta_efectivo()
    '    'ElseIf lblComprobante.Text <> "FACTURA"
    '    '    If datalistadoclientes3.Visible = True Then
    '    '        MOSTRAR_cliente_standar()
    '    '    End If
    '    '    procesar_venta_efectivo()

    '    'End If
    'End Sub
    'Sub procesar_venta_tarjeta()
    '    lblpagocon.Text = TXTPAGOCON.Text
    '    CONFIRMAR_VENTA_TARJETA()

    '    If lblProcede.Text = "PROCEDE" Then
    '        actualizar_serie_mas_uno()
    '        disminuir_stock_productos()
    '        INSERTAR_KARDEX_SALIDA()

    '        VENTAS_MENU_PRINCIPAL.Timer3.Start()
    '        validar_tipo_de_impresion()

    '        Close()
    '    ElseIf lblProcede.Text = "NO PROCEDE" Then
    '        txtnumerofin.Focus()
    '        txtnumerofin.BackColor = Color.NavajoWhite
    '    End If
    'End Sub
    'Sub vender_con_tarjeta()

    '    If lblComprobante.Text = "FACTURA" And datalistadoclientes3.Visible = True Then
    '        MessageBox.Show("Seleccione un Cliente, para Facturas es Obligatorio", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    ElseIf lblComprobante.Text = "FACTURA" And datalistadoclientes3.Visible = False
    '        procesar_venta_tarjeta()
    '    ElseIf lblComprobante.Text <> "FACTURA"
    '        If datalistadoclientes3.Visible = True Then
    '            MOSTRAR_cliente_standar()
    '        End If
    '        procesar_venta_tarjeta()
    '    End If




    'End Sub

    'Dim indicador As String
    Sub mostrar_ticket_impreso_VISTA_PREVIA()
        PanelGuardado_de_datos.Visible = False
        PanelImpresionvistaprevia.Visible = True
        PanelImpresionvistaprevia.Dock = DockStyle.Fill
        PanelImpresionvistaprevia.BringToFront()
        Dim rptFREPORT2 As New Ticket_report()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try
            abrir()
            daMA = New SqlDataAdapter("mostrar_ticket_impreso", conexion)
            daMA.SelectCommand.CommandType = 4
            daMA.SelectCommand.Parameters.AddWithValue("@idventa", LBLidVenta.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@total_en_letras", txtnumeroconvertidoenletra.Text)

            daMA.Fill(dtMA)
            Cerrar()
            rptFREPORT2 = New Ticket_report
            rptFREPORT2.Table1.DataSource = dtMA
            rptFREPORT2.DataSource = dtMA

            ReportViewer3.Report = rptFREPORT2
            Dim ancho As Unit = rptFREPORT2.PageSettings.PaperSize.Width
            Dim alto As Unit = rptFREPORT2.Table1.Size.Height
            rptFREPORT2.PageSettings.PaperSize = New SizeU(ancho, Unit.Cm(20) + Unit.Cm(0.6 * contador_de_items_ventas))
            ReportViewer3.RefreshReport()
            'MessageBox.Show(rptFREPORT2.PageSettings.PaperSize.ToString())
            'MessageBox.Show(rptFREPORT2.TextBox12.Height.ToString())
            VENTAS_MENU_PRINCIPAL.lblEfectivo.Text = txtefectivo2.Text
            VENTAS_MENU_PRINCIPAL.lblVuelto.Text = TXTVUELTO.Text
            VENTAS_MENU_PRINCIPAL.TimerLimpiar_para_venta_nueva.Start()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub validar_tipo_de_impresion()
        If indicador = "VISTA PREVIA" Then
            mostrar_ticket_impreso_VISTA_PREVIA()
        ElseIf indicador = "DIRECTO" Then
            imprimir_directo()
        End If



    End Sub
    Sub INGRESAR_LOS_DATOS()

        CONVERTIR_TOTAL_A_LETRAS()
        completar_con_ceros_los_texbox_de_otros_medios_de_pago()

        Try

            If txttipo.Text = "EFECTIVO" And vuelto >= 0 Then
                vender_en_efectivo()
            ElseIf txttipo.Text = "EFECTIVO" And vuelto < 0 Then
                Dim result As DialogResult
                result = MessageBox.Show("El vuelto no puede ser menor a el Total pagado ", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If txttipo.Text = "CREDITO" And datalistadoclientes2.Visible = False Then
                vender_en_efectivo()
            ElseIf txttipo.Text = "CREDITO" And datalistadoclientes2.Visible = True Then
                Dim result As DialogResult
                result = MessageBox.Show("Seleccione un Cliente para Activar Pago a Credito", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


            If txttipo.Text = "TARJETA" Then
                vender_en_efectivo()
            End If


            If txttipo.Text = "MIXTO" Then
                vender_en_efectivo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace & " RESUMEN" & ex.Message)
        End Try



    End Sub
    Sub identificar_el_tipo_de_pago()

        Dim indicadorEfectivo As Integer = 4
        Dim indicadorCredito As Integer = 2
        Dim indicadorTarjeta As Integer = 3

        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0
        If txtcredito2.Text = "" Then txtcredito2.Text = 0
        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0

        If txtefectivo2.Text = "." Then txtefectivo2.Text = 0
        If txtcredito2.Text = "." Then txtcredito2.Text = 0
        If txttarjeta2.Text = "." Then txttarjeta2.Text = 0


        If txtefectivo2.Text = 0 Then
            indicadorEfectivo = 0
        End If
        If txtcredito2.Text = 0 Then
            indicadorCredito = 0
        End If
        If txttarjeta2.Text = 0 Then
            indicadorTarjeta = 0
        End If

        Dim calculo_identificacion As Integer

        calculo_identificacion = indicadorEfectivo + indicadorCredito + indicadorTarjeta

        If calculo_identificacion = 4 Then
            indicador_de_tipo_de_pago_string = "EFECTIVO"

        End If
        If calculo_identificacion = 2 Then
            indicador_de_tipo_de_pago_string = "CREDITO"
        End If
        If calculo_identificacion = 3 Then
            indicador_de_tipo_de_pago_string = "TARJETA"
        End If

        If calculo_identificacion > 4 Then
            indicador_de_tipo_de_pago_string = "MIXTO"
        End If
        txttipo.Text = indicador_de_tipo_de_pago_string
    End Sub

    Private Sub TGuardarSinImprimir_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Dim cmd As New SqlCommand
            If txtnombrecliente.Text <> "" Then
                If txtdirecciondefactura.Text = "" Then txtdirecciondefactura.Text = "-"
                If txtrucdefactura.Text = "" Then txtdirecciondefactura.Text = "0"
                If txtcelular.Text = "" Then txtdirecciondefactura.Text = "0"
                abrir()
                cmd = New SqlCommand("insertar_cliente", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@Nombre", txtnombrecliente.Text)
                cmd.Parameters.AddWithValue("@Direccion_para_factura", txtdirecciondefactura.Text)
                cmd.Parameters.AddWithValue("@Ruc ", txtrucdefactura.Text)
                cmd.Parameters.AddWithValue("@movil", txtcelular.Text)

                cmd.Parameters.AddWithValue("@Cliente ", "SI")
                cmd.Parameters.AddWithValue("@Proveedor", "NO")


                cmd.Parameters.AddWithValue("@Estado", "ACTIVO")
                cmd.Parameters.AddWithValue("@Saldo", 0)
                cmd.ExecuteNonQuery()
                Cerrar()
                PanelGuardado_de_datos.Visible = True
                PanelRegistroCliente1.Visible = False
                Timer2.Start()
                'VENTAS_MENU_PRINCIPAL.TimerhideMascara.Start()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub VOLVERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VOLVERToolStripMenuItem.Click
        PanelGuardado_de_datos.Visible = True
        PanelRegistroCliente1.Visible = False
    End Sub

    Private Sub datalistadoclientes2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoclientes2.CellContentClick

    End Sub

    Private Sub MEDIOS_DE_PAGO_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub txtefectivo2_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles txtefectivo2.GiveFeedback

    End Sub

    Private Sub datalistadoclientes3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoclientes3.CellContentClick

    End Sub

    Private Sub mpanel_Paint(sender As Object, e As PaintEventArgs) Handles mpanel.Paint

    End Sub

    Private Sub BtnCerrar_turno_Click(sender As Object, e As EventArgs) Handles BtnCerrar_turno.Click
        If txtrestante.Text = 0 Then
            If txtImpresora.Text <> "Ninguna" Then
                editar_eleccion_de_impresora()
                indicador = "DIRECTO"
                identificar_el_tipo_de_pago()
                INGRESAR_LOS_DATOS()
                Label1.BackColor = Color.WhiteSmoke
                Label1.ForeColor = Color.Gray
            Else
                Label1.BackColor = Color.Crimson
                Label1.ForeColor = Color.White
                MessageBox.Show("Seleccione una Impresora", "Impresora Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("El restante debe ser 0 ò el monto a pagar sobrepasa al Total", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtrestante.Text = 0 Then
            indicador = "VISTA PREVIA"
            identificar_el_tipo_de_pago()
            INGRESAR_LOS_DATOS()
        Else
            MessageBox.Show("El restante debe ser 0 ò el monto a pagar sobrepasa al Total", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    'Private Sub txtclientesolicitabnte3_TextChanged(sender As Object, e As EventArgs) Handles txtclientesolicitabnte3.TextChanged

    'End Sub

    'Private Sub datalistadoclientes3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoclientes3.CellContentClick

    'End Sub

    'Private Sub datalistadoclientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    'End Sub

    'Private Sub pcredito_Paint(sender As Object, e As PaintEventArgs)

    'End Sub

    'Private Sub FlowLayoutPanel4_Paint(sender As Object, e As PaintEventArgs)

    'End Sub

    'Private Sub btnFactura_Click(sender As Object, e As EventArgs)
    '    lblComprobante.Text = "FACTURA"
    '    validar_tipos_de_comprobantes()


    'End Sub

    'Private Sub BtnBoleta_Click(sender As Object, e As EventArgs)
    '    lblComprobante.Text = "BOLETA"
    '    validar_tipos_de_comprobantes()
    'End Sub

    'Private Sub BtnTicket_Click(sender As Object, e As EventArgs)
    '    lblComprobante.Text = "TICKET"
    '    validar_tipos_de_comprobantes()
    'End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Timer1.Stop()
    '    MOSTRAR_comprobante_serializado_POR_DEFECTO()
    '    btnGuardarImprimirdirecto.Text = "Guardar e Imprimir " & lblComprobante.Text & " (Enter)"
    '    validar_tipos_de_comprobantes()
    'End Sub

    'Private Sub datalistadoclientes2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoclientes2.CellContentClick

    'End Sub

    'Private Sub FlowLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel3.Paint

    'End Sub

End Class