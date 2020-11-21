
Imports System.Data.SqlClient
Imports System.Management
Public Class CIERRE_DE_CAJA
    Public idcaja As Integer
    Dim contador As Integer
    Sub REPORT_VENTAS_por_TURNOS_en_EFECTIVO()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("REPORT_VENTAS_por_TURNOS_en_EFECTIVO", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@id_caja", idcaja)
            da.SelectCommand.Parameters.AddWithValue("@fi", fechainicial)
            da.SelectCommand.Parameters.AddWithValue("@ff", Now())
            da.Fill(dt)
            DATALISTADO_VENTAS_Efectivo.DataSource = dt
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
    Sub REPORT_VENTAS_por_TURNOS_Por_tarjeta()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("REPORT_VENTAS_por_TURNOS_Por_tarjeta", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@id_caja", idcaja)
            da.SelectCommand.Parameters.AddWithValue("@fi", fechainicial)
            da.SelectCommand.Parameters.AddWithValue("@ff", Now())
            da.Fill(dt)
            DATALISTADO_VENTAS_Tarjeta.DataSource = dt
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & ex.StackTrace)

        End Try
    End Sub
    Sub REPORT_VENTAS_por_TURNOS_Por_Credito()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("REPORT_VENTAS_por_TURNOS_Por_Credito", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@id_caja", idcaja)
            da.SelectCommand.Parameters.AddWithValue("@fi", fechainicial)
            da.SelectCommand.Parameters.AddWithValue("@ff", Now())
            da.Fill(dt)
            DATALISTADO_VENTAS_Credito.DataSource = dt
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & ex.StackTrace)


        End Try
    End Sub
    Sub REPORT_GASTOS_VARIOS_por_turnos()

        Dim com As New SqlCommand("REPORT_GASTOS_VARIOS_por_turnos", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_caja", idcaja)
        com.Parameters.AddWithValue("@fi", fechainicial)
        com.Parameters.AddWithValue("@ff", Now())

        Try
            abrir()
            lblsalidasvarias.Text = (com.ExecuteScalar())
            Cerrar()
        Catch ex As Exception
            lblsalidasvarias.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try



    End Sub
    Sub REPORT_GANANCIAS_DE_VENTAS_por_TURNOS()

        Dim com As New SqlCommand("REPORT_GANANCIAS_DE_VENTAS_por_TURNOS", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_caja", idcaja)
        com.Parameters.AddWithValue("@fi", fechainicial)
        com.Parameters.AddWithValue("@ff", Now())

        Try
            abrir()
            lblgananciasVentas.Text = (com.ExecuteScalar())
            Cerrar()


        Catch ex As Exception
            lblgananciasVentas.Text = 0
            ''MessageBox.Show(ex.Message & " " & ex.StackTrace)

        End Try



    End Sub
    Sub REPORT_INGRESOS_VARIOS_por_turnos()
        Dim com As New SqlCommand("REPORT_INGRESOS_VARIOS_por_turnos", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_caja", idcaja)
        com.Parameters.AddWithValue("@fi", fechainicial)
        com.Parameters.AddWithValue("@ff", Now())
        Try
            abrir()
            LBLENTRADASVARIAS.Text = (com.ExecuteScalar())
            Cerrar()


        Catch ex As Exception
            LBLENTRADASVARIAS.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)

        End Try




    End Sub
    Sub REPORT_COBROS_EN_EFECTIVO_por_turnos()
        Dim com As New SqlCommand("REPORT_COBROS_EN_EFECTIVO_por_turnos", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_caja", idcaja)
        com.Parameters.AddWithValue("@fi", fechainicial)
        com.Parameters.AddWithValue("@ff", Now())

        Try
            abrir()
            lblabonosEfectivo.Text = (com.ExecuteScalar())
            Cerrar()


        Catch ex As Exception
            lblabonosEfectivo.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try




    End Sub

    Sub REPORT_COBROS_EN_Tarjeta_por_turnos()

        Dim com As New SqlCommand("REPORT_COBROS_EN_TARJETA_por_turnos", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_caja", idcaja)
        com.Parameters.AddWithValue("@fi", fechainicial)
        com.Parameters.AddWithValue("@ff", Now())

        Try
            abrir()
            lblabonosTarjeta.Text = (com.ExecuteScalar())
            Cerrar()


        Catch ex As Exception
            lblabonosTarjeta.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)

        End Try



    End Sub
    Sub REPORT_PAGOS_EN_EFECTIVO_por_turnos()


        Dim com As New SqlCommand("REPORT_PAGOS_EN_EFECTIVO_por_turnos", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_caja", idcaja)
        com.Parameters.AddWithValue("@fi", fechainicial)
        com.Parameters.AddWithValue("@ff", Now())

        Try
            abrir()
            lblPAGOSEfectivo.Text = (com.ExecuteScalar())
            Cerrar()

        Catch ex As Exception
            lblPAGOSEfectivo.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try




    End Sub
    Sub MOSTRAR_FONDO_DE_CAJA()

        Dim com As New SqlCommand("MOSTRAR_FONDO_DE_CAJA_INICIAL", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_caja", idcaja)
        com.Parameters.AddWithValue("@fi", fechainicial)
        com.Parameters.AddWithValue("@ff", Now())

        Try
            abrir()
            lblfondodeCaja.Text = (com.ExecuteScalar())
            Cerrar()


        Catch ex As Exception
            lblfondodeCaja.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)

        End Try


    End Sub

    Sub mostrar_cierre_de_caja_pendiente()

        Try
            abrir()
            Dim da = New SqlCommand("MOSTRAR_CIERRE_DE_CAJA_PENDIENTE", conexion)
            da.CommandType = 4
            da.Parameters.AddWithValue("@serial", lblIDSERIAL.Text)
            fechainicial = da.ExecuteScalar()
            Cerrar()
        Catch ex As Exception : MessageBox.Show(ex.Message)

        End Try

    End Sub
    Public fechainicial As DateTime

    Sub mostrar_Caja_por_serial()
        Dim com As New SqlCommand("mostrar_cajas_por_Serial_de_DiscoDuro", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@Serial", (lblIDSERIAL.Text))
        Try
            abrir()
            idcaja = (com.ExecuteScalar())
            Cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
    Private Sub CIERRE_DE_CAJA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-ES")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","
        BtnImprimir.Visible = False
        obtener_serial_pc()
        mostrar_Caja_por_serial()
        mostrar_cierre_de_caja_pendiente()
        obtener_fechas_de_corte()
        calcular_cierre_de_turno_ok()
    End Sub
    Sub obtener_fechas_de_corte()
        Try

            lbldesdehasta.Text = "Corte de " & " Desde " & fechainicial & " hasta " & Now()
        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
    Sub obtener_serial_pc()
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())
    End Sub

    Sub calcular_cierre_de_turno_ok()
        Timer1.Start()
    End Sub
    Sub calcular()
        Try
            lblDineroEncajaTurno.Text = lblfondodeCaja.Text * 1 + LBLVENTASenEfectivo.Text * 1 + lblabonosEfectivo.Text * 1 + lblabonosTarjeta.Text * 1 - lblPAGOSEfectivo.Text * 1 + LBLENTRADASVARIAS.Text * 1 - lblsalidasvarias.Text * 1
            lblDineroEncajaTurnoTOTAL.Text = lblDineroEncajaTurno.Text
            lblVentas_suma.Text = LBLVentasEnEfectivo2.Text * 1 + lblventas_Tarjeta.Text * 1 + lblVentasAcredito.Text * 1
        Catch ex As Exception
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
    Sub obtener_valores_de_ventas()
        Try
            LBLTOTALVENTAS.Text = DATALISTADO_VENTAS_Efectivo.SelectedCells.Item(1).Value
        Catch ex As Exception
            LBLTOTALVENTAS.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try
        LBLVENTASenEfectivo.Text = LBLTOTALVENTAS.Text
        LBLVentasEnEfectivo2.Text = LBLVENTASenEfectivo.Text
        Try
            lblventas_Tarjeta.Text = DATALISTADO_VENTAS_Tarjeta.SelectedCells.Item(1).Value
        Catch ex As Exception
            lblventas_Tarjeta.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)

        End Try
        Try
            lblVentasAcredito.Text = DATALISTADO_VENTAS_Credito.SelectedCells.Item(1).Value
        Catch ex As Exception
            lblVentasAcredito.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
    Sub REPORT_por_Pagar_aperturados_por_turno()

        Dim com As New SqlCommand("REPORT_por_Pagar_aperturados_por_turno", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_caja", idcaja)
        com.Parameters.AddWithValue("@fi", fechainicial)
        com.Parameters.AddWithValue("@ff", Now())

        Try
            abrir()
            lblPorpagar.Text = (com.ExecuteScalar())
            Cerrar()


        Catch ex As Exception
            lblPorpagar.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try


    End Sub
    Sub REPORT_creditos_aperturados_por_turno()

        Dim com As New SqlCommand("REPORT_creditos_aperturados_por_turno", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@id_caja", idcaja)
        com.Parameters.AddWithValue("@fi", fechainicial)
        com.Parameters.AddWithValue("@ff", Now())

        Try
            abrir()
            lblPorCobrar.Text = (com.ExecuteScalar())
            Cerrar()


        Catch ex As Exception
            lblPorCobrar.Text = 0
            'MessageBox.Show(ex.Message & " " & ex.StackTrace)

        End Try


    End Sub



    Private Sub MenuStrip9_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub



    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel12_Paint(sender As Object, e As PaintEventArgs) Handles Panel12.Paint

    End Sub



    Private Sub lbldesdehasta_Click(sender As Object, e As EventArgs) Handles lbldesdehasta.Click

    End Sub





    Private Sub CircularProgressBar1_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        reporte_cierre_de_caja_form.ShowDialog()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        contador += 1
        If contador = 1 Then
            REPORT_GASTOS_VARIOS_por_turnos()
        ElseIf contador = 2 Then
            REPORT_INGRESOS_VARIOS_por_turnos()
        ElseIf contador = 3 Then
            REPORT_COBROS_EN_EFECTIVO_por_turnos()
        ElseIf contador = 4 Then
            REPORT_COBROS_EN_Tarjeta_por_turnos()
        ElseIf contador = 5 Then
            REPORT_PAGOS_EN_EFECTIVO_por_turnos()
        ElseIf contador = 6 Then
            REPORT_VENTAS_por_TURNOS_en_EFECTIVO()
        ElseIf contador = 7 Then
            REPORT_VENTAS_por_TURNOS_Por_tarjeta()
        ElseIf contador = 8 Then
            REPORT_VENTAS_por_TURNOS_Por_Credito()
        ElseIf contador = 9 Then
            REPORT_GANANCIAS_DE_VENTAS_por_TURNOS()
        ElseIf contador = 10 Then
            obtener_valores_de_ventas()
        ElseIf contador = 11 Then
            MOSTRAR_FONDO_DE_CAJA()
        ElseIf contador = 12 Then
            calcular()
        ElseIf contador = 13 Then
            LBLTOTALVENTAS.Text = lblVentas_suma.Text
        ElseIf contador = 14 Then
            REPORT_creditos_aperturados_por_turno()
        ElseIf contador = 15 Then
            REPORT_por_Pagar_aperturados_por_turno()
        ElseIf contador = 16 Then
            Timer1.Stop()
            contador = 0
        End If
    End Sub



    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MASCARA1.Show()
        Cierre_de_turno.ShowDialog()
    End Sub
End Class