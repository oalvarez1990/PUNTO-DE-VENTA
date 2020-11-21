
Imports System.Data.SqlClient
Imports System.Management
Imports System.Configuration
Imports System.Xml
Imports System.IO
Public Class DASHBOARD_PRINCIPAL
    Private aes As New AES()
    Dim año As Integer
    Dim mes As String
    Dim monto As Double
    Dim descripcion As String
    Dim Tipo As String
    Dim mesgasto As String
    Dim montogasto As Double

    Dim eneroI As Double = 0
    Dim febreroI As Double = 0
    Dim marzoI As Double = 0
    Dim abrilI As Double = 0
    Dim mayoI As Double = 0
    Dim junioI As Double = 0
    Dim julioI As Double = 0
    Dim agostoI As Double = 0
    Dim septiembreI As Double = 0
    Dim octubreI As Double = 0
    Dim noviembreI As Double = 0
    Dim diciembreI As Double = 0

    Dim eneroG As Double = 0
    Dim febreroG As Double = 0
    Dim marzoG As Double = 0
    Dim abrilG As Double = 0
    Dim mayoG As Double = 0
    Dim junioG As Double = 0
    Dim julioG As Double = 0
    Dim agostoG As Double = 0
    Dim septiembreG As Double = 0
    Dim octubreG As Double = 0
    Dim noviembreG As Double = 0
    Dim diciembreG As Double = 0
    Dim id_usuario As Integer
    Dim temporizador As Integer
    Public moneda As String
    Dim TotaldeNotificaciones As Integer
    Dim ContarNOTIFICADOR_PRODUCTO_VENCIDOS As Integer
    Sub Listar_ventaspor_mes()
        Dim fecha As ArrayList = New ArrayList
        Dim monto As ArrayList = New ArrayList
        Dim dr As SqlDataReader
        Dim cmd As SqlCommand
        Try
            abrir()
            cmd = New SqlCommand("mostrar_ventas_realizadas", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            dr = cmd.ExecuteReader()
            While (dr.Read())
                fecha.Add(dr.GetString(0))
                monto.Add(dr.GetString(1))
            End While
            ChartVENTAS.Series(0).Points.DataBindXY(fecha, monto)
            dr.Close()
            Cerrar()
            Dim importe As Double
            Dim com As New SqlCommand

            com = New SqlCommand("select CONVERT(NUMERIC(18,1),sum( Monto_total)) FROM dbo.ventas where ACCION= 'VENTA' and MONTH ( fecha_venta) = MONTH (GETDATE())", conexion)

            Try
                abrir()
                importe = (com.ExecuteScalar())
                Cerrar()

                txtventas.Text = importe
            Catch ex As Exception
                txtventas.Text = 0
            End Try


            Dim importe2 As Double
            Dim com2 As New SqlCommand

            com2 = New SqlCommand("select CONVERT(NUMERIC(18,1),sum( Ganancia )) FROM   dbo.detalle_venta INNER JOIN ventas on VENTAS.idventa=detalle_venta.idventa where ACCION= 'VENTA' and Monto_total>0 and MONTH ( fecha_venta) = MONTH (GETDATE())", conexion)

            Try
                abrir()
                importe2 = (com2.ExecuteScalar())
                Cerrar()
                lblgananciasok.Text = importe2
            Catch ex As Exception
                lblgananciasok.Text = 0
            End Try


        Catch ex As Exception
            lblgananciasok.Text = 0
        End Try

    End Sub
    Sub Listar_ventas_POR_FECHA()
        Dim fecha As ArrayList = New ArrayList
        Dim monto As ArrayList = New ArrayList
        Dim dr As SqlDataReader
        Dim cmd As SqlCommand
        Try
            abrir()
            cmd = New SqlCommand("mostrar_ventas_realizadas_POR_FECHAS", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@FI", TXTFI.Value)
            cmd.Parameters.AddWithValue("@FF", TXTFF.Value)
            cmd.CommandType = CommandType.StoredProcedure
            dr = cmd.ExecuteReader()
            While (dr.Read())
                fecha.Add(dr.GetString(0))
                monto.Add(dr.GetString(1))
            End While
            ChartVENTAS.Series(0).Points.DataBindXY(fecha, monto)
            dr.Close()
            Cerrar()



            Dim importe As Double
            Dim com As New SqlCommand
            com = New SqlCommand("mostrar_ventas_realizadas_POR_FECHA", conexion)
            com.CommandType = 4
            com.Parameters.AddWithValue("@FI", TXTFI.Value)
            com.Parameters.AddWithValue("@FF", TXTFF.Value)
            Try
                abrir()
                importe = (com.ExecuteScalar()) 'asignamos el valor del importe
                Cerrar()
                txtventas.Text = importe  ' mostramos el importe
            Catch ex As Exception
                txtventas.Text = 0
            End Try


            Dim importe2 As Double
            Dim com2 As New SqlCommand

            com2 = New SqlCommand("MOSTRAR_Ganancias_por_fecha", conexion)
            com2.CommandType = 4
            com2.Parameters.AddWithValue("@FI", TXTFI.Value)
            com2.Parameters.AddWithValue("@FF", TXTFF.Value)
            Try
                abrir()
                importe2 = (com2.ExecuteScalar()) 'asignamos el valor del importe
                Cerrar()
            Catch ex As Exception
            End Try
            lblgananciasok.Text = importe2  ' mostramos el importe

        Catch ex As Exception
            lblgananciasok.Text = 0
        End Try

    End Sub
    Sub mostrar_5_productos_mas_vendidos()
        Dim CANTIDAD As ArrayList = New ArrayList
        Dim PRODUCTO As ArrayList = New ArrayList
        Dim dr As SqlDataReader
        Dim cmd As SqlCommand
        Try
            abrir()
            cmd = New SqlCommand("mostrar_5_productos_mas_vendidos", conexion)
            'da.Fill(dt)
            'Chart1.DataSource = dt
            cmd.CommandType = CommandType.StoredProcedure
            dr = cmd.ExecuteReader()
            While (dr.Read())
                CANTIDAD.Add(dr.GetInt32(0))
                PRODUCTO.Add(dr.GetString(1))
            End While
            Chart3.Series(0).Points.DataBindXY(PRODUCTO, CANTIDAD)

            dr.Close()
            Cerrar()
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LineShape1_Click(sender As Object, e As EventArgs)

    End Sub

    Sub sumar_Cuentas_por_pagar()

        Dim importe As Double
        Dim com As New SqlCommand

        com = New SqlCommand("SUMAR_POR_PAGAR_OK", conexion)

        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
        Catch ex As Exception
        End Try
        lblPorPagar.Text = importe  ' mostramos el importe
        lblPorPagar.Text = moneda & " " & Format(CType(lblPorPagar.Text, Decimal), "##0.00")

    End Sub

    Sub MOSTRAR_Inventarios_bajo_minimo_COUNT()

        Dim importe As Double
        Dim com As New SqlCommand("MOSTRAR_Inventarios_bajo_minimo_COUNT", conexion)


        Try
            abrir()
            importe = (com.ExecuteScalar())
            Cerrar()
        Catch ex As Exception
        End Try
        lblStockBajo.Text = importe & " Producto(s)"



    End Sub
    Sub MOSTRAR_Clientes()
        Dim importe As Double
        Dim com As New SqlCommand("select count(idclientev ) from clientes where Cliente='SI'", conexion)
        Try
            abrir()
            importe = (com.ExecuteScalar())
            Cerrar()
        Catch ex As Exception
        End Try
        lblNclientes.Text = importe & " Cliente(s)"
    End Sub
    Sub MOSTRAR_Productos_Count()
        Dim importe As Double
        Dim com As New SqlCommand("select count(Id_Producto1  ) from Producto1  where Usa_inventarios ='SI'", conexion)
        Try
            abrir()
            importe = (com.ExecuteScalar())
            Cerrar()
        Catch ex As Exception
        End Try
        lblProductos.Text = importe & " Productos"
    End Sub



    Sub SUMAR_VENTAS()

        Dim importe As Double
        Dim com As New SqlCommand

        com = New SqlCommand("sumar_ventas_POR_TURNO", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@FI", TXTFI.Value)
        com.Parameters.AddWithValue("@FF", TXTFF.Value)
        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
        Catch ex As Exception
        End Try
        txtventas.Text = importe  ' mostramos el importe

    End Sub


    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub





    Sub SUMAR_POR_COBRAR_OK()
        Dim importe As Double
        Dim com As New SqlCommand("SUMAR_POR_COBRAR_OK", conexion)
        'com.CommandType = 4
        'com.Parameters.AddWithValue("@FI", TXTFI.Value)
        'com.Parameters.AddWithValue("@FF", TXTFF.Value)
        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
        Catch ex As Exception
        End Try
        TXTPOR_COBRAR.Text = importe  ' mostramos el importe
        TXTPOR_COBRAR.Text = moneda & " " & Format(CType(TXTPOR_COBRAR.Text, Decimal), "##0.00")

    End Sub
    Sub mostrar_moneda()

        Dim com As New SqlCommand("Select Moneda from Empresa", conexion)
        'com.CommandType = 4
        'com.Parameters.AddWithValue("@FI", TXTFI.Value)
        'com.Parameters.AddWithValue("@FF", TXTFF.Value)
        Try
            abrir()
            moneda = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub
    Sub mostrar_gastos_por_año_en_comboboxAño()
        Dim dtunidad As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("mostrar_gastos_por_anio_en_comboboxAnio", conexion)
            DA.Fill(dtunidad)

            txtaño_gasto.DisplayMember = "anio"

            txtaño_gasto.ValueMember = "anio"

            txtaño_gasto.DataSource = dtunidad
        Catch ex As Exception : MessageBox.Show(ex.Message)

        End Try

        Cerrar()

    End Sub
    Sub mostrar_gastos_por_MES_en_comboboxMES()
        Dim dtunidad As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("mostrar_gastos_por_MES_en_comboboxMES", conexion)
            DA.SelectCommand.CommandType = 4
            DA.SelectCommand.Parameters.AddWithValue("@anio", txtaño_gasto.Text)


            DA.Fill(dtunidad)

            txtmes_gasto.DisplayMember = "mes"

            txtmes_gasto.ValueMember = "mes"

            txtmes_gasto.DataSource = dtunidad
        Catch ex As Exception : MessageBox.Show(ex.Message)

        End Try

        Cerrar()

    End Sub
    Sub mostrar_mayores_GASTOS_POR_CONCEPTO_por_año()

        Dim fecha As ArrayList = New ArrayList
        Dim descripcion As ArrayList = New ArrayList

        Dim dr As SqlDataReader
        Dim cmd As SqlCommand
        Try
            abrir()
            cmd = New SqlCommand("mostrar_mayores_GASTOS_POR_CONCEPTO_por_anio", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@anio", txtaño_gasto.Text)

            cmd.CommandType = CommandType.StoredProcedure
            dr = cmd.ExecuteReader()
            While (dr.Read())
                fecha.Add(dr.GetString(0))
                descripcion.Add(dr.GetString(1))
            End While

            ChartGastos_por_año.Series(0).Points.DataBindXY(fecha, descripcion)

            dr.Close()
            Cerrar()
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub mostrar_mayores_GASTOS_POR_CONCEPTO_por_mes_de_año()

        Dim fecha As ArrayList = New ArrayList
        Dim descripcion As ArrayList = New ArrayList

        Dim dr As SqlDataReader
        Dim cmd As SqlCommand
        Try
            abrir()
            cmd = New SqlCommand("mostrar_mayores_GASTOS_POR_CONCEPTO_por_mes_de_anio", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@mes", txtmes_gasto.Text)
            cmd.Parameters.AddWithValue("@anio", txtaño_gasto.Text)

            cmd.CommandType = CommandType.StoredProcedure
            dr = cmd.ExecuteReader()
            While (dr.Read())
                fecha.Add(dr.GetString(0))
                descripcion.Add(dr.GetString(1))
            End While
            Chart4.Series(0).Points.DataBindXY(fecha, descripcion)
            dr.Close()
            Cerrar()
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub restaurar_base_para_versiones_no_express()
        Dim cnn As New SqlConnection("Server=.\;database=master; integrated security=yes")
        cnn.Open()
        Dim DropRes As String = "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'BASEADA' USE [master] ALTER DATABASE [BASEADA] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [BASEADA] RESTORE DATABASE BASEADA FROM DISK = N'" & lblruta.Text & "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10"

        Try

            Dim BorraRestaura As New SqlCommand(DropRes, cnn)
            BorraRestaura.ExecuteNonQuery()

            MessageBox.Show("La base de datos " & Microsoft.VisualBasic.Left(lblruta.Text, lblruta.TextLength - 4) & " ha sido restaurada satisfactoriamente! Vuelve a Iniciar El Aplicativo", "Restauración de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error al restaurar la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Try
    End Sub
    Sub MOSTRAR_licencia_temporal()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("SELECT*FROM Marcan", conexion)

            da.Fill(dt)
            datalistado_licencia_temporal.DataSource = dt
            Cerrar()


        Catch ex As Exception ': MessageBox.Show(ex.Message)
        End Try


    End Sub
    Sub validar_licencia_pro()
        MOSTRAR_licencia_temporal()


        Try

            LBLESTADOLicenciaLocal.Text = Desencriptar(datalistado_licencia_temporal.SelectedCells.Item(4).Value.Trim)
            txtfecha_final_licencia_temporal.Text = Desencriptar(datalistado_licencia_temporal.SelectedCells.Item(3).Value.Trim)

        Catch ex As Exception
        End Try

        If LBLESTADOLicenciaLocal.Text = "?ACTIVADO PRO?" Then
            PanelLicencia.Visible = True
            lblActivando_licencia.Text = "Licencia PROFESIONAL Activada hasta " & txtfecha_final_licencia_temporal.Text
            Button20.Visible = False

        Else
            PanelLicencia.Visible = True
            lblActivando_licencia.Text = "Licencia de Prueba Activada hasta " & txtfecha_final_licencia_temporal.Text
            Button20.Visible = True

        End If



    End Sub

    Private Sub DASHBOARD_PRINCIPAL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Obtener_ip()
        mostrar_moneda()
        chekFiltros.Checked = False
        mostrar_gastos_por_año_en_comboboxAño()
        mostrar_gastos_por_MES_en_comboboxMES()
        Listar_ventaspor_mes()
        mostrar_mayores_GASTOS_POR_CONCEPTO_por_año()
        mostrar_5_productos_mas_vendidos()
        MOSTRAR_Inventarios_bajo_minimo_COUNT()
        MOSTRAR_Clientes()
        MOSTRAR_Productos_Count()
        SUMAR_NOTIFICACIONES()
        limpiar()
        SUMAR_POR_COBRAR_OK()
        sumar_Cuentas_por_pagar()
        Obtener_fecha_actual()
        'Panel4.Location = New Point((Width - Panel4.Width) / 2, 75)
        obtener_serial_pc()
        validar_licencia_pro()
        mostrar_inicio_De_sesion()
        mostrar_usuario_logueado()
    End Sub
    Sub Obtener_ip()
        getIp()
        Me.Text = valorIp
    End Sub
    Sub limpiar()
        Label32.Text = "Total VENTAS " & moneda
        Label6.Text = "Total GANANCIA " & moneda
    End Sub
    Sub Obtener_fecha_actual()
        lblfechaHoy.Text = MonthName(DatePart(DateInterval.Month, Now())) & " " & DatePart(DateInterval.Year, Now())
        Me.lblfechaHoy.Text = UCase(Me.lblfechaHoy.Text)
        lblmes.Text = MonthName(DatePart(DateInterval.Month, Now()))
    End Sub
    Sub obtener_serial_pc()
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())
    End Sub
    Sub mostrar_inicio_De_sesion()


        Dim com As New SqlCommand("mostrar_inicio_De_sesion", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_serial_pc", lblIDSERIAL.Text)

        Try
            abrir()
            id_usuario = (com.ExecuteScalar())
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try

    End Sub
    Sub mostrar_usuario_logueado()

        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_usuario_POR_login", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@id_usuario", id_usuario)
            da.Fill(dt)
            datalistado_usuario_logueado.DataSource = dt
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try
        Try
            ImagenEmpresaTRUE.BackgroundImage = Nothing
            Dim b() As Byte = datalistado_usuario_logueado.SelectedCells.Item(1).Value
            Dim ms As New IO.MemoryStream(b)
            ImagenEmpresaTRUE.Image = Image.FromStream(ms)
            ImagenEmpresaTRUE.SizeMode = PictureBoxSizeMode.StretchImage


        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)

        End Try
    End Sub
    Sub contar_Notificador_cobros()
        Dim importe As Double
        Dim com As New SqlCommand("CONTARNOTIFICADOR_COBROS", conexion)

        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
            lblContarNOTIFICADOR_COBROS.Text = importe
        Catch ex As Exception
            lblContarNOTIFICADOR_COBROS.Text = 0
        End Try
        ' mostramos el importe

    End Sub
    Sub SUMAR_NOTIFICACIONES()
        contar_Notificador_cobros()
        contar_NOTIFICADOR_PAGOS()
        contar_Notificador_productos_vencidos()
        mostrar_correo_base()
        Dim numero_correos As Integer
        If LBLEstado_correo.Text = "SIN CONEXION" Then
            numero_correos = 1
        Else
            numero_correos = 0
        End If
        Try
            TotaldeNotificaciones = numero_correos + lblContarNOTIFICADOR_COBROS.Text * 1 + lblContarNOTIFICADOR_Pagos.Text * 1 + ContarNOTIFICADOR_PRODUCTO_VENCIDOS

            If TotaldeNotificaciones = 0 Then
                LBLnotificaciones.Visible = False
            Else
                LBLnotificaciones.Visible = True
                LBLnotificaciones.Text = TotaldeNotificaciones
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        mostrar_correo_base()
        'MsgBox(TotaldeNotificaciones)
        'MsgBox(ContarNOTIFICADOR_PRODUCTO_VENCIDOS & "produc venci")

    End Sub
    Sub mostrar_correo_base()

        Dim importe As String
        Dim com As New SqlCommand("SELECT Estado_De_envio FROM Correo_base", conexion)

        Try
            abrir()
            importe = (com.ExecuteScalar())
            Cerrar()
            LBLEstado_correo.Text = Desencriptar(importe)
        Catch ex As Exception
            LBLEstado_correo.Text = 0
        End Try

    End Sub

    Sub contar_Notificador_productos_vencidos()
        Dim importe As Double
        Dim com As New SqlCommand("contar_productos_vencidos", conexion)

        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
            ContarNOTIFICADOR_PRODUCTO_VENCIDOS = importe
        Catch ex As Exception
            ContarNOTIFICADOR_PRODUCTO_VENCIDOS = 0
        End Try
        ' mostramos el importe

    End Sub
    Sub contar_NOTIFICADOR_PAGOS()
        Dim importe As Double
        Dim com As New SqlCommand("CONTARNOTIFICADOR_PAGOS", conexion)

        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()
            lblContarNOTIFICADOR_Pagos.Text = importe
        Catch ex As Exception
            lblContarNOTIFICADOR_Pagos.Text = 0
        End Try
        ' mostramos el importe

    End Sub
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub txtaño_gasto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtaño_gasto.SelectedIndexChanged
        mostrar_mayores_GASTOS_POR_CONCEPTO_por_año()
        mostrar_gastos_por_MES_en_comboboxMES()
        mostrar_mayores_GASTOS_POR_CONCEPTO_por_mes_de_año()
    End Sub


    Private Sub txtmes_gasto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtmes_gasto.SelectedIndexChanged
        mostrar_mayores_GASTOS_POR_CONCEPTO_por_mes_de_año()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

        Close()

    End Sub


    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles lblmes.Click
        Listar_ventaspor_mes()
        Panel21.Visible = False

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Listar_ventaspor_mes()
        Panel21.Visible = False
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles TFILTROS.Click
        PanelHoy.Visible = False
        Panel21.Visible = True
        chekFiltros.Checked = True

    End Sub

    Private Sub TXTFI_ValueChanged(sender As Object, e As EventArgs) Handles TXTFI.ValueChanged
        Listar_ventas_POR_FECHA()
    End Sub

    Private Sub TXTFF_ValueChanged(sender As Object, e As EventArgs) Handles TXTFF.ValueChanged
        Listar_ventas_POR_FECHA()
    End Sub

    Private Sub lblfechaHoy_Click(sender As Object, e As EventArgs) Handles lblfechaHoy.Click
        Me.lblfechaHoy.Text = UCase(Me.lblfechaHoy.Text)
        'Me.TextBox1.SelectionStart = Me.TextBox1.TextLength + 1
    End Sub

    Private Sub chekFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chekFiltros.CheckedChanged
        If chekFiltros.Checked = True Then
            PanelHoy.Visible = False
            Panel21.Visible = True
        ElseIf chekFiltros.Checked = False Then
            PanelHoy.Visible = True
            Listar_ventaspor_mes()
            Panel21.Visible = False
        End If
    End Sub
    Sub ocultar_objetos_emergentes()
        PanelCONTENEDOR_herramientas.Visible = False


    End Sub
    Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox18_Click(sender As Object, e As EventArgs) Handles PictureBox18.Click

        Panelcuenta.Visible = False

        PanelCONTENEDORDENOTIFICACIONES.Controls.Clear()
        PanelCONTENEDOR_herramientas.Visible = True
        PanelNOTIFICACIONES.Visible = True
        PanelNOTIFICACIONES.Dock = DockStyle.Top
        PanelCONTENEDOR_herramientas.Location = New Point((Panel14.Location.X - 280), 65)
        'PanelCONTENEDOR_herramientas.Size = New Point(816, 573)


        dibujarCOBROS()
        dibujarPOR_PAGAR()
        dibujarPRODUCTOS_vencidos()
        If LBLEstado_correo.Text = "SIN CONEXION" Then
            dibujarCorreoBase_sin_conexion()
        End If
    End Sub
    Sub dibujarCorreoBase_sin_conexion()



        Dim b As New Label()
        Dim p1 As New Panel
        Dim P2 As New Panel
        Dim I1 As New PictureBox
        Dim I2 As New PictureBox
        Dim L As New Label

        b.Text = "Sincroniza tu correo para recibir Reportes en tu Bandeja de Correo"

        b.Size = New System.Drawing.Size(430, 35)
        b.Font = New System.Drawing.Font(10, 10)
        b.BackColor = BackColor
        b.FlatStyle = FlatStyle.Flat
        b.BackColor = Color.White
        b.ForeColor = Color.Black
        b.Dock = DockStyle.Top
        b.TextAlign = ContentAlignment.MiddleLeft

        L.Size = New System.Drawing.Size(430, 18)
        L.Text = "Recibiras reportes a tu Correo Electronico"

        L.Font = New System.Drawing.Font(10, 10)
        L.BackColor = BackColor
        L.FlatStyle = FlatStyle.Flat
        L.BackColor = Color.White
        L.ForeColor = Color.Gray
        L.Dock = DockStyle.Fill
        L.TextAlign = ContentAlignment.MiddleLeft
        I2.BackgroundImage = My.Resources.nube_secundaria
        I2.BackgroundImageLayout = ImageLayout.Zoom
        I2.Size = New System.Drawing.Size(18, 18)
        I2.Dock = DockStyle.Left

        p1.Size = New System.Drawing.Size(430, 67)
        p1.BorderStyle = BorderStyle.FixedSingle
        p1.Dock = DockStyle.Top
        p1.BackColor = Color.White

        P2.Size = New System.Drawing.Size(287, 22)
        P2.Dock = DockStyle.Top
        P2.BackColor = Color.White


        I1.BackgroundImage = My.Resources.nube_sincroizacio
        I1.BackgroundImageLayout = ImageLayout.Zoom
        I1.Size = New System.Drawing.Size(90, 69)
        I1.Dock = DockStyle.Left
        I1.BackColor = Color.White

        p1.Controls.Add(b)
        p1.Controls.Add(I1)
        p1.Controls.Add(P2)
        P2.Controls.Add(I2)
        P2.Controls.Add(L)
        P2.BringToFront()
        b.SendToBack()
        I1.SendToBack()
        L.BringToFront()
        PanelCONTENEDORDENOTIFICACIONES.Controls.Add(p1)
        AddHandler b.Click, AddressOf miEventoCorreoLabel
        AddHandler L.Click, AddressOf miEventoCorreoLabel
        AddHandler I1.Click, AddressOf miEventoCorreoLabel
        AddHandler I2.Click, AddressOf miEventoCorreoLabel

    End Sub
    Private Sub miEventoCorreoLabel(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Configurar_envio_a_correo.Desde_donde_se_abre = "DASHBOARD"
            Configurar_envio_a_correo.ShowDialog()

        Catch ex As Exception
        End Try
    End Sub
    Sub dibujarCOBROS()
        Try
            abrir()
            Dim query As String = "NOTIFICADOR_COBROS"
            Dim cmd As New SqlCommand(query, conexion)
            Dim rdr As SqlDataReader = cmd.ExecuteReader()

            While rdr.Read()
                Dim b As New Label()
                Dim p1 As New Panel
                Dim P2 As New Panel
                Dim I1 As New PictureBox
                Dim I2 As New PictureBox
                Dim L As New Label

                b.Text = rdr("Nombre").ToString() & " Te debe " & "(" & rdr("Saldo").ToString() & ")"
                b.Name = rdr("Nombre").ToString()
                b.Size = New System.Drawing.Size(430, 35)
                b.Font = New System.Drawing.Font(10, 10)
                b.BackColor = BackColor
                b.FlatStyle = FlatStyle.Flat
                b.BackColor = Color.White
                b.ForeColor = Color.Black
                b.Dock = DockStyle.Top
                b.TextAlign = ContentAlignment.MiddleLeft
                b.Cursor = Cursors.Hand
                L.Text = "(" & rdr("Saldo").ToString() & ") Saldo por Cobrar"
                L.Name = rdr("Nombre").ToString()
                L.Size = New System.Drawing.Size(430, 18)
                L.Font = New System.Drawing.Font(10, 10)
                L.BackColor = BackColor
                L.FlatStyle = FlatStyle.Flat
                L.BackColor = Color.White
                L.ForeColor = Color.Gray
                L.Dock = DockStyle.Fill
                L.TextAlign = ContentAlignment.MiddleLeft
                L.Cursor = Cursors.Hand
                I2.BackgroundImage = My.Resources.monedas
                I2.BackgroundImageLayout = ImageLayout.Zoom
                I2.Size = New System.Drawing.Size(18, 18)
                I2.Dock = DockStyle.Left
                p1.Size = New System.Drawing.Size(430, 67)
                p1.BorderStyle = BorderStyle.FixedSingle
                p1.Dock = DockStyle.Top
                p1.BackColor = Color.White
                P2.Size = New System.Drawing.Size(287, 22)
                P2.Dock = DockStyle.Top
                P2.BackColor = Color.White
                I1.BackgroundImage = My.Resources.COBROSSSS
                I1.BackgroundImageLayout = ImageLayout.Zoom
                I1.Size = New System.Drawing.Size(90, 69)
                I1.Dock = DockStyle.Left
                I1.BackColor = Color.White

                p1.Controls.Add(b)
                p1.Controls.Add(I1)
                p1.Controls.Add(P2)
                P2.Controls.Add(I2)
                P2.Controls.Add(L)
                P2.BringToFront()
                b.SendToBack()
                I1.SendToBack()
                L.BringToFront()
                PanelCONTENEDORDENOTIFICACIONES.Controls.Add(p1)
                AddHandler b.Click, AddressOf miEventoCOBROS
                AddHandler L.Click, AddressOf miEventoCOBROS
                AddHandler I1.Click, AddressOf miEventoCOBROS
                AddHandler I2.Click, AddressOf miEventoCOBROS
            End While

            Cerrar()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub miEventoCOBROS(ByVal sender As System.Object, ByVal e As EventArgs)

        Try

            'cobro_a_clientes.txtclientesolicitante.Text = DirectCast(sender, Label).Name
            'cobro_a_clientes.TimerMOSTRAR_DESDE_REFERENCIA.Start()

            'cobro_a_clientes.ShowDialog()
            'cobro_a_clientes.txtclientesolicitante.Text = DirectCast(sender, Label).Name
            'ocultar_objetos_emergentes()
            'cobro_a_clientes.TimerMOSTRAR_DESDE_REFERENCIA.Start()
            MessageBox.Show("da click a PUNTO DE VENTA para Realizar Cobros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub miEventoVENTASESPERA(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Ventas_en_espera.txtbusca.Text = DirectCast(sender, Label).Name
            ocultar_objetos_emergentes()
            Ventas_en_espera.ShowDialog()
            Ventas_en_espera.txtbusca.Text = DirectCast(sender, Label).Name

        Catch ex As Exception

        End Try

    End Sub
    Private Sub miEventoPAGOS(ByVal sender As System.Object, ByVal e As EventArgs)
        'Try

        '    PAGOS_PROVEEDOSOKA.txtclientesolicitante.Text = DirectCast(sender, Label).Name
        '    PAGOS_PROVEEDOSOKA.TimerMOSTRAR_DESDE_REFERENCIA.Start()
        '    ocultar_objetos_emergentes()

        '    PAGOS_PROVEEDOSOKA.ShowDialog()
        '    PAGOS_PROVEEDOSOKA.txtclientesolicitante.Text = DirectCast(sender, Label).Name
        '    PAGOS_PROVEEDOSOKA.TimerMOSTRAR_DESDE_REFERENCIA.Start()

        'Catch ex As Exception

        'End Try
        MessageBox.Show("da click a PUNTO DE VENTA para Realizar Pagos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub miEventoProductos_Vencidos(ByVal sender As System.Object, ByVal e As EventArgs)
        Try

            INVENTARIO.TimerVencimientos.Start()
            ocultar_objetos_emergentes()
            'INVENTARIO.txtBuscarVencimientos.Text = DirectCast(sender, Label).Name
            Dispose()
            INVENTARIO.ShowDialog()
            INVENTARIO.TimerVencimientos.Start()
            'INVENTARIO.txtBuscarVencimientos.Text = DirectCast(sender, Label).Name

        Catch ex As Exception

        End Try

    End Sub
    Sub dibujarPOR_PAGAR()
        Try
            abrir()
            Dim query As String = "NOTIFICADOR_PAGOS"
            Dim cmd As New SqlCommand(query, conexion)
            Dim rdr As SqlDataReader = cmd.ExecuteReader()



            Dim NBotones As Integer = 3
            While rdr.Read()
                Dim b As New Label()
                Dim p1 As New Panel
                Dim P2 As New Panel
                Dim I1 As New PictureBox
                Dim I2 As New PictureBox
                Dim L As New Label


                For I As Integer = 0 To NBotones

                    b.Text = "Recuerda Pagar a " & rdr("Nombre").ToString() & " los " & rdr("Saldo").ToString() & " que le Debes"
                    b.Name = rdr("Nombre").ToString()
                    b.Size = New System.Drawing.Size(430, 35)
                    b.Font = New System.Drawing.Font(10, 10)
                    b.BackColor = BackColor
                    b.FlatStyle = FlatStyle.Flat
                    b.BackColor = Color.White
                    b.ForeColor = Color.Black
                    b.Dock = DockStyle.Top
                    b.TextAlign = ContentAlignment.MiddleLeft


                    L.Text = "(" & rdr("Saldo").ToString() & ") Saldo por Pagar"
                    L.Name = rdr("Nombre").ToString()
                    L.Size = New System.Drawing.Size(430, 18)
                    L.Font = New System.Drawing.Font(10, 10)
                    L.BackColor = BackColor
                    L.FlatStyle = FlatStyle.Flat
                    L.BackColor = Color.White
                    L.ForeColor = Color.Gray
                    L.Dock = DockStyle.Fill
                    L.TextAlign = ContentAlignment.MiddleLeft



                    I2.BackgroundImage = My.Resources.advertencia
                    I2.BackgroundImageLayout = ImageLayout.Zoom
                    I2.Size = New System.Drawing.Size(18, 18)
                    I2.Dock = DockStyle.Left

                    p1.Size = New System.Drawing.Size(430, 67)
                    p1.BorderStyle = BorderStyle.FixedSingle
                    p1.Dock = DockStyle.Top
                    p1.BackColor = Color.White

                    P2.Size = New System.Drawing.Size(287, 22)
                    P2.Dock = DockStyle.Top
                    P2.BackColor = Color.White


                    I1.Image = My.Resources.megafono
                    I1.SizeMode = ImageLayout.Zoom
                    I1.Size = New System.Drawing.Size(90, 69)
                    I1.Dock = DockStyle.Left
                    I1.BackColor = Color.White



                Next
                p1.Controls.Add(b)
                p1.Controls.Add(I1)
                p1.Controls.Add(P2)
                P2.Controls.Add(I2)
                P2.Controls.Add(L)

                P2.BringToFront()
                b.SendToBack()
                I1.SendToBack()
                L.BringToFront()


                PanelCONTENEDORDENOTIFICACIONES.Controls.Add(p1)
                AddHandler b.Click, AddressOf miEventoPAGOS
                AddHandler L.Click, AddressOf miEventoPAGOS
                AddHandler I1.Click, AddressOf miEventoPAGOS
                AddHandler I2.Click, AddressOf miEventoPAGOS
            End While

            Cerrar()
        Catch ex As Exception

        End Try

    End Sub
    Sub dibujarPRODUCTOS_vencidos()
        Try
            abrir()
            Dim query As String = "contar_productos_vencidos"
            Dim cmd As New SqlCommand(query, conexion)
            Dim rdr As SqlDataReader = cmd.ExecuteReader()

            While rdr.Read()
                Dim b As New Label()
                Dim p1 As New Panel
                Dim P2 As New Panel
                Dim I1 As New PictureBox
                Dim I2 As New PictureBox
                Dim L As New Label




                b.Text = "Tienes Productos Vencidos"
                b.Name = rdr("id").ToString()
                b.Size = New System.Drawing.Size(430, 35)
                b.Font = New System.Drawing.Font(10, 10)
                b.BackColor = Color.White
                b.ForeColor = Color.Black
                b.Dock = DockStyle.Top
                b.TextAlign = ContentAlignment.MiddleLeft


                L.Text = "(" & rdr("id").ToString() & ") Producto(s) Vencido(s)"
                L.Name = rdr("id").ToString()
                L.Size = New System.Drawing.Size(430, 18)
                L.Font = New System.Drawing.Font(10, 10)
                L.BackColor = Color.White
                L.ForeColor = Color.Gray
                L.Dock = DockStyle.Fill
                L.TextAlign = ContentAlignment.MiddleLeft






                I2.BackgroundImage = My.Resources.advertencia
                I2.BackgroundImageLayout = ImageLayout.Zoom
                I2.Size = New System.Drawing.Size(18, 18)
                I2.Dock = DockStyle.Left

                p1.Size = New System.Drawing.Size(430, 67)
                p1.BorderStyle = BorderStyle.FixedSingle
                p1.Dock = DockStyle.Top
                p1.BackColor = Color.White

                P2.Size = New System.Drawing.Size(287, 22)
                P2.Dock = DockStyle.Top
                P2.BackColor = Color.White


                I1.Image = My.Resources.calendario
                I1.SizeMode = ImageLayout.Zoom
                I1.Size = New System.Drawing.Size(90, 69)
                I1.Dock = DockStyle.Left
                I1.BackColor = Color.White
                p1.Controls.Add(b)
                p1.Controls.Add(I1)
                p1.Controls.Add(P2)
                P2.Controls.Add(I2)
                P2.Controls.Add(L)

                P2.BringToFront()
                b.SendToBack()
                I1.SendToBack()
                L.BringToFront()

                PanelCONTENEDORDENOTIFICACIONES.Controls.Add(p1)
                AddHandler b.Click, AddressOf miEventoProductos_Vencidos
                AddHandler L.Click, AddressOf miEventoProductos_Vencidos
                AddHandler I1.Click, AddressOf miEventoProductos_Vencidos
                AddHandler I2.Click, AddressOf miEventoProductos_Vencidos


            End While

            Cerrar()
        Catch ex As Exception

        End Try

    End Sub
    Sub mostrar_contenedor_herramientas()

        PanelCONTENEDOR_herramientas.Visible = True
        Panelcuenta.Visible = False

        PanelNOTIFICACIONES.Visible = False

        PanelCONTENEDOR_herramientas.Location = New Point((Panel14.Location.X - 34), 48)
        PanelCONTENEDOR_herramientas.Size = New Point(816, 573)
    End Sub
    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs)
        mostrar_contenedor_herramientas()
    End Sub
    Sub MOSTRAR_CAJA_POR_SERIAL()

        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Serial", (lblIDSERIAL.Text))

            da.Fill(dt)
            datalistado_caja.DataSource = dt
            Cerrar()

        Catch ex As Exception ': MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub ListarAPERTURAS_de_detalle_de_cierres_de_caja()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@serial", lblIDSERIAL.Text)

            da.Fill(dt)
            datalistado_detalle_cierre_de_caja.DataSource = dt
            Cerrar()

        Catch ex As Exception

        End Try

    End Sub
    Sub contar_APERTURAS_de_detalle_de_cierres_de_caja()
        Dim x As Integer
        x = datalistado_detalle_cierre_de_caja.Rows.Count
        lblcontador_cierres_De_caja_aperturadas.Text = CStr(x)
    End Sub
    Dim id_usarios_admin As Integer
    Sub MOSTRAR_id_de_admin()



        Dim com As New SqlCommand("select idUsuario from USUARIO2 WHERE Login='admin'", conexion)

        Try
            abrir()
            id_usarios_admin = (com.ExecuteScalar())
            Cerrar()


        Catch ex As Exception

        End Try



    End Sub
    Sub aperturar_detalle_de_cierre_caja()
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("insertar_DETALLE_cierre_de_caja", conexion)
            cmd.CommandType = 4

            cmd.Parameters.AddWithValue("@fechaini", lblfechaoka.Value)
            cmd.Parameters.AddWithValue("@fechafin", lblfechaoka.Value)
            cmd.Parameters.AddWithValue("@fechacierre", lblfechaoka.Value)
            cmd.Parameters.AddWithValue("@ingresos", "0.00")
            cmd.Parameters.AddWithValue("@egresos", "0.00")
            cmd.Parameters.AddWithValue("@saldo", "0.00")
            cmd.Parameters.AddWithValue("@idusuario", IDUSUARIO.Text)
            cmd.Parameters.AddWithValue("@totalcaluclado", "0.00")
            cmd.Parameters.AddWithValue("@totalreal", "0.00")

            cmd.Parameters.AddWithValue("@estado", "CAJA APERTURADA")
            cmd.Parameters.AddWithValue("@diferencia", "0.00")
            cmd.Parameters.AddWithValue("@idcierrepadre", txtidcaja.Text)
            cmd.ExecuteNonQuery()
            lblpermisodeCaja.Text = "correcto"
            Cerrar()


        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("Editar_estado_caja", conexion)
            cmd.CommandType = 4

            cmd.Parameters.AddWithValue("@estado", "Caja Aperturada")
            cmd.Parameters.AddWithValue("@idcaja", txtidcaja.Text)

            cmd.ExecuteNonQuery()
            Cerrar()

        Catch ex As Exception

        End Try
    End Sub
    Sub MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@serial", lblIDSERIAL.Text)
            da.SelectCommand.Parameters.AddWithValue("@idusuario", IDUSUARIO.Text)
            da.Fill(dt)
            datalistado_movimientos_validar.DataSource = dt
            Cerrar()
            Dim x As Integer
            x = datalistado_movimientos_validar.Rows.Count
            lblcontadorMovimientosValidados.Text = CStr(x)

        Catch ex As Exception ': MessageBox.Show(ex.Message)
        End Try


    End Sub
    Sub Iniciar_sesion_correcto()
        Try

            MOSTRAR_id_de_admin()

            IDUSUARIO.Text = id_usarios_admin
            MOSTRAR_CAJA_POR_SERIAL()
            Try
                txtidcaja.Text = datalistado_caja.SelectedCells.Item(1).Value
                lblcaja.Text = datalistado_caja.SelectedCells.Item(2).Value
            Catch ex As Exception

            End Try


            ListarAPERTURAS_de_detalle_de_cierres_de_caja()
            contar_APERTURAS_de_detalle_de_cierres_de_caja()
            If lblcontador_cierres_De_caja_aperturadas.Text = 0 Then

                'aperturar_caja_padre()
                'ListarAPERTURAS_DE_CAJA_padre()
                aperturar_detalle_de_cierre_caja()
                'ListarAPERTURAS_de_detalle_de_cierres_de_caja()
                MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario()
                ListarAPERTURAS_de_detalle_de_cierres_de_caja()
                Try
                    lblusuario_queinicioCaja.Text = datalistado_detalle_cierre_de_caja.SelectedCells.Item(1).Value
                    lblnombredeCajero.Text = datalistado_detalle_cierre_de_caja.SelectedCells.Item(2).Value
                Catch ex As Exception

                End Try
                lblApertura_De_caja.Text = "Nuevo*****"
                Iniciar()

            Else
                MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario()
                ListarAPERTURAS_de_detalle_de_cierres_de_caja()
                Try
                    lblusuario_queinicioCaja.Text = datalistado_detalle_cierre_de_caja.SelectedCells.Item(1).Value
                    lblnombredeCajero.Text = datalistado_detalle_cierre_de_caja.SelectedCells.Item(2).Value
                Catch ex As Exception

                End Try

                If lblcontadorMovimientosValidados.Text = 0 Then

                    If lblusuario_queinicioCaja.Text <> "admin" And txtlogin.Text = "admin" Then
                        MessageBox.Show("Continuaras Turno de *" & lblnombredeCajero.Text & " Todos los Registros seran con ese Usuario", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        lblpermisodeCaja.Text = "correcto"
                    ElseIf lblusuario_queinicioCaja.Text = "admin" And txtlogin.Text = "admin" Then

                        lblpermisodeCaja.Text = "correcto"
                    ElseIf lblusuario_queinicioCaja.Text = "admin" And txtlogin.Text <> "admin" Then
                        MessageBox.Show("Para poder continuar con el Turno de *" & lblnombredeCajero.Text & "* ,Inicia sesion con el Usuario " & lblusuario_queinicioCaja.Text & " -ó-el Usuario *admin*", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        lblpermisodeCaja.Text = "vacio"
                    ElseIf lblusuario_queinicioCaja.Text <> "admin" And txtlogin.Text <> "admin" Then
                        MessageBox.Show("Para poder continuar con el Turno de *" & lblnombredeCajero.Text & "* ,Inicia sesion con el Usuario " & lblusuario_queinicioCaja.Text & " -ó-el Usuario *admin*", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        lblpermisodeCaja.Text = "vacio"

                    ElseIf lblusuario_queinicioCaja.Text = txtlogin.Text Then
                        lblpermisodeCaja.Text = "correcto"
                    End If

                Else

                    lblpermisodeCaja.Text = "correcto"
                End If

                If lblpermisodeCaja.Text = "correcto" Then
                    lblApertura_De_caja.Text = "Aperturado"
                    Iniciar()
                End If



            End If
        Catch ex As Exception
            'MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub btnPuntodeVenta_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        ocultar_objetos_emergentes()
        Dispose()
        cobro_a_clientes.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        ocultar_objetos_emergentes()
        Dispose()
        PAGOS_PROVEEDOSOKA.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        ocultar_objetos_emergentes()
        Dispose()
        CIERRE_DE_CAJA.ShowDialog()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)
        ocultar_objetos_emergentes()
        Ticket.ShowDialog()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs)

    End Sub
    Dim Base_De_datos As String
    Public Sub LeerXML_base_de_datos()

        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Base_de_datos.xml")
            Dim root As XmlElement = doc.DocumentElement
            Base_De_datos = root.Attributes.Item(0).Value
            Base_De_datos = (aes.Decrypt(Base_De_datos, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException


        End Try
    End Sub
    Dim Servidor As String
    Public Sub LeerXML_Servidor()

        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Servidor.xml")
            Dim root As XmlElement = doc.DocumentElement
            Servidor = root.Attributes.Item(0).Value
            Servidor = (aes.Decrypt(Servidor, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException


        End Try
    End Sub
    Private Sub Button17_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Dispose()

    End Sub
    Dim contador As Integer
    Sub Iniciar()
        If lblApertura_De_caja.Text = "Nuevo*****" And lblROL.Text <> "Solo Ventas (no esta autorizado para manejar dinero)" Then
            Me.Dispose()
            APERTURA_DE_CAJA.ShowDialog()
        Else
            Me.Dispose()
            VENTAS_MENU_PRINCIPAL.ShowDialog()
        End If
    End Sub

    Public panel_PARA_MOSTRAR_FORMULARIOS As New Panel
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click


        MessageBox.Show("da click a PUNTO DE VENTA para Realizar Cobros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub TimerCERRAR_OTROS_FORMULARIOS_Tick(sender As Object, e As EventArgs) Handles TimerCERRAR_OTROS_FORMULARIOS.Tick
        Me.Controls.Remove(panel_PARA_MOSTRAR_FORMULARIOS)
        Panel5.Visible = True
        TimerCERRAR_OTROS_FORMULARIOS.Stop()
    End Sub

    Private Sub DASHBOARD_PRINCIPAL_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim dlgRes As DialogResult
        dlgRes = MessageBox.Show("¿Realmente desea Cerrar el Sistema?", "Cerrando", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dlgRes = DialogResult.Yes Then


            MASCARA1.Show()
            GENERADOR_DE_COPIAS_AUTOMATICO.ShowDialog()
            End
        End If

        If dlgRes = DialogResult.No Then
            e.Cancel = True
        End If

    End Sub

    Private Sub PanelCONTENEDOR_CUENTA_HERRAMIENTAS_Paint(sender As Object, e As PaintEventArgs) Handles PanelCONTENEDOR_herramientas.Paint

    End Sub

    Private Sub PanelCONTENEDOR_CUENTA_HERRAMIENTAS_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelCONTENEDOR_herramientas.MouseUp

    End Sub

    Private Sub PanelCONTENEDOR_CUENTA_HERRAMIENTAS_MouseLeave(sender As Object, e As EventArgs) Handles PanelCONTENEDOR_herramientas.MouseLeave
        PanelCONTENEDOR_herramientas.Visible = False

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        ocultar_objetos_emergentes()

        Membresias.ShowDialog()

    End Sub

    Private Sub Panel4_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Panel4_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel4.MouseMove
        ocultar_objetos_emergentes()
    End Sub

    Private Sub Panel23_Paint(sender As Object, e As PaintEventArgs) Handles Panel23.Paint

    End Sub

    Private Sub Panel23_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel23.MouseMove
        ocultar_objetos_emergentes()
    End Sub

    Private Sub ImagenEmpresaTRUE_Click(sender As Object, e As EventArgs) Handles ImagenEmpresaTRUE.Click

    End Sub

    Private Sub Label66_Click(sender As Object, e As EventArgs) Handles Label66.Click

    End Sub
    Private Sub TimerCerrar_Aperturas_de_credito_Tick(sender As Object, e As EventArgs) Handles TimerCerrar_Aperturas_de_credito.Tick
        temporizador += 1
        If temporizador = 2 Then
            MASCARA1.Dispose()
            APERTURA_DE_CREDITOS.Dispose()
            TimerCerrar_Aperturas_de_credito.Stop()
        End If

    End Sub

    Private Sub Label57_Click(sender As Object, e As EventArgs)
        ocultar_objetos_emergentes()
        Dispose()
        MENU_dE_REPORTES_OI.ShowDialog()
    End Sub

    Private Sub Chart3_Click(sender As Object, e As EventArgs) Handles Chart3.Click

    End Sub

    Private Sub Chart1_Click_1(sender As Object, e As EventArgs) Handles ChartGastos_por_año.Click

    End Sub

    Private Sub ChartGastos_por_año_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Chart1_Click_2(sender As Object, e As EventArgs) Handles Chart4.Click

    End Sub

    Private Sub Chart4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ocultar_objetos_emergentes()
        Iniciar_sesion_correcto()
    End Sub



    Private Sub UI_CustomButton2_Click(sender As Object, e As EventArgs)
        APERTURA_DE_CREDITOS.lblTipo.Text = "POR PAGAR"
        ocultar_objetos_emergentes()

        MASCARA1.Show()

        APERTURA_DE_CREDITOS.ShowDialog()
        APERTURA_DE_CREDITOS.lblTipo.Text = "POR PAGAR"
    End Sub

    Private Sub UI_CustomButton3_Click(sender As Object, e As EventArgs)
        APERTURA_DE_CREDITOS.lblTipo.Text = "POR COBRAR"
        ocultar_objetos_emergentes()
        MASCARA1.Show()
        APERTURA_DE_CREDITOS.ShowDialog()
        APERTURA_DE_CREDITOS.lblTipo.Text = "POR COBRAR"
    End Sub

    Private Sub UI_CustomButton1_Click(sender As Object, e As EventArgs) Handles UI_CustomButton1.Click
        ocultar_objetos_emergentes()
        Dispose()
        INVENTARIO.ShowDialog()
    End Sub

    Private Sub UI_CustomButton4_Click(sender As Object, e As EventArgs) Handles UI_CustomButton4.Click
        ocultar_objetos_emergentes()
        Dispose()
        MENU_dE_REPORTES_OI.ShowDialog()
    End Sub

    Private Sub UI_CustomButton5_Click(sender As Object, e As EventArgs) Handles UI_CustomButton5.Click
        ocultar_objetos_emergentes()
        MASCARA1.Show()
        MASCARA1.FormBorderStyle = FormBorderStyle.None
        GENERAR_COPIAS_DE_SEGURIDAD.ShowDialog()
    End Sub

    Private Sub UI_CustomButton6_Click(sender As Object, e As EventArgs) Handles UI_CustomButton6.Click
        LeerXML_base_de_datos()
        LeerXML_Servidor()

        With dlg
            .InitialDirectory = ""
            .Filter = "Backup " & Base_De_datos & "|*.bak"
            .FilterIndex = 2
            .Title = "Cargador de Backup " & Me.Text

        End With
        If dlg.ShowDialog() = DialogResult.OK Then
            Try
                lblruta.Text = Path.GetFullPath(dlg.FileName)

            Catch ex As Exception

            End Try
        End If

        If MessageBox.Show("Usted está a punto de restaurar la base de datos," & vbCrLf &
"asegurese de que el archivo .bak sea reciente, de" & vbCrLf &
"lo contrario podría perder información y no podrá" & vbCrLf &
"recuperarla, ¿desea continuar?", "Restauración de base de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim cnn As New SqlConnection("Server=" & Servidor & ";database=master; integrated security=yes")
            cnn.Open()
            Dim DropRes As String = "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" & Base_De_datos & "' USE [master] ALTER DATABASE [" & Base_De_datos & "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [" & Base_De_datos & "] RESTORE DATABASE " & Base_De_datos & " FROM DISK = N'" & lblruta.Text & "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10"

            Try

                Dim BorraRestaura As New SqlCommand(DropRes, cnn)
                BorraRestaura.ExecuteNonQuery()

                MessageBox.Show("La base de datos " & Microsoft.VisualBasic.Left(lblruta.Text, lblruta.TextLength - 4) & " ha sido restaurada satisfactoriamente! Vuelve a Iniciar El Aplicativo", "Restauración de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
            Catch ex As Exception
                restaurar_base_para_versiones_no_express()
            Finally
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End Try
        Else ' No restaura 
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        ocultar_objetos_emergentes()
        Iniciar_sesion_correcto()
    End Sub

    Private Sub UI_CustomButton7_Click(sender As Object, e As EventArgs) Handles UI_CustomButton7.Click
        Flujo_caja.ShowDialog()
    End Sub

    Private Sub UI_CustomButton2_Click_1(sender As Object, e As EventArgs) Handles Configuracionesbtn.Click
        ocultar_objetos_emergentes()

        'Panel5.Visible = False
        'panel_PARA_MOSTRAR_FORMULARIOS.Dock = DockStyle.Fill

        'PANEL_CONFIGURACIONES.TopLevel = False
        'PANEL_CONFIGURACIONES.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'PANEL_CONFIGURACIONES.Dock = DockStyle.Fill
        'panel_PARA_MOSTRAR_FORMULARIOS.Controls.Add(PANEL_CONFIGURACIONES)

        'Me.Controls.Add(panel_PARA_MOSTRAR_FORMULARIOS)
        'panel_PARA_MOSTRAR_FORMULARIOS.BringToFront()
        Dispose()
        PANEL_CONFIGURACIONES.ShowDialog()
    End Sub
End Class