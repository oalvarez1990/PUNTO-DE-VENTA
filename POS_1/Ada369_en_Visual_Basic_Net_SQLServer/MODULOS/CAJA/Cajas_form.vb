Imports System.Data.SqlClient
Public Class Cajas_form
    Inherits System.Windows.Forms.Form
    Private mMenu As New System.Windows.Forms.MainMenu()
    Private Sub Cajas_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''''''Me.Menu = mMenu
        ''''''Dim Menustrip As New MenuStrip
        ''''''Menustrip.BackColor = Color.FromArgb(20, 20, 20)
        ''''''Menustrip.AutoSize = False
        ''''''Menustrip.Size = New System.Drawing.Size(40, 24)
        ''''''Menustrip.Dock = DockStyle.Right

        ''''''Dim ToolStripPRINCIPAL As New ToolStripMenuItem
        ''''''Dim ToolStripEDITAR As New ToolStripMenuItem

        ''''''ToolStripPRINCIPAL.Image = My.Resources.menu_BLACK
        ''''''ToolStripPRINCIPAL.BackColor = Color.FromArgb(20, 20, 20)
        ''''''ToolStripEDITAR.Text = "Editar"
        ''''''Menustrip.Items.Add(ToolStripPRINCIPAL)
        ''''''ToolStripPRINCIPAL.DropDownItems.Add(ToolStripEDITAR)
        ''''''mMenu.MenuItems.Add("mnuFichero")
        ''''''Panel2.Controls.Add(Menustrip)
        'With mMenu.MenuItems.Add("mnuFichero")
        '    .Text = "&Fichero"
        '    With .MenuItems.Add("mnuHola", New EventHandler(AddressOf mnuHola_Click))
        '        .Text = "Saludar"
        '    End With
        '    ' Un separador
        '    With .MenuItems.Add("mnuSep")
        '        .Text = "-"
        '    End With
        '    ' Para salir, usamos el mismo evento que el del botón salir
        '    With .MenuItems.Add("mnuSalir", New EventHandler(AddressOf mnuHola_Click))
        '        .Text = "Salir"
        '    End With
        'End With

        dibujarCAJAS_REMOTAS()
        dibujarCAJA_PRINCIPAL()
        Panel9.Location = New Point((Width - Panel9.Width) / 2, (Height - Panel9.Height) / 2)

    End Sub
    Private Sub mnuHola_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case CType(sender, MenuItem).Text
            Case "Saludar"
                MessageBox.Show("Hola")
            Case "Salir"
                Me.Close()
        End Select
    End Sub

    Sub dibujarCAJA_PRINCIPAL()
        Panel8.Controls.Clear()
        abrir()
        Dim query As String = "Mostrar_caja_principal"
        Dim cmd As New SqlCommand(query, conexion)
        Dim rdr As SqlDataReader = cmd.ExecuteReader()


        While rdr.Read()
            Dim p1 As New Panel
            Dim P2 As New Panel
            Dim I1 As New PictureBox
            Dim I2 As New PictureBox
            Dim L As New Label
            Dim L2 As New Label
            Dim L3 As New Label
            Dim P3 As New Panel
            Dim LABELUsuario As New Label

            Dim PbarraArriba As New Panel
            Dim PbarraCostado As New Panel

            'Dim Menustrip As New MenuStrip
            'Dim toolMenustrip As New ToolStripMenuItem


            L.Text = rdr("Descripcion").ToString()
            L.Name = rdr("Id_Caja").ToString()
            L.Size = New System.Drawing.Size(430, 18)
            L.Font = New System.Drawing.Font("Microsoft Sans Serif", 20)
            L.BackColor = Color.FromArgb(20, 20, 20)
            'L.FlatStyle = FlatStyle.Flat
            L.AutoSize = False
            L.BackColor = Color.FromArgb(20, 20, 20)
            L.ForeColor = Color.White
            L.Dock = DockStyle.Fill
            L.TextAlign = ContentAlignment.MiddleCenter

            'L.Cursor = Cursors.Hand

            LABELUsuario.Text = "Por " & rdr("Nombre_y_Apelllidos").ToString()

            LABELUsuario.Dock = DockStyle.Bottom
            LABELUsuario.AutoSize = False
            LABELUsuario.TextAlign = ContentAlignment.MiddleCenter
            LABELUsuario.BackColor = Color.FromArgb(20, 20, 20)
            LABELUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10)
            LABELUsuario.ForeColor = Color.FromArgb(80, 80, 80)
            LABELUsuario.Size = New System.Drawing.Size(430, 31)


            p1.Size = New System.Drawing.Size(208, 143)
            p1.BorderStyle = BorderStyle.None
            p1.Dock = DockStyle.Top
            p1.BackColor = Color.FromArgb(20, 20, 20)

            P2.Size = New System.Drawing.Size(208, 24)
            P2.Dock = DockStyle.Top
            P2.BackColor = Color.FromArgb(20, 20, 20)





            L2.Text = rdr("Estado").ToString()
            L2.Size = New System.Drawing.Size(430, 18)
            L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9)
            L2.BackColor = Color.FromArgb(20, 20, 20)
            'L.FlatStyle = FlatStyle.Flat
            L2.AutoSize = False
            L2.BackColor = Color.FromArgb(20, 20, 20)
            L2.ForeColor = Color.Gray
            L2.Dock = DockStyle.Fill
            L2.TextAlign = ContentAlignment.MiddleCenter


            Dim Menustrip As New MenuStrip
            Menustrip.BackColor = Color.FromArgb(20, 20, 20)
            Menustrip.AutoSize = False
            Menustrip.Size = New System.Drawing.Size(28, 24)
            Menustrip.Dock = DockStyle.Right
            Menustrip.Name = rdr("Id_Caja").ToString()
            Dim ToolStripPRINCIPAL As New ToolStripMenuItem
            Dim ToolStripEDITAR As New ToolStripMenuItem


            ToolStripPRINCIPAL.Image = My.Resources.menuCajas_claro
            ToolStripPRINCIPAL.BackColor = Color.FromArgb(20, 20, 20)
            ToolStripEDITAR.Text = "Editar"
            ToolStripEDITAR.Name = rdr("Descripcion").ToString()
            ToolStripEDITAR.Tag = rdr("Id_Caja").ToString()


            Menustrip.Items.Add(ToolStripPRINCIPAL)
            ToolStripPRINCIPAL.DropDownItems.Add(ToolStripEDITAR)

            If L2.Text = "RECIEN CREADA" Then

                I1.BackgroundImage = My.Resources.Caja_recien_creada
            ElseIf L2.Text = "Caja Restaurada"
                I1.BackgroundImage = My.Resources.Caja_recien_creada
            ElseIf L2.Text = "Caja Aperturada"
                I1.BackgroundImage = My.Resources.Caja_activa

            ElseIf L2.Text = "Caja Cerrada"
                I1.BackgroundImage = My.Resources.caja_eliminada
            ElseIf L2.Text = "Caja Eliminada"

                I1.BackgroundImage = My.Resources.Caja_eliminada_oficial
                L.ForeColor = Color.DimGray
            End If




            I1.BackgroundImageLayout = ImageLayout.Zoom
            I1.Size = New System.Drawing.Size(22, 24)
            I1.Dock = DockStyle.Fill
            I1.BackColor = Color.FromArgb(20, 20, 20)

            P3.Size = New System.Drawing.Size(30, 24)
            P3.Dock = DockStyle.Left
            P3.BackColor = Color.FromArgb(200, 200, 200)

            PbarraArriba.Size = New System.Drawing.Size(22, 5)
            PbarraArriba.Dock = DockStyle.Top
            PbarraArriba.BackColor = Color.FromArgb(20, 20, 20)

            PbarraCostado.Size = New System.Drawing.Size(2, 22)
            PbarraCostado.Dock = DockStyle.Left
            PbarraCostado.BackColor = Color.FromArgb(20, 20, 20)


            L3.Text = rdr("Tipo").ToString()
            L3.Size = New System.Drawing.Size(430, 18)
            L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8)
            L3.BackColor = Color.FromArgb(20, 20, 20)
            'L.FlatStyle = FlatStyle.Flat
            L3.AutoSize = False
            L3.BackColor = Color.FromArgb(20, 20, 20)
            L3.ForeColor = Color.DimGray
            L3.Dock = DockStyle.Bottom
            L3.TextAlign = ContentAlignment.MiddleCenter











            P3.Controls.Add(PbarraArriba)
            P3.Controls.Add(PbarraCostado)
            P3.Controls.Add(I1)
            p1.Controls.Add(P2)
            'p1.Controls.Add(I1)
            p1.Controls.Add(L)

            P2.Controls.Add(P3)
            p1.Controls.Add(Menustrip)
            P2.Controls.Add(L2)
            p1.Controls.Add(LABELUsuario)

            'p1.Controls.Add(L3)
            Panel8.Controls.Add(p1)
            'L.BringToFront()
            LABELUsuario.BringToFront()
            I1.BringToFront()

            'Menustrip.Dock = DockStyle.Right
            'Menustrip.ContextMenu = ContextMenuStrip.Controls.Add(toolMenustrip)


            'I1.SendToBack()
            'L.BringToFront()
            'PanelCONTENEDORDENOTIFICACIONES.Controls.Add(p1)
            AddHandler ToolStripEDITAR.Click, AddressOf miEventoToolStripEDITAR


            'AddHandler L.Click, AddressOf miEventoCOBROS
            'AddHandler I1.Click, AddressOf miEventoCOBROS
            'AddHandler I2.Click, AddressOf miEventoCOBROS
        End While
        Cerrar()
    End Sub
    Sub dibujarCAJAS_REMOTAS()
        FlowLayoutPanel2.Controls.Clear()

        abrir()
        Dim query As String = "Mostrar_caja_remota"
        Dim cmd As New SqlCommand(query, conexion)
        Dim rdr As SqlDataReader = cmd.ExecuteReader()


        While rdr.Read()
            Dim LABELUsuario As New Label
            Dim p1 As New Panel
            Dim P2 As New Panel
            Dim I1 As New PictureBox
            Dim I2 As New PictureBox
            Dim L As New Label
            Dim L2 As New Label
            Dim L3 As New Label
            Dim P3 As New Panel

            Dim PbarraArriba As New Panel
            Dim PbarraCostado As New Panel

            'Dim Menustrip As New MenuStrip
            'Dim toolMenustrip As New ToolStripMenuItem


            L.Text = rdr("Descripcion").ToString()
            L.Name = rdr("Id_Caja").ToString()
            L.Size = New System.Drawing.Size(430, 18)
            L.Font = New System.Drawing.Font("Microsoft Sans Serif", 20)
            L.BackColor = Color.FromArgb(20, 20, 20)
            'L.FlatStyle = FlatStyle.Flat
            L.AutoSize = False
            L.BackColor = Color.FromArgb(20, 20, 20)
            L.ForeColor = Color.White
            L.Dock = DockStyle.Fill
            L.TextAlign = ContentAlignment.MiddleCenter

            'L.Cursor = Cursors.Hand
            LABELUsuario.Text = "Por " & rdr("Nombre_y_Apelllidos").ToString()

            LABELUsuario.Dock = DockStyle.Bottom
            LABELUsuario.AutoSize = False
            LABELUsuario.TextAlign = ContentAlignment.MiddleCenter
            LABELUsuario.BackColor = Color.FromArgb(20, 20, 20)
            LABELUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10)
            LABELUsuario.ForeColor = Color.FromArgb(80, 80, 80)
            LABELUsuario.Size = New System.Drawing.Size(430, 31)


            p1.Size = New System.Drawing.Size(208, 143)
            p1.BorderStyle = BorderStyle.None
            p1.Dock = DockStyle.Top
            p1.BackColor = Color.FromArgb(20, 20, 20)

            P2.Size = New System.Drawing.Size(208, 24)
            P2.Dock = DockStyle.Top
            P2.BackColor = Color.FromArgb(20, 20, 20)




            L2.Text = rdr("Estado").ToString()
            L2.Size = New System.Drawing.Size(430, 18)
            L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9)
            L2.BackColor = Color.FromArgb(20, 20, 20)
            'L.FlatStyle = FlatStyle.Flat
            L2.AutoSize = False
            L2.BackColor = Color.FromArgb(20, 20, 20)
            L2.ForeColor = Color.Gray
            L2.Dock = DockStyle.Fill
            L2.TextAlign = ContentAlignment.MiddleCenter


            Dim Menustrip As New MenuStrip
            Menustrip.BackColor = Color.FromArgb(20, 20, 20)
            Menustrip.AutoSize = False
            Menustrip.Size = New System.Drawing.Size(28, 24)
            Menustrip.Dock = DockStyle.Right
            Menustrip.Name = rdr("Id_Caja").ToString()
            Dim ToolStripPRINCIPAL As New ToolStripMenuItem
            Dim ToolStripEDITAR As New ToolStripMenuItem
            Dim ToolStripELIMINAR As New ToolStripMenuItem

            Dim ToolStripRESTAURAR As New ToolStripMenuItem

            ToolStripPRINCIPAL.Image = My.Resources.menuCajas_claro
            ToolStripPRINCIPAL.BackColor = Color.FromArgb(20, 20, 20)
            ToolStripEDITAR.Text = "Editar"
            ToolStripEDITAR.Name = rdr("Descripcion").ToString()
            ToolStripEDITAR.Tag = rdr("Id_Caja").ToString()

            ToolStripELIMINAR.Text = "Eliminar"
            ToolStripELIMINAR.Tag = rdr("Id_Caja").ToString()

            ToolStripRESTAURAR.Text = "Restaurar"
            ToolStripRESTAURAR.Tag = rdr("Id_Caja").ToString()


            Menustrip.Items.Add(ToolStripPRINCIPAL)


            If L2.Text = "RECIEN CREADA" Then

                I1.BackgroundImage = My.Resources.Caja_recien_creada
            ElseIf L2.Text = "Caja Restaurada"
                I1.BackgroundImage = My.Resources.Caja_recien_creada
            ElseIf L2.Text = "Caja Aperturada"
                I1.BackgroundImage = My.Resources.Caja_activa

            ElseIf L2.Text = "Caja Cerrada"
                I1.BackgroundImage = My.Resources.caja_eliminada
            ElseIf L2.Text = "Caja Eliminada"

                I1.BackgroundImage = My.Resources.Caja_eliminada_oficial
                L.ForeColor = Color.DimGray
            End If

            If L2.Text <> "Caja Eliminada" Then
                ToolStripPRINCIPAL.DropDownItems.Add(ToolStripEDITAR)
                ToolStripPRINCIPAL.DropDownItems.Add(ToolStripELIMINAR)

            Else
                ToolStripPRINCIPAL.DropDownItems.Add(ToolStripRESTAURAR)
            End If



            I1.BackgroundImageLayout = ImageLayout.Zoom
            I1.Size = New System.Drawing.Size(22, 24)
            I1.Dock = DockStyle.Fill
            I1.BackColor = Color.FromArgb(20, 20, 20)

            P3.Size = New System.Drawing.Size(30, 24)
            P3.Dock = DockStyle.Left
            P3.BackColor = Color.FromArgb(200, 200, 200)

            PbarraArriba.Size = New System.Drawing.Size(22, 5)
            PbarraArriba.Dock = DockStyle.Top
            PbarraArriba.BackColor = Color.FromArgb(20, 20, 20)

            PbarraCostado.Size = New System.Drawing.Size(2, 22)
            PbarraCostado.Dock = DockStyle.Left
            PbarraCostado.BackColor = Color.FromArgb(20, 20, 20)


            L3.Text = rdr("Tipo").ToString()
            L3.Size = New System.Drawing.Size(430, 18)
            L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8)
            L3.BackColor = Color.FromArgb(20, 20, 20)
            'L.FlatStyle = FlatStyle.Flat
            L3.AutoSize = False
            L3.BackColor = Color.FromArgb(20, 20, 20)
            L3.ForeColor = Color.DimGray
            L3.Dock = DockStyle.Bottom
            L3.TextAlign = ContentAlignment.MiddleCenter











            P3.Controls.Add(PbarraArriba)
            P3.Controls.Add(PbarraCostado)
            P3.Controls.Add(I1)
            p1.Controls.Add(P2)
            'p1.Controls.Add(I1)
            p1.Controls.Add(L)

            P2.Controls.Add(P3)
            p1.Controls.Add(Menustrip)
            P2.Controls.Add(L2)
            p1.Controls.Add(LABELUsuario)

            'p1.Controls.Add(L3)
            FlowLayoutPanel2.Controls.Add(p1)
            L.BringToFront()
            LABELUsuario.BringToFront()

            I1.BringToFront()

            'Menustrip.Dock = DockStyle.Right
            'Menustrip.ContextMenu = ContextMenuStrip.Controls.Add(toolMenustrip)


            'I1.SendToBack()
            'L.BringToFront()
            'PanelCONTENEDORDENOTIFICACIONES.Controls.Add(p1)
            AddHandler ToolStripEDITAR.Click, AddressOf miEventoToolStripEDITAR
            AddHandler ToolStripELIMINAR.Click, AddressOf miEventoToolStripELIMINAR
            AddHandler ToolStripRESTAURAR.Click, AddressOf miEventoToolStripRESTAURAR

            'AddHandler L.Click, AddressOf miEventoCOBROS
            'AddHandler I1.Click, AddressOf miEventoCOBROS
            'AddHandler I2.Click, AddressOf miEventoCOBROS
        End While
        Cerrar()
    End Sub
    Dim idcaja As Integer
    Private Sub miEventoToolStripEDITAR(ByVal sender As System.Object, ByVal e As EventArgs)
        idcaja = DirectCast(sender, ToolStripMenuItem).Tag
        txtcaja.Text = DirectCast(sender, ToolStripMenuItem).Name
        Panel10.Visible = True
        Panel10.Dock = DockStyle.Fill

        panelConfigurarCaja.Location = New Point((Panel10.Width - panelConfigurarCaja.Width) / 2, (Panel10.Height - panelConfigurarCaja.Height) / 2)

        txtcaja.SelectAll()
        txtcaja.Focus()

    End Sub

    Private Sub miEventoToolStripELIMINAR(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim result As DialogResult
        Dim cmd As SqlCommand
        result = MessageBox.Show("¿Realmente desea eliminar esta caja?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            idcaja = DirectCast(sender, ToolStripMenuItem).Tag
            eliminar_caja()

        End If


    End Sub
    Private Sub miEventoToolStripRESTAURAR(ByVal sender As System.Object, ByVal e As EventArgs)

        idcaja = DirectCast(sender, ToolStripMenuItem).Tag
        restaurar_caja()




    End Sub
    Sub eliminar_caja()
        Dim cmd As New SqlCommand

        Try

            abrir()
            cmd = New SqlCommand("eliminar_caja", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idcaja", idcaja)
            cmd.ExecuteNonQuery()
            Cerrar()

            dibujarCAJAS_REMOTAS()
            dibujarCAJA_PRINCIPAL()
        Catch ex As Exception

        End Try

    End Sub
    Sub restaurar_caja()
        Dim cmd As New SqlCommand

        Try

            abrir()
            cmd = New SqlCommand("restaurar_caja", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idcaja", idcaja)
            cmd.ExecuteNonQuery()
            Cerrar()

            dibujarCAJAS_REMOTAS()
            dibujarCAJA_PRINCIPAL()
        Catch ex As Exception

        End Try

    End Sub
    Sub editar_nombre_caja()
        Dim cmd As New SqlCommand
        If txtcaja.Text <> "" Then
            Try

                abrir()
                cmd = New SqlCommand("editar_caja", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@descripcion", txtcaja.Text)
                cmd.Parameters.AddWithValue("@idcaja", idcaja)


                cmd.ExecuteNonQuery()
                Cerrar()
                Panel10.Visible = False
                Panel10.Dock = DockStyle.None
                dibujarCAJAS_REMOTAS()
                dibujarCAJA_PRINCIPAL()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Ingrese un nombre para la Caja", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        editar_nombre_caja()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Panel10.Visible = False
        Panel10.Dock = DockStyle.None
    End Sub

    Private Sub Cajas_form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
        PANEL_CONFIGURACIONES.ShowDialog()

    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs) Handles ToolStripButton22.Click
        Dispose()
        PANEL_CONFIGURACIONES.ShowDialog()

    End Sub
End Class