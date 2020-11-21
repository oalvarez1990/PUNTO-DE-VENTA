Public Class ELECCION_DE_SALIDA_DE_KARDEX

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        KARDEX_REGISTRO.TXTTIPO.Text = "ENTRADA"
       

        KARDEX_REGISTRO.ShowDialog()
        KARDEX_REGISTRO.TXTTIPO.Text = "ENTRADA"


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        VENTAS_MENU_PRINCIPAL.ShowDialog()
        hide()
        mascara1.hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        
        Close()

    End Sub
End Class