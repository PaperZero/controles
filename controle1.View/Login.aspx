<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="controle1.View.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CssLogin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <div class="login-page">
  <div class="form">
    
    
    
   
      <asp:TextBox type="text" placeholder="USUARIO" runat="server" ID="txtusu"> </asp:TextBox>
      

   <asp:TextBox type="password" placeholder="SENHA" runat="server" id="txtsenha"> </asp:TextBox>

       
      <button id="BtnLogin" runat="server" onserverclick="BtnLogin_Click">login</button>
     
    
      
     
    
  </div>
</div>





        </div>
    </form>
</body>
</html>
