<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Funcionario.aspx.cs" Inherits="controle1.View.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

   

    
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Funcionarios<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnid" runat="server" OnClick="btnid_Click"  Text="Pesquisa ID" />
            <br />
            <br />
            nome&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID<br />
            <asp:TextBox ID="txtusu" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
            <br />
            <br />
            senha<br />
            <asp:TextBox ID="txtsen" runat="server"></asp:TextBox>
            <br />
            <br />
            cargo<br />
            <asp:TextBox ID="txtcar" runat="server"></asp:TextBox>
            <br />
            <br />
            CPF<br />
            <asp:TextBox ID="txtcpf" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnentrar" runat="server" OnClick="btnentrar_Click" Text="Cadastra" />
            &nbsp;
            <asp:Button ID="btnedi" runat="server" OnClick="btnedi_Click" Text="Edita" />
            <br />
            <br />
            <asp:Button ID="btnpesquisa" runat="server" OnClick="btnpesquisa_Click" Text="Pesquisa" />
            <br />
            <br />
            <br />
            <asp:GridView ID="Gvfun" runat="server">
            </asp:GridView>
            <br />
            <br />
            Dev tools<br />
            <asp:Button ID="btntudo" runat="server" OnClick="btntudo_Click" Text="APAGA TUDO" />
            <br />
        </div>
    </form>
</body>
</html>
