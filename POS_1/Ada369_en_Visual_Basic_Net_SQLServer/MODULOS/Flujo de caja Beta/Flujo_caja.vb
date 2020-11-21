Imports System.Data.SqlClient
Public Class Flujo_caja
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        obtener_ventas()
        obtener_GASTOS()
        obtener_suma_de_ingresos_por_meses()

        Tipo = "Ingresos"
        descripcion = "Ventas"
        Insertar_Flujo_de_caja_ingresos()

        For Each row As DataGridViewRow In datalistadoGastos.Rows
            mes = Convert.ToString(row.Cells("mes").Value)
            monto = Convert.ToDouble(row.Cells("monto").Value)
            descripcion = Convert.ToString(row.Cells("Concepto").Value)
            Tipo = "Gastos"
            Insertar_Flujo_de_caja_gastos()
        Next
        mostrar_Flujo_de_caja()
        eliminar_flujo_de_caja()
    End Sub
    Sub eliminar_flujo_de_caja()
        Try
            abrir()
            Dim cmd As New SqlCommand("delete from Flujo_de_caja", conexion)
            cmd.ExecuteNonQuery()
            Cerrar()
        Catch ex As Exception

        End Try
    End Sub
    Sub obtener_ventas()
        Try
            abrir()
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter("Flujo_de_caja_ventas", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", año)

            da.Fill(dt)
            datalistadoVentasReport.DataSource = dt
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
    Sub obtener_GASTOS()
        Try
            abrir()
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter("Flujo_de_caja_Gastos", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", año)

            da.Fill(dt)
            datalistadoGastos.DataSource = dt
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & ex.StackTrace)

        End Try
    End Sub
    Public Sub Insertar_Flujo_de_caja_ingresos()
        Try
            abrir()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Insertar_Flujo_de_caja", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Enero", eneroI)


            cmd.Parameters.AddWithValue("@Febrero", febreroI)

            cmd.Parameters.AddWithValue("@Marzo", marzoI)

            cmd.Parameters.AddWithValue("@Abril", abrilI)

            cmd.Parameters.AddWithValue("@Mayo", mayoI)


            cmd.Parameters.AddWithValue("@Junio", junioI)

            cmd.Parameters.AddWithValue("@Julio", julioI)


            cmd.Parameters.AddWithValue("@Agosto", agostoI)

            cmd.Parameters.AddWithValue("@Septiembre", septiembreI)


            cmd.Parameters.AddWithValue("@Octubre", octubreI)

            cmd.Parameters.AddWithValue("@Noviembre", noviembreI)

            cmd.Parameters.AddWithValue("@Diciembre", diciembreI)

            cmd.Parameters.AddWithValue("@Tipo", Tipo)
            cmd.Parameters.AddWithValue("@Descripcion", descripcion)
            cmd.ExecuteNonQuery()
            Cerrar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Insertar_Flujo_de_caja_gastos()
        Try
            abrir()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Insertar_Flujo_de_caja", conexion)
            cmd.CommandType = 4
            If mes = 1 Then
                cmd.Parameters.AddWithValue("@Enero", eneroG)
            Else
                cmd.Parameters.AddWithValue("@Enero", 0)
            End If
            If mes = 2 Then
                cmd.Parameters.AddWithValue("@Febrero", febreroG)
            Else
                cmd.Parameters.AddWithValue("@Febrero", 0)
            End If
            If mes = 3 Then
                cmd.Parameters.AddWithValue("@Marzo", marzoG)
            Else
                cmd.Parameters.AddWithValue("@Marzo", 0)
            End If
            If mes = 4 Then
                cmd.Parameters.AddWithValue("@Abril", abrilG)
            Else
                cmd.Parameters.AddWithValue("@Abril", 0)
            End If
            If mes = 5 Then
                cmd.Parameters.AddWithValue("@Mayo", mayoG)
            Else
                cmd.Parameters.AddWithValue("@Mayo", 0)
            End If

            If mes = 6 Then
                cmd.Parameters.AddWithValue("@Junio", junioG)
            Else
                cmd.Parameters.AddWithValue("@Junio", 0)
            End If
            If mes = 7 Then
                cmd.Parameters.AddWithValue("@Julio", julioG)
            Else
                cmd.Parameters.AddWithValue("@Julio", 0)
            End If

            If mes = 8 Then
                cmd.Parameters.AddWithValue("@Agosto", agostoG)
            Else
                cmd.Parameters.AddWithValue("@Agosto", 0)
            End If
            If mes = 9 Then
                cmd.Parameters.AddWithValue("@Septiembre", septiembreG)
            Else
                cmd.Parameters.AddWithValue("@Septiembre", 0)
            End If

            If mes = 10 Then
                cmd.Parameters.AddWithValue("@Octubre", octubreG)
            Else
                cmd.Parameters.AddWithValue("@Octubre", 0)
            End If
            If mes = 11 Then
                cmd.Parameters.AddWithValue("@Noviembre", noviembreG)
            Else
                cmd.Parameters.AddWithValue("@Noviembre", 0)
            End If
            If mes = 12 Then
                cmd.Parameters.AddWithValue("@Diciembre", diciembreG)
            Else
                cmd.Parameters.AddWithValue("@Diciembre", 0)
            End If
            cmd.Parameters.AddWithValue("@Tipo", Tipo)
            cmd.Parameters.AddWithValue("@Descripcion", descripcion)
            cmd.ExecuteNonQuery()
            Cerrar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Flujo_caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        año = DatePart(DateInterval.Year, Now())
        obtener_ventas()
        obtener_GASTOS()
        obtener_suma_de_ingresos_por_meses()

        Tipo = "Ingresos"
        descripcion = "Ventas"
        Insertar_Flujo_de_caja_ingresos()

        For Each row As DataGridViewRow In datalistadoGastos.Rows
            mes = Convert.ToString(row.Cells("mes").Value)
            monto = Convert.ToDouble(row.Cells("monto").Value)
            descripcion = Convert.ToString(row.Cells("Concepto").Value)
            Tipo = "Gastos"
            Insertar_Flujo_de_caja_gastos()
        Next
        mostrar_Flujo_de_caja()
        eliminar_flujo_de_caja()
    End Sub
    Sub obtener_suma_de_ingresos_por_meses()
        For Each row As DataGridViewRow In datalistadoVentasReport.Rows
            mes = Convert.ToString(row.Cells("mes").Value)

            If mes = 1 Then
                eneroI = (row.Cells("monto").Value)
            End If
            If mes = 2 Then
                febreroI = (row.Cells("monto").Value)
            End If
            If mes = 3 Then
                marzoI = (row.Cells("monto").Value)
            End If
            If mes = 4 Then
                abrilI = (row.Cells("monto").Value)
            End If
            If mes = 5 Then
                mayoI = (row.Cells("monto").Value)
            End If
            If mes = 6 Then
                junioI = (row.Cells("monto").Value)
            End If
            If mes = 7 Then
                julioI = (row.Cells("monto").Value)
            End If
            If mes = 8 Then
                agostoI = (row.Cells("monto").Value)
            End If

            If mes = 9 Then
                septiembreI = (row.Cells("monto").Value)
            End If
            If mes = 10 Then
                octubreI += (row.Cells("monto").Value)
            End If
            If mes = 11 Then
                noviembreI = (row.Cells("monto").Value)
            End If
            If mes = 12 Then
                diciembreI = (row.Cells("monto").Value)
            End If
        Next
        For Each row As DataGridViewRow In datalistadoGastos.Rows
            mesgasto = Convert.ToString(row.Cells("mes").Value)
            If mesgasto = 1 Then
                eneroG = (row.Cells("monto").Value)
            End If
            If mesgasto = 2 Then
                febreroG = (row.Cells("monto").Value)
            End If
            If mesgasto = 3 Then
                marzoG = (row.Cells("monto").Value)
            End If
            If mesgasto = 4 Then
                abrilG = (row.Cells("monto").Value)
            End If
            If mesgasto = 5 Then
                mayoG = (row.Cells("monto").Value)
            End If
            If mesgasto = 6 Then
                junioG = (row.Cells("monto").Value)
            End If
            If mesgasto = 7 Then
                julioG = (row.Cells("monto").Value)
            End If
            If mesgasto = 8 Then
                agostoG = (row.Cells("monto").Value)
            End If

            If mesgasto = 9 Then
                septiembreG = (row.Cells("monto").Value)
            End If
            If mesgasto = 10 Then
                octubreG += (row.Cells("monto").Value)
            End If
            If mesgasto = 11 Then
                noviembreG = (row.Cells("monto").Value)
            End If
            If mesgasto = 12 Then
                diciembreG = (row.Cells("monto").Value)
            End If
        Next


    End Sub
    Sub mostrar_Flujo_de_caja()
        Dim rptFREPORT2 As New Flujo_de_Caja_report()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try
            abrir()
            daMA = New SqlDataAdapter("mostrar_flujo_de_caja", conexion)
            daMA.SelectCommand.CommandType = 4
            daMA.SelectCommand.Parameters.AddWithValue("@Tenero", eneroI - eneroG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tfebrero", febreroI - febreroG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tmarzo", marzoI - marzoG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tabril", abrilI - abrilG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tmayo", mayoI - mayoG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tjunio", junioI - junioG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tjulio", julioI - julioG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tagosto", agostoI - agostoG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tseptiembre", septiembreI - septiembreG)
            daMA.SelectCommand.Parameters.AddWithValue("@Toctubre", octubreI - octubreG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tnoviembre", noviembreI - noviembreG)
            daMA.SelectCommand.Parameters.AddWithValue("@Tdiciembre", diciembreI - diciembreG)
            daMA.SelectCommand.Parameters.AddWithValue("@anio", año)

            daMA.Fill(dtMA)
            Cerrar()
            rptFREPORT2 = New Flujo_de_Caja_report
            rptFREPORT2.Table1.DataSource = dtMA
            rptFREPORT2.DataSource = dtMA

            ReportViewer1.Report = rptFREPORT2
            'Dim ancho As Unit = rptFREPORT2.PageSettings.PaperSize.Width
            'Dim alto As Unit = rptFREPORT2.Table1.Size.Height
            'rptFREPORT2.PageSettings.PaperSize = New SizeU(ancho, Unit.Cm(20) + Unit.Cm(0.6 * contador_de_items_ventas))
            ReportViewer1.RefreshReport()
            'VENTAS_MENU_PRINCIPAL.lblEfectivo.Text = txtefectivo2.Text
            'VENTAS_MENU_PRINCIPAL.lblVuelto.Text = TXTVUELTO.Text


        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub datalistadoGastos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoGastos.CellContentClick

    End Sub
End Class