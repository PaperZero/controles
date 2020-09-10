<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="controle1.View.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CssMenu.css" rel="stylesheet" />
    <script src="JSmenu.js"></script>
    <title></title>
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>

   
 

</head>
<body>
    <form id="form1" runat="server">
       
       

        <asp:Button ID="btnFun" runat="server" OnClick="btnFun_Click" Text="Funcionarios" />
&nbsp; funcionando 2/6<br />
        <br />
        <asp:Button ID="btnpro" runat="server" OnClick="Button1_Click" Text="Produtos" />
        <br />
        <br />
        <asp:Button ID="btnCo" runat="server" Text="Comentarios" OnClick="btnCo_Click" />
        <br />
        <br />
        <asp:Button ID="Btncard" runat="server" Text="Cardex" OnClick="Btncard_Click" />
    </form>
</body>
</html>
