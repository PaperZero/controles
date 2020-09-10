<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Conversa.aspx.cs" Inherits="controle1.View.Conversa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gcon" runat="server">
            </asp:GridView>
            <br />
            <asp:TextBox ID="txtconv" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Atualizar" />
            <br />
            <br />
            Você esta logado como:
            <asp:Label ID="lblNome" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
