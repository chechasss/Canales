Imports System.IO

Public Class Logger

    Public Shared Sub Log(mensaje As String)

        Dim ruta = HttpContext.Current.Server.MapPath("~/Logs/log.txt")
        File.AppendAllText(ruta, DateTime.Now.ToString() & " - " & mensaje & Environment.NewLine)

    End Sub

End Class