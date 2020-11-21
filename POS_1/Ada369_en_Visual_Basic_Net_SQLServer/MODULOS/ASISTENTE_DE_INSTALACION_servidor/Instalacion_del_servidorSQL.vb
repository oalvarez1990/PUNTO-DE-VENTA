Imports System.IO
Imports System.Threading
Imports System.Management
Imports System.Data.SqlClient
Imports System.Xml
Public Class Instalacion_del_servidorSQL
    Private Hilo As Thread
    Dim acaba As Boolean = False
    Dim nombre_del_equipo_usuario As String
    Dim nombre_usuario_pc As String
    Dim ruta As String
    Private aes As New AES()
    Dim indicador As String
    Private Sub Instalacion_del_servidorSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelGeneral.Location = New Point((Width - PanelGeneral.Width) / 2, (Height - PanelGeneral.Height) / 2)
        PanelDios.Size = New Point(1, 1)

        PanelInstalando_servidor.Visible = False
        PanelInstalando_servidor.Dock = DockStyle.None

        nombre_del_equipo_usuario = Security.Principal.WindowsIdentity.GetCurrent().Name

        txtservidor.Text = "."

        txtEliminarBase.Text = txtEliminarBase.Text.Replace("BASEADA", TXTbasededatos.Text)
        txtCrear_procedimientos.Text = txtCrear_procedimientos.Text.Replace("BASEADA", TXTbasededatos.Text)
        txtCrearUsaurioDb.Text = txtCrearUsaurioDb.Text.Replace("ada369", txtusuario.Text)
        txtCrearUsaurioDb.Text = txtCrearUsaurioDb.Text.Replace("softwarereal", lblcontraseña.Text)
        txtCrearUsaurioDb.Text = txtCrearUsaurioDb.Text.Replace("BASEADA", TXTbasededatos.Text)

        txtCrear_procedimientos.Text = txtCrear_procedimientos.Text + vbCr + txtCrearUsaurioDb.Text
        Me.Cursor = Cursors.WaitCursor

        comprobar_si_ya_hay_servidor_instalado()
        If Button2.Visible = True Then
            txtservidor.Text = ".\" & lblnombredeservicio.Text
            comprobar_si_ya_hay_servidor_instalado()
        End If


    End Sub
    Sub comprobar_si_ya_hay_servidor_instalado()
        iniciar_sqlBrowser()
        ejecutar_scryt_ELIMINARBase_comprobacion_de_inicio()
        ejecutar_scryt_crearBase_comprobacion_De_inicio()
    End Sub
    Sub ejecutar_scryt_ELIMINARBase()
        Dim str As String
        Dim myConn As SqlConnection = New SqlConnection("Data Source=" & txtservidor.Text & ";Initial Catalog=master;Integrated Security=True")
        str = txtEliminarBase.Text
        Dim myCommand As SqlCommand = New SqlCommand(str, myConn)
        Try
            myConn.Open()
            myCommand.ExecuteNonQuery()
        Catch ex As Exception


        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
        End Try
    End Sub
    Sub ejecutar_scryt_ELIMINARBase_comprobacion_de_inicio()
        Dim str As String
        Dim myConn As SqlConnection = New SqlConnection("Data Source=" & txtservidor.Text & ";Initial Catalog=master;Integrated Security=True")
        str = txtEliminarBase.Text
        Dim myCommand As SqlCommand = New SqlCommand(str, myConn)
        Try
            myConn.Open()
            myCommand.ExecuteNonQuery()
            'indicador = "CORRECTO"
        Catch ex As Exception


        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
                'indicador = "INCORRECTO"
            End If
        End Try
    End Sub

    Sub ejecutar_scryt_crearBase()

        Dim cnn As New SqlConnection(
                       "Server=" & txtservidor.Text & "; " &
                       "database=master; integrated security=yes")

        Dim s As String = "CREATE DATABASE " & TXTbasededatos.Text
        Dim cmd As New SqlCommand(s, cnn)

        Try

            cnn.Open()
            cmd.ExecuteNonQuery()

            SavetoXML(aes.Encrypt("Data Source=" & txtservidor.Text & ";Initial Catalog=" & TXTbasededatos.Text & ";Integrated Security=True", appPwdUnique, Integer.Parse("256")))
            ejecutar_scryt_crearProcedimientos_almacenados_y_tablas()
            Timer4.Start()
        Catch ex As Exception
        Finally
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Try
    End Sub
    Sub ejecutar_scryt_crearBase_comprobacion_De_inicio()
        Dim cnn As New SqlConnection(
                       "Server=" & txtservidor.Text & "; " &
                       "database=master; integrated security=yes")

        Dim s As String = "CREATE DATABASE " & TXTbasededatos.Text
        Dim cmd As New SqlCommand(s, cnn)
        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
            SavetoXML(aes.Encrypt("Data Source=" & txtservidor.Text & ";Initial Catalog=" & TXTbasededatos.Text & ";Integrated Security=True", appPwdUnique, Integer.Parse("256")))
            ejecutar_scryt_crearProcedimientos_almacenados_y_tablas()
            PanelInstalando_servidor.Visible = True
            PanelInstalando_servidor.Dock = DockStyle.Fill
            LabelAnuncio_de_instalando_servidor.Text = "Instancia Encontrada...
            No Cierre esta Ventana, se cerrara Automaticamente cuando este todo Listo"
            Label3.Visible = False
            PanelTemporizador.Visible = False
            Timer4.Start()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Label3.Visible = True
            PanelTemporizador.Visible = True
            Button2.Visible = True
            PanelInstalando_servidor.Visible = False
            PanelInstalando_servidor.Dock = DockStyle.None
            lblbuscador_de_servidores.Text = "De click a Instalar Servidor, luego de click a SI cuando se le pida, luego presione ACEPTAR y espere por favor "
        Finally
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Try
    End Sub
    Public Sub SavetoXML(ByVal dbcnString)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("ConnectionString.xml")
            Dim root As XmlElement = doc.DocumentElement
            root.Attributes.Item(0).Value = dbcnString
            Dim writer As XmlTextWriter = New XmlTextWriter("ConnectionString.xml", Nothing)
            writer.Formatting = Formatting.Indented
            doc.Save(writer)
            writer.Close()
        Catch ex As Exception
            MessageBox.Show("Es la Primera vez que estas abriendo ADA 369 Debes Ejecutar el Aplicativo como Administrador, da anticlik izquierdo y Elije *Ejecutar como Administrador*", "Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End Try

    End Sub
    Public Sub SavetoXMLWeb(ByVal dbcnString)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("Conexion_web.xml")
            Dim root As XmlElement = doc.DocumentElement
            root.Attributes.Item(0).Value = dbcnString
            Dim writer As XmlTextWriter = New XmlTextWriter("Conexion_web.xml", Nothing)
            writer.Formatting = Formatting.Indented
            doc.Save(writer)
            writer.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub ejecutar_scryt_crearProcedimientos_almacenados_y_tablas()

        ruta = Path.Combine(Directory.GetCurrentDirectory(), txtnombre_scrypt.Text & ".txt")

        Dim fi As FileInfo = New FileInfo(ruta)
        Dim sw As StreamWriter

        Try
            If File.Exists(ruta) = False Then

                sw = File.CreateText(ruta)
                sw.WriteLine(txtCrear_procedimientos.Text)
                sw.Flush()
                sw.Close()
            ElseIf File.Exists(ruta) = True Then
                File.Delete(ruta)
                sw = File.CreateText(ruta)
                sw.WriteLine(txtCrear_procedimientos.Text)
                sw.Flush()
                sw.Close()
            End If
        Catch ex As Exception

        End Try

        Try
            Dim Pross As Process = New Process

            Pross.StartInfo.FileName = "sqlcmd"
            Pross.StartInfo.Arguments = " -S " & txtservidor.Text & " -i " & txtnombre_scrypt.Text & ".txt"
            Pross.Start()
            SavetoXML_servidor(aes.Encrypt(txtservidor.Text, appPwdUnique, Integer.Parse("256")))
            SavetoXML_Base_de_datos(aes.Encrypt(TXTbasededatos.Text, appPwdUnique, Integer.Parse("256")))
            SavetoXML_Software(aes.Encrypt(txtsoftware.Text, appPwdUnique, Integer.Parse("256")))
            SavetoXML_Contraseña_de_Base_de_datos(aes.Encrypt(lblcontraseña.Text, appPwdUnique, Integer.Parse("256")))
            SavetoXMLWeb(aes.Encrypt(lblconexionweb.Text, appPwdUnique, Integer.Parse("256")))
        Catch ex As Exception
        End Try


    End Sub
    Public Sub SavetoXML_servidor(ByVal dbcnString)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("Servidor.xml")
        Dim root As XmlElement = doc.DocumentElement
        root.Attributes.Item(0).Value = dbcnString
        Dim writer As XmlTextWriter = New XmlTextWriter("Servidor.xml", Nothing)
        writer.Formatting = Formatting.Indented
        doc.Save(writer)
        writer.Close()
    End Sub
    Public Sub SavetoXML_Software(ByVal dbcnString)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("Software.xml")
        Dim root As XmlElement = doc.DocumentElement
        root.Attributes.Item(0).Value = dbcnString
        Dim writer As XmlTextWriter = New XmlTextWriter("Software.xml", Nothing)
        writer.Formatting = Formatting.Indented
        doc.Save(writer)
        writer.Close()
    End Sub
    Public Sub SavetoXML_Base_de_datos(ByVal dbcnString)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("Base_de_datos.xml")
        Dim root As XmlElement = doc.DocumentElement
        root.Attributes.Item(0).Value = dbcnString
        Dim writer As XmlTextWriter = New XmlTextWriter("Base_de_datos.xml", Nothing)
        writer.Formatting = Formatting.Indented
        doc.Save(writer)
        writer.Close()
    End Sub

    Public Sub SavetoXML_Contraseña_de_Base_de_datos(ByVal dbcnString)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("Passwor_Base_de_datos.xml")
        Dim root As XmlElement = doc.DocumentElement
        root.Attributes.Item(0).Value = dbcnString
        Dim writer As XmlTextWriter = New XmlTextWriter("Passwor_Base_de_datos.xml", Nothing)
        writer.Formatting = Formatting.Indented
        doc.Save(writer)
        writer.Close()
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dispose()
        Eleccion_Servidor_o_remoto.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            txtArgumentosini.Text = txtArgumentosini.Text.Replace("PRUEBAFINAL22", lblnombredeservicio.Text)
            TimerCRARINI.Start()
            executa()
            Timer2.Start()
            PanelInstalando_servidor.Visible = True
            PanelInstalando_servidor.Dock = DockStyle.Fill
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub executa()
        Try
            Dim Pross As Process = New Process
            Pross.StartInfo.FileName = "SQLEXPR_x86_ENU.exe"
            Pross.StartInfo.Arguments = "/ConfigurationFile=ConfigurationFile.ini /ACTION=Install /IACCEPTSQLSERVERLICENSETERMS /SECURITYMODE=SQL /SAPWD=" & lblcontraseña.Text & " /SQLSYSADMINACCOUNTS=" & nombre_del_equipo_usuario

            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            Pross.Start()

        Catch ex As Exception

        End Try

    End Sub


    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles lblbuscador_de_servidores.Click

    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        milise.Text += 1
        If milise.Text = "60" Then
            seg.Text += 1
            milise.Text = "00"

        End If

        If seg.Text = "60" Then
            min.Text += 1
            seg.Text = "00"
        End If

        If min.Text = 6 Then
            Timer2.Enabled = False
            iniciar_sqlBrowser()
            ejecutar_scryt_ELIMINARBase()
            ejecutar_scryt_crearBase()
            'MsgBox("primera ejecucion")
            Timer3.Start()
        End If
    End Sub


    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        mils2.Text += 1
        If mils2.Text = "60" Then
            seg2.Text += 1
            mils2.Text = "00"

        End If

        If seg2.Text = "60" Then
            min2.Text += 1
            seg2.Text = "00"

        End If

        If min2.Text = 1 Then
            min2.Text = "00"
            seg2.Text = "00"


            ejecutar_scryt_ELIMINARBase()
            ejecutar_scryt_crearBase()

        End If
    End Sub
    Sub iniciar_sqlBrowser()
        'Try
        '    Dim Pross As Process = New Process
        '    Pross.StartInfo.FileName = "net start sqlbrowser"

        '    Pross.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        '    Pross.Start()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        ''''''Try
        ''''''    Dim cmd As ProcessStartInfo
        ''''''    cmd = New ProcessStartInfo("net start sqlbrowser")
        ''''''    cmd.UseShellExecute = False
        ''''''    cmd.CreateNoWindow = True
        ''''''    cmd.RedirectStandardOutput = True
        ''''''    Dim proc As New Process()
        ''''''    proc.StartInfo = cmd
        ''''''    proc.Start()

        ''''''Catch ex As Exception
        ''''''    MessageBox.Show(ex.Message)
        ''''''End Try

    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick

        Timer2.Stop()
        Timer3.Stop()
        mil3.Text += 1
        If mil3.Text = "60" Then
            seg3.Text += 1
            mil3.Text = "00"

        End If

        If seg3.Text = "15" Then
            Timer4.Stop()
            Try
                File.Delete(ruta)

            Catch ex As Exception

            End Try

            Dispose()
            End
        End If

    End Sub



    Public Sub SavetoXML_indicador_de_instalacion(ByVal dbcnString)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("Indicador_de_instanciador.xml")
        Dim root As XmlElement = doc.DocumentElement
        root.Attributes.Item(0).Value = dbcnString
        Dim writer As XmlTextWriter = New XmlTextWriter("Indicador_de_instanciador.xml", Nothing)
        writer.Formatting = Formatting.Indented
        doc.Save(writer)
        writer.Close()
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub TimerCRARINI_Tick(sender As Object, e As EventArgs) Handles TimerCRARINI.Tick

        Dim rutaPREPARAR As String
        Dim sw As StreamWriter
        rutaPREPARAR = Path.Combine(Directory.GetCurrentDirectory(), "ConfigurationFile.ini")
        rutaPREPARAR = rutaPREPARAR.Replace("ConfigurationFile.ini", "SQLEXPR_x86_ENU\ConfigurationFile.ini")

        'If File.Exists(rutaPREPARAR) = False Then
        If File.Exists(rutaPREPARAR) = True Then
            TimerCRARINI.Stop()
        End If

        Try
                sw = File.CreateText(rutaPREPARAR)
                sw.WriteLine(txtArgumentosini.Text)
                sw.Flush()
            sw.Close()
            TimerCRARINI.Stop()
        Catch ex As Exception

            End Try







    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        iniciar_sqlBrowser()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        PanelDios.Size = New Point(891, 639)
        PanelDios.Dock = DockStyle.Fill
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PanelDios.Dock = DockStyle.None
        PanelDios.Size = New Point(1, 1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PanelDios.Dock = DockStyle.None
        PanelDios.Size = New Point(1, 1)
        comprobar_si_ya_hay_servidor_instalado()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PanelDios.Dock = DockStyle.None
        PanelDios.Size = New Point(1, 1)
        Try
            txtArgumentosini.Text = txtArgumentosini.Text.Replace("PRUEBAFINAL22", lblnombredeservicio.Text)
            TimerCRARINI.Start()
            executa()
            Timer2.Start()
            PanelInstalando_servidor.Visible = True
            PanelInstalando_servidor.Dock = DockStyle.Fill
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class