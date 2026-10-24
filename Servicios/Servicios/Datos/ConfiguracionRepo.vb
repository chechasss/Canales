Imports System.Data.SqlClient
Imports System.Configuration
Public Class ConfiguracionRepo
    Public Function ObtenerCanal(canal As String) As Canal
        Dim conexion = ConfigurationManager.ConnectionStrings("dbConString").ConnectionString
        Using con As New SqlConnection(conexion)
            Using command As New SqlCommand("sp_getConfigCanal", con)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@Canal", canal)
                con.Open()
                Using reader = command.ExecuteReader()
                    If reader.Read() Then
                        Return New Canal With {
                            .Canal = reader("Canal").ToString(),
                            .UrlServicio = reader("UrlServicio").ToString(),
                            .ApiKey = reader("ApiKey").ToString(),
                            .MostrarMenu = CBool(reader("MostrarMenu")),
                            .PaginaDestino = reader("PaginaDestino").ToString(),
                            .TimeoutSegs = CInt(reader("TimeoutSegundos"))
                        }
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function

    Public Function ObtenerCanalesMenu() As List(Of Canal)

        Dim lista As New List(Of Canal)
        Dim conexion = ConfigurationManager.ConnectionStrings("dbConString").ConnectionString
        Using con As New SqlConnection(conexion)
            Using command As New SqlCommand("sp_getMenuCanal", con)
                command.CommandType = CommandType.StoredProcedure
                con.Open()

                Using dr = command.ExecuteReader()

                    While dr.Read()

                        lista.Add(
                            New Canal With {
                                .Canal = dr("Canal").ToString(),
                                .MostrarMenu = CBool(dr("MostrarMenu")),
                                .PaginaDestino = dr("PaginaDestino").ToString(),
                                .Descripcion = dr("Descripcion").ToString()
                            })
                    End While
                End Using
            End Using
        End Using
        Return lista
    End Function
End Class