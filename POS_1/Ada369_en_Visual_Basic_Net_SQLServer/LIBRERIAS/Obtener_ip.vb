Imports System.Net

Module Obtener_ip
    Public valorIp As String

    Public Function getIp() As String

        valorIp = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString()
        Return valorIp

    End Function
End Module
