Imports System.Data.SqlClient
Imports System.Xml
Imports System.Management
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Net.Dns
Imports System.DirectoryServices
Public Class Conexion_caja_secundaria
    Private Sub Conexion_caja_secundaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Panel2.Location = New Point((Width - Panel2.Width) / 2, (Height - Panel2.Height) / 2)
        'LeerXML_con_la_base_de_datos()
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())
    End Sub

    Sub conectar_manualmente()
        Dim IP As String = txtservidor.Text
        cadena_de_conexion = "Data Source =" & IP & ";Initial Catalog=BASEADA;Integrated Security=False; User Id=ada369;Password=softwarereal"
        mostrar_conexion()
        If indicador_de_conexion = "HAY CONEXION" Then
            SavetoXML(aes.Encrypt(cadena_de_conexion, appPwdUnique, Integer.Parse("256")))
            mostrar_estacion_por_serial()
            If datalistado_movimientos_validar.RowCount > 0 Then
                Label3.Text = "!Conectado!"
                MessageBox.Show("Conexion Correcta. Vuelve a Abrir el Sistema", "Conexion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dispose()
            ElseIf datalistado_movimientos_validar.RowCount = 0 Then
                REGISTRO_DE_CAJA.lblconexion.Text = cadena_de_conexion
                Dispose()
                REGISTRO_DE_CAJA.ShowDialog()
            End If
        Else
            MessageBox.Show("Sin conexion", "Desconectado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Sub mostrar_estacion_por_serial()

        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Try
                Dim conexionManual As New SqlConnection(cadena_de_conexion)
                conexionManual.Open()
                da = New SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", conexionManual)

                da.SelectCommand.CommandType = 4
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblIDSERIAL.Text)
                da.Fill(dt)
                datalistado_movimientos_validar.DataSource = dt
                conexionManual.Close()
                indicador = "HAY CONEXION"

            Catch ex As Exception

            End Try
        Catch ex As Exception

            indicador = "NO HAY CONEXION"

        End Try


    End Sub
    Dim indicador_de_conexion As String
    Sub mostrar_conexion()


        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            Dim conexionManual As New SqlConnection(cadena_de_conexion)
            conexionManual.Open()
            da = New SqlDataAdapter("select * from USUARIO2", conexionManual)
            da.Fill(dt)
            datalistadoConexion.DataSource = dt
            conexionManual.Close()
            indicador_de_conexion = "HAY CONEXION"

        Catch ex As Exception
            indicador_de_conexion = "NO HAY CONEXION"
        End Try





    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        hide()
        Eleccion_Servidor_o_remoto.ShowDialog()

    End Sub
    Dim base_de_datos As String
    Dim servidor As String
    Dim Contraseña_base_de_datos As String

    Public Sub LeerXML_con_la_base_de_datos()
        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Base_de_datos.xml")
            Dim root As XmlElement = doc.DocumentElement
            base_de_datos = root.Attributes.Item(0).Value
            'txtBasededatos.Text = (aes.Decrypt(base_de_datos, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException

        End Try
    End Sub
    Public Sub LeerXML_servidor()
        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Servidor.xml")
            Dim root As XmlElement = doc.DocumentElement
            servidor = root.Attributes.Item(0).Value
            txtservidor.Text = (aes.Decrypt(servidor, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException

        End Try
    End Sub
    Public Sub LeerXML_con_la_contraseña_base_de_datos()
        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Passwor_Base_de_datos.xml")
            Dim root As XmlElement = doc.DocumentElement
            Contraseña_base_de_datos = root.Attributes.Item(0).Value
            'txtcontraseñaBd.Text = (aes.Decrypt(Contraseña_base_de_datos, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException

        End Try
    End Sub
    Public Sub SavetoXML(ByVal dbcnString)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("ConnectionString.xml")
        Dim root As XmlElement = doc.DocumentElement
        root.Attributes.Item(0).Value = dbcnString
        Dim writer As XmlTextWriter = New XmlTextWriter("ConnectionString.xml", Nothing)
        writer.Formatting = Formatting.Indented
        doc.Save(writer)
        writer.Close()
    End Sub
    Private aes As New AES()
    Dim indicador As String

    Sub mostrar_usuario()

        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter

            da = New SqlDataAdapter("select * from USUARIO2", cadena_de_conexion)
            da.Fill(dt)
            datalistado_movimientos_validar.DataSource = dt

            indicador = "HAY CONEXION"
        Catch ex As Exception
            MessageBox.Show("Conexion Fallida, Revisa de nuevo la Cadena de Conexion o Escribenos para Ayudarte de Inmediato", "Sin Conexion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            indicador = "NO HAY CONEXION"

        End Try


    End Sub
    Public cadena_de_conexion As String

    'Private Sub btnSave_Click(sender As Object, e As EventArgs)
    '    cadena_de_conexion = "Data Source=" & txtCnString.Text & ";Initial Catalog=" & txtBasededatos.Text & "; Integrated Security=False; User Id=" & txtusuarioBd.Text & "; Password=" & txtcontraseñaBd.Text
    '    If txtCnString.Text = "" Then
    '        MessageBox.Show("Por favor ingrese la cadena de Conexion..", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Else
    '        SavetoXML(aes.Encrypt(cadena_de_conexion, appPwdUnique, Integer.Parse("256")))
    '        'MessageBox.Show("Conexion Creada Archivo: ConnectionString.xml", "Encryptacion completa", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        mostrar_usuario()
    '        If indicador = "HAY CONEXION" Then
    '            REGISTRO_DE_CAJA.lblconexion.Text = cadena_de_conexion
    '            Dispose()
    '            REGISTRO_DE_CAJA.ShowDialog()
    '            REGISTRO_DE_CAJA.lblconexion.Text = cadena_de_conexion

    '        End If
    '    End If
    'End Sub
    Sub escanear_ips_en_red()
        Try
            Dim DomainEntry As New DirectoryEntry("WinNT://" & "WORKGROUP")
            DomainEntry.Children.SchemaFilter.Add("computer")
            For Each machine As DirectoryEntry In DomainEntry.Children
                Dim Ipaddr As String
                Dim Tempaddr As System.Net.IPHostEntry
                Try
                    Tempaddr = GetHostByName(machine.Name)
                Catch ex As Exception
                    Continue For
                End Try
                Try
                    Dim TempAd As IPAddress() = Tempaddr.AddressList
                    For Each TempA As IPAddress In TempAd
                        Ipaddr = TempA.ToString()
                    Next
                Catch ex As Exception
                    Continue For
                End Try
                Me.datalistado.Rows.Add(Ipaddr)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        escanear_ips_en_red()
        'conectar_automatico()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Panel1.Visible = True
        Panel1.Dock = DockStyle.Fill

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Panel1.Visible = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        conectar_manualmente()
    End Sub
End Class