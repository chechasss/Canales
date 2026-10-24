Imports System.Web.Http
Imports System.Threading
Public Class EmpresasController
    Inherits ApiController
    <Route("empresas")>
    <HttpGet>
    Public Function ObtenerEmpresas(canal As String) As IHttpActionResult
        Dim apiKey As String = ""
        If Request.Headers.Contains("X-Api-Key") Then
            apiKey = Request.Headers.GetValues("X-Api-Key").FirstOrDefault()
        End If

        If apiKey <> canal.Substring(0, 2) + "123" Then
            Return Unauthorized()
        End If

        Dim empresas =
        New List(Of Empresa) From {New Empresa With {
                .Id = 1,
                .Nombre = "RYOBI",
                .LogoUrl = "/imagenes/ryobi.png"
            }, New Empresa With {
                .Id = 2,
                .Nombre = "KleinTools",
                .LogoUrl = "/imagenes/klein.png"
            }, New Empresa With {
                .Id = 3,
                .Nombre = "Milwawkee",
                .LogoUrl = "/imagenes/milwawkee.png"
            }, New Empresa With {
                .Id = 3,
                .Nombre = "DeWalt",
                .LogoUrl = "/imagenes/dewalt.png"
            }
        }

        If canal = "ERROR" Then
            Return InternalServerError()
        End If
        If canal = "LENTO" Then
            Thread.Sleep(15000)
        End If

        Select Case canal
            Case "AB"
                empresas = New List(Of Empresa) From {New Empresa With {
                    .Id = 1,
                    .Nombre = "RYOBI",
                    .LogoUrl = "/imagenes/ryobi.png"
                }, New Empresa With {
                    .Id = 2,
                    .Nombre = "KleinTools",
                    .LogoUrl = "/imagenes/klein.png"
                }
            }
            Case "CJ"

                empresas =
                    New List(Of Empresa) From {New Empresa With {
                    .Id = 3,
                    .Nombre = "Milwawkee",
                    .LogoUrl = "/imagenes/milwawkee.png"
                }, New Empresa With {
                    .Id = 4,
                    .Nombre = "DeWalt",
                    .LogoUrl = "/imagenes/dewalt.png"
                }
            }
            Case Else
                Return NotFound()

        End Select

        Return Ok(empresas)
    End Function
End Class