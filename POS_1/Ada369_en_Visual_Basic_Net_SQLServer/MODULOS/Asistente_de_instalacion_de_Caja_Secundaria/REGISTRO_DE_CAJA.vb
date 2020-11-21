Imports System.Data.SqlClient
Imports System.Management
Public Class REGISTRO_DE_CAJA
    Private Sub EMPRESA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","
        Panel16.Location = New Point((Width - Panel16.Width) / 2, (Height - Panel16.Height) / 2)
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())

    End Sub

    Private Sub TSIGUIENTE_Y_GUARDAR__Click(sender As Object, e As EventArgs) Handles TSIGUIENTE_Y_GUARDAR_.Click
        Dim conexionExpress As New SqlConnection(lblconexion.Text)
        Dim cmd As New SqlCommand
        If txtcaja.Text <> "" Then
            If txtRuta.Text <> "" Then
                Try
                    conexionExpress.Open()
                    cmd = New SqlCommand("Insertar_caja", conexionExpress)
                    cmd.CommandType = 4
                    cmd.Parameters.AddWithValue("@descripcion", txtcaja.Text)
                    cmd.Parameters.AddWithValue("@Tema", "Redentor")
                    cmd.Parameters.AddWithValue("@Serial_PC", lblIDSERIAL.Text)
                    cmd.Parameters.AddWithValue("@Impresora_Ticket", "Ninguna")
                    cmd.Parameters.AddWithValue("@Impresora_A4", "Ninguna")
                    cmd.Parameters.AddWithValue("@Tipo", "SECUNDARIA")
                    cmd.Parameters.AddWithValue("@Ruta_para_copias_de_seguridad", txtRuta.Text)
                    cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_de_seguridad", "Ninguna")
                    cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_date", txtfecha.Value)
                    cmd.Parameters.AddWithValue("@Frecuencia_de_copias", 1)
                    cmd.Parameters.AddWithValue("@Estado_Copia_De_seguridad", "PENDIENTE")
                    cmd.ExecuteNonQuery()
                    conexionExpress.Close()
                    insertar_inicio_De_sesion()
                    MessageBox.Show("Listo ya Tienes Esta CAJA Habilitada", "Caja Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MessageBox.Show("Asegúrese de Seleccionar una Carpeta para las Copias de seguridad", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Sub insertar_inicio_De_sesion()
        Try
            Dim conexionExpress As New SqlConnection(lblconexion.Text)
            Dim cmd As New SqlCommand
            conexionExpress.Open()
            cmd = New SqlCommand("insertar_inicio_De_sesion", conexionExpress)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Id_serial_Pc", lblIDSERIAL.Text)
            cmd.ExecuteNonQuery()
            conexionExpress.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub txtcaja_Click(sender As Object, e As EventArgs) Handles txtcaja.Click
        txtcaja.SelectAll()

    End Sub

    Private Sub txtcaja_TextChanged(sender As Object, e As EventArgs) Handles txtcaja.TextChanged

    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(sender As Object, e As EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txtRuta.Text = FolderBrowserDialog1.SelectedPath
            Dim ruta As String = txtRuta.Text
            If (ruta.Contains("C:\")) Then
                MessageBox.Show("Selecciona un Disco Diferente al Disco C:", "Ruta Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtRuta.Text = ""
            Else
                txtRuta.Text = FolderBrowserDialog1.SelectedPath

            End If


        End If
    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs) Handles ToolStripButton22.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txtRuta.Text = FolderBrowserDialog1.SelectedPath
            Dim ruta As String = txtRuta.Text
            If (ruta.Contains("C:\")) Then
                MessageBox.Show("Selecciona un Disco Diferente al Disco C:", "Ruta Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtRuta.Text = ""
            Else
                txtRuta.Text = FolderBrowserDialog1.SelectedPath

            End If


        End If
    End Sub

    Private Sub TSIGUIENTE_Y_GUARDAR_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles TSIGUIENTE_Y_GUARDAR.ItemClicked

    End Sub
End Class