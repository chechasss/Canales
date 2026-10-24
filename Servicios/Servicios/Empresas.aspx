<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Empresas.aspx.vb" Inherits="Servicios.Empresas" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
        <asp:Panel ID="pnlMenu" runat="server">
        </asp:Panel>
        <asp:Repeater ID="rptEmpresas" runat="server">
            <ItemTemplate><div>
            <h3>
                <%# Eval("Nombre") %>
            </h3>
            </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
