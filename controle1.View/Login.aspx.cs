using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controle.DAL;

namespace controle1.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {

            string email;
            string senha;

            email = txtusu.Text;

            senha = txtsenha.Text;

            controle.DAL.DALfuncionario objentrar = new DALfuncionario();

            objentrar.login = email;
            objentrar.senha = senha;

            objentrar = objentrar.logon(objentrar);

            if (email == objentrar.login && senha == objentrar.senha)
            {
                Session["usuario"] = objentrar.IDfuncionario;

                Response.Redirect("Menu.aspx");

            }
            else
            {
                txtusu.Text = "dados incorretos";
            }

          
        }
    }
}