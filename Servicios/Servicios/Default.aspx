<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Servicios._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>
        <asp:Repeater ID="rptMenu" runat="server">
            <ItemTemplate>
                <div class="row">
                    <section class="col-md-4">
                        <h2>  Canal <%# Eval("Canal") %> </h2>
                        <p> <%# Eval("Descripcion") %> </p>
                        <p>
                            <a class="btn btn-default" href='Empresas.aspx?<%# Eval("PaginaDestino") %>'>
                                Consultar
                            </a>
                        </p>
                    </section>
            </div>
        </ItemTemplate>
        </asp:Repeater>

    </main>

</asp:Content>
