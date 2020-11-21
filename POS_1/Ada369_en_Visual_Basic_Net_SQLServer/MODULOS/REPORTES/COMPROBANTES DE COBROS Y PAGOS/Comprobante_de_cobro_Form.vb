Imports System.Data.SqlClient
Imports System.Management
Public Class Comprobante_de_cobro_Form
    Dim idcaja As Integer
    Private Sub Comprobante_de_cobro_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIdSerial.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIdSerial.Text = lblIdSerial.Text.Trim()
        mostrar_caja()
        mostrar_detalle_de_venta_desde_el_medio_De_pago()
    End Sub
    Sub MOSTRAR_CAJA_POR_SERIAL()


        Dim dt As New DataTable

        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Serial", Encriptar(lblIdSerial.Text))

            da.Fill(dt)
            datalistado_caja.DataSource = dt
            Cerrar()

        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub mostrar_caja()
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIdSerial.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIdSerial.Text = lblIdSerial.Text.Trim()
        MOSTRAR_CAJA_POR_SERIAL()
        Try
            idcaja = datalistado_caja.SelectedCells.Item(1).Value
            MsgBox(idcaja)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub mostrar_detalle_de_venta_desde_el_medio_De_pago()
        Dim rptFREPORT2 As New Comproante_de_cobro()
        Dim dtMA As New DataTable
        Dim daMA As SqlDataAdapter
        Try
            abrir()
            daMA = New SqlDataAdapter("mostrar_detalle_de_cobro_para_Imprimir", conexion)
            daMA.SelectCommand.CommandType = 4
            daMA.SelectCommand.Parameters.AddWithValue("@id_caja", idcaja)

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

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class