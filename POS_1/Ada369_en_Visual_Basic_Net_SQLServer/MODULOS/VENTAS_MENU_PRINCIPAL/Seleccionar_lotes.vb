Imports System.Data.SqlClient
Public Class Seleccionar_lotes
    Private Sub Seleccionar_lotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar_Producto_por_lote()
    End Sub
    Sub mostrar_Producto_por_lote()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("mostrar_Producto_por_lote_en_ventas", conexion)
        Try
            abrir()
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Descripcion", VENTAS_MENU_PRINCIPAL.DATALISTADO_PRODUCTOS_OKA.SelectedCells.Item(17).Value)
            da.Fill(dt)
            datalistadoLOTES.DataSource = dt
            Cerrar()
            datalistadoLOTES.Columns(1).Visible = False

            datalistadoLOTES.Columns(7).Visible = False
            'datalistadoLOTES.Columns(9).Visible = False
            'datalistadoLOTES.Columns(10).Visible = False
            'datalistadoLOTES.Columns(11).Visible = False
        Catch ex As Exception
        End Try
        Multilinea(datalistadoLOTES)
    End Sub

    Private Sub datalistadoLOTES_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoLOTES.CellContentClick

    End Sub

    Private Sub datalistadoLOTES_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistadoLOTES.CellDoubleClick
        VENTAS_MENU_PRINCIPAL.txtbuscar.Text = datalistadoLOTES.SelectedCells.Item(7).Value
        VENTAS_MENU_PRINCIPAL.lblidproducto.Text = datalistadoLOTES.SelectedCells.Item(1).Value
        VENTAS_MENU_PRINCIPAL.vender_por_teclado()
        Dispose()


    End Sub
End Class