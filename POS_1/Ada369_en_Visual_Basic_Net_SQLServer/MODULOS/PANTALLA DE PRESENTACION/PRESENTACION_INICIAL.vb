Public Class PRESENTACION_INICIAL
    Private Sub PRESENTACION_INICIAL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel5.Location = New Point((Width - Panel5.Width) / 2, (Height - Panel5.Height) / 2)
        Timer1.Start()
    End Sub
    Dim contador As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        contador += 1
        If contador = 400 Then
            Timer1.Stop()
            Dispose()
            LOGIN.ShowDialog()

        End If
    End Sub
End Class