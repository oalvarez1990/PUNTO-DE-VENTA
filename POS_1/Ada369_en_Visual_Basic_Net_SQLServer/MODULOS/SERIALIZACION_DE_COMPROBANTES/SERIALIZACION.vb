


Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.ComponentModel

Public Class SERIALIZACION
    Dim DTc As New DataTable
    Dim DTe As New DataTable
    Dim DTt As New DataTable

    Private Sub contar()
        Dim x As Integer
        x = datalistado.Rows.Count
        txtcontador.Text = CStr(x)
    End Sub

    Private Sub ocultar_columnas()
        datalistado.Columns(1).Visible = False
    End Sub

    Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_Tipo_de_documentos_para_insertar_estos_mismos", conexion)
            da.Fill(dt)
            datalistado.DataSource = dt
            contar()
            datalistado.Columns(1).Visible = False
            datalistado.Columns(2).Visible = False
            datalistado.Columns(3).Visible = False
            datalistado.Columns(4).Visible = False
            datalistado.Columns(5).Width = 220
            datalistado.Columns(6).Width = 520
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
        Me.datalistado.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.White
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Segoe UI", 10, FontStyle.Regular Or
        FontStyle.Bold)
        Me.datalistado.ColumnHeadersDefaultCellStyle = styCabeceras


    End Sub

    Private Sub EMPRESA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","
        Panel2.Visible = False
        MenuStrip2.Visible = True
        datalistado.Enabled = True
        Listar()
        GUARDARCAMBIOS.Visible = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Dim result As DialogResult
        Dim cmd As SqlCommand
        result = MessageBox.Show("Realmente desea eliminar los registros seleccionados?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In datalistado.SelectedRows
                    Dim onekey As Integer = Convert.ToInt32(row.Cells("Id_serializacion").Value)
                    Try
                        abrir()
                        cmd = New SqlCommand("eliminar_Serializacion", conexion)
                        cmd.CommandType = 4
                        cmd.Parameters.AddWithValue("@id", onekey)
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception : MsgBox(ex.Message)

                    End Try
                    Cerrar()


                Next
                Call Listar()




            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

        End If
        'ElseIf CONTROL_TOTAL.txtadmin.Text = "NO" Then
        'MsgBox("NO TIENES PERMISOS de Admin,Contacta al Administrador")

        'End If
    End Sub

    Private Sub datalistado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellDoubleClick
        Panel2.Visible = True
        Try
            TXTCOMPRO.Text = datalistado.SelectedCells.Item(6).Value

            TXTCANTIDADDECEROS.Text = datalistado.SelectedCells.Item(2).Value
            txtnumerofin.Text = datalistado.SelectedCells.Item(3).Value
            txtSerie.Text = datalistado.SelectedCells.Item(1).Value
            GUARDAR.Visible = False
            GUARDARCAMBIOS.Visible = True
            If datalistado.SelectedCells.Item(7).Value = "SI" Then
                checkDefecto.Visible = False
                checkDefecto.Checked = True
            Else
                checkDefecto.Visible = True
                checkDefecto.Checked = False


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnvolver_Click(sender As Object, e As EventArgs) Handles btnvolver.Click
        Panel2.Visible = False
        Listar()

    End Sub


    Private Sub GUARDAR_Click(sender As Object, e As EventArgs) Handles GUARDAR.Click
        ELEJIR_POR_DEFECTO()

        Try



            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("insertar_Serializacion", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Serie", txtSerie.Text)
            cmd.Parameters.AddWithValue("@numeroinicio", TXTCANTIDADDECEROS.Text)
            cmd.Parameters.AddWithValue("@numerofin", txtnumerofin.Text)
            cmd.Parameters.AddWithValue("@Destino", "OTROS")
            cmd.Parameters.AddWithValue("@Id_tipodoc", TXTCOMPRO.Text)
            cmd.Parameters.AddWithValue("@Por_defecto", "-")
            cmd.ExecuteNonQuery()
            Cerrar()
            Listar()
            Panel2.Visible = False



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Panel2.Visible = True
        GUARDAR.Visible = True
        GUARDARCAMBIOS.Visible = False
        TXTCOMPRO.Clear()
        TXTCANTIDADDECEROS.Clear()
        txtnumerofin.Clear()
        txtSerie.Clear()
    End Sub

    Private Sub VOLVEROK_Click(sender As Object, e As EventArgs) Handles VOLVEROK.Click
        Panel2.Visible = False
        ELEJIR_POR_DEFECTO()
    End Sub

    Private Sub GUARDARCAMBIOS_Click(sender As Object, e As EventArgs) Handles GUARDARCAMBIOS.Click
        ELEJIR_POR_DEFECTO()

        Try

            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("editar_serializacion", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Serie", txtSerie.Text)
            cmd.Parameters.AddWithValue("@Cantidad_de_numeros", TXTCANTIDADDECEROS.Text)
            cmd.Parameters.AddWithValue("@numerofin", txtnumerofin.Text)
            cmd.Parameters.AddWithValue("@Tipo", TXTCOMPRO.Text)
            cmd.Parameters.AddWithValue("@Id_serie", datalistado.SelectedCells.Item(4).Value)
            cmd.ExecuteNonQuery()
            Cerrar()
            Listar()
            Panel2.Visible = False


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtnumeroinicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCANTIDADDECEROS.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            ' 
            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(TXTCANTIDADDECEROS, e)
    End Sub






    Private Sub txtprecio_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Public Sub NumerosyDecimal(ByVal CajaTexto As System.Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        ElseIf e.KeyChar = "," Then
            e.Handled = False

        Else
            e.Handled = True

        End If


    End Sub


    Private Sub txtprecio_descuento_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub txtnumeroinicio_TextChanged(sender As Object, e As EventArgs) Handles TXTCANTIDADDECEROS.TextChanged

    End Sub

    Private Sub txtnumerofin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumerofin.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            ' 
            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        NumerosyDecimal(txtnumerofin, e)
    End Sub

    Private Sub txtnumerofin_TextChanged(sender As Object, e As EventArgs) Handles txtnumerofin.TextChanged

    End Sub

    Private Sub txtserie_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Sub ELEJIR_POR_DEFECTO()
        If checkDefecto.Checked = True Then
            Try
                Dim cmd As New SqlCommand
                abrir()
                cmd = New SqlCommand("editar_serializacion_POR_DEFECTO", conexion)
                cmd.CommandType = 4

                cmd.Parameters.AddWithValue("@Id_serie", datalistado.SelectedCells.Item(4).Value)
                cmd.ExecuteNonQuery()
                Cerrar()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub checkDefecto_CheckedChanged(sender As Object, e As EventArgs) Handles checkDefecto.CheckedChanged




    End Sub

    Private Sub SERIALIZACION_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ELEJIR_POR_DEFECTO()
    End Sub
End Class