Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing

Public Class vForm
    Public WithEvents ventana As New Form

    ''------------------------------------------------------------------------
    Private Const WM_SYSCOMMAND As Integer = &H112&
    Private Const MOUSE_MOVE As Integer = &HF012&

    <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(
        ByVal hWnd As System.IntPtr, ByVal wMsg As Integer,
        ByVal wParam As Integer, ByVal lParam As Integer
        )
    End Sub

    <System.Runtime.InteropServices.DllImport("coredll.dll",
            EntryPoint:="SetForegroundWindow")>
    Private Shared Function SetForegroundWindow(
        ByVal hWnd As IntPtr) As Boolean
    End Function
    '
    <System.Runtime.InteropServices.DllImport("coredll.dll",
            EntryPoint:="FindWindow")>
    Private Shared Function FindWindow(
        ByVal lpClassName As String,
        ByVal lpWindowName As String) As IntPtr
    End Function

    Public Sub moverForm()
        ReleaseCapture()
        SendMessage(ventana.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0)
    End Sub

    Private Function RoundedRec(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer) As System.Drawing.Drawing2D.GraphicsPath

        Dim graphics_path As New System.Drawing.Drawing2D.GraphicsPath
        graphics_path.AddLine(X + 10, Y, X + Width, Y)

        Dim tr() As Point = {
        New Point(X + Width, Y),
        New Point((X + Width) + 4, Y + 2),
        New Point((X + Width) + 8, Y + 6),
        New Point((X + Width) + 10, Y + 10)}

        graphics_path.AddCurve(tr)

        Dim br() As Point = {
        New Point((X + Width) + 10, Y + Height),
        New Point((X + Width) + 8, (Y + Height) + 4),
        New Point((X + Width) + 4, (Y + Height) + 8),
        New Point(X + Width, (Y + Height) + 10)}

        graphics_path.AddCurve(br)

        Dim bl() As Point = {
        New Point(X + 10, (Y + Height) + 10),
        New Point(X + 6, (Y + Height) + 8),
        New Point(X + 2, (Y + Height) + 4),
        New Point(X, Y + Height)}

        graphics_path.AddCurve(bl)

        Dim tl() As Point = {
        New Point(X, Y + 10),
        New Point(X + 2, Y + 6),
        New Point(X + 6, Y + 2),
        New Point(X + 10, Y)}
        graphics_path.AddCurve(tl)
        Return graphics_path
    End Function

    <DllImport("dwmapi.dll", PreserveSig:=True)>
    Private Shared Function DwmSetWindowAttribute(hwnd As IntPtr, attr As Integer, ByRef attrValue As Integer, attrSize As Integer) As Integer
    End Function

    <DllImport("dwmapi.dll")>
    Private Shared Function DwmExtendFrameIntoClientArea(hWnd As IntPtr, ByRef pMarInset As Margins) As Integer
    End Function

    ''------------------------------------------------------------------------

    Sub redondear()
        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 10, 10), 180, 90)
        p.AddLine(10, 0, ventana.Width - 10, 0)
        p.AddArc(New Rectangle(ventana.Width - 10, 0, 10, 10), -90, 90)
        p.AddLine(ventana.Width, 10, ventana.Width, ventana.Height - 10)
        p.AddArc(New Rectangle(ventana.Width - 10, ventana.Height - 10, 10, 10), 0, 90)
        p.AddLine(ventana.Width - 10, ventana.Height, 10, ventana.Height)
        p.AddArc(New Rectangle(0, ventana.Height - 10, 10, 10), 90, 90)
        p.CloseFigure()
        ventana.Region = New Region(p)
    End Sub

    ''------------------------------------------------------------------------
End Class
