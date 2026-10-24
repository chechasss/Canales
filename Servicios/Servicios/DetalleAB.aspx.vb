Public Class DetalleAB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empresa") Is Nothing Then

            Response.Redirect("Empresas.aspx")
            Return

        End If
        lblEmpresa.Text = Session("Empresa").ToString()
    End Sub

End Class