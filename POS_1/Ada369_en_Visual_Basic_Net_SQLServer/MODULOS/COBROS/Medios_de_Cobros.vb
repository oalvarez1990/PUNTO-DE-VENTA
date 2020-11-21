Imports System.Data.SqlClient
Imports System.Management
Public Class Medios_de_Cobros
    Dim indicador_de_tipo_de_pago_string As String
    Private Sub TXTPAGOCON_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtefectivo2.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            ' 
            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        Separador_de_Numeros(txtefectivo2, e)
    End Sub

    Private Sub TXTPAGOCON_TextChanged(sender As Object, e As EventArgs) Handles txtefectivo2.TextChanged
        calcular_restante()
    End Sub
    Sub calcular_restante()
        Try
            Dim efectivo As Double
            Dim tarjeta As Double



            If txtefectivo2.Text = "" Then efectivo = 0 Else efectivo = txtefectivo2.Text

            If txttarjeta2.Text = "" Then tarjeta = 0 Else tarjeta = txttarjeta2.Text

            If txtefectivo2.Text = "0.00" Then efectivo = 0

            If txttarjeta2.Text = "0.00" Then tarjeta = 0

            If txtefectivo2.Text = "." Then efectivo = 0



            Try
                If efectivo > (txt_total_suma.Text * 1) Then
                    TXTVUELTO.Text = efectivo - txt_total_suma.Text * 1
                    efectivo_calculado.Text = efectivo - TXTVUELTO.Text * 1

                Else
                    TXTVUELTO.Text = 0
                    efectivo_calculado.Text = efectivo

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            Try
                txtrestante.Text = txt_total_suma.Text * 1 - efectivo_calculado.Text * 1 - tarjeta
                txtrestante.Text = Format(CType(txtrestante.Text, Decimal), "##0.00")
            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try


    End Sub
    Private Sub txttarjeta2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttarjeta2.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            ' 
            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        Separador_de_Numeros(txttarjeta2, e)
    End Sub

    Private Sub txttarjeta2_TextChanged(sender As Object, e As EventArgs) Handles txttarjeta2.TextChanged
        calcular_restante()
    End Sub

    Private Sub TXTVUELTO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTVUELTO.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            ' 
            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        Separador_de_Numeros(TXTVUELTO, e)
    End Sub

    Private Sub TXTVUELTO_TextChanged(sender As Object, e As EventArgs) Handles TXTVUELTO.TextChanged

    End Sub
    Dim txttotal_saldo As Double
    Dim idcliente As Integer
    Dim idcaja As Integer
    Dim idusuario As Integer
    Public id_usuario As Integer
    Sub mostrar_inicio_De_sesion()
        Try

            Dim com As New SqlCommand("mostrar_inicio_De_sesion", conexion)
            com.CommandType = 4
            com.Parameters.AddWithValue("@id_serial_pc", Encriptar(lblIdSerial.Text))

            Try
                abrir()
                id_usuario = (com.ExecuteScalar())

                Cerrar()

            Catch ex As Exception


            End Try

        Catch ex As Exception

        End Try


    End Sub
    Sub mostrar_caja()

        MOSTRAR_CAJA_POR_SERIAL()

    End Sub
    Sub MOSTRAR_CAJA_POR_SERIAL()


        'Dim dt As New DataTable

        'Dim da As SqlDataAdapter
        'Try
        '    abrir()
        '    da = New SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", conexion)
        '    da.SelectCommand.CommandType = 4
        '    da.SelectCommand.Parameters.AddWithValue("@Serial", Encriptar(lblIdSerial.Text))

        '    da.Fill(dt)
        '    datalistado_caja.DataSource = dt
        '    Cerrar()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & "FALLO MOSTRAR_CAJA_POR_SERIAL")

        'End Try
        Try

            Dim com As New SqlCommand("mostrar_cajas_por_Serial_de_DiscoDuro", conexion)
            com.CommandType = 4
            com.Parameters.AddWithValue("@Serial", Encriptar(lblIdSerial.Text))

            Try
                abrir()
                idcaja = (com.ExecuteScalar())

                Cerrar()

            Catch ex As Exception


            End Try

        Catch ex As Exception

        End Try

    End Sub
    Sub mostrar_detalle_de_venta_desde_el_medio_De_pago()
        PanelImpresionvistaprevia.Visible = True
        PanelImpresionvistaprevia.Dock = DockStyle.Fill
        Dim rptFREPORT2 As New Comproante_de_cobro()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try
            abrir()
            daMA = New SqlDataAdapter("mostrar_detalle_de_cobro_para_Imprimir", conexion)
            daMA.SelectCommand.CommandType = 4
            daMA.SelectCommand.Parameters.AddWithValue("@id_caja", idcaja)
            daMA.SelectCommand.Parameters.AddWithValue("@monto", montoAbonado)

            daMA.Fill(dtMA)
            Cerrar()
            rptFREPORT2 = New Comproante_de_cobro
            'rptFREPORT2.Table1.DataSource = dtMA
            rptFREPORT2.DataSource = dtMA

            ReportViewer1.Report = rptFREPORT2
            ReportViewer1.RefreshReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Medios_de_Cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIdSerial.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIdSerial.Text = lblIdSerial.Text.Trim()

        txttotal_saldo = cobro_a_clientes.txttotal_saldo.Text
        TXTTOTAL.Text = cobro_a_clientes.txttotal_saldo.Text
        txt_total_suma.Text = TXTTOTAL.Text
        idcliente = cobro_a_clientes.idcliente
        TXTVUELTO.Text = 0
        txtefectivo2.Clear()
        txttarjeta2.Clear()

        mostrar_caja()
        mostrar_inicio_De_sesion()
    End Sub
    Private Sub btn0_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "0"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "0"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "0"
        End If
        MenuStrip15.Focus()

    End Sub
    Dim INDICAR_DE_FOCO As Integer

    Private Sub btn1_Click(sender As Object, e As EventArgs)

        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "1"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "1"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "1"
        End If

        MenuStrip15.Focus()




    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "2"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "2"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "2"
        End If
        MenuStrip15.Focus()

    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "3"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "3"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "3"
        End If
        MenuStrip15.Focus()

    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "4"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "4"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "4"
        End If
        MenuStrip15.Focus()

    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "5"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "5"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "5"
        End If
        MenuStrip15.Focus()

    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "6"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "6"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "6"
        End If
        MenuStrip15.Focus()

    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "7"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "7"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "7"
        End If
        MenuStrip15.Focus()

    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "8"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "8"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "8"
        End If
        MenuStrip15.Focus()

    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Text = txtefectivo2.Text & "9"
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Text = txttarjeta2.Text & "9"
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Text = TXTVUELTO.Text & "9"
        End If
        MenuStrip15.Focus()

    End Sub
    Dim SECUENCIA As Boolean = True
    Private Sub btnborrarderecha_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            If SECUENCIA = True Then
                txtefectivo2.Text = txtefectivo2.Text & "."
                SECUENCIA = False
            Else
                Return

            End If
        ElseIf INDICAR_DE_FOCO = 2 Then
            If SECUENCIA = True Then
                txttarjeta2.Text = txttarjeta2.Text & "."
                SECUENCIA = False
            Else
                Return

            End If
        ElseIf INDICAR_DE_FOCO = 3 Then
            If SECUENCIA = True Then
                TXTVUELTO.Text = TXTVUELTO.Text & "."
                SECUENCIA = False
            Else
                Return

            End If
        End If


        MenuStrip15.Focus()




    End Sub

    Private Sub btnborrartodo_Click(sender As Object, e As EventArgs)
        If INDICAR_DE_FOCO = 1 Then
            txtefectivo2.Clear()
            SECUENCIA = True
        ElseIf INDICAR_DE_FOCO = 2 Then
            txttarjeta2.Clear()
            SECUENCIA = True
        ElseIf INDICAR_DE_FOCO = 3 Then
            TXTVUELTO.Clear()
            SECUENCIA = True
        End If
        MenuStrip15.Focus()
    End Sub

    'Private Sub TXTEFECTIVO_Click(sender As Object, e As EventArgs) Handles txtefectivo2.Click
    '    INDICAR_DE_FOCO = 1

    '    txttarjeta2.Clear()
    '    txtefectivo2.Text = txttotal_saldo
    'End Sub

    'Private Sub txttarjeta_Click(sender As Object, e As EventArgs) Handles txttarjeta2.Click
    '    INDICAR_DE_FOCO = 2
    '    txtefectivo2.Clear()
    '    txttarjeta2.Text = txttotal_saldo
    'End Sub
    Dim tipo_de_cobro As String
    Sub insertar_detalle_cobro_a_cliente()
        If txtefectivo2.Text <> 0 Then
            Try
                Dim cmd As New SqlCommand
                abrir()
                cmd = New SqlCommand("insertar_DETALLE_CONTROL_DE_COBROS", conexion)
                cmd.CommandType = 4

                cmd.Parameters.AddWithValue("@Id_usuario", id_usuario)
                cmd.Parameters.AddWithValue("@Pago_realizado", txtefectivo2.Text)
                cmd.Parameters.AddWithValue("@Fecha_que_pago", Now())
                cmd.Parameters.AddWithValue("@Tipo_de_cobro", "EFECTIVO")
                cmd.Parameters.AddWithValue("@idcliente", idcliente)
                cmd.Parameters.AddWithValue("@Detalle", "COBRO")
                cmd.Parameters.AddWithValue("@Id_caja", idcaja)
                cmd.ExecuteNonQuery()
                Cerrar()
                'cobrar_a_cliente()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            If txttarjeta2.Text <> 0 Then
                Try
                    Dim cmd As New SqlCommand
                    abrir()
                    cmd = New SqlCommand("insertar_DETALLE_CONTROL_DE_COBROS", conexion)
                    cmd.CommandType = 4

                    cmd.Parameters.AddWithValue("@Id_usuario", id_usuario)
                    cmd.Parameters.AddWithValue("@Pago_realizado", txttarjeta2.Text)
                    cmd.Parameters.AddWithValue("@Fecha_que_pago", Now())
                    cmd.Parameters.AddWithValue("@Tipo_de_cobro", "TARJETA")
                    cmd.Parameters.AddWithValue("@idcliente", idcliente)
                    cmd.Parameters.AddWithValue("@Detalle", "COBRO")
                    cmd.Parameters.AddWithValue("@Id_caja", idcaja)
                    cmd.ExecuteNonQuery()
                    Cerrar()
                    'cobrar_a_cliente()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        End If
        cobrar_a_cliente()

    End Sub

    Dim montoAbonado As Double
    Dim monto As Double
    Sub completar_con_ceros_los_texbox_de_otros_medios_de_pago()
        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0

        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0
        If TXTVUELTO.Text = "" Then TXTVUELTO.Text = 0
        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0

        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0
        If TXTVUELTO.Text = "" Then TXTVUELTO.Text = 0

        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0

        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0
    End Sub
    Private Sub tGUARDAR_Click(sender As Object, e As EventArgs) Handles tGUARDAR.Click
        'identificar_el_tipo_de_pago()
        completar_con_ceros_los_texbox_de_otros_medios_de_pago()
        montoAbonado = txtefectivo2.Text * 1 + txttarjeta2.Text * 1

        If montoAbonado <= TXTTOTAL.Text * 1 And montoAbonado <> 0 Then
            insertar_detalle_cobro_a_cliente()

        Else
            Dim result As DialogResult
            result = MessageBox.Show("Exeso de Cobro", "Exeso de Cobro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        ''''Dim efectivo As Double
        ''''Dim tarjeta As Double



        ''''If txtefectivo2.Text = "" Then efectivo = 0 Else efectivo = txtefectivo2.Text
        ''''If txttarjeta2.Text = "" Then tarjeta = 0 Else tarjeta = txttarjeta2.Text

        ''''If txtefectivo2.Text = "." Then efectivo = 0
        ''''If txttarjeta2.Text = "." Then tarjeta = 0
        ''''Try


        ''''    If tarjeta = 0 Then
        ''''        tipo_de_cobro = "EFECTIVO"
        ''''        If efectivo > monto Then
        ''''            montoAbonado = efectivo - TXTVUELTO.Text * 1
        ''''            monto = txttotal_saldo
        ''''        ElseIf efectivo <= monto Then
        ''''            montoAbonado = efectivo
        ''''            monto = txttotal_saldo
        ''''        End If
        ''''    ElseIf efectivo = 0
        ''''        tipo_de_cobro = "TARJETA"

        ''''        montoAbonado = tarjeta
        ''''        monto = txttotal_saldo
        ''''    End If


        ''''    If monto >= montoAbonado Then
        ''''        insertar_detalle_cobro_a_cliente()


        ''''    Else
        ''''        MessageBox.Show("Exedes el Monto a pagar", "Saldo en 0", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ''''    End If
        ''''Catch ex As Exception
        ''''    MessageBox.Show(ex.Message)
        ''''End Try
        '''''mostrar_DETALLE_CONTROL_DE_COBROS()
        '''''datalistadoMovimientos.Visible = True
        '''''datalistadoHistorial.Visible = False
        '''''datalistadoHistorial.Dock = DockStyle.None
        '''''datalistadoMovimientos.Dock = DockStyle.Fill
        '''''Panel17.Visible = True
        '''''PanelH.Visible = False
        '''''PanelM.Visible = True
        '''''Timerocultar.Start()

    End Sub
    Sub identificar_el_tipo_de_pago()

        Dim indicadorEfectivo As Integer = 4
        Dim indicadorCredito As Integer = 2
        Dim indicadorTarjeta As Integer = 3

        If txtefectivo2.Text = "" Then txtefectivo2.Text = 0
        If txttarjeta2.Text = "" Then txttarjeta2.Text = 0

        If txtefectivo2.Text = "." Then txtefectivo2.Text = 0
        If txttarjeta2.Text = "." Then txttarjeta2.Text = 0


        If txtefectivo2.Text = 0 Then
            indicadorEfectivo = 0
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
    Sub Saldo()

        Dim importe As Double
        Dim com As New SqlCommand("mostrar_solo_saldo_cliente_proveedor", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id", idcliente)
        Try
            abrir()
            importe = (com.ExecuteScalar())
            Cerrar()
        Catch ex As Exception
        End Try

    End Sub
    Sub cobrar_a_cliente()
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("disminuirSaldocliente", conexion)
            cmd.CommandType = 4

            cmd.Parameters.AddWithValue("@Id_cliente", idcliente)
            cmd.Parameters.AddWithValue("@montopagado", montoAbonado)
            cmd.ExecuteNonQuery()
            Cerrar()
            'mostrar_detalle_de_venta_desde_el_medio_De_pago()
            'Saldo()
            cobro_a_clientes.Saldo()
            ReportViewer1.Visible = True
            ReportViewer1.Dock = DockStyle.Fill
            cobro_a_clientes.mostrar_DETALLE_CONTROL_DE_COBROS()

            mostrar_detalle_de_venta_desde_el_medio_De_pago()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs)
        PanelImpresionvistaprevia.Visible = False
    End Sub

    Private Sub Medios_de_Cobros_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        cobro_a_clientes.TimerSUMAR_SALDO.Start()
        Dispose()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub
End Class