


Imports System.IO

Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Imports Microsoft.VisualBasic

Imports System.Windows.Forms
Imports System.Management
Imports System.Threading




Public Class GENERADOR_DE_COPIAS_AUTOMATICO
    Private Hilo As Thread
    Dim acaba As Boolean = False
    Dim CONTADOR As Integer
    Private aes As New AES()

    Public Shared Sub Main()
        Dim path As String = "C:\CI"
        Dim di As DirectoryInfo = Directory.CreateDirectory(path)
        Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path))
        di.Delete()
        Console.WriteLine("The directory was deleted successfully.")
        Try

            If Directory.Exists(path) Then
                Console.WriteLine("That path exists already.")
                Return
            End If


        Catch e As Exception
            MsgBox("HOLA")
            Console.WriteLine("The process failed: {0}", e.ToString())

        Finally
        End Try
    End Sub
    Sub MOSTRAR_cajas_por_serial()

        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("MOSTRAR_cajas_por_serial", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@serial", lblIDSERIAL.Text)
            da.Fill(dt)
            datalistado_cajas.DataSource = dt
            Cerrar()

        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try




    End Sub
    Sub Cargar_id_serial_pc()
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        lblIDSERIAL.Text = serialDD.Properties("SerialNumber").Value.ToString
        lblIDSERIAL.Text = Encriptar(lblIDSERIAL.Text.Trim())
    End Sub
    Dim idcaja As Integer
    Private Sub GENERADOR_DE_COPIAS_AUTOMATICO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_id_serial_pc()
        MOSTRAR_cajas_por_serial()
        Try
            txtRuta.Text = datalistado_cajas.SelectedCells.Item(8).Value
            lblfecha.Text = datalistado_cajas.SelectedCells.Item(9).Value
            lbldirectorio.Text = "Copia Guardada en: " & txtRuta.Text & "\" & "BASEADA.bak"
            lbldirectorio.Visible = False
            lblfrecuencia.Text = datalistado_cajas.SelectedCells.Item(11).Value
            idcaja = datalistado_cajas.SelectedCells.Item(3).Value
        Catch ex As Exception

        End Try
        txtRuta.BackColor = Color.White
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim ruta1 As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim ruta2 As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        Dim miCarpeta As String = "C:\Respaldos_ADA369"
        Try
            If Directory.Exists(miCarpeta) Then

            Else

                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(ruta1, miCarpeta))

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Dim Servidor As String
    Public Sub LeerXML_Servidor()

        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Servidor.xml")
            Dim root As XmlElement = doc.DocumentElement
            Servidor = root.Attributes.Item(0).Value
            Servidor = (AES.Decrypt(Servidor, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException


        End Try
    End Sub
    Dim txtsoftware As String
    Public Sub LeerXML_Nombre_De_software()

        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Software.xml")
            Dim root As XmlElement = doc.DocumentElement
            txtsoftware = root.Attributes.Item(0).Value
            txtsoftware = (AES.Decrypt(txtsoftware, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException


        End Try
    End Sub
    Dim Base_De_datos As String
    Public Sub LeerXML_base_de_datos()

        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Base_de_datos.xml")
            Dim root As XmlElement = doc.DocumentElement
            Base_De_datos = root.Attributes.Item(0).Value
            Base_De_datos = (AES.Decrypt(Base_De_datos, appPwdUnique, Integer.Parse("256")))

        Catch ex As System.Security.Cryptography.CryptographicException


        End Try
    End Sub
    Sub executa()
        LeerXML_Nombre_De_software()
        LeerXML_base_de_datos()

        Dim miCarpeta As String = "Copias_de_Seguridad_de_" & txtsoftware

        If My.Computer.FileSystem.DirectoryExists(txtRuta.Text & miCarpeta) Then
        Else
            My.Computer.FileSystem.CreateDirectory(txtRuta.Text & miCarpeta)
        End If

        ''''''Dim ruta As String = txtRuta.Text & miCarpeta & "\Licencia_" & txtsoftware.Text & "_" & Now.Day & "_" & Now.Month & "_" & Now.Year & "_" & Hour(TimeOfDay) & "_" & Minute(TimeOfDay) & ".xml"
        ''''''Dim fi As FileInfo = New FileInfo(ruta)
        ''''''Dim sw As StreamWriter
        ''''''Try
        ''''''    If File.Exists(ruta) = False Then
        ''''''        sw = File.CreateText(ruta)
        ''''''        sw.WriteLine(XMLparte1.Text & "hola" & xmlParte2.Text)
        ''''''        sw.Flush()
        ''''''        sw.Close()
        ''''''    ElseIf File.Exists(ruta) = True Then
        ''''''        File.Delete(ruta)
        ''''''        sw = File.CreateText(ruta)

        ''''''        sw.WriteLine(XMLparte1.Text & "hola" & xmlParte2.Text)
        ''''''        sw.Flush()
        ''''''        sw.Close()
        ''''''    End If
        ''''''Catch ex As Exception

        ''''''End Try
        Dim ruta_completa As String = txtRuta.Text & miCarpeta

        Dim ruta2 As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        Dim SubCarpeta As String = ruta_completa & "\Respaldo_al_" & Now.Day & "_" & MonthName(Now.Month) & "_" & Now.Year & "_" & Hour(TimeOfDay) & "_" & Minute(TimeOfDay)


        Try
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(ruta_completa, SubCarpeta))
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try


        Try
            Dim v_nombre_respaldo As String
            v_nombre_respaldo = Base_De_datos & ".bak"
            abrir()
            Dim cmd As New SqlCommand("BACKUP DATABASE " & Base_De_datos & " TO DISK = '" & SubCarpeta & "\" & v_nombre_respaldo & "'", conexion)
            cmd.ExecuteNonQuery()
            Cerrar()
            acaba = True
        Catch ex As Exception
            End
        End Try
    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs) Handles ToolStripButton22.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then

            txtRuta.Text = FolderBrowserDialog1.SelectedPath


        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (acaba = True) Then


            Me.Button2.Enabled = True

            Me.Button2.Refresh()

            'PicBox.Visible = False
            PictureBox1.Visible = False
            Panel1.Enabled = True
            Timer1.Enabled = False
            lbldirectorio.Visible = True
            lbldirectorio.Text = "Copia Guardada en: " & txtRuta.Text & "\" & "BASEADA.bak"

            Panel2.Visible = True
            txtRuta.BackColor = Color.White
            editar_copia_de_seguridad()
            MOSTRAR_cajas_por_serial()
            Label4.Text = "COPIA DE SEGURIDAD GENERADA"
            Button2.Visible = False
            End
            Try
                lblfecha.Text = datalistado_cajas.SelectedCells.Item(9).Value
            Catch ex As Exception

            End Try

        End If
    End Sub
    Sub editar_copia_de_seguridad()

        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("editar_copia_de_seguridad", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Id_caja", idcaja)

            cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_de_seguridad", txtfechaSistema.Value)
            cmd.Parameters.AddWithValue("@Carpeta_para_copias_de_seguridad", txtRuta.Text)
            cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_date", txtfechaSistema.Value)
            cmd.ExecuteNonQuery()
            Cerrar()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, Label4.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then

            txtRuta.Text = FolderBrowserDialog1.SelectedPath


        End If
    End Sub

    Private Sub txtRuta_Click(sender As Object, e As EventArgs) Handles txtRuta.Click
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

    Private Sub txtRuta_TextChanged(sender As Object, e As EventArgs) Handles txtRuta.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Timer2.Enabled = False
        End

    End Sub

   
    
    Sub GENERAR_COPIA_DE_SEGURIDAD()
        If txtRuta.Text <> "" Then
            Hilo = New Thread(New ThreadStart(AddressOf executa))
            txtRuta.BackColor = Color.White
            'Iniciar el proceso
            PictureBox1.Visible = True
            Panel1.Enabled = False
            lbldirectorio.Visible = False
            Panel2.Visible = False
            Try
                Hilo.Start()
                acaba = False
                Timer1.Enabled = True
            Catch ex As Exception
                Dim result As DialogResult
                result = MessageBox.Show("Selecciona una Ruta Diferente al Disco C", "Seleccione Ruta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If result = DialogResult.OK Then
                    PictureBox1.Visible = False
                    Panel1.Enabled = True
                    Timer1.Enabled = False
                    lbldirectorio.Visible = False
                    Panel2.Visible = True
                    txtRuta.BackColor = Color.White
                End If
            End Try

        Else
            MessageBox.Show("Selecciona una Ruta donde Guardar las Copias de Seguridad", "Seleccione Ruta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRuta.Focus()
            txtRuta.BackColor = Color.FromArgb(255, 255, 192)
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        
        If LBLTIEMPO.Text > 0 Then
            LBLTIEMPO.Text = LBLTIEMPO.Text - 1

        Else
            Timer2.Enabled = False
            Label4.Text = "GENERANDO COPIA DE SEGURIDAD"
            LBLTIEMPO.Visible = False
            GENERAR_COPIA_DE_SEGURIDAD()
        End If
    End Sub

    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer2.Enabled = False
        End
    End Sub
End Class