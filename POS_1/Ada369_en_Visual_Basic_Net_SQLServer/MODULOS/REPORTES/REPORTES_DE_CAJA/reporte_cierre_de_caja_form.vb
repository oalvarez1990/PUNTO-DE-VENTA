Imports System.Data.SqlClient

Public Class reporte_cierre_de_caja_form
    Private Sub reporte_cierre_de_caja_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reporte_cierre_de_caja()
    End Sub
    Sub reporte_cierre_de_caja()
        Dim rptFREPORT2 As New Report_cierre_De_turno()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try
            abrir()
            daMA = New SqlDataAdapter("reporte_cierre_de_caja", conexion)
            daMA.SelectCommand.CommandType = 4
            daMA.SelectCommand.Parameters.AddWithValue("@ventastotales", CIERRE_DE_CAJA.LBLTOTALVENTAS.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@ganancia", CIERRE_DE_CAJA.lblgananciasVentas.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@fondo", CIERRE_DE_CAJA.lblfondodeCaja.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@ventasefectivo", CIERRE_DE_CAJA.LBLVENTASenEfectivo.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@pagosefectivo", CIERRE_DE_CAJA.lblPAGOSEfectivo.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@cobrosefectivo", CIERRE_DE_CAJA.lblabonosEfectivo.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@ingresosvarios", CIERRE_DE_CAJA.LBLENTRADASVARIAS.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@gastosvarios", CIERRE_DE_CAJA.lblsalidasvarias.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@esperado", CIERRE_DE_CAJA.lblDineroEncajaTurno.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@Vefectivo", CIERRE_DE_CAJA.LBLVentasEnEfectivo2.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@Vtarjeta", CIERRE_DE_CAJA.lblventas_Tarjeta.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@Vcredito", CIERRE_DE_CAJA.lblVentasAcredito.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@TOTALventas", CIERRE_DE_CAJA.lblVentas_suma.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@cajero", VENTAS_MENU_PRINCIPAL.lblLogin.Text)
            daMA.SelectCommand.Parameters.AddWithValue("@fechas", "Desde " & CIERRE_DE_CAJA.fechainicial & " hasta " & CIERRE_DE_CAJA.lblfechaActual.Value)
            daMA.SelectCommand.Parameters.AddWithValue("@caja", "Cuadre de Caja")


            daMA.Fill(dtMA)
            Cerrar()
            rptFREPORT2 = New Report_cierre_De_turno
            'rptFREPORT2.Table1.DataSource = dtMA
            rptFREPORT2.DataSource = dtMA

            ReportViewer1.Report = rptFREPORT2
            ReportViewer1.RefreshReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class