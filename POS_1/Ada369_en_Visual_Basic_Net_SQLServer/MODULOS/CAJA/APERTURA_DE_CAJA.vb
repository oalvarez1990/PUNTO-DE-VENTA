

Imports System.Data.SqlClient

Imports System.Management
Imports System.Xml
Imports System.Net.Mail
Imports System.Net


Public Class APERTURA_DE_CAJA
   
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        Dim cmd As New SqlCommand
        Try
            If txtmonto.Text = "" Then txtmonto.Text = 0
            abrir()
            cmd = New SqlCommand("editar_dinero_caja_inicial", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Id_caja", txtidcaja.Text)
            cmd.Parameters.AddWithValue("@saldo", txtmonto.Text)
            cmd.ExecuteNonQuery()
            Cerrar()

        Catch ex As Exception : MsgBox(ex.Message)
        End Try

        Dispose()
        VENTAS_MENU_PRINCIPAL.ShowDialog()


    End Sub
    Private Sub APERTURA_DE_CAJA_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        End
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
    Private Sub APERTURA_DE_CAJA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","


        Panel1.Location = New Point(Me.Width - Width / 1.6, 160)
        txtmonto.Focus()

        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())
        MOSTRAR_CAJA_POR_SERIAL()
        Try
            txtidcaja.Text = datalistado_caja.SelectedCells.Item(1).Value
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click


        Me.Dispose()
        VENTAS_MENU_PRINCIPAL.ShowDialog()
        Me.Dispose()

    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto.KeyPress
        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then

            e.KeyChar =
                Threading.Thread.CurrentThread.
                CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        End If
        Separador_de_Numeros(txtmonto, e)
    End Sub

    Private Sub txtmonto_TextChanged(sender As Object, e As EventArgs) Handles txtmonto.TextChanged

    End Sub

    Private Sub APERTURA_DE_CAJA_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Alt + Keys.F4 Then
            End
        End If
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtmonto.Text = txtmonto.Text & "0"
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtmonto.Text = txtmonto.Text & "1"

    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtmonto.Text = txtmonto.Text & "2"
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtmonto.Text = txtmonto.Text & "3"
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtmonto.Text = txtmonto.Text & "4"
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtmonto.Text = txtmonto.Text & "5"
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtmonto.Text = txtmonto.Text & "6"
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtmonto.Text = txtmonto.Text & "7"


    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtmonto.Text = txtmonto.Text & "8"
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtmonto.Text = txtmonto.Text & "9"
    End Sub

    Private Sub btnborrarderecha_Click(sender As Object, e As EventArgs) Handles btnborrarderecha.Click
        Try
            Dim largo As Integer
            If txtmonto.Text <> "" Then
                largo = txtmonto.Text.Length
                txtmonto.Text = Mid(txtmonto.Text, 1, largo - 1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnborrartodo_Click(sender As Object, e As EventArgs) Handles btnborrartodo.Click
        txtmonto.Clear()
    End Sub
End Class