
Imports System.Data
Imports System.Data.SqlClient
Imports System.Management

Public Class LISTADO_GASTOS_VARIOS
    Dim lblidcaja As Integer
    Dim fechainicial As DateTime

    Private Sub LISTADO_GASTOS_VARIOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cambiar_de_nomenclatura_global()
        obtener_serialPc()
        MOSTRAR_CAJA_POR_SERIAL()
        MOSTRAR_CIERRE_DE_CAJA_PENDIENTE()
        obtener_fecha_inicial()
        centrar_panel_principal()
        mostrar_gastos_por_turnos()
        mostrar_ingresos_por_turnos()
    End Sub
    Sub centrar_panel_principal()
        Panel7.Location = New Point((Width - Panel7.Width) / 2, (Height - Panel7.Height) / 2)
    End Sub
    Sub cambiar_de_nomenclatura_global()
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-ES")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","
    End Sub
    Sub obtener_fecha_inicial()
        Try
            fechainicial = datalistado_CIERRE_DE_CAJA_PENDIENTE.SelectedCells.Item(1).Value

        Catch ex As Exception

        End Try
    End Sub
    Sub obtener_serialPc()
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())
    End Sub
    Sub MOSTRAR_CAJA_POR_SERIAL()

        Dim com As New SqlCommand("mostrar_cajas_por_Serial_de_DiscoDuro", conexion)
        com.CommandType = 4
        com.Parameters.AddWithValue("@Serial", (lblIDSERIAL.Text))

        Try
            abrir()
            lblidcaja = (com.ExecuteScalar())
            Cerrar()

        Catch ex As Exception


        End Try
    End Sub
    Sub MOSTRAR_CIERRE_DE_CAJA_PENDIENTE()

        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("MOSTRAR_CIERRE_DE_CAJA_PENDIENTE", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@serial", lblIDSERIAL.Text)

            da.Fill(dt)
            datalistado_CIERRE_DE_CAJA_PENDIENTE.DataSource = dt
            Cerrar()
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub mostrar_gastos_por_turnos()
        Try
            abrir()
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter("mostrar_gastos_por_turnos", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@id_caja", lblidcaja)
            da.SelectCommand.Parameters.AddWithValue("@fi", fechainicial)
            da.SelectCommand.Parameters.AddWithValue("@ff", Now())
            da.Fill(dt)
            datalistadogastos.DataSource = dt
            Cerrar()
            datalistadogastos.Columns(1).Visible = False
            sumar_gastos()
            Multilinea(datalistadogastos)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub sumar_gastos()
        Dim totalpagar As Double
        totalpagar = 0
        Dim fila As DataGridViewRow = New DataGridViewRow()
        For Each fila In datalistadogastos.Rows
            totalpagar += (fila.Cells("Monto").Value)
        Next
        lbltotalGastos.Text = totalpagar
        lbltotalGastos.Text = Format(CType(lbltotalGastos.Text, Decimal), "##0.00")
    End Sub
    Sub sumar_ingresos()
        Dim totalpagar As Double
        totalpagar = 0
        Dim fila As DataGridViewRow = New DataGridViewRow()
        For Each fila In datalistadoingresos.Rows
            totalpagar += (fila.Cells("Monto").Value)
        Next
        lbltotalIngresos.Text = totalpagar
        lbltotalIngresos.Text = Format(CType(lbltotalIngresos.Text, Decimal), "##0.00")
    End Sub
    Sub mostrar_ingresos_por_turnos()
        Try
            abrir()
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter("mostrar_ingresos_por_turnos", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@id_caja", lblidcaja)
            da.SelectCommand.Parameters.AddWithValue("@fi", fechainicial)
            da.SelectCommand.Parameters.AddWithValue("@ff", Now())
            da.Fill(dt)
            datalistadoingresos.DataSource = dt
            Cerrar()
            datalistadoingresos.Columns(1).Visible = False
            sumar_ingresos()
            Multilinea(datalistadoingresos)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub datalistado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadogastos.CellContentClick

    End Sub

    Private Sub datalistado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadogastos.CellClick
        If e.ColumnIndex = Me.datalistadogastos.Columns.Item("EliminarG").Index Then
            Dim result As DialogResult
            result = MessageBox.Show("¿Realmente desea eliminar este Gasto?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.OK Then
                Try
                    Dim idgasto As Integer
                    idgasto = datalistadogastos.SelectedCells.Item(1).Value
                    abrir()
                    Dim cmd As New SqlCommand("eliminar_gasto", conexion)
                    cmd.CommandType = 4
                    cmd.Parameters.AddWithValue("@idgasto", idgasto)
                    cmd.ExecuteNonQuery()
                    Cerrar()
                    mostrar_gastos_por_turnos()
                Catch ex As Exception

                End Try
            End If



        End If
    End Sub

    Private Sub datalistadoingresos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoingresos.CellContentClick

    End Sub

    Private Sub datalistadoingresos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoingresos.CellClick
        If e.ColumnIndex = Me.datalistadoingresos.Columns.Item("EliminarI").Index Then
            Dim result As DialogResult
            result = MessageBox.Show("¿Realmente desea eliminar este Ingreso?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.OK Then
                Try
                    Dim idingreso As Integer
                    idingreso = datalistadoingresos.SelectedCells.Item(1).Value
                    abrir()
                    Dim cmd As New SqlCommand("eliminar_ingreso", conexion)
                    cmd.CommandType = 4
                    cmd.Parameters.AddWithValue("@idingreso", idingreso)
                    cmd.ExecuteNonQuery()
                    Cerrar()
                    mostrar_ingresos_por_turnos()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If



        End If
    End Sub

    Private Sub LISTADO_GASTOS_VARIOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
End Class