Imports System.Data.SqlClient
Imports System.Xml
Imports System.Management


Public Class Eleccion_Servidor_o_remoto

    Private aes As New AES()

    Sub Listar()

        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("select * from Empresa", conexion)
            da.Fill(dt)
            datalistado.DataSource = dt
            Cerrar()
            lblEstado_de_conexion.Text = "CONECTADO"
        Catch ex As Exception
            'MsgBox(ex.Message)

        End Try


    End Sub
    Dim dbcnString As String
    Dim Indicador_de_instanciador As String
    Public Sub ReadfromXML_Indicador_de_instanciador()
        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Indicador_de_instanciador.xml")
            Dim root As XmlElement = doc.DocumentElement
            dbcnString = root.Attributes.Item(0).Value
            Indicador_de_instanciador = (AES.Decrypt(dbcnString, appPwdUnique, Integer.Parse("256")))


        Catch ex As System.Security.Cryptography.CryptographicException
        End Try
    End Sub
    Private Sub Eleccion_Servidor_o_remoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Location = New Point((Width - Panel4.Width) / 2, (Height - Panel4.Height) / 2)

        Listar()

        If lblEstado_de_conexion.Text = "CONECTADO" Then

            Dispose()
            REGISTRO_DE_EMPRESA.ShowDialog()

        Else

        End If
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dispose()
        Instalacion_del_servidorSQL.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dispose()
        Conexion_caja_secundaria.ShowDialog()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click


    End Sub
End Class