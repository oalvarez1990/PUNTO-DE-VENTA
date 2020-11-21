Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization
Imports System.Management

Public Class productosOK
    Dim DTc As New DataTable
    Dim DTe As New DataTable
    Dim DTt As New DataTable
    Dim dtlinea As New DataTable
    Dim dttipo As New DataTable
    Dim panel As New PanelExtended
    Dim idgrupo As Integer
    Dim idproducto As Integer
    Private total_los_datos = New DataTable
    Private total As Integer = 0
    Private pagina As Integer = 0
    Private maximo_paginas As Integer = 0
    Private items_por_pagina As Integer = 10
    Dim Estado_control_de_lotes As String
    Dim manejo_de_lotes As String
    Dim Funcion As String

    Sub LISTARPRODUCTOSNUEVOS()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("MOSTRAR_PRODUCTOS_NUEVOS", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@DESCRIPCION", txtdescripcion.Text)
            da.Fill(dt)
            datalistadoProductosNuevos.DataSource = dt
            Cerrar()
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try

    End Sub



    Sub Listar()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_Producto1", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Desde", paginaInicio.Text)
            da.SelectCommand.Parameters.AddWithValue("@Hasta", paginaMaxima.Text)

            da.Fill(dt)
            datalistado.DataSource = dt
            Cerrar()
            datalistado.Columns(0).Width = 50
            datalistado.Columns(1).Width = 50
            datalistado.Columns(2).Visible = False
            datalistado.Columns(7).Visible = False
            datalistado.Columns(10).Visible = False
            datalistado.Columns(15).Visible = False
            datalistado.Columns(16).Visible = False
            Multilinea(datalistado)
            sumar_costo_de_inventario_CONTAR_PRODUCTOS()
            mostrar_paginados()
            txtbusca.Text = "Buscar..."
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try



    End Sub
    Sub mostrar_paginados()
        If lblcantidad_productos.Text <= datalistado.RowCount Then
            btn_Ultima.Visible = False
            btn_Primera.Visible = False
            FlowLayoutPanel1.Visible = False
        ElseIf lblcantidad_productos.Text > datalistado.RowCount
            btn_Ultima.Visible = True
            btn_Primera.Visible = True
            FlowLayoutPanel1.Visible = True
        End If

    End Sub
    Sub mostrar_descripcion_produco_sin_repetir()
        Dim dtDATALISTADO_AGREGANDO As New DataTable
        Dim daListarpresentacionesagregadas As SqlDataAdapter
        Try
            abrir()
            daListarpresentacionesagregadas = New SqlDataAdapter("mostrar_descripcion_produco_sin_repetir", conexion)
            daListarpresentacionesagregadas.SelectCommand.CommandType = 4


            daListarpresentacionesagregadas.SelectCommand.Parameters.AddWithValue("@buscar", txtdescripcion.Text)

            daListarpresentacionesagregadas.Fill(dtDATALISTADO_AGREGANDO)
            DATALISTADO_PRODUCTOS_OKA.DataSource = dtDATALISTADO_AGREGANDO
            DATALISTADO_PRODUCTOS_OKA.Columns(1).Width = 500

            Cerrar()
        Catch ex As Exception
        End Try

    End Sub
    'Sub mostrar_Empresa_igv()
    '    Dim dtDATALISTADO_AGREGANDO As New DataTable
    '    Dim daListarpresentacionesagregadas As SqlDataAdapter
    '    Try
    '        abrir()
    '        daListarpresentacionesagregadas = New SqlDataAdapter("mostrar_Empresa_igv", conexion)
    '        daListarpresentacionesagregadas.SelectCommand.CommandType = 4


    '        daListarpresentacionesagregadas.SelectCommand.Parameters.AddWithValue("@empresa", VENTAS_MENU_PRINCIPAL.LBLempresa.Text)

    '        daListarpresentacionesagregadas.Fill(dtDATALISTADO_AGREGANDO)
    '        datalistado_empresa.DataSource = dtDATALISTADO_AGREGANDO


    '        Cerrar()
    '    Catch ex As Exception
    '    End Try




    'End Sub


    Sub LIMPIAR()
        txtidproducto.Text = ""
        txtdescripcion.Text = ""
        txtcosto.Text = 0
        TXTPRECIODEVENTA2.Text = 0
        txtpreciomayoreo.Text = 0
        txtgrupo.Text = ""

        agranel.Checked = False
        txtstockminimo.Text = 0
        txtstock2.Text = 0
        lblEstadoCodigo.Text = "NUEVO"
    End Sub

    Sub buscar()

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("buscar_producto_por_descripcion", conexion)
        Try
            abrir()
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@letra", txtbusca.Text)
            'da.SelectCommand.Parameters.AddWithValue("@Desde", paginaInicio.Text)
            'da.SelectCommand.Parameters.AddWithValue("@Hasta", paginaMaxima.Text)
            da.Fill(dt)
            datalistado.DataSource = dt
            Cerrar()
            datalistado.Columns(0).Width = 50
            datalistado.Columns(1).Width = 50
            datalistado.Columns(2).Visible = False
            datalistado.Columns(7).Visible = False
            datalistado.Columns(10).Visible = False
            datalistado.Columns(15).Visible = False
            datalistado.Columns(16).Visible = False

        Catch ex As Exception
        End Try

        Multilinea(datalistado)

        sumar_costo_de_inventario_CONTAR_PRODUCTOS()

        btn_Ultima.Visible = False
        btn_Primera.Visible = False
        FlowLayoutPanel1.Visible = False
    End Sub

    Private Sub txtbusca_TextChanged(sender As Object, e As EventArgs) Handles txtbusca.TextChanged
        If txtbusca.Text <> "" And txtbusca.Text <> "Buscar..." Then
            buscar()
        ElseIf txtbusca.Text = "" Then

        End If



    End Sub


    Private Sub datalistado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellClick
        If e.ColumnIndex = Me.datalistado.Columns.Item("Eliminar").Index Then
            Dim result As DialogResult

            result = MessageBox.Show("¿Realmente desea eliminar este Producto?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then
                Dim cmd As SqlCommand
                Try
                    For Each row As DataGridViewRow In datalistado.SelectedRows

                        Dim onekey As Integer = Convert.ToInt32(row.Cells("Id_Producto1").Value)
                        Try

                            Try

                                abrir()
                                cmd = New SqlCommand("eliminar_Producto1", conexion)
                                cmd.CommandType = 4

                                cmd.Parameters.AddWithValue("@id", onekey)

                                cmd.ExecuteNonQuery()
                                Cerrar()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try

                        Catch ex As Exception : MsgBox(ex.Message)

                        End Try

                    Next
                    mostrar_datos()


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If



        End If
        If e.ColumnIndex = Me.datalistado.Columns.Item("Editar").Index Then
            proceso_para_obtener_datos_de_productos()

        End If
    End Sub
    Sub mostrar_datos()
        PanelTotales.Visible = True
        PanelPaginado.Visible = True
        PANELRegistro.Visible = False
        PANELRegistro.Dock = DockStyle.None

        ultima_pagina()
    End Sub
    Private Sub datalistado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellContentClick

    End Sub
    Private Sub Apagadado_Click(sender As Object, e As EventArgs)
        If idproducto <> 0 Then
            Dim CMD As SqlCommand
            Try
                abrir()
                CMD = New SqlCommand("editar_Producto1_SIN_CONTROL_DE_INVENTARIO", conexion)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.AddWithValue("@Id_Producto1", idproducto)
                CMD.Parameters.AddWithValue("@Stock", txtstock2.Text)
                CMD.Parameters.AddWithValue("@Stock_minimo", txtstockminimo.Text)
                CMD.Parameters.AddWithValue("@Usa_inventarios", "SI")
                If No_aplica_fecha.Checked = True Then
                    CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", txtfechaoka.Text)
                ElseIf No_aplica_fecha.Checked = False Then
                    CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA")
                End If

                CMD.ExecuteNonQuery()
                Cerrar()

            Catch ex As Exception

            End Try
        End If

        TimerEncendido.Start()
    End Sub



    Private Sub Encendido_Click(sender As Object, e As EventArgs)


        Try
            If idproducto = 0 Then
                TimerApagado.Start()
            End If
        Catch ex As Exception

        End Try

        Try
            If idproducto * 1 <> 0 And txtstock2.Text * 1 > 0 Then
                Dim result2 As DialogResult
                result2 = MessageBox.Show("Hay Aun En Stock, Dirijete al Modulo Inventarios para Ajustar el Inventario a cero", "Stock Existente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            End If
        Catch ex As Exception

        End Try

        Try
            If idproducto * 1 <> 0 And txtstock2.Text * 1 = 0 Then
                Dim CMD As SqlCommand
                Try
                    abrir()
                    CMD = New SqlCommand("editar_Producto1_SIN_CONTROL_DE_INVENTARIO", conexion)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.AddWithValue("@Id_Producto1", idproducto)
                    CMD.Parameters.AddWithValue("@Stock", "Ilimitado")
                    CMD.Parameters.AddWithValue("@Stock_minimo", 0)
                    CMD.Parameters.AddWithValue("@Usa_inventarios", "NO")
                    CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA")
                    CMD.ExecuteNonQuery()
                    Cerrar()
                    TimerApagado.Start()
                    txtstock2.Text = 0
                    txtstockminimo.Text = 0
                    No_aplica_fecha.Checked = False
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try



    End Sub





    Private Sub Apagado2_Click(sender As Object, e As EventArgs)

        TimerEncendido.Start()

    End Sub
    Sub REGISTRO_CORRECTO(ByVal fin As Integer)

        Dim NBotones As Integer = 3

        Dim b As New Label()
        Dim P2 As New Panel
        'Dim I1 As New PictureBox


        b.Text = "REGISTRO GUARDADO CORRECTAMENTE"
        b.Size = New System.Drawing.Size(430, 35)

        b.BackColor = BackColor
        b.FlatStyle = FlatStyle.Flat
        b.BackColor = Color.Transparent
        b.ForeColor = Color.White
        b.Dock = DockStyle.Fill
        b.Font = New Font("Segoe UI", 12, FontStyle.Regular Or
        FontStyle.Bold)
        b.TextAlign = ContentAlignment.MiddleCenter
        'I1.BackgroundImage = My.Resources.correcto_simbolo
        'I1.BackgroundImageLayout = ImageLayout.Zoom
        'I1.Size = New System.Drawing.Size(90, 69)
        'I1.Dock = DockStyle.Left
        'I1.BackColor = Color.Transparent
        panel.Size = New System.Drawing.Size(430, 67)
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.Dock = DockStyle.Top
        panel.BackColor = Color.FromArgb(20, 20, 20)


        panel.Controls.Add(b)
        'panel.Controls.Add(I1)
        panel.Dock = DockStyle.Top
        panel.SendToBack()



    End Sub

    Sub sumar_costo_de_inventario_CONTAR_PRODUCTOS()
        Dim resultado As String
        Dim queryMoneda As String
        queryMoneda = "Select Moneda  FROM EMPRESA"
        Dim comMoneda As New SqlCommand(queryMoneda, conexion)
        Try
            abrir()
            resultado = (comMoneda.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
        Catch ex As Exception
            resultado = ""
        End Try

        Dim importe As Double
        Dim query As String
        query = "Select      CONVERT(NUMERIC(18, 2),sum(Producto1.Precio_de_compra * Stock )) As suma FROM  Producto1 where  Usa_inventarios ='SI'"
        Dim com As New SqlCommand(query, conexion)
        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
            lblcosto_inventario.Text = resultado & " " & importe
        Catch ex As Exception
            lblcosto_inventario.Text = resultado & " " & 0
        End Try

        Dim conteoresultado As String
        Dim querycontar As String
        querycontar = "select count(Id_Producto1 ) from Producto1 "
        Dim comcontar As New SqlCommand(querycontar, conexion)
        Try
            abrir()
            conteoresultado = (comcontar.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
            lblcantidad_productos.Text = conteoresultado
        Catch ex As Exception
            conteoresultado = ""
            lblcantidad_productos.Text = 0
        End Try

    End Sub
    Sub mostra_moneda_de_empresa()

        Dim moneda As String
        Dim com As New SqlCommand("Select Moneda From Empresa", conexion)

        Try
            abrir()
            moneda = (com.ExecuteScalar())
            Cerrar()
            lblmoneda.Text = moneda

        Catch ex As Exception
            lblmoneda.Text = ""
        End Try


    End Sub

    Private Sub productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        PANELRegistro.Visible = False
        DATALISTADO_PRODUCTOS_OKA.Size = New Point(594, 148)
        DATALISTADO_PRODUCTOS_OKA.Location = New Point(porunidad.Location.X, porunidad.Location.Y)
        Try

            txtnumeroigv.Text = datalistado_empresa.SelectedCells.Item(1).Value
            txtigv.Text = datalistado_empresa.SelectedCells.Item(2).Value
            txtigv2.Text = txtnumeroigv.Text
            lbligvcalculo.Text = "+ " & txtigv.Text
        Catch ex As Exception

        End Try

        Try
            If txtnumeroigv.Text = 0 Then
                txtigv.Visible = False

            End If
            If txtnumeroigv.Text <> 0 Then
                txtigv.Visible = True

            End If
        Catch ex As Exception

        End Try

        txtdescripcion.AutoCompleteCustomSource = DataHelper.LoadAutoComplete
        txtdescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtdescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource
        datalistadoGrupos.Location = New Point(PanelGuiaParaGRupos.Location.X, PanelGuiaParaGRupos.Location.Y)
        datalistadoGrupos.Size = New Point(431, 274)

        Panel2.Visible = False
        txtbusca.Visible = True
        MenuStrip2.Visible = True
        datalistado.Enabled = True

        LIMPIAR()

        NuevoRegistroToolStripMenuItem.Visible = False
        txtbusca.Text = "Buscar..."
        sumar_costo_de_inventario_CONTAR_PRODUCTOS()


        mostrar_caja()
        mostrar_inicio_De_sesion()

        mostrar_datos_al_inicio()



    End Sub
    Sub mostrar_datos_al_inicio()
        paginaInicio.Text = 1
        paginaMaxima.Text = 10
        Listar()



        If lblcantidad_productos.Text > paginaMaxima.Text Then
            btn_Sig.Visible = True
            btn_atras.Visible = False
            btn_Ultima.Visible = True
            btn_Primera.Visible = True
        ElseIf lblcantidad_productos.Text <= paginaMaxima.Text
            btn_Sig.Visible = False
            btn_atras.Visible = False
            btn_Ultima.Visible = False
            btn_Primera.Visible = False
        End If
        paginar()

        mostrar_paginados()

    End Sub
    Sub paginar()
        Try
            lbl_Pagina.Text = paginaMaxima.Text / 10
            lbl_totalPaginas.Text = Math.Ceiling(lblcantidad_productos.Text / items_por_pagina)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LIMPIAR()
        sumar_costo_de_inventario_CONTAR_PRODUCTOS()
    End Sub

    Sub agregar_formato_de_moneda()
        'Try

        '    mostra_moneda_de_empresa()
        '    TXTPRECIODEVENTA2.Text = lblmoneda.Text & " " & Format(Convert.ToDouble(TXTPRECIODEVENTA2.Text), "#,###,###,#0.00")


        'Catch ex As Exception

        'End Try

    End Sub
    Sub proceso_para_obtener_datos_de_productos()
        Try
            Funcion = "EDITAR"
            DATALISTADO_PRODUCTOS_OKA.Visible = False
            Panel6.Visible = False
            TGUARDAR.Visible = False
            TGUARDARCAMBIOS.Visible = True
            PanelPaginado.Visible = False
            PanelTotales.Visible = False
            PANELRegistro.Visible = True
            PANELRegistro.Dock = DockStyle.Fill
            MenuStrip2.Visible = False
            NuevoRegistroToolStripMenuItem.Visible = True
            txtmsbox.Text = "Se ha activado la modificacion de registros   "
            lblEstadoCodigo.Text = "EDITAR"
            PanelGrupo.Visible = False
            BtnGuardarCambios.Visible = False
            BtnGuardar_grupo.Visible = False
            PanelcodigodeBarras.Visible = True
            habilitar_objetos()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        Try

            txtidproducto.Text = datalistado.SelectedCells.Item(2).Value
            idproducto = datalistado.SelectedCells.Item(2).Value
            txtcodigodebarras.Text = datalistado.SelectedCells.Item(3).Value
            txtgrupo.Text = datalistado.SelectedCells.Item(4).Value
            txtdescripcion.Text = datalistado.SelectedCells.Item(5).Value
            txtnumeroigv.Text = datalistado.SelectedCells.Item(6).Value
            idgrupo = datalistado.SelectedCells.Item(16).Value
            manejo_de_lotes = datalistado.SelectedCells.Item(17).Value
            LBL_ESSERVICIO.Text = datalistado.SelectedCells.Item(7).Value
            txtcosto.Text = datalistado.SelectedCells.Item(8).Value
            txtpreciomayoreo.Text = datalistado.SelectedCells.Item(9).Value
            LBLSEVENDEPOR.Text = datalistado.SelectedCells.Item(10).Value
            txtstockminimo.Text = datalistado.SelectedCells.Item(11).Value
            lblfechasvenci.Text = datalistado.SelectedCells.Item(12).Value
            txtstock2.Text = datalistado.SelectedCells.Item(13).Value
            TXTPRECIODEVENTA2.Text = datalistado.SelectedCells.Item(14).Value
            txtapartirde.Text = datalistado.SelectedCells.Item(15).Value
            Try
                If txtnumeroigv.Text = 0 Then
                    txtigv.Checked = False
                End If
                If txtnumeroigv.Text <> 0 Then
                    txtigv.Checked = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            If LBLSEVENDEPOR.Text = "Unidad" Then
                porunidad.Checked = True

            End If
            If LBLSEVENDEPOR.Text = "Granel" Then
                agranel.Checked = True
            End If

            agregar_formato_de_moneda()
            PanelGrupo.Visible = False
            datalistadoGrupos.Visible = False
            Try

                Dim TotalVentaVariabledouble As Double
                TotalVentaVariabledouble = ((TXTPRECIODEVENTA2.Text * 1 - txtcosto.Text * 1) / (txtcosto.Text * 1)) * 100

                If TotalVentaVariabledouble > 0 Then
                    Me.txtPorcentajeGanancia.Text = TotalVentaVariabledouble
                Else
                    'Me.txtPorcentajeGanancia.Text = 0
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If manejo_de_lotes = "SI" Then
                mostrar_Producto_por_lote()
                If datalistadoLOTES.RowCount > 1 Then
                    PANELINVENTARIO.Visible = False
                    PanelcodigodeBarras.Visible = False
                    panelAgregarLotes.Visible = False
                    PanelVerLotes.Visible = False
                    visualizar_panel_lotes()
                Else
                    editar_estado_quitar_lotes()
                End If
            Else
                controlar_stock_sin_lotes()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub editar_estado_quitar_lotes()
        Try
            abrir()
            Dim cmd As SqlCommand = New SqlCommand("editar_estado_quitar_lotes", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idproducto", idproducto)
            cmd.ExecuteNonQuery()
            Cerrar()
            controlar_stock_sin_lotes()
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try
    End Sub
    Sub controlar_stock_sin_lotes()
        PanelVerLotes.Visible = False
        If lblfechasvenci.Text = "NO APLICA" Then
            No_aplica_fecha.Checked = True
        End If
        If lblfechasvenci.Text <> "NO APLICA" Then
            No_aplica_fecha.Checked = False
        End If


        If LBL_ESSERVICIO.Text = "SI" Then
            Inventarios.Checked = True
            PANELINVENTARIO.Visible = True
            PANELINVENTARIO.Visible = True
            txtstock2.ReadOnly = True

        End If
        If LBL_ESSERVICIO.Text = "NO" Then
            Inventarios.Checked = False
            PANELINVENTARIO.Visible = False
            PANELINVENTARIO.Visible = False
            txtstock2.ReadOnly = True
            txtstock2.Text = 0
            txtstockminimo.Text = 0
            No_aplica_fecha.Checked = True
            txtstock2.ReadOnly = False
        End If
    End Sub
    Private Sub datalistado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellDoubleClick
        proceso_para_obtener_datos_de_productos()
    End Sub
    Private Sub txtgrupo_SelectedIndexChanged(sender As Object, e As EventArgs)
        With txtidlinea
            .DataSource = dtlinea
            .DisplayMember = "Idline"
            .ValueMember = "Idline"
        End With
    End Sub

    Private Sub datalistado_KeyDown(sender As Object, e As KeyEventArgs) Handles datalistado.KeyDown
        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            SendKeys.Send("{TAB}")
            Try
                DATALISTADO_PRODUCTOS_OKA.Visible = False

                Panel6.Visible = False
                TGUARDAR.Visible = False
                TGUARDARCAMBIOS.Visible = True
                PANELRegistro.Visible = True
                MenuStrip2.Visible = False


                NuevoRegistroToolStripMenuItem.Visible = True
                txtmsbox.Text = "Se ha activado la modificacion de registros   "
                idproducto = datalistado.SelectedCells.Item(1).Value




            Catch ex As Exception

            End Try

            Try

                txtidproducto.Text = datalistado.SelectedCells.Item(1).Value

                txtcodigodebarras.Text = datalistado.SelectedCells.Item(2).Value
                txtgrupo.Text = datalistado.SelectedCells.Item(3).Value
                txtdescripcion.Text = datalistado.SelectedCells.Item(4).Value
                txtnumeroigv.Text = datalistado.SelectedCells.Item(5).Value
                Try
                    If txtnumeroigv.Text = 0 Then
                        txtigv.Checked = False
                    End If
                    If txtnumeroigv.Text <> 0 Then
                        txtigv.Checked = True

                    End If
                Catch ex As Exception

                End Try

                LBL_ESSERVICIO.Text = datalistado.SelectedCells.Item(6).Value

                If LBL_ESSERVICIO.Text = "SI" Then
                    Inventarios.Checked = True
                    PANELINVENTARIO.Visible = True
                    PANELINVENTARIO.Visible = True
                    txtstock2.ReadOnly = True

                End If
                If LBL_ESSERVICIO.Text = "NO" Then
                    Inventarios.Checked = False
                    PANELINVENTARIO.Visible = False
                    PANELINVENTARIO.Visible = False
                    txtstock2.ReadOnly = False
                End If


                txtcosto.Text = datalistado.SelectedCells.Item(7).Value
                txtpreciomayoreo.Text = datalistado.SelectedCells.Item(8).Value
                LBLSEVENDEPOR.Text = datalistado.SelectedCells.Item(9).Value
                If LBLSEVENDEPOR.Text = "Unidad" Then
                    porunidad.Checked = True

                End If
                If LBLSEVENDEPOR.Text = "Granel" Then
                    agranel.Checked = True
                End If
                txtstockminimo.Text = datalistado.SelectedCells.Item(10).Value
                lblfechasvenci.Text = datalistado.SelectedCells.Item(11).Value
                If lblfechasvenci.Text = "NO APLICA" Then
                    No_aplica_fecha.Checked = True
                End If
                If lblfechasvenci.Text <> "NO APLICA" Then
                    No_aplica_fecha.Checked = False
                End If
                txtstock2.Text = datalistado.SelectedCells.Item(12).Value
                TXTPRECIODEVENTA2.Text = datalistado.SelectedCells.Item(13).Value



                'imagenrs.BackgroundImage = Nothing
                'Dim brs() As Byte = datalistado.SelectedCells.Item(9).Value
                'Dim msrs As New IO.MemoryStream(brs)
                'imagenrs.Image = Image.FromStream(msrs)
                'imagenrs.SizeMode = PictureBoxSizeMode.StretchImage



                'imagenft.BackgroundImage = Nothing
                'Dim bft() As Byte = datalistado.SelectedCells.Item(4).Value
                'Dim msft As New IO.MemoryStream(bft)
                'imagenft.Image = Image.FromStream(msft)
                'imagenft.SizeMode = PictureBoxSizeMode.StretchImage






            Catch ex As Exception
            End Try
        End If
        If (e.KeyCode = Keys.Delete) Then


            Dim result As DialogResult
            Dim cmd As SqlCommand
            result = MessageBox.Show("Realmente desea eliminar los registros seleccionados?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then
                Try
                    For Each row As DataGridViewRow In datalistado.SelectedRows
                        'Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)
                        'datalistado.Rows.Remove(datalistado.CurrentRow)


                        'If datalistado.SelectedCells.Item(6).Value Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("Id_Producto1").Value)

                        Try

                            abrir()
                            cmd = New SqlCommand("eliminar_Producto1", conexion)
                            cmd.CommandType = 4
                            cmd.Parameters.AddWithValue("@id", onekey)

                            cmd.ExecuteNonQuery()

                            Cerrar()
                        Catch ex As Exception 'MsgBox(ex.Message)

                        End Try

                        'End If

                    Next

                    Call sumar_costo_de_inventario_CONTAR_PRODUCTOS()

                    Timer2.Start()


                Catch ex As Exception
                    'MsgBox(ex.Message)

                End Try
            Else
                MessageBox.Show("Cancelando eliminación de registros", "Eliminando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If


        End If


    End Sub



    Private Sub txttipodeproducto_SelectedIndexChanged(sender As Object, e As EventArgs)
        With txtidtipodeproducto
            .DataSource = dttipo
            .DisplayMember = "Id_tipo_de_producto"
            .ValueMember = "Id_tipo_de_producto"
        End With
    End Sub
    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        Panel8.Visible = False

    End Sub


    Private Sub VOLVERToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Panel6.Visible = False

    End Sub


    Private Sub TXTPRECIODEVENTA2_Click(sender As Object, e As EventArgs) Handles TXTPRECIODEVENTA2.Click
        'Panel21.Visible = True
        'Panel18.Visible = True

        'Panel22.Visible = False

        'Try
        '    If txtigv.Checked = True Then
        '        txtigv2.Visible = True
        '        lbligvcalculo.Visible = True
        '        txtprecio_sin_impuestos.Text = TXTPRECIODEVENTA2.Text
        '        txtigv2.Text = 0
        '        txtigv2.Text = (txtnumeroigv.Text * 1 * TXTPRECIODEVENTA2.Text * 1) / 100
        '        txtprecio_sin_impuestos.Text = TXTPRECIODEVENTA2.Text * 1 - txtigv2.Text * 1
        '        txtpreciofinal.Text = txtigv2.Text * 1 + txtprecio_sin_impuestos.Text * 1

        '        txtigv2.Text = Format(CType(txtigv2.Text, Decimal), "##0.00")
        '        txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
        '    End If
        '    If txtigv.Checked = False Then
        '        txtprecio_sin_impuestos.Text = TXTPRECIODEVENTA2.Text
        '        txtigv2.Text = 0
        '        txtigv2.Visible = False
        '        lbligvcalculo.Visible = False
        '        txtpreciofinal.Text = txtprecio_sin_impuestos.Text * 1
        '        txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
        '    End If

        'Catch ex As Exception

        'End Try

        Try

            Dim TotalVentaVariabledouble As Double
            TotalVentaVariabledouble = ((TXTPRECIODEVENTA2.Text * 1 - txtcosto.Text * 1) / (txtcosto.Text * 1)) * 100
            Me.txtPorcentajeGanancia.Text = TotalVentaVariabledouble
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TXTPRECIODEVENTA2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPRECIODEVENTA2.KeyPress

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            ' 
            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(TXTPRECIODEVENTA2, e)
    End Sub


    Private Sub TXTPRECIODEVENTA2_TextChanged(sender As Object, e As EventArgs) Handles TXTPRECIODEVENTA2.TextChanged
        TimerCalcular_precio_venta.Stop()


        TimerCalucular_porcentaje_ganancia.Start()
        TimerCalcular_precio_venta.Stop()



        'Try
        '    txtPorcentajeGanancia.Value = (TXTPRECIODEVENTA2.Text * 1 - txtcosto.Text * 1) / (txtcosto.Text * 1)

        'Catch ex As Exception
        '    'txtPorcentajeGanancia.Value = 0
        'End Try
        'Try
        '    If txtigv.Checked = True Then
        '        txtigv2.Visible = True
        '        lbligvcalculo.Visible = True

        '        txtigv2.Text = 0
        '        txtigv2.Text = (txtnumeroigv.Text * 1 * TXTPRECIODEVENTA2.Text * 1) / 100
        '        txtprecio_sin_impuestos.Text = TXTPRECIODEVENTA2.Text * 1 - txtigv2.Text * 1
        '        txtpreciofinal.Text = txtigv2.Text * 1 + txtprecio_sin_impuestos.Text * 1

        '        txtigv2.Text = Format(CType(txtigv2.Text, Decimal), "##0.00")
        '        txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
        '    End If
        '    If txtigv.Checked = False Then
        '        txtprecio_sin_impuestos.Text = TXTPRECIODEVENTA2.Text
        '        txtigv2.Text = 0
        '        txtigv2.Visible = False
        '        lbligvcalculo.Visible = False
        '        txtpreciofinal.Text = txtprecio_sin_impuestos.Text * 1
        '        txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
        '    End If

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub txtcosto_Click(sender As Object, e As EventArgs) Handles txtcosto.Click
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
    End Sub

    Private Sub txtcosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcosto.KeyPress

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then

            e.KeyChar = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(txtcosto, e)
    End Sub

    Private Sub txtcosto_TextChanged(sender As Object, e As EventArgs) Handles txtcosto.TextChanged
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False

    End Sub



    Private Sub txtdescripcion_Click(sender As Object, e As EventArgs) Handles txtdescripcion.Click
        DATALISTADO_PRODUCTOS_OKA.Visible = True
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
    End Sub
    Private Sub contar()
        'Dim x As Integer
        'x = datalistado.Rows.Count
        'txtcontador.Text = CStr(x)
        Try
            Dim com As New SqlCommand("select count(Id_Producto1) from Producto1 ", conexion)

            Try
                abrir()
                txtcontador.Text = (com.ExecuteScalar())
                Cerrar()

            Catch ex As Exception
                txtcontador.Text = 0
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub contar_descripcion_producto_sin_repetir()
        Dim x As Integer
        x = DATALISTADO_PRODUCTOS_OKA.Rows.Count
        contador_descripcion_produco_sin_repetir = CStr(x)
    End Sub

    Dim contador_descripcion_produco_sin_repetir As Integer
    Private Sub txtdescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtdescripcion.TextChanged
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
        mostrar_descripcion_produco_sin_repetir()
        contar_descripcion_producto_sin_repetir()


        If contador_descripcion_produco_sin_repetir = 0 Then
            DATALISTADO_PRODUCTOS_OKA.Visible = False
        End If
        If contador_descripcion_produco_sin_repetir > 0 Then
            DATALISTADO_PRODUCTOS_OKA.Visible = True
        End If
        If TGUARDAR.Visible = False Then
            DATALISTADO_PRODUCTOS_OKA.Visible = False
        End If

    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Funcion = "NUEVO"
        lblEstadoCodigo.Text = "NUEVO"
        PanelGrupo.Visible = False
        BtnGuardar_grupo.Visible = False
        BtnGuardarCambios.Visible = False
        mostrar_grupos()

        txtapartirde.Text = 0
        txtstock2.ReadOnly = False
        Panel21.Visible = False
        Panel22.Visible = False
        Panel18.Visible = False
        idproducto = 0
        Inventarios.Checked = True
        PANELINVENTARIO.Visible = True
        txtdescripcion.AutoCompleteCustomSource = DataHelper.LoadAutoComplete
        txtdescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtdescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource

        PanelTotales.Visible = False
        PanelPaginado.Visible = False
        PANELRegistro.Visible = True
        PANELRegistro.Dock = DockStyle.Fill


        porunidad.Checked = True
        noconsiderarinventario.Checked = True
        No_aplica_fecha.Checked = False
        Panel6.Visible = False

        NuevoRegistroToolStripMenuItem.Visible = True
        LIMPIAR()
        txtmsbox.Text = "Se ha activado  registro  nuevo "
        btnagregaryguardar.Visible = True
        btnagregar.Visible = False


        txtdescripcion.Text = ""
        PANELINVENTARIO.Visible = True



        TGUARDAR.Visible = True
        TGUARDARCAMBIOS.Visible = False
        PanelcodigodeBarras.Visible = False
        LOTES.Visible = True
        LOTES.Checked = False
        PanelVerLotes.Visible = False
        panelAgregarLotes.Visible = False

        habilitar_objetos()
    End Sub
    Sub habilitar_objetos()
        txtdescripcion.Enabled = True
        porunidad.Enabled = True
        agranel.Enabled = True
        txtgrupo.Enabled = True
    End Sub

    Private Sub lblcostoUnt_TextChanged(sender As Object, e As EventArgs) Handles lblcostoUnt.TextChanged
        Try
            txtcosto.Text = lblcostoUnt.Text * 1 * txtcantidad_de_unidad_de_medidaoka.Text * 1

        Catch ex As Exception
            lblcostoUnt.Text = 0
        End Try
    End Sub




    Private Sub DATALISTADO_PRODUCTOS_OKA_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DATALISTADO_PRODUCTOS_OKA.CellClick, datalistado_empresa.CellClick
        Try
            txtdescripcion.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells.Item(1).Value
            DATALISTADO_PRODUCTOS_OKA.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DATALISTADO_PRODUCTOS_OKA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DATALISTADO_PRODUCTOS_OKA.CellContentClick, datalistado_empresa.CellContentClick

    End Sub

    Private Sub txtpreciomayoreo_Click(sender As Object, e As EventArgs) Handles txtpreciomayoreo.Click, txtapartirde.Click
        Panel21.Visible = False
        Panel22.Visible = True
        Panel18.Visible = True

        Try
            If txtigv.Checked = True Then
                txtigv2.Visible = True
                lbligvcalculo.Visible = True

                txtigv2.Text = 0
                txtigv2.Text = (txtnumeroigv.Text * 1 * txtpreciomayoreo.Text * 1) / 100
                txtprecio_sin_impuestos.Text = txtpreciomayoreo.Text * 1 - txtigv2.Text * 1
                txtpreciofinal.Text = txtigv2.Text * 1 + txtprecio_sin_impuestos.Text * 1

                txtigv2.Text = Format(CType(txtigv2.Text, Decimal), "##0.00")
                txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
            End If
            If txtigv.Checked = False Then
                txtprecio_sin_impuestos.Text = txtpreciomayoreo.Text
                txtigv2.Text = 0
                txtigv2.Visible = False
                lbligvcalculo.Visible = False
                txtpreciofinal.Text = txtprecio_sin_impuestos.Text * 1
                txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
            End If

        Catch ex As Exception

        End Try
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
    Private Sub txtpreciomayoreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpreciomayoreo.KeyPress

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            ' 
            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(txtpreciomayoreo, e)
    End Sub

    Private Sub txtpreciomayoreo_MouseMove(sender As Object, e As MouseEventArgs) Handles txtpreciomayoreo.MouseMove

    End Sub

    Private Sub txtpreciomayoreo_TextChanged(sender As Object, e As EventArgs) Handles txtpreciomayoreo.TextChanged

        'Try
        '    If txtigv.Checked = True Then
        '        txtigv2.Visible = True
        '        lbligvcalculo.Visible = True

        '        txtigv2.Text = 0
        '        txtigv2.Text = (txtnumeroigv.Text * 1 * txtpreciomayoreo.Text * 1) / 100
        '        txtprecio_sin_impuestos.Text = txtpreciomayoreo.Text * 1 - txtigv2.Text * 1
        '        txtpreciofinal.Text = txtigv2.Text * 1 + txtprecio_sin_impuestos.Text * 1

        '        txtigv2.Text = Format(CType(txtigv2.Text, Decimal), "##0.00")
        '        txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
        '    End If
        '    If txtigv.Checked = False Then
        '        txtprecio_sin_impuestos.Text = txtpreciomayoreo.Text
        '        txtigv2.Text = 0
        '        txtigv2.Visible = False
        '        lbligvcalculo.Visible = False
        '        txtpreciofinal.Text = txtprecio_sin_impuestos.Text * 1
        '        txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
        '    End If

        'Catch ex As Exception

        'End Try
        Try

        Catch ex As Exception
            txtapartirde.Text = 0
        End Try
    End Sub

    Private Sub txtcodigodebarras_Click(sender As Object, e As EventArgs) Handles txtcodigodebarras.Click
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
    End Sub

    Private Sub txtcodigodebarras_TextChanged(sender As Object, e As EventArgs) Handles txtcodigodebarras.TextChanged
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
    End Sub

    Private Sub txtstock2_Click(sender As Object, e As EventArgs) Handles txtstock2.Click
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False

    End Sub

    Private Sub txtstock2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtstock2.KeyPress

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then

            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)
        End If
        NumerosyDecimal(txtstock2, e)
    End Sub

    Private Sub txtstock2_MouseClick(sender As Object, e As MouseEventArgs) Handles txtstock2.MouseClick
        Try
            If idproducto <> 0 Then
                Tmensajes.SetToolTip(txtstock2, "Para modificar el Stock Hazlo desde el Modulo de Inventarios")
                Tmensajes.ToolTipTitle = "Accion denegada"
                Tmensajes.ToolTipIcon = ToolTipIcon.Info

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtstock2_MouseHover(sender As Object, e As EventArgs) Handles txtstock2.MouseHover
        Try
            If idproducto <> 0 Then
                Tmensajes.SetToolTip(txtstock2, "Para modificar el Stock Hazlo desde el Modulo de Inventarios")
                Tmensajes.ToolTipTitle = "Accion denegada"
                Tmensajes.ToolTipIcon = ToolTipIcon.Info

            End If
        Catch ex As Exception

        End Try


    End Sub



    Private Sub txtstock2_TextChanged(sender As Object, e As EventArgs) Handles txtstock2.TextChanged
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False

    End Sub

    Private Sub txtstockminimo_Click(sender As Object, e As EventArgs) Handles txtstockminimo.Click
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
    End Sub

    Private Sub txtstockminimo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtstockminimo.KeyPress

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            ' 
            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(txtstockminimo, e)
    End Sub

    Private Sub txtstockminimo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtstockminimo.KeyUp

    End Sub

    Private Sub txtstockminimo_TextChanged(sender As Object, e As EventArgs) Handles txtstockminimo.TextChanged
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
    End Sub

    Private Sub txtfechaoka_ValueChanged(sender As Object, e As EventArgs) Handles txtfechaoka.ValueChanged
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
    End Sub

    Private Sub porunidad_CheckedChanged(sender As Object, e As EventArgs) Handles porunidad.CheckedChanged
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
    End Sub

    Private Sub agranel_CheckedChanged(sender As Object, e As EventArgs) Handles agranel.CheckedChanged
        Panel22.Visible = False
        Panel21.Visible = False
        Panel18.Visible = False
    End Sub

    Private Sub ToolStripMenuItem11_Click_2(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        DATALISTADO_PRODUCTOS_OKA.Visible = False

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        sumar_costo_de_inventario_CONTAR_PRODUCTOS()
        Timer2.Stop()


    End Sub

    Private Sub ToolStripMenuItem15_Click_1(sender As Object, e As EventArgs) Handles btnExcel.Click
        MASCARA1.Show()
        Asistente_de_importacionExcel.ShowDialog()
    End Sub

    Private Sub txtigv_CheckedChanged(sender As Object, e As EventArgs) Handles txtigv.CheckedChanged
        If Panel21.Visible = True Then
            Try
                If txtigv.Checked = True Then
                    txtigv2.Visible = True
                    lbligvcalculo.Visible = True
                    txtigv2.Text = 0
                    txtigv2.Text = (txtnumeroigv.Text * 1 * TXTPRECIODEVENTA2.Text * 1) / 100
                    txtprecio_sin_impuestos.Text = TXTPRECIODEVENTA2.Text * 1 - txtigv2.Text * 1
                    txtpreciofinal.Text = txtigv2.Text * 1 + txtprecio_sin_impuestos.Text * 1

                    txtigv2.Text = Format(CType(txtigv2.Text, Decimal), "##0.00")
                    txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
                End If
                If txtigv.Checked = False Then
                    txtprecio_sin_impuestos.Text = TXTPRECIODEVENTA2.Text
                    txtigv2.Text = 0
                    txtigv2.Visible = False
                    lbligvcalculo.Visible = False
                    txtpreciofinal.Text = txtprecio_sin_impuestos.Text * 1
                    txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
                End If

            Catch ex As Exception

            End Try

        ElseIf Panel22.Visible = True Then
            Try
                If txtigv.Checked = True Then
                    txtigv2.Visible = True
                    lbligvcalculo.Visible = True

                    txtigv2.Text = 0
                    txtigv2.Text = (txtnumeroigv.Text * 1 * txtpreciomayoreo.Text * 1) / 100
                    txtprecio_sin_impuestos.Text = txtpreciomayoreo.Text * 1 - txtigv2.Text * 1
                    txtpreciofinal.Text = txtigv2.Text * 1 + txtprecio_sin_impuestos.Text * 1

                    txtigv2.Text = Format(CType(txtigv2.Text, Decimal), "##0.00")
                    txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
                End If
                If txtigv.Checked = False Then
                    txtprecio_sin_impuestos.Text = txtpreciomayoreo.Text
                    txtigv2.Text = 0
                    txtigv2.Visible = False
                    lbligvcalculo.Visible = False
                    txtpreciofinal.Text = txtprecio_sin_impuestos.Text * 1
                    txtpreciofinal.Text = Format(CType(txtpreciofinal.Text, Decimal), "##0.00")
                End If

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub Panel22_Paint(sender As Object, e As PaintEventArgs) Handles Panel22.Paint

    End Sub
    Sub INSERTAR_KARDEX_ENTRADA()
        'Try
        '    Dim cmd As New SqlCommand
        '    abrir()
        '    cmd = New SqlCommand("insertar_KARDEX_ENTRADA", conexion)
        '    cmd.CommandType = 4
        '    cmd.Parameters.AddWithValue("@Fecha", Now())
        '    cmd.Parameters.AddWithValue("@Motivo", "Registro inicial de Producto")
        '    cmd.Parameters.AddWithValue("@Cantidad ", txtstock2.Text)
        '    cmd.Parameters.AddWithValue("@Id_producto", lblIdProducto.Text)
        '    cmd.Parameters.AddWithValue("@Id_usuario", VENTAS_MENU_PRINCIPAL.lblidusuario.Text)
        '    cmd.Parameters.AddWithValue("@Tipo", "ENTRADA")
        '    cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO")
        '    cmd.Parameters.AddWithValue("@Id_caja", VENTAS_MENU_PRINCIPAL.lblidcaja.Text)
        '    cmd.ExecuteNonQuery()

        '    Cerrar()


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Dim idusuario As Integer
    Dim idcaja As Integer
    Sub mostrar_inicio_De_sesion()
        Try

            Dim com As New SqlCommand("mostrar_inicio_De_sesion", conexion)
            com.CommandType = 4
            com.Parameters.AddWithValue("@id_serial_pc", lblIdSerial.Text)

            Try
                abrir()
                idusuario = (com.ExecuteScalar())
                Cerrar()

            Catch ex As Exception


            End Try

        Catch ex As Exception

        End Try


    End Sub
    Sub mostrar_caja()
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIdSerial.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIdSerial.Text = Encriptar(lblIdSerial.Text.Trim())
        MOSTRAR_CAJA_POR_SERIAL()
        Try
            idcaja = datalistado_caja.SelectedCells.Item(1).Value
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub MOSTRAR_CAJA_POR_SERIAL()


        Dim dt As New DataTable

        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Serial", lblIdSerial.Text)

            da.Fill(dt)
            datalistado_caja.DataSource = dt
            Cerrar()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub insertar_productos()
        If txtpreciomayoreo.Text = 0 Or txtpreciomayoreo.Text = "" Then txtapartirde.Text = 0
        Dim CMD As SqlCommand
        Try
            abrir()

            CMD = New SqlCommand("insertar_Producto", conexion)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text)
            CMD.Parameters.AddWithValue("@Imagen", ".")
            CMD.Parameters.AddWithValue("@Precio_de_compra", txtcosto.Text)
            CMD.Parameters.AddWithValue("@Precio_de_venta", TXTPRECIODEVENTA2.Text)
            CMD.Parameters.AddWithValue("@Codigo", txtcodigodebarras.Text)
            CMD.Parameters.AddWithValue("@A_partir_de", txtapartirde.Text)

            If txtigv.Checked = True Then
                CMD.Parameters.AddWithValue("@Impuesto", txtnumeroigv.Text)
            End If
            If txtigv.Checked = False Then
                CMD.Parameters.AddWithValue("@Impuesto", 0)
            End If

            CMD.Parameters.AddWithValue("@Precio_mayoreo", txtpreciomayoreo.Text)



            If porunidad.Checked = True Then txtse_vende_a.Text = "Unidad"
            If agranel.Checked = True Then txtse_vende_a.Text = "Granel"

            CMD.Parameters.AddWithValue("@Se_vende_a", txtse_vende_a.Text)
            CMD.Parameters.AddWithValue("@Id_grupo", idgrupo)
            If PANELINVENTARIO.Visible = True Then
                CMD.Parameters.AddWithValue("@Usa_inventarios", "SI")
                CMD.Parameters.AddWithValue("@Stock_minimo", txtstockminimo.Text)
                CMD.Parameters.AddWithValue("@Stock", txtstock2.Text)

                If No_aplica_fecha.Checked = True Then
                    CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA")
                End If

                If No_aplica_fecha.Checked = False Then
                    CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", txtfechaoka.Text)
                End If


            End If
            If PANELINVENTARIO.Visible = False Then
                CMD.Parameters.AddWithValue("@Usa_inventarios", "NO")
                CMD.Parameters.AddWithValue("@Stock_minimo", 0)
                CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA")
                CMD.Parameters.AddWithValue("@Stock", "Ilimitado")

            End If
            CMD.Parameters.AddWithValue("@Fecha", Now())
            CMD.Parameters.AddWithValue("@Motivo", "Registro inicial de Producto")
            CMD.Parameters.AddWithValue("@Cantidad ", txtstock2.Text)
            CMD.Parameters.AddWithValue("@Id_usuario", idusuario)
            CMD.Parameters.AddWithValue("@Tipo", "ENTRADA")
            CMD.Parameters.AddWithValue("@Estado", "CONFIRMADO")
            CMD.Parameters.AddWithValue("@Id_caja", idcaja)
            CMD.Parameters.AddWithValue("@Manejo_de_lotes", Estado_control_de_lotes)


            CMD.ExecuteNonQuery()
            Cerrar()
            If LOTES.Checked = False Then
                REGISTRO_correcto_para_1_solo_producto()
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub REGISTRO_correcto_para_1_solo_producto()
        CORRECTO()
        PANELRegistro.Visible = False

        Timer3.Start()
        txtbusca.Text = txtdescripcion.Text
        buscar()
    End Sub

    Private Sub TGUARDAR_Click(sender As Object, e As EventArgs) Handles TGUARDAR.Click
        Estado_control_de_lotes = "NO"

        If txtpreciomayoreo.Text = "" Then txtpreciomayoreo.Text = 0
        If txtapartirde.Text = "" Then txtapartirde.Text = 0
        TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text & " ", "")
        TXTPRECIODEVENTA2.Text = Format(CType(TXTPRECIODEVENTA2.Text, Decimal), "##0.00")
        If (txtpreciomayoreo.Text * 1 > 0 And txtapartirde.Text * 1 > 0) Or (txtpreciomayoreo.Text * 1 = 0 And txtapartirde.Text * 1 = 0) Then
            If txtcosto.Text * 1 >= TXTPRECIODEVENTA2.Text * 1 Then

                Dim result As DialogResult
                result = MessageBox.Show("El precio de Venta es menor que el COSTO, Esto Te puede Generar Perdidas", "Producto con Perdidas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                If result = DialogResult.OK Then
                    insertar_productos()
                Else
                    TXTPRECIODEVENTA2.Focus()
                End If


            ElseIf txtcosto.Text * 1 < TXTPRECIODEVENTA2.Text * 1 Then
                insertar_productos()
            End If
        ElseIf txtpreciomayoreo.Text * 1 <> 0 Or txtapartirde.Text * 1 <> 0 Then
            MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

        End If



    End Sub

    Private Sub TGUARDARCAMBIOS_Click(sender As Object, e As EventArgs) Handles TGUARDARCAMBIOS.Click
        Estado_control_de_lotes = "NO"

        If txtpreciomayoreo.Text = "" Then txtpreciomayoreo.Text = 0
        If txtapartirde.Text = "" Then txtapartirde.Text = 0
        TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text & " ", "")
        TXTPRECIODEVENTA2.Text = Format(CType(TXTPRECIODEVENTA2.Text, Decimal), "##0.00")
        If (txtpreciomayoreo.Text * 1 > 0 And txtapartirde.Text * 1 > 0) Or (txtpreciomayoreo.Text * 1 = 0 And txtapartirde.Text * 1 = 0) Then


            If txtcosto.Text * 1 > TXTPRECIODEVENTA2.Text * 1 Then
                Dim result As DialogResult
                result = MessageBox.Show("El precio de Venta es menor que el COSTO, Esto Te puede Generar Perdidas", "Producto con Perdidas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                If result = DialogResult.OK Then
                    If PanelVerLotes.Visible = False Then
                        editar_productos_sin_lotizar()

                    End If

                Else
                    TXTPRECIODEVENTA2.Focus()
                End If



            ElseIf txtcosto.Text * 1 <= TXTPRECIODEVENTA2.Text * 1 Then
                If PanelVerLotes.Visible = False Then
                    editar_productos_sin_lotizar()
                End If
            End If
        ElseIf txtpreciomayoreo.Text * 1 <> 0 Or txtapartirde.Text * 1 <> 0 Then
            MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

        End If





    End Sub
    Sub editar_productos_sin_lotizar()
        If txtpreciomayoreo.Text = 0 Then txtapartirde.Text = 0
        If txtpreciomayoreo.Text = "" Then txtapartirde.Text = 0
        Dim CMD As SqlCommand
        Try
            abrir()
            CMD = New SqlCommand("editar_Producto1", conexion)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.AddWithValue("@Id_Producto1", idproducto)
            CMD.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text)
            CMD.Parameters.AddWithValue("@Imagen", ".")
            CMD.Parameters.AddWithValue("@A_partir_de", txtapartirde.Text)
            If PANELINVENTARIO.Visible = True Then
                CMD.Parameters.AddWithValue("@Stock", txtstock2.Text)
                If No_aplica_fecha.Checked = True Then
                    CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA")
                End If
                If No_aplica_fecha.Checked = False Then
                    CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", txtfechaoka.Text)
                End If
            End If
            If PANELINVENTARIO.Visible = False Then
                CMD.Parameters.AddWithValue("@Stock", "Ilimitado")
                CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA")
            End If
            CMD.Parameters.AddWithValue("@Precio_de_compra", txtcosto.Text)
            CMD.Parameters.AddWithValue("@Precio_de_venta", TXTPRECIODEVENTA2.Text)

            CMD.Parameters.AddWithValue("@Codigo", txtcodigodebarras.Text)

            If txtigv.Checked = True Then
                CMD.Parameters.AddWithValue("@Impuesto", txtnumeroigv.Text)
            End If
            If txtigv.Checked = False Then
                CMD.Parameters.AddWithValue("@Impuesto", 0)
            End If
            CMD.Parameters.AddWithValue("@Stock_minimo", txtstockminimo.Text)
            CMD.Parameters.AddWithValue("@Precio_mayoreo", txtpreciomayoreo.Text)
            If porunidad.Checked = True Then txtse_vende_a.Text = "Unidad"
            If agranel.Checked = True Then txtse_vende_a.Text = "Granel"
            CMD.Parameters.AddWithValue("@Se_vende_a", txtse_vende_a.Text)
            CMD.Parameters.AddWithValue("@Id_grupo", idgrupo)
            If PANELINVENTARIO.Visible = True Then
                CMD.Parameters.AddWithValue("@Usa_inventarios", "SI")
            End If
            If PANELINVENTARIO.Visible = False Then
                CMD.Parameters.AddWithValue("@Usa_inventarios", "NO")
            End If
            CMD.ExecuteNonQuery()
            PANELRegistro.Visible = False
            txtbusca.Text = txtdescripcion.Text
            mostrar_datos()
            Try
                CORRECTO()
                Timer3.Start()
            Catch ex As Exception
            End Try
            Cerrar()
        Catch ex As Exception
            mostrar_datos()
            MsgBox(MessageBox.Show(ex.Message) & "fallo editar_Producto1")
        End Try
    End Sub
    Sub editar_Producto1_lotizados()
        If txtpreciomayoreo.Text = 0 Then txtapartirde.Text = 0
        If txtpreciomayoreo.Text = "" Then txtapartirde.Text = 0
        Dim CMD As SqlCommand
        Try
            abrir()
            CMD = New SqlCommand("editar_Producto1_lotizados", conexion)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.AddWithValue("@Id_Producto1", idproducto)
            CMD.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text)
            CMD.Parameters.AddWithValue("@A_partir_de", txtapartirde.Text)
            CMD.Parameters.AddWithValue("@Precio_de_compra", txtcosto.Text)
            CMD.Parameters.AddWithValue("@Precio_de_venta", TXTPRECIODEVENTA2.Text)

            CMD.Parameters.AddWithValue("@Precio_mayoreo", txtpreciomayoreo.Text)
            If porunidad.Checked = True Then txtse_vende_a.Text = "Unidad"
            If agranel.Checked = True Then txtse_vende_a.Text = "Granel"
            CMD.Parameters.AddWithValue("@Se_vende_a", txtse_vende_a.Text)
            CMD.Parameters.AddWithValue("@Id_grupo", idgrupo)
            CMD.ExecuteNonQuery()
            PANELRegistro.Visible = False
            txtbusca.Text = txtdescripcion.Text
            mostrar_datos()
            Try
                CORRECTO()
                Timer3.Start()
            Catch ex As Exception
            End Try
            Cerrar()
        Catch ex As Exception
            mostrar_datos()
            MsgBox(MessageBox.Show(ex.Message) & "fallo editar_Producto1")
        End Try
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        PANELRegistro.Visible = False
        PanelTotales.Visible = True
        PanelPaginado.Visible = True
        Listar()
    End Sub
    Sub CORRECTO()
        Me.panel.Visible = True
        panel.AutoScroll = True
        panel.Location = New System.Drawing.Point(193, 38)
        panel.Name = "Panel1"
        panel.Size = New System.Drawing.Size(455, 640)
        Me.panel.Controls.Clear()
        Me.Controls.Add(panel)
        REGISTRO_CORRECTO(fin:=1)
        PanelTotales.Visible = True
        PanelPaginado.Visible = True
    End Sub
    Private Sub ToolStripMenuItem5_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click


    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value = ProgressBar1.Value + 10

        Else
            ProgressBar1.Value = 0

            Me.panel.Controls.Clear()
            Me.panel.Visible = False
            Timer3.Stop()

            ProgressBar1.Value = 0

        End If
    End Sub

    Private Sub txtapartirde_TextChanged(sender As Object, e As EventArgs) Handles txtapartirde.TextChanged

    End Sub

    Private Sub txtapartirde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtapartirde.KeyPress

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then

            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(txtapartirde, e)
    End Sub
    Private Sub txtcodigodebarras_Enter(sender As Object, e As EventArgs) Handles txtcodigodebarras.Enter

        ' Referenciamos el control TextBox que ha desencadenado el evento
        Dim tb As TextBox = DirectCast(sender, TextBox)

        DrawRectangle(tb, Color.Red)

    End Sub

    Private Sub txtcodigodebarras_Leave(sender As Object, e As EventArgs) Handles txtcodigodebarras.Leave

        ' Referenciamos el control TextBox que ha desencadenado el evento
        Dim tb As TextBox = DirectCast(sender, TextBox)

        DrawRectangle(tb, Me.BackColor)

    End Sub

    Private Sub DrawRectangle(tb As TextBox, clr As Color)

        If (tb Is Nothing) Then Return

        Dim d As Integer = 2

        Dim pt As New Point(tb.Location.X - d, tb.Location.Y - d)
        Dim sz As New Size(tb.Width + (2 * d), tb.Height + (2 * d))

        Using g As Graphics = Me.CreateGraphics()
            Dim rect As New Rectangle(pt, sz)
            Dim p As New Pen(clr, 2)
            g.DrawRectangle(p, rect)
            p.Dispose()
        End Using

    End Sub





    Private Sub TimerCalcular_precio_venta_Tick(sender As Object, e As EventArgs) Handles TimerCalcular_precio_venta.Tick
        TimerCalcular_precio_venta.Stop()

        Try
            Dim TotalVentaVariabledouble As Double
            TotalVentaVariabledouble = (txtcosto.Text * 1) + (txtcosto.Text * 1) * ((txtPorcentajeGanancia.Text * 1) / 100)

            If TotalVentaVariabledouble > 0 And txtPorcentajeGanancia.Focused = True Then
                TXTPRECIODEVENTA2.Text = TotalVentaVariabledouble
            Else
                'txtPorcentajeGanancia.Value = 0
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub TimerCalucular_porcentaje_ganancia_Tick(sender As Object, e As EventArgs) Handles TimerCalucular_porcentaje_ganancia.Tick
        TimerCalucular_porcentaje_ganancia.Stop()

        Try

            Dim TotalVentaVariabledouble As Double
            TotalVentaVariabledouble = ((TXTPRECIODEVENTA2.Text * 1 - txtcosto.Text * 1) / (txtcosto.Text * 1)) * 100

            If TotalVentaVariabledouble > 0 And TXTPRECIODEVENTA2.Focused = True Then
                Me.txtPorcentajeGanancia.Text = TotalVentaVariabledouble
            Else
                'Me.txtPorcentajeGanancia.Text = 0
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtMiTexto_LostFocus()

    End Sub



    Private Sub Panel13_Paint(sender As Object, e As PaintEventArgs) Handles Panel13.Paint

    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click, lblIdSerial.Click

    End Sub

    Private Sub TXTPRECIODEVENTA2_LostFocus(sender As Object, e As EventArgs) Handles TXTPRECIODEVENTA2.LostFocus
        agregar_formato_de_moneda()
    End Sub
    Sub insertar_grupo()

        Dim CMD As SqlCommand
        Try
            abrir()

            CMD = New SqlCommand("insertar_Grupo", conexion)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.AddWithValue("@Grupo", TxtGrupoRegistro.Text)
            CMD.Parameters.AddWithValue("@Por_defecto", "NO")
            CMD.ExecuteNonQuery()
            Cerrar()
            txtgrupo.Text = TxtGrupoRegistro.Text
            mostrar_grupos()
            PanelGrupo.Visible = False
            datalistadoGrupos.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BtnGuardar_Categoria_Click(sender As Object, e As EventArgs) Handles BtnGuardar_grupo.Click
        insertar_grupo()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        PanelGrupo.Visible = False

    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles btnNuevoGrupo.Click
        TxtGrupoRegistro.Clear()
        TxtGrupoRegistro.Focus()

        PanelGrupo.Visible = True
        PanelGrupo.Size = New Point(1311, 340)
        PanelGrupo.BringToFront()
        PanelGrupo.Location = New Point(PanelReferenciaGrupo.Location.X, PanelReferenciaGrupo.Location.Y)
        BtnGuardar_grupo.Visible = True
        BtnGuardarCambios.Visible = False

    End Sub

    Private Sub btnGuardar_grupo_Click(sender As Object, e As EventArgs)
        insertar_grupo()

    End Sub

    Private Sub txtgrupo_TextChanged_1(sender As Object, e As EventArgs) Handles txtgrupo.TextChanged
        mostrar_grupos()

        If datalistadoGrupos.RowCount > 0 Then
            datalistadoGrupos.Visible = True
            datalistadoGrupos.BringToFront()
        Else
            datalistadoGrupos.Visible = False

        End If



    End Sub
    Sub mostrar_grupos()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_grupos", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@buscar", txtgrupo.Text)
            da.Fill(dt)
            datalistadoGrupos.DataSource = dt
            datalistadoGrupos.Columns(2).Visible = False
            datalistadoGrupos.Columns(0).Width = 60
            datalistadoGrupos.Columns(1).Width = 60
            datalistadoGrupos.Columns(3).Width = datalistadoGrupos.Width - datalistadoGrupos.Columns(0).Width - datalistadoGrupos.Columns(1).Width
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnGuardarCambios_Click(sender As Object, e As EventArgs)
        editar_grupo()


    End Sub

    Sub editar_grupo()

        Dim CMD As SqlCommand
        Try
            abrir()
            CMD = New SqlCommand("editar_grupo", conexion)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.AddWithValue("@id", idgrupo)
            CMD.Parameters.AddWithValue("@Grupo", TxtGrupoRegistro.Text)
            CMD.ExecuteNonQuery()
            Cerrar()
            PanelGrupo.Visible = False
            datalistadoGrupos.Visible = False
            txtgrupo.Text = TxtGrupoRegistro.Text
            PanelcodigodeBarras.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub datalistadoGrupos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoGrupos.CellContentClick

    End Sub

    Private Sub datalistadoGrupos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoGrupos.CellClick
        If e.ColumnIndex = Me.datalistadoGrupos.Columns.Item("EliminarG").Index Then
            Dim result As DialogResult

            result = MessageBox.Show("¿Realmente desea eliminar este Grupo?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then
                Dim cmd As SqlCommand
                Try
                    For Each row As DataGridViewRow In datalistadoGrupos.SelectedRows

                        Dim onekey As Integer = Convert.ToInt32(row.Cells("Idline").Value)
                        Try

                            Try

                                abrir()
                                cmd = New SqlCommand("eliminar_grupos", conexion)
                                cmd.CommandType = 4

                                cmd.Parameters.AddWithValue("@id", onekey)

                                cmd.ExecuteNonQuery()
                                Cerrar()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try

                        Catch ex As Exception : MsgBox(ex.Message)

                        End Try

                    Next

                    txtgrupo.Text = "GENERAL"
                    mostrar_grupos()
                    idgrupo = datalistadoGrupos.SelectedCells.Item(2).Value
                    datalistadoGrupos.Visible = True



                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If



        End If
        If e.ColumnIndex = Me.datalistadoGrupos.Columns.Item("EditarG").Index Then




            Try
                idgrupo = datalistadoGrupos.SelectedCells.Item(2).Value
                TxtGrupoRegistro.Text = datalistadoGrupos.SelectedCells.Item(3).Value
                If TxtGrupoRegistro.Text = "General" Then
                    MessageBox.Show("Este Grupo esta ingresado por Defecto y no Se puede Editar")
                Else
                    TxtGrupoRegistro.SelectAll()
                    TxtGrupoRegistro.Focus()
                    datalistadoGrupos.Visible = False
                    PanelGrupo.Visible = True
                    BtnGuardar_grupo.Visible = False
                    BtnGuardarCambios.Visible = True

                    PanelGrupo.Visible = True
                    PanelGrupo.Size = New Point(1311, 284)
                    PanelGrupo.Location = New Point(13, 194)
                End If

            Catch ex As Exception
            End Try

        End If
        If e.ColumnIndex = Me.datalistadoGrupos.Columns.Item("Grupo").Index Then
            idgrupo = datalistadoGrupos.SelectedCells.Item(2).Value
            txtgrupo.Text = datalistadoGrupos.SelectedCells.Item(3).Value

            BtnGuardar_grupo.Visible = False
            BtnGuardarCambios.Visible = False
            datalistadoGrupos.Visible = False
            PanelcodigodeBarras.Visible = True
            If lblEstadoCodigo.Text = "NUEVO" Then
                GENERAR_CODIGO_DE_BARRAS_AUTOMATICO()
            End If
        End If

    End Sub



    Private Sub txtgrupo_Click(sender As Object, e As EventArgs) Handles txtgrupo.Click
        txtgrupo.SelectAll()
        txtgrupo.Focus()
        datalistadoGrupos.Visible = True
        mostrar_grupos()
        PanelcodigodeBarras.Visible = False


    End Sub

    Private Sub txtPorcentajeGanancia_TextChanged(sender As Object, e As EventArgs) Handles txtPorcentajeGanancia.TextChanged
        TimerCalucular_porcentaje_ganancia.Stop()

        TimerCalcular_precio_venta.Start()
        TimerCalucular_porcentaje_ganancia.Stop()
    End Sub

    Private Sub txtPorcentajeGanancia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentajeGanancia.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            ' 
            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(txtPorcentajeGanancia, e)
    End Sub

    Private Sub lblmoneda_Click(sender As Object, e As EventArgs) Handles lblmoneda.Click

    End Sub

    Private Sub MenuStrip15_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip15.ItemClicked

    End Sub

    Private Sub btnGenerarCodigo_Click(sender As Object, e As EventArgs) Handles btnGenerarCodigo.Click
        GENERAR_CODIGO_DE_BARRAS_AUTOMATICO()
    End Sub
    Sub GENERAR_CODIGO_DE_BARRAS_AUTOMATICO()
        txtcodigodebarras.Text = ""
        Try
            Dim importe As Double
            Dim com As New SqlCommand("SELECT max(Id_Producto1)  FROM Producto1", conexion)
            Try
                abrir()
                importe = (com.ExecuteScalar()) 'asignamos el valor del importe
                Cerrar()
            Catch ex As Exception
            End Try
            txtcodigodebarras.Text = importe + 1

        Catch ex As Exception
            txtcodigodebarras.Text = 1
        End Try

        Dim Cadena As String = txtgrupo.Text
        Dim Palabra() As String
        Palabra = Cadena.Split(" ")
        Try
            txtcodigodebarras.Text = txtcodigodebarras.Text & Palabra(0).Substring(0, 2) & 369
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub txtbusca_Click(sender As Object, e As EventArgs) Handles txtbusca.Click
        txtbusca.SelectAll()

    End Sub

    Private Sub acciones_para_aumentar_stock_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles acciones_para_aumentar_stock.Opening

    End Sub

    Private Sub PANELDEPARTAMENTO_Paint(sender As Object, e As PaintEventArgs) Handles PANELRegistro.Paint

    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs)
        Dispose()
        PANEL_CONFIGURACIONES.panel_PARA_MOSTRAR_FORMULARIOS.Visible = False

    End Sub

    Private Sub btn_Sig_Click(sender As Object, e As EventArgs) Handles btn_Sig.Click
        Try
            paginaInicio.Text += 10
            paginaMaxima.Text += 10
            Listar()
            Label51.Text = lblcantidad_productos.Text
            If lblcantidad_productos.Text > paginaMaxima.Text Then
                btn_Sig.Visible = True
                btn_atras.Visible = True
            Else
                btn_Sig.Visible = False
                btn_atras.Visible = True
            End If
            'contar_cantidad_de_grupos()
            'If cantidad_grupos > paginaMaxima.Text Then
            '    dibujar_boton_atras_grupos()
            '    dibujar_boton_siguiente_grupo()
            'Else
            '    Panel_grupos.Controls.Remove(PaginadorSiguiente)
            '    dibujar_boton_atras_grupos()
            'End If
            paginar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_Previo_Click(sender As Object, e As EventArgs) Handles btn_atras.Click
        paginaInicio.Text -= 10
        paginaMaxima.Text -= 10
        Listar()
        Label51.Text = lblcantidad_productos.Text
        If lblcantidad_productos.Text > paginaMaxima.Text Then
            btn_Sig.Visible = True
            btn_atras.Visible = True
        Else
            btn_Sig.Visible = False
            btn_atras.Visible = True
        End If

        If paginaInicio.Text = 1 Then
            btn_Sig.Visible = True
            btn_atras.Visible = False

        End If
        paginar()
    End Sub
    Sub ultima_pagina()
        paginaMaxima.Text = lbl_totalPaginas.Text * 10
        paginaInicio.Text = paginaMaxima.Text - 9
        Listar()
        If lblcantidad_productos.Text > paginaMaxima.Text Then
            btn_Sig.Visible = True
            btn_atras.Visible = False
        Else
            btn_Sig.Visible = False
            btn_atras.Visible = True
        End If
        paginar()
    End Sub
    Private Sub btn_Ultima_Click(sender As Object, e As EventArgs) Handles btn_Ultima.Click

        ultima_pagina()
    End Sub

    Private Sub btn_Primera_Click(sender As Object, e As EventArgs) Handles btn_Primera.Click
        mostrar_datos_al_inicio()
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        mostrar_datos_al_inicio()
    End Sub

    Private Sub BtnGuardarCambios_Click_1(sender As Object, e As EventArgs) Handles BtnGuardarCambios.Click
        editar_grupo()
    End Sub

    Private Sub Inventarios_CheckedChanged(sender As Object, e As EventArgs) Handles Inventarios.CheckedChanged
        If Inventarios.Checked = True Then
            PANELINVENTARIO.Visible = True
            LOTES.Visible = True
        Else
            PANELINVENTARIO.Visible = False
            LOTES.Visible = False
            If idproducto <> 0 Then
                validar_stock()
            End If

        End If

    End Sub
    Sub validar_stock()
        If txtstock2.Text = "" Then txtstock2.Text = 0
        Try
            If idproducto <> 0 And txtstock2.Text * 1 > 0 Then
                Dim result2 As DialogResult
                result2 = MessageBox.Show("Hay Aun En Stock, Dirijete al Modulo Inventarios para Ajustar el Inventario a cero", "Stock Existente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            End If
            PANELINVENTARIO.Visible = True
            Inventarios.Checked = True
        Catch ex As Exception

        End Try

        Try
            If idproducto <> 0 And txtstock2.Text * 1 = 0 Then
                Dim CMD As SqlCommand
                Try
                    abrir()
                    CMD = New SqlCommand("editar_Producto1_SIN_CONTROL_DE_INVENTARIO", conexion)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.AddWithValue("@Id_Producto1", idproducto)
                    CMD.Parameters.AddWithValue("@Stock", "Ilimitado")
                    CMD.Parameters.AddWithValue("@Stock_minimo", 0)
                    CMD.Parameters.AddWithValue("@Usa_inventarios", "NO")
                    CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA")
                    CMD.ExecuteNonQuery()
                    Cerrar()
                    TimerApagado.Start()
                    txtstock2.Text = 0
                    txtstockminimo.Text = 0
                    No_aplica_fecha.Checked = False
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If datalistadoLOTES.RowCount <= 1 Then
            If Funcion = "EDITAR" Then
                editar_estado_quitar_lotes()
            End If
            PanelVerLotes.Visible = False
            LOTES.Checked = False
        Else
            MessageBox.Show("Solo debes tener 1 producto para poder Inhabilitar el control de LOTES", "Hay mas de 1 Producto")
        End If


    End Sub

    Private Sub LOTES_CheckedChanged(sender As Object, e As EventArgs) Handles LOTES.CheckedChanged
        If LOTES.Checked = True Then
            If Funcion = "EDITAR" Then
                editar_estado_agregar_lotes()
                mostrar_Producto_por_lote()
                'If datalistadoLOTES.RowCount > 1 Then

                'End If

            End If
            visualizar_panel_lotes()
        End If
    End Sub
    Sub editar_estado_agregar_lotes()
        Try
            abrir()
            Dim cmd As SqlCommand = New SqlCommand("editar_estado_agregar_lotes", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idproducto", idproducto)
            cmd.ExecuteNonQuery()
            Cerrar()
            controlar_stock_sin_lotes()
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try
    End Sub
    Sub visualizar_panel_lotes()
        PanelVerLotes.Visible = True
        PanelVerLotes.Location = New Point(PanelcodigodeBarras.Location.X, PanelcodigodeBarras.Location.Y)
        PanelVerLotes.Size = New Point(724, 274)
        PanelVerLotes.BringToFront()

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        panelAgregarLotes.Visible = True
        panelAgregarLotes.Location = New Point(PanelcodigodeBarras.Location.X, PanelcodigodeBarras.Location.Y)
        panelAgregarLotes.Size = New Point(724, 274)
        panelAgregarLotes.BringToFront()
        txtStockLote.Clear()
        txtStockMinimoLote.Clear()
        GENERAR_CODIGO_DE_BARRAS_AUTOMATICO_LOTES()
    End Sub

    Private Sub ToolStripMenuItem21_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        GENERAR_CODIGO_DE_BARRAS_AUTOMATICO_LOTES()
    End Sub
    Sub GENERAR_CODIGO_DE_BARRAS_AUTOMATICO_LOTES()
        txtcodigodebarras.Text = ""
        Try
            Dim importe As Double
            Dim com As New SqlCommand("SELECT max(Id_Producto1)  FROM Producto1", conexion)
            Try
                abrir()
                importe = (com.ExecuteScalar()) 'asignamos el valor del importe
                Cerrar()
            Catch ex As Exception
            End Try
            txtCodigoLote.Text = importe + 1

        Catch ex As Exception
            txtCodigoLote.Text = 1
        End Try

        Dim Cadena As String = txtgrupo.Text
        Dim Palabra() As String
        Palabra = Cadena.Split(" ")
        Try
            txtCodigoLote.Text = txtCodigoLote.Text & Palabra(0).Substring(0, 2) & 369
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        panelAgregarLotes.Visible = False
    End Sub

    Private Sub btnAgregarLote_Click(sender As Object, e As EventArgs) Handles btnAgregarLote.Click, btnGuardarcambioCodigoLote.Click
        Estado_control_de_lotes = "SI"
        txtstockminimo.Text = txtStockMinimoLote.Text
        txtstock2.Text = txtStockLote.Text
        No_aplica_fecha.Checked = False
        txtfechaoka.Text = txtFechaLote.Text
        If txtpreciomayoreo.Text = "" Then txtpreciomayoreo.Text = 0
        If txtapartirde.Text = "" Then txtapartirde.Text = 0
        TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text & " ", "")
        TXTPRECIODEVENTA2.Text = Format(CType(TXTPRECIODEVENTA2.Text, Decimal), "##0.00")
        If (txtpreciomayoreo.Text * 1 > 0 And txtapartirde.Text * 1 > 0) Or (txtpreciomayoreo.Text * 1 = 0 And txtapartirde.Text * 1 = 0) Then
            If txtcosto.Text * 1 >= TXTPRECIODEVENTA2.Text * 1 Then

                Dim result As DialogResult
                result = MessageBox.Show("El precio de Venta es menor que el COSTO, Esto Te puede Generar Perdidas", "Producto con Perdidas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                If result = DialogResult.OK Then
                    insertar_Producto_por_lotes()
                Else
                    TXTPRECIODEVENTA2.Focus()
                End If


            ElseIf txtcosto.Text * 1 < TXTPRECIODEVENTA2.Text * 1 Then
                insertar_Producto_por_lotes()
            End If
        ElseIf txtpreciomayoreo.Text * 1 <> 0 Or txtapartirde.Text * 1 <> 0 Then
            MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

        End If

    End Sub
    Sub mostrar_Producto_por_lote()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("mostrar_Producto_por_lote", conexion)
        Try
            abrir()
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text)
            da.Fill(dt)
            datalistadoLOTES.DataSource = dt
            Cerrar()
            datalistadoLOTES.Columns(1).Visible = False
            datalistadoLOTES.Columns(6).Visible = False
            datalistadoLOTES.Columns(9).Visible = False
            datalistadoLOTES.Columns(10).Visible = False
            datalistadoLOTES.Columns(11).Visible = False
        Catch ex As Exception
        End Try
        Multilinea(datalistadoLOTES)
    End Sub
    Sub insertar_Producto_por_lotes()
        If txtpreciomayoreo.Text = 0 Or txtpreciomayoreo.Text = "" Then txtapartirde.Text = 0



        Dim CMD As SqlCommand
        Try
            abrir()

            CMD = New SqlCommand("insertar_Producto_por_lotes", conexion)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text)
            CMD.Parameters.AddWithValue("@Imagen", ".")
            CMD.Parameters.AddWithValue("@Precio_de_compra", txtcosto.Text)
            CMD.Parameters.AddWithValue("@Precio_de_venta", TXTPRECIODEVENTA2.Text)
            CMD.Parameters.AddWithValue("@Codigo", txtCodigoLote.Text)
            CMD.Parameters.AddWithValue("@A_partir_de", txtapartirde.Text)

            If txtigv.Checked = True Then
                CMD.Parameters.AddWithValue("@Impuesto", txtnumeroigv.Text)
            End If
            If txtigv.Checked = False Then
                CMD.Parameters.AddWithValue("@Impuesto", 0)
            End If

            CMD.Parameters.AddWithValue("@Precio_mayoreo", txtpreciomayoreo.Text)



            If porunidad.Checked = True Then txtse_vende_a.Text = "Unidad"
            If agranel.Checked = True Then txtse_vende_a.Text = "Granel"

            CMD.Parameters.AddWithValue("@Se_vende_a", txtse_vende_a.Text)
            CMD.Parameters.AddWithValue("@Id_grupo", idgrupo)
            CMD.Parameters.AddWithValue("@Usa_inventarios", "SI")
            CMD.Parameters.AddWithValue("@Stock_minimo", txtStockMinimoLote.Text)
                CMD.Parameters.AddWithValue("@Stock", txtStockLote.Text)
            CMD.Parameters.AddWithValue("@Fecha_de_vencimiento", txtFechaLote.Text)
            CMD.Parameters.AddWithValue("@Fecha", Now())
            CMD.Parameters.AddWithValue("@Motivo", "Registro inicial de Producto")
            CMD.Parameters.AddWithValue("@Cantidad ", txtStockLote.Text)
            CMD.Parameters.AddWithValue("@Id_usuario", idusuario)
            CMD.Parameters.AddWithValue("@Tipo", "ENTRADA")
            CMD.Parameters.AddWithValue("@Estado", "CONFIRMADO")
            CMD.Parameters.AddWithValue("@Id_caja", idcaja)
            CMD.Parameters.AddWithValue("@Manejo_de_lotes", "SI")
            CMD.ExecuteNonQuery()
            Cerrar()
            REGISTRO_correcto_para_lotes()



        Catch ex As Exception
            MsgBox(ex.Message + " " + ex.StackTrace)
        End Try
    End Sub
    Sub REGISTRO_correcto_para_lotes()
        CORRECTO()
        Timer3.Start()
        mostrar_Producto_por_lote()
        panelAgregarLotes.Visible = False

        txtdescripcion.Enabled = False
        txtgrupo.Enabled = False
        porunidad.Enabled = False
        agranel.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        'REGISTRO_correcto_para_1_solo_producto()
        Estado_control_de_lotes = "NO"

        If txtpreciomayoreo.Text = "" Then txtpreciomayoreo.Text = 0
        If txtapartirde.Text = "" Then txtapartirde.Text = 0
        TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text & " ", "")
        TXTPRECIODEVENTA2.Text = Format(CType(TXTPRECIODEVENTA2.Text, Decimal), "##0.00")
        If (txtpreciomayoreo.Text * 1 > 0 And txtapartirde.Text * 1 > 0) Or (txtpreciomayoreo.Text * 1 = 0 And txtapartirde.Text * 1 = 0) Then


            If txtcosto.Text * 1 > TXTPRECIODEVENTA2.Text * 1 Then
                Dim result As DialogResult
                result = MessageBox.Show("El precio de Venta es menor que el COSTO, Esto Te puede Generar Perdidas", "Producto con Perdidas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                If result = DialogResult.OK Then

                    editar_Producto1_lotizados()


                Else
                    TXTPRECIODEVENTA2.Focus()
                End If



            ElseIf txtcosto.Text * 1 <= TXTPRECIODEVENTA2.Text * 1 Then

                editar_Producto1_lotizados()

            End If
        ElseIf txtpreciomayoreo.Text * 1 <> 0 Or txtapartirde.Text * 1 <> 0 Then
            MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

        End If

    End Sub

    Private Sub datalistadoLOTES_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoLOTES.CellContentClick

    End Sub
    Sub obtener_datos_para_editar_codigo_de_lote()
        Try
            idproducto = datalistadoLOTES.SelectedCells.Item(1).Value
            txtCodigoLote.Text = datalistadoLOTES.SelectedCells.Item(2).Value
            txtFechaLote.Value = datalistadoLOTES.SelectedCells.Item(4).Value
            panelAgregarLotes.Visible = True
            panelAgregarLotes.Location = New Point(PanelcodigodeBarras.Location.X, PanelcodigodeBarras.Location.Y)
            panelAgregarLotes.Size = New Point(724, 274)
            panelAgregarLotes.BringToFront()
            btnAgregarLote.Visible = False
            btnGuardarcambioCodigoLote.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub datalistadoLOTES_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoLOTES.CellDoubleClick
        obtener_datos_para_editar_codigo_de_lote()

    End Sub

    Private Sub datalistado_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellEndEdit

    End Sub

    Private Sub datalistadoLOTES_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoLOTES.CellClick
        If e.ColumnIndex = Me.datalistadoLOTES.Columns.Item("EditarLote").Index Then
            obtener_datos_para_editar_codigo_de_lote()

        End If
    End Sub
End Class