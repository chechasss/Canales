Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarMenu()
        End If
    End Sub

    Private Sub CargarMenu()
        Dim repo As New ConfiguracionRepo()
        Dim canales = repo.ObtenerCanalesMenu()
        rptMenu.DataSource = canales
        rptMenu.DataBind()
    End Sub
End Class