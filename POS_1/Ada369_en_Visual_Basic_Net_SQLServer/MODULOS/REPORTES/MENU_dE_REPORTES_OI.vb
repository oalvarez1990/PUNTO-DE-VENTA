Imports System.Data
Imports System.Data.SqlClient
Public Class MENU_dE_REPORTES_OI
    Dim panelPadre As New Panel
    Private Sub MENU_dE_REPORTES_OI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelBienvenida.Dock = DockStyle.Fill
        PanelBienvenida.Visible = True
        PanelVENTAS.Visible = False

    End Sub
    Sub mostrar_empleados()
        Dim dtComprobante As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("select * From USUARIO2", conexion)
            da.Fill(dtComprobante)
            txtEmpleado.DisplayMember = "Nombre_y_Apelllidos"
            txtEmpleado.ValueMember = "idUsuario"
            txtEmpleado.DataSource = dtComprobante
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub TXTFF_ValueChanged(sender As Object, e As EventArgs) Handles TXTFF.ValueChanged
        If chekFiltros.Checked = True Then
            If PResumenVentas.Visible = True Then
                reporte_resumen_de_ventas_POR_FECHAS()
            Else PVentasPorempleado.Visible = True
                reporte_resumen_de_ventas_por_empleado_y_fechas()
            End If
        End If
    End Sub

    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        PanelVENTAS.Visible = True
        PanelVENTAS.Dock = DockStyle.Fill
        PanelBienvenida.Visible = False
        PanelProductos.Visible = False
        PanelPorCobrarPagar.Visible = False
        Panel4.Enabled = False
        PanelEmpleado.Visible = False

        chekFiltros.Checked = False
        PanelFiltros.Visible = False


        btnVentas.BackColor = Color.White
        btnVentas.ForeColor = Color.OrangeRed
        btnCobrar.BackColor = Color.FromArgb(242, 243, 244)
        btnCobrar.ForeColor = Color.FromArgb(64, 64, 64)
        BtnPagar.ForeColor = Color.FromArgb(64, 64, 64)
        BtnPagar.BackColor = Color.FromArgb(242, 243, 244)
        BtnProductos.ForeColor = Color.FromArgb(64, 64, 64)
        BtnProductos.BackColor = Color.FromArgb(242, 243, 244)

    End Sub

    Private Sub chekFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chekFiltros.CheckedChanged
        If chekFiltros.Checked = True Then
            If PResumenVentas.Visible = True Then
                reporte_resumen_de_ventas_POR_FECHAS()
            ElseIf PVentasPorempleado.Visible = True
                reporte_resumen_de_ventas_por_empleado_y_fechas()
            End If
            btnHoy.ForeColor = Color.DimGray
            PanelFiltros.Visible = True

            TFILTROS.ForeColor = Color.OrangeRed
        Else
            If PResumenVentas.Visible = True Then
                reporte_resumen_de_ventas_hasta_hoy()
            ElseIf PVentasPorempleado.Visible = True
                reporte_resumen_de_ventas_hasta_hoy_POR_EMPLEADO()
            End If

            btnHoy.ForeColor = Color.OrangeRed
            PanelFiltros.Visible = False
            TFILTROS.ForeColor = Color.DimGray
        End If
    End Sub
    Sub reporte_resumen_de_ventas_por_empleado_y_fechas()
        Dim reporte As New Reporte_de_ventas_por_empleado()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try


            abrir()
            daMA = New SqlDataAdapter("reporte_resumen_de_ventas_por_empleado_y_fechas", conexion)
            daMA.SelectCommand.CommandType = 4
            daMA.SelectCommand.Parameters.AddWithValue("@fi", TXTFI.Value)
            daMA.SelectCommand.Parameters.AddWithValue("@ff", TXTFF.Value)
            daMA.SelectCommand.Parameters.AddWithValue("@Id_empleado", valorSeleccionado)

            daMA.Fill(dtMA)
            Cerrar()
            reporte = New Reporte_de_ventas_por_empleado
            reporte.Table1.DataSource = dtMA
            reporte.DataSource = dtMA

            ReportViewer1.Report = reporte
            ReportViewer1.RefreshReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub reporte_resumen_de_ventas_POR_FECHAS()
        Dim reporte As New ReportRESUMENVentas()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try


            abrir()
            daMA = New SqlDataAdapter("reporte_resumen_de_ventas", conexion)
            daMA.SelectCommand.CommandType = 4
            daMA.SelectCommand.Parameters.AddWithValue("@fi", TXTFI.Value)
            daMA.SelectCommand.Parameters.AddWithValue("@ff", TXTFF.Value)
            daMA.Fill(dtMA)
            Cerrar()
            reporte = New ReportRESUMENVentas
            reporte.Table1.DataSource = dtMA
            reporte.DataSource = dtMA

            ReportViewer1.Report = reporte
            ReportViewer1.RefreshReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TXTFI_ValueChanged(sender As Object, e As EventArgs) Handles TXTFI.ValueChanged
        If chekFiltros.Checked = True Then
            If PResumenVentas.Visible = True Then
                reporte_resumen_de_ventas_POR_FECHAS()
            Else PVentasPorempleado.Visible = True
                reporte_resumen_de_ventas_por_empleado_y_fechas()
            End If

        End If

    End Sub

    Private Sub btnHoy_Click(sender As Object, e As EventArgs) Handles btnHoy.Click
        btnHoy.ForeColor = Color.OrangeRed
        chekFiltros.Checked = False
        PanelFiltros.Visible = False
        reporte_resumen_de_ventas_hasta_hoy()
        TFILTROS.ForeColor = Color.DimGray

    End Sub

    Sub reporte_resumen_de_ventas_hasta_hoy()
        Dim reporte As New ReportRESUMENVentas()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try
            'reporte.TextBox12.Format = Format()
            'reporte.TextBox15.Format = FormatDateTime(Now(), DateFormat.ShortTime)
            abrir()
            daMA = New SqlDataAdapter("reporte_resumen_de_ventas_hasta_hoy", conexion)
            daMA.Fill(dtMA)
            Cerrar()
            reporte = New ReportRESUMENVentas
            reporte.Table1.DataSource = dtMA
            reporte.DataSource = dtMA

            ReportViewer1.Report = reporte
            ReportViewer1.RefreshReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnResumenVentas.Click
        Panel4.Enabled = True
        btnResumenVentas.ForeColor = Color.OrangeRed
        PResumenVentas.Visible = True
        PVentasPorempleado.Visible = False
        btnHoy.ForeColor = Color.OrangeRed
        PanelEmpleado.Visible = False
        reporte_resumen_de_ventas_hasta_hoy()
        chekFiltros.Checked = False
        TFILTROS.ForeColor = Color.DimGray
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        reporte_resumen_de_ventas_hasta_hoy()
        reporte_resumen_de_ventas_POR_FECHAS()
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        btnResumenVentas.ForeColor = Color.DimGray
        btnEmpleado.ForeColor = Color.OrangeRed
        Panel4.Enabled = True
        PResumenVentas.Visible = False
        PVentasPorempleado.Visible = True
        mostrar_empleados()
        'MessageBox.Show(valorSeleccionado)
        reporte_resumen_de_ventas_hasta_hoy_POR_EMPLEADO()
        PanelEmpleado.Visible = True
        btnHoy.ForeColor = Color.OrangeRed
        chekFiltros.Checked = False
        TFILTROS.ForeColor = Color.DimGray
    End Sub
    Sub reporte_resumen_de_ventas_hasta_hoy_POR_EMPLEADO()
        Dim reporte As New Reporte_de_ventas_por_empleado()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try

            abrir()
            daMA = New SqlDataAdapter("reporte_resumen_de_ventas_hasta_hoy_POR_EMPLEADO", conexion)
            daMA.SelectCommand.CommandType = CommandType.StoredProcedure
            daMA.SelectCommand.Parameters.AddWithValue("@Id_empleado", valorSeleccionado)
            daMA.Fill(dtMA)
            Cerrar()
            reporte = New Reporte_de_ventas_por_empleado
            reporte.Table1.DataSource = dtMA
            reporte.DataSource = dtMA

            ReportViewer1.Report = reporte
            ReportViewer1.RefreshReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public valorSeleccionado As Integer
    Private Sub txtEmpleado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtEmpleado.SelectedIndexChanged

        valorSeleccionado = txtEmpleado.SelectedValue
        If chekFiltros.Checked = True Then
            reporte_resumen_de_ventas_por_empleado_y_fechas()
        Else
            reporte_resumen_de_ventas_hasta_hoy_POR_EMPLEADO()
        End If
    End Sub

    Private Sub TFILTROS_Click(sender As Object, e As EventArgs) Handles TFILTROS.Click

    End Sub

    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        btnCobrar.BackColor = Color.White
        btnCobrar.ForeColor = Color.OrangeRed
        btnVentas.ForeColor = Color.FromArgb(64, 64, 64)
        btnVentas.BackColor = Color.FromArgb(242, 243, 244)
        BtnPagar.ForeColor = Color.FromArgb(64, 64, 64)
        BtnPagar.BackColor = Color.FromArgb(242, 243, 244)
        BtnProductos.ForeColor = Color.FromArgb(64, 64, 64)
        BtnProductos.BackColor = Color.FromArgb(242, 243, 244)





        PanelVENTAS.Visible = False
        PanelProductos.Visible = False
        PanelPorCobrarPagar.Visible = True
        PanelPorCobrarPagar.Dock = DockStyle.Fill
        PanelBienvenida.Dock = DockStyle.None
        PanelBienvenida.Visible = False
        reporte_de_cuentas_por_Cobrar()
    End Sub
    Sub reporte_de_cuentas_por_Cobrar()
        Dim reporte As New cuentas_por_cobrar()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try

            abrir()
            daMA = New SqlDataAdapter("reporte_de_cuentas_por_Cobrar", conexion)
            daMA.Fill(dtMA)
            Cerrar()
            reporte = New cuentas_por_cobrar
            reporte.Table1.DataSource = dtMA
            reporte.DataSource = dtMA

            ReportViewer2.Report = reporte
            ReportViewer2.RefreshReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub reporte_de_cuentas_por_PAGAR()
        Dim reporte As New Cuentas_pagar()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try

            abrir()
            daMA = New SqlDataAdapter("reporte_de_cuentas_por_PAGAR", conexion)
            daMA.Fill(dtMA)
            Cerrar()
            reporte = New Cuentas_pagar
            reporte.Table1.DataSource = dtMA
            reporte.DataSource = dtMA

            ReportViewer2.Report = reporte
            ReportViewer2.RefreshReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BtnPagar_Click(sender As Object, e As EventArgs) Handles BtnPagar.Click
        btnCobrar.BackColor = Color.FromArgb(242, 243, 244)
        btnCobrar.ForeColor = Color.FromArgb(64, 64, 64)
        btnVentas.ForeColor = Color.FromArgb(64, 64, 64)
        btnVentas.BackColor = Color.FromArgb(242, 243, 244)

        BtnProductos.ForeColor = Color.FromArgb(64, 64, 64)
        BtnProductos.BackColor = Color.FromArgb(242, 243, 244)



        BtnPagar.ForeColor = Color.OrangeRed
        BtnPagar.BackColor = Color.White
        PanelVENTAS.Visible = False
        PanelProductos.Visible = False
        PanelPorCobrarPagar.Visible = True
        PanelPorCobrarPagar.Dock = DockStyle.Fill
        PanelBienvenida.Dock = DockStyle.None
        PanelBienvenida.Visible = False
        reporte_de_cuentas_por_PAGAR()

    End Sub

    Private Sub BtnProductos_Click(sender As Object, e As EventArgs) Handles BtnProductos.Click
        btnCobrar.BackColor = Color.FromArgb(242, 243, 244)
        btnCobrar.ForeColor = Color.FromArgb(64, 64, 64)
        btnVentas.ForeColor = Color.FromArgb(64, 64, 64)
        btnVentas.BackColor = Color.FromArgb(242, 243, 244)
        BtnPagar.ForeColor = Color.FromArgb(64, 64, 64)
        BtnPagar.BackColor = Color.FromArgb(242, 243, 244)
        BtnProductos.ForeColor = Color.OrangeRed
        BtnProductos.BackColor = Color.White

        PanelVENTAS.Visible = False
        PanelProductos.Visible = True

        PanelPorCobrarPagar.Visible = False
        PanelProductos.Dock = DockStyle.Fill
        PanelBienvenida.Dock = DockStyle.None
        PanelBienvenida.Visible = False
        PInventarios.Visible = False
        Pvencidos.Visible = False
        PStockBajo.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PInventarios.Visible = True
        Pvencidos.Visible = False
        PStockBajo.Visible = False
        mostrar_inventarios_todos()
    End Sub
    Sub mostrar_inventarios_todos()
        Dim rptFREPORT2 As New ReportInventarios_Todos()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try
            abrir()
            daMA = New SqlDataAdapter("imprimir_inventarios_todos", conexion)

            daMA.Fill(dtMA)
            Cerrar()
            rptFREPORT2 = New ReportInventarios_Todos
            rptFREPORT2.DataSource = dtMA
            ReportViewer3.Visible = True
            ReportViewer3.Report = rptFREPORT2
            ReportViewer3.RefreshReport()
        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PInventarios.Visible = False
        Pvencidos.Visible = True
        PStockBajo.Visible = False
        buscar_productos_vencidos()
    End Sub

    Sub buscar_productos_vencidos()
        Dim rptFREPORT4 As New Report_productos_vencidos()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("REPORTE_productos_vencidos", conexion)

            da.Fill(dt)
            Cerrar()
            rptFREPORT4 = New Report_productos_vencidos
            rptFREPORT4.DataSource = dt
            rptFREPORT4.Table2.DataSource = dt
            ReportViewer3.Visible = True
            ReportViewer3.Report = rptFREPORT4
            ReportViewer3.RefreshReport()
        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PInventarios.Visible = False
        Pvencidos.Visible = False
        PStockBajo.Visible = True
        MOSTRAR_Inventarios_bajo_minimo()
    End Sub

    Sub MOSTRAR_Inventarios_bajo_minimo()
        Dim rptFREPORT2 As New ReportInventariosBajos()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try
            abrir()
            daMA = New SqlDataAdapter("MOSTRAR_Inventarios_bajo_minimo", conexion)
            daMA.Fill(dtMA)
            Cerrar()
            rptFREPORT2 = New ReportInventariosBajos
            ReportViewer3.Visible = True
            rptFREPORT2.DataSource = dtMA
            ReportViewer3.Report = rptFREPORT2
            ReportViewer3.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MENU_dE_REPORTES_OI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
        DASHBOARD_PRINCIPAL.ShowDialog()
    End Sub
End Class