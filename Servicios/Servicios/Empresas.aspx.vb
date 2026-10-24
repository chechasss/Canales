Imports System.Threading.Tasks
Public Class Empresas
    Inherits System.Web.UI.Page

    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Await CargarEmpresas()
        End If
    End Sub

    Private Async Function CargarEmpresas() As Task
        Try
            Dim canal = Request.QueryString("canal")

            Dim repo As New ConfiguracionRepo()
            Dim config = repo.ObtenerCanal(canal)

            If config Is Nothing Then
                lblMensaje.Text = "Canal no encontrado"
                Return

            End If

            pnlMenu.Visible = config.MostrarMenu

            Session("PaginaDestino") = config.PaginaDestino

            Dim service As New EmpresaService()

            Dim empresas = Await service.ObtenerEmpresasAsync(config)

            rptEmpresas.DataSource = empresas

            rptEmpresas.DataBind()

        Catch ex As Exception

            Logger.Log(ex.ToString())

            lblMensaje.Text = "Error obteniendo empresas : " + ex.Message

        End Try

    End Function

    Protected Sub SeleccionarEmpresa(sender As Object, e As CommandEventArgs)

        Session("Empresa") = e.CommandArgument.ToString()
        Dim pagina = Session("PaginaDestino").ToString()
        Response.Redirect(pagina)

    End Sub
End Class