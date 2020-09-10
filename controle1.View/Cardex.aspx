<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cardex.aspx.cs" Inherits="controle1.View.Cardex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gcardex" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="btnatu" runat="server" OnClick="btnatu_Click" Text="atualizar" />
        </div>
    </form>
</body>
</html>
