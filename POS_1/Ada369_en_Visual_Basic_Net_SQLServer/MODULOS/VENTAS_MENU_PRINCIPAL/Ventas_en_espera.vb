
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Management

Public Class Ventas_en_espera
    Dim idcaja As Integer
    Dim idcajaActual As Integer

    Sub mostrar_productos_agregados_a_venta_en_espera()

        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try

            abrir()
            daMA = New SqlDataAdapter("mostrar_productos_agregados_a_venta_en_espera", conexion)
            daMA.SelectCommand.CommandType = 4
            daMA.SelectCommand.Parameters.AddWithValue("@idventa", id_venta)
            daMA.Fill(dtMA)
            datalistadodetalledeventasarestaurar.DataSource = dtMA

            datalistadodetalledeventasarestaurar.Columns(1).Width = 350
            datalistadodetalledeventasarestaurar.Columns(2).Width = 68
            datalistadodetalledeventasarestaurar.Columns(3).Width = 70
            datalistadodetalledeventasarestaurar.Columns(4).Width = 75


            Cerrar()

        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub Ventas_en_espera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar_ventas_en_espera_con_fecha_y_monto()
        contar_ventas_en_espera()
        Cargar_id_serial_pc()
        obtener_id_caja()
    End Sub
    Sub obtener_id_caja()
        Try
            abrir()
            Dim da = New SqlCommand("mostrar_cajas_por_Serial_de_DiscoDuro", conexion)
            da.CommandType = 4
            da.Parameters.AddWithValue("@Serial", lblIDSERIAL.Text)
            idcajaActual = da.ExecuteScalar()
            Cerrar()
        Catch ex As Exception
        End Try
    End Sub
    Sub Cargar_id_serial_pc()
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())

    End Sub
    Sub mostrar_ventas_en_espera_con_fecha_y_monto()
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Try
                abrir()
                da = New SqlDataAdapter("mostrar_ventas_en_espera_con_fecha_y_monto", conexion)
                da.Fill(dt)
                datalistado_ventas_en_espera.DataSource = dt
                datalistado_ventas_en_espera.Columns(1).Visible = False
                datalistado_ventas_en_espera.Columns(4).Visible = False

                Cerrar()

            Catch ex As Exception


            End Try


        Catch ex As Exception

        End Try

    End Sub
    Sub contar_ventas_en_espera()
        'Dim importe As Double
        'Dim com As New SqlCommand("mostrar_ventas_en_espera", conexion)

        'Try
        '    abrir()
        '    importe = (com.ExecuteScalar()) 'asignamos el valor del importe
        '    Cerrar()
        'Catch ex As Exception
        'End Try
        'VENTAS_MENU_PRINCIPAL.LBLcontadorESPERA.Text = importe  ' mostramos el importe
        'Label60.Text = "Ventas en Espera (" & VENTAS_MENU_PRINCIPAL.LBLcontadorESPERA.Text & ")"



        Dim importe As Integer
        Dim com As New SqlCommand("mostrar_ventas_en_espera_solo_para_vendedores", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@Id_caja", VENTAS_MENU_PRINCIPAL.lblidcaja.Text)

        Try
            abrir()
            importe = (com.ExecuteScalar()) 'asignamos el valor del importe
            Cerrar()

        Catch ex As Exception
            importe = 0
        End Try
        Label60.Text = "Ventas en Espera (" & importe & ")"

    End Sub
    Dim id_venta As Integer
    Private Sub datalistado_ventas_en_espera_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado_ventas_en_espera.CellClick
        If datalistado_ventas_en_espera.RowCount > 0 Then
            id_venta = datalistado_ventas_en_espera.SelectedCells.Item(1).Value
            lblfechadeventa.Text = datalistado_ventas_en_espera.SelectedCells.Item(3).Value
            idcaja = datalistado_ventas_en_espera.SelectedCells.Item(4).Value
            mostrar_productos_agregados_a_venta_en_espera()

        End If

    End Sub

    Private Sub datalistado_ventas_en_espera_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado_ventas_en_espera.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

        Close()

    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        Try
            Dim cmd As SqlCommand

            abrir()
            cmd = New SqlCommand("eliminar_venta", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idventa", datalistado_ventas_en_espera.SelectedCells.Item(1).Value)
            cmd.ExecuteNonQuery()
            Cerrar()

        Catch ex As Exception

        End Try

        id_venta = 0

        mostrar_ventas_en_espera_con_fecha_y_monto()
        mostrar_productos_agregados_a_venta_en_espera()
        contar_ventas_en_espera()
        VENTAS_MENU_PRINCIPAL.contar_ventas_en_espera_solo_para_vendedores()



    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        VENTAS_MENU_PRINCIPAL.txtidventa.Text = id_venta
        cambio_de_caja()
        VENTAS_MENU_PRINCIPAL.restaurar_venta()
        Dispose()
    End Sub
    Sub cambio_de_caja()
        Try
            abrir()
            Dim cmd As New SqlCommand("cambio_de_Caja", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Idcaja", idcajaActual)
            cmd.Parameters.AddWithValue("@Idventa", id_venta)
            cmd.ExecuteNonQuery()
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Ventas_en_espera_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        VENTAS_MENU_PRINCIPAL.TimerNotificaciones.Start()
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        Close()
    End Sub

    Private Sub txtbusca_TextChanged(sender As Object, e As EventArgs) Handles txtbusca.TextChanged

    End Sub
End Class