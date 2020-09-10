using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace controle1.View
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produtos.aspx");
        }

        protected void btnFun_Click(object sender, EventArgs e)
        {
            Response.Redirect("Funcionario.aspx");
        }

        protected void Btncard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cardex.aspx");
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Conversa.aspx");
        }
    }
}