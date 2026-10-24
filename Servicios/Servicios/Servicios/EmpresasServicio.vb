Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class EmpresaService

    Public Async Function ObtenerEmpresasAsync(configuracion As Canal) As Task(Of List(Of Empresa))

        Using cliente As New HttpClient()

            cliente.Timeout = TimeSpan.FromSeconds(configuracion.TimeoutSegs)
            cliente.DefaultRequestHeaders.Add("X-Api-Key", configuracion.ApiKey)
            Dim url = configuracion.UrlServicio & "?canal=" & configuracion.Canal
            Dim respuesta = Await cliente.GetAsync(url)
            If respuesta.IsSuccessStatusCode Then

                Dim contenido = Await respuesta.Content.ReadAsStringAsync()

                Return JsonConvert.DeserializeObject(Of List(Of Empresa))(contenido)

            End If

            Select Case respuesta.StatusCode

                Case HttpStatusCode.NotFound
                    Throw New Exception(
                        "No se encontraron empresas para el canal seleccionado.")
                Case HttpStatusCode.Unauthorized
                    Throw New Exception(
                        "API Key inválida.")
                Case HttpStatusCode.InternalServerError
                    Throw New Exception(
                        "El servicio devolvió un error interno.")
                Case Else

                    Throw New Exception(
                        "Error inesperado: " &
                        respuesta.StatusCode.ToString())

            End Select
        End Using

    End Function

End Class